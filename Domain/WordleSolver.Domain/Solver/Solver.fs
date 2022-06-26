module WordleSolver.Solver
    open WordleSolver.Domain.Types

    // Real logic goes here
    let private getCharAt (word:wordleWord, position:LetterPosition) : char =
        match position with
        | LetterPosition.First -> word.Word.[0]
        | LetterPosition.Second -> word.Word.[1]
        | LetterPosition.Third -> word.Word.[2]
        | LetterPosition.Fourth -> word.Word.[3]
        | LetterPosition.Fifth -> word.Word.[4]

    let private matchRightLetterWrongPlace (word:wordleWord, character:char, wordleChar:char) : bool =
        not (wordleChar.Equals character) && (word.Word.Contains character)

    let private checkLetter (guessLetter:guessLetter, word:wordleWord) : bool =
        let (letter, feedback, letterPosition) = guessLetter
        let wordChar = getCharAt (word, letterPosition)
        match feedback with
        | Feedback.RightLetterRightPlace -> wordChar.Equals letter.Char
        | Feedback.RightLetterWrongPlace -> matchRightLetterWrongPlace (word, letter.Char, wordChar)
        | Feedback.WrongLetter -> not (word.Word.Contains letter.Char)

    let private checkWord (guess:guess, word:wordleWord) : bool =
        guess.GuessLetters |> List.fold
                        (fun isValid guessLetter -> isValid && checkLetter (guessLetter, word))
                        true
                        
    let private getValidWordsFromGuess (words:wordleWord list, guess:guess) : wordleWord list =
        words |> List.filter (fun word -> checkWord (guess, word))

    let public GetValidWordsFromGuesses (words:wordleWord list, guesses:guess list) : wordleWord list =
        guesses |> List.map (fun guess -> getValidWordsFromGuess (words, guess))
                |> Seq.map Set.ofList
                |> Seq.reduce Set.intersect
                |> Set.toList


                