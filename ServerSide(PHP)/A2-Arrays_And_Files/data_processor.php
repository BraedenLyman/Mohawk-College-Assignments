<?php
/**
 * I Braeden Lyman, 000370695, certify that this material is my original work. 
 * No other person's work has been used without suitable acknowledgment and I have not 
 * made my work available to anyone else.
 * 
 * The purpose of this file is to process the button click event and the dropdown
 * change sorting event chosen by the user on the client side. This php file takes
 * those values, filters & sanitizes them, then opens and reads the corresponding 
 * files to send them to the client side code for the user to view, based on their 
 * choices.
 * 
 * @author Braeden Lyman
 * @version 2023.11.01
 * @package Comp 10260 Assignment 2
 */

    $choice = filter_input(INPUT_GET, 'choice', FILTER_DEFAULT); // filters users input choice option
    $sort = filter_input(INPUT_GET, 'sort', FILTER_DEFAULT); // filters users input sort option   

    // checks to see if choice value is pokemon or movies and sort value is a or d
    if ($choice !== false && ($choice === 'pokemon' || $choice === 'movies' && $sort === 'a' || $sort === 'd')) {
        if ($choice === 'pokemon') {
            echo readPokemon($sort);
        }  elseif ($choice === 'movies') {
            echo readMovies($sort);
        } else {
            echo "Invalid Choice";
        }
    } else {
        echo "Invalid choice";
    }

    /**
     * readPokemon function is to open, read and send the data in the pokemon.txt 
     * file to the client side code if the users choice value is pokemon. It also 
     * sorts the data based on users sort choice on the client side. After its 
     * done processing and has sent the information to the client side, it then
     * closes the file.
     * 
     * @return $pokemonData as a JSON encoded array sorted ascending or sorted descending
     */
    function readPokemon($sort) {
        $pokemonFile = 'pokemon.txt'; // pokemon text file
        $file = fopen($pokemonFile, "r"); // open file for reading
        $pokemonData = []; // intializing the array

        // checks to see if file is read and if it is read it then goes 
        // throug the file line by line to the end of the file.
        if ($file) {
            while (!feof($file)) {
                $name = trim(fgets($file)); // gets the field name 'name' 
                $image = trim(fgets($file)); // gets the field name 'image'
                $pokemonData[] = ['name' => $name, 'image' => $image]; // pokemonData assoiative array of name and image
            } 
            fclose($file); // closes the flie 

            // sort by ascending 
            if ($sort === 'a') {
                usort ($pokemonData, function($a, $b) {
                    return strcmp($a['name'], $b['name']);
                });
            // sort by descending
            } elseif ($sort === 'd') {
                usort($pokemonData, function($a, $b) {
                    return strcmp($b['name'], $a['name']);
                });
            }
            return json_encode($pokemonData);
        } else {
            echo "Failed to open the file";
        }
    }

    /**
     * readMovies function is to open, read and send the data in the movies.json
     * file to the client side code if the users choice value is movies. It alos
     * sorts the data based on users sort choice on the client side. After its 
     * done processing and has sent the information to the client side, it then
     * closes the file. 
     * 
     * @return $moviesIndexed as a JSON encoded array sorted ascending or descending
     */
    function readMovies($sort) {
        $moviesFile = 'movies.json'; // movie JSON file
        $file = fopen($moviesFile, "r"); // open file for reading

        // checks to see if file is open
        if ($file) {
            $jsonMoviesContent = file_get_contents($moviesFile); // gets file contents
            $movieData = json_decode($jsonMoviesContent); // file contents is decoded from a JSON file
            
            // checks to see if JSON decoded file opens
            if ($movieData) {
                $moviesIndexed = []; // creates an associative array
                
                // iterates through the filedata 
                foreach($movieData as $index => $movies) {
                    $moviesIndexed[$index] = [ // moviesIndexed associative array of name and year
                        'name' => $movies->name,
                        'year' => $movies->year
                    ];
                }
                fclose($file); // closes the file

                // sort by ascending
                if ($sort === 'a') {
                    usort ($moviesIndexed, function($a, $b) {
                        return strcmp($a['name'], $b['name']);
                    });
                // sort by descending
                } elseif ($sort === 'd') {
                    usort($moviesIndexed, function($a, $b) {
                        return strcmp($b['name'], $a['name']);
                    });
                }
                return json_encode($moviesIndexed);
            } else {
                fclose($file);
                return "Failed to read JSON file.";
            }
        } else {
            return "Failed to open JSON file.";
        }
    }  
?>