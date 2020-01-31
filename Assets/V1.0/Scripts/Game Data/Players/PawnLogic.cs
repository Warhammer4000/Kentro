
using System.Collections;
using System.Diagnostics.Contracts;
using UnityEngine;

namespace Kentro
{
    public class PawnLogic:MonoBehaviour
    {
        private bool IsSelected;
        private bool IsMoving;
        [Header("Configs")]
        [SerializeField] private float speed = 1f;
        [SerializeField] private  float _framewait = 0.1f;
        public Card Card { get; set; }
        private Vector3 _targetPosition;
        [SerializeField]private Animator _animator;


        public delegate void PawnSelectionEvent();

        public PawnSelectionEvent OnPawnSelection;


        public void Move(Card card)
        {
            _targetPosition = card.WorldPos;
            Card.SetPawn(null);
            Card = card;
            Card.SetPawn(this);
            if(IsMoving)return;
            IsMoving = true;
            StartCoroutine(MoveRoutine());
        }

        public void SelectPawn()
        {
            IsSelected = true;
            _animator.SetBool("Hovering",IsSelected);
            OnPawnSelection?.Invoke();
        }

        public void DeselectPawn()
        {
            IsSelected = false;
            _animator.SetBool("Hovering", IsSelected);
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