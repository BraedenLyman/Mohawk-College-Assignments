package assignment1_000370695;
import java.util.Scanner;
import javafx.application.Application;
import javafx.scene.Group;
import javafx.scene.Scene;
import javafx.scene.canvas.Canvas;
import javafx.scene.canvas.GraphicsContext;
import javafx.stage.Stage;
import static javafx.application.Application.launch;

/**
 * This program is about creating the main elements of the game Arkanoid.
 * The games' elements have a paddle, ball and bricks on one side
 * and on the other side it displays the current score, high-score, and wave.
 * This program was created on May 18th, 2023.
 * @author Braeden Lyman 000370695
 **/

public class BraedenArk extends Application
{

    /**
     * @param stage The FX stage to draw on
     **/

    @Override
    public void start(Stage stage) {
        Group root = new Group();
        Scene scene = new Scene(root);
        Canvas canvas = new Canvas(1200, 800); // Set canvas Size in Pixels
        stage.setTitle("Braeden's Arkanoid"); // Set window title
        root.getChildren().add(canvas);
        stage.setScene(scene);
        GraphicsContext gc = canvas.getGraphicsContext2D();

        // CODE STARTS HERE
        Scanner input = new Scanner(System.in);

        // User Input - Defines Brick Columns
        int col = 0;
        while (col < 1 || col > 8) { // while loop for making sure user enters valid input
            System.out.print("How many columns of bricks would you like? (Choose a number between 1 & 8): ");
            col = input.nextInt(); // user input
            if (col < 1 || col > 8){ // if statement for invalid input
                System.out.println("Invalid input. Please choose another number between 1 & 8): ");
            }
        }

        // User Input - Defines Brick Rows
        int row = 0;
        while (row < 1 || row > 20 ) { // while loop for making sure user enters valid input
            System.out.print("How many rows of bricks would you like? (Choose a number between 1 & 20): ");
            row = input.nextInt(); // user input
            if (row < 1 || row > 20){ // if statement for invalid input
                System.out.println("Invalid input. Please choose another number between 1 & 20: " );
            }
        }

        // Brick Grid (col & row) - Calculations
        int tempCol = col * 100; // calculation for simplifying user input for columns
        int tempRow = row * 20; // calculation for simplifying user input for rows

        // Brick Grid - Columns and Rows
        for (int columns = 1; columns < tempCol; columns += 100) // in-bedded for-loop
            for (int rows1 = 20; rows1 <= tempRow; rows1 += 20) {
                gc.fillRect(columns, rows1, 98, 19); // displays grid of columns and rows from in-bedded for-loop above
            }

        // User Input - Current Score Information
        System.out.print("What would you like for your current score? : ");
        gc.fillText("Score",820, 40); // score title
        int currentScore = input.nextInt(); // user input
        String currentScoreString = Integer.toString(currentScore); // conversion of currentScore to a string for displaying in the console
        gc.fillText(currentScoreString, 820, 60); // displays current score in the console

        // User Input - High Score Information
        System.out.print("What would you like the high score to be?: ");
        gc.fillText("High Score", 820, 100); // high score title
        int highScore = input.nextInt(); // user input
        String highScoreString = Integer.toString(highScore); // conversion of highScore to a string for displaying in the console
        if (currentScore > highScore){ // if statement calculates if currentScore is larger than highScore then display high score as current score
            gc.fillText(currentScoreString, 820, 120);
        } else {

            gc.fillText(highScoreString, 820, 120);
        }

        // User Input - Wave Information
        int wave = 0;
        while (wave < 1 || wave > 20) { // while loop for making sure user enters valid input
            System.out.print("What wave would you like to start on? (Choose a number between 1 & 20): ");
            wave = input.nextInt(); // user input
            if (wave < 1 || wave > 20){ //if statement for invalid input
                System.out.println("Invalid input. Please choose another number between 1 & 20: ");
            }
        }
        gc.fillText("Wave", 820, 160); // wave title
        String WaveString = Integer.toString(wave); // conversion of integer wave to a string for displaying in the console
        gc.fillText(WaveString, 820, 180); // displays what wave user is on

        // User Input - Ball & Ball Start Location Information
        int ballStart = 0;
        while (ballStart < 1 || ballStart > 700) { // while loop for making sure user enters valid input
            System.out.print("Where would you like the ball to start?: (Choose a number between 1 & 700) ");
            ballStart = input.nextInt(); // user input
            if (ballStart < 1 || ballStart > 700){ // if statement for invalid input
                System.out.println("Invalid Input. Please choose a number between 1 & 700: ");
            }
        }
        gc.fillOval(ballStart,700, 20, 20); // where the ball will start

        // User Input - Paddle & Paddle Start Location Information
        int paddleStart = 0;
        while (paddleStart < 1 || paddleStart > 700){ // while loop for making sure user enters valid input
            System.out.print("Where would you like the paddle to start? (Choose a number between 1 & 700) ");
            paddleStart = input.nextInt(); // user input
            if (paddleStart < 1 || paddleStart > 700){ // if statement for invalid input
                System.out.println("Invalid Input. Please choose a number between 1 & 700: ");
            }
        }
        gc.fillRect(paddleStart, 750, 50, 10); // where the paddle will start

        // Grid Separation
        gc.fillRect(800, 0, 10, 800); // separates game from score


        // CODE STOPS HERE
        stage.show();
    }

    /**
     * The actual main method that launches the app.
     *
     * @param args unused
     */
    public static void main(String[] args) {
        launch(args);
    }
}