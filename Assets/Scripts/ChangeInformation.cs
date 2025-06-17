using System.Collections.Generic;
using UnityEngine;

public class ChangeInformation : MonoBehaviour
{
    [Header("ChangeInfo")]
    [SerializeField]
    List<GameObject> info;

    private static int index = 0;

    SEManager se;

    private void Start()
    {
        info[index].SetActive(true);
        se = GameObject.FindGameObjectWithTag("SEManager").GetComponent<SEManager>();
    }

    public void InfoChange(int i)
    {
        if (info.Count == 0 || info == null)
        {
            Debug.Log("ƒŠƒXƒg‚ª‹ó‚Å‚·");
            return;
        }

        info[index].SetActive(false);
        index += i;
        if (index < 0)
        {
            index = info.Count - 1;
        }
        index %= info.Count;
        info[index].SetActive(true);
        se.InfoButtonSE();
    }
}
