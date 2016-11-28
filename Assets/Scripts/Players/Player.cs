using UnityEngine;
using System.Collections;

// Abstract definition of Player. Inherited classes contain player logic
public abstract class Player {
    public string playerName = "Player 1";
    public CellContent playerSymbol = CellContent.X;

    // abstract method defined by players
    public abstract void ChooseNextMove(BoardModel boardModel);
}
