namespace WordleSolver.Tests

open FsCheck
open System

type Letter =
    static member Char() =
        Arb.generate<char>
        |> Gen.filter (fun x -> Char.IsLetter x)