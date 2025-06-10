using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class StatusBar : MonoBehaviour
{
    [Header("Fill Amount")]
    [SerializeField]
    float fillmax;

    void OnEnable()
    {
        StartCoroutine(BarChargeCoroutine());
    }

    IEnumerator BarChargeCoroutine()
    {
        float delta = 0.0f;
        float fill = 0.0f;
        while (fill < fillmax)
        {
            if (delta < 0.1f)
            {
                fill += fillmax * (Time.deltaTime * 1f / 0.5f);
                delta += Time.deltaTime * 1f;
            }
            else if (delta < 0.2f)
            {
                fill += fillmax * (Time.deltaTime * 0.9f / 0.5f);
                delta += Time.deltaTime * 0.9f;
            }
            else if (delta < 0.3f)
            {
                fill += fillmax * (Time.deltaTime * 0.8f / 0.5f);
                delta += Time.deltaTime * 0.8f;
            }
            else if (delta < 0.4f)
            {
                fill += fillmax * (Time.deltaTime * 0.6f / 0.5f);
                delta += Time.deltaTime * 0.6f;
            }
            else if (delta < 0.5f)
            {
                fill += fillmax * (Time.deltaTime * 0.35f / 0.5f);
                delta += Time.deltaTime * 0.35f;
            }
            gameObject.GetComponent<Image>().fillAmount = fill;
            yield return null;
        }
    }
}
