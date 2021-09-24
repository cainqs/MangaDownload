using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace Services
{
    public class MangaService
    {
        public static string GenerateFolder(string folder, string mangeName, int count)
        {
            if (!folder.EndsWith(Path.DirectorySeparatorChar))
            {
                folder += Path.DirectorySeparatorChar;
            }

            var tempFolder = folder + mangeName + "_" + DateTime.Now.ToString("yyy-MM-dd-HH-mm-ss") + "-" + count + Path.DirectorySeparatorChar;

            if (!Directory.Exists(tempFolder))
            {
                Directory.CreateDirectory(tempFolder);
            }

            return tempFolder;
        }

        public static string GenerateSubFolder(string folder)
        {
            if (!folder.EndsWith(Path.DirectorySeparatorChar))
            {
                folder += Path.DirectorySeparatorChar;
            }

            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }

            return folder;
        }

        public static string Zip(string root, string targetFile)
        {
            var res = ZipHelper.Zip(root, targetFile);

            if (res)
            {
                return targetFile;
            }

            return "";
        }
    }
}
