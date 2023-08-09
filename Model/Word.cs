using System.Text.Json.Serialization;

/**
 * Model for the Word List. 
 * This model creates and instance of Word for each word in the Word List
 * 
 * This model is an observable object so that each instance can be updated while the program is running
 */
namespace Treedle.Model
{
    //Receives the word from the word list
    public class Word
    {
        public string word { get; set; }
    }

    //Allows the class to access the json file
    [JsonSerializable(typeof(List<Word>))]
    internal sealed partial class WordContext : JsonSerializerContext
    {

    }
}
