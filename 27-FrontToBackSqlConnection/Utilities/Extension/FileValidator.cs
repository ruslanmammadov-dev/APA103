using _27_FrontToBackSqlConnection.Utilities.Enums;

namespace _27_FrontToBackSqlConnection.Utilities.Extension
{
    public static class FileValidator
    {
        public static bool CheckFileType(this IFormFile file, string type)
        {
            return file.ContentType.Contains(type);
        }

        public static bool CheckFileSize(this IFormFile file, FileSizes fileSize, int size)
        {
            switch (fileSize)
            {
                case FileSizes.KB:
                    return file.Length <= size * 1024;
                case FileSizes.MB:
                    return file.Length <= size * 1024 * 1024;
                case FileSizes.GB:
                    return file.Length <= size * 1024L * 1024 * 1024;
            }
            return false;
        }

        public static async Task<string> CreateFile(this IFormFile file, params string[] roots)
        {
            string fileName = string.Concat(Guid.NewGuid().ToString(), file.FileName);

            string path = string.Empty;

            for (int i = 0; i < roots.Length; i++)
            {
                path = Path.Combine(path, roots[i]);
            }

            path = Path.Combine(path, fileName);

            using (FileStream fileStream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            return fileName;
        }

        public static void DeleteFile(this string filename, params string[] roots)
        {
            string path = string.Empty;

            for (int i = 0; i < roots.Length; i++)
            {
                path = Path.Combine(path, roots[i]);
            }

            path = Path.Combine(path, filename);

            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }
    }
}
