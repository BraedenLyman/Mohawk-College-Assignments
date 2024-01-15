package assignment4_000370695;

/**
 * DeckOfCards class is to create a deck of cards that hold a card
 * (from the Card class) inside an array. A deck of cards can shuffle,
 * deal cards, and display a histogram of 100,000 cards dealt.
 * @author Braeden Lyman
 */

import java.util.Random;

public class DeckOfCards {
    /* Initializes an array of cards from the Card class */
    private Card[] cards;

    /* Size of the deck */
    private int deckSize;

    /* Initializes an array of cards for the histogram */
    private int[] histogram;

    /**
     *  DeckOfCards constructor for getting the deck size by getting user input
     *  for the maximum rank and maximum suit and multiplying them together.
     * @param maxRank user input for maximum rank in the deck
     * @param numSuits user input for maximum number of suits in the deck
     */
    public DeckOfCards(int maxRank, int numSuits) {
        this.deckSize = maxRank * numSuits;
        this.cards = new Card[deckSize];

        // for-loop for getting the total amount of cards with each rank and suit combination
        // that are in the created deck size
        int numRankSuit = 0;
        for (int rank = 1; rank <= maxRank; rank++) {
            for (int suit = 1; suit <= numSuits; suit++) {
                cards[numRankSuit] = new Card(rank, suit);
                numRankSuit++;
            }
        }
    }

    /**
     * The Shuffle method is used to randomly shuffle the cards by switching out pairs of cards.
     */
    public void shuffle() {
        Random random = new Random(); // For getting random card
        for (int i = deckSize - 1; i > 0; i--) {
            int rand = random.nextInt(i + 1);
            Card temp = cards[i];
            cards[i] = cards[rand];
            cards[rand] = temp;
        }
    }

    /**
     * Used to get the size of the deck.
     * @return deck size
     */
    public int getDeckSize() {
        return deckSize;
    }

    /**
     * Used to get the mimimum card value in the deck.
     * @return the minimum card value in the deck
     */
    public int minCardValue() {
        int minValue = cards[0].getValue();
        for (int i = 1; i < deckSize; i++) {
            int value = cards[i].getValue();
            if (value < minValue) {
                minValue = value;
            }
        }
        return minValue;
    }

    /**
     *  Used to get the maximum card value in the deck.
     * @return the maximum card value in the deck
     */
    public int maxCardValue() {
        int maxValue = this.cards[0].getValue();
        for (int i = 1; i < deckSize; i++) {
            int value = this.cards[i].getValue();
            if (value > maxValue) {
                maxValue = value;
            }
        }
        return maxValue;
    }

    /**
     * Used to deal the amount of cards user input asks for.
     * @param numOfCards determines how many cards to be dealt from user input
     * @return the top number of cards from user input
     */
    public Card[] deal(int numOfCards) {
        Card[] hand = new Card[numOfCards];
        for (int i = 0; i < numOfCards; i++) {
            hand[i] = this.cards[i];
        }
        return hand;
    }

    /**
     * Used to display the outcome of how many cards are in the deck, along
     * with the lowest value, highest value, and what the top card is.
     * @return the string output of deck size, minimum and maximum card value, and top card in deck
     */
    @Override
    public String toString() {
        return "Deck of "
                + getDeckSize()
                + " cards: Low - "
                + minCardValue()
                + " High - "
                + maxCardValue()
                + " Top Card - "
                + this.cards[0];
    }

    /**
     * Used to display the histogram of 100,000 cards dealt given the amount of cards in a hand.
     * @param numOfCards user input of how many cards they want to display the histogram for
     */
    public void histogram(int numOfCards) {
        this.histogram = new int[numOfCards * numOfCards + 1];
        int numDeals = 100000;


        for (int i = 0; i < numDeals; i++) {
            shuffle();
            Card[] hand = deal(numOfCards);
            int totalSum = 0;
            for (Card card : hand) {
                totalSum += card.getValue();
            }
            if (totalSum >= 1 && totalSum < histogram.length) {
                histogram[totalSum]++;
            }
        }
        for (int i = 1; i < histogram.length; i++) {
            if (histogram[i] != 0) {
                System.out.println(i + ": " + histogram[i]);
            }
        }
    }
}