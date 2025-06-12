using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class RankingManager : MonoBehaviour
{
    private static List<(int, float)> ranking=new List<(int, float)>();
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
        ranking.Add((ChangeInformation.Index, director.getMeter()));
        ranking.OrderBy(x => x.Item2);
        ranking.Reverse();
        if (ranking.Count > 10)
        {
            ranking.RemoveAt(ranking.Count - 1);
        }
        if (ranking != null && ranking.Count > 0)
        {
            foreach (var r in ranking)
            {
                Debug.Log(r.Item2.ToString());
            }
        }
    }
}
