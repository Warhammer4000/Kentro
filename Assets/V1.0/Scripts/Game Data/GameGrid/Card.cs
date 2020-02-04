﻿
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
        public bool isCenter;
        public bool blocked;
        
        //todo


        public delegate void CardEvent();
        public delegate void CardChangeEvent(int value);

        public CardEvent OnCardReveal;
        public CardEvent OnCardHide;
        public CardEvent OnCardHover;
        public CardEvent OnCardIdle;
        public CardChangeEvent OnCardChange;

        public Card(Position position)
        {
            Position = position;
            flipped = false;
        }

        public void ChangeNumber(int Value)
        {
            value = Value;
            OnCardChange?.Invoke(value);
        }

        public void Reveal()
        {
            if (flipped) return;
            value = new Random().Next(1, 5);
            OnCardReveal?.Invoke();
            flipped = true;
            blocked = false;
            
            if (PowerUpFactory.Instance.ListPowerUps.Count != 0)
            {
                powerup = PowerUpFactory.Instance.ListPowerUps.Pop();
            }
            else
            {
                powerup = new PNone();
            }
            Debug.Log(powerup.getType().ToString());
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
