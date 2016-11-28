using UnityEngine;
using System.Collections;

public static class WinConditions {

    public static bool isWinningCondition(CellContent[] testCells, CellContent testSymbol) {
        // row1
        if (testCells[0] == testSymbol && testCells[1] == testSymbol && testCells[2] == testSymbol) {
            return true;
        }
        // row2
        if (testCells[3] == testSymbol && testCells[4] == testSymbol && testCells[5] == testSymbol) {
            return true;
        }
        // row3
        if (testCells[6] == testSymbol && testCells[7] == testSymbol && testCells[8] == testSymbol) {
            return true;
        }
        // col1
        if (testCells[0] == testSymbol && testCells[3] == testSymbol && testCells[6] == testSymbol) {
            return true;
        }
        // col2
        if (testCells[1] == testSymbol && testCells[4] == testSymbol && testCells[7] == testSymbol) {
            return true;
        }
        // col3
        if (testCells[2] == testSymbol && testCells[5] == testSymbol && testCells[8] == testSymbol) {
            return true;
        }
        // diag1
        if (testCells[0] == testSymbol && testCells[4] == testSymbol && testCells[8] == testSymbol) {
            return true;
        }
        // diag2
        if (testCells[6] == testSymbol && testCells[4] == testSymbol && testCells[2] == testSymbol) {
            return true;
        }
        return false;
    }

    // should only be called after checking for a win as draw only checks if board doesn't contain Empty cells
    public static bool isDraw(CellContent[] boardScore) {
        // check for draw !
        for (int i = 0; i < boardScore.Length; i++) {
            if (boardScore[i] == CellContent.EMPTY) {
                return false;
            }
        }
        // board is filled, so a draw
        return true;
    }
}
