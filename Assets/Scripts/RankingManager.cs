using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using unityroom.Api;

public class RankingManager : MonoBehaviour
{
    private static List<(int, float)> ranking = new List<(int, float)>();
    public static List<(int, float)> Ranking { get { return ranking; } }

    [Header("GameDirector")]
    [SerializeField]
    GameDirector director;

    private void OnEnable()
    {
        RankingSort();
    }

    void RankingSort()
    {
        if (!ModeSelect.Achieve && !GameDirector.GG)
        {
            ranking.Add((SelectCharacter.Index, director.getMeter() * 30));
            ranking.Sort((a, b) => a.Item2.CompareTo(b.Item2));
            ranking.Reverse();
            if (ranking.Count > 10)
            {
                ranking.RemoveAt(ranking.Count - 1);
            }
            UnityroomApiClient.Instance.SendScore(1, director.getMeter() * 30, ScoreboardWriteMode.HighScoreDesc);
        }
    }
}
