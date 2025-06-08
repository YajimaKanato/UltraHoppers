using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class GameDirector : MonoBehaviour
{
    [Header("Player")]
    [SerializeField]
    Transform player;
    Vector3 basePos;
    float nowPlayerPos;
    bool playerStop = false;

    private void Start()
    {
        basePos = player.position;
    }

    public float getMeter()
    {
        if (!playerStop)
        {
            nowPlayerPos = player.position.x - basePos.x;
        }
        return nowPlayerPos;
    }

    [Header("Result")]
    [SerializeField]
    GameObject result;
    void ActiveObject()
    {
        result.SetActive(true);
    }

    [Header("Meter")]
    [SerializeField]
    GameObject meter;
    void InActiveObject()
    {
        meter.SetActive(false);
    }

    public void changeColor(Image image,Color color)
    {
        image.color = color;
    }

    public void PlayerStop()
    {
        playerStop = true;
        ActiveObject();
        InActiveObject();
    }
}
