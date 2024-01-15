<?php
  /**
   * This document is to see if the serial number entered from the user is a 
   * radar note, ladder note, rotator note or a binary note. If it is one of 
   * the notes, it will display what note it is and add it to a unordered list.
   * If it's not one of the notes, it will return boolean false.
   * 
   * I Braeden Lyman, 000370695, certify that this material is my original work. 
   * No other person's work has been used without suitable acknowledgment and I 
   * have not made my work available to anyone else.
   * 
   * @author Braeden Lyman <000370695>
   * @package COMP 10260 Assignment 1
   * @version 2023.35.00
   */

   $serial_number = $_GET['serial_number'];

/**
 * radar_note function is to see if the serial number is 
 * all the same digit or if the numbers can be read forwards 
 * and backwards.
 * @param String $serial_number - Serial number input from the user
 * @return String - A string that states whether or not the serial number is 
 *                  Solid Serial Number or Palindrome.
 */
function radar_note($serial_number){
    $num_str = strval($serial_number); // Serial number as a string
    $first_digit = $num_str[0]; // First digit index
    $all_same_digits = true; // For if a number is solid
    $reverse_num_str = strrev($serial_number); // Serial number in reverse order

    // Solid serial number for-loop
    for ($i = 1; $i < strlen($num_str); $i++){
        if ($num_str[$i] !== $first_digit){
            $all_same_digits = false;
            break;
        }
    }
    if ($all_same_digits){
        return "Solid Serial Number";
    }

    //Palindrome if-statment
    if ($num_str === $reverse_num_str){
        return "Palindrome";
    }
}

/**
 * laddder_note function is to see if the serial number is
 * in a ladder sequence of: increasing, decreasing, increasing 
 * then decreasing (Inc-Dec) or decreasing then increasing
 * (Dec-Inc).
 * @param String $serial_number - Serial number input from the user
 * @return String - A string that states whether or not the serial 
 *                  number is increasing, decreasing, increasing then
 *                  decreasing or decreasing then increasing.
 */
function ladder_note($serial_number){
    $num_length = strlen($serial_number); // length of the serial number
    $increasing = true; // if digits are in an increasing sequence
    $decreasing = true; // if digits are in a decending sequence
    
    // for-loop to check if the serial number is increasing or decreasing
    for ($i = 1; $i < $num_length; $i++){
        if ($serial_number[$i] != $serial_number[$i - 1] + 1){ 
            $increasing = false;
        }
        if ($serial_number[$i] != $serial_number[$i - 1] - 1){ 
            $decreasing = false;
        }
    }
    if ($increasing){
        return "Ladder Note (Increasing)";
    }
    if ($decreasing){
        return "Ladder Note (Decreasing)";
    }

    //$num_str = strval($serial_number);
    $num_length1 = strlen($serial_number); // length of the serial number
    $middle_digit = intval($num_length1 / 2); // middle digit by dividing the serial number length by 2
    $up_down = true; // if serial number is an increasing/decreasing sequence 
    $down_up = true; // if serial number is a decreasing/increasing sequence

    // for-loop for checking to see if numbers up to the middle digit are increasing/decreasing sequence
    for ($i = 1; $i < $middle_digit; $i++){
        if ($serial_number[$i] != $serial_number[$i - 1] + 1){ 
            $up_down = false;
            break;
        } 
        if ($up_down){
        // for-loop for checking to see if numbers after the middle digit are decreasing/increasing sequence
            for ($i = $middle_digit + 1; $i < $num_length1; $i++){ 
                if ($serial_number[$i] != $serial_number[$i - 1] - 1){  
                    $up_down = false;
                    break;
                } 
            }
        } 
    }   
    if ($up_down){
        return "Ladder Note (Inc-Dec)";
    } 

    // for-loop for checking to see if numbers up to the middle digit are decreasing/increasing sequence
    for ($i = 1; $i < $middle_digit; $i++){
        if ($serial_number[$i] != $serial_number[$i - 1] - 1){
            $down_up = false;
        } 
        if ($down_up){
        // for-loop for checking to see if numbers after the middle digit are increasing/decreasing sequence
            for ($i = $middle_digit + 1; $i < $num_length1; $i++){
                if ($serial_number[$i] != $serial_number[$i - 1] + 1){
                    $down_up = false;
                }
            }
        }
    }
    if ($down_up){
        return "Ladder Note (Dec-Inc)";
    }
}

/**
 * rotator_function is to see if the serial number can 
 * be read upside down and rightside up
 * @param String - $serial_number - Serial number input from the user
 * @return String - A string that states whether or not the serial 
 *                  number can be read upside down or rightside up.
 */
function rotator_note($serial_number) {
    $num_length = strlen($serial_number); // length of the serial number
    $reverse_num_str = strrev($serial_number); // serial number in reverse order
    $rotator = true; // if the number can be read upside down or rightside up
    $output_num = ''; //outputs the serial number if conditions are met

    // for making 6 and 9 interchangeable digits
    $serial_number = str_replace('6', 'x', $serial_number); 
    $serial_number = str_replace('9', '6', $serial_number);
    $serial_number = str_replace('x', '9', $serial_number);

    //for-loop for checking to see if numbers consist of 0, 1, 6, 8 or 9
    for ($i = 0; $i < $num_length; $i++){
        if ($serial_number[$i] != '0' && $serial_number[$i] != '1' && 
            $serial_number[$i] != '6' && $serial_number[$i] != '8' && 
            $serial_number[$i] != '9'){
            $rotator = false;
            break;
        }
      $output_num .= $serial_number;
    }
    // if-statment so all same numbers don't output rotator note
    if ($serial_number === str_repeat('0', $num_length) || 
        $serial_number === str_repeat('1', $num_length) ||
        $serial_number === str_repeat('6', $num_length) ||
        $serial_number === str_repeat('8', $num_length) ||
        $serial_number === str_repeat('9', $num_length)){
        $rotator = false;
    }
    if ($serial_number != $reverse_num_str){
        $rotator = false;        
    }
    if ($rotator){
        return "Rorator Note";
    }
}

/**
 * binary_note function is to to see if the serial number is
 * in a binary sequence of the number 0 or the number 1.
 * @param $serial_number - Serial number input from the user
 * @return String - A string that states whether or not the serial 
 *                  number is a binary number of 0's, 1's or both.
 */
function binary_note($serial_number){
    $num_str = strval($serial_number);
    $num_length = strlen($num_str);
    $binary = true;

    // for-loop for chekcing to see if the serial number includes 0's or 1's
    for ($i = 0; $i < $num_length; $i++){
        if ($num_str[$i] != '1' && $num_str[$i] != '0'){
            $binary = false;
            break;
        }
    }
    if ($binary){
        return "Binary";
    } else{
        return false;
    }
}

/**
 * output_note function is to output the results of the 7-digit
 * serial number.
 * @param $serial_number - Serial number input from the user
 * @return String - A string that prints out what the outcome of the 7-digit number is
 */
function output_note($serial_number){
    $pattern_part = substr($serial_number, 3); // Removes the 3 letters from the serial number

    $results = array(); // results displayed in an array

    // if-statment for if the serial number is a ladder note
    if ($result = ladder_note($pattern_part)){
        $results[] = "<li>$serial_number, $result</li>";
    }

    // if-statment for if the serial number is a radar note
    if ($result = radar_note($pattern_part)){
        $results[] = "<li>$serial_number, $result</li>";
    }

    // if-statment for if the serial number is a binary note
    if ($result = binary_note($pattern_part)){
        $results[] = "<li>$serial_number, $result</li>";
    }

    // if-statment for if the serial number is a rotator note
    if ($result = rotator_note($pattern_part)){
        $results[] = "<li>$serial_number, $result</li>";
    }

    // if-statment for if the serial number is empty
    if (empty($results)) {
        $results[] = "<li>$serial_number, Uninteresting Serial Number</li>";
    }
    return $results;
}

echo implode(output_note($serial_number)); 

?>
