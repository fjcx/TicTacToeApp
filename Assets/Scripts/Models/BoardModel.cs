using UnityEngine;
using System.Collections;

public enum CellContent {
    EMPTY, X, O
}

[System.Serializable]
public class BoardModel {

    public CellContent[] cells;     // Representation of game board

    public Player player1;          // Player 1 details
    public Player player2;          // Player 2 details
    public Player currentPlayer;    // Reference to current player

    public int p1Total;             // Player 1 total score
    public int p2Total;             // Player 2 total score
}
