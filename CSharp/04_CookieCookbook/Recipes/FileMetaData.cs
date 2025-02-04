namespace CookiesCookbook.Recipes.FileMetaData
{
    public enum FileFormat
    {
        Json,
        txt
    }

    public class FileMetadata
    {
        private string FileName {get;}
        private FileFormat Format {get;}
        public FileMetadata(string fileName, FileFormat format)
        {
            FileName = fileName;
            Format = format;
        }

        public string ToPath() => $"{FileName}.{Format.AsFileExtensions()}";
    }

    public static class FileFormatExtensions
    {
        public static string AsFileExtensions(this FileFormat fileFormat) => fileFormat == FileFormat.Json ? "json" : "txt";
    }
}