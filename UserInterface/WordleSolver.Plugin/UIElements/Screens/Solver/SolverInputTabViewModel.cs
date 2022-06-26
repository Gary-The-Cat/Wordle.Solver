namespace WordleSolver.Plugin.UIElements.Screens.Solver;

using Impulse.SharedFramework.Services.Layout;
using Microsoft.FSharp.Collections;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using WordleSolver.Domain.Types;
using WordleSolver.Plugin.UIElements.Controls.GuessLetter;

public partial class SolverInputTabViewModel : DocumentBase
{
    public SolverInputTabViewModel()
    {
        MakeGuessCommand = ReactiveCommand.Create(MakeGuess);

        Guesses = new List<guess>();
    }

    public GuessLetterViewModel GuessLetterOne { get; set; } = new GuessLetterViewModel();
    
    public GuessLetterViewModel GuessLetterTwo { get; set; } = new GuessLetterViewModel();

    public GuessLetterViewModel GuessLetterThree { get; set; } = new GuessLetterViewModel();

    public GuessLetterViewModel GuessLetterFour { get; set; } = new GuessLetterViewModel();

    public GuessLetterViewModel GuessLetterFive { get; set; } = new GuessLetterViewModel();

    public List<guess> Guesses { get; set; }

    public string CurrentSuggestedWord { get; set; } = "STRAP";

    public override string DisplayName => "Wordle Solver";

    public ICommand MakeGuessCommand { get; set; }

    public void MakeGuess()
    {
        // Get letters
        var letterOneResult = letter.Create(GuessLetterOne.FeedbackCharacter.First());
        var letterTwoResult = letter.Create(GuessLetterTwo.FeedbackCharacter.First());
        var letterThreeResult = letter.Create(GuessLetterThree.FeedbackCharacter.First());
        var letterFourResult = letter.Create(GuessLetterFour.FeedbackCharacter.First());
        var letterFiveResult = letter.Create(GuessLetterFive.FeedbackCharacter.First());

        // Get feedback
        var letterOneFeedback = GuessLetterOne.GetFeedback();
        var letterTwoFeedback = GuessLetterTwo.GetFeedback();
        var letterThreeFeedback = GuessLetterThree.GetFeedback();
        var letterFourFeedback = GuessLetterFour.GetFeedback();
        var letterFiveFeedback = GuessLetterFive.GetFeedback();

        var word = wordleWord.Create(String.Concat(
            letterOneResult.ResultValue.Char,
            letterTwoResult.ResultValue.Char,
            letterThreeResult.ResultValue.Char,
            letterFourResult.ResultValue.Char,
            letterFiveResult.ResultValue.Char));


        var guessLetters = new List<Tuple<letter, Feedback, LetterPosition>>()
        {
            new Tuple<letter, Feedback, LetterPosition>(letterOneResult.ResultValue, letterOneFeedback, LetterPosition.First),
            new Tuple<letter, Feedback, LetterPosition>(letterOneResult.ResultValue, letterOneFeedback, LetterPosition.Second),
            new Tuple<letter, Feedback, LetterPosition>(letterOneResult.ResultValue, letterOneFeedback, LetterPosition.Third),
            new Tuple<letter, Feedback, LetterPosition>(letterOneResult.ResultValue, letterOneFeedback, LetterPosition.Fourth),
            new Tuple<letter, Feedback, LetterPosition>(letterOneResult.ResultValue, letterOneFeedback, LetterPosition.Fifth),
        };


        var fSharpWordleWords = ListModule.OfSeq(guessLetters);
        var guess = Domain.Types.guess.Create(fSharpWordleWords).ResultValue;


        var wordleWords = ListModule.OfSeq(Wordle.Words.Select(w => wordleWord.Create(w).ResultValue));
        var guesses = ListModule.OfSeq(new List<guess>() { guess });

        Guesses.Add(guess);

        var words = WordleSolver.Solver.GetValidWordsFromGuesses(wordleWords, guesses);
    }
}
