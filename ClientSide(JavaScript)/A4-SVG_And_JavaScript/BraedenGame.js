/**
 * This file is to create a game using SVG grapichs. It contains
 * simple shapes and movement using the setInterval method.
 * It also has collision detection to see if the user has won or lost.
 * 
 * File Name: BraedenGmae.js
 * By: Braeden Lyman
 * Student Id: 000370695
 */


const svgNS = "http://www.w3.org/2000/svg";

let rectY; // rectangle movement on the y-axis.
let rectX; // rectangle movement on the x-axis.
let rectDirection = {x: 0, y: 0}; //rectangle direction starting point.
let currentLevel = 1; // Current Level.
var newRect; // new rectangle variable.
let gameRunning = false; // to see if the game is running or not. Starts off as not running.
let movingRect; // moving recatngle variable.
let border11; // border11 - border variable for level one.
let border12; // border12 - border variable for level one.
let winSquare11; // winSquare11 - winner square variable for level one.

let border21; // border21 - border variable for level two.
let border22; // border22 - border variable for level two.
let border23; // border23 - border variable for level two.
let border24; // border24 - border variable for level two.
let border25; // border25 - border variable for level two.
let winSquare21; // winSquare21 - winner square variable for level two.
let rectMovesX = 10; // Starting point of the moving rectangle on the x-axis.
let rectMovesY = 10; // Starting point of the moving rectangle on the y-axis.

/**
* The createRect function is to create a rectangle shape
* using SVG graphics.
* 
* @param {AttributeNS} x - X-axis location of the rectangle.
* @param {AttributeNS} y - Y-axis location of the rectangle.
* @param {AttributeNS} width - Width of th rectangle.
* @param {AttributeNS} height - Height of the rectangle.
* @param {AttributeNS} fill - Fills in the color of the rectangle.
* @returns a rectangle.
*/
function createRect(x, y, width, height, fill) {
    let rect = document.createElementNS(svgNS, "rect"); // Creates a dynamic rectangle element.
    rect.setAttributeNS(null, "x", x);
    rect.setAttributeNS(null, "y", y);
    rect.setAttributeNS(null, "width", width);
    rect.setAttributeNS(null, "height", height);
    rect.setAttributeNS(null, "fill", fill);
    return rect;
}

/**
* createMovingRect function is to create a moving rectangle shape
* using SVG graphics.
* @param {AttributeNS} x - X-axis location of the rectangle.
* @param {AttributeNS} y - Y-axis location of the rectangle.
* @param {AttributeNS} width - Width of the rectangle.
* @param {AttributeNS} height - Height of the rectangle.
* @param {AttributeNS} fill  - Fills in the color of the rectangle.
* @returns a moving rectangle.
*/
function createMovingRect(x, y, width, height, fill) {
    let movingRect = createRect(x, y, width, height, fill) // Creates a dynamic moving rectangle element.
    return movingRect;
}

/**
* moveRect function is to create the movement for 
* the player square.
*/
function moveRect() {

    if (currentLevel === 1) {  // Level one check collisionCheck.
        collisionCheck(); // Calls collisionCheck function.
    } else if (currentLevel === 2) { // level two check collisionCheck2.
        collisionCheck2();
    }

    rectX += rectDirection.x * 4; // Player square moves left and right * 4.
    rectY += rectDirection.y * 4; // Player square moves up and down * 4.

    // if-statement for calculating if the square is in the boundries, then move in the x or y directon * 1.
    if (rectX <=1 || rectX >=480 - 25) {
        rectX = Math.max(1, Math.min(480 -25, rectX));
        rectDirection.x *= 1;
    }
    if (rectY <= 1 || rectY >= 480 - 25) {
        rectY = Math.max(1, Math.min(480 -25, rectY));
        rectDirection.y *= 1;
    }

    newRect.setAttributeNS(null, "x", rectX); // newRect location on the x-axis.
    newRect.setAttributeNS(null, "y", rectY); // newRect location on the y-axis.
    colorPick(); // Calls the colorPick function.
}

/**
* changeDirection function is to allow the user's rectangle
* (blue square) to have movement.
* @param {Number} changeX - changes the x-location based on player movement. 
* @param {Number} changeY - changes the y-loccation based on player movement.
*/ 
function changeDirection(changeX, changeY) {
    rectDirection.x = changeX;
    rectDirection.y = changeY;
}

