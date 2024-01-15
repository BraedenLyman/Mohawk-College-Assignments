/**
 * This document is for creating functions to request data from the csuinx server
 * and if successful, returns it to display on the index.html document.
 * Information recived is dependent on users input choice as well as 
 * buton choice. Each button reuqests different information.
 * 
 * Name: Braeden Lyman
 * Student ID: 000370695
 * Date: Augest 06, 2023
 */

/**
 * firstFetch function is for when user clicks the first button
 * it fetches the url from csunix and asks for a response. 
 * If response is successful, it calls the firstSuccess function.
 * function also disables radio input after clicking button.
 */
function firstFetch() {
    document.getElementById("firstB").addEventListener("click", function(){
        let url = "https://csunix.mohawkcollege.ca/~adams/10259/a6_responder.php"; // url trying to fetch for.
        fetch(url)
        .then(response => response.text())
        .then(firstSuccess);
        disableUserInput(); 
    })
}

/**
 * firstSuccess function is for when the fetch is successful.
 * It returns a text with student number.
 * @param {fetch} a - adds the fetch text to student # 000370695 as a string. 
 */
function firstSuccess(a) {
    let text = document.createElement("h1");
    text.textContent = a + " Student # 000370695";

    let firstF = document.getElementById("firstF");
    firstF.innerHTML = "";
    firstF.appendChild(text);
}

/**
 * secondFetch function is for when user clicks the second button
 * it fetches the url from csunix and asks for a response.
 * If response is successful, it calls the secondSuccess function.
 * function also disables radio input after clicking button.
 */
function secondFetch() {
    document.getElementById("secondB").addEventListener("click", function(){
        let choice = "mario"
        let copyrightMessage = "";

        // if-statement for if mario checked - displays mario copyright, if starwars checked - displays starwars copyright.
        if (document.getElementById('starwars').checked) {
            choice = "starwars"
            copyrightMessage = "Star Wars \u00A9 & TM 2022 Lucasfilm Ltd. All rights reserved. Visual material \u00A9 2022 Electronic Arts Inc."
        } else {
            copyrightMessage = "Game trademarks and copyrights are properties of their respective owners. Nintendo properties are trademarks of Nintendo. \u00A9 2019 Nintendo.";
        }
        
        document.getElementById("copyrightInfo").textContent = copyrightMessage;
        let url = "https://csunix.mohawkcollege.ca/~adams/10259/a6_responder.php?choice=" + choice;
            fetch(url)
            .then(response => response.json())
            .then(secondSuccess);
            disableUserInput();
    });
}

/**
 * secondSuccess function is for when the second fetch is successful.
 * It returns 2 strings and 1 image element grouped together from 1 up 
 * to at most 3 grouped elements. 
 * @param {*fetch} a - adds series, img, and name to a div in the html doc. 
 */
function secondSuccess(a) {
    let dataInfo = document.getElementById("secondF");
    console.log(JSON.stringify(a)); // For debugging.
    
    let rows = "";
    // for-loop for adding series string, url, and name string to div dependign on a's length recieved.
    for (let i = 0; i < a.length; i++) {
           rows +=  "<div class='col'>" +
                    "<h2>" + a[i].series + "</h2>" +
                    "<img src='" + a[i].url + "' class='d-flex justify-content-center img-fluid'>" +
                    "<p>" + a[i].name + "</p>" +
                    "</div>";
    }
    dataInfo.innerHTML = rows;
}

/**
 * thirdFetch function is for when user clicks on the third button
 * it fetches the url from csuinx and asks for a response.
 * If successful, it calls the thirdSuccess function.
 * function also disables radio input after clicking button.
 */
function thirdFetch() {
    document.getElementById("thirdB").addEventListener("click", function(){
        let choice = "mario"
        let copyrightMessage = "";

        // if-statement for if mario checked - displays mario copyright, if starwars checked - displays starwars copyright.      
        if (document.getElementById('starwars').checked){
            choice = "starwars"
            copyrightMessage = "Star Wars \u00A9 & TM 2022 Lucasfilm Ltd. All rights reserved. Visual material \u00A9 2022 Electronic Arts Inc."
        } else {
            copyrightMessage = "Game trademarks and copyrights are properties of their respective owners. Nintendo properties are trademarks of Nintendo. \u00A9 2019 Nintendo.";
        }
    
        document.getElementById("copyrightInfo2").textContent = copyrightMessage;
        let url = "https://csunix.mohawkcollege.ca/~adams/10259/a6_responder.php?choice=" + choice;
            fetch(url, { method: "POST"})
            .then(response => response.json())
            .then(thirdSuccess);
            disableUserInput();
    });
}

/**
 * thirdSuccess function is for when the third fetch is successful.
 * It reurns a table of elemnents from 1 to at most 15.
 * @param {*} a adds series, name and url to a created table depending on length recieved.
 */
function thirdSuccess(a) {
    let data = document.querySelector(".thirdF");
    console.log(JSON.stringify(a)); // for debugging.

    // table header data.
    let dataTable = '<thead id="datahead">' +
                    '<tr><th>Series</th><th>Name</th><th>Link</th>' +
                    '</thead>' +
                    '<tbody>';
    // for-loop for adding series, name and url to created table depending on how many elements recieved.                
    for (let i = 0; i < a.length; i++) {
        row =   "<td>" + a[i].series + "</td>" + 
                "<td>" + a[i].name + "</td>" +
                "<td class='urlStyle'>" + a[i].url + "</td>";
                dataTable += "<tr>" + row + "</tr>"; 
    }
    
    dataTable +='</tbody>'
    data.innerHTML = dataTable;
}   

/**
 * disableInput function is for disabling the radio
 * input function after user clicks on any buttons.
 */
function disableUserInput() {
    document.getElementById("mario").disabled = true;
    document.getElementById("starwars").disabled = true;
}

/**
 * Windows event listener to add the fetches when the 
 * html document loads.
 */
window.addEventListener('load',function() {
    firstFetch(); 
    secondFetch();
    thirdFetch();
});