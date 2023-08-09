using CommunityToolkit.Mvvm.ComponentModel;

namespace Treedle.Model
{
    public class WordRows
    {
        public WordRows() 
        {
            Letters = new Letter[5]
            {
                new Letter(),
                new Letter(),
                new Letter(),
                new Letter(),
                new Letter()
            };
        }
        public Letter[] Letters { get; set; }

        public bool Validate(char[] correctAnswer , Keys[] pressedKeys)
        {
            Dictionary<string, int> dictionary = new Dictionary<string, int>();
            for (int i = 0;i <correctAnswer.Length; i++)
                if (!dictionary.ContainsKey(correctAnswer[i] + ""))
                    dictionary.Add(correctAnswer[i]+"", 1);
                else 
                    dictionary[correctAnswer[i]+""]++;
            
            int count = 0;
            for(int i=0; i< Letters.Length; i++)
            {
                var letter = Letters[i];
                var key = pressedKeys[i];
                if (letter.Input.Equals(correctAnswer[i]+""))
                {
                    letter.Color = Color.FromArgb("#6ca965");
                    letter.Framecolor = Color.FromArgb("#6ca965");
                    key.Color = Color.FromArgb("#6ca965");
                    count++;
                    dictionary[letter.Input]--;
                }
                else if (correctAnswer.Contains(char.Parse(letter.Input)) && dictionary[letter.Input] >= 1)
                {
                    letter.Color = Color.FromArgb("#c8b653");
                    letter.Framecolor = Color.FromArgb("#c8b653");
                    key.Color = Color.FromArgb("#c8b653");
                    dictionary[letter.Input]--;
                }
                else
                {
                    letter.Color = Color.FromArgb("#787c7f");
                    key.Color = Colors.LightSalmon;
                }


            }

            return count == 5;
        }

        public bool IsWordInWordList(List<string> wordList)
        {
            var test = new Word();


            for (int i = 0; i < Letters.Length; i++)
            {
                test.word += Letters[i].Input;
            }

            return wordList.IndexOf(test.word) >= 0;
        }
    }

    public partial class Letter : ObservableObject
    {
        public Letter() 
        {
            Color = Colors.Black;
            Framecolor = Color.FromArgb("#787c7f");
        }

        [ObservableProperty]
        private string input;

        [ObservableProperty]
        private Color color;

        [ObservableProperty]
        private Color framecolor;
    }
}
