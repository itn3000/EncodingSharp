# Overview

This is the playground for how to manage the interop CLR library with native library.

# Projects

* encoding-rs-glue
    * rust project using [encoding_c](https://docs.rs/encoding_c/0.9.8/encoding_c/) (assuming native library)
* EncodingSharp.Native
    * intermediate package for bridging with native and managed.
    * including only native library
    * used by EncodingSharp project
* EncodingSharp
    * Wrapper project
    * references EncodingSharp.Native with PackageReference
* EncodingSharp.Test
    * xunit test project
* testapp
    * console app using EncodingSharp

# Build

1. install rust toolchain
2. add `x86_64-pc-winodws-msvc` and `i686-pc-windows-msvc` to rust target(by `rustup target add [targetname]`)
3. build `encoding-rs-glue` project by `cargo build --target [targetname]`
4. build nuget package by `dotnet pack -o nupkg EncodingSharp.Native/EncodingSharp.Native.csproj`
    * this will output `nupkg/EncodingSharp.Native.1.0.0.nupkg`
5. build remaining projects by `dotnet build`