using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;


public class Fade : MonoBehaviour
{
    private void Start()
    {
        BGMChange();
        StartCoroutine(FadeInCoroutine());
    }

    IEnumerator FadeInCoroutine()
    {
        Debug.Log("FadeIn");
        float alpha = 1.0f;
        while (alpha != 0)
        {
            alpha -= Time.deltaTime;
            if (alpha <= 0)
            {
                alpha = 0;
            }
            GetComponent<Image>().color = new Color(0, 0, 0, alpha);
            yield return null;
        }
        this.gameObject.SetActive(false);
    }

    void BGMChange()
    {
        BGMManager bgm = GameObject.FindGameObjectWithTag("BGMManager").GetComponent<BGMManager>();
        if (SceneManager.GetActiveScene().name=="Title")
        {
            bgm.TitleBGM();
        }
        else if(SceneManager.GetActiveScene().name == "InGame")
        {
            bgm.InGame();
        }
        else if (SceneManager.GetActiveScene().name == "Info")
        {
            bgm.InfoBGM();
        }
        else if (SceneManager.GetActiveScene().name == "Credit")
        {
            bgm.CreditBGM();
        }
        else if (SceneManager.GetActiveScene().name == "Select")
        {
            bgm.SelectBGM();
        }
    }
}
