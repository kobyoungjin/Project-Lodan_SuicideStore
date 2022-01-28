using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.UI;

public class TurnOrder : MonoBehaviour
{
    private GameStatus gameStatus;
    private Button ChangeTurnOrderButton;
    public Image turnImage;

    private void Start()
    {
        gameStatus = GameObject.Find("Tic Tac Toe").GetComponent<GameStatus>();
        turnImage = GameObject.Find("Tic Tac Toe/Change Turn Order Button/Image").GetComponent<Image>();
        turnImage.sprite = Resources.Load<Sprite>("MiniGame/TicTaeToe/X");
        ChangeTurnOrderButton = transform.gameObject.GetComponent<Button>();
        ChangeTurnOrderButton.onClick.AddListener(this.ChangeTurnOrder);
    }

    public void ChangeTurnOrder()
    {
        if (!gameStatus.GameStarted)
        {
            gameStatus.UpdateGameStatus(new Point(0, 0), "");
            turnImage.sprite = Resources.Load<Sprite>("MiniGame/TicTaeToe/O");
        }
    }
}
