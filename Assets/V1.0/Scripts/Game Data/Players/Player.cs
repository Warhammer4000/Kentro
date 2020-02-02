
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
        public bool IsMyTurn;

        public List<IPowerUp> PowerUps;
       
        [SerializeField]private int _numberOfPawn = 3;
       
        //todo
        public Player()
        {
            Pawns=new List<PawnLogic>();
            

        }



    }
}
