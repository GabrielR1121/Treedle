using CommunityToolkit.Mvvm.ComponentModel;
using Treedle.Model;
using CommunityToolkit.Mvvm.Input;
using Treedle.Service;
using System.Collections.ObjectModel;
using Microsoft.Maui.Controls;
using Treedle.View;
using Mopups.Services;

namespace Treedle.ViewModel
{
    public partial class GameViewModel : ObservableObject
    {
        public List<string> WordList { get; } = new();

        int rowIndex;
        int columnIndex;

        char [] correctAnswer;

        public Keys[] keyboardRow1 { set; get; }

        public Keys[] keyboardRow2 { set;  get; }
        public Keys[] keyboardRow3 { set;  get; }

        public Keys[] pressedKeys { set; get; }


        public string []key1 = "Q W E R T Y U I O P".Split(" ");

        public string[] key2 = "A S D F G H J K L".Split(" ");

        public string[] key3 = "Enter Z X C V B N M Delete".Split(" ");

        [ObservableProperty]
        private WordRows[] rows;

        public GameViewModel(List<string> wordList)
        {
            this.WordList = wordList;

            correctAnswer = getNewWord().ToCharArray();
            

            rows = new WordRows[6]
            {
                new WordRows(),
                new WordRows(),
                new WordRows(),
                new WordRows(),
                new WordRows(),
                new WordRows()
            };

            

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

            pressedKeys = new Keys[5]
            {
                new Keys(),
                new Keys(),
                new Keys(),
                new Keys(),
                new Keys()
            };

            for(int i =0; i < keyboardRow1.Length; i++) 
            {
                keyboardRow1[i].Key = key1[i];
            }

            for (int i = 0; i < keyboardRow2.Length; i++)
            {
                keyboardRow2[i].Key = key2[i];
            }
            for (int i = 0; i < keyboardRow3.Length; i++)
            {
                keyboardRow3[i].Key = key3[i];
                if (key3[i].Equals("Enter") || key3[i].Equals("Delete"))
                {
                    keyboardRow3[i].Widthreq = 75;
                }
            }


            
        }

        public async void Enter()
        {
            if (columnIndex != 5)
                return;

            var correct = false;
            var isInWordList = Rows[rowIndex].IsWordInWordList(WordList);


            if (isInWordList)
                correct = Rows[rowIndex].Validate(correctAnswer, pressedKeys);
            else
            {
                await MopupService.Instance.PushAsync(new NotWordPage());
                return;
            }

           

            if (correct)
            {
              await MopupService.Instance.PushAsync(new PlayerStatsPage(new string(correctAnswer), WordList));
              return;
            }
            else
            {
                rowIndex++;
                columnIndex = 0;
            }

            if(rowIndex == 6)
            {
                await MopupService.Instance.PushAsync(new PlayerStatsPage(new string(correctAnswer), WordList));
                return;
            }

            
        }

        [RelayCommand]
        public void EnterLetter(Keys key)
        {
            string letter = key.Key;

            if(letter.Equals("Enter"))
            {
                Enter();
                return;
            }

            if (letter.Equals("Delete"))
            {
                if (columnIndex == 0)
                    return;

                columnIndex--;
                Rows[rowIndex].Letters[columnIndex].Input = " ";
                return;

            }

            

            if (columnIndex == 5)
                return;

            pressedKeys[columnIndex] = key;

            Rows[rowIndex].Letters[columnIndex].Input = letter;
            columnIndex++;
        }

   

        public string getNewWord()
        {
            Random rand = new Random();
            return WordList[rand.Next(0,WordList.Count)];
        }

    }

    
}
