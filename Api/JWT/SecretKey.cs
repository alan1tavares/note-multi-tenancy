using System.Text;

namespace Api.JWT
{
    public class SecretKey
    {
        public static string Get() => "de1fde61701241c798fceca76b375bfd";

        public static byte[] GetWithEncoding() => Encoding.UTF8.GetBytes(Get());
    }


}
