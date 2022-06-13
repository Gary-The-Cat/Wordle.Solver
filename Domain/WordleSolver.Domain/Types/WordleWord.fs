namespace WordleSolver.Domain.Types

open System

type wordleWord private(word:string) =

    interface IComparable with
        member this.CompareTo(obj: obj): int =
            match obj with
            | :? wordleWord as word -> word.Word.CompareTo(this.Word)
            | _ -> -1

    member this.Word = word

    static member Create(word:string) : Result<wordleWord, string> =
        if word.Length = 5 then
            Ok (new wordleWord(word))
        else
            Error $"The word '{word}' does not contain 5 characters."
