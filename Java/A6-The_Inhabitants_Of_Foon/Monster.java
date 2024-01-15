package assignment6_000370695;
/**
 * This document is to create a monster class that has attributes
 * and abilities that all monsters have. This class represent the
 * super class.
 *
 * Class Name: Monster.java
 * Name: Braeden Lyman
 * Student ID: 000370695
 * Date: July 20th, 2023.
 */

abstract class Monster {
    /** Clan Affiliation **/
    public String clanAffiliation;

    /** Ferocity Attribute **/
    public int ferocity;

    /** Increase Ferocity Points **/
    public int increaseFerocity;

    /** Decrease Ferocity Points **/
    public int decreaseFerocity;

    /** Defence Attribute **/
    public int defence;

    /** Increase Defence Points **/
    public int increaseDefence;

    /** Decrease Defence Points **/
    public int decreaseDefence;

    /** Magic Attribute **/
    public int magic;

    /** Increase Magic Points **/
    public int  increaseMagic;

    /** Decrease Magic Points **/
    public int decreaseMagic;

    /** Treasure **/
    private int treasure;

    /** Health **/
    private  int health;


    /**
     * Monster constructor sets clanAffiliation then fills in default values
     * for all other attributes.
     * @param clanAffiliation indicates which clan a monster is from.
     */
    Monster(String clanAffiliation) {
        this.clanAffiliation = clanAffiliation;
        this.ferocity = 10;
        this.defence = 10;
        this.magic = 10;
        this.treasure = 10;
        this.health = 100;
    }

    /**
     *  Monster constructor sets all instance variables for user to choose what
     *  variables they want.
     * @param clanAffiliation indicates which clan a monster is from.
     * @param ferocity indicates how much ferocity points a monster has.
     * @param defence indicates how many defence points a monster has.
     * @param magic indiciates how many magic points a monster has.
     * @param treasure indicates how much treasure a monster has.
     * @param health indicates how much health a monster has.
     */
    Monster(String clanAffiliation, int ferocity, int defence, int magic, int treasure, int health) {
        this.clanAffiliation = clanAffiliation;
        this.ferocity = ferocity;
        this.defence = defence;
        this.magic = magic;
        this.treasure = treasure;
        this.health = health;

        if (ferocity < 0 || ferocity > 20){ System.out.println("Ferocity is to be between 0 and 20"); this.ferocity = 0;} // If statement to display if number is above 20 and below 0. Resets to 0.
        if (defence < 0 || defence > 20){ System.out.println("Defence is to be between 0 and 20"); this.defence = 0;} // If statement to display if number is above 20 and below 0. Resets to 0.
        if (magic < 0 || magic > 20){ System.out.println("Magic is to be between 0 and 20"); this.magic = 0;} // If statement to display if number is above 20 and below 0. Resets to 0.
        if (treasure < 0){ System.out.println("Treasure is to be above 0"); this.treasure = 0;} // If statement to display if number is below 0. Resets to 0.
    }

    /**
     * Increases the ferocity points by one each time.
     *  Only allowed between 0 and 20.
     * @return ferocity + 1.
     */
    public int setIncreaseFerocity() {
        if (this.ferocity > 0 && this.ferocity < 20) {
            increaseFerocity = this.ferocity += 1;
        } else {
            increaseFerocity = 0;
        }
        return increaseFerocity;
    }

    /**
     * Decreases the ferocity points by one each time.
     * Only allowed between 0 and 20.
     * @return ferocity - 1.
     */
    public int setDecreaseFerocity() {
        if (this.ferocity > 0 && this.ferocity < 20) {
            decreaseFerocity = this.ferocity -= 1;
        } else {
            decreaseFerocity = 0;
        }
        return decreaseFerocity;
    }

    /**
     * Increase the defence points by one each time.
     * Only allowed between 0 and 20.
     * @return defence + 1.
     */
    public int setIncreaseDefence() {
        if (this.defence > 0 && this.defence < 20) {
            increaseDefence = this.defence += 1;
        } else {
            increaseDefence = 0;
        }
        return increaseDefence;
    }

    /**
     * Decreases the defence points by one each time.
     * Only allowed between 0 and 20.
     * @return defence - 1.
     */
    public int setDecreaseDefence() {
        if (this.defence > 0 && this.defence < 20) {
            decreaseDefence = this.defence -= 1;
        } else {
            decreaseDefence = 0;
        }
        return decreaseDefence;
    }

