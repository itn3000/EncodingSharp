using System;
using System.Runtime.CompilerServices;

namespace EncodingSharp
{
    public class EncoderRs : IDisposable
    {
        IntPtr _Encoder;
        private bool disposedValue;

        public EncoderRs(string name)
        {
            IntPtr _Encoding = EncodingRsNative.encoding_for_label_w(name, new IntPtr((uint)name.Length));
            if(_Encoding == IntPtr.Zero)
            {
                throw new ArgumentException($"invalid encoding name({name})", "name");
            }
            _Encoder = EncodingRsNative.encoding_new_encoder(_Encoding);
            if(_Encoder == IntPtr.Zero)
            {
                throw new Exception($"failed to get encoder object({name})");
            }
        }

        public unsafe uint EncodeUtf8(ReadOnlySpan<byte> u8bytes, Span<byte> dst, bool isLast, ref bool had_replacements)
        {
            // throw new Exception($"encoder addr is {_Encoder}");
            var u8len = new IntPtr(u8bytes.Length);
            // var u8len = (uint)u8bytes.Length;
            var dstlen = new IntPtr(dst.Length);
            return EncodingRsNative.encoder_encode_from_utf8(_Encoder, in u8bytes[0], ref u8len, ref dst[0], ref dstlen, isLast, ref had_replacements);
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
                EncodingRsNative.encoder_free(_Encoder);
                // TODO: 大きなフィールドを null に設定します
                disposedValue = true;
            }
        }

        ~EncoderRs()
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