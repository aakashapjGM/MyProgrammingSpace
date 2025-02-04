using System.Text.Json;

namespace CookiesCookbook.Recipes.StringRepository
{
    public interface IStringRepository
    {
        List<string> Read(string filePath);
        void Write(string filePath, List<string> strings);
    }

    public abstract class StringRepository : IStringRepository
    {
        private static readonly string Separator = Environment.NewLine;
        public List<string> Read(string filePath)
        {
            if(File.Exists(filePath))
            {
                var fileContents = File.ReadAllText(filePath);
                return TextToString(fileContents);
            }
            
            return new List<string>();
            
        }

        protected abstract List<string> TextToString(string fileContents);

        public void Write(string filePath, List<string> strings)
        {
            File.WriteAllText(filePath, StringToText(strings));
        }

        protected abstract string StringToText(List<string> strings);
    }

    public class StringTextualRepository : StringRepository
    {
        private static readonly string Separator = Environment.NewLine;

        protected override List<string> TextToString(string fileContents)
        {
            return fileContents.Split(Separator).ToList();
        }


        protected override string StringToText(List<string> strings)
        {
            return string.Join(Separator, strings);
        }
    }

    public class StringJsonRepository : StringRepository
    {
        protected override List<string> TextToString(string fileContents)
        {
            return JsonSerializer.Deserialize<List<string>>(fileContents);
        }


        protected override string StringToText(List<string> strings)
        {
            return JsonSerializer.Serialize(strings);
        }
    }
}




// using System.Text.Json;

// namespace CookiesCookbook.Recipes.StringRepository
// {
//     public interface IStringRepository
//     {
//         List<string> Read(string filePath);
//         void Write(string filePath, List<string> strings);
//     }

//     public class StringTextualRepository : IStringRepository
//     {
//         private static readonly string Separator = Environment.NewLine;
//         public List<string> Read(string filePath)
//         {
//             if(File.Exists(filePath))
//             {
//                 var fileContents = File.ReadAllText(filePath);
//                 return fileContents.Split(Separator).ToList();
//             }
            
//             return new List<string>();
            
//         }

//         public void Write(string filePath, List<string> strings)
//         {
//             File.WriteAllText(filePath, string.Join(Separator, strings));
//         }
//     }

//     public class StringJsonRepository : IStringRepository
//     {
//         public List<string> Read(string filePath)
//         {
//             if(File.Exists(filePath))
//             {
//                 var fileContents = File.ReadAllText(filePath);
//                 return JsonSerializer.Deserialize<List<string>>(fileContents);
//             }
            
//             return new List<string>();
            
//         }

//         public void Write(string filePath, List<string> strings)
//         {
//             File.WriteAllText(filePath, JsonSerializer.Serialize(strings));
//         }
//     }
// }