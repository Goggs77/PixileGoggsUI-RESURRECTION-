using System.Windows;
using System.Windows.Input;

namespace PixileGoggsUI__RESURRECTION_;

public partial class HelpPage : Window
{
    private int _pageIndex = 1;
    private const uint PageTotal = 10;

    public HelpPage(int startPageIndex = 1)
    {
        InitializeComponent();
        if(!(startPageIndex is >=1 and <= 10)){_pageIndex = startPageIndex;}
        Page.Text = $"Page: {startPageIndex}/10";
        HelpBox.Text = HelpStrings.GetHelpString(_pageIndex);
    }
    private void ExitWindow(object sender, MouseButtonEventArgs e)
    {
        Hide();
    }

    private void Drag(object sender, MouseButtonEventArgs e)
    {
        DragMove();
    }

    private void GoNextPage(object sender, MouseButtonEventArgs e)
    {
        if (_pageIndex == PageTotal)
        {
            _pageIndex = 1;
        }
        else
        {
            _pageIndex++;
        }
        Page.Text = $"Page: {_pageIndex}/10";
        HelpBox.Text = HelpStrings.GetHelpString(_pageIndex);

    }

    private void GoPreviousPage(object sender, MouseButtonEventArgs e)
    {
        if (_pageIndex == 1)
        {
            _pageIndex = (int)PageTotal;
        }
        else
        {
            _pageIndex--;
        }
        Page.Text = $"Page: {_pageIndex}/10";
        HelpBox.Text = HelpStrings.GetHelpString(_pageIndex);
    }
}