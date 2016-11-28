using UnityEngine;
using System.Collections;
using System;

public class BoardController : MonoBehaviour {

    private TTTApplication tttApplication;

    // Use this for initialization
    void Start() {
        // Perhaps use different reference !!!
        tttApplication = (TTTApplication) GameObject.FindObjectOfType(typeof(TTTApplication));

        EventController.Instance.Subscribe<ResetBoardEvent>(OnResetBoardEvent);
        EventController.Instance.Subscribe<CellClickEvent>(OnCellClickEvent);
        EventController.Instance.Subscribe<DoNextMoveEvent>(OnDoNextMoveEvent);
    }

    public BoardController(TotalScorePanelView totalScorePanelView,
        CurrentTurnPanelView currentTurnPanelView,
        StatusPanelView statusPanelView) {
    }

    // Event Listeners
    public void OnResetBoardEvent(ResetBoardEvent evt) {
        ResetBoard();
    }

    public void OnCellClickEvent(CellClickEvent evt) {
        // Disable clicking on the board after it is clicked
        EventController.Instance.Publish(new EnableBoardClickEvent(false));
        DoPlayerMove(evt.cellIndex);
    }
    // End

    // OnClick events
    public void Quit() {
        EventController.Instance.Publish(new DisplayMainMenuEvent(true));
    }

    // 
    public void OnDoNextMoveEvent(DoNextMoveEvent evt) {
        StartCoroutine(ArtificalWait(evt));
    }

    public IEnumerator ArtificalWait(DoNextMoveEvent evt) {
        yield return new WaitForSeconds(evt.fakeWait);
        DoPlayerMove(evt.move);
    }

    // Board Actions
    public void ResetBoard() {
        // Disable clicking on board until players turn
        EventController.Instance.Publish(new EnableBoardClickEvent(false));
        BoardModel boardModel = tttApplication.Model;

        for (int i = 0; i < boardModel.cells.Length; i++) {
            boardModel.cells[i] = CellContent.EMPTY;
        }
        // Update view elements
        EventController.Instance.Publish(new UpdateBoardCellsEvent(boardModel));
        EventController.Instance.Publish(new UpdateTotalScoreEvent(boardModel));
        // Invoke beginning of players turn 
        StartPlayerTurn();
    }

    public void StartPlayerTurn() {
        BoardModel boardModel = tttApplication.Model;
        boardModel.currentPlayer.ChooseNextMove(boardModel);
    }

    public void DoPlayerMove(int cellIndex) {
        BoardModel boardModel = tttApplication.Model;

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

    public void EndPlayerTurn() {
        BoardModel boardModel = tttApplication.Model;

        // Check for win/draw condition
        // int winCond = isWinCondition(boardModel.linearCells);
        bool isCurrPlayerWin = WinConditions.isWinningCondition(boardModel.cells, boardModel.currentPlayer.playerSymbol);

        if (isCurrPlayerWin) {
            // only the currrentplayer can win as they made the last move    
            ShowPlayerWon(boardModel.currentPlayer);
            // TODO: Update to default player on win condition !!!!
            boardModel.currentPlayer = boardModel.player1;
        } else if (WinConditions.isDraw(boardModel.cells)) {
            ShowPlayerWon(null);
            // TODO: Update to default player on win condition !!!!
            boardModel.currentPlayer = boardModel.player1;
        } else {
            // Switch players for turn  --> TODO perhaps do playerRef and checks differently
            if (boardModel.currentPlayer == boardModel.player1) {
                boardModel.currentPlayer = boardModel.player2;          // TODO: perhaps should not reference/Update directly !!!!
            } else {
                boardModel.currentPlayer = boardModel.player1;
            }
            StartPlayerTurn();      // TODO: need some condition checks ???
        }
    }

    public void ShowPlayerWon(Player winingPlayer) {
        BoardModel boardModel = tttApplication.Model;
        string statusMessage;
        if (winingPlayer == boardModel.player1) {
            boardModel.p1Total++;                   // DONT reference this directlt !!!!
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
