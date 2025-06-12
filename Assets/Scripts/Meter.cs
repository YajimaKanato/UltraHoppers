using UnityEngine;
using UnityEngine.UI;

public class Meter : MonoBehaviour
{
    [Header("GameDirector")]
    [SerializeField]
    GameDirector director;

    [Header("Meter")]
    [SerializeField]
    Text text;

    float meter;
    private void Start()
    {
        text = text.GetComponent<Text>();
    }

    private void Update()
    {
        meter = director.getMeter() * 30;
        if (meter > 10000)
        {
            meter = 9999.9f;
        }
        text.text = (director.getMeter() * 30).ToString("F1") + "m";
    }
}
