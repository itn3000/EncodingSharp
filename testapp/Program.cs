using System;
using System.Text;
using System.Linq;
using EncodingSharp;

namespace testapp
{
    class Program
    {
        static void Main(string[] args)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            var s = new string((char)0x3072, 10);
            var u8bytes = Encoding.UTF8.GetBytes(s);
            var encoded = new byte[128];
            using(var encoder = new EncoderRs("shift-jis"))
            {
                bool had_replacements = true;
                var issuccess = encoder.EncodeUtf8(u8bytes, encoded, true, out var outlen, ref had_replacements);
                Console.WriteLine("{0}, {1}", issuccess,
                    string.Join(":", encoded.AsSpan(0, (int)outlen).ToArray().Select(x => x.ToString("x2"))));
                Console.WriteLine("{0}",
                    string.Join(":", Encoding.GetEncoding("shift-jis").GetBytes(s).Select(x => x.ToString("x2"))));
            }
        }
    }
}
