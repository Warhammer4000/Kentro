using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kentro;

public class ButtonManger : MonoBehaviour
{
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
