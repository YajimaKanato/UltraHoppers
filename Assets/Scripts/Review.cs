using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Review : MonoBehaviour
{
    [Header("Gauge")]
    [SerializeField]
    GameObject gauge;

    float gaugeRate;
    public void GetReview()
    {
        gaugeRate = gauge.GetComponent<Gauge>().charge;
        if (gaugeRate >= 0.9f)
        {
            this.gameObject.GetComponent<Text>().text = "Fantastic!";
        }
        else if (gaugeRate >= 0.7f)
        {
            this.gameObject.GetComponent<Text>().text = "Excellent!";
        }
        else if (gaugeRate >= 0.4f)
        {
            this.gameObject.GetComponent<Text>().text = "Very Good!";
        }
        else
        {
            this.gameObject.GetComponent<Text>().text = "Good!";
        }
        StartCoroutine(InActiveCoroutine());
    }

    IEnumerator InActiveCoroutine()
    {
        yield return new WaitForSeconds(0.5f);
        this.gameObject.SetActive(false);
    }
}
