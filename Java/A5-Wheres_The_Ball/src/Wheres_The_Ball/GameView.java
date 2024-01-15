package assignment5_000370695;

/**
 * The purpose of this class is to simulate a ball guessing game,
 * where a user presses a button to guess which square the ball is under.
 * It also takes in the users name to display the rules on how to play the game.
 *
 * Class: GameView.java (view class)
 * @author Braeden Lyman
 */

import javafx.application.Application;
import javafx.event.ActionEvent;
import javafx.scene.Scene;
import javafx.scene.canvas.Canvas;
import javafx.scene.canvas.GraphicsContext;
import javafx.scene.control.Button;
import javafx.scene.control.Label;
import javafx.scene.control.TextField;
import javafx.scene.layout.Pane;
import javafx.scene.paint.Color;
import javafx.scene.text.Font;
import javafx.stage.Stage;

public class GameView extends Application {
    /** Draws the shapes **/
    private GraphicsContext gc;

    /** Declares a gameRect object **/
    private GameRect gameRect;

    /** Declares a gameBall object **/
    private GameBall gameBall;

    /** Win Label - if user wins **/
    private Label win;

    /** Loose Label - if user looses **/
    private Label loose;

    /** User Input TextField **/
    private TextField name;

    /** Displays User's Name  **/
    private Label displayName;

    /** Title of Game **/
    private Label title;

    /** Subtitle of game **/
    private Label subtitle;

    /** Submit Button after user enters name **/
    private Button submitName;

    /** Option Button Choices for User's to choose from **/
    private Button opt1, opt2, opt3, reset;

    /** Where user is to enter their name label **/
    private Label enterName;


    /**
     *  submitHandler for when user clicks on the Submit Name Button.
     * @param e displays a welcome message for user as well as the rules
     *          on how to play the game.
     */
    private void submitHandler(ActionEvent e) {
        String howToPlayMessage = "Welcome " + name.getText() + "! \n " + "\n" +
                                "How To Play: \n " + "\n" +
                                "1: Choose a square by clicking the button \n " +
                                "underneath your choice.\n" + "\n" +
                                "2: If you win, you will see a green circle in the box \n " +
                                "and you will see a message pop up saying \n 'You Won!'. \n " + "\n" +
                                "3: If you loose, you will see a red circle in the box \n " +
                                "and you will see a message pop up saying \n 'You Loose!'. \n" + "\n" +
                                "4: After each round, clear the game by \n " +
                                "clicking the Reset button. \n";
        displayName.setText(howToPlayMessage);
    }

    /**
     * draw helper method for drawing the objects from
     * gameRect class and gameBall class to the Canvas
     */
    private void draw() {
        gameRect.drawRect(gc);
        gameBall.drawGameBall(gc);
    }

    /**
     * opt1Handler handler for when user chooses the opt1 button.
     * Calls drawWin and drawLoose methods depending on the
     * outcome.
     * @param e displays a message and draws either drawWin
     *          or drawLoose method depending on the outcome.
     */
    private void opt1Handler (ActionEvent e) {
        if (gameBall.getRandomNum() == 0){
            win.setText("You Won!");
            gameBall.drawWinBall(gc);
        } else {
            loose.setText("You Loose!");
            gameBall.drawLooseBall(gc);
        }
    }

    /**
     * opt2Handler handler for when user chooses the opt2 button.
     * Calls drawWin and drawLoose methods depending on the
     * * outcome.
     * @param e displays a message and draws either drawWin
     *          or drawLoose method depending on the outcome.
     */
    private void opt2Handler (ActionEvent e) {
        if (gameBall.getRandomNum() == 1) {
            win.setText("You Won!");
            gameBall.drawWinBall(gc);
        }
        else {
            loose.setText("You Loose!");
            gameBall.drawLooseBall(gc);
        }
    }

    /**
     * opt3Handler handler for when user chooses the opt3 button.
     * Calls drawWin and drawLoose methods depending on the
     * outcome.
     * @param e displays a message and draws either drawWin
     *          or drawLoose method depending on the outcome.
     */
    private void opt3Handler (ActionEvent e) {
        if (gameBall.getRandomNum() == 2) {
            win.setText("You Won!");
            gameBall.drawWinBall(gc);
        } else {
            loose.setText("You Loose!");
            gameBall.drawLooseBall(gc);
        }
    }

    /**
     * resetHandler handler for when user chooses the reset button.
     * Calls the drawGameBall method to randomly draw a new circle in one
     * of the three squares.
     * @param e Resets the message displayed as well as resets the drawGameBall method
     *          by randomly selecting a new number from 0 and 2.
     */
    private void resetHandler (ActionEvent e) {
        win.setText("");
        loose.setText("");
        gameBall.drawGameBall(gc);
    }

