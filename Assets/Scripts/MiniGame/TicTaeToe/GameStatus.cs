using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class GameStatus : MonoBehaviour
{
    public Action<string[,]> MiniMaxNextMove = null;
    private TurnOrder turnOrder;
    public List<Transform> UsedCells;
    public bool GameStarted;
    public bool XTurn;
    public bool GameEnded;
    private string[,] BoardStatus = new string[3, 3] {{"","",""}, // Board cell structure
                                                      {"","",""},
                                                      {"","",""}};

    private Text gameEndingText;

    // Start is called before the first frame update
    void Start()
    {
        turnOrder = GameObject.Find("Tic Tac Toe/Change Turn Order Button").GetComponent<TurnOrder>();
        gameEndingText = GameObject.Find("Tic Tac Toe/Game Ending Text").GetComponent<Text>();
        GameEnded = false;
        GameStarted = false;
        XTurn = true;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartGame();
        }
    }


    public void AddGridCell(Transform transform)
    {
        UsedCells.Add(transform); // Gets used to reset the grids that where updated.
        transform.GetComponent<TicTacToeCellManager>().boardUpdate += UpdateGameStatus;
    }

    public void UpdateGameStatus(Point clickedCell, string player) // Gets called when a cell is clicked to update turn order and make sure the game is started.
    {
        GameStarted = true;
        UpdateBoardStatus(clickedCell, player);
        XTurn = !XTurn;
        string result = CheckForWinner(BoardStatus);
        if (result != null)
        {
            HandelGameEnding(result);
        }
        if (!XTurn && !GameEnded)
        {
            MiniMaxNextMove?.Invoke(BoardStatus);
        }
    }

    private void UpdateBoardStatus(Point clickedCell, string player)
    {
        BoardStatus[clickedCell.X, clickedCell.Y] = player;
    }

    public string CheckForWinner(string[,] boardStatus) // Checks Tic Tac Toe rules if there is a winner and resturns corresponding value for game result
    {
        string winner = null;
        for (int i = 0; i < 3; i++)
        {
            if (ThreeEqualSymbols(boardStatus[i, 0], boardStatus[i, 1], boardStatus[i, 2])) // Check if any rows are equal 
            {
                winner = boardStatus[i, 0];
            }
            if (ThreeEqualSymbols(boardStatus[0, i], boardStatus[1, i], boardStatus[2, i])) // Check if any colums are equal
            {
                winner = boardStatus[0, i];
            }
        }
        if (ThreeEqualSymbols(boardStatus[0, 0], boardStatus[1, 1], boardStatus[2, 2]) // Check both diagnals if equal
                || ThreeEqualSymbols(boardStatus[0, 2], boardStatus[1, 1], boardStatus[2, 0]))
        {
            winner = boardStatus[1, 1];
        }
        if (!boardStatus.OfType<string>().Any(x => x == "") && winner == null) // Checks if there are no spaces to be filled
        {
            return "tie";
        }
        else
        {
            return winner;
        }
    }

    private bool ThreeEqualSymbols(string a, string b, string c) // Checks if there is 3 equal values and no blanks
    {
        return (a == b && b == c) && a != "";
    }

    private void HandelGameEnding(string result) // Handles text to convey game conclution to player
    {
        GameEnded = true;
        if (result == "tie")
            gameEndingText.text = "<color=#ffa500ff><b><size=100>무승부</size></b></color>\n<size=50><color=#808080ff>R을 눌러 재시작</color></size>";
        else if (result == "X") // Can be commented out because it's imposible to win
            gameEndingText.text = "<color=#008000ff><b><size=100>승리</size></b></color>\n<size=50><color=#808080ff>R을 눌러 재시작</color></size>";
        else
            gameEndingText.text = "<color=#ff0000ff><b><size=100>패배</size></b></color>\n<size=50><color=#808080ff>R을 눌러 재시작</color></size>";
    }
    private void RestartGame() // Resets all the values for a fresh game
    {
        GameEnded = false;
        GameStarted = false;
        XTurn = true;
        gameEndingText.text = "";
        for (int x = 0; x < 3; x++)
        {
            for (int y = 0; y < 3; y++)
            {
                BoardStatus[x, y] = "";
            }
        }
        foreach (Transform cell in UsedCells)
        {
            cell.GetComponent<TicTacToeCellManager>().ClearCells();
        }
        turnOrder.turnImage.sprite = Resources.Load<Sprite>("TicTaeToe/X");
    }
}
