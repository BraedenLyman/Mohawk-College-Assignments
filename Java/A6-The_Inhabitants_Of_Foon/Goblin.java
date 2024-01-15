package assignment6_000370695;
/**
 * This document is to create a Goblin class that inherits
 * the monster's attributes and abilities. This class has
 * functions that only a Goblin can have.
 *
 * Class Name: Goblin.java
 * Name: Braeden Lyman
 * Student ID: 000370695
 * Date: July 20th, 2023.
 */

public class Goblin extends Monster {
    /** Goblin Enemy Fixed at Birth **/
    public Goblin enemy;

    /**
     * Goblin constructor sets clanAffiliation from super then fills in default values
     * for all other attributes from super.
     * @param clanAffiliation indicates which clan a goblin is from.
     */
    Goblin(String clanAffiliation) {
        super(clanAffiliation);
    }

    /**
     *  Goblin constructor sets all instance variables from super.
     * @param clanAffiliation indicates which clan a goblin is from.
     * @param ferocity indicates how much ferocity points a goblin has.
     * @param defence indicates how many defence points a goblin has.
     * @param magic indiciates how many magic points a goblin has.
     * @param treasure indicates how much treasure a goblin has.
     * @param health indicates how much health a goblin has.
     */
    Goblin(String clanAffiliation, int ferocity, int defence, int magic, int treasure, int health) {
        super(clanAffiliation, ferocity, defence, magic, treasure, health);
    }

    /**
     * getEnemy Method is to get the attributes of a goblin's enemy fixed at birth.
     * @return a goblin enemy with different attributes.
     */
    public Goblin getEnemy() {
        this.enemy = new Goblin("Enemy", 15, 15, 15, 15, 50);
        return this.enemy;
    }

    /**
     * toString Method to print out all the attributes a Goblin has.
     * @return a string to represent what a Goblin has for attributes.
     */
    @Override
    public String toString() {
        return  " Goblin: Clan Affiliation - " + clanAffiliation + " |" +
                " Ferocity - " + ferocity + " |" +
                " Defence - " + defence + " |" +
                " Magic - " + magic + " |" +
                " Treasure - " + getTreasure() + " |" +
                " Health - " + getHealth();
    }
}