using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Windows.Media;
using WordleSolver.Domain.Types;

namespace WordleSolver.Plugin.UIElements.Controls.GuessLetter;

[INotifyPropertyChanged]
public partial class GuessLetterViewModel
{
    public Action? OnCharacterChanged { get; set; }
    
    public FeedbackSelectionViewModel FeedbackSelectionViewModel { get; set; }
        = new FeedbackSelectionViewModel();

    public string FeedbackCharacter { get; set; } = string.Empty;

    public Feedback GetFeedback()
    {
        switch (FeedbackSelectionViewModel.Feedback)
        {
            case Enums.Feedback.RightLetterWrongPlace:
                return Feedback.RightLetterWrongPlace;
            case Enums.Feedback.RightLetterRightPlace:
                return Feedback.RightLetterRightPlace;
            case Enums.Feedback.WrongLetter:
                return Feedback.WrongLetter;
            default:
                throw new ArgumentException("Oh shit.");
        }
    }

}
