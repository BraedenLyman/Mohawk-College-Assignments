
/**
 * TestClass class is for testing the methods for the train
 * weight and max acceleration.
 *
 * Name: Braeden Lyman
 * Student ID: 000370695
 */

public class TestClass {
    public static void main(String[] args) {
        Train t = Train.create();
        t.applyBreak(0.5);
        System.out.printf("Maxiumum Acceleration: $%.2f\n",
                t.getMaxAccel());
        if (t.getMaxAccel() < 0.1)
            System.out.println("** Warning: Train is too heavy.");

            }
        }
