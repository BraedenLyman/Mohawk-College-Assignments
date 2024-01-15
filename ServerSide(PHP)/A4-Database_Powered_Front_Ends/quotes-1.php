<?php
/**
 * I Braeden Lyman, 000370695, certify that this material is my original work. 
 * No other person's work has been used without suitable acknowledgment and I have not 
 * made my work available to anyone else.
 * 
 * The purpose of this file is to retrieve the information from the connected database 
 * (db_connect.php) regarding author name and quote text that will be displayed on 
 * BootStrap 5 Cards. The information is gathered using a query, then prepared to be
 * executed. If the execution is successful, the results are taken and put into a function
 * that contains BootStrap5 html cards with the results on them. It then sends the cards 
 * back to the client side as a JSON string for displaying the results to the a4.html file. 
 * Each page has a maximum of 20 cards per page and when the user scrolls on the page an 
 * event will occur where the Cards displayed will be different then the previous page. 
 * 
 * @author Braeden Lyman
 * @version 2023.11.27
 * @package Comp 10260 Assignment 4
 */

$page = filter_input(INPUT_GET, 'page', FILTER_VALIDATE_INT);       // filters the page parameter
include("db_connect.php");                                          // connects the database from db_connect.php
$limit = 20;                                                        // limits bootsrap5 cards to 20 per page

// checks to see if page is positive integer
if (!$page || $page < 1) {
    $page = 1;  // sets page to 1 if page not found or page is not a positive integer
}

$offset = ($page - 1) * $limit;                                     // offset for skipping quotations from previous pages

// query for gathering author name and quote text
$query = "SELECT quotes.quote_text, authors.author_name
          FROM quotes
          JOIN authors ON quotes.author_id = authors.author_id
          LIMIT $limit
          OFFSET $offset
          ";

$stm = $db->prepare($query);                                        // prepares the query for the selected database                         
$success = $stm->execute();                                         // exectues the query

// checks to see if execution is successful
if (!$success) {
    echo "Error \n";                                                // displays error message if unsuccessful
} else {
    
    /**
     * htmlContent function is to display a bootstrap5 card with the author name 
     * and quote text
     * 
     * @return - An html string that creates a bootstrap5 card with author name and quote text
     */
    function htmlContent($author, $quote) {
        return 
        '<div class="card mb-3 a4card w-100">
            <div class="card-header bg-info">' . $author . '</div>
            <div class="card-body d-flex align-items-center bg-secondary">
                <p class="card-text w-100">' . $quote . '</p>
            </div>
        </div>';
    }

    $cards = [];                                                                // creates an empty aray of cards

    // while loop to fetch the author name and quote text
    while ($result = $stm->fetch(PDO::FETCH_ASSOC)) {
        $cards[] = htmlContent($result['author_name'], $result['quote_text']);  // puts the content from the htmlContent function with the fetched author and quote text into the cards array 
    };

    $jsonString = json_encode($cards);                                          // encodes the cards array to send to the client side as JSON string
    echo $jsonString;       
}
?> 