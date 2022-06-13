using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Windows.Media;

namespace WordleSolver.Plugin.UIElements.Controls.GuessLetter;

[INotifyPropertyChanged]
public partial class GuessLetterViewModel
{
    public Action OnCharacterChanged { get; set; }
    
    public FeedbackSelectionViewModel FeedbackSelectionViewModel { get; set; }
        = new FeedbackSelectionViewModel();

    public string FeedbackCharacter { get; set; } = string.Empty;
}
