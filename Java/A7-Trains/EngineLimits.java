/**
 * EngineLimits interface is for checking the engine limitations.
 *
 * Name: Braeden Lyman
 * Student ID: 000370695
 */
public interface EngineLimits {
    /**
     * getMaxAccel method is for getting maxAccel in TrainEngine class.
     * @param weight of the train.
     * @return maxAcceleration of the train.
     */
    public double getMaxAccel(double weight);

    /**
     * getMaxSpeed method is for getting the maxSpeed of the train.
     * @return max speed
     */
    public double getMaxSpeed();
}

