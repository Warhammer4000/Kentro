
using Kentro;
using UnityEngine;

public class ClickManager : MonoBehaviour
{
    [SerializeField] private string CardTag = "Card";
    [SerializeField] private string PawnTag = "Pawn";

    private PawnLogic _selectedPawn;
    private bool turn = true;

    void Update()
    {
        if (!Input.GetMouseButtonDown(0)) return;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out var hit, 100.0f))
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
                        
                    }
                }

                if (behaviour.Card.Pawn != null && turn == behaviour.Card.Pawn.player.isMyTurn)
                {
                    _selectedPawn= behaviour.Card.Pawn;
                    _selectedPawn.SelectPawn();
                    turn = !turn;
                    return;
                }
            }

            if (hit.transform.tag == PawnTag)
            {
                PawnLogic pawn = hit.transform.GetComponent<PawnLogic>();
                
                pawn.SelectPawn();
                
            }
        }
    }


   

}
