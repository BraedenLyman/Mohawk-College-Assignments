package assignment4_000370695;

/**
 * The Card class is to create a playing card with each card having its own rank and suit.
 * @author Braeden Lyman
 */

public class Card {
    /* Rank of card */
    private int rank;

    /* Suit of card */
    private int suit;

    /**
     *  Card constructor to get rank and suit form user input.
     * @param rank number of ranks in the deck
     * @param suit number of suits in the deck
     */
    public Card(int rank, int suit) {
        this.rank = rank;
        this.suit = suit;
    }

    /**
     * Used to get the rank in the deck of cards.
     * @return rank of card in the deck
     */
    public int getRank() {
        return rank;
    }

    /**
     * Used to get the suit in the deck of cards.
     * @return suit of card in the deck
     */
    public int getSuit() {
        return suit;
    }

    /**
     * Used to get the card value.
     * @return the card value by multiplying the rank by the suit
     */
    public int getValue() {
        return this.rank * this.suit;
    }

    /**
     * Used to display the outcome of rank and suit of a card.
     * @return the String output for rank and suit
     */
    @Override
    public String toString() {
        return "R"
                + getRank()
                + "S"
                + getSuit();
    }
}