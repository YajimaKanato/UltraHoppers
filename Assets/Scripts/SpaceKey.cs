using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SpaceKey : MonoBehaviour
{
    void OnEnable()
    {
        StartCoroutine(SpaceCoroutine());
    }

    IEnumerator SpaceCoroutine()
    {
        var interval = new WaitForSeconds(0.15f);
        int num = 1;
        while (true)
        {
            if (num == 1)
            {
                this.gameObject.GetComponent<Text>().color = Color.white;
            }
            else if (num == -1)
            {
                this.gameObject.GetComponent<Text>().color = Color.red;
            }
            num = -num;
            yield return interval;
        }
    }
}
