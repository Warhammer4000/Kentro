
using System.Collections;
using System.Collections.Generic; 
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
        private Vector3 _targetPosition;
        public Vector3 position;
        [SerializeField]private Animator _animator;
        List<Card> validCards;
        public Player player;
        public Card defaultCard;
        public bool frozen;

        public delegate void PawnSelectionEvent();

        public PawnSelectionEvent OnPawnSelection;

        //this
        public void Move(Card card)//porer
        {
            if (IsMoving) return;
            IsMoving = true;
            MakeCardsIdle();
            if(card.Pawn != null)
            {
                killPawn(card);
            }
            _targetPosition = card.WorldPos;
            Card.SetPawn(null);
            CurrentSpeed = Card.value;

            if(card.powerup.getType() != PowerupEnum.None)
            {
                player.PowerUps.Add(card.powerup);
                card.powerup = new PNone();
            }


            Card = card;
            Card.SetPawn(this);
            StartCoroutine(MoveRoutine());
            if (Card.isCenter == true)
            {
                ScoreManager.Instance.GoalScoreAdd(player);
                Card.Pawn = null;
            }
            
            //Test
            if (player.PowerUps.Count != 0)
            {
                Debug.Log(player.PlayerId.ToString());
                Debug.Log(player.PowerUps[player.PowerUps.Count - 1].getType().ToString());
            }
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
            if (Card.isCenter) return;
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
        }


        private List<Card> GetValidCards()
        {
            List<Card> cards=new List<Card>();

            int distance = Card.value;
            Position currentPosition = Card.Position;
            Position[] possibleMovingPositions=new Position[4];

            possibleMovingPositions[0]=new Position(currentPosition.X+distance, 
                currentPosition.Y);
            possibleMovingPositions[1] = new Position(currentPosition.X-distance,
                currentPosition.Y);
            possibleMovingPositions[2] = new Position(currentPosition.X,
                currentPosition.Y+distance);
            possibleMovingPositions[3] = new Position(currentPosition.X,
                currentPosition.Y-distance);

            foreach (var position in possibleMovingPositions)
            { 
                var card = GameManager.Instance.GetCard(position);
                if(card==null) continue;
                if (card.Pawn != null && card.Pawn.player == player) continue;
                cards.Add(card);
            }

            return cards;
        }

        IEnumerator MoveRoutine()
        {
            while (transform.position!=_targetPosition)
            {
                yield return new WaitForSeconds(_framewait);
                float step = CurrentSpeed * speed* Time.deltaTime; 
                // calculate distance to move
                transform.position = Vector3.MoveTowards(transform.position, _targetPosition, step);
            }

            IsMoving = false;
            DeselectPawn();
            validCards.Clear();
        }

        private void killPawn(Card card)
        {
            card.Pawn.transform.position = card.Pawn.defaultCard.WorldPos;
            card.Pawn.Card = card.Pawn.defaultCard;
            card.Pawn.defaultCard.Pawn = card.Pawn;
            ScoreManager.Instance.HitScoreAdd(player);

        }

    }
}