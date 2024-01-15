package assignment6_000370695;
/**
 * This document is to create an Infantry class that inherits
 * the Orcs attributes and abilities. This class has
 * functions that only an Infantry can have.
 *
 * Class Name: Infantry.java
 * Name: Braeden Lyman
 * Student ID: 000370695
 * Date: July 20th, 2023.
 */

public class Infantry extends Orc {
    /**
     * Infantry orc constructor sets clanAffiliation from super then fills in default values
     * for all other attributes from super.
     * @param clanAffiliation indicates which clan an infantry Orc is from.
     */
    Infantry(String clanAffiliation) {
        super(clanAffiliation);
    }

    /**
     *  Infantry Orc constructor sets all instance variables from super.
     * @param clanAffiliation indicates which clan an infantry orc is from.
     * @param ferocity indicates how much ferocity points an infantry orc has.
     * @param defence indicates how many defence points an infantry orc has.
     * @param magic indiciates how many magic points an infantry orc has.
     * @param treasure indicates how much treasure an infantry orc has.
     * @param health indicates how much health an infantry orc has.
     */
    Infantry(String clanAffiliation, int ferocity, int defence, int magic, int treasure, int health) {
        super(clanAffiliation, ferocity, defence, magic, treasure, health);
    }

    /**
     * getWarlordCommander Method is to get the amount of Warlord Orc
     * commanders for a group of Infantry Orcs.
     * @return the amount of Warlord Orc commanders that are assigned
     * to a group of Infantry Orcs.
     */
    @Override
    public String getWarlordCommander() {
        Warlord warlord = new Warlord(this.clanAffiliation);
         return warlord.clanAffiliation;
    }

    /**
     * toString Method to print out all the attributes an Infantry Orc has.
     * As well as the amount of Warlord Orc commanders that are assigned
     * to the Infantry Orc.
     * @return a string to represent what an Infantry Orc has for attributes.
     */
    @Override
    public String toString() {
        return  " Orc-Infantry: Clan Affiliation - " + clanAffiliation + " |" +
                " Ferocity - " + ferocity + " |" +
                " Defence - " + defence + " |" +
                " Magic - " + magic + " |" +
                " Treasure - " + getTreasure() + " |" +
                " Health - " + getHealth() + " |" +
                " Warlord Commander: - " + getWarlordCommander();
    }
}