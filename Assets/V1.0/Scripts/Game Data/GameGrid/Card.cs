

using System;
using UnityEngine;
using Random = System.Random;

namespace Kentro
{
    [Serializable]
    public class Card
    {
        public int value;
        public Position Position;
        public Vector3 WorldPos;
        public bool flipped;
        public IPowerUp powerup;
        public PawnLogic Pawn;
        //todo
        private PowerUpFactory powerFactory;

        public Card(Position position,Vector3 worldPos)
        {

            //value = new Random().Next(1,7);
            Position = position;
            flipped = false;
            WorldPos = worldPos;
            /*powerFactory = new PowerUpFactory();

            switch (powerFactory.ListPowerUps.Count)
            {
                case 0:
                    powerup = new PNone();
                    break;
                default:
                    powerup = powerFactory.ListPowerUps.Peek();
                    powerFactory.ListPowerUps.Pop();
                    break;
            }*/

        }

        public void Flip()
        {
            flipped = !flipped;
            value = new Random().Next(1, 7);
        }

        /*public Card(PlayerEnum player, int value)
        {
            this.value = value;
            pawnOwner = player;
            flipped = true;
            powerup = new PNone();
            
        }*/
    }
}
