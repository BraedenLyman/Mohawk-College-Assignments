package assignment2_000370695;

import java.util.Scanner;

// Start - Main Class
public class Main {

    /**
     *  Implementation of a Break Room with two different vending machines containing one product each
     *  with the Product Name, Product Price, Inventory, and Users Credit. The user can enter coins
     *  and use the machine following the machine's prompts.
     * @author Braeden Lyman
     */

    // Start - Main Program
    public static void main(String[] args) {

        Scanner input = new Scanner(System.in); // Allows for user input

        // Snack Machine
        VendingMachine snackVend = new VendingMachine("Snack Machine","Protein Bar", 2.00, 5, 0.00); // Creating vending machine - Snack Machine

        //Drink Machine
        VendingMachine drinkVend = new VendingMachine("Drink Machine", "Pop", 1.00, 5, 0.00); // Creating vending machine - Drink Machine

        // Start - While-loop for user interacting with vending machine
        boolean valid = true;
        while (valid) {

            // Start - Welcome Message
            System.out.println();
            System.out.println("*** Welcome to the Break Room! ***");
            System.out.println();
            System.out.println("*** We have two vending machines to choose from: ***");
            System.out.println();
            System.out.println("*** Option #1 " + snackVend.toString() + " ***"); // Displays the parameters  for snackVend
            System.out.println("*** Option #2 " +drinkVend.toString() + " ***"); // Displays the parameters for drinkVend
            System.out.println("*** Option #3 Exit - Press '3' to Exit ***"); // Displays if user wants to exit the program
            // End - Welcome Message

            int option = input.nextInt(); // User input for options 1, 2, or 3
            // Start - Switch for user choice
            switch (option) {
                case 1:
                    // Start - Message after user input is == 1
                    System.out.println("*** You have chose the Snack Machine! ***"); // Which machine the user entered message
                    System.out.println("*** Enter money to vend. ***"); // Telling user to enter money to vend
                    System.out.println("*** Amount entered as followed: Toonies, Loonies, Quarters, Dimes, Nickles ***"); // Message to show how user enters coins
                    System.out.println("*** My Credit is: " + snackVend.getMyCredit(input.nextInt(), input.nextInt(), input.nextDouble(), input.nextDouble(), input.nextDouble()) + " ***"); // Users credit calculated after they enter all their coins
                    // End - Message after user input is == 1

                    // Start - If user has enough money - This will execute
                    int option2 = snackVend.isValid(); // Method in VendingMachine.java that will execute this If-statment
                    if (option2 == 1) {
                        System.out.println("*** Dispensing Item... ***"); // Snack item is dispensed
                        System.out.println("*** Change due is: " + snackVend.dispenseItem() + " ***"); // Change is automatically dispensed after snack is dispensed
                        System.out.println();
                    // End - If user has enough money - This will execute

                    // Start - If user doesn't have enough money - This will execute
                    } else if (option2 == 2) {
                        System.out.println("*** Not Enough Credits. ***"); // Not enough credits message
                        System.out.println("*** Dispensing Your Coins... ***"); // Dispenses coins user entered back
                        System.out.println("*** Credits Returned: $" + snackVend.notEnough(0.0) + " ***"); // Amount of credits returned to the user
                        System.out.println();
                    // End - If user doesn't have enough money - This will execute

                    // Start - If Invalid - This will execute
                     }else {
                        System.out.println("*** Invalid ***"); // Shows User invalid error
                        System.out.println();
                    }
                    // End - If invalid - This will execute
                    break;

                case 2:
                    // Start - Message after user input == 2
                    System.out.println("*** You have chose the Drink Machine! ***"); // Which machine the user entered message
                    System.out.println("*** Enter money to vend. ***"); // Telling the user to enter money to vend
                    System.out.println("*** Amount entered as followed: Toonies, Loonies, Quarters, Dimes, Nickles ***"); // Message to show how user enters coins
                    System.out.println("*** My Credit is: " + drinkVend.getMyCredit(input.nextInt(), input.nextInt(), input.nextDouble(), input.nextDouble(), input.nextDouble()) + " ***"); // Users credit calculated after they enter all their coins
                    // End - Message after user input == 2

                    // Start - If user has enough money - This will execute
                    int option3 = drinkVend.isValid(); // Method in VendingMachine.java that will execute this If-statment
                    if (option3 == 1) {
                        System.out.println("*** Dispensing Item... ***"); // Snack item is dispensed
                        System.out.println("*** Change due is: " + drinkVend.dispenseItem() + " ***"); // Change is automatically dispensed after snack is dispensed
                        System.out.println();
                    // End - If user has enough money - This will execute

                    // Start - If user doesn't have enough money - This will execute
                    } else if (option3 == 2) {
                        System.out.println("*** Not Enough Credits. ***"); // Not enough credits message
                        System.out.println("*** Dispensing Your Coins... ***"); // Dispenses coins user entered back
                        System.out.println("*** Credits Returned: $" + drinkVend.notEnough(0.0) + " ***"); // Amount of credits returned to the user
                        System.out.println();
                    // End - If user doesn't have enough money - This will execute

                    // Start - If Invalid - This will execute
                    }else {
                        System.out.println("*** Invalid ***");
                        System.out.println();
                    }
                    // End - If Invalid - This will execute

                    break;

                case 3 :
                    // Start - Message after user input == 3
                    System.out.println("*** Turning Off ***"); // Message showing machine turning off
                    System.out.println("*** Goodbye ***"); // Goodbye Message
                    valid = false; // Breaks the while-loop and ends program
                    break;
                    // End - Message after user input == 3
                default:
                    // Start - Message after user input != 1, != 2, != 3
                    System.out.println("*** Invalid Response. Try again. ***");
                    System.out.println();
                    // End - Message after user input != 1, != 2, != 3
            }
            // End - Switch for user choice
        } // End - While-loop for user interacting with vending machine
    } // End - Main Program
} // End - Main Class