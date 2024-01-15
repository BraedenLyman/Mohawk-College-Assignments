
package assignment2_000370695;

/**
 *  Implementation of a Break Room with two different vending machines containing one product each
 *  with the Product Name, Product Price, Inventory, and Users Credit. The user can enter coins
 *  and use the machine following the machine's prompts.
 * @author Braeden Lyman
 */
public class VendingMachine {
    /** Vending Machine Name **/
    private String venName;

    /** Product Name **/
    private String prodName;

    /** Product Price **/
    private double prodPrice;

    /** Product Inventory **/
    private int prodInventory;

    /** Users Credit **/
    private double myCredit;

    /**
     * VendingMachine Compiler
     *
     * To define a vending machine with these parameters
     * @param venName Vending Machine Name
     * @param prodName Product Name
     * @param prodPrice Product Price
     * @param prodInventory Product Inventory
     * @param myCredit Users Credit
     */
    public VendingMachine(String venName, String prodName, double prodPrice, int prodInventory, double myCredit) {
        this.venName = venName;
        this.prodName = prodName;
        this.prodPrice = prodPrice;
        this.prodInventory = prodInventory;
        this.myCredit = myCredit;
    }

    /**
     * Method toString
     *
     * Vending machine options for users to choose from.
     * @return Displays the parameters for SnackVend & DrinkVend.
     */
    @Override
    public String toString() {
        return  venName + " - " +
                "Item: " + prodName +
                ", Price: $" + prodPrice +
                ", Inventory Left: " + prodInventory +
                ", My Credit " + myCredit;
    }

    /**
     * Method isValid
     *
     *  Method for checking if user has enough money. Displays corresponding message.
     * @return If-statment returns either: option 3 == 1, option 3 == 2, or else.
     */
    public int isValid (){
        int val = 0;
        if (myCredit >= prodPrice){
            val = 1; // Checks if user has enough money or exactly enough money and will execute and show in Main.java
        } else if (myCredit < prodPrice){
            val = 2; // Checks if user doesn't have enough money will execute and show in Main.java
        }else {
            val = 3; // Invalid message will execute and show in Main.java
        }
        return val; // Checks if user has enough money or not and executes if-statment in Main.java
    }

    /**
     * Method notEnough
     *
     * Method for checking if user doesn't have enough money.
     * @param coinsReturned Coins returned to user.
     * @return Coins returned to user if not enough money is present.
     */
    public double notEnough (double coinsReturned) {
        if (myCredit < prodPrice) { // If-statment executes if users has less money than the product cost
            coinsReturned = myCredit; // Calculation of how much money returned if user doesn't have enough money
            myCredit = 0.0; // Credit balance after coin return
        }
        return coinsReturned; // Returns coins back to user after not enough money
    }

    /**
     * Method dispenseItem
     *
     * Method for checking if user has enough money.
     * @return Dispenses item if user has enough money or more than enough money.
     * @return Dispenses users change
     */
    public double dispenseItem (){
        if (myCredit >= prodPrice) { // If-statment executes if user has more money then the product cost or equals product cost
            double changeDue =  myCredit - prodPrice; // Calculations for amount of change that is due back to the user
            prodInventory -= 1; // Inventory after item is dispensed
            myCredit = 0.0; // Credit balance after dispensing item
            return changeDue; // How much change is due to the user
        }
        return myCredit; // Returns users credits
    }

    /**
     * Method getMyCredit
     *
     * Calculations for amount of money user enters into the machine.
     * @param toonies Amount of toonies user enters
     * @param loonies Amount of loonies user enters
     * @param quarters Amount of quarters user enters
     * @param dimes Amount of dimes user enters
     * @param nickles Amount of nickles user enters
     * @return The total amount of money user has entered into the machine.
     */
    public double getMyCredit(int toonies, int loonies, double quarters, double dimes, double nickles) {
        int totalToonies = toonies *2; // Coverts amount of toonies user enters to toonie amount
        int totalLoonies = loonies *1; // Converts amount of loonies user enters to loonie amount
        double totalQuarters = quarters * 0.25; // Converts amount of quarters user enters to quarter amount
        double totalDimes = dimes * 0.10; // Converts amount of dimes user enters to dime amount
        double totalNickles = nickles * 0.05; // Converts amount of nickles user enters to nickle amount
        myCredit = totalToonies + totalLoonies + totalQuarters + totalDimes + totalNickles; // Converts total amount of money user enters to total amount of money
        return myCredit; // Returns users credits
    }
}