using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SocialPlatforms.Impl;

public class GameDirector : MonoBehaviour
{
    [Header("Players")]
    [SerializeField]
    GameObject[] players;
    Vector3 basePos;
    float nowPlayerPos;
    bool playerStop = false;

    static int achi;
    public static int Ach { get { return achi; } }

    [SerializeField]
    Text te;
    [SerializeField]
    Text tt;
    [SerializeField]
    Text ttt;
    [SerializeField]
    Text tttt;
    [SerializeField]
    GameObject g;
    [SerializeField]
    GameObject b;
    static bool gg = false;
    public static bool GG { get { return gg; } }
    private void Start()
    {
        gg = false;
        if (ModeSelect.Achieve)
        {
            b.SetActive(true);
            achi = Random.Range(5000, 10000);
            te.text = "Match to ...\n" + achi + "m!!!\n";
            ttt.text = "Glide Å}500m to Succeed";
        }
        else
        {
            tttt.gameObject.SetActive(false);
        }
    }
    private void Update()
    {
        if (ModeSelect.Achieve && Input.GetMouseButtonDown(0) && !playerStop && !gg)
        {
            b.SetActive(false);
            te.text = "";
            ttt.text = "";
            tt.text = "Glide to\n" + achi + "m";
            tttt.text = "";
        }

        if (Input.GetKeyDown(KeyCode.Escape) && !playerStop)
        {
            gg = !gg;
            g.SetActive(gg);
        }
    }

    public float getMeter()
    {
        if (!playerStop)
        {
            nowPlayerPos = players[SelectCharacter.Index].transform.position.x - basePos.x;
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

    public void PlayerStop()
    {
        playerStop = true;
        ActiveObject();
        InActiveObject();
    }

    private void Awake()
    {
        players[SelectCharacter.Index].SetActive(true);
        basePos = players[SelectCharacter.Index].transform.position;
    }
}
