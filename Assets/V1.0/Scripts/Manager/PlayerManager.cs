
using System.Collections.Generic;
using Kentro;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    public static PlayerManager Instance;


    public Player Player1;
    public Player Player2;

    public Vector3 HeightOffset;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }


    

    public List<Position> PlayerOnePawns;
    public List<Position> PlayerTwoPawns;

    public void CreatePawns()
    {
        PlayerOnePawns = GameManager.Instance.GetPlayer1PawnPositions();


        PlayerTwoPawns = GameManager.Instance.GetPlayer2PawnPositions();

        foreach (var pawns in PlayerOnePawns)
        {
            Card card = GameManager.Instance.GetCard(pawns);
            var pawnInstance=Instantiate(Player1.PawnPrefab, card.WorldPos, Quaternion.identity);
            Player1.Pawns.Add(pawnInstance.GetComponent<PawnLogic>());
        }


        foreach (var pawns in PlayerTwoPawns)
        {
            Card card = GameManager.Instance.GetCard(pawns);
            var pawnInstance = Instantiate(Player2.PawnPrefab, card.WorldPos+HeightOffset, Quaternion.identity);
            Player2.Pawns.Add(pawnInstance.GetComponent<PawnLogic>());
        }

    }




}
