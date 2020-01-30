using TMPro;
using UnityEngine;

public class CardBehaviour : MonoBehaviour
{
    [SerializeField]private Animator _animator;
    [SerializeField]private TextMeshPro _cardNumberTextMesh;

    [SerializeField] private bool IsCenter;
    [SerializeField] private GameObject CenterVFX;



    void Start()
    {
       
        
        if (_animator == null)
        {
            Debug.LogWarning(gameObject.name+" Doesn't have animator");
        }
    }

    public void RevealCard()
    {
        if(IsCenter)return;
        _animator.SetBool("Revealed", true);
    }

    public void HideCard()
    {
        _animator.SetBool("Revealed", false);
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
