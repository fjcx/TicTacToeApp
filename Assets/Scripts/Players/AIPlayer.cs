using UnityEngine;
using System.Collections;
using System;

// Basic abstract AI player
public abstract class AIPlayer : Player {
    protected CellContent opponentSymbol;

    protected CellContent[] cells;          // board cells to test
    protected float fakeWaitTime = 1.0f;    // artifical wait time while 'thinking'

    // For AI player clicking on the game board is disabled and move() is called
    // to determine best move (which is defined by the inherited AI player classes)
    public override void ChooseNextMove(BoardModel boardModel) {
        EventController.Instance.Publish(new UpdateCurrentTurnEvent(boardModel.players[boardModel.currentPlayerIndex], "Thinking..."));
        cells = boardModel.cells;
        setOpponentSymbol();
        int bestMove = move();
        EventController.Instance.Publish(new DoNextMoveEvent(bestMove, fakeWaitTime));
    }

    // Sets opponent symbol based on current player symbol
    public void setOpponentSymbol() {
        opponentSymbol = (playerSymbol == CellContent.X) ? CellContent.O : CellContent.X;
    }

    // Abstract method to get next move. Returns cellIndex for bestMove
    public abstract int move();
}
