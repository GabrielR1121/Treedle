using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Treedle.Model
{
    public class Word
    {
        public string word { get; set; }
    }

    [JsonSerializable(typeof(List<Word>))]
    internal sealed partial class WordContext : JsonSerializerContext
    {

    }
}
