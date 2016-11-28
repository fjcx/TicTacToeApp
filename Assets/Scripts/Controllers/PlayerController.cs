using UnityEngine;
using System.Collections;

// Controller class containing player logic
public class PlayerController : MonoBehaviour {

    private TTTApplication tttApp;

    void Start () {
        tttApp = (TTTApplication)GameObject.FindObjectOfType(typeof(TTTApplication));
        // Subscribing to Player related events
        EventController.Instance.Subscribe<ChooseNextMoveEvent>(OnChooseNextMoveEvent);
        EventController.Instance.Subscribe<CreatePlayersEvent>(OnCreatePlayersEvent);
    }

    #region Subscribed event listeners
    // Received ChooseNextMoveEvent
    public void OnChooseNextMoveEvent(ChooseNextMoveEvent evt) {
        ChooseNextMode(evt.currentPlayer);
    }

    // Received CreatePlayersEvent
    public void OnCreatePlayersEvent(CreatePlayersEvent evt) {
        PlayerModel player1 = new PlayerModel();
        PlayerModel player2 = new PlayerModel();

        player1.score = 0;
        player1.playerSymbol = CellContent.X;
        player1.playerName = evt.player1Name;

        player2.score = 0;
        player2.playerSymbol = CellContent.O;
        player2.playerName = evt.player2Name;

        // Creating new Player types based on drop down selection
        if (evt.player1Type == "Human") {
            player1.playerType = PlayerType.HUMAN;
        } else {
            player1.playerType = PlayerType.AIMINIMAX;
        }

        if (evt.player2Type == "Human") {
            player2.playerType = PlayerType.HUMAN;
        } else {
            player2.playerType = PlayerType.AIMINIMAX;
        }

        // Update BoardModel with new Players
        BoardModel boardModel = tttApp.Model;
        boardModel.players[0] = player1;
        boardModel.players[1] = player2;
        boardModel.currentPlayerIndex = 0;

        EventController.Instance.Publish(new ResetBoardEvent());
        EventController.Instance.Publish(new DisplayBoardEvent(true));
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
