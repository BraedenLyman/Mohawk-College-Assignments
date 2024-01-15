/**  
 * This JavaScript doucment is to create functions that
 * interact with the html page. These functions are the 
 * logic beind how the images, buttons, inputs, and timers
 * work.
 * 
 * File: index.html
 * Name: Braeden Lyman
 * Student ID: 000370695
 * Date: July 13th, 2023
**/

window.addEventListener("load", function(){
randomStartImg();
animation();
myTimer();
userInput();
});

/**
 * Sports Array that holds a 2D array of 3x3 images.
 */
let sportsArray = [
['Images/hockey1.png', 'Images/hockey2.png', 'Images/hockey3.png'],
['Images/baseball1.png', 'Images/baseball2.png', 'Images/baseball3.png'],
['Images/soccer1.png', 'Images/soccer2.png', 'Images/soccer3.png']
];

/**
 * userInput function - To allow user to input a number between 500
 * and 10,000 that interacts with the count down timer.
 */
function userInput() {
    document.getElementById("numInput").addEventListener("input", function(){
        let nInput = document.getElementById("numInput").value;
        let errorMessage = document.getElementById("errorMsg");

        if (nInput < 500 || nInput > 10000) {
            errorMessage.textContent = "Please enter a number between 500 and 10,000"
        } else {
            errorMessage.textContent = "";
        }
    });
}

/**
 * myTimer function - Count down timer that displays in 1/10th
 * of a second. Updates images once counter reaches 0, and restarts
 * itself.
 */
function myTimer() {
    let count = document.getElementById("count");
    let count1 = 12; 
    let count2 = count1 * 10;
    let countdown = count2;

    intervalId = setInterval(function () {
        count2 --;
        countdown--;
        count.textContent = (countdown / 10).toFixed(1); // Converts countdown timer to 1/10th millisecond
           
        if ( count2 <= 0) {
            randomizeButtonImg();
            count1 = 10;  
            count2 = count1 * 10;
            countdown = count2;
        }

        count.classList.remove("green", "yellow", "red"); // Removes current background colors of timer.
        
        // Incraments the background color everytime the counter runs.
        if (countdown >= 50) {
            count.classList.add("green"); 
        } else if (countdown >= 20) {
            count.classList.add("yellow");
        } else { 
            count.classList.add("red");
            }
    }, 100);
}

let count = 0; // Starting count for image counter

/**
 * myImgCounter1 function - Adds 1 to the count everytime an image is clicked.
 */
function myImgCounter1() {
    let counter = document.getElementById("counter");
    count += 1;
    counter.textContent = count;
}

/**
 * myImgCounter3 function - Adds 3 to the count everytime ther Randomize button is clicked.
 */
function myImgCounter3() {
    let counter = document.getElementById("counter");
    count +=3;
    counter.textContent = count;
}

/**
 * randomStartImg function - Randomizes the starting images once the page is loaded
 * and refreshed.
 */
function randomStartImg() {
    let hockeyImg = document.getElementById("imgOne");
    let baseballImg = document.getElementById("imgTwo");
    let soccerImg = document.getElementById("imgThree");

    hockeyImg.src = sportsArray[0][randomImg()]; // 1 img from the hockey group.
    baseballImg.src = sportsArray[1][randomImg()]; // 1 img from the baseball group.
    soccerImg.src = sportsArray[2][randomImg()]; // 1 img from the sports group.
}

/**
 * randomClickImgOne function - Randomizes img 1.
 */
function randomClickImgOne() {
    let imgOne = document.getElementById("imgOne");
    imgOne.src = sportsArray[randomImg()][randomImg()];
}

/**
 * randomClickImgTwo function - Randomizes img 2.
 */
function randomClickImgTwo() {
    let imgTwo = document.getElementById("imgTwo");
    imgTwo.src = sportsArray[randomImg()][randomImg()];
}

/**
 * randomClickImgThree function - Randomizes img 3.
 */
function randomClickImgThree() {
    let imgThree = document.getElementById("imgThree");
    imgThree.src = sportsArray[randomImg()][randomImg()];
}

/**
 * randomImg function - Calculations for getting a random image
 * from the sports array.
 * @returns random img from the sports array.
 */
function randomImg() {
    return Math.floor(Math.random() * sportsArray.length)
}

/**
 * randomizeButtonImg function - Restarts the count down timer,
 * randomizes 3 new images and adds 3 to the image counter.
 */
function randomizeButtonImg() {
    myImgCounter3();
    clearInterval(intervalId);
    myTimer();

    let imgOne = document.getElementById("imgOne");
    let imgTwo = document.getElementById("imgTwo");
    let imgThree = document.getElementById("imgThree");

    imgOne.src = sportsArray[randomImg()][randomImg()];
    imgTwo.src = sportsArray[randomImg()][randomImg()];
    imgThree.src = sportsArray[randomImg()][randomImg()];
}

/**
 * animation function - Everytime an image is clicked it does a
 * fade animation, while swithching to a new random image.
 */
function animation() {
    let imgOneAnimation = document.getElementById('imgOne');
    let imgTwoAnimation = document.getElementById('imgTwo');
    let imgThreeAnimation = document.getElementById('imgThree');
    
    // Img 1 - Animation after clicked.
    imgOneAnimation.addEventListener('click', function() {
        myImgCounter1();
        clearInterval(intervalId);
        myTimer();
        animationOne();
        randomClickImgOne();
    
    });

    // Img 2 - Animation after clicked.
    imgTwoAnimation.addEventListener('click', function() {
        myImgCounter1();
        clearInterval(intervalId);
        myTimer();
        animationTwo();
        randomClickImgTwo();
    
    });
    // Img 3 - Animation after clicked.
    imgThreeAnimation.addEventListener('click', function() {
        myImgCounter1();
        clearInterval(intervalId);
        myTimer();
        animationThree();
        randomClickImgThree();
    });  
}

/**
 * animationOne function - Adds the fade animation to image 1.
 */
function animationOne() {
    let img = document.getElementById("imgOne");
    img.classList.remove('faded');
    setTimeout( () => { img.classList.add('faded');}, 0);
}

/**
 * animationTwo function - Adds the fade animation to image 2.
 */
function animationTwo() {
    let img = document.getElementById("imgTwo");
    img.classList.remove('faded');
    setTimeout( () => { img.classList.add('faded');}, 0);
}

/**
 * animationThree function - Adds the fade animation to image 3.
 */
function animationThree() {
    let img = document.getElementById("imgThree");
    img.classList.remove('faded');
    setTimeout( () => { img.classList.add('faded');}, 0);
}
