using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace One.Converter.Helper;

public class ConvertHelper
{

    public static string ExportToPem(X509Certificate2 cert)
    {
        StringBuilder builder = new StringBuilder();
        builder.AppendLine("-----BEGIN CERTIFICATE-----");
        builder.AppendLine(Convert.ToBase64String(cert.RawData, Base64FormattingOptions.InsertLineBreaks));
        builder.AppendLine("-----END CERTIFICATE-----");
        return builder.ToString();
    }

    //Extract Private Key in PEM format 
    public static string ExportPrivateKey(X509Certificate2 cert)
    {
        var rsa = cert.GetRSAPrivateKey();
        if (rsa == null) return null;
        var builder = new StringBuilder();
        builder.AppendLine("-----BEGIN PRIVATE KEY-----");
        builder.AppendLine(Convert.ToBase64String(rsa.ExportPkcs8PrivateKey(), Base64FormattingOptions.InsertLineBreaks));
        builder.AppendLine("-----END PRIVATE KEY-----");
        return builder.ToString();
    }
}