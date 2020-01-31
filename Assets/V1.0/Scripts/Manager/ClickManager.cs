
using Kentro;
using UnityEngine;

public class ClickManager : MonoBehaviour
{
    [SerializeField] private string CardTag = "Card";
    [SerializeField] private string PawnTag = "Pawn";
    //public PlayerManager PlayerManager;
    void Update()
    {
        if (!Input.GetMouseButtonDown(0)) return;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out var hit, 100.0f))
        {
           
            if (hit.transform.tag == CardTag)
            {
                CardBehaviour behaviour = hit.transform.GetComponent<CardBehaviour>();

                if (behaviour.Card.Pawn != null)
                {
                    behaviour.Card.Pawn.SelectPawn();
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


    private bool isValid(Card pawnCard,Card target)
    {
        if (pawnCard.Position.X + pawnCard.value == target.Position.X && pawnCard.Position.Y == target.Position.Y)
            return true;
        else if (pawnCard.Position.X - pawnCard.value == target.Position.X && pawnCard.Position.Y == target.Position.Y)
            return true;
        else if (pawnCard.Position.Y + pawnCard.value == target.Position.Y && pawnCard.Position.X == target.Position.X)
            return true;
        else if (pawnCard.Position.Y - pawnCard.value == target.Position.Y && pawnCard.Position.X == target.Position.X)
            return true;
        return false;
    }

}
