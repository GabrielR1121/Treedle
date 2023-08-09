using System.Text.Json;
using Treedle.Model;
using System.Net.Http.Json;

namespace Treedle.Service
{
    public class WordService
    {
        public WordService() 
        {

        }

        List<Word> wordList;
        public async Task<List<Word>> GetWords()
        {
            using var stream = await FileSystem.OpenAppPackageFileAsync("WordList.json");
            using var reader = new StreamReader(stream);
            var contents = await reader.ReadToEndAsync();
            wordList = JsonSerializer.Deserialize(contents, WordContext.Default.ListWord);


            return wordList;
        }
    }
}
