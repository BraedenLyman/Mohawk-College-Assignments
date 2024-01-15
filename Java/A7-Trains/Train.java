/**
 * Train class is to create a train object where the user can add on however
 * many train cars they want to the train. Adding on a train car, they get the
 * choice of what car they want to add, then it prompts the create method for
 * that train car class the user selected.
 *
 * Name: Braeden Lyman
 * Student ID: 000370695
 */

import java.util.ArrayList;
import java.util.Scanner;

public class Train {
    /* Number of Cars */
    private int numCars;

    /* Train Name */
    private String name;

    /* TrainCar Object */
    private TrainCar trainCar = new TrainCar("",0,0);

    /* ArrayList for TrainCar */
    ArrayList<TrainCar> train = new ArrayList<>();

    /**
     * Train constructor displays a train object
     * with name and size of the train.
     * @param name - name of the train.
     * @param numCars - size of the train.
     */
    private Train(String name, int numCars){
        this.name = name;
        this.numCars = numCars;
    }

    /**
     * create method creates a Train object.
     *
     * @return Train
     */
    public static Train create() {
        Scanner scanner = new Scanner(System.in);

        System.out.print("Enter train Name: ");
        String name = scanner.nextLine();
        System.out.print("Enter number of cars: ");
        int numCars = scanner.nextInt();
        Train newTrain = new Train(name, numCars);

        while (true) {
            System.out.println("Which car would you like to add?: 1: Engine");
            int trainChoice = scanner.nextInt();
            if (trainChoice == 1) {
                newTrain.train.add(TrainEngine.create());
                break;
            } else {
                System.out.println("Invalid choice. Please choose the Engine as the first car.");
            }
        }
        for (int i = 1; i < numCars; i++) {
            System.out.println("Adding car " + (i + 1) + " of " + numCars);
            System.out.println("Which car would you like to add?: 2: FreightCar | 3: Caboose");
            int trainChoice = scanner.nextInt(); // User input for train choice.

            if (trainChoice == 2) {
                newTrain.train.add(FreightCar.create());
            } else if (trainChoice == 3) {
                newTrain.train.add(Caboose.create());
            } else {
                System.out.println("Invalid choice. Skipping this car.");
            }
        }
        System.out.println("Done adding");
        System.out.println(newTrain.train.toString());
        return newTrain;
    }

    /**
     * getTotalWeight method is for getting the total weight of the train.
     * @return totalWeight.
     */
    public double getTotalWeight(){
        double totalWeight = 0; // variable for totalWeight
        for (TrainCar car : train) {
            totalWeight += car.getWeight(); // gets the total weight of the train convoy
        }
        return totalWeight;
    }

    /**
     * getMaxAccel method is for getting the maximum acceleration for the train.
     * @return power / totalWeight or 0.
     */
    public double getMaxAccel() {
        double totalWeight = getTotalWeight();
        if (train.get(0) instanceof TrainEngine) {
            TrainEngine engine = (TrainEngine) train.get(0);
            double power = engine.getPower(); //gets power from the TrainEngine class
            return power / totalWeight; // power / totalWeight to get max acceleration of whole train
        } else {
            System.out.println("Train does not have an engine. Cannot calculate max acceleration.");
            return 0;
        }
    }

    /**
     * applyBreak method is for applying the train's breaks.
     *
     * @param brakes Train brakes
     * @return brakes
     */
    public double applyBreak(double brakes) {
        brakes = trainCar.brake(0.5);
        return brakes;
    }

    /**
     * toString method for displaying the train as a string.
     * @return String
     */
    @Override
    public String toString() {
        return "Train: Name - " + name + " | Number of Cars - " + numCars;
    }
}
