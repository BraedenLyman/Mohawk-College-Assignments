<?php
/**
 * I Braeden Lyman, 000370695, certify that this material is my original work. 
 * No other person's work has been used without suitable acknowledgment and I have not 
 * made my work available to anyone else.
 * 
 * The purpose of this file is to recieve GET parameters from the client side, filter the
 * inputs and then display certain outcomes for a simple version of the game called NIM.
 * The game has two players, a computer and the user. The purpose of the game is to not be 
 * the last one to take the stone. The user (player) chooses to take 1, 2, or 3 stones from 
 * the hypothetical pile. The computer then takes an amount between 1, 2, or 3 based on which 
 * difficulty the user chooses. The game is played by going back and forth, until there are no 
 * stones left.
 * 
 * @author Braeden Lyman
 * @version 2023.11.01
 * @package Comp 10260 Assignment 2
 */

session_start(); // start the session
$mode = filter_input(INPUT_GET, 'mode', FILTER_VALIDATE_INT); // filter validate for mode input

/**
 * resetGame function is for reseting the game to the default presets by clicking the 
 * reset game button
 * @return - PHP associative array of sessions that will be converted to a JSON string
 *           displaying the rested stats such as, game is started, 20 stones at start of
 *           game, player as the first move, and how many stones are remaining.
 */
function resetGame() {
    $_SESSION['stones'] = 20;                       //stones session set to 20 int
    $_SESSION['player'] = 'player';                 //player session set to player string
    $_SESSION['winner'] = 'Game is started';        //winner session set to Game is started string

    //PHP associative array of sessions 
    return [
        'move' => 0,
        'stones' => $_SESSION['stones'],
        'player' => $_SESSION['player'],
        'winner' => $_SESSION['winner']
    ];
}

/**
 * playerMove function is used to determine the current in game stats for the player. Once the user 
 * clicks the play next move button, if it's the players turn, which ever number of stones
 * the user would like to take (indicated by the radio button 1, 2, or 3) the game will update
 * the stats to indicate the amount taken, how many stones are left, if it's the players 
 * turn and if the player has won.
 * 
 * @return - PHP associative array of sessions that will be converted to a JSON string
 *           displaying the current game stats for the player such as game is started, 
 *           how many stones at the start of the turn, if its the player turn, and how 
 *           many stones are remaining.
 */
function playerMove() {
    $playerMove = filter_input(INPUT_GET, 'player_move', FILTER_VALIDATE_INT); // filter validate for player_move input
    
    // If its not the players turn, its the computers turn
    if ($_SESSION['player'] != 'player') {
        return computerMove();
    }

    // calls error method if playerMove is out of range
    if ($playerMove < 1 || $playerMove > 3) {
        return error();
    }

    $move = $playerMove;                    // gets the current move
    $_SESSION['stones'] -= $move;           // remaining stones after move
    $count = max(0, $_SESSION['stones']);   // gets the inital count of stones in the game

    // if statment to see if computer is a winner
    if ($count <= 0) {
        $_SESSION['winner'] = 'Computer';   // establishes computer as winner
        session_destroy();                  // ends the game
    }
    
    $_SESSION['player'] = 'computer';       // Switch to the computer's turn

    // PHP associative array of current in-game stats of the players turn
    return [
        'move' => $move,
        'stones' => $count,
        'player' => 'player',
        'winner' => $_SESSION['winner']
    ];
}

/**
 * computerMove function is used to determine the current in game stats for the computer. Once the user 
 * clicks the play next move button, if it's the computers turn and if the user choses difficulty to be 
 * easy, the computers turn will generate a random number of stones to take (between 1, 2, or 3). If the 
 * diffuclty is set to optimal, and it's the computers turn, the number of stones the computer takes is 
 * generated by taking the remaining stones, modular 4 to give the amount of stones taken by the comoputer 
 * (will result in 1, 2, or 3).
 * 
 * @return - PHP associative array of sessions that will be converted to a JSON string
 *           displaying the current game stats for the computer such as game is started, 
 *           how many stones at the start of the turn, if its the computers turn, and how 
 *           many stones are remaining.
 */
function computerMove() {
    $difficulty = filter_input(INPUT_GET, 'difficulty', FILTER_VALIDATE_INT); // filter validate for difficulty input
    
    // If its not the computers turn, its the players turn
    if ($_SESSION['player'] != 'computer') {
        return playerMove();
    }

    $stones = $_SESSION['stones'];  // stores stone session as a variable stones

    // gets the difficulty level selected
    if ($difficulty == 0){
        $move = rand(1, 3);                 // generates random number 1, 2, or 3
    } elseif ($difficulty == 1) {
        $remiander = $stones % 4;           // remaining stones modular 4 to get computers move of 1, 2, or 3

        // switch statment to get computer move if optimal difficulty is selected
        switch ($remiander) {
            
            // if remainder is 3
            case 3:
                $move = 2;              // sets move to 2
                break;
            // if remainder is 2
            case 2:
                $move = 1;              // sets move to 1
                break;
            // if remainder is 1
            case 1: 
                $move = rand(1, 3);     // sets move to random number between 1, 2, or 3
                break;
            // if remainder is 0
            case 0:
                $move = 3;              // sets move to 3
                break;
        }
    }

    $_SESSION['stones'] -= $move;           // remaing stones after move
    $count = max(0, $_SESSION['stones']);   // gets the inital count of stones in the game

    // if statment to see if player is a winner
    if ($count <= 0) {
        $_SESSION['winner'] = 'player';     // establishes computer as winner
        session_destroy();                  // ends the game
    }
  
    $_SESSION['player'] = 'player';         // Switch to the player's turn 

    // PHP associative array of current in-game stats of the computers turn
    return [
        'move' => $move,
        'stones' => $count,
        'player' => 'computer',
        'winner' => $_SESSION['winner']
    ];
}

/**
 * error function is used to display error on each stat to indicate there
 * is an error.
 * 
 * @return - PHP associative array of sessions that will be converted to a JSON string
 *           displaying error.
 */
function error() {
    // PHP associative array of error stats if an error has occured
    return [
        'move' => 'error',
        'stones' => 'error',
        'player' => 'error',
        'winner' => 'error'
    ];
}

// if statment to check mode selected
if ($mode == 0) {
    echo json_encode(resetGame());      // resets the game stats
} elseif ($mode == 1) {
    echo json_encode(playerMove());     // plays the game starting with the player
} else {
   echo json_encode(error());           // calls error method if error is found
}
?>