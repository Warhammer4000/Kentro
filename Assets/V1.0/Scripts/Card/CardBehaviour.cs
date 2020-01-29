using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardBehaviour : MonoBehaviour
{
    [SerializeField]private Animator _animator;

    void Start()
    {
        _animator = gameObject.GetComponent<Animator>();
        if (_animator == null)
        {
            Debug.LogWarning(gameObject.name+" Doesn't have animator");
        }
    }

    public void RevealCard()
    {
        _animator.SetBool("Revealed",true);
    }

    public void HideCard()
    {
        _animator.SetBool("Revealed", false);
    }
}
