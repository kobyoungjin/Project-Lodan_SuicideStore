using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class MiniMax : MonoBehaviour
{
    private GameStatus gameStatus;
    // Start is called before the first frame update
    void Start()
    {
        gameStatus = GameObject.Find("Tic Tac Toe").GetComponent<GameStatus>();
        gameStatus.MiniMaxNextMove += BestMove;
    }

    private void BestMove(string[,] board) // checks every possible next move
    {
        int bestScore = int.MinValue;
        Point bestMove;
        for (int x = 0; x < 3; x++)
        {
            for (int y = 0; y < 3; y++)
            {
                if (board[x, y] == "")
                {
                    board[x, y] = "O";
                    int score = CalculateMiniMax(board, 0, false);
                    board[x, y] = "";
                    if (score > bestScore) // Keeps the best trees first move as the next move untill every possible state has been evaluated
                    {
                        bestScore = score;
                        bestMove = new Point(x, y);
                    }
                }
            }
        }
        UpdateBestMoveCell(bestMove);
    }

    // recusivley check every possilbe next move and moves after that untill game end
    private int CalculateMiniMax(string[,] boardStatus, int depth, bool isMaximizing)
    {
        string result = gameStatus.CheckForWinner(boardStatus);
        if (result != null)
        {
            if (result == "X")
                return -10;
            else if (result == "O")
                return 10;
            else if (result == "tie")
                return 0;
        }
        if (isMaximizing) // gets next best move
        {
            int bestScore = int.MinValue;
            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    if (boardStatus[x, y] == "")
                    {
                        boardStatus[x, y] = "O";
                        int score = CalculateMiniMax(boardStatus, depth++, !isMaximizing);
                        boardStatus[x, y] = "";
                        bestScore = Math.Max(bestScore, score);
                    }
                }
            }
            return bestScore;
        }
        else // gets next worst move
        {
            int bestScore = int.MaxValue;
            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    if (boardStatus[x, y] == "")
                    {
                        boardStatus[x, y] = "X";
                        int score = CalculateMiniMax(boardStatus, depth++, !isMaximizing);
                        boardStatus[x, y] = "";
                        bestScore = Math.Min(bestScore, score);
                    }
                }
            }
            return bestScore;
        }
    }
    private void UpdateBestMoveCell(Point bestMove) // Changes 2d array format to list of 9 game cells
    {
        int cellNumber = bestMove.X + bestMove.Y * 3;
        TicTacToeCellManager ticTacToeCellManager = transform.GetChild(cellNumber).GetComponent<TicTacToeCellManager>();
        ticTacToeCellManager.UpdateCellStatus();
    }
}
