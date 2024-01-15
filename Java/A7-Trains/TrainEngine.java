/**
 * TrainEngine class is for creating a train engine object.
 *
 * Name: Braeden Lyman
 * Student ID: 000370695
 */

import java.util.Scanner;

public class TrainEngine extends AdminCar implements EngineLimits {
    /* Description of the Train Engine */
    private String description;

    /* Train Engine Power*/
    private double power;

    /**
     * TrainEngine constructor displays the name, description,
     * weight, amount of wheels and the amount of power the
     * TraineEngine has.
     * @param name - name of the train engine.
     * @param description - description of the train engine.
     * @param weight - weight of the train engine.
     * @param wheels - amount of wheels the train engine has.
     * @param power - amount of power the train engine has.
     */
    private TrainEngine( String name, String description, double weight, int wheels, double power) {
        super(name, weight, wheels, 4);
        this.description = description;
        this.power = power;
    }

    /**
     * create method creates a TrainEngine object.
     *
     * @return trainEngine.
     */
    public static TrainEngine create() {
        Scanner scanner = new Scanner(System.in);
        String name = "Engine";
        System.out.println(name);
        System.out.print("Enter Engine description: ");
        String description = scanner.nextLine();
        System.out.print("Engine Car Weight: ");
        double weight = scanner.nextDouble();
        double maxWeight = 250; // max engine weight
        double minWeight = 100; // min engine weight
        while (weight < minWeight || weight > maxWeight) {
            System.out.println("Try Again. Max Weight is 250 and Min Weight is 100.");
            weight = scanner.nextDouble();
        }
        System.out.print("How many Wheels: ");
        int wheels = scanner.nextInt();
        int minWheels = 4; // min engine wheels
        int maxWheels = 10; // max engine wheels
        while (wheels < minWheels || wheels > maxWheels) {
            System.out.println("Try Again. Min Wheels is 4 and Max Wheels is 10.");
            wheels = scanner.nextInt();
        }
        System.out.print("How much power: ");
        double power = scanner.nextDouble();
        double minPower = 600; // min engine power
        double maxPower = 3000; // max engine power
        while (power < minPower || power > maxPower) {
            System.out.println("Try Again. Max Power is 3000 and Min Power is 600.");
            power = scanner.nextDouble();
        }
        return new TrainEngine(name, description, weight, wheels, power);
    }

    /**
     * getDescription method gets the description
     * of the train engine.
     * @return description of the train engine.
     */
    public String getDescription() {
        return description;
    }

    /**
     * getPower method gets power from TrainEngine.
     * @return power from train engine.
     */
    public double getPower() {
        return power;
    }

    /**
     * getMaxAccel gets the maximum acceleration
     * of the train engine.
     * @param weight - weight of the train.
     * @return - weight / by power.
     */
    public double getMaxAccel(double weight) {
        return this.power /  weight;
    }

    /**
     * getMaxSpeed method gets the maximum speed
     * of the train engine.
     * @return  max speed.
     */
    @Override
    public double getMaxSpeed() {
        return 100; // Maximum 100km/hr
    }

    /**
     * toString method for displaying the TrainEngine
     * as a string.
     * @return String.
     */
    @Override
    public String toString() {
        return "|| TrainEngine: Power - " + this.power + " | Description - " + getDescription() + " | Weight - " + getWeight() + " || ";
    }
}
