using UnityEngine;
using System.Collections;

// Controller class containing menu related logic
public class PlayerController : MonoBehaviour {

    private TTTApplication tttApp;

    void Start () {
        tttApp = (TTTApplication)GameObject.FindObjectOfType(typeof(TTTApplication));
        // Subscribing to Player related events
        EventController.Instance.Subscribe<ChooseNextMoveEvent>(OnChooseNextMoveEvent);
    }

    #region Subscribed event listeners
    // Received ChooseNextMoveEvent.
    public void OnChooseNextMoveEvent(ChooseNextMoveEvent evt) {
        ChooseNextMode(evt.currentPlayer);
    }
    #endregion

    // Received CreatePlayersEvent
    public void ChooseNextMode(PlayerModel playerModel) {
        BoardModel boardModel = tttApp.Model;
        if (playerModel.playerType == PlayerType.HUMAN) {
            // For human player choose next move just enablings clicking on the game 
            // board and waits for the player to click a cell as their next move
            EventController.Instance.Publish(new UpdateCurrentTurnEvent(boardModel.players[boardModel.currentPlayerIndex], "Pick a square"));
            EventController.Instance.Publish(new EnableBoardClickEvent(true));
        } else if (playerModel.playerType == PlayerType.AIMINIMAX) {
            // For AI player clicking on the game board is disabled and bestMove() is called
            // to determine best move (which is defined by the called AI util function)
            EventController.Instance.Publish(new UpdateCurrentTurnEvent(boardModel.players[boardModel.currentPlayerIndex], "Thinking..."));
            CellContent[] cells = boardModel.cells;
            CellContent opponentSymbol = (playerModel.playerSymbol == CellContent.X) ? CellContent.O : CellContent.X;
            int bestMove = MinimaxAlgo.bestMove(playerModel.playerSymbol, cells, playerModel.playerSymbol, opponentSymbol);
            float fakeWaitTime = 1.0f;
            EventController.Instance.Publish(new DoNextMoveEvent(bestMove, fakeWaitTime));
        }
    }
}
