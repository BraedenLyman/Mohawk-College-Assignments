package assignment3_000370695;
/**
 * The purpose of this document is to create a Wheel class for
 * a player.
 *
 * This is document 2/5
 * @author: Braeden Lyman
 */

import javafx.scene.canvas.GraphicsContext;
import javafx.scene.paint.Color;

public class Wheel {
    /** x-axis location of wheel **/
    private double x;

    /** y-axis location of wheel **/
    private double y;

    /**
     *  Defining the location of the wheels
     * @param x - x-axis location of the wheels
     * @param y - y-axis location of the wheels
     */
    public Wheel (double x, double y) {
        this.x = x;
        this.y = y;
    }

    /**
     * Drawing out the left wheel and right wheel
     * @param gc Draws the left and right wheels
     */
    public void draw (GraphicsContext gc) {
        // Player - Wheels
        gc.setFill(Color.BLACK);
        gc.fillOval(x, y, 20, 40);
        gc.fillOval(x, y, 20, 40);
    }
}