namespace WordleSolver.Domain.Types

open System

type letter private (char) =
    member this.Char = char

    static member Create char : Result<letter, string> =
        if Char.IsLetter char then
            Ok (new letter(char))
        else
            Error $"The character '{char}' is not a letter."