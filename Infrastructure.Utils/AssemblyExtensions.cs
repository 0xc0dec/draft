using System;
using System.IO;
using System.Reflection;
using Microsoft.Extensions.FileProviders;

namespace Infrastructure.Utils
{
    public static class AssemblyExtensions
    {
        public static byte[] GetEmbeddedFile(this Assembly assembly, string path)
        {
            var fileProvider = new EmbeddedFileProvider(assembly);
            var fileInfo = fileProvider.GetFileInfo(path);
            if (fileInfo?.Exists != true)
                throw new ApplicationException($"Embedded file '{path}' not found in assembly {assembly.FullName}");
            using (var stream = fileInfo.CreateReadStream())
                return stream.ReadAll();
        }

        private static byte[] ReadContent(Stream stream)
        {
            var buffer = new byte[16 * 1024];
            using (var ms = new MemoryStream())
            {
                int read;
                while ((read = stream.Read(buffer, 0, buffer.Length)) > 0)
                    ms.Write(buffer, 0, read);
                return ms.ToArray();
            }
        }
    }
}