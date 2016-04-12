using System;
using System.IO;
using System.IO.Compression;
using System.Linq;

namespace OsuExtractor
{
    public class Program
    {
        private const string OsuFilter = "*.osz";
        private const string MP3 = ".mp3";
        private const string OutputDir = "output";

        public static void Main(string[] args)
        {
            Directory.CreateDirectory(OutputDir);
            foreach (string path in Directory.GetFiles(Environment.CurrentDirectory, OsuFilter, SearchOption.AllDirectories))
            {
                using (ZipArchive archive = ZipFile.OpenRead(path))
                {
                    foreach (var entry in archive.Entries.Where(x => x.FullName.EndsWith(MP3)))
                    {
                        entry.ExtractToFile(string.Format(@"{0}\{1}", OutputDir, entry.Name), true);
                    }
                } 
            }
        }
    }
}
