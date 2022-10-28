using System.Windows.Forms;

namespace DimaGame;

public partial class WinForm : Form
{
    private readonly int _height = 320;
    private readonly int _width = 320;
    private readonly (int, int) _sizeLabel = (150, 50);

    public WinForm()
    {
        InitializeComponent(_height, _width);
        Init();
    }

    private void Init()
    {
        var label = new Label();
        var buttonReset = new Button();
        var buttonExit = new Button();
        var colorWhite = Color.White;
        var colorBlack = Color.Black;

        label.Text = "You win!";
        label.Location = new Point(_width / 2 - _sizeLabel.Item1 / 2, _height / 2 - _sizeLabel.Item2 / 2);
        label.BackColor = colorBlack;
        label.ForeColor = colorWhite;
        label.Size = new Size(_sizeLabel.Item1, _sizeLabel.Item2);
        label.Font = new Font("Text", 25);

        buttonReset.Location = new Point(15, 15);
        buttonReset.Click += ResetClick;
        buttonReset.Text = "Reset";
        buttonReset.Size = new Size(100, 30);
        buttonReset.Location = new Point(_width / 2 - 100 / 2, _height / 2 + _sizeLabel.Item2 / 2 + 25 / 2);
        buttonReset.BackColor = colorBlack;
        buttonReset.ForeColor = colorWhite;

        buttonExit.Location = new Point(15, 45);
        buttonExit.Click += ExitClick;
        buttonExit.Text = "Exit";
        buttonExit.Size = new Size(100, 30);
        buttonExit.Location = new Point(_width / 2 - 100 / 2, _height / 2 + _sizeLabel.Item2 / 2 + 100 / 2);
        buttonExit.BackColor = colorBlack;
        buttonExit.ForeColor = colorWhite;

        Controls.Add(label);
        Controls.Add(buttonReset);
        Controls.Add(buttonExit);
    }

    private void ResetClick(object sender, EventArgs e)
    {
        Close();
    }

    private void ExitClick(object sender, EventArgs e)
    {
        Application.Exit();
    }
}