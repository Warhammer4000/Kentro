
using System.Collections;
using System.Diagnostics.Contracts;
using UnityEngine;

namespace Kentro
{
    public class PawnLogic:MonoBehaviour
    {
        public bool IsSelected;
        [SerializeField]private bool IsMoving;
        [SerializeField] private float speed = 1f;
        [SerializeField] private  float _framewait = 0.1f;
        public Card Card { get; set; }
        private Vector3 _targetPosition;


        public void Move(Card card)
        {
            _targetPosition = Card.WorldPos;
            Card.SetPawn(null);
            Card = card;
            Card.SetPawn(this);
            if(IsMoving)return;
            IsMoving = true;
            StartCoroutine(MoveRoutine());
        }

        IEnumerator MoveRoutine()
        {
            while (transform.position!=_targetPosition)
            {
                yield return new WaitForSeconds(_framewait);
                float step = speed * Time.deltaTime; // calculate distance to move
                transform.position = Vector3.MoveTowards(transform.position, _targetPosition, step);
                IsSelected = false;
            }

            IsMoving = false;
        }

    }
}