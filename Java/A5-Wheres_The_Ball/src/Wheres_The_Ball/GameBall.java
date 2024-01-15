package assignment5_000370695;

/**
 * This class is to create circle shapes using Fx Graphics to implement
 * into the file GameView.java.
 *
 * Class: GameBall.java (model class)
 * @author Braeden Lyman
 */

import javafx.scene.canvas.GraphicsContext;
import javafx.scene.paint.Color;

public class GameBall {
    /** Location on the x-axis **/
    private double x;

    /** Location on the y-axis **/
    private double y;

    /** Randomly generated number **/
    private int randomNum;

    /**
     * Constructor to determine circle locations.
     * @param x to determine the x-axis
     * @param y to determine the y-axis
     */
    public GameBall(double x, double y) {
        this.x = x;
        this.y = y;
    }

    /**
     * Getter method for getting access to the randomNum variable.
     * @return random number between 0 and 2.
     */
    public int getRandomNum() {
        return randomNum;
    }

    /**
     * drawGameBall method for drawing certain circles depending on the
     * random number.
     * @param gc draws the properties of each circle.
     */
    public void drawGameBall(GraphicsContext gc) {
        this.randomNum = (int)(Math.random()*3); // Calculates a random number between 0 and 2

        switch (this.randomNum) { // switch case to draw certain circles depending on the random generated number
            case 0:
                gc.setFill(Color.BLACK);
                gc.fillOval(60, 325, 50, 50);

                gc.setFill(Color.BLACK);
                gc.fillOval(260, 325, 50, 50);

                gc.setFill(Color.BLACK);
                gc.fillOval(460, 325, 50, 50);
                break;
            case 1:
                gc.setFill(Color.BLACK);
                gc.fillOval(260, 325, 50, 50);

                gc.setFill(Color.BLACK);
                gc.fillOval(60, 325, 50, 50);

                gc.setFill(Color.BLACK);
                gc.fillOval(460, 325, 50, 50);

                break;
            case 2:
                gc.setFill(Color.BLACK);
                gc.fillOval(460, 325, 50, 50);

                gc.setFill(Color.BLACK);
                gc.fillOval(60, 325, 50, 50);

                gc.setFill(Color.BLACK);
                gc.fillOval(260, 325, 50, 50);
                break;
        }
    }

    /**
     * drawWinBall method for drawing certain circles depending on users choice.
     * @param gc draws the properties of a circle if users option is correct
     */
    public void drawWinBall(GraphicsContext gc) {
        int winNum = this.getRandomNum(); // winNum holds random calculated numbers from 0 and 2

        switch (winNum) { // switch case to draw certain circles if users option is correct
            case 0:
                gc.setFill(Color.GREEN);
                gc.fillOval(60, 325, 50, 50);
                break;
            case 1:
                gc.setFill(Color.GREEN);
                gc.fillOval(260, 325, 50, 50);
                break;
            case 2:
                gc.setFill(Color.GREEN);
                gc.fillOval(460, 325, 50, 50);
                break;
        }
    }

    /**
     * drawLooseBall method for drawing certain circles depending on users choice.
     * @param gc draws the properties of a circle if users option is incorrect
     */
    public void drawLooseBall(GraphicsContext gc) {
        int looseNum = this.getRandomNum(); // looseNum holds random calculated numbers from 0 and 2

        switch (looseNum) { //// switch case to draw certain circles if users option is incorrect
            case 0:
                gc.setFill(Color.RED);
                gc.fillOval(60, 325, 50, 50);
                break;
            case 1:
                gc.setFill(Color.RED);
                gc.fillOval(260, 325, 50, 50);
                break;
            case 2:
                gc.setFill(Color.RED);
                gc.fillOval(460, 325, 50, 50);
                break;
        }
    }
}