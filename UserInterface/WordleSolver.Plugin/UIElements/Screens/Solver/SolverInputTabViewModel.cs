namespace WordleSolver.Plugin.UIElements.Screens.Solver;

using Impulse.SharedFramework.Services.Layout;
using ReactiveUI;
using System.Windows.Input;
using WordleSolver.Plugin.UIElements.Controls.GuessLetter;

public partial class SolverInputTabViewModel : DocumentBase
{
    public SolverInputTabViewModel()
    {
        MakeGuessCommand = ReactiveCommand.Create(MakeGuess);
    }

    public GuessLetterViewModel GuessLetterOne { get; set; } = new GuessLetterViewModel();
    
    public GuessLetterViewModel GuessLetterTwo { get; set; } = new GuessLetterViewModel();

    public GuessLetterViewModel GuessLetterThree { get; set; } = new GuessLetterViewModel();

    public GuessLetterViewModel GuessLetterFour { get; set; } = new GuessLetterViewModel();

    public GuessLetterViewModel GuessLetterFive { get; set; } = new GuessLetterViewModel();

    public string CurrentSuggestedWord { get; set; } = "STRAP";

    public override string DisplayName => "Wordle Solver";

    public ICommand MakeGuessCommand { get; set; }

    public void MakeGuess()
    {
    }
}
