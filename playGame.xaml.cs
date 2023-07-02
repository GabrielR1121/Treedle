namespace Treedle;

public partial class playGame : ContentPage
{
	public playGame()
	{
		InitializeComponent();
		//createGrid();
        //createKeyboard();


	}
    /**
     * Creates the grid system in treedle. 
     * Creates all 6 rows and 5 Columns 
     */
	public void createGrid()
	{
        //Creates the verticle layout that holds the items in the page
        VerticalStackLayout verticalStackLayout = new VerticalStackLayout{};

        //Creates the grid with the appropriate cosmetics and settings
        Grid grid = new Grid
        {
            BackgroundColor = Colors.White,
            Margin = new Thickness(3),
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
        for( int row = 0; row < 5; row++ )
            for( int col = 0; col < 6; col++ ) 
                grid.Add(createBorder(createLabel()),row,col);

        //Adds the grid to the Vertical Layout
        verticalStackLayout.Add(grid);

        // Adds content to page
        Content = verticalStackLayout;
        
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
            TextColor = Colors.White,
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
            StrokeThickness = 3,
            Padding = new Thickness(20,5),
            HorizontalOptions = LayoutOptions.Center,
            
        };
    }

    public void createKeyboard()
    {
        VerticalStackLayout verticalStackLayout = new VerticalStackLayout{ };

        Grid grid = new Grid
        {
            BackgroundColor = Colors.DarkGray,
            RowDefinitions =
            {
                new RowDefinition(),
                new RowDefinition(),
                new RowDefinition()
               
            },
            ColumnDefinitions =
            {
                //10,9,10
                new ColumnDefinition(),
                new ColumnDefinition(),
                new ColumnDefinition()
            }
        };
    }

    public Button createButton()
    {
        return new Button
        {

        };
    }
}