using CommunityToolkit.Mvvm.ComponentModel;

/**
 * Model for each row in the game AND 
 * Model for each letter in the row.
 * 
 * This model creates and instance for each row in the game and each word has an instance of letter
 * 
 * WordRow Has no atributes
 * Letter has the atributes of the letter and the color of the letter and frame
 * 
 * This model is an observable object so that each instance can be updated while the program is running
 */
namespace Treedle.Model
{
    public class WordRows
    {
        //For each instance of Word Rows there is an array filled with 5 instances of letter.
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

        //Creates and instance of letters to get and set 
        public Letter[] Letters { get; set; }

        /**
         * Validates if the word entered is correct
         * Recieves the array containing the correct answer and an array of the keys pressed
         * Returns a boolean value depending if the word is 100% correct or not.
         */
        public bool Validate(char[] correctAnswer , Keys[] pressedKeys)
        {
            //Creates a dictionary in order to see how many letters are repeated in the answer array
            Dictionary<string, int> dictionary = new Dictionary<string, int>();

            //Traverse correct answer array
            for (int i = 0;i <correctAnswer.Length; i++)
                //If the letter is not in the dictionary then add it with a value of 1
                if (!dictionary.ContainsKey(correctAnswer[i] + ""))
                    dictionary.Add(correctAnswer[i]+"", 1);
                //Else increment the value by 1
                else 
                    dictionary[correctAnswer[i]+""]++;
            
            //Creates variable to count how mnay correct letter in the correct positions were achieved
            int count = 0;

            //Traverses the letter array 
            for(int i=0; i< Letters.Length; i++)
            {
                //Creates a variable to store the instance of the letter
                var letter = Letters[i];
                //Createsa variable to store the instance of the pressed key
                var key = pressedKeys[i];

                //If the letter is in the correct position then:
                //   Change the background color of the letter to green
                //   Change the frame of the letter to green
                //   Change the color of the pressed key to green
                //   Increase the value of count by 1
                //   Decrease the value of the letter in the dictionary by 1
                if (letter.Input.Equals(correctAnswer[i]+""))
                {
                    letter.Color = Color.FromArgb("#6ca965");
                    letter.Framecolor = Color.FromArgb("#6ca965");
                    key.Color = Color.FromArgb("#6ca965");
                    count++;
                    dictionary[letter.Input]--;
                }
                //If the letter is in the word but not in the correct postion AND the value of the dictionary is more than or equal to 1 then:
                //   Change the background color of the letter to yellow
                //   Change the frame of the letter to yellow
                //   Change the color of the pressed key to yellow
                //   Decrease the value of the letter in the dictionary by 1
                else if (correctAnswer.Contains(char.Parse(letter.Input)) && dictionary[letter.Input] >= 1)
                {
                    letter.Color = Color.FromArgb("#c8b653");
                    letter.Framecolor = Color.FromArgb("#c8b653");
                    key.Color = Color.FromArgb("#c8b653");
                    dictionary[letter.Input]--;
                }
                //Else the letter is not in the word:
                //    Change the background color of the letter to gray
                //    Change the color of the pressed key to red.
                else
                {
                    letter.Color = Color.FromArgb("#787c7f");
                    key.Color = Colors.LightSalmon;
                }


            }
            //If all letters are in the word and in the correct position then return true else false
            return count == 5;
        }

        /**
         * Checks if the entered word is in the word list or not
         * 
         * Receives the word list
         * 
         * Returns boolean value if the word is in the word list or not
         */
        public bool IsWordInWordList(List<string> wordList)
        {
            //Creates and stores an instance of word 
            var word = new Word();


            //Traverse the letters array in order to get the entered word.
            for (int i = 0; i < Letters.Length; i++)
                word.word += Letters[i].Input;

            //If the word is in the word list then return true else false.
            return wordList.IndexOf(word.word) >= 0;
        }
    }
    /**
     * Model class for letters
     */
    public partial class Letter : ObservableObject
    {
        //Constructor for the Letters model
        public Letter() 
        {
            Color = Colors.Black;
            Framecolor = Color.FromArgb("#787c7f");
        }

        //Observes the atribute of input in order to set the text of the letter.
        //Observable Property allows the letter to be updated asynchronously 
        [ObservableProperty]
        private string input;

        //Observes the atribute of color in order to set the color of the letter.
        //Observable Property allows the letter to be updated asynchronously 
        [ObservableProperty]
        private Color color;


        //Observes the atribute of framecolor in order to set the frame color of the letter.
        //Observable Property allows the letter to be updated asynchronously 
        [ObservableProperty]
        private Color framecolor;
    }
}
