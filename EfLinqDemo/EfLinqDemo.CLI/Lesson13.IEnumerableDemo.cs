using System;
using System.Linq;

namespace EfLinqDemo.CLI
{
    public class Lesson13_IEnumerableDemo
    {
        public static void BasicExample()
        {
            var contents = System.IO.Directory.EnumerateFileSystemEntries(@"C:\");
            foreach (var item in contents)
            {
                Console.WriteLine($"Name: `{item}`");
            }
        }

        public static void BasicWithLinq()
        {
            var contents = from entry in System.IO.Directory.EnumerateFileSystemEntries(@"C:\")
                           let info = new System.IO.FileInfo(entry)
                           where !info.Attributes.HasFlag(System.IO.FileAttributes.System) && !info.Attributes.HasFlag(System.IO.FileAttributes.Hidden)
                           group entry by entry[3] into entriesByFirstLetter
                           select entriesByFirstLetter;

            foreach (var item in contents)
            {
                var entries = string.Join(", ", item);
                Console.WriteLine($"Names starting with `{item.Key}`: {entries}");
            }
        }

        public static void BasicWithoutLinq()
        {
            foreach (var entry in System.IO.Directory.EnumerateFileSystemEntries(@"C:\"))
            {
                var info = new System.IO.FileInfo(entry);
                if (!info.Attributes.HasFlag(System.IO.FileAttributes.System) && !info.Attributes.HasFlag(System.IO.FileAttributes.Hidden))
                {
                    Console.WriteLine($"Name: {entry}");
                }
            }
        }
    }
}
