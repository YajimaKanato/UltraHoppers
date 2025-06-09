using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Gauge : MonoBehaviour
{
    [Header("Player")]
    [SerializeField]
    GameObject player;

    [Header("Review")]
    [SerializeField]
    GameObject review;

    Coroutine coroutine;
    public float charge;
    public void StartCharge()
    {
        if (coroutine == null)
        {
            coroutine = StartCoroutine(GaugeCoroutine());
        }
    }
    
    public void StopCharge()
    {
        review.GetComponent<Review>().GetReview();
        if (coroutine != null)
        {
            StopCoroutine(coroutine);
        }
        StartCoroutine(InActiveCoroutine());
    }

    IEnumerator GaugeCoroutine()
    {
        charge = 0.0f;
        while (true)
        {
            charge += Time.deltaTime / player.GetComponent<Player>().speed;
            if (charge >= 1.0f)
            {
                charge = 1.0f;
            }
            this.gameObject.GetComponent<Image>().fillAmount = charge;
            if (charge == 1.0f)
            {
                charge = 0.0f;
            }
            yield return null;
        }
    }

    IEnumerator InActiveCoroutine()
    {
        yield return new WaitForSeconds(0.5f);
        this.gameObject.SetActive(false);
    }
}
