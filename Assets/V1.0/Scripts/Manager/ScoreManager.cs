
using Kentro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    private int goalScore = 100;
    private int hitScore = 30;

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
        Debug.Log(player.Score);
    }

    public void HitScoreAdd(Player player)
    {
        player.Score += hitScore;
        Debug.Log(player.Score);
    }
}
