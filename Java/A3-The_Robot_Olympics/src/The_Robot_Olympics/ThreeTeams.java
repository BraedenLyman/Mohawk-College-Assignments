package assignment3_000370695;
/**
 * The purpose of this document is to display the Robotic Olympics to a canvas with three teams
 * that consist of three players on each team. It also displays a referee that's a player
 * chosen randomly from one of the three teams.
 *
 * This is document 5/5
 * @author: Braeden Lyman
 */

import javafx.application.Application;
import javafx.scene.Group;
import javafx.scene.Scene;
import javafx.scene.canvas.Canvas;
import javafx.scene.canvas.GraphicsContext;
import javafx.scene.paint.Color;
import javafx.scene.shape.Circle;
import javafx.stage.Stage;
import java.awt.*;
import java.util.Random;
import static javafx.application.Application.launch;


public class ThreeTeams extends Application {

    @Override
    public void start(Stage stage) throws Exception {
        Group root = new Group();
        Scene scene = new Scene(root);
        Canvas canvas = new Canvas(800, 600); // Set canvas Size in Pixels
        stage.setTitle("Robotic Olympics"); // Set window title
        root.getChildren().add(canvas);
        stage.setScene(scene);
        GraphicsContext gc = canvas.getGraphicsContext2D();

        /**
         * Creating three teams and drawing them
         */
        Team t1 = new Team("Team Shweet", 25, 65, Color.CORAL);
        t1.draw(gc);
        Team t2 = new Team("Team Gotti",25,265, Color.BLUEVIOLET);
        t2.draw(gc);
        Team t3 = new Team("Team Heck Yeah", 25, 465, Color.AQUA);
        t3.draw(gc);

        /**
         * Creating a randomizer with three options to create a referee object based on the switch case
         */
        Random random = new Random();
        int randomNum = random.nextInt(3) + 1;

        //Switch for choosing the referee randomly
        switch(randomNum) {
            case 1:
                if (randomNum ==1) {
                    Player ref1 = new Player(600, 275, Color.CORAL,"Ref Shweet");
                    ref1.draw(gc);
                }
                break;
            case 2:
                if (randomNum ==2) {
                    Player ref2 = new Player(600, 275, Color.BLUEVIOLET,"Ref Gotti");
                    ref2.draw(gc);
                }
                break;
            case 3:
                if (randomNum == 3) {
                    Player ref3 = new Player(600, 275, Color.AQUA,"Ref Heck Yeah");
                    ref3.draw(gc);
                }
                break;
        }

        stage.show();
    }

    /**
     *  Launches the program of the three teams and a random ref
     * @param args launches the program
     */
    public static void main(String[] args) {
        launch(args);
    }
}
