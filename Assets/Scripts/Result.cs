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
    void Update()
    {
        result.text = director.getMeter().ToString("F1") + "m";
    }
}
