using UnityEngine;
using System.Collections;

public enum PlayerType { HUMAN, CPU };

public abstract class Player {
    public string playerName = "Player 1";
    public CellContent playerSymbol = CellContent.X;
    //public string symbol = "X";

    // abstract method defined by players
    public abstract void ChooseNextMove(BoardModel boardModel);
}
