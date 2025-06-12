using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class CharacterGroup : MonoBehaviour
{
    [Header("CharacterImage")]
    [SerializeField]
    List<Sprite> sprites;

    Image[] images;
    private void Start()
    {
        images = GetComponentsInChildren<Image>();
        for (int i = 0; i < RankingManager.Ranking.Count; i++)
        {
            images[i].sprite=sprites[RankingManager.Ranking[i].Item1];
            images[i].color = new Color(1, 1, 1, 1);
        }
    }
}
