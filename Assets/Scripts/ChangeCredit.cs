using System.Collections.Generic;
using UnityEngine;

public class ChangeCredit : MonoBehaviour
{
    [Header("ChangeCredit")]
    [SerializeField]
    List<GameObject> credit;

    private static int index = 0;

    private void Start()
    {
        credit[index].SetActive(true);
    }

    public void InfoChange(int i)
    {
        if (credit.Count == 0 || credit == null)
        {
            Debug.Log("ƒŠƒXƒg‚ª‹ó‚Å‚·");
            return;
        }

        credit[index].SetActive(false);
        index += i;
        if (index < 0)
        {
            index = credit.Count - 1;
        }
        index %= credit.Count;
        credit[index].SetActive(true);
    }
}
