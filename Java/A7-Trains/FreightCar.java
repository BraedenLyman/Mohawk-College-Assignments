/**
 * FreightCar class is for creating a freight car train object.
 *
 * Name: Braeden Lyman
 * Student ID: 000370695
 */

import java.util.Scanner;

public class FreightCar extends TrainCar {
    /* Freight Train Type */
    private String type;

    /**
     * FreightCar constructor is used for displaying the name,
     * type and weight of the freight car.
     * @param name - name of the freight car.
     * @param type - type of freight car.
     * @param weight - weight of freight car
     */
    private FreightCar(String name, String type, double weight){
        super(name, weight, 4);
        this.type = type;
    }

    /**
     * create method creates a FreightCar object.
     *
     * @return new FreightCar object.
     */
    public static FreightCar create(){
        Scanner scanner = new Scanner(System.in);
        String name = "Freight Car";
        System.out.println(name);
        System.out.print("Enter Type of FreightCar: ");
        String type = scanner.nextLine();
        System.out.print("Enter Weight of Freight: ");
        double weight = scanner.nextInt();
        double maxWeight = 250; // max engine weight
        double minWeight = 50; // min engine weight
        while (weight < minWeight || weight > maxWeight) {
            System.out.println("Try Again. Max Weight is 200 and Min Weight is 50.");
            weight = scanner.nextDouble();
        }

        return new FreightCar(name, type, weight);
    }

    /**
     * getType method is for getting the type of freight car.
     * @return - type of freight car.
     */
    public String getType() {
        return type;
    }

    /**
     * toString method is used to display the FreightCar as a string.
     * @return - String.
     */
    @Override
    public String toString() {
        return "|| FreightCar: Type - " + getType() + "  | Weight - " + getWeight() + " || ";
    }
}
