namespace Treedle;
/**
 * TO-DO: 
 *      * Figure out if there is a way to add a loading screen or soemthing between MainPage and playGame.
 *      * Resize Keyboard buttons and remove gray background
 *      * Start working on game logic.
 */
public partial class playGame : ContentPage
{
    public playGame()
    {
        //Creates the title information at the top of the screen.
        createTitle();

        //Creates the verticle layout that holds the items in the page
        VerticalStackLayout verticalStackLayout = new VerticalStackLayout { 
        BackgroundColor=Colors.Black};



        //Adds the game grid to the vertical layout
        verticalStackLayout.Add(createGameGrid());

        //Adds all three rows of the keyboard to the vertical layout
        for (int keyboardRow = 0; keyboardRow < 3; keyboardRow++)
            verticalStackLayout.Add(createKeyboardGrid(keyboardRow));

        //Adds the vertical layout contents to the Content Page
        Content = verticalStackLayout;


    }
    /**
     * Adds cosmetics and proper settings to Navigation Page.
     */
    public void createTitle()
    {
        //Sets the title to Treedle
        NavigationPage.SetTitleView(this, new Label
        {
            Text = "Treedle",
            FontSize = 50,
            TextColor = Colors.White,
            HorizontalOptions = LayoutOptions.Center
        });

        //Removes the back button from the navigation bar.
        NavigationPage.SetHasBackButton(this, false);
    }
    /**
     * Creates the grid system in treedle. 
     * Creates all 6 rows and 5 Columns 
     */
    public Grid createGameGrid()
    {

        //Creates the grid with the appropriate cosmetics and settings
        Grid grid = new Grid
        {
            Margin = new Thickness(0, 40, 0, 90),
            ColumnSpacing = 10,
            RowSpacing = 10,
            HorizontalOptions = LayoutOptions.Center,


            RowDefinitions =
            {
                new RowDefinition(),
                new RowDefinition(),
                new RowDefinition(),
                new RowDefinition(),
                new RowDefinition(),
                new RowDefinition()
            },
            ColumnDefinitions =
            {
                new ColumnDefinition(),
                new ColumnDefinition(),
                new ColumnDefinition(),
                new ColumnDefinition(),
                new ColumnDefinition()
            }
        };

        //Creates each grid by making using the createBorder and createLabel Message.
        for (int row = 0; row < 5; row++)
            for (int col = 0; col < 6; col++)
            {
               grid.Add(createBorder(createLabel()), row, col);
            }

        return grid;

    }

    /**
     * Creates a default label that holds a default element of X.
     * X string is created to maintain box shape while user inputs letters of their own.
     * Returns a Label Object.
     */
    public Label createLabel()
    {
        return new Label
        {
            Text = "X",
            TextColor = Colors.Black,
            FontSize = 39,
            FontAttributes = FontAttributes.Bold,
            HorizontalTextAlignment = TextAlignment.Center


        };
    }
    /**
     * Creates a border for each created label with the approriate cosmetics and size settings.
     * Receives a label Object. 
     * Returns a Border Object with a label inside.
     */
    public Border createBorder(Label label)
    {
        return new Border
        {
            Content = label,
            BackgroundColor = Colors.Black,
            Stroke = Color.FromArgb("#787c7f"),
            StrokeThickness = 2,
            Padding = new Thickness(30, 15),
            HorizontalOptions = LayoutOptions.Center,

        };
    }
    /**
     * Creates the keyboard grid.
     * Receives the row number of the keyboard. 
     * Returns the grid of buttons for the assigned row
     */
    public Grid createKeyboardGrid(int rowNumber)
    {
        //Keyboard design 
        Grid grid = new Grid
        {
            ColumnSpacing = 10,
            RowSpacing = 10,
            Margin = new Thickness(3),
            Padding = new Thickness(35, 0, 35, 0),
            HorizontalOptions = LayoutOptions.Center,
            RowDefinitions =
            {
                new RowDefinition()

            },
            ColumnDefinitions =
            {
                new ColumnDefinition(),
                new ColumnDefinition(),
                new ColumnDefinition(),
                new ColumnDefinition(),
                new ColumnDefinition(),
                new ColumnDefinition(),
                new ColumnDefinition(),
                new ColumnDefinition(),
                new ColumnDefinition(),
                new ColumnDefinition(),
            }
        };

        //List of List to create the row of letters of the keyboard.
        List<List<string>> myList = new List<List<string>>();
        myList.Add(new List<string> { "Q", "W", "E", "R", "T", "Y", "U", "I", "O", "P" });
        myList.Add(new List<string> { "A", "S", "D", "F", "G", "H", "J", "K", "L" });
        myList.Add(new List<string> { "Enter", "Z", "X", "C", "V", "B", "N", "M", "Delete" });

        int col = 0;
        foreach (string item in myList[rowNumber])
            grid.Add(createButton(item), col++, rowNumber);



        return grid;
    }
    /**
     * Creates a keyboard button. 
     * Receives the keyboard letter
     * Returns the button with the designated cosmetics and settings
     */
    public Button createButton(string letter)
    {
        if (letter.CompareTo("Enter") == 0 || letter.CompareTo("Delete") == 0)
            return new Button
            {
                Text = letter,
                WidthRequest = 70,
                FontSize = 13,
                FontAttributes = FontAttributes.Bold,
                TextColor = Colors.White,
                BackgroundColor = Color.FromArgb("#787c7f")
            };
        else
            return new Button
            {
                Text = letter,
                FontSize =20,
                WidthRequest = 50,
                HeightRequest= 50,
                TextColor = Colors.White,
                FontAttributes = FontAttributes.Bold,
               BackgroundColor = Color.FromArgb("#787c7f")
            };
    }
}