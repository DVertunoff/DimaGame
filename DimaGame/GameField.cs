namespace DimaGame;

/// <summary>
/// Класс GameField
/// Отвечает за создание и визуальную составляющую игрового поля
/// </summary>
public partial class GameField : Form
{
/// <param name="_fieldSize"> Размер поля </param>
/// <param name="_buttonSize"> Размер кнопки  </param>
/// <param name="_windowHeight"> Высота окна </param>
/// <param name="_windowWidth"> Ширина окна </param>
/// <param name="_logicGame"> Переменная объекта класса отвечающая за логику игры </param>
/// <param name="_masOfButtons"> Двумерный массив кнопок </param>
    private readonly int _fieldSize = 3;
    private readonly int _buttonSize = 50;
    private readonly int _windowHeight = 400;
    private readonly int _windowWidth = 400;
    private readonly LogicGame _logicGame;
    private readonly Button[,] _masOfButtons;

/// <summary>
/// Конструктор класса GameField
/// </summary>
    public GameField(int size)
    {
        _fieldSize = size;
        _logicGame = new LogicGame(_fieldSize);
        InitializeComponent(_windowHeight, _windowWidth);
        _logicGame.StartLogic();
        _masOfButtons = new Button[_fieldSize, _fieldSize];
        Init();
    }

/// <summary>
/// Настройка и отображение игрового поля, состоящего из кнопок
/// </summary>
    private void Init()
    {
/// <param name="xposFirstButton"> Позиция самой первой кнопки по оси x, от которой идет отcчет позиции других кнопок </param>
/// <param name="yposFirstButton"> Позиция самой первой кнопки по оси y, от которой идет отcчет позиции других кнопок </param>
/// <param name="checkButton"> Ну поле короче собирает </param>
        var xposFirstButton = _windowWidth / 2 - _buttonSize * _fieldSize / 2;
        var yposFirstButton = _windowHeight / 2 - _buttonSize * _fieldSize / 2;
        var checkButton = new Button();

        for (int i = 0; i < _fieldSize; i++)
        for (int j = 0; j < _fieldSize; j++)
        {
            var button = new Button();
            button.Location = new Point(xposFirstButton + j * _buttonSize, yposFirstButton + i * _buttonSize);
            button.Height = 50;
            button.Width = 50;
            button.Text = _logicGame.GetCellWithNumber(i, j);
            button.Name = i + " " + j;
            button.Click += ButtonClick;
            Controls.Add(button);
            _masOfButtons[i, j] = button;
            if (button.Text.Equals(" ")) button.Enabled = false;
        }

        checkButton.Text = "collect the field";
        checkButton.Click += CheckButton;
        Controls.Add(checkButton);
        checkButton. BackgroundImage = Image.FromFile(@"fon2.jpg");
        checkButton.ForeColor = Color.White;
        checkButton.Size = new Size(100, 30);
        checkButton.Location = new Point(10, 10);
    }

    private void ButtonClick(object sender, EventArgs e)
    {
        var buttonName = (sender as Button).Name;
        var str = buttonName.Split();
        var coordXOfButton = int.Parse(str[0]);
        var coordYOfButton = int.Parse(str[1]);

        if (_logicGame.GetCellWithNumber(coordXOfButton, int.Parse(str[1]) + 1) == " ")
        {
            var s = _logicGame.GetCellWithNumber(coordXOfButton, coordYOfButton);
            _logicGame.SetCellWithNumber(coordXOfButton, coordYOfButton + 1, s);
            _logicGame.SetCellWithNumber(coordXOfButton, coordYOfButton, " ");
            _masOfButtons[coordXOfButton, coordYOfButton].Enabled = false;
            _masOfButtons[coordXOfButton, coordYOfButton + 1].Enabled = true;
        }

        if (_logicGame.GetCellWithNumber(int.Parse(str[0]), coordYOfButton - 1) == " ")
        {
            var s = _logicGame.GetCellWithNumber(coordXOfButton, coordYOfButton);
            _logicGame.SetCellWithNumber(coordXOfButton, coordYOfButton - 1, s);
            _logicGame.SetCellWithNumber(coordXOfButton, coordYOfButton, " ");
            _masOfButtons[coordXOfButton, coordYOfButton].Enabled = false;
            _masOfButtons[coordXOfButton, coordYOfButton - 1].Enabled = true;
        }

        if (_logicGame.GetCellWithNumber(coordXOfButton + 1, coordYOfButton) == " ")
        {
            var s = _logicGame.GetCellWithNumber(coordXOfButton, coordYOfButton);
            _logicGame.SetCellWithNumber(coordXOfButton + 1, coordYOfButton, s);
            _logicGame.SetCellWithNumber(coordXOfButton, coordYOfButton, " ");
            _masOfButtons[coordXOfButton, coordYOfButton].Enabled = false;
            _masOfButtons[coordXOfButton + 1, coordYOfButton].Enabled = true;
        }

        if (_logicGame.GetCellWithNumber(coordXOfButton - 1, coordYOfButton) == " ")
        {
            var s = _logicGame.GetCellWithNumber(coordXOfButton, coordYOfButton);
            _logicGame.SetCellWithNumber(coordXOfButton - 1, coordYOfButton, s);
            _logicGame.SetCellWithNumber(coordXOfButton, coordYOfButton, " ");
            _masOfButtons[coordXOfButton, coordYOfButton].Enabled = false;
            _masOfButtons[coordXOfButton - 1, coordYOfButton].Enabled = true;
        }

        Repaint();
        
        if (_logicGame.FieldValidation()) WinFinction();
    }

    private void CheckButton(object sender, EventArgs e)
    {
        Check();
        Repaint();
    }

    private void Repaint()
    {
        for (int i = 0; i < _masOfButtons.GetLength(0); i++)
        for (int j = 0; j < _masOfButtons.GetLength(0); j++)
        {
            _masOfButtons[i, j].Text = _logicGame.GetCellWithNumber(i, j);
        }
    }

    private void Check()
    {
        for (int i = 0; i < _masOfButtons.GetLength(0); i++)
        for (int j = 0; j < _masOfButtons.GetLength(0); j++)
        {
            _logicGame.SetCellWithNumber(i,j, _logicGame.GetTrueFieldValue(i,j));
        }
    }

    private void WinFinction()
    {
        WinForm form = new WinForm();
        form.ShowDialog();
        
        Form startField = Application.OpenForms[0];
        startField.Show();
        
        Close();
    }
}
