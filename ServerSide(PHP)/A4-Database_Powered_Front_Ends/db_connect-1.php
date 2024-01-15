<?php
/**
 * I Braeden Lyman, 000370695, certify that this material is my original work. 
 * No other person's work has been used without suitable acknowledgment and I have not 
 * made my work available to anyone else.
 * 
 * The purpose of this file is to connect to a database that has the data from the 10260_assignment_4.sql file
 * using the PDO method. If the connection is successful, the quotes.php file will be able to query items from 
 * the database. If it failed to connect, then it will display an error message saying what is wrong.
 * 
 * @author Braeden Lyman
 * @version 2023.11.27
 * @package Comp 10260 Assignment 4
*/

$servername = "localhost";              // server name
$dbName = "sa000370695";                // database name
$username = "sa000370695";              // username
$password = "Sa_19970104";              // password

// try catch to connect to the database
try 
{
        $db = new PDO("mysql:host=$servername;dbname=$dbName", $username, $password);   // connects to the database
} 
catch (Exception $e) 
{
    exit ("ERROR: Could not connect to the database. {$e-> getMessage()}");             // error message if connection is unsuccessful
}
?>