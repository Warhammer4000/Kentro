
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;

namespace Kentro
{
    public class PawnLogic:MonoBehaviour
    {
        private bool IsSelected;
        private bool IsMoving;
        [Header("Configs")]
        [SerializeField] private float speed = 1f;

        private float CurrentSpeed;
        private  float _framewait = 0f;
        public Card Card;
        public Player Player;
        private Vector3 _targetPosition;
        [SerializeField]private Animator _animator;
        List<Card> validCards;

        public delegate void PawnSelectionEvent();

        public PawnSelectionEvent OnPawnSelection;


        public void Move(Card card)
        {
            if (IsMoving) return;
            IsMoving = true;

            MakeCardsIdle();
            _targetPosition = card.WorldPos;
            Card.SetPawn(null);
            CurrentSpeed = Card.value;
            Card = card;
            Card.SetPawn(this);
            StartCoroutine(MoveRoutine());
            
        }

        public void SelectPawn()
        {
            IsSelected = true;
            _animator.SetBool("Hovering",IsSelected);
            OnPawnSelection?.Invoke();
            if(IsMoving)return;
            SuggestMoves();
        }

        public void DeselectPawn()
        {
            IsSelected = false;
            _animator.SetBool("Hovering", IsSelected);
            MakeCardsIdle();
        }


        private void SuggestMoves()
        {
            validCards = GetValidCards();
            foreach (var card in validCards)
            {
                card.Hover();
            }
        }

        private void MakeCardsIdle()
        {
            if(validCards==null)return;
            foreach (var card in validCards)
            {
                card.Idle();
            }
            validCards.Clear();
        }


        private List<Card> GetValidCards()
        {
            List<Card> cards=new List<Card>();

            int distance = Card.value;
            Position currentPosition = Card.Position;
            Position[] possibleMovingPositions=new Position[4];

            possibleMovingPositions[0]=new Position(currentPosition.X+distance, currentPosition.Y);
            possibleMovingPositions[1] = new Position(currentPosition.X-distance, currentPosition.Y);
            possibleMovingPositions[2] = new Position(currentPosition.X, currentPosition.Y+distance);
            possibleMovingPositions[3] = new Position(currentPosition.X, currentPosition.Y-distance);

            foreach (var position in possibleMovingPositions)
            {
                var card = GameManager.Instance.GetCard(position);
                if(card==null)continue;
                cards.Add(card);
            }

            return cards;
        }

        IEnumerator MoveRoutine()
        {
            while (transform.position!=_targetPosition)
            {
                yield return new WaitForSeconds(_framewait);
                float step = CurrentSpeed * speed* Time.deltaTime; // calculate distance to move
                transform.position = Vector3.MoveTowards(transform.position, _targetPosition, step);
            }

            IsMoving = false;
            DeselectPawn();
        }

    }
}