/**
* colorPick function is to allow user to choose a color of their moving square.
*/
function colorPick() {
    let colorPick = document.getElementById("colorPick");
    colorPick.addEventListener("input", function() {  
        let color = colorPick.value;
        newRect.setAttributeNS(null, "fill", color); // newRect attribute for filling in the color of the user's square from the user's input.
    })
}

/**
* start function is the main function that puts all of the other
* functions toether to create the game.
*/
function start() {
    let startStopButton = document.getElementById("startButton"); // Dynamic button for starting or stopping the game.
        
    startStopButton.addEventListener("click", function() {
        if (gameRunning) {
            startStopButton.innerHTML = "Start Game!";
            gameRunning = false;
            removeRectangles(); // Calls the removeRectangles function.
            cleanUpLevel1(); // Calls the cleanUpLevel1 function.
            clearInterval(intervalId); // Clears the current interval.
        } else {
            startStopButton.innerHTML = "Stop Game"
            var svgArea = document.getElementById("svgArea");
            newRect = createRect(rectX, rectY, 25, 25, "blue"); // Creates the player rectangle that defaults to the color blue. 
            svgArea.appendChild(newRect); // Adds the player rectangle to the SVG area.
            level1(); // Calls the level1 function.
            buttonClicks(); // Calls the buttonClicks function.
            keyBoardEvents(); // Calls the keyBoardEvents function.
            getLevel(); // Calls the getLevel function.
        }
    });
}

/**
* moveMyRectX function is to create movement on the x-axis 
* for the moving rectangle.
* @returns X-axis movemment for the moving rectangle.
*/
function moveMyRectX() {
    rectMovesX += 5;
    if (rectMovesX >= 480) {
        rectMovesX =  -40;
    }

    const movingRectLeft = rectMovesX;
    const movingRectRight = rectMovesX + 50;
    const movingRectTop = 225;
    const movingRectBottom = 225 + 50;
    const playerRectRight = rectX + 25;
    const playerRectBottom = rectY + 25;

    // if-statement for if player square (blue sqaure) collides with the moving rectangle, then it's game over.
    if (
        movingRectRight >= rectX &&
        movingRectLeft <= playerRectRight &&
        movingRectBottom >= rectY &&
        movingRectTop <= playerRectBottom
    ) {
        gameOver(); // Calls the gameOver function.
        return;
    }

    movingRect.setAttributeNS(null, "x", rectMovesX);
}

function cleanUpLevel1() {
    svgArea.removeChild(border11); // Removes border11.
    svgArea.removeChild(border12); // REmoves border12.
    svgArea.removeChild(winSquare11); // Removes winSquare11.
    svgArea.removeChild(movingRect); // Removes movingRect.
    clearInterval(intervalId); // Clears the intervalId interval.
    clearInterval(intervalId1); // Clears the intervalId1 interval.
}

/**
* level1 function creates all of the elements for level1.
*/
function level1() {
    currentLevel === 1; 

    rectY = 450; // Starting point for user square on the x-axis.
    rectX = 225; // Starting point for user square on the y-axis.

    var borderA1 = document.getElementById("svgArea"); // Getting id for where to place borderA1.
    var borderB1 = document.getElementById("svgArea"); // Getting id for where to place borderB1.
    var winSquareA1 = document.getElementById("svgArea"); // Getting id for where to place winSqaure11.

    border11 = createRect(0, 0, 215, 480, "black"); // Creating dynamic border11.
    border12 = createRect(260, 0, 220, 480, "black"); // Creating dynamic border12.
    winSquare11 = createRect(215, 0, 45, 30, "green"); // Creating dynamic winSquare11.

    borderA1.appendChild(border11); // Adding border11 to SVG area.
    borderB1.appendChild(border12); // Adding border12 to SVG area.
    winSquareA1.appendChild(winSquare11); // Adding winSquare11 to SVG area.

    intervalId1 = setInterval(moveRect, 10); // setInterval for user square movement.
    movingRect = createMovingRect(rectMovesX, 225, 50, 50, "orange"); // Creating moving rectangle on the x-axis.
    svgArea.appendChild(movingRect); // Adding movingRect to the SVG area. 
    intervalId = setInterval(moveMyRectX, 10); // setInterval for moving rectangle movement.
    gameRunning = true; // To check if the game is running.
    

}

/**
* level2 function creates aqll of the elements for level2.
*/
function level2() {
    currentLevel === 2;

    rectY = 450; // Starting point for user square on the x-axis.
    rectX = 10; // Starting point for user square on the y-axis.

    var borderA2 = document.getElementById("svgArea"); // Getting id for where to place borderA2.
    var borderB2 = document.getElementById("svgArea"); // Getting id for where to place borderB2.
    var borderC2 = document.getElementById("svgArea"); // Getting id for where to place borderC2.
    var borderD2 = document.getElementById("svgArea"); // Getting id for where to place borderD2.
    var borderE2 = document.getElementById("svgArea"); // Getting id for where to place borderE2.
    var winSquareA2 = document.getElementById("svgArea"); // Getting id for where to place winSquareA2.
 
    border21 = createRect(0, 0, 60, 410, "black"); // Creating dynamic border21.
    border22 = createRect(120,50, 360, 80, "black"); // Creating dynamic border22.
    border23 = createRect(60,380, 360, 30, "black"); // Creating dynamic border23.
    border24 = createRect(120, 210, 360, 120, "black"); // Creating dynamic border24.
    border25 = createRect(60, 165, 340, 10, "black"); // Creating dynamic border25.
    winSquare21 = createRect(450, 0, 30, 50, "green"); // Creating dynamic winSquare21.

    borderA2.appendChild(border21); // Adding border21 to SVG area.
    borderB2.appendChild(border22); // Adding border22 to SVG area.
    borderC2.appendChild(border23); // Adding border23 to SVG area.
    borderD2.appendChild(border24); // Adding border24 to SVG area.
    borderE2.appendChild(border25); // Adding border25 to SVG area.
    winSquareA2.appendChild(winSquare21); // Adding winSquare21 to SVG area.

    intervalId1 = setInterval(moveRect, 10); // setInterval for user square movement.
    movingRect = createMovingRect(rectMovesX, 225, 50, 50, "orange"); // Creating moving rectangle on the x-axis.
    svgArea.appendChild(movingRect); // Adding movingRect to the SVG area.
    intervalId = setInterval(moveMyRectX, 10); // setInterval for moving rectangle movement.
    gameRunning = true; // To check if the game is running.
}

/**
* setupNextLevel function is to set up the next level 
* in the SVG game area.
*/
function setupNextLevel() {
    currentLevel ++; 

    if (currentLevel === 2) {
        cleanUpLevel1(); // Calls cleanUpLevel1 function.
        level2(); // Calls level2 function.
        return;
    } else {
        var svgArea = document.getElementById("svgArea");
        removeRectangles(); // Calls removeRectangles function.
        var text = document.createElementNS(svgNS, "text"); // Creates a text area to display text.
        text.setAttributeNS(null, "x", 100); // text attribute - x-axis location.
        text.setAttributeNS(null, "y", 200); // text attribute - y-axis location.
        text.setAttributeNS(null, "font-size", "40");  // text attribute - sets the font size to 40.
        text.setAttributeNS(null, "fill", "blue"); // text attribute - fills in the color to blue. 
        text.textContent = "Congratulations"; // Sets the text.
        svgArea.appendChild(text); // Addes the dynamix text to the SVG area. 

        var text2 = document.createElementNS(svgNS, "text"); // Creates a text area to display text.
        text2.setAttributeNS(null, "x", 20); // text attribute - x-axis location.
        text2.setAttributeNS(null, "y", 300); // text attribute - y-axis location.
        text2.setAttributeNS(null, "font-size", "40");  // text attribute - sets the font size to 40.
        text2.setAttributeNS(null, "fill", "blue"); // text attribute - fills in the color to blue. 
        text2.textContent = "You completed all levels!"; // Sets the text.
        svgArea.appendChild(text2); // Addes the dynamix text to the SVG area. 
    }
    getLevel(); // Calls the getLevel function.
}

/**
* getLevel function gets the current level user is on and displays it to the html document.
*/
function getLevel() { 
    let levelNow = document.getElementById("currentLevel");
    levelNow.textContent = currentLevel.toString(); // Uses the currentLevel variable that keeps track of current level and outputs it as a string to the html document.
}

