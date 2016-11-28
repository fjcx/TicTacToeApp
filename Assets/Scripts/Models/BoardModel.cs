using System;

[Serializable]
public enum CellContent {
    EMPTY, X, O
}

[Serializable]
public class BoardModel {

    public CellContent[] cells;     // Representation of game board

    public Player[] players;        // Player details
    public int currentPlayerIndex;  // Current player index
    public int[] playerScores;      // Players total scores

}
