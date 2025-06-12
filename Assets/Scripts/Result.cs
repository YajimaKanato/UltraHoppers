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

    float meter;
    void Update()
    {
        meter = director.getMeter() * 30;
        if (meter > 10000)
        {
            meter = 9999.9f;
        }
        result.text = meter.ToString("F1") + "m";
    }
}
