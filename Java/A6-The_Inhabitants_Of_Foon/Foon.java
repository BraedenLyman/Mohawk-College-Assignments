package assignment6_000370695;

/**
 * This class acts as the view to display the monsters
 * from The Inhabitants of Foon. It also shows the
 * combat between each monster with their abilities
 * and basic attributes. This is not required for
 * this assignment, however examples below show the
 * creation of the different Monsters of Foon objects.
 *
 * Class Name: Foon.java
 * Name: Braeden Lyman
 * Student ID: 000370695
 * Date: July 20th, 2023.
 */

public class Foon {
    public static void main(String[] args) {
        /** Monster Goblin Attributes **/
        Monster goblin = new Goblin("Clan A");
        System.out.println(goblin);

        /** Monster Manticore Attributes **/
        Monster manticore = new Manticore("Clan B", 11, 11, 11, 11, 100);
        System.out.println(manticore);

        /** Monster Orc Attributes **/
        Monster orc = new Orc("Clan C", 12, 12, 12, 12,100);
        System.out.println(orc);

        System.out.println();

        /** Goblin goblin2 Attributes **/
        Goblin goblin2 = new Goblin("Clan A", 13, 13, 13,13,100);
        System.out.println(goblin2);

        /** Goblin goblin2's enemy **/
        System.out.println(goblin2.getEnemy());

        System.out.println();

        /** Manticore manticore1 Attributes **/
        Manticore manticore1 = new Manticore("Clan B");
        System.out.println(manticore1);

        /** Manticore manticore1 changing Clans **/
        manticore1.setClanAffiliation("Clan B-2");
        System.out.println(manticore1);

        System.out.println();

        /** Warlord O=orcWarlord Attributes **/
        Warlord orcWarlord = new Warlord("Clan C-1", 14, 14, 14, 14, 100, 10);
        System.out.println();

        /** Warlord orcWarlord setting leadership points **/
        System.out.println(orcWarlord.setLeadership(2));
        System.out.println(orcWarlord);

        /** Adding leadership points to Warlord orcWarlord **/
        orcWarlord.setIncreaseLeadership();
        System.out.println(orcWarlord);

        /** Removing leadership points from Warlord orcWarlord **/
        orcWarlord.setDecreaseLeadership();
        System.out.println(orcWarlord);

        System.out.println();

        /** Setting Warlord orcWarlord's treasure to 30 points **/
        orcWarlord.setTreasure(30);

        /** Getting leadership points boost from the amount of treasure Warlord orcWarlord has **/
        orcWarlord.treasureLeadership();
        System.out.println(orcWarlord);
        System.out.println();

        /** Warlord orcWarlord sounding its battle cry**/
        System.out.println(orcWarlord.getBattleCry());
        System.out.println(orcWarlord);
        System.out.println();

        /** Infantry infantry Attributes **/
        Infantry infantry = new Infantry("Clan C-2", 15, 15, 15, 15, 100);
        System.out.println(infantry);
        System.out.println();

        /** Warlord orcWarlord attacks Goblin goblin2 **/
        System.out.println(orcWarlord.attack(goblin2));
        System.out.println();

        /** Warlord orcWarlord's current Attributes **/
        System.out.println(orcWarlord);

        System.out.println();

        /** Goblin goblin2 current Attributes **/
        System.out.println(goblin2);

        /** Goblin goblin2 defending its self **/
        System.out.println(goblin2.getDefence());

        /** Checking if Goblin goblin2 is still alive **/
        goblin.isAlive();
    }
}