namespace DimaGame;

partial class GameField
{
    private System.ComponentModel.IContainer components = null;
    
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }

        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code
   
    private void InitializeComponent(int windowsHeight, int windowWidth)
    {
        this.components = new System.ComponentModel.Container();
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.Text = "Пятнашки";
        this.ClientSize = new System.Drawing.Size(windowWidth, windowsHeight);
        this.StartPosition = FormStartPosition.CenterScreen;
        this.FormBorderStyle = FormBorderStyle.FixedSingle;
        this.BackgroundImage = Image.FromFile(@"fon2.jpg");
    }

    #endregion
}