using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeScene : MonoBehaviour
{
    [Header("FadeImage")]
    [SerializeField]
    GameObject image;

    [Header("TitlePlayer")]
    [SerializeField]
    GameObject player;

    Coroutine coroutine;
    public void SceneChange(string name)
    {
        image.SetActive(true);
        coroutine = StartCoroutine(SceneChangeCoroutine(name));
    }

    IEnumerator SceneChangeCoroutine(string name)
    {
        if (name == "Select")
        {
            if (player != null)
            {
                Debug.Log("a");
                player.GetComponent<TitlePlayer>().GameStart();
            }
            
            yield return new WaitForSeconds(0.4f);
        }

        Debug.Log("FadeOut");
        float alpha = 0.0f;
        while (alpha != 1)
        {
            alpha += Time.deltaTime;
            if (alpha >= 1)
            {
                alpha = 1;
            }
            image.GetComponent<Image>().color = new Color(0, 0, 0, alpha);
            yield return null;
        }
        SceneManager.LoadScene(name);
    }
}
