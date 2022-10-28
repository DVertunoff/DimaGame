using System.ComponentModel;

namespace DimaGame;

partial class WinForm
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }

        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent(int height, int width)
    {
        this.components = new System.ComponentModel.Container();
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(width, height);
        this.Text = "Вы победили!";
        this.FormBorderStyle = FormBorderStyle.FixedSingle;
        this.StartPosition = FormStartPosition.CenterScreen;
        this.BackgroundImage = Image.FromFile(@"fon1.jpg");
    }

    #endregion
}