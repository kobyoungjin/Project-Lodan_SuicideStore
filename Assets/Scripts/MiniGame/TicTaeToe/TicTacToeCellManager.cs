using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.UI;

public class TicTacToeCellManager : MonoBehaviour
{
    private GameStatus gameStatus;
    private Button CellStatusButton;
    private Image CellImage;
    private int cellNumber;
    private bool cellEmpty;
    public Action<Point, String> boardUpdate = null;
    // Start is called before the first frame update
    void Start()
    {
        cellNumber = int.Parse(transform.name[6].ToString());
        CellImage = transform.GetChild(1).GetComponent<Image>();
        CellStatusButton = transform.GetChild(0).GetComponent<Button>();
        CellStatusButton.onClick.AddListener(PlayerInput);
        cellEmpty = true;
        gameStatus = GameObject.Find("Tic Tac Toe").GetComponent<GameStatus>();
        gameStatus.AddGridCell(transform);
    }

    private void PlayerInput()
    {
        if (gameStatus.XTurn)
        {
            UpdateCellStatus();
        }
    }

    public void UpdateCellStatus() // Updates the data for the cell
    {
        Point clickedCell;
        string player;
        if (cellEmpty && !gameStatus.GameEnded)
        {
            if (gameStatus.XTurn)
            {
                CellImage.sprite = Resources.Load<Sprite>("TicTaeToe/X");
                player = "X";
            }
            else
            {
                CellImage.sprite = Resources.Load<Sprite>("TicTaeToe/O");
                player = "O";
            }
            clickedCell = new Point(cellNumber % 3, Convert.ToInt32(Math.Floor(cellNumber / 3.0)) % 3); // Calculates where the cell should be in the array
            boardUpdate?.Invoke(clickedCell, player); // Gets used to update game turn order and make sure the game has started
            CellImage.enabled = true;
        }
        cellEmpty = false;
    }

    public void ClearCells() // Clears this particular cells data
    {
        cellEmpty = true;
        CellImage.sprite = null;
        CellImage.enabled = false;
    }
}
