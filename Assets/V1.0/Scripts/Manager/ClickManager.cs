
using Kentro;
using UnityEngine;

public class ClickManager : MonoBehaviour
{
    [SerializeField] private string CardTag = "Card";
    [SerializeField] private string PawnTag = "Pawn";

    private PawnLogic _selectedPawn;

    void Update()
    {
        if (!Input.GetMouseButtonDown(0)) return;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out var hit, 100.0f))
        {
           
            if (hit.transform.tag == CardTag)
            {
                CardBehaviour behaviour = hit.transform.GetComponent<CardBehaviour>();
                Debug.Log(behaviour.Card.Pawn.Player.IsMyTurn );


                if (behaviour.Card.Pawn != null )
                {
                    //Debug.Log("Here is pawn");
                    _selectedPawn = behaviour.Card.Pawn;
                    _selectedPawn.SelectPawn();

                    return;
                }

                if (_selectedPawn != null)
                {
                    if (behaviour.Card.IsHovering)
                    {
                        //Debug.Log("Here is card");

                        behaviour.Card.Reveal();
                        _selectedPawn.Move(behaviour.Card);
                        _selectedPawn = null;
                    }
                }

               


              
                

                


            }

            //if (hit.transform.tag == PawnTag)
            //{
            //    PawnLogic pawn = hit.transform.GetComponent<PawnLogic>();
                
            //    pawn.SelectPawn();
                
            //}
        }
    }


   

}
