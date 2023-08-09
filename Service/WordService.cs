using System.Text.Json;
using Treedle.Model;


/**
 * Creates a Service call to the WordList.json file 
 * This class serves as the access to the Data Base or to an API. 
 * 
 ***** Eventually i would like to create my own REST API and have this service access that****
 */
namespace Treedle.Service
{
    public class WordService
    {
        public WordService() 
        {

        }

        //Creates a List filled with Word
        List<Word> wordList;

        /**
         * Opens the JSON file and retrives all the words within the file
         * 
         * Returns a List of the Model Word.
         */
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
