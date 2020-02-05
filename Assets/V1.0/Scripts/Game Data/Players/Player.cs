
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
        
        public Dictionary<PowerupEnum,int> PowerUps;
        [SerializeField]private int _numberOfPawn = 3;
        
        public int Score = 0;
       
        //todo
        public Player()
        {
            Pawns=new List<PawnLogic>();
            PowerUps = new Dictionary<PowerupEnum, int>();
            PowerUps.Add(PowerupEnum.ChangeNumber, 0);
            PowerUps.Add(PowerupEnum.Freeze, 0);
            PowerUps.Add(PowerupEnum.ShowCard, 0);
            PowerUps.Add(PowerupEnum.ShuffleAll, 0);
            PowerUps.Add(PowerupEnum.Swap, 0);
        }


    }
}
