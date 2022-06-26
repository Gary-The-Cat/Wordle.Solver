open WordleSolver.Domain.Types
open WordleSolver.Solver;
open Xunit
open System
open FsCheck
open FsCheck.Xunit
open WordleSolver.Tests


type LetterTwo =
    static member letter() = 
        Arb.generate<char>
        |> Gen.map letter

[<Arbitrary([| typeof<LetterTwo> |])>]
module Tests  =

    [<Property>]
    let ``Create ShouldAlwaysReturnValidInstance WhenProvidedWithLetter`` (myLetter: letter) =
        printfn ""

////[<Fact>]
////let ``My not-failing test`` () =
////    let myLetter = letter.Create '/'
////    Assert.False(myLetter.IsSome)
    
////[<Fact>]
////let ``My second passing test`` () =
////    let letterOption = letter.Create 'g'

////    let guessLetter = match letterOption with
////        | Some x -> Some(guessLetter(x, Feedback.RightLetterRightPlace, LetterPosition.First))
////        | None -> None
    
////    Assert.True(guessLetter.IsSome)
    
////[<Fact>]
////let ``My third passing test`` () =
////    let letterOptionA = letter.Create 'g'
////    let letterOptionB = letter.Create 'r'
////    let letterOptionC = letter.Create 'e'
////    let letterOptionD = letter.Create 'a'
////    let letterOptionE = letter.Create 't'

////    let guessLetters = match (letterOptionA, letterOptionB, letterOptionC, letterOptionD, letterOptionE) with
////        | Some a, Some b, Some c, Some d, Some e -> [
////            guessLetter(a, Feedback.RightLetterRightPlace, LetterPosition.First)
////            guessLetter(b, Feedback.RightLetterRightPlace, LetterPosition.Second)
////            guessLetter(c, Feedback.RightLetterRightPlace, LetterPosition.Third)
////            guessLetter(d, Feedback.RightLetterRightPlace, LetterPosition.Fourth)
////            guessLetter(e, Feedback.RightLetterRightPlace, LetterPosition.Fifth) ]
////        | _ -> []
    
////    let guess = guess.Create guessLetters

////    Assert.False(guessLetters.IsEmpty)
    
////[<Fact>]
////let ``Guess refined list`` () =
////    let letterOptionA = letter.Create 'g'
////    let letterOptionB = letter.Create 'r'
////    let letterOptionC = letter.Create 'e'
////    let letterOptionD = letter.Create 'a'
////    let letterOptionE = letter.Create 't'

////    let guessLetters = match (letterOptionA, letterOptionB, letterOptionC, letterOptionD, letterOptionE) with
////        | Some a, Some b, Some c, Some d, Some e -> [
////                                                    guessLetter(a, Feedback.RightLetterRightPlace, LetterPosition.First)
////                                                    guessLetter(b, Feedback.RightLetterRightPlace, LetterPosition.Second)
////                                                    guessLetter(c, Feedback.RightLetterRightPlace, LetterPosition.Third)
////                                                    guessLetter(d, Feedback.RightLetterRightPlace, LetterPosition.Fourth)
////                                                    guessLetter(e, Feedback.RightLetterRightPlace, LetterPosition.Fifth) ]
////        | _ -> []
    
////    let guesses = [(guess.Create guessLetters).Value]

////    let correctWordleWord = wordleWord.Create("great").Value
////    let incorrectWordleWord = wordleWord.Create("sloppy").Value
    
////    let wordleWords = [correctWordleWord; incorrectWordleWord]
////    let refinedList = getValidWordsFromGuesses (wordleWords, guesses)
    
////    Assert.False(guessLetters.IsEmpty)