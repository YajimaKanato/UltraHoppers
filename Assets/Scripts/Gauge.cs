using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Gauge : MonoBehaviour
{
    GameObject player;

    [Header("Review")]
    [SerializeField]
    GameObject review;

    Coroutine coroutine;
    public float charge;

    SEManager se;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        se = GameObject.FindGameObjectWithTag("SEManager").GetComponent<SEManager>();
    }
    public void StartCharge()
    {
        if (coroutine == null)
        {
            coroutine = StartCoroutine(GaugeCoroutine(SelectCharacter.Index));
        }
    }

    IEnumerator GaugeCoroutine(int index)
    {
        charge = 0.0f;
        while (true)
        {
            if (charge == 1.0f)
            {
                charge = 0.0f;
            }
            if (charge == 0.0f)
            {
                switch (index)
                {
                    case 0:
                        se.GaugeChargeSE(0);
                        break;
                    case 1:
                    case 2:
                        se.GaugeChargeSE(1);
                        break;
                    case 3:
                        se.GaugeChargeSE(2);
                        break;
                    default:
                        break;
                }
            }
            charge += Time.deltaTime / player.GetComponent<Player>().speed;
            if (charge > 1.0f)
            {
                charge = 1.0f;
                se.GaugeChargeStopSE();
            }
            this.gameObject.GetComponent<Image>().fillAmount = charge;
            yield return null;
        }
    }
    public void StopCharge()
    {
        review.GetComponent<Review>().GetReview();
        se.GaugeChargeStopSE();
        se.GaugeSetSE();
        if (coroutine != null)
        {
            StopCoroutine(coroutine);
        }
        StartCoroutine(InActiveCoroutine());
    }

    IEnumerator InActiveCoroutine()
    {
        yield return new WaitForSeconds(0.5f);
        this.gameObject.SetActive(false);
    }
}
