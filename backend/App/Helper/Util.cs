using System.Globalization;
using System.Security.Cryptography;
using System.Text;

public class Util
{
    public static DateTime DateTimeNow()
    {
        return DateTime.UtcNow;
    }

    public static string GerarHashSenha(string senha)
    {
        using (SHA256 sha256 = SHA256.Create())
        {
            byte[] bytes = Encoding.UTF8.GetBytes(senha);
            byte[] hash = sha256.ComputeHash(bytes);
            StringBuilder sb = new StringBuilder();
            foreach (byte b in hash)
            {
                sb.Append(b.ToString("x2"));
            }
            return sb.ToString();
        }
    }

    public static DateTime? ConverterParaDataComHora(string dataString)
    {
        string[] formatos = {
        "yyyy-MM-dd",
        "yyyy-MM-ddTHH:mm:ss",
        "yyyy-MM-ddTHH:mm:ss.fff",
        "yyyy-MM-ddTHH:mm:ssZ",
        "yyyy-MM-ddTHH:mm:ss.fffZ"
    };

        if (DateTime.TryParseExact(dataString, formatos,
            System.Globalization.CultureInfo.InvariantCulture,
            System.Globalization.DateTimeStyles.AdjustToUniversal,
            out DateTime dataConvertida))
        {
            return dataConvertida;
        }

        return null;
    }

    public static DateTime? ConverterDataHoraBR(string dataString)
    {
        if (DateTime.TryParseExact(dataString, "dd/MM/yyyy HH:mm:ss",
            System.Globalization.CultureInfo.InvariantCulture,
            System.Globalization.DateTimeStyles.None, out DateTime dataConvertida))
        {
            return dataConvertida;
        }

        return null;
    }

    public static DateTime ConverterParaDate(string dataString)
    {
        DateTime dataOriginal = DateTime.ParseExact(dataString, "yyyy-MM-dd", CultureInfo.InvariantCulture);
        DateTime dataUtc = DateTime.SpecifyKind(dataOriginal, DateTimeKind.Utc);

        return dataUtc;
    }
}