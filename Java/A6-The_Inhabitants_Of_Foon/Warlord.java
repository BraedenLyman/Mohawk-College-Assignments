package assignment6_000370695;
/**
 * This document is to create a Warlord class that inherits
 * the Orcs attributes and abilities. This class has
 * functions that only a Warlord can have.
 *
 * Class Name: Warlord.java
 * Name: Braeden Lyman
 * Student ID: 000370695
 * Date: July 20th, 2023.
 */

public class Warlord extends Orc {
    /** Warlord Leadership Points **/
    private int leadership = 1;

    /** Infantry's Assigned to Warlord **/
    private Infantry infantry1, infantry2, infantry3, infantry4, infantry5;


    /**
     * Warlord orc constructor sets clanAffiliation from super then fills in default values
     * for all other attributes from super.
     * @param clanAffiliation indicates which clan a warlord orc is from.
     */
    Warlord(String clanAffiliation) {
        super(clanAffiliation);
        this.infantry1 = new Infantry(clanAffiliation);
        this.infantry2 = new Infantry(clanAffiliation);
        this.infantry3 = new Infantry(clanAffiliation);
        this.infantry4 = new Infantry(clanAffiliation);
        this.infantry5 = new Infantry(clanAffiliation);
    }

    /**
     *  Warlord orc constructor sets all instance variables from super.
     * @param clanAffiliation indicates which clan a warlord orc is from.
     * @param ferocity indicates how much ferocity points a warlord or chas.
     * @param defence indicates how many defence points a warlord orc has.
     * @param magic indiciates how many magic points a warlord orc has.
     * @param treasure indicates how much treasure a warlord orc has.
     * @param health indicates how much health a warlord orc has.
     */
    Warlord(String clanAffiliation, int ferocity, int defence, int magic, int treasure, int health, int leadership) {
        super(clanAffiliation, ferocity, defence, magic, treasure, health);
        this.leadership = leadership;
        this.infantry1 = new Infantry(clanAffiliation);
        this.infantry2 = new Infantry(clanAffiliation);
        this.infantry3 = new Infantry(clanAffiliation);
        this.infantry4 = new Infantry(clanAffiliation);
        this.infantry5 = new Infantry(clanAffiliation);

        if (leadership < 1 || leadership > 5){ System.out.println("Leadership is to be between 1 and 5"); this.leadership = 0;} // If statement to display if number is above 5 and below 1. Resets to 0.
    }

    /**
     * getLeadership Method is to get the amount of leadership points a Warlord Orc has.
     * @return the amount of leadership points a Warlord Orc has.
     */
    public int getLeadership() {
        return this.leadership;
    }

    /**
     * setLeadership Method sets the amount of leadership points a Warlord Orc can have.
     * @param leadership the amount of leadership points assigned to a Warlord Orc.
     * @return the amount of points a Warlord Orc has.
     */
    public int setLeadership(int leadership) {
        this.leadership = leadership;
        return leadership;
    }

    /**
     * setIncreaseLeadership Method is to increase the amount of leadership points a
     * Warlord Orc has.
     * @return the increased amount of leadership points a Warlord Orc has.
     */
    public int setIncreaseLeadership() {
        int increaseLeadership; // adds one to the current leadership points
        if (this.leadership >= 1 && this.leadership < 5) {
            increaseLeadership = this.leadership += 1;
        } else {
            increaseLeadership = 0;
        }
        return increaseLeadership;
    }

    /**
     * treasureLeadership Method is for when a Warlord Orc gains 10 treasures. They
     * also gain a +1 leadership bonus.
     * @return the new amount of leadership points a Warlord Orc has.
     */
    public int treasureLeadership() {
        int boost = 0; // boost counter for each time the Warlord Orc gets a leadership boost of +1.
        int myTreasure = 10; // myTreasure counter for each time the Warlord Orc gains 10 or more treasures.

        // while loop to indicate everytime the Warlord Orc gets 10 treasures, they get a +1 leadership bonus.
        while (getTreasure() >= myTreasure) {
            myTreasure += 10;
            boost += 1;
        }
        this.leadership = setLeadership(boost);
        return this.leadership;
    }

    /**
     * setDecreaseLeadership Method is to decrease the amount of leadership points a
     * Warlord Orc has.
     * @return the decreased amount of leadership points a Warlord Orc has.
     */
    public int setDecreaseLeadership() {
        int decreaseLeadership; // subtracts one from the current leadership points.
        if (this.leadership >= 1 && this.leadership < 5) {
            decreaseLeadership = this.leadership -= 1;
        } else {
            decreaseLeadership = 0;
        }
        return decreaseLeadership;
    }

    /**
     * getAttackScore Method is from the super class
     * to get the attackScore of a monster and multiply
     * it by 1.5 as a Warlord Orc is stronger than a normal
     * monsters.
     * @return attackScore from the super class * 1.5.
     */
    @Override
    public double getAttackScore() {
        return super.getAttackScore() * 1.5;
    }

    /**
     * getBattleCry Method is to give a health boost to the Warlord Orc and the
     * Warlord Orc's infantry members.
     * @return healthBoost of leadership points * 5.
     */
    public int getBattleCry(){
        int healthBoost = getLeadership() * 5; // healthBoost takes leadership points and multiples by 5 to get the added health bonus.
        if (getHealth() > 0) {
            setIncreaseHealth(healthBoost);
            this.infantry1.setIncreaseHealth(healthBoost);
            this.infantry2.setIncreaseHealth(healthBoost);
            this.infantry3.setIncreaseHealth(healthBoost);
            this.infantry4.setIncreaseHealth(healthBoost);
            this.infantry5.setIncreaseHealth(healthBoost);
        } else {
            System.out.println("Warlord is dead. Cannot sound BattleCry");
        }
        return healthBoost;
    }

    /**
     * toString Method to print out all the attributes a Warlord Orc has
     * as well as the amount of infantry members assigned to it and the
     * amount of leadership points a Warlord Orc has.
     * @return a string to represent what a Warlord Orc has for attributes.
     */
    @Override
    public String toString() {
        return  " Orc-Warlord: Clan Affiliation - " + clanAffiliation + " |" +
                " Ferocity - " + ferocity + " |" +
                " Defence - " + defence + " |" +
                " Magic - " + magic + " |" +
                " Treasure - " + getTreasure() + " |" +
                " Health - " + getHealth() + " |" +
                " Leadership Rating - " + getLeadership() + "\n" +
                " Infantry: " + "\n" +
                " 1: " + this.infantry1 + "\n" +
                " 2: " + this.infantry2 + "\n" +
                " 3: " + this.infantry3 + "\n" +
                " 4: " + this.infantry4 + "\n" +
                " 5: " + this.infantry5;
    }
}