/**
 * TrainCar class is for creating a train car that can be either a freight
 * car, caboose car, or train engine.
 *
 * Name: Braeden Lyman
 * Student ID: 000370695
 */
public class TrainCar implements Coupler{
    /* Train Car Name */
    private String name;

    /* Train Car Weight */
    private double weight;

    /* Train Car Wheels */
    private int wheels;

    /**
     * TrainCar constructor is used to display a train cars name, weight
     * and number of wheels.
     * @param name - name of the train car.
     * @param weight - how much the train car weighs.
     * @param wheels - number of wheels train car has.
     */
    public TrainCar(String name, double weight, int wheels) {
        this.name = name;
        this.weight = weight;
        this.wheels = wheels;
    }

    /**
     * getName method gets the name of the train.
     * @return name of the train.
     */
    public String getName() {
        return name;
    }

    /**
     * getWeight method gets the weight of a train.
     * @return  weight of the train.
     */
    public double getWeight() {
        return weight;
    }

    /**
     * brake method displays if the brakes have been applied or not.
     * @param b brakes on the train.
     */
    @Override
    public double brake(double b) {
        if (b > 0 && b < 1) {
            System.out.println("Brakes Applied");
        } else {
            System.out.println("Breaks NOT Applied!");
        }
        return b;
    }

    /**
     * toString method displays the train car as a string.
     * @return string.
     */
    @Override
    public String toString() {
        return "TrainCar: Name - " + name + " | Weight - " + weight + " | Wheels - " + wheels;
    }
}
