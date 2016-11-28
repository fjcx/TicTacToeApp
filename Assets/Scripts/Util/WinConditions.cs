using UnityEngine;
using System.Collections;

// Util class for checking win/draw conditions
public static class WinConditions {

    // Checks for game winning conditions.
    /// <param name="testCells">Board cell representation to test.</param>
    /// <param name="testSymbol">Symbol to check for win (i.e. check if X won/check if O won).</param>
    public static bool isWinningCondition(CellContent[] testCells, CellContent testSymbol) {
        if (testSymbol == CellContent.X || testSymbol == CellContent.O) {
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
        }
        return false;
    }

    // Testing for a draw. 
    // Note: should only be called after checking for a win as draw only checks if board doesn't contain Empty cells
    /// <param name="testCells">Board cell representation to test.</param>
    public static bool isDraw(CellContent[] testCells) {
        // check for draw
        for (int i = 0; i < testCells.Length; i++) {
            if (testCells[i] == CellContent.EMPTY) {
                return false;
            }
        }
        // board is filled, so a draw
        return true;
    }
}
