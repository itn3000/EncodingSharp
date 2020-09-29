using System.Runtime.InteropServices;
using System.Runtime;
using System;

namespace EncodingSharp
{
    internal static class EncodingRsNative
    {
        [DllImport("encoding_rs_glue", CallingConvention = CallingConvention.Cdecl)]
        public extern static void encoder_free(IntPtr encoder);
        [DllImport("encoding_rs_glue", CallingConvention = CallingConvention.Cdecl)]
        public extern static uint decoder_decode_to_utf8(IntPtr decoder, in byte src, ref IntPtr src_len, ref byte dst, ref IntPtr dst_len, bool isLast, ref bool had_replacements);
        [DllImport("encoding_rs_glue", CallingConvention = CallingConvention.Cdecl)]
        public extern static uint encoder_encode_from_utf8(IntPtr encoder, in byte src, ref IntPtr src_len, ref byte dst, ref IntPtr dst_len, bool isLast, ref bool had_replacements);
        [DllImport("encoding_rs_glue", CallingConvention = CallingConvention.Cdecl)]
        public extern static IntPtr encoding_new_decoder(IntPtr encoding);
        [DllImport("encoding_rs_glue", CallingConvention = CallingConvention.Cdecl)]
        public extern static IntPtr encoding_new_encoder(IntPtr encoding);
        [DllImport("encoding_rs_glue", CallingConvention = CallingConvention.Cdecl, EntryPoint = "encoding_for_label")]
        public extern static IntPtr encoding_for_label_u8(in byte label, IntPtr label_size);
        [DllImport("encoding_rs_glue", CallingConvention = CallingConvention.Cdecl, EntryPoint = "encoding_for_label", CharSet = CharSet.Ansi)]
        public extern static IntPtr encoding_for_label_w(string label, IntPtr label_size);
    }
}