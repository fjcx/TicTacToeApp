using UnityEngine;
using System.Collections;

// Basic human player
public class HumanPlayer : Player {

    public HumanPlayer(string playerName, CellContent playerSymbol) {
        this.playerName = playerName;
        this.playerSymbol = playerSymbol;
    }

    // For human player choose next move just enablings clicking on the game 
    // board and waits for the player to click a cell as their next move
    public override void ChooseNextMove (BoardModel boardModel) {
        EventController.Instance.Publish(new UpdateCurrentTurnEvent(boardModel.players[boardModel.currentPlayerIndex], "Pick a square"));
        EventController.Instance.Publish(new EnableBoardClickEvent(true));
    }
}
