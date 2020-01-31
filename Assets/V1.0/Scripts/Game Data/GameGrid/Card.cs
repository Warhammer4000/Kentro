

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
        public bool IsHovering;
        public IPowerUp powerup;
        public PawnLogic Pawn;
        //todo
        //private PowerUpFactory powerFactory;

        public delegate void CardEvent();

        public CardEvent OnCardReveal;
        public CardEvent OnCardHide;
        public CardEvent OnCardHover;
        public CardEvent OnCardIdle;

        public Card(Position position)
        {
            Position = position;
            flipped = false;
        }

        public void Reveal()
        {
           
            value = new Random().Next(1, 7);
            OnCardReveal?.Invoke();
            flipped = true;
        }

        public void Hide()
        {
            flipped = false;
            OnCardHide?.Invoke();
        }

        public void Hover()
        {
            IsHovering = true;
            OnCardHover?.Invoke();
        }

        public void Idle()
        {
            IsHovering = false;
            OnCardIdle?.Invoke();
        }

        public void SetPawn(PawnLogic pawn)
        {
            Pawn = pawn;
        }

        
    }
}
