/**
 * AdminCar class is for creating an Admin Car object.
 *
 * Name: Braeden Lyman
 * Student ID: 000370695
 */
public class AdminCar extends TrainCar {
    /* Total Staff on the AdminCar */
    private int totalStaff;

    /**
     * AdminCar constructor for displaying the name,
     * weight, amount of wheels, and total amount
     * of staff on the AdminCar.
     * @param name - name of the admin car.
     * @param weight - weight of the admin car.
     * @param wheels - amount of wheels the admin car has.
     * @param totalStaff - total amount of staff the admin car has.
     */
    public AdminCar(String name, double weight, int wheels, int totalStaff) {
        super(name, weight, wheels);
        this.totalStaff = totalStaff;
    }

    /**
     * toString method is for displaying the AdminCar as a string.
     * @return - String displays the:
     */
    @Override
    public String toString() {
        return "AdminCar: " + totalStaff;
    }
}
