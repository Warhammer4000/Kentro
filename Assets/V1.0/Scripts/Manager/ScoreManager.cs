
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    [SerializeField] private int player1Score;
    [SerializeField] private int player2Score;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
}
