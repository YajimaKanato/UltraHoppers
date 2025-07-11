using UnityEngine;
using System.Collections.Generic;

public class SelectCharacter : MonoBehaviour
{
    [Header("ChangeCredit")]
    [SerializeField]
    List<GameObject> info;

    [SerializeField]
    List<GameObject> players;

    private static int index = 0;
    public static int Index {  get { return index; } }

    SEManager se;

    private void Start()
    {
        info[index].SetActive(true);
        players[index].SetActive(true);
        se = GameObject.FindGameObjectWithTag("SEManager").GetComponent<SEManager>();
    }

    public void InfoChange(int i)
    {
        if (info.Count == 0 || info == null)
        {
            Debug.Log("リストが空です");
            return;
        }

        info[index].SetActive(false);
        players[index].SetActive(false);
        index += i;
        if (index < 0)
        {
            index = info.Count - 1;
        }
        index %= info.Count;
        info[index].SetActive(true);
        players[index].SetActive(true);
        se.InfoButtonSE();
    }
}
