using CommunityToolkit.Mvvm.ComponentModel;
using Treedle.Model;
using CommunityToolkit.Mvvm.Input;
using Treedle.View;
using Mopups.Services;

namespace Treedle.ViewModel
{
    /**
     * Game view Model class.
     * This class holds all the commands used in the game page view class
     */
    public partial class GameViewModel : ObservableObject
    {
        //Creates an instance of Word List to store all the words 
        public List<string> WordList { get; } = new();

        //Creates the row index
        int rowIndex;

        //Creates the column index
        int columnIndex;

        //Creates the array that will store the correct answer
        char [] correctAnswer;

        //Creates the array that will hold the first row of the keyboard
        public Keys[] keyboardRow1 { set; get; }

        //Creates the array that will hold the second row of the keybaord
        public Keys[] keyboardRow2 { set;  get; }

        //Creates the array that will hold the third array of the keyboard
        public Keys[] keyboardRow3 { set;  get; }

        //Creates the array  that will store the pressed keys
        public Keys[] pressedKeys { set; get; }

        //Array that stores the characters in the first row of the keyboard
        public string []key1 = "Q W E R T Y U I O P".Split(" ");

        //Array that stores the characters in the second row of the keyboard
        public string[] key2 = "A S D F G H J K L".Split(" ");

        //Array that stores the third row of the keyboard
        public string[] key3 = "Enter Z X C V B N M Delete".Split(" ");


        //Observable property of the array rows to allow the array to be accessed asynchronously
        [ObservableProperty]
        private WordRows[] rows;


        /**
         * Constructor of the GameViewModel
         * 
         * Receives the word list as a parameter
         */
        public GameViewModel(List<string> wordList)
        {
            //Stores the word list in the instance
            this.WordList = wordList;

            //Retreives the new word to use a correct answer
            correctAnswer = getNewWord().ToCharArray();
            
            //Initiates the rows to be used in the game
            rows = new WordRows[6]
            {
                new WordRows(),
                new WordRows(),
                new WordRows(),
                new WordRows(),
                new WordRows(),
                new WordRows()
            };

            
            //Initiates the keyboard row 1 to be used in the game 
            keyboardRow1 = new Keys[10]
            {
                new Keys(),
                new Keys(),
                new Keys(),
                new Keys(),
                new Keys(),
                new Keys(),
                new Keys(),
                new Keys(),
                new Keys(),
                new Keys()

            };

            //Initiates the keyboard row 2 to be used in the game 
            keyboardRow2 = new Keys[9]
            {
                new Keys(),
                new Keys(),
                new Keys(),
                new Keys(),
                new Keys(),
                new Keys(),
                new Keys(),
                new Keys(),
                new Keys()
            };

            //Initiates the keyboard row 3 to be used in the game 
            keyboardRow3 = new Keys[9]
            {
                new Keys(),
                new Keys(),
                new Keys(),
                new Keys(),
                new Keys(),
                new Keys(),
                new Keys(),
                new Keys(),
                new Keys()
            };

            //Initiates the pressed keys to be used in the game
            pressedKeys = new Keys[5]
            {
                new Keys(),
                new Keys(),
                new Keys(),
                new Keys(),
                new Keys()
            };

            //Fills the keyboard row 1 array with the appropriate keys 
            for(int i =0; i < keyboardRow1.Length; i++) 
                keyboardRow1[i].Key = key1[i];

            //Fills the keyboard row 2 array with the appropriate keys 
            for (int i = 0; i < keyboardRow2.Length; i++)
                 keyboardRow2[i].Key = key2[i];

            //Fills the keyboard row 3 array with the appropriate keys and formating
            for (int i = 0; i < keyboardRow3.Length; i++)
            {
                keyboardRow3[i].Key = key3[i];
                if (key3[i].Equals("Enter") || key3[i].Equals("Delete"))
                {
                    keyboardRow3[i].Widthreq = 75;
                }
            }


            
        }


        /**
         * When the enter button is pressed verify the word, validate the letters, and end or continue the game
         */
        public async void Enter()
        {
            //If the user has not entered a 5 letter word do nothing
            if (columnIndex != 5)
                return;
            //Initializes the correct answer variable to false
            var correct = false;

            //Verififies if the entered wored is in the Word List
            var isInWordList = Rows[rowIndex].IsWordInWordList(WordList);

            //IF the word is in the word list then vaidate the letters 
            if (isInWordList)
                correct = Rows[rowIndex].Validate(correctAnswer, pressedKeys);
            //Else show pop up alerting that the word is not in the Word List
            else
            {
                await MopupService.Instance.PushAsync(new NotWordPage());
                return;
            }

           
            //If the validation returned true then end the game and show the stats Pop Up
            if (correct)
            {
              await MopupService.Instance.PushAsync(new PlayerStatsPage(new string(correctAnswer), WordList));
              return;
            }
            //Else change to the next row and set column to 0
            else
            {
                rowIndex++;
                columnIndex = 0;
            }

            //If all rows were used then end the game and show correct answer
            if(rowIndex == 6)
            {
                await MopupService.Instance.PushAsync(new PlayerStatsPage(new string(correctAnswer), WordList));
                return;
            }

            
        }

        /**
         * When a key is pressed in the game page view Relay that command to this method
         * Receives the key that was pressed.
         */
        [RelayCommand]
        public void EnterLetter(Keys key)
        {
            //Stores the string of the key in a variable
            string letter = key.Key;

            //If the key pressed is ENTER then run the Enter method()
            if(letter.Equals("Enter"))
            {
                Enter();
                return;
            }

            //If the key pressed is DELETE 
            if (letter.Equals("Delete"))
            {
                //Verify that the cursor is not in the begginning of the row
                if (columnIndex == 0)
                    return;

                //Decrement row index
                columnIndex--;

                //Clear the text within that slot 
                Rows[rowIndex].Letters[columnIndex].Input = " ";
                return;

            }

            
            //If the user attempts to enter a 6 or more letter word then do not do anything
            if (columnIndex == 5)
                return;

            //Store the pressed key
            pressedKeys[columnIndex] = key;

            //Displays the pressed key text to the page if all other filters were passed
            Rows[rowIndex].Letters[columnIndex].Input = letter;

            //Increment the column index
            columnIndex++;
        }

   
        /**
         * Gets a new word from the wordlist at random
         */
        public string getNewWord()
        {
            Random rand = new Random();
            return WordList[rand.Next(0,WordList.Count)];
        }

    }

    
}