    /**
     * Increase the magic points by one each time.
     * Only allowed between 0 and 20.
     * @return magic + 1.
     */
    public int setIncreaseMagic() {
        if (this.magic > 0 && this.magic < 20) {
            increaseMagic = this.magic += 1;
        } else {
            increaseMagic = 0;
        }
        return increaseMagic;
    }

    /**
     * Decreases the magic points by one each time.
     * Only allowed between 0 and 20.
     * @return magic - 1.
     */
    public int setDecreaseMagic() {
        if (this.magic > 0 && this.magic < 20) {
            decreaseMagic = this.magic -= 1;
        } else {
            decreaseMagic = 0;
        }
        return decreaseMagic;
    }

    /**
     * Increases health by a certain amount.
     * @param amount of health to be applied.
     */
    public void setIncreaseHealth(int amount) {
        if (this.health > 0) {
            this.health += amount;
        }
    }

    /**
     * Decreases health by a certain amount.
     * @param amount of health to be subtracted.
     */
    public void setDecreaseHealth(int amount) {
        if (this.health > 0) {
            this.health -= amount;
            if (this.health < 0) {
                this.health = 0;
            }
        }
    }

    /**
     * isAlive Method for checking if monster is alive or not.
     * @return  boolean value true if Monster is alive or false
     * if monster is dead each with a printout statement.
     */
    public boolean isAlive() {
        boolean isAlive; // To check if monster is alive or not.
        if (getHealth() > 0) {
            System.out.println("Monster is Alive.");
            isAlive = true;
        } else {
            System.out.println("Monster is Dead.");
            isAlive = false;
        }
        return isAlive;
    }

    /**
     *  attack Method is for when a monster is attacking another monster.
     * @param opponent is the opponent a monster is attacking
     * @return difference in the monster's and opponent's attackScore
     * that displays a certain outcome based on what happens.
     */
    public double attack(Monster opponent) {
        double difference = getAttackScore() - opponent.getAttackScore(); // difference for calculating if the opponent or the monster attacking looses points.
        if (getHealth() > 0) {
            if (opponent.getHealth() > 0) {
                opponent.getAttackScore();
                difference = getAttackScore() - opponent.getAttackScore();
                if (difference > 0) {
                    opponent.setDecreaseHealth((int) difference);
                    if (opponent.getHealth() <= 0) {
                        setTreasure(getTreasure()  + opponent.getTreasure()); // If opponent dies, treasure goes to the monster attacking.
                        opponent.setTreasure(0); // If opponent dies, they have 0 treasure.
                    }
                } else {
                    setDecreaseHealth((int) Math.abs(difference));
                    if (getHealth() <= 0) {
                        opponent.setTreasure(getTreasure()); // If monster attacking dies, opponent gets the monster's treasure.
                        setTreasure(0); // If monster attacking dies, they have 0 treasure.
                    }
                }
            } else {
                System.out.println("Cannot Attack! Opponent is already dead.");
            }
        } else {
            System.out.println("Cannot Attack. I am dead.");
        }
        return difference;
    }

    /**
     * getAttackScore Method is for calculating the amount of which a monster attacks with
     * based on their ferocity, defence, and magic.
     * @return the average of ferocity, defence and magic as a double.
     */
    public double getAttackScore() {
        return (double) (this.ferocity + this.defence + this.magic) / 3;
    }

    /**
     * getDefence Method is for when a monster is defending themselves from
     * an attack.
     * @return shows how many defence points a monster is defending with.
     */
    public int getDefence() {
        if (getHealth() > 0) {
            System.out.println("Monster Defending");
        } else {
            System.out.println("Monster is dead. Cannot defend.");
        }
        return defence;
    }

    /**
     * getHealth Method is for getting the amount of health
     * a monster has.
     * @return the health points a monster has.
     */
    public int getHealth() {
        return health;
    }

    /**
     * getTreasure Method is for getting the amount of treasure
     * a monster has.
     * @return the amount of treasure a monster has.
     */
    public int getTreasure() {
        return treasure;
    }

    /**
     * setTreasure Method is for setting the amount of treasure a
     * monster has.
     * @param treasure the amount of treasure points set for a monster.
     */
    public void setTreasure(int treasure) {
        this.treasure = treasure;
    }
}