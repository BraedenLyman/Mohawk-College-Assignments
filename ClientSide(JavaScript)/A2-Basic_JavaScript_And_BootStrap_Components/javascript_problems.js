/*
    The purpose of this doucument is to solve the problems that 
    were givin to us using JavaScript and have them displayed on a 
    webpage.
    
    Author: Braeden Lyman
    Student ID: 000370695
    File: javascript_problems.js
*/


/* Group 1 - Choice 1 */
function group1Choice1 () {
    let inputRef = document.querySelector("#g1c1_input");
    let outputRef = document.querySelector("#g1c1_output");
    let inputVal = Number.parseInt (inputRef.value);

    if (!isNaN(inputVal)) {
        if (inputVal === 0 || (inputVal >=13 && inputVal <=17)) {
            outputRef.value = "In range";
        } else {
            outputRef.value = "Out of range";
        }
    } else {
        outputRef.value = "Not a number"; 
    }

}

/* Group 1 - Choice 2 */
function group1Choice2 () {
    let inputRef = document.querySelector("#g1c2_input");
    let outputRef = document.querySelector("#g1c2_output");
    let inputVal = Number.parseFloat (inputRef.value);

    if (!isNaN(inputVal)){
        if (inputVal >=0) {
            year = Math.floor(inputVal / 365.25); // Convert input to x amount of years
            month = Math.floor((inputVal % 365.25) / 30.44); // Convert input to x amount of months
            day = (inputVal % 365.25) % 30.44; // Convert input to x amount of days
            day = day.toFixed(2); // Displays day to the nearest two decimal places
            outputRef.value = year + " years, " + month + " months, and " + day + " days";
        }
    } else {
        outputRef.value = "Non-numeric or negative input";
    }
}

/* Group 2 - Choice 1 */
function group2Choice1 (){
    let inputRef = document.querySelector("#g2c1_input");
    let outputRef = document.querySelector("#g2c1_output");
    let inputVal = inputRef.value;

    inputStringVal = true;
    while (inputStringVal) {
        if (inputVal === "a" || inputVal === "A" ||
            inputVal === "e" || inputVal === "E" || 
            inputVal === "i" || inputVal === "I" ||
            inputVal === "o" || inputVal === "O" || 
            inputVal === "u" || inputVal  === "U"
            ) {
            outputRef.value =  "A Vowel";
            inputStringVal = false;
        } else if (inputVal === "y"|| inputVal === "Y") {
            outputRef.value = "Sometimes";
            inputStringVal = false;
        } else {
            outputRef.value = "Not a vowel";
            inputStringVal = false;
        }
    }
}

/* Group 2 - Choice 3 */
function group2Choice3 (){
    let inputRef = document.querySelector("#g2c3_input");
    let outputRef = document.querySelector("#g2c3_output");
    let inputVal = Number.parseInt (inputRef.value);
    let start = 1;
    for (let i = 1; i <=inputVal; i++){
        start *= i
    } 
    outputRef.value =  start;
}

/* Group 3 - Choice 1 */
function group3Choice1 (){
    let inputRef = document.querySelector("#g3c1_input");
    let outputRef = document.querySelector("#g3c1_output");
    let result = 0;

    if (inputRef.value.length < 10 || inputRef.value.length > 20){
        outputRef.value = 0;
    }

    for (let i = 0; i < inputRef.value.length; i++) {
        if (inputRef.value[i] !== "0" && inputRef.value[i] !== "1") {
            outputRef.value = 0;
        }
    }

    for (let i = 0; i < inputRef.value.length; i ++) {
        if (inputRef.value[i] === "1") {
            result += Math.pow(2, i);
        } 
        
    }
    outputRef.value = result;
}