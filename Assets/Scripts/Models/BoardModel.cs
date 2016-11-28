using UnityEngine;
using System.Collections;

public enum CellContent {
    EMPTY, X, O
}

[System.Serializable]
public class BoardModel {

    public CellContent[] cells;

    public int p1Total;     // --> perhaps change to int[]
    public int p2Total;

    public Player player1;  // --> perhaps change to PlayerModel[]
    public Player player2;

    public Player currentPlayer;
}