    /**
     * This is where the components, model and events of the game are created.
     *
     * @param stage The main stage
     * @throws Exception
     */
    @Override
    public void start(Stage stage) throws Exception {
        Pane root = new Pane();
        Scene scene = new Scene(root, 1050, 600); // set the size here
        stage.setTitle("Where's The Ball Game"); // set the window title here
        stage.setScene(scene);

        // 1. The model
        /** Creates a new gameRect object **/
        gameRect = new GameRect(0, 0);

        /** Creates a new gameBall object **/
        gameBall = new GameBall(0,0);


        // 2. The GUI components
        /** Canvas component where the FX Graphics are displayed on **/
        Canvas canvas = new Canvas(1100, 600);


        /** Label component displays a title of the game **/
        title = new Label("Where's the Ball?");

        /** Label component displays a subtitle of the game **/
        subtitle = new Label("A fun guessing game by Braeden Lyman");


        /** Label component that displays where the user is to enter their name **/
        enterName = new Label("Enter your name below and click the Submit Name button to see how to play!");

        /** TextField component where user enters their name **/
        name = new TextField("");

        /** Button component where user presses after inputting name **/
        submitName = new Button("Submit Name");

        /** Label component that outputs users name entered with howToPlay message **/
        displayName = new Label("");


        /** Button component Option 1 for user to choose from **/
        opt1 = new Button("Option 1");

        /** Button component Option 2 for user to choose from **/
        opt2 = new Button("Option 2");

        /** Button component Option 3 for user to choose from **/
        opt3 = new Button("Option 3");

        /** Button component Reset for user to choose from **/
        reset = new Button("Reset");


        /** Label component that displays if user won **/
        win= new Label("");

        /** Label component that displays if user lost **/
        loose = new Label("");


        // 3. Components added to the root
        /**
         * root that displays the components to the scene.
         */
        root.getChildren().addAll(  canvas, opt1, opt2, opt3,
                                    reset, win, loose, title,
                                    subtitle, name, submitName,
                                    displayName, enterName);


        // 4. Component configuration (colors, fonts, size, location)

        opt1.relocate(50, 410);                   // Relocate Option 1 Button
        opt2.relocate(250, 410);                  // Relocate Option 2 Button
        opt3.relocate(450,410);                   // Relocate Option 3 Button
        reset.relocate(257, 470);                 // Relocate Reset Button

        win.relocate(225, 200);                   // Relocate Win Label
        win.setFont(new Font(30));                 // Setting font size for Win Label
        win.setTextFill(Color.GREEN);                   // Setting font color for Win Label

        loose.relocate(220, 200);                 // Relocate Loose Label
        loose.setFont(new Font(30));               // Setting font size for Loose Label
        loose.setTextFill(Color.RED);                   // Setting font color for Loose Label

        title.relocate(170, 20);                  // Relocate Title Label
        title.setFont(new Font(30));               // Setting font size for Title Label
        subtitle.relocate(160,60);                // Relocate Subtitle Label
        subtitle.setFont(new Font(14));            // Setting font size for Subtitle Label

        enterName.relocate(15,90);                // Relocate enterName Label
        enterName.setFont(new Font(16));           // Setting font size for enterName Label
        name.relocate(160, 120);                  // Relocate Name TextField
        name.requestFocus();                            // RequestFocus Method for Name TextField
        submitName.relocate(320, 120);            // Relocate submitName Button
        displayName.relocate(600,40);             // Relocate displayName Label
        displayName.setFont(new Font(20));         // Setting font size for displayName


        // 5. Event Handlers and Final setup
        gc = canvas.getGraphicsContext2D();             // FX Graphics to be drawn on Canvas
        draw();                                         // Draw Method
        opt1.setOnAction(this::opt1Handler);            // Option 1 Button - Event Handler
        opt2.setOnAction(this::opt2Handler);            // Option 2 Button - Event Handler
        opt3.setOnAction(this::opt3Handler);            // Option 3 Button - Event Handler
        reset.setOnAction(this::resetHandler);          // Reset Button - Event Handler
        submitName.setOnAction(this::submitHandler);    // submitName Button - Event Handler

        // 6. Stage Show
        /**
         * Shows the stage
         */
        stage.show();
    }

    /**
     * Launches GameView application
     *
     * @param args unused
     */
    public static void main(String[] args) {
        launch(args);
    }
}