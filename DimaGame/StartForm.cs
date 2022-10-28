using System.Windows.Forms;

namespace DimaGame;

/// <summary>
/// Класс StartForm 
/// Создает стартовое окно запуска программы
/// с настройкой и запуском игрового поля 
/// </summary>
public partial class StartForm : Form
{
/// <param name="_windowHeight"> Высота создаваемой формы </param>
/// <param name="_windowWidth"> Ширина создаваемой формы  </param>
/// <param name="_textFromNumericUpDown"> Переменная, отвечающая за размер поля </param>
/// <param name="_form1"> Переменная объекта класса GameField отвечающая за создание поля </param>
/// <param name="_numericUpDown"> Элемент управления, позволяющий выбрать размер поля </param>
    private readonly int _windowHeight = 450;
    private readonly int _windowWidth = 800;
    private int _textFromNumericUpDown;
    private GameField _gameField;
    private readonly NumericUpDown _numericUpDown = new NumericUpDown();
 
/// <summary>
/// Конструктор класса StartForm
/// </summary>
    public StartForm()
    {
        InitializeComponent(_windowWidth, _windowHeight);
        Init();
    }

/// <summary>
/// Функция добавляющая элементы управления формы StartForm
/// </summary>
    private void Init()
    {
/// <param name="button"> Кнопка
/// при нажатии инициализируется переход на форму с игровым полем </param>
/// <param name="label"> Переменная типа label для вывода текста </param>
/// <param name="sizeLabel"> Переменная отвечающая за размер label </param>
        var button = new Button();
        var label = new Label();
        (int, int) sizeLabel = (350, 50);

        label.BackgroundImage = Image.FromFile(@"fon2.jpg");
        label.Text = "GAME PYATNASHKI";
        label.Font = new Font("Text", 25);
        label.Location = new Point(_windowWidth / 2 - sizeLabel.Item1 / 2, 50);
        label.Size = new Size(sizeLabel.Item1, sizeLabel.Item2);
        label.ForeColor = Color.White;

        button.BackgroundImage = Image.FromFile(@"fon2.jpg");
        button.Text = "PLAY";
        button.ForeColor = Color.White;
        button.Click += ClickStartGame;
        button.Size = new Size(100, 50);
        button.Font = new Font("ButtonText", 15);
        button.Location = new Point(_windowWidth / 2 - 100 / 2, _windowHeight / 2 - 50 / 2);

        _numericUpDown.Maximum = 6;
        _numericUpDown.Minimum = 3;
        _numericUpDown.BackColor = Color.Black;
        _numericUpDown.ForeColor = Color.White;
        _numericUpDown.Size = new Size(100, 50);
        _numericUpDown.Location = new Point(_windowWidth / 2 - 100 / 2, _windowHeight / 2 - 120 / 2);

        Controls.Add(label);
        Controls.Add(button);
        Controls.Add(_numericUpDown);
    }

/// <summary>
/// Функция скрывающая форму StartForm и показывающая форму GameField
/// </summary>
    private void ClickStartGame(object sender, EventArgs e)
    {
        _textFromNumericUpDown = int.Parse(_numericUpDown.Text);
        _gameField = new GameField(_textFromNumericUpDown);
        _gameField.Show();
        Hide();
    }
}