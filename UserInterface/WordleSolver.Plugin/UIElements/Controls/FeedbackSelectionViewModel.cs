namespace WordleSolver.Plugin.UIElements.Controls;

using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.Generic;
using System.Windows.Media;
using WordleSolver.Plugin.Enums;

[INotifyPropertyChanged]
public partial class FeedbackSelectionViewModel
{
    private List<SolidColorBrush> colours;
    
    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(SelectedColour))]
    private bool isWrongLetterChecked;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(SelectedColour))]
    private bool isRightLetterWrongPlaceChecked;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(SelectedColour))]
    private bool isRightLetterRightPlaceChecked;

    internal FeedbackSelectionViewModel()
    {
        colours = new List<SolidColorBrush>()
        {
            new SolidColorBrush(Color.FromRgb(0x75, 0xB3, 0x6E)),
            new SolidColorBrush(Color.FromRgb(0xCF, 0xBD, 0x61)),
            new SolidColorBrush(Color.FromRgb(0x83, 0x87, 0x89)),
        };

        this.IsRightLetterRightPlaceChecked = true;
    }

    public Feedback Feedback => this.isWrongLetterChecked ? Feedback.WrongLetter
            : this.isRightLetterWrongPlaceChecked ? Feedback.RightLetterWrongPlace
                : Feedback.RightLetterRightPlace;
    
    public SolidColorBrush SelectedColour => colours[(int)Feedback];
}
