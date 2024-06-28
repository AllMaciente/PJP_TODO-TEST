using Controller;

namespace View;

public class ViewTask : Form
{
    private readonly Label LblTitle;
    // private readonly
    public ViewTask()
    {
        Size = new Size(500, 350);
        MinimumSize = new Size(500, 350);
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Pessoa";
    }
}