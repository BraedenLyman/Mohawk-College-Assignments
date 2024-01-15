<?php
/**
 * I Braeden Lyman, 000370695, certify that this material is my original work. 
 * No other person's work has been used without suitable acknowledgment and I have not 
 * made my work available to anyone else.
 * 
 * The purpose of this file is to process an uploaded file to the server using a POST request and sending the information back to the client side 
 * to display the data. Depending on which column the user wants to sort the data by, the data is then sorted for that column.
 * 
 * @author Braeden Lyman
 * @version 2023.11.01
 * @package Comp 10260 Assignment 2
 */

 // check to see if request method is post and if a file name csvFile is present in the POST data
if ($_SERVER["REQUEST_METHOD"] == "POST" && isset($_FILES["csvFile"])) {
    $file = $_FILES["csvFile"]; // the csvFile
    $sortColumn = isset($_POST["sortColumn"]) ? intval($_POST["sortColumn"]) : 1; // sets the sortColumn to an int value and specifies the sorting column

    $fileContents = strtolower(pathinfo($file["name"], PATHINFO_EXTENSION)); // parses the path info of the file - extracts the extension of the file and converts it to lowercase

    // checks to see if parsed path info is a csv file  then sorts the array based on the column choice
    if ($fileContents === 'csv') {
        $csvData = array_map('str_getcsv', file($file["tmp_name"])); // parses every line in the csv file and returns it as an array of arrays
        $header = array_shift($csvData); // removes the first row containing the column names and assignes it to $header to hold the row as a header row

        // sorts the array based on the values of the specified column - determined by $sortColumn
        usort($csvData, function ($a, $b) use ($sortColumn) {
            return strnatcasecmp($a[$sortColumn - 1], $b[$sortColumn - 1]);
        });

        // creates a new array that maps the row data to its corresponding column header as keys
        $result = array_map(function ($row) use ($header) {
            return array_combine($header, $row);
        }, $csvData);

        // lets the client side know the data being sent back by the server is in JSON format
        header("Content-Type: application/json");
        echo json_encode($result);
    } else {
        header("HTTP/1.1 400 Bad Request"); // if not a csv file - displays a bad request header message
        echo "Invalid file format. Please upload a CSV file.";  
    }
} else {
    header("HTTP/1.1 400 Bad Request"); // if request is not POST or does not contain a csvFIle value - displays a bad request header message
    echo "Invalid request.";
}
?>