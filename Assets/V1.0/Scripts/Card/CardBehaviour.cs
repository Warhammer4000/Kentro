using Kentro;
using TMPro;
using UnityEngine;

public class CardBehaviour : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Animator _hoverAnimator;
    [SerializeField] private TextMeshPro _cardNumberTextMesh;

    public bool IsCenter;
    [SerializeField] private GameObject CenterVFX;

    public Card Card;

    private void Start()
    {
        if (_animator == null) Debug.LogWarning(gameObject.name + " Doesn't have animator");
    }


    public void RegisterCard(Card card)
    {
        Card = card;
        Card.WorldPos = transform.position;
        Card.OnCardHover += HoverCard;
        Card.OnCardIdle += IdleCard;
        Card.OnCardReveal += RevealCard;
        Card.OnCardHide += HideCard;
    }

    #region AnimationFunctions

    public void RevealCard()
    {
        if (IsCenter || Card.flipped) return;
        SetNumber(Card.value);
        _animator.SetBool("Revealed", true);
    }

    public void HideCard()
    {
    
        _animator.SetBool("Revealed", false);
    }

    public void HoverCard()
    {
        _hoverAnimator.SetBool("Hovering",true);
    }

    public void IdleCard()
    {
        _hoverAnimator.SetBool("Hovering", false);
    }

    #endregion

    public void MakeCenter()
    {
        IsCenter = true;
        Card.isCenter = true;
        CenterVFX.gameObject.SetActive(true);
    }

    private void SetNumber(int number)
    {
        _cardNumberTextMesh.text = number.ToString();
    }
}