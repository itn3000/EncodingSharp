using System;
using System.Text;
using Xunit;

namespace EncodingSharp.Test
{
    public class EncodingFixture : IDisposable
    {
        public EncodingFixture()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        }
        public void Dispose()
        {
        }
    }
}