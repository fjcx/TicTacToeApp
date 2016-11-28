using UnityEngine;
using System.Collections;
using System;

public enum Seed {CROSS, NOUGHT, EMPTY};

public abstract class AIPlayer : Player {
    protected CellContent opponentSymbol;

    protected CellContent[] cells;
    protected float fakeWaitTime = 1.0f;

    public override void ChooseNextMove(BoardModel boardModel) {
        EventController.Instance.Publish(new UpdateCurrentTurnEvent(boardModel.currentPlayer, "Thinking..."));

        cells = boardModel.cells;
        setOpponentSymbol();
        int bestMove = move();
        
        EventController.Instance.Publish(new DoNextMoveEvent(bestMove, fakeWaitTime));
    }

    /** Set/change the seed used by computer and opponent */
    public void setOpponentSymbol() {
        opponentSymbol = (playerSymbol == CellContent.X) ? CellContent.O : CellContent.X;
    }

    /** Abstract method to get next move. Returns cellIndex for bestMove */
    public abstract int move();
}
