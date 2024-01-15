package assignment3_000370695;
/**
 * The purpose of this document is to create the main body of
 * a Player that calls the Head and Wheel classes to add onto the
 * players body.
 *
 * This is document 3/5
 * @author: Braeden Lyman
 */

import javafx.scene.canvas.GraphicsContext;
import javafx.scene.paint.Color;

public class Player {
    /** x-axis location for player/ref **/
    private double x;
    /** y-axis location of player/ref **/
    private double y;
    /** Player win percentage **/
    private int average;

    /** Player color **/
    private Color color;

    /** Name of player/ref **/
    private String title;

    /** For calling the Head Class**/
    private Head head;

    /** For calling the Wheel Class - Left Wheel **/
    private Wheel lWheel;

    /** For calling the Wheel Class - Right Wheel **/
    private Wheel rWheel;

    /**
     * Player Constructor
     * @param x x-axis location of player
     * @param y y-axis location of player
     * @param color - what color the player is
     */
    public Player(double x, double y, Color color) {
        this.x = x;
        this.y = y;
        this.color = color;
        this.title = "";
        this.average = (int)(Math.random()*100);
        this.head = new Head(x + 14, y - 40);
        this.lWheel = new Wheel(x - 10, y + 30);
        this.rWheel = new Wheel(x + 60, y + 30);
    }

    /**
     *  Referee Constructor
     * @param x - x-axis location of ref
     * @param y - y-axis location of ref
     * @param color - color of the ref
     * @param title - Name of the ref
     */
    public Player(double x, double y, Color color, String title) {
        this.x = x;
        this.y = y;
        this.color = color;
        this.title = title;
        this.average = 100;
        this.head = new Head(x + 14.0, y - 40.0);
        this.lWheel = new Wheel(x - 10.0, y + 30.0);
        this.rWheel = new Wheel(x + 60.0, y + 30.0);
    }

    /**
     * Player Draw Method - Creates player's body and calls Head and Wheel Draw Methods
     * @param gc - draws out the player calling the head and wheel classes
     */
    public void draw(GraphicsContext gc) {
        gc.setFill(color);
        gc.fillOval(x, y, 70, 70);
        gc.strokeText(String.valueOf(this.average), x+30, y+30,50);
        gc.strokeText(this.title,x,y+100, 50);
        head.draw(gc);
        lWheel.draw(gc);
        rWheel.draw(gc);
    }

    /**
     * Method for getting Team Average - Refer to Team Class
     * @return - average win percentage of team
     */
    public int getAverage() {
        return average;
    }
}
