using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class MinimaxAlgo {

    // Get next best move for AI. Returns cellIndex for bestMove
    public static int bestMove(CellContent currPlayer, CellContent[] cells, CellContent playerSymbol, CellContent opponentSymbol) {
        int[] result = minimax(2, cells, currPlayer, playerSymbol, opponentSymbol);
        return result[1];
    }

    // Recursive minimax algo. Return int[2] of {score, cellIndex}
    private static int[] minimax(int depth, CellContent[] cells, CellContent currPlayer, CellContent playerSymbol, CellContent opponentSymbol) {
        // Generate possible next moves in a List of indices
        List<int> nextMoves = generateMoves(cells, playerSymbol, opponentSymbol);

        //  Maximizing playerSymbol, while minimize opponentSymbol
        int bestScore = (currPlayer == playerSymbol) ? int.MinValue : int.MaxValue;
        int currentScore;
        int bestIndex = -1;

        if (nextMoves.Count == 0 || depth == 0) {
            // No next moves, or depth reached, evaluate score
            bestScore = evaluate(cells, playerSymbol, opponentSymbol);
        } else {
            foreach (int move in nextMoves) {
                // Try this move for current player
                cells[move] = currPlayer;
                if (currPlayer == playerSymbol) {
                    // Maximizing playerSymbol (i.e. AI player)
                    currentScore = minimax(depth - 1, cells, opponentSymbol, playerSymbol, opponentSymbol)[0];
                    if (currentScore > bestScore) {
                        bestScore = currentScore;
                        bestIndex = move;
                    }
                } else {
                    // Minimizing playerSymbol (i.e. AI player)
                    currentScore = minimax(depth - 1, cells, playerSymbol, playerSymbol, opponentSymbol)[0];
                    if (currentScore < bestScore) {
                        bestScore = currentScore;
                        bestIndex = move;
                    }
                }
                // Undo move
                cells[move] = CellContent.EMPTY;
            }
        }
        return new int[] { bestScore, bestIndex };
    }

    // Find all valid next moves
    private static List<int> generateMoves(CellContent[] cells, CellContent playerSymbol, CellContent opponentSymbol) {
        List<int> nextMoves = new List<int>();

        // If win condition then there is no next move
        if (WinConditions.isWinningCondition(cells, playerSymbol) || WinConditions.isWinningCondition(cells, opponentSymbol)) {
            // return empty list
            return nextMoves;
        }

        for (int i = 0; i < cells.Length; i++) {
            if (cells[i] == CellContent.EMPTY) {
                nextMoves.Add(i);
            }
        }

        return nextMoves;
    }

    // Heuristic evaluation function for the game board
    //  Return +100, +10, +1 for EACH 3-, 2-, 1-in-a-line for currentPlayer (i.e. AI)
    //         -100, -10, -1 for EACH 3-, 2-, 1-in-a-line for opponentPlayer
    //          0 otherwise
    private static int evaluate(CellContent[] cells, CellContent playerSymbol, CellContent opponentSymbol) {
        int score = 0;
        // Evaluate score for each of the 8 cell combinations (3 rows, 3 columns, 2 diagonals)
        score += evaluateLine(cells, 0, 1, 2, playerSymbol, opponentSymbol);  // row 0
        score += evaluateLine(cells, 3, 4, 5, playerSymbol, opponentSymbol);  // row 1
        score += evaluateLine(cells, 6, 7, 8, playerSymbol, opponentSymbol);  // row 2
        score += evaluateLine(cells, 0, 3, 6, playerSymbol, opponentSymbol);  // col 0
        score += evaluateLine(cells, 1, 4, 7, playerSymbol, opponentSymbol);  // col 1
        score += evaluateLine(cells, 2, 5, 8, playerSymbol, opponentSymbol);  // col 2
        score += evaluateLine(cells, 0, 4, 8, playerSymbol, opponentSymbol);  // diagonal 1
        score += evaluateLine(cells, 2, 4, 6, playerSymbol, opponentSymbol);  // diagonal 2
        return score;
    }

    // Heuristic evaluation function for the game board
    //  Return +100, +10, +1 for EACH 3-, 2-, 1-in-a-line for currentPlayer (i.e. AI)
    //         -100, -10, -1 for EACH 3-, 2-, 1-in-a-line for opponentPlayer
    //          0 otherwise
    private static int evaluateLine(CellContent[] cells, int cell1, int cell2, int cell3, CellContent playerSymbol, CellContent opponentSymbol) {
        int score = 0;

        // First cell
        if (cells[cell1] == playerSymbol) {
            score = 1;
        } else if (cells[cell1] == opponentSymbol) {
            score = -1;
        }

        // Second cell
        if (cells[cell2] == playerSymbol) {
            if (score == 1) {               // cell1 is playerSymbol
                score = 10;
            } else if (score == -1) {       // cell1 is opponentSymbol
                return 0;
            } else {                        // cell1 is empty
                score = 1;
            }
        } else if (cells[cell2] == opponentSymbol) {
            if (score == -1) {              // cell1 is opponentSymbol
                score = -10;
            } else if (score == 1) {        // cell1 is playerSymbol
                return 0;
            } else {                        // cell1 is empty
                score = -1;
            }
        }

        // Third cell
        if (cells[cell3] == playerSymbol) {
            if (score > 0) {                // cell1 and/or cell2 is playerSymbol
                score *= 10;
            } else if (score < 0) {         // cell1 and/or cell2 is opponentSymbol
                return 0;
            } else {                        // cell1 and cell2 are empty
                score = 1;
            }
        } else if (cells[cell3] == opponentSymbol) {
            if (score < 0) {                // cell1 and/or cell2 is opponentSymbol
                score *= 10;
            } else if (score > 1) {         // cell1 and/or cell2 is playerSymbol
                return 0;
            } else {                        // cell1 and cell2 are empty
                score = -1;
            }
        }
        return score;
    }
}
