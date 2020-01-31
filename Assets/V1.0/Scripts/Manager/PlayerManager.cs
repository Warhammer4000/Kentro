
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

        SpawnPawn(Player1,PlayerOnePawns);
        SpawnPawn(Player2,PlayerTwoPawns);




    }

    private void SpawnPawn(Player player, List<Position> pawnPositions)
    {
        foreach (var position in pawnPositions)
        {
            Card card = GameManager.Instance.GetCard(position);
            card.value = 1;
            var pawnInstance = Instantiate(player.PawnPrefab, card.WorldPos, Quaternion.identity);
            card.SetPawn(pawnInstance.GetComponent<PawnLogic>());
            pawnInstance.GetComponent<PawnLogic>().Card = card;

            player.Pawns.Add(pawnInstance.GetComponent<PawnLogic>());
        }

        //todo we can do better
        for (int i = 0; i < player.Pawns.Count; i++)
        {
            for (int j = 0; j < player.Pawns.Count; j++)
            {
                if(i==j)continue;
                player.Pawns[i].OnPawnSelection += player.Pawns[j].DeselectPawn;

            }
        }
    }


}
