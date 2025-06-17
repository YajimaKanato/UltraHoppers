using UnityEngine;
using System.Collections.Generic;

public class SelectCharacter : MonoBehaviour
{
    [Header("ChangeCredit")]
    [SerializeField]
    List<GameObject> info;

    private static int index = 0;
    public static int Index {  get { return index; } }

    SEManager se;

    private void Start()
    {
        info[index].SetActive(true);
        se = GetComponent<SEManager>();
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