/**
* collisionCheck function is to check the collision
* between the user rectangle, the moving rectangle 
* the winSquare and the borders in the SVG area on level 1.
* @returns gameOver function or youWin function based on the outcome of the game.
*/
function collisionCheck() {
    const rectRight = rectX + 25; 
    const rectBottom = rectY + 25;

    const movingRectLeft = rectX; 
    const movingRectRight = rectRight; 
    const movingRectTop = rectY; 
    const movingRectBottom = rectBottom;

    // level1 - border11 collision check.
    const border11Left = parseFloat(border11.getAttributeNS(null, "x")); // Calculations for border11 leftside collison.
    const border11Right = border11Left + parseFloat(border11.getAttributeNS(null, "width")); // Calculations for border11 rightside collison.
    const border11Top = parseFloat(border11.getAttributeNS(null, "y")); // Calculations for border11 top collison.
    const border11Bottom = border11Top + parseFloat(border11.getAttributeNS(null, "height")); // Calculations for border11 bottom collison.

    // if-statement for if collison on border11 - Call gameOver function.
    if (
        movingRectRight >= border11Left &&
        movingRectLeft <= border11Right &&
        movingRectBottom >= border11Top &&
        movingRectTop <= border11Bottom
    ) {
        gameOver(); // Calls the gameOver function.
        return;
    }

    // level1 - border12 collision check.
    const border12Left = parseFloat(border12.getAttributeNS(null, "x")); // Calculations for border12 leftside collison.
    const border12Right = border12Left + parseFloat(border12.getAttributeNS(null, "width")); // Calculations for border12 rightside collison.
    const border12Top = parseFloat(border12.getAttributeNS(null, "y")); // Calculations for border12 top collison.
    const border12Bottom = border12Top + parseFloat(border12.getAttributeNS(null, "height")); // Calculations for border12 bottom collison.

    // if-statement for if collison on border12 - Call gameOver function.
    if (
        movingRectRight >= border12Left &&
        movingRectLeft <= border12Right &&
        movingRectBottom >= border12Top &&
        movingRectTop <= border12Bottom
    ) {
        gameOver(); // Calls the gameOver function.
        return;
    }

    // level1 - winSquare11 collision check.
    const winSquare11Left = parseFloat(winSquare11.getAttributeNS(null, "x")); // Calculations for winSaqure11 leftside collison.
    const winSquare11Right = winSquare11Left + parseFloat(winSquare11.getAttributeNS(null, "width")); // Calculations for winSquare11 rightside collison.
    const winSquare11Top = parseFloat(winSquare11.getAttributeNS(null, "y")); // Calculations for winSquare11 top collison.
    const winSquare11Bottom = winSquare11Top + parseFloat(winSquare11.getAttributeNS(null, "height")); // Calculations for winSquare bottom collison.

    // if-statement for if collison on winSquare11 - Call youWin function.
    if (
        movingRectRight >= winSquare11Left &&
        movingRectLeft <= winSquare11Right &&
        movingRectBottom >= winSquare11Top &&
        movingRectTop <= winSquare11Bottom
    ) {
        youWon(); // Calls the youWon function.
        return;
    }

}

