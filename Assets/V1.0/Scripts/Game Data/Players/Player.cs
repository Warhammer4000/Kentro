
using System;
using System.Collections.Generic;
using UnityEngine;


namespace Kentro
{
    [Serializable]
    public class Player
    {
        public PlayerEnum PlayerId;
        public GameObject PawnPrefab;
        public List<PawnLogic> Pawns;

        public List<IPowerUp> PowerUps;
       
        [SerializeField]private int _numberOfPawn = 3;
       
        //todo
        public Player()
        {
            Pawns=new List<PawnLogic>();
            /*this.PlayerId = playerId;
            pawn = new List<PawnLogic>();
            for(int i = 0; i<NumberOfPawn; i++)
                pawn.Add(new PawnLogic(x,y));
            PowerUps = new List<IPowerUp>();*/
        }


    }
}
