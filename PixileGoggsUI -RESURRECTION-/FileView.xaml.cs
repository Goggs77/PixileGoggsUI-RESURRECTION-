using System;
using System.IO;
using System.Windows;
using System.Windows.Input;

namespace PixileGoggsUI__RESURRECTION_;

public partial class FileView : Window, IDisposable
{
    private string _filepath;
    public FileView(string path)
    {
        InitializeComponent();
        FileTextBox.Text = File.ReadAllText(path);
        Title.Text = Path.GetFileName(path);
        _filepath = Path.GetFullPath(path);
    }


    private void ExitWindow(object sender, MouseButtonEventArgs e)
    {
        this.Hide();
        Dispose();
    }

    private void Drag(object sender, MouseButtonEventArgs e)
    {
        DragMove();
    }

    private void SaveToFile(object sender, MouseButtonEventArgs e)
    {
        File.WriteAllText(_filepath,FileTextBox.Text);
        MessageBox.Show($"Saved Changes On {_filepath}","Saved");
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}