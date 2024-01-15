package assignment3_000370695;
/**
 * The purpose of this document is to assign three players that have been created using the draw
 * methods to a team.
 *
 * This is document 4/5
 * @author: Braeden Lyman
 */

import javafx.scene.canvas.GraphicsContext;
import javafx.scene.paint.Color;
import java.util.Random;

public class Team {
    /** Location of the Team on the X-axis **/
    private double x;

    /** Location of the Team on the Y-axis **/
    private double y;

    /** Naming the Team **/
    private String name;

    /** Defining the Players that consist inside the Team **/
    private Player p1, p2, p3;

    /** For finding Team's Average Win percentage **/
    private int average;

    /**
     *  Team Constructor
     * @param name - Name of team
     * @param x - x-axis location where the team starts
     * @param y - y-axis location of where the team starts
     * @param color - Color of the team
     */
    public Team (String name, double x, double y, Color color) {
        this.name = name;
        this.x = x;
        this.y = y;
        this.p1 = new Player(x, y + 10, color);
        this.p2 = new Player(x + 100, y + 10, color);
        this.p3 = new Player(x + 200, y + 10, color);

        // Calculations for getting teams average
        this.average = p1.getAverage() + p2.getAverage() + p3.getAverage();
        this.average = this.average / 3;
    }

    /**
     * Draw method for drawing the players out on a canvas with a text underneath showing the team's average
     * @param gc Draws the players for each team
     */
    public void draw (GraphicsContext gc) {
        p1.draw(gc);
        p2.draw(gc);
        p3.draw(gc);
        gc.strokeText(this.name,x,y+100);
        gc.strokeText("( Team Average: " + this.average + ")" ,x+100, y+100, 200);
    }
}