using UnityEngine;
using System.Collections;
using System;

// Controller class containing game board related logic
public class BoardController : MonoBehaviour {

    private TTTApplication tttApp;

    // Use this for initialization
    void Start() {
        tttApp = (TTTApplication) GameObject.FindObjectOfType(typeof(TTTApplication));
        // Subscribing to Board related events
        EventController.Instance.Subscribe<ResetBoardEvent>(OnResetBoardEvent);
        EventController.Instance.Subscribe<CellClickEvent>(OnCellClickEvent);
        EventController.Instance.Subscribe<DoNextMoveEvent>(OnDoNextMoveEvent);
    }

    #region Subscribed event listeners
    // Received ResetBoardEvent event
    public void OnResetBoardEvent(ResetBoardEvent evt) {
        ResetBoard();
    }

    // Received CellClickEvent event
    public void OnCellClickEvent(CellClickEvent evt) {
        // Disable clicking on the board after it is clicked
        EventController.Instance.Publish(new EnableBoardClickEvent(false));
        DoPlayerMove(evt.cellIndex);
    }

    // Received DoNextMoveEvent event
    public void OnDoNextMoveEvent(DoNextMoveEvent evt) {
        StartCoroutine(ArtificalWait(evt));
    }
    #endregion

    #region OnClick event listeners
    // Received Quit Game Board Event
    public void Quit() {
        EventController.Instance.Publish(new DisplayMainMenuEvent(true));
    }
    #endregion

    // ArtificalWait to simulate an AI player thinking
    public IEnumerator ArtificalWait(DoNextMoveEvent evt) {
        yield return new WaitForSeconds(evt.fakeWait);
        DoPlayerMove(evt.move);
    }

    // Reset the game board (but retain players and total score)
    public void ResetBoard() {
        // Disable clicking on board until players turn
        EventController.Instance.Publish(new EnableBoardClickEvent(false));
        BoardModel boardModel = tttApp.Model;

        for (int i = 0; i < boardModel.cells.Length; i++) {
            boardModel.cells[i] = CellContent.EMPTY;
        }
        // Update view elements
        EventController.Instance.Publish(new UpdateBoardCellsEvent(boardModel));
        EventController.Instance.Publish(new UpdateTotalScoreEvent(boardModel));
        // Invoke beginning of players turn 
        StartPlayerTurn();
    }

    // Refers to the logic defined in Player type to choose the next move
    public void StartPlayerTurn() {
        BoardModel boardModel = tttApp.Model;
        boardModel.currentPlayer.ChooseNextMove(boardModel);
    }

    // Applies the chosen move to the game board
    public void DoPlayerMove(int cellIndex) {
        BoardModel boardModel = tttApp.Model;

        if (boardModel.cells[cellIndex] == CellContent.EMPTY) {
            if (boardModel.currentPlayer.playerSymbol == CellContent.X) {
                boardModel.cells[cellIndex] = CellContent.X;
            } else if (boardModel.currentPlayer.playerSymbol == CellContent.O) {
                boardModel.cells[cellIndex] = CellContent.O;
            }

            // Update GridCells also
            EventController.Instance.Publish(new UpdateBoardCellsEvent(boardModel));
            EndPlayerTurn();
        } else {
            EventController.Instance.Publish(new EnableBoardClickEvent(true));
        }
    }

    // Ends the current turn. Checks for win/draw conditions and switches player
    public void EndPlayerTurn() {
        BoardModel boardModel = tttApp.Model;

        // Check for win/draw condition
        if (WinConditions.isWinningCondition(boardModel.cells, boardModel.currentPlayer.playerSymbol)) {
            // Note: only the currrentplayer can win as they made the last move    
            ShowPlayerWon(boardModel.currentPlayer);
            // Update current player to default player on win condition
            boardModel.currentPlayer = boardModel.player1;
        } else if (WinConditions.isDraw(boardModel.cells)) {
            ShowPlayerWon(null);
            // Update current player to default player on draw condition
            boardModel.currentPlayer = boardModel.player1;
        } else {
            // Switch current player if no win/draw is found
            if (boardModel.currentPlayer == boardModel.player1) {
                boardModel.currentPlayer = boardModel.player2;
            } else {
                boardModel.currentPlayer = boardModel.player1;
            }
            // Call Player to choose next move
            StartPlayerTurn();
        }
    }

    // Invokes status panel to display win/draw status
    public void ShowPlayerWon(Player winingPlayer) {
        BoardModel boardModel = tttApp.Model;
        string statusMessage;
        if (winingPlayer == boardModel.player1) {
            boardModel.p1Total++;
            statusMessage = "Player 1 wins!";
        } else if (winingPlayer == boardModel.player2) {
            boardModel.p2Total++;
            statusMessage = "Player 2 wins!";
        } else {
            statusMessage = "Game is a Draw!";
        }

        EventController.Instance.Publish(new DisplayStatusPanelEvent(true, statusMessage));
        EventController.Instance.Publish(new UpdateTotalScoreEvent(boardModel));
    }
}
