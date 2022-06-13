using Impulse.SharedFramework.Plugin;
using Impulse.SharedFramework.Services;
using Microsoft.FSharp.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Versioning;
using System.Threading.Tasks;
using WordleSolver.Domain.Types;
using WordleSolver.Plugin.UIElements.Screens.Solver;

namespace WordleSolver.Plugin;
public class WordleSolverPlugin : IPlugin
{
    private IRibbonService ribbonService;
    private IDocumentService documentService;

    private WordleSolverPlugin(IRibbonService ribbonService, IDocumentService documentService)
    {
        this.ribbonService = ribbonService;
        this.documentService = documentService;
    }

    [RequiresPreviewFeatures]
    public static IPlugin Create(IRibbonService ribbonService, IDocumentService documentService)
    {
        return new WordleSolverPlugin(ribbonService, documentService); 
    }

    public async Task Initialize()
    {
        // Load the ribbon button here.
        this.ribbonService.AddButton(new Impulse.SharedFramework.Ribbon.RibbonButtonViewModel()
        {
            Title = "Wrodle Solver",
            Id = "Developer.Debug.Demos.WordleSolver",
            EnabledIcon = "pack://application:,,,/Impulse.Dashboard;Component/Icons/Export/Bat.png",
            DisabledIcon = "pack://application:,,,/Impulse.Dashboard;Component/Icons/Export/Bat_GS.png",
            IsEnabled = true,
            Callback = OpenSolvleDemo
        });
    }

    private void OpenSolvleDemo()
    {
        var document = new SolverInputTabViewModel();
        this.documentService.OpenDocument(document);
        ////var wordleWords = ListModule.OfSeq(Wordle.Words.Select(w => wordleWord.Create(w).ResultValue));

        ////var guessLetters = new List<Tuple<letter, Feedback, LetterPosition>>();
        ////var letterResult = letter.Create('5');
        
        ////guessLetters.AddRange(new[]
        ////{
        ////    new Tuple<letter, Feedback, LetterPosition>(letter.Create('g').ResultValue, Feedback.RightLetterRightPlace, LetterPosition.First),
        ////    new Tuple<letter, Feedback, LetterPosition>(letter.Create('r').ResultValue, Feedback.RightLetterRightPlace, LetterPosition.Second),
        ////    new Tuple<letter, Feedback, LetterPosition>(letter.Create('e').ResultValue, Feedback.WrongLetter, LetterPosition.Third),
        ////    new Tuple<letter, Feedback, LetterPosition>(letter.Create('a').ResultValue, Feedback.WrongLetter, LetterPosition.Fourth),
        ////    new Tuple<letter, Feedback, LetterPosition>(letter.Create('t').ResultValue, Feedback.WrongLetter, LetterPosition.Fifth)
        ////});
            
        
        ////var fSharpWordleWords = ListModule.OfSeq(guessLetters);
        ////var guess = Domain.Types.guess.Create(fSharpWordleWords).ResultValue;

        ////var guesses = ListModule.OfSeq(new List<guess>() { guess });
        ////var remainingWords = WordleSolver.Solver.GetValidWordsFromGuesses(wordleWords, guesses);
    }

    public async Task OnClose()
    {
    }
}
