using System;
using System.Runtime.CompilerServices;

namespace EncodingSharp
{
    public class DecoderRs : IDisposable
    {
        IntPtr _Decoder;
        private bool disposedValue;

        public DecoderRs(string name)
        {
            IntPtr _Encoding = EncodingRsNative.encoding_for_label_w(name, new IntPtr((uint)name.Length));
            if(_Encoding == IntPtr.Zero)
            {
                throw new ArgumentException($"invalid encoding name({name})", "name");
            }
            _Decoder = EncodingRsNative.encoding_new_decoder(_Encoding);
        }

        public unsafe uint DecodeUtf8(ReadOnlySpan<byte> encodedbytes, Span<byte> u8dst, bool isLast, ref bool had_replacements)
        {
            var enclen = new IntPtr(encodedbytes.Length);
            var dstlen = new IntPtr(u8dst.Length);
            return EncodingRsNative.decoder_decode_to_utf8(_Decoder, in encodedbytes[0], ref enclen, ref u8dst[0], ref dstlen, isLast, ref had_replacements);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: マネージド状態を破棄します (マネージド オブジェクト)
                }

                // TODO: アンマネージド リソース (アンマネージド オブジェクト) を解放し、ファイナライザーをオーバーライドします
                EncodingRsNative.encoder_free(_Decoder);
                // TODO: 大きなフィールドを null に設定します
                disposedValue = true;
            }
        }

        ~DecoderRs()
        {
            // このコードを変更しないでください。クリーンアップ コードを 'Dispose(bool disposing)' メソッドに記述します
            Dispose(disposing: false);
        }

        public void Dispose()
        {
            // このコードを変更しないでください。クリーンアップ コードを 'Dispose(bool disposing)' メソッドに記述します
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}