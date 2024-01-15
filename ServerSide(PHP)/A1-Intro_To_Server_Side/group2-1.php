<?php
  /**
   * This document is to 
   * 
   * I Braeden Lyman, 000370695, certify that this material is my original work. 
   * No other person's work has been used without suitable acknowledgment and I 
   * have not made my work available to anyone else.
   * 
   * @author Braeden Lyman <000370695>
   * @package COMP 10260 Assignment 1
   * @version 2023.35.00
   */

$rows = $_GET['rows'];

/**
 * generate_table function generates 
 * table data that consists of twho columns that 
 * column1 forms a pyramid and column2 adds the
 * numbers up from column1.
 * @param String $row_num -  number input from the user
 * @return String - A string that displays the data in a table
 */
function generate_table($rows){
    $column1 = str_repeat($rows, $rows); // creates a pyramid in the first column
    $column2 = array_sum(str_split($column1)); // calculates the sum of the digits in the first column

    // genertaes HTML for the row
    $rows = "<tr>";
    $rows .= "<td>$column1</td>";
    $rows .= "<td>$column2</td>";
    $rows.= "</tr>";
    return $rows;
}

// generates the table rows
$table_rows = "";
for ($i = 1; $i <= $rows; $i++){
    $table_rows .= generate_table($i);  
}

echo $table_rows; //outputs the table
?>