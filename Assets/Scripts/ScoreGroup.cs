using UnityEngine;
using UnityEngine.UI;

public class ScoreGroup : MonoBehaviour
{
    Text[] texts;
    private void Start()
    {
        texts = GetComponentsInChildren<Text>();
        for (int i = 0; i < RankingManager.Ranking.Count; i++)
        {
            if (RankingManager.Ranking[i].Item2 > 10000)
            {
                texts[i].text = "9999.9 m";
            }
            else
            {
                texts[i].text = (Mathf.Floor(RankingManager.Ranking[i].Item2 * 10) / 10).ToString();
                //texts[i].text = ((int)(RankingManager.Ranking[i].Item2)).ToString("");
                //texts[i].text += (Mathf.Floor((RankingManager.Ranking[i].Item2 - (int)(RankingManager.Ranking[i].Item2)) * 10) / 10).ToString("F1").TrimStart('0');
                texts[i].text += " m";
            }
        }
    }
}
