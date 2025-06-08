using UnityEngine;
using UnityEngine.UI;

public class Meter : MonoBehaviour
{
    [Header("GameDirector")]
    [SerializeField]
    GameDirector director;

    [Header("MeterBack")]
    [SerializeField]
    Image image;

    [Header("Meter")]
    [SerializeField]
    Text text;



    private void Start()
    {
        image = image.GetComponent<Image>();
        text = text.GetComponent<Text>();
    }

    private void Update()
    {
        text.text = director.getMeter().ToString("F1") + "m";
    }
}
