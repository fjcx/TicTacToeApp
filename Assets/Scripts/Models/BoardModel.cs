using System;

[Serializable]
public enum CellContent {
    EMPTY, X, O
}

[Serializable]
public class BoardModel {

    public CellContent[] cells;     // Representation of game board
    public int currentPlayerIndex;  // Current player index
    public PlayerModel[] players;   // Player data
}
