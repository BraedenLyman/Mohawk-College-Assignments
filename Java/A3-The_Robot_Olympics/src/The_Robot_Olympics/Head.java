package assignment3_000370695;
/**
 * The purpose of this document is to create a Head class for
 * a player.
 *
 * This is document 1/5
 * @author: Braeden Lyman
 */

import javafx.scene.canvas.GraphicsContext;
import javafx.scene.paint.Color;

public class Head {
    /** x-axis location of the head **/
    private double x;

    /** y-location of the head **/
    private double y;

    /**
     *  Defining the location of the head
     * @param x - x-axis location for the head
     * @param y - y-axis location for the head
     */
    public Head(double x, double y) {
        this.x = x;
        this.y = y;
    }

    /**
     *  Drawing out the Head
     * @param gc - Draws out the head
     */
    public void draw (GraphicsContext gc) {
        //Player - Head & Neck
        gc.setFill(Color.BLACK);
        gc.strokeRect(x, y, 40, 30);
        gc.fillOval(x +10, y + 15, 5,5);
        gc.fillOval(x + 24, y + 15, 5,5);
        gc.fillRect(x + 15, y + 30, 10, 10);
    }
}