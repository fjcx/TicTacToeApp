using UnityEngine;
using System.Collections;

public class HumanPlayer : Player {

    public HumanPlayer(string playerName, CellContent playerSymbol) {
        this.playerName = playerName;
        this.playerSymbol = playerSymbol;
    }

    public override void ChooseNextMove (BoardModel boardModel) {
        // Enable board clicking and wait for player action
        // TODO: enable board clicking and choose next move
        EventController.Instance.Publish(new UpdateCurrentTurnEvent(boardModel.currentPlayer, "Pick a square"));
        EventController.Instance.Publish(new EnableBoardClickEvent(true));
    }
}
