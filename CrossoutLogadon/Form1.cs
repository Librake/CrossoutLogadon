using System.Diagnostics;

namespace CrossoutLogadon;

public partial class Form1 : Form
{
    LogStorage logStorage;
    public Form1()
    {
        logStorage = new LogStorage();
        InitializeComponent();
        this.FormBorderStyle = FormBorderStyle.FixedDialog;
    }
}
