using UnityEngine;
using UnityEngine.UI;

public class Result : MonoBehaviour
{
    [Header("GameDirector")]
    [SerializeField]
    GameDirector director;

    [Header("Result")]
    [SerializeField]
    Text result;

    [SerializeField]
    Text te;

    float meter;
    void Update()
    {
        meter = director.getMeter() * 30;
        if (meter > 10000)
        {
            meter = 9999.9f;
        }
        result.text = (Mathf.Floor(meter * 10) / 10).ToString("F1") + "m";

        if (ModeSelect.Achieve)
        {
            if (Mathf.Abs(director.getMeter() * 30 - GameDirector.Ach) <= 500)
            {
                te.color = Color.yellow;
                te.text = "Success!!!";
            }
            else
            {
                te.color = Color.red;
                te.text = "Failure...";
            }
        }
    }
}
