/**
 * Caboose class is for creating a caboose train cart object
 *
 * Name: Braeden Lyman
 * Student ID: 000370695
 */

import java.util.Scanner;

public class Caboose extends AdminCar {
    /**
     * Caboose constructor displays the weight, amount
     * of wheels, and the total amount of staff on the
     * Caboose.
     * @param weight - weight of the caboose.
     */
    private Caboose (double weight){
        super("Caboose", weight, 4, 4);
    }

    /**
     * create method creates a Caboose object.
     */
    public static Caboose create() {
        Scanner scanner = new Scanner(System.in);
        System.out.print("Caboose Weight: ");
        double weight = scanner.nextDouble();
        double maxWeight = 200; // max engine weight
        double minWeight = 80; // min engine weight
        while (weight < minWeight || weight > maxWeight) {
            System.out.println("Try Again. Max Weight is 200 and Min Weight is 80.");
            weight = scanner.nextDouble();
        }

        return new Caboose(weight);
    }

    /**
     * toString method for displaying the Caboose as a string.
     * @return String displays the:
     */
    @Override
    public String toString() {
        return "|| Caboose: Weight - " + getWeight() + " || ";
    }
}
