
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
            //Debug.Log(hit.transform.name);
            if (hit.transform.tag == CardTag)
            {
                CardBehaviour behaviour = hit.transform.GetComponent<CardBehaviour>();

                if (behaviour.Card.Pawn != null)
                {
                    behaviour.Card.Pawn.IsSelected = behaviour.Card.Pawn.IsSelected == false;
                    return;
                }
                for (int i = 0; i < 3; i++)
                {
                    switch (PlayerManager.Instance.Player2.Pawns[i].IsSelected)
                    {
                        case true when isValid(PlayerManager.Instance.Player2.Pawns[i].Card, behaviour.Card):
                            behaviour.RevealCard();
                            PlayerManager.Instance.Player2.Pawns[i].Card.SetPawn(null);
                            PlayerManager.Instance.Player2.Pawns[i].Move(behaviour.Card.WorldPos);
                            PlayerManager.Instance.Player2.Pawns[i].Card = behaviour.Card;
                            behaviour.Card.SetPawn(PlayerManager.Instance.Player2.Pawns[i]);
                            return;
                    }
                }
                

                //behaviour.RevealCard();


            }

            if (hit.transform.tag == PawnTag)
            {
                //CardBehaviour behaviour = hit.transform.GetComponent<CardBehaviour>();
                PawnLogic pawn = hit.transform.GetComponent<PawnLogic>();
                //behaviour.RevealCard();
                if (pawn.IsSelected == false)
                {
                    pawn.IsSelected = true;
                    //Debug.Log();
                } 
                    
                else
                {
                    pawn.IsSelected = false;
                }
                //Debug.Log("Clicked it");
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
