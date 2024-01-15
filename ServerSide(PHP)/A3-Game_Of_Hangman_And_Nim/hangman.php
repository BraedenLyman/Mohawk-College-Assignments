<?php
/**
 * I Braeden Lyman, 000370695, certify that this material is my original work. 
 * No other person's work has been used without suitable acknowledgment and I have not 
 * made my work available to anyone else.
 * 
 * The purpose of this file is to recieve GET parameters from the client side, filter the
 * inputs and then display certain outcomes for a game called Hangman. The purpose of the
 * game is to guess a secret word by choosing letters of the alphabet. In this version of
 * the game, the user gets a total of 7 incorrect guesses. If the user uses more than 7 
 * incorrect guesses, they loose the game. The amount of incorrect guesses is displayed 
 * on the page when an incorrect guess is made. If the user guesses right, the word that 
 * is hidden with dashes ("-") that indicate how many letters are in the word, is then 
 * populated with that letter in the correct spot(s). If the user guesses the word with less
 * than 7 guesses they win the game. If the user wished to reset the game, they can by simply
 * clicking the reset button and it will display another hidden word to guess.
 * 
 * @author Braeden Lyman
 * @version 2023.11.01
 * @package Comp 10260 Assignment 2
 */
session_start();    // starts the session

$mode = filter_input(INPUT_GET, 'mode', FILTER_DEFAULT);    // filter validate the mode input
$letter = '';                                               // empty string 

/**
 * resetGame function is to reset the game and to display another hidden word
 * that is shown to the user using "-" replaced for the letters if the user 
 * clicks the reset button. It also resets the amount of incorrect guesses.
 * 
 * @return - PHP associative array of sessions that will be converted to a JSON string
 *           displaying the current game status and the hidden word
 */
function resetGame() {
    $file = 'wordlist.txt';                                   // file that contains the wordbank of words 
    $wordlist = file_get_contents($file);                     // gets contents of the file
    $wordArray = array_map('trim', explode("\n", $wordlist)); // explodes $wordlist into an array and cleans up all white space before and after each word
    $word = strtoupper($wordArray[array_rand($wordArray)]);   // gets a random word from the wordlist array ($wordlist) and converts it to upper case
    $wordLength = strlen($word);

    $_SESSION['status'] = "new game started";               // status label set to new game started
    $_SESSION['secret'] = $word;                            // secret word takes the random word and hides it using "-"
    $_SESSION['strikes'] = 0;                               // incorrect guesses is initalized to 0 to start
    $_SESSION['guesses'] = [];                              // guessed letters the user has made stored into an array
    $_SESSION['hiddenWord'] = str_repeat('-', $wordLength - 1);   // hides the random word using "-"

    //PHP associative array of the status and the hidden word
    return [
        'status' => $_SESSION['status'], 
        'secret' => $_SESSION['hiddenWord']
    ];
}

/**
 * makeGuess function is where the user makes a guess of which letter they 
 * think is in the hidden word. If they guess correctly, the letter will display
 * in the word in the corrisponding location(s). If the user guesses all letters 
 * in the word, they win the game. If the user uses more than 7 incorrect guesses
 * they then loose the game.
 * 
 * @return - PHP associative array of sessions that will be converted to a JSON string
 *           displaying the current in-game stats such as winner or looser status label,
 *           guessed letters in an array, hidden word, amount of incorrect guesses, and 
 *           the letters still available to be guessed.
 */
function makeGuess() {
    $letter = filter_input(INPUT_GET, 'letter', FILTER_DEFAULT);            // filter validate letter input
    $_SESSION['status'] = "you are playing a game now";                     // current status label

    // if statment checks if a guessed letter is already in the letter guessed array
    if (!in_array(strtoupper($letter), $_SESSION['guesses'])) { 
        $_SESSION['guesses'][] = strtoupper($letter);                       // adds the letter to the array if not already in the letter guessed array
    
        // if statment checks which position each letter is at in the secret array
        if (strpos($_SESSION['secret'], strtoupper($letter)) !== false) {
            $wordArray = str_split($_SESSION['secret']);                    // converts secret string to an array, stored as $wordArray

            // foreach loop checks 
            foreach ($wordArray as $key => $char) {
                if ($char === strtoupper($letter)) {
                    $_SESSION['hiddenWord'][$key] = strtoupper($letter);
                }
            }
        } else {
            $_SESSION['strikes']++;                                         // amount of incorrect guesses the user has

            // if statment checks if the amount of incorrect guesses is above 7, user looses the game.
            if ($_SESSION['strikes'] >= 7) {
                $_SESSION['status'] = "you have lost the game";             // new status label
                $_SESSION['hiddenWord'] = $_SESSION['secret'];              // displays the hidden word once user looses
                session_destroy();                                          // ends the session               
            }        
        }

        // if statment checks if user won the game by guessing the secret word
        if ($_SESSION['hiddenWord'] === $_SESSION['secret'] && $_SESSION['strikes'] < 7) {
            $_SESSION['status'] = "congratulations! You won!";              // new status label
            session_destroy();                                              // ends the session
        }
    }
    
    // PHP associative array of current in-game stats such as the status of the game, letters already guessed, amount of strikes, and correct guesses
    $results = [
        'status' => $_SESSION['status'],
        'alphabet' => implode(' | ', array_diff(range('A', 'Z'), $_SESSION['guesses'])), // letters guessed are converted to uppercase and spaced out using "|"
        'secret' => $_SESSION['hiddenWord'],
        'strikes' => $_SESSION['strikes'],
        'guesses' => $_SESSION['guesses']
    ];
    return $results;
}

// if statment checks if user clicks the reset button
if ( $mode === 'reset'){
    echo json_encode(resetGame()); // calls resetGame function
} elseif (isset($letter)) {
    $results = makeGuess();         // stores makeGuess function as $results
    echo json_encode($results);     // calls $results 
}
?>