/**
* collisionCheck function is to check the collision
* between the user rectangle, the moving rectangle 
* the winSquare and the borders in the SVG area on level 2.
* @returns gameOver function or youWin function based on the outcome of the game.
*/
function collisionCheck2(){
    const rectRight = rectX + 25;
    const rectBottom = rectY + 25;

    const movingRectLeft = rectX;
    const movingRectRight = rectRight;
    const movingRectTop = rectY;
    const movingRectBottom = rectBottom;

    // level2 - border21 collision check
    const border21Left = parseFloat(border21.getAttributeNS(null, "x"));  // Calculations for border21 leftside collison.
    const border21Right = border21Left + parseFloat(border21.getAttributeNS(null, "width"));  // Calculations for border22 rightside collison.
    const border21Top = parseFloat(border21.getAttributeNS(null, "y"));  // Calculations for border21 top collison.
    const border21Bottom = border21Top + parseFloat(border21.getAttributeNS(null, "height"));  // Calculations for border21 bottom collison.
 
     // if-statement for if collison on border21 - Call gameOver function.
     if (
        movingRectRight >= border21Left &&
        movingRectLeft <= border21Right &&
        movingRectBottom >= border21Top &&
        movingRectTop <= border21Bottom
     ) {
        gameOver(); // Calls the gameOver function.
        return;
     }
    
    // level2 - border22 collision check.
    const border22Left = parseFloat(border22.getAttributeNS(null, "x"));  // Calculations for border22 leftside collison.
    const border22Right = border22Left + parseFloat(border22.getAttributeNS(null, "width"));  // Calculations for border22 rightside collison.
    const border22Top = parseFloat(border22.getAttributeNS(null, "y"));  // Calculations for border22 top collison.
    const border22Bottom = border22Top + parseFloat(border22.getAttributeNS(null, "height"));  // Calculations for border22 bottom collison.

    // if-statement for if collison on border22 - Call gameOver function.
    if (
        movingRectRight >= border22Left &&
        movingRectLeft <= border22Right &&
        movingRectBottom >= border22Top &&
        movingRectTop <= border22Bottom
    ) {
        gameOver(); // Calls the gameOver function.
        return;
    }

    // level2 - border23 collision check.
    const border23Left = parseFloat(border23.getAttributeNS(null, "x")); // Calculations for border23 leftside collison.
    const border23Right = border23Left + parseFloat(border23.getAttributeNS(null, "width")); // Calculations for border23 rightside collison.
    const border23Top = parseFloat(border23.getAttributeNS(null, "y")); // Calculations for border23 top collison.
    const border23Bottom = border23Top + parseFloat(border23.getAttributeNS(null, "height")); // Calculations for border23 bottom collison.
 
    // if-statement for if collison on border23 - Call gameOver function.
     if (
        movingRectRight >= border23Left &&
        movingRectLeft <= border23Right &&
        movingRectBottom >= border23Top &&
        movingRectTop <= border23Bottom
     ) {
        gameOver(); // Calls the gameOver function.
        return;
     }

    // level2 - border24 collision check.
    const border24Left = parseFloat(border24.getAttributeNS(null, "x")); // Calculations for border24 leftside collison.
    const border24Right = border24Left + parseFloat(border24.getAttributeNS(null, "width")); // Calculations for border24 rightside collison.
    const border24Top = parseFloat(border24.getAttributeNS(null, "y")); // Calculations for border24 top collison.
    const border24Bottom = border24Top + parseFloat(border24.getAttributeNS(null, "height")); // Calculations for border24 bottom collison.

    // if-statement for if collison on border24 - Call gameOver function.
    if (
        movingRectRight >= border24Left &&
        movingRectLeft <= border24Right &&
        movingRectBottom >= border24Top &&
        movingRectTop <= border24Bottom
    ) {
        gameOver(); // Calls the gameOver function.
        return;
    }

    // level2 - border25 collision check. 
    const border25Left = parseFloat(border25.getAttributeNS(null, "x")); // Calculations for border25 leftside collison.
    const border25Right = border25Left + parseFloat(border25.getAttributeNS(null, "width")); // Calculations for border25 rightside collison.
    const border25Top = parseFloat(border25.getAttributeNS(null, "y")); // Calculations for border25 top collison.
    const border25Bottom = border25Top + parseFloat(border25.getAttributeNS(null, "height")); // Calculations for border25 bottom collison.
    
    // if-statement for if collison on border25 - Call gameOver function.
    if (
        movingRectRight >= border25Left &&
        movingRectLeft <= border25Right &&
        movingRectBottom >= border25Top &&
        movingRectTop <= border25Bottom
    ) {
        gameOver(); // Calls the gameOver function.
        return;
    }

    // level2 - winSquare21 collision check.
    const winSquare21Left = parseFloat(winSquare21.getAttributeNS(null, "x")); // Calculations for winSquare21 leftside collison.
    const winSquare21Right = winSquare21Left + parseFloat(winSquare21.getAttributeNS(null, "width")); // Calculations for winSquare rightside collison.
    const winSquare21Top = parseFloat(winSquare21.getAttributeNS(null, "y")); // Calculations for winSquare21 top collison.
    const winSquare21Bottom = winSquare21Top + parseFloat(winSquare21.getAttributeNS(null, "height")); // Calculations for winSquare21 bottom collison.
  
    // if-statement for if collison on winSqaure21 - Call youWin function.
    if(
        movingRectRight >= winSquare21Left &&
        movingRectLeft <= winSquare21Right &&
        movingRectBottom >= winSquare21Top &&
        movingRectTop <= winSquare21Bottom
    ){
        youWon(); // Calls the gameOver function.
        return;
    }
}

