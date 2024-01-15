package assignment4_000370695;

/**
 * Main class is to display a menu of choices for the user to choose from
 * representing a deck of cards that contain an array of cards. The
 * users choice reflects on what the deck of cards and cards do.
 * @author Braeden Lyman
 */

import java.util.Arrays;
import java.util.Scanner;

/**
 * Main method is the view to ask for user inputs and displays
 * the output of a certain outcome.
 */
public class Main {
    public static void main(String[] args) {

        Scanner input = new Scanner(System.in);
        System.out.println("How many Ranks?: ");
        int maxRank = input.nextInt();
        System.out.println("How many Suits?: ");
        int numSuits = input.nextInt();
        System.out.println();

        boolean flag = true;
        while (flag) {
            DeckOfCards deck = new DeckOfCards(maxRank, numSuits);
            deck.shuffle();
            System.out.println(deck);

            // Menu for user to select from
            System.out.println("1: Shuffle | 2: Deal 1 Hand | 3: Deal 100,000 times | 4: Quit");
            int menu = input.nextInt();

            // Switch for users choice
            switch (menu) {
                default:
                    System.out.println("Invalid Try again!");
                    break;

                case 1:
                    // Shuffle
                    deck.shuffle();
                    break;

                case 2:
                    // Deal 1 Hand
                    System.out.println("How many cards?: ");
                    boolean flag1 = true;
                    while (flag1) {
                        int numOfCards = input.nextInt();
                        if (numOfCards < 0 || numOfCards > deck.getDeckSize()) {
                            System.out.println("Try Again! How many Cards?: ");
                        } else {
                            System.out.println(Arrays.toString(deck.deal(numOfCards)));
                            System.out.println();
                            flag1 = false;
                        }
                    }
                    break;

                case 3:
                    //Deal 100,000 times
                    System.out.println("How many cards?: ");
                    int numOfCards = input.nextInt();
                    deck.histogram(numOfCards);
                    System.out.println();
                    break;

                case 4:
                    // Quit
                    System.out.println("GoodBye!");
                    flag = false;
                    break;
            }
        }
    }
}