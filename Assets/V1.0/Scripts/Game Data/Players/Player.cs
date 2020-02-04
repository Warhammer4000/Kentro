
using System;
using System.Collections.Generic;
using UnityEngine;


namespace Kentro
{
    [Serializable]
    public class Player
    {
        
        public GameObject PawnPrefab;
        public List<PawnLogic> Pawns;
        public PlayerEnum PlayerId;
        

        public List<IPowerUp> PowerUps;
       
        [SerializeField]private int _numberOfPawn = 3;
        
        public int Score = 0;
       
        //todo
        public Player()
        {
            Pawns=new List<PawnLogic>();
            PowerUps = new List<IPowerUp>();
        }


    }
}
