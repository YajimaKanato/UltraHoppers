using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class GameDirector : MonoBehaviour
{
    [Header("Players")]
    [SerializeField]
    GameObject[] players;
    GameObject player;
    Vector3 basePos;
    float nowPlayerPos;
    bool playerStop = false;

    public float getMeter()
    {
        if (!playerStop)
        {
            nowPlayerPos = players[ChangeInformation.Index].transform.position.x - basePos.x;
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

    private void Awake()
    {
        //player = players[ChangeInformation.Index];
        players[ChangeInformation.Index].SetActive(true);
        basePos = players[ChangeInformation.Index].transform.position;
    }
}
