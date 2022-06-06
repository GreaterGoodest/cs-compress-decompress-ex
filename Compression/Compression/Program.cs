using System;
using System.IO;
using System.IO.Compression;

namespace Compression
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine("Invalid usage.");
                Console.WriteLine("./Compression.exe [input file] [compressed result]");
                System.Environment.Exit(1);
            }
            string InputFile = args[0];  // File to compress
            string CompressedFile = args[1];  // Destination file

            FileStream inputFileStream = File.OpenRead(InputFile);
            FileStream compressedFileStream = File.Create(CompressedFile);
            GZipStream compressor = new GZipStream(compressedFileStream, CompressionMode.Compress);
            try
            {
                inputFileStream.CopyTo(compressor);
            }
            catch (IOException e)
            {
                Console.WriteLine("Unable to write compressed data: " + e);
            }
            catch (Exception e)
            {
                Console.WriteLine("Unexpected error while compressing: " + e);
            }
            finally
            {
                compressor?.Dispose();
                inputFileStream?.Dispose();
                compressedFileStream?.Dispose();
            }
        }
    }
}