/**
* youWin function displays a message saying "You Won!" if you beat both levels.
*/
function youWon() {
    setupNextLevel(); // Calls the setupNextLevel function.
    getLevel(); // Calls the getLevel function.
}

/**
* gameOver function displays a message saying "Game Over" if user looses.
*/
function gameOver() {
    var svgArea = document.getElementById("svgArea");
    removeRectangles(); // Calls removeRectangles function.
    var text = document.createElementNS(svgNS, "text"); // Creates dynamic text in the SVG area.
    text.setAttributeNS(null, "x", 150); // text attribute - x-axis location.
    text.setAttributeNS(null, "y", 250); // text attribute - y-axis location.
    text.setAttributeNS(null, "font-size", "40");  // text attribute - sets the font size to 40.
    text.setAttributeNS(null, "fill", "red"); // text attribute - fills the text color in as red.
    text.textContent = "Game Over"; // displays text inside the SVG grapics area when you loose.
    svgArea.appendChild(text); // Adds text to the SVG area.
}

/**
* removeRectangles function removes all of the rectangles in the SVG area.
*/
function removeRectangles() {
    var svgArea = document.getElementById("svgArea");
    while (svgArea.firstChild) {
        svgArea.removeChild(svgArea.firstChild);
    } 
}

/**
* buttonClicks function creates the mouse down and mouse up action events for the
* left, right, down, and up buttons in the html document.
*/
function buttonClicks() {
    let leftB = document.getElementById("leftButton"); // Left button variable.
    let rightB = document.getElementById("rightButton"); // Right button variable.
    let upB = document.getElementById("upButton"); // Up button variable.
    let downB = document.getElementById("downButton"); // Down button variable.

    // Left button mousedown event.
    leftB.addEventListener("mousedown", function(){
       changeDirection(-1, 0);
    })

    // Left button mouseup event.
    leftB.addEventListener("mouseup", function(){
        changeDirection(0, 0);
    })

    // Right button mousedown event.
    rightB.addEventListener("mousedown", function(){
        changeDirection(1, 0);
    })

    // Right button mouseup event.
    rightB.addEventListener("mouseup", function(){
        changeDirection(0, 0);
    })

    // Up Button mousedown event.
    upB.addEventListener("mousedown", function(){
        movingUp = true;
        changeDirection(0, -1);
    })

    // Up Button mouseup event.
    upB.addEventListener("mouseup", function(){
        movingUp = false;
        changeDirection(0, 0);
    })

    // Down Button mousedown event.
    downB.addEventListener("mousedown", function(){
        changeDirection(0,1);
    })

    // Down Button mouseUp event.
    downB.addEventListener("mouseup", function(){
        changeDirection(0, 0);
    });
}

/**
* keyBoardEvents function creates the mouse down and mouse up 
* action events for the left, right, down, and up arrow keys
* on a keyboard input.
*/
function keyBoardEvents() { 
    window.addEventListener("keydown", function (event){
         // if-statement for if arrowKeys are keydown.
        if (event.key === "ArrowLeft") {
            changeDirection(-1, 0);
        } else if (event.key === "ArrowRight") {
            changeDirection(1, 0);
        } else if (event.key === "ArrowUp") {
            changeDirection(0, -1);
        } else if (event.key === "ArrowDown") {
            changeDirection(0, 1);
        }
    });

    window.addEventListener("keyup", function (event){
        // if-statement for if arrowKeys are keyup.
        if (
            event.key === "ArrowLeft" ||
            event.key === "ArrowRight" ||
            event.key === "ArrowUp" ||
            event.key === "ArrowDown" 
        ){
            changeDirection(0, 0);
        }
    });
}

/**
* window event listener for adding the game to the SVG area.
*/
window.addEventListener("load", function() {
    start(); // Calls the start function.
});