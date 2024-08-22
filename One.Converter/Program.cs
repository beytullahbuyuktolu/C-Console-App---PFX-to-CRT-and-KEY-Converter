using One.Converter.Helper;
using System.Security.Cryptography.X509Certificates;

internal class Program
{
    private static void Main(string[] args)
    {
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
    }
}