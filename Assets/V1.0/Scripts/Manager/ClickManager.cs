using Kentro;
using System.Collections.Generic;
using UnityEngine;

public class ClickManager : MonoBehaviour
{
    [SerializeField] private string CardTag = "Card";
    [SerializeField] private string PawnTag = "Pawn";

    public PawnLogic _selectedPawn;
    public PlayerEnum turn;
    public PowerupEnum state;


    private Card swap1, swap2;

    public static ClickManager Instance { get; set; }

    void Awake()
    {

        if (Instance == null)
        {
            Instance = this;
            state = PowerupEnum.None;
            turn = PlayerEnum.Player1;
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

            if (PowerupEnum.None == state)
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
                            if (turn == PlayerEnum.Player1) turn = PlayerEnum.Player2;
                            else turn = PlayerEnum.Player1;
                        }
                    }

                    if (behaviour.Card.Pawn != null && turn ==
                        behaviour.Card.Pawn.player.PlayerId)
                    {
                        _selectedPawn = behaviour.Card.Pawn;
                        _selectedPawn.SelectPawn();
                        return;
                    }
                }
            }

            if (PowerupEnum.Swap == state)
            {
                if (hit.transform.tag == CardTag)
                {
                    CardBehaviour behaviour = hit.transform.GetComponent<CardBehaviour>();
                    if (behaviour.Card.Pawn == null && behaviour.Card.flipped)
                    {
                        if (swap1 == null)
                        {
                            swap1 = behaviour.Card;
                        }
                        else
                        {
                            swap2 = behaviour.Card;
                            IPowerUp power = new PSwap();
                            List<Card> list = new List<Card>();
                            list.Add(swap1);
                            list.Add(swap2);
                            power.Operation(list, 0);
                            swap1 = null;
                            swap2 = null;
                            state = PowerupEnum.None;
                        }
                    }
                }
            }
            if (PowerupEnum.Freeze == state)
            {
                if (hit.transform.tag == CardTag)
                {
                    CardBehaviour behaviour = hit.transform.GetComponent<CardBehaviour>();
                    if (behaviour.Card.Pawn != null && behaviour.Card.Pawn.player.PlayerId
                        !=
                        turn)
                    {
                        IPowerUp power = new PFreeze();
                        List<Card> list = new List<Card>();
                        list.Add(behaviour.Card);
                        power.Operation(list, 0);
                        state = PowerupEnum.None;
                       
                    }
                }

            }
        }


    }
   

}
