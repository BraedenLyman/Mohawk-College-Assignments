package assignment6_000370695;
/**
 * This document is to create an Orc class that inherits
 * the monster's attributes and abilities. This class has
 * functions that only an Orc can have.
 *
 * Class Name: Orc.java
 * Name: Braeden Lyman
 * Student ID: 000370695
 * Date: July 20th, 2023.
 */

public class Orc extends Monster {
    /** Orc as a Warlord **/
    Warlord warlord;

    /** Orc as an Infantry **/
    Infantry infantry;


    /**
     * Monster constructor sets clanAffiliation then fills in default values
     * for all other attributes.
     * @param clanAffiliation indicates which clan a monster is from.
     */
    Orc(String clanAffiliation) {
        super(clanAffiliation);
    }

    /**
     *  Orc constructor sets all instance variables from super.
     * @param clanAffiliation indicates which clan an Orc is from.
     * @param ferocity indicates how much ferocity points an Orc has.
     * @param defence indicates how many defence points an Orc has.
     * @param magic indiciates how many magic points an Orc has.
     * @param treasure indicates how much treasure an Orc has.
     * @param health indicates how much health an Orc has.
     */
    Orc(String clanAffiliation, int ferocity, int defence, int magic, int treasure, int health) {
        super(clanAffiliation, ferocity, defence, magic, treasure, health);
    }

    /**
     * getLeadership Method is to get the leadership points a warlord Orc has.
     * @return the leadership points a warlord has.
     */
    public int getLeadership() {
        return this.warlord.getLeadership();
    }

    /**
     * setIncreaseLeadership Method is to increase the amount of leadership points a
     * warlord Orc can have.
     * @return the increased amount of leadership points a warlord Orc has.
     */
    public int setIncreaseLeadership() {
        return this.warlord.setIncreaseLeadership();
    }

    /**
     * setDecreaseLeadership Method is to decrease the amount of leadership points a
     * warlord Orc can have.
     * @return the decreased amount of leadership points a warlord Orc has.
     */
    public int setDecreaseLeadership() {
        return this.warlord.setDecreaseLeadership();
    }

    /**
     * getWarlordCommander Method is to get the amount of warlord commanders there
     * is for a group of 5 infantry Orcs.
     *
     * @return the amount of warlord commanders there are for a group of 5 infantry Orcs
     */
    public String getWarlordCommander() {
        return infantry.getWarlordCommander();
    }

    /**
     * toString Method to print out all the attributes an Orc has.
     * @return a string to represent what an Orc has for attributes.
     */
    @Override
    public String toString() {
        return  " Orc: Clan Affiliation - " + clanAffiliation + " |" +
                " Ferocity - " + ferocity + " |" +
                " Defence - " + defence + " |" +
                " Magic - " + magic + " |" +
                " Treasure - " + getTreasure() + " |" +
                " Health - " + getHealth();
    }
}