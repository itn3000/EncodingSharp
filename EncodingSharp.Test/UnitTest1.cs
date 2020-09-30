using System;
using System.Text;
using Xunit;

namespace EncodingSharp.Test
{
    public class UnitTest1: IClassFixture<EncodingFixture>
    {
        [Theory]
        [InlineData((char)0x3072, "shift-jis")]
        public void EncodingUtf8(char ch, string encodingName)
        {
            var s = new string(ch, 10);
            var u8bytes = Encoding.UTF8.GetBytes(s);
            using(var encoder = new EncoderRs(encodingName))
            {
                var sp = new Span<byte>(u8bytes);
                Span<byte> dst = stackalloc byte[128];
                bool had_replacements = false;
                var issuccess = encoder.EncodeUtf8(u8bytes, dst, true, out var outlen, ref had_replacements);
                Assert.Equal((uint)0, issuccess);
                var enc = Encoding.GetEncoding(encodingName);
                var clsencoded = enc.GetBytes(s);
                Assert.Equal(clsencoded.Length, (int)outlen);
                Assert.Equal(clsencoded, dst.Slice(0, (int)outlen).ToArray());
            }
        }
    }
}
