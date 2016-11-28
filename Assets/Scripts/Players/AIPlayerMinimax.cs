using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

// AI player based on basic minimax algorithm
public class AIPlayerMinimax : AIPlayer {
    public AIPlayerMinimax(string playerName, CellContent playerSymbol) {
        this.playerName = playerName;
        this.playerSymbol = playerSymbol;
    }

    // Get next best move for AI. Returns cellIndex for bestMove
    public override int move() {
        int[] result = minimax(2, playerSymbol);
        return result[1];
    }

    // Recursive minimax algo. Return int[2] of {score, cellIndex}
    private int[] minimax(int depth, CellContent player) {
        // Generate possible next moves in a List of indices
        List<int> nextMoves = generateMoves();

        //  Maximizing playerSymbol, while minimize opponentSymbol
        int bestScore = (player == playerSymbol) ? int.MinValue : int.MaxValue;
        int currentScore;
        int bestIndex = -1;

        if (nextMoves.Count == 0 || depth == 0) {
            // No next moves, or depth reached, evaluate score
            bestScore = evaluate();
        } else {
            foreach (int move in nextMoves) {
                // Try this move for current player
                cells[move] = player;
                if (player == playerSymbol) {
                    // Maximizing playerSymbol (i.e. AI player)
                    currentScore = minimax(depth - 1, opponentSymbol)[0];
                    if (currentScore > bestScore) {
                        bestScore = currentScore;
                        bestIndex = move;
                    }
                } else {
                    // Minimizing playerSymbol (i.e. AI player)
                    currentScore = minimax(depth - 1, playerSymbol)[0];
                    if (currentScore < bestScore) {
                        bestScore = currentScore;
                        bestIndex = move;
                    }
                }
                // Undo move
                cells[move] = CellContent.EMPTY;
            }
        }
        return new int[] { bestScore, bestIndex};
    }

    // Find all valid next moves
    private List<int> generateMoves() {
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
    private int evaluate() {
        int score = 0;
        // Evaluate score for each of the 8 cell combinations (3 rows, 3 columns, 2 diagonals)
        score += evaluateLine(0, 1, 2);  // row 0
        score += evaluateLine(3, 4, 5);  // row 1
        score += evaluateLine(6, 7, 8);  // row 2
        score += evaluateLine(0, 3, 6);  // col 0
        score += evaluateLine(1, 4, 7);  // col 1
        score += evaluateLine(2, 5, 8);  // col 2
        score += evaluateLine(0, 4, 8);  // diagonal 1
        score += evaluateLine(2, 4, 6);  // diagonal 2
        return score;
    }

    // Heuristic evaluation function for the game board
    //  Return +100, +10, +1 for EACH 3-, 2-, 1-in-a-line for currentPlayer (i.e. AI)
    //         -100, -10, -1 for EACH 3-, 2-, 1-in-a-line for opponentPlayer
    //          0 otherwise
    private int evaluateLine(int cell1, int cell2, int cell3) {
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