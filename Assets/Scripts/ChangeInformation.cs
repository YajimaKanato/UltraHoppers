using UnityEngine;
using System.Collections.Generic;

public class ChangeInformation : MonoBehaviour
{
    [Header("ChangeCredit")]
    [SerializeField]
    List<GameObject> info;

    private int index = 0;
    
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
    }
}
