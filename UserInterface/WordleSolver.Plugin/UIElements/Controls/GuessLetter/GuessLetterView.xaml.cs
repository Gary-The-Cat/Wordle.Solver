using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WordleSolver.Plugin.UIElements.Controls.GuessLetter;
/// <summary>
/// Interaction logic for GuessLetterView.xaml
/// </summary>
public partial class GuessLetterView : UserControl
{
    public GuessLetterView()
    {
        InitializeComponent();
    }

    private GuessLetterViewModel ViewModel => (GuessLetterViewModel)this.DataContext;

    private void TextBox_GotFocus(object sender, RoutedEventArgs e)
    {
        this.ViewModel.FeedbackCharacter = string.Empty;
    }

    private void TextBox_KeyUp(object sender, KeyEventArgs e)
    {
        ViewModel.OnCharacterChanged?.Invoke();
    }
}
