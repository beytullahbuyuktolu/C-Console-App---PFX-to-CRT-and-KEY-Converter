# PFX to CRT and KEY Converter

This project is a simple C# console application that converts a PFX (Personal Information Exchange) file into separate CRT (Certificate) and KEY (Private Key) files. This is particularly useful when you need to extract these files to be used in web servers or other applications.

## Features

- Converts a PFX file to CRT (certificate) format.
- Extracts the private key from a PFX file into a separate KEY file.
- Outputs the CRT and KEY files in PEM format, ready for use.

## Prerequisites

- [.NET Core SDK](https://dotnet.microsoft.com/download) (3.1 or later)
- A valid PFX file that contains both a certificate and a private key.

## How to Use

1. Clone this repository to your local machine:

    ```bash
    git clone https://github.com/beytullahbuyuktolu/PFX-to-CRT-and-KEY-Converter.git
    ```

2. Open the project in your preferred C# IDE (e.g., Visual Studio, Visual Studio Code).

3. Update the `pfxFilePath`, `pfxConvertPath`, and `pfxPassword` variables in `Program.cs` with the path to your PFX file, the path where you want to save the converted files, and the PFX file's password.

4. Build and run the project:

    ```bash
    dotnet run
    ```

5. The CRT and KEY files will be generated in the specified directory.

## Example

Here is an example of how to configure and use the application:

```csharp
// Specify the path and password of the PFX file
string pfxFilePath = @"C:\ssl\SSLPfxFile.pfx";
string pfxConvertPath = @"C:\ssl\";
string pfxPassword = "SSLPfxFilePassword";

// Load PFX file
var cert = new X509Certificate2(pfxFilePath, pfxPassword, X509KeyStorageFlags.Exportable);

// Extract and save the CRT file
var crt = ConvertHelper.ExportToPem(cert);
File.WriteAllText(pfxConvertPath + "certificate.crt", crt);

// Extract and save the private.key file
var privateKey = ConvertHelper.ExportPrivateKey(cert);
if (privateKey != null)
{
    File.WriteAllText(pfxConvertPath + "private.key", privateKey);
    Console.WriteLine("CRT and KEY files created successfully.");
}
else
    Console.WriteLine("The private key was not found or is inaccessible.");
