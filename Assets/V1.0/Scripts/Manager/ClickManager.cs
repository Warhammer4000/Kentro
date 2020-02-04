using Kentro;
using System.Collections.Generic;
using UnityEngine;

public class ClickManager : MonoBehaviour
{
    [SerializeField] private string CardTag = "Card";
    [SerializeField] private string PawnTag = "Pawn";

    public PawnLogic _selectedPawn;
    private bool turn = true;
    public PowerupEnum state;

    private Card swap1, swap2;

    public static ClickManager Instance { get; set; }

    void Awake()
    {

        if (Instance == null)
        {
            Instance = this;
            state = PowerupEnum.None;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {

        if (!Input.GetMouseButtonDown(0)) return;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out var hit, 100.0f))
        {
        
            if(PowerupEnum.None == state) 
            { 

            if (hit.transform.tag == CardTag)
            {
                CardBehaviour behaviour = hit.transform.GetComponent<CardBehaviour>();
                
                if (_selectedPawn != null)
                {
                    if (behaviour.Card.IsHovering)
                    {
                        behaviour.Card.Reveal();
                        _selectedPawn.Move(behaviour.Card);
                        turn = !turn;
                    }
                }

                if (behaviour.Card.Pawn != null && turn == 
                    behaviour.Card.Pawn.player.isMyTurn)
                {
                    _selectedPawn= behaviour.Card.Pawn;
                    _selectedPawn.SelectPawn();
                    return;
                }
            } 
        }

            if(PowerupEnum.Swap == state)
            {
                if (hit.transform.tag == CardTag)
                {
                    CardBehaviour behaviour = hit.transform.GetComponent<CardBehaviour>();
                    if (behaviour.Card.Pawn == null && behaviour.Card.flipped)
                    {
                        if(swap1 == null)
                        {
                            swap1 = behaviour.Card;
                            swap1.Hover();
                        }
                        else
                        {
                            swap2 = behaviour.Card;
                            IPowerUp power = new PSwap();
                            List<Card> l = new List<Card>();
                            l.Add(swap1);l.Add(swap2);
                            power.Operation(l, 0);
                            swap1 = null;
                            swap2 = null;
                            state = PowerupEnum.None;

                        }
                    }
                }
            }
           
    }
}
    


   

}
