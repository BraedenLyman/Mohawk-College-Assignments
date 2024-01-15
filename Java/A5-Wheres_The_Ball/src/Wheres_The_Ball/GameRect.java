package assignment5_000370695;

/**
 * This class is to create rectangle shapes using Fx Graphics to implement
 * into the file GameView.java.
 *
 * Class: GameRect.java (model class)
 * @author Braeden Lyman
 */

import javafx.scene.canvas.GraphicsContext;
import javafx.scene.paint.Color;

public class GameRect {
    /** Location on the X-axis **/
    private double x;

    /** Location on the y-axis **/
    private double y;

    /**
     * Constructor to determine rectangle locations.
     * @param x to determine the x-axis.
     * @param y to determine the y-axis.
     */
    public GameRect(double x, double y) {
        this.x = x;
        this.y = y;
    }

    /**
     * DrawRect method for drawing the rectangles.
     * @param gc draws the properties of each rectangle.
     */
    public void drawRect(GraphicsContext gc) {
        gc.setFill(Color.GREY);
        gc.fillRect(0,0,1050,600);
        gc.setFill(Color.CORAL);
        gc.fillRect(35, 300, 100,100);
        gc.fillRect(235, 300, 100,100);
        gc.fillRect(435, 300, 100,100);
        gc.setFill(Color.BLUEVIOLET);
        gc.fillRect(580,0,10,600);
    }
}