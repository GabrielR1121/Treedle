using CommunityToolkit.Mvvm.ComponentModel;

/**
 * Model for the Games keyboard. 
 * This model creates and instance of Keys for each key in the keyboard
 * Each key has an an atribute of Text, Color, Width Request and Heigth Request.
 * 
 * This model is an observable object so that each instance can be updated while the program is running
 */
namespace Treedle.Model
{
    public partial class Keys : ObservableObject
    {
        /**
         * Constructor Keys with all atributes
         */
        public Keys() {

            Color = Color.FromArgb("#787c7f");
            widthreq = 50;
            heightreq = 50;
        }

        //Observes the atribute of Keys in order to set the text of the keys.
        //Observable Property allows the key to be updated asynchronously 
        [ObservableProperty]
        private string key;

        //Observes the atribute of color in order to set the color of the keys.
        //Observable Property allows the color to be updated asynchronously 
        [ObservableProperty]
        private Color color;

        //Observes the atribute of widthreq in order to set the desired width of the keys.
        //Observable Property allows the Width to be updated asynchronously 
        [ObservableProperty]
        private int widthreq;

        //Observes the atribute of heightreq in order to set the desired height of the keys.
        //Observable Property allows the Height to be updated asynchronously 
        [ObservableProperty]
        private int heightreq;

    }
}
