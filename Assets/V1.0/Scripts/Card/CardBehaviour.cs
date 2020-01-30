using Kentro;
using TMPro;
using UnityEngine;

public class CardBehaviour : MonoBehaviour
{
    [SerializeField]private Animator _animator;
    [SerializeField]private TextMeshPro _cardNumberTextMesh;

    [SerializeField] private bool IsCenter;
    [SerializeField] private GameObject CenterVFX;

    public Card Card;

    void Start()
    {
       
        
        if (_animator == null)
        {
            Debug.LogWarning(gameObject.name+" Doesn't have animator");
        }
    }

    public void RevealCard()
    {
        if(IsCenter || Card.flipped)return;
        Card.Flip();
        SetNumber(Card.value);
        _animator.SetBool("Revealed", Card.flipped);
       
    }

    public void HideCard()
    {
        Card.Flip();
        _animator.SetBool("Revealed", Card.flipped);
    }

    public void MakeCenter()
    {
        IsCenter = true;
        CenterVFX.gameObject.SetActive(true);
    }

    private void SetNumber(int number)
    {
        _cardNumberTextMesh.text = number.ToString();
    }
}
