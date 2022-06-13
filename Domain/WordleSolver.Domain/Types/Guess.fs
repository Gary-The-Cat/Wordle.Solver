namespace WordleSolver.Domain.Types

type guess private (guessLetters) =
    member this.GuessLetters = guessLetters

    // Uber Explicit
    static member Create(guessLetters:list<guessLetter>)  : Result<guess, string> =
        if guessLetters.Length <> 5 then
            Error "A guess must contain at least 5 guess letters."
        else
            Ok (guess guessLetters)