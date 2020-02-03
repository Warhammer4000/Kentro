using Kentro;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    private int goalScore = 100;
    private int hitScore = 30;
    [SerializeField] public Text player1Score;
    [SerializeField] public Text player2Score;



    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    public void GoalScoreAdd(Player player)
    {
        player.Score += goalScore;
        if (player.PlayerId == PlayerEnum.Player1)
        {
            player1Score.text = player.Score.ToString();
            return;
        }
        player2Score.text = player.Score.ToString();

        Debug.Log(player.Score);
    }

    public void HitScoreAdd(Player player)
    {
        player.Score += hitScore;
        if (player.PlayerId == PlayerEnum.Player1)
        {
            player1Score.text = player.Score.ToString();
            return;
        }
        player2Score.text = player.Score.ToString();
    }

}
