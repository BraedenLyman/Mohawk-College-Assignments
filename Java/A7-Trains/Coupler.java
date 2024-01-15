/**
 * Coupler interface is for checking to see if all brakes
 * have been applied on the train.
 *
 * Name: Braeden Lyman
 * Student ID: 000370695
 */
public interface Coupler {
    /**
     * brake method for checking to see if the
     * brakes have been applied.
     * @param b brake number between 0 and 1 applied
     * @return brakes applied, or brakes not applied.
     */
    double brake(double b);
}
