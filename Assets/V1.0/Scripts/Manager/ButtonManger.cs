﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kentro;
using UnityEngine.UI;

public class ButtonManger : MonoBehaviour
{
    //[SerializeField] private GameObject ShuffleAll;
    public Button player1ShuffleAll;
    public Button player2ShuffleAll;
    public Button player1Swap;
    public Button player2Swap;
    public Button player1Freeze;
    public Button player2Freeze;
    public Button player1ChangeNumber;
    public Button player2ChangeNumber;
    public Button player1ShowCard;
    public Button player2ShowCard;

    private void Update()
    {
        if (ClickManager.Instance.turn == PlayerEnum.Player1)
        {
            player1ShowCard.interactable = true;
            player2ShowCard.interactable = false;
            player1ShuffleAll.interactable = true;
            player2ShuffleAll.interactable = false;
            player1Swap.interactable = true;
            player2Swap.interactable = false;
            player1Freeze.interactable = true;
            player2Freeze.interactable = false;
            player1ChangeNumber.interactable = true;
            player2ChangeNumber.interactable = false;
        }
        else
        {
            player1ShowCard.interactable = false;
            player2ShowCard.interactable = true;
            player1ShuffleAll.interactable = false;
            player2ShuffleAll.interactable = true;
            player1Swap.interactable = false;
            player2Swap.interactable = true;
            player1Freeze.interactable = false;
            player2Freeze.interactable = true;
            player1ChangeNumber.interactable = false;
            player2ChangeNumber.interactable = true;
        }
    }

    public void ShowCard()
    {
        
        List<Card> NeedToShow = ClickManager.Instance._selectedPawn.validCards;
        IPowerUp power = new PShow();
        power.Operation(NeedToShow, 0);

    }
    public void ChangeNumber()
    {
        
        List<Card> NeedToShow = new List<Card>();
        NeedToShow.Add(ClickManager.Instance._selectedPawn.Card);
        IPowerUp power = new PChangeNumber();
        power.Operation(NeedToShow, 2);
        ClickManager.Instance._selectedPawn.DeSuggestMoves();
        ClickManager.Instance._selectedPawn.SelectPawn();


    }
    public void ShuffleAll()
    {

        List<Card> NeedToShow = GameManager.Instance._gameGrid.Cards;
        IPowerUp power = new PShuffleAll();
        power.Operation(NeedToShow, 0);

    }
    public void SwapNumber()
    {

        ClickManager.Instance.state = PowerupEnum.Swap;

    }
    public void FreezePawn()
    {
        ClickManager.Instance.state = PowerupEnum.Freeze;
    }
}
