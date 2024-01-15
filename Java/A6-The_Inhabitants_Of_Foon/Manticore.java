package assignment6_000370695;
/**
 * This document is to create a Manticore class that inherits
 * the monster's attributes and abilities. This class has
 * functions that only a Manticore can have.
 *
 * Class Name: Manticore.java
 * Name: Braeden Lyman
 * Student ID: 000370695
 * Date: July 20th, 2023.
 */

public class Manticore extends Monster {
    /**
     * Manticore constructor sets clanAffiliation from super then fills in default values
     * for all other attributes from super.
     * @param clanAffiliation indicates which clan a manticore is from.
     */
    Manticore(String clanAffiliation) {
        super(clanAffiliation);
    }

    /**
     *  Manticore constructor sets all instance variables from super.
     * @param clanAffiliation indicates which clan a manticore is from.
     * @param ferocity indicates how much ferocity points a manticore has.
     * @param defence indicates how many defence points a manticore has.
     * @param magic indiciates how many magic points a manticore has.
     * @param treasure indicates how much treasure a manticore has.
     * @param health indicates how much health a manticore has.
     */
    Manticore(String clanAffiliation, int ferocity, int defence, int magic, int treasure, int health) {
        super(clanAffiliation, ferocity, defence, magic, treasure, health);
    }

    /**
     * setClanAffiliation Method is to allow the manticore to switch clans
     * as they are fickle and change clans all the time.
     * @param clanAffiliation chooses another clan they want to be part of.
     */
    public void setClanAffiliation(String clanAffiliation) {
        this.clanAffiliation = clanAffiliation;
    }

    /**
     * getAttackScore Method is from the super class
     * to get the attackScore of a monster and multiply
     * it by 1.5 as a manticore is stronger than a normal
     * monsters.
     * @return attackScore from the super class * 1.5.
     */
    @Override
    public double getAttackScore() {
        return super.getAttackScore() * 1.5;
    }

    /**
     * toString Method to print out all the attributes a Manticore has.
     * @return a string to represent what a Manticore has for attributes.
     */
    @Override
    public String toString() {
        return  " Manticore: Clan Affiliation - " + clanAffiliation + " |" +
                " Ferocity - " + ferocity + " |" +
                " Defence - " + defence + " |" +
                " Magic - " + magic + " |" +
                " Treasure - " + getTreasure() + " |" +
                " Health - " + getHealth();
    }
}