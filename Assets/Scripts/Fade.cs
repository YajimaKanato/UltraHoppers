using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class Fade : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(FadeInCoroutine());
    }

    IEnumerator FadeInCoroutine()
    {
        Debug.Log("FadeIn");
        float alpha = 1.0f;
        while (alpha != 0)
        {
            alpha -= Time.deltaTime;
            if (alpha <= 0)
            {
                alpha = 0;
            }
            GetComponent<Image>().color = new Color(0, 0, 0, alpha);
            yield return null;
        }
        this.gameObject.SetActive(false);
    }
}
