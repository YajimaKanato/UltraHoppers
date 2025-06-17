using System.Runtime.CompilerServices;
using UnityEngine;

public class SEManager : MonoBehaviour
{
    [Header("SceneButton")]
    [SerializeField]
    AudioClip sceneButton;

    [Header("InfoChangeButton")]
    [SerializeField]
    AudioClip infoButton;

    [Header("GameStartButton")]
    [SerializeField]
    AudioClip gameStartButton;

    [Header("GaugeCharge")]
    [SerializeField]
    AudioClip[] gaugeCharge = new AudioClip[3];

    [Header("GaugeSet")]
    [SerializeField]
    AudioClip gaugeSet;

    [Header("PlayerShot")]
    [SerializeField]
    AudioClip playerShot;

    [Header("Lift")]
    [SerializeField]
    AudioClip lift;

    AudioSource[] audioSource;
    private static SEManager instance;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            audioSource = new AudioSource[20];
            for (int i = 0; i < audioSource.Length; i++)
            {
                audioSource[i] = gameObject.AddComponent<AudioSource>();
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }

    AudioSource GetUnusedAudioSource()
    {
        Debug.Log("getUnused");
        foreach (var audiosource in audioSource)
        {
            if (audiosource.isPlaying == false)
            {
                return audiosource;
            }
        }
        return null;
    }

    public void SceneButtonSE()
    {
        var audiosource = GetUnusedAudioSource();
        if (audiosource != null)
        {
            audiosource.PlayOneShot(sceneButton);
        }
    }

    public void InfoButtonSE()
    {
        var audiosource = GetUnusedAudioSource();
        if (audiosource != null)
        {
            audiosource.PlayOneShot(infoButton);
        }
    }

    public void GameStartButtonSE()
    {
        var audiosource = GetUnusedAudioSource();
        if (audiosource != null)
        {
            audiosource.PlayOneShot(gameStartButton);
        }
    }

    AudioSource gauge;
    public void GaugeChargeSE(int index)
    {
        gauge = GetUnusedAudioSource();
        if (gauge != null)
        {
            gauge.loop = true;
            gauge.clip = gaugeCharge[index];
            gauge.Play();
        }
    }

    public void GaugeSetSE()
    {
        var audiosource = GetUnusedAudioSource();
        if (audiosource != null)
        {
            gauge.Stop();
            audiosource.PlayOneShot(gaugeSet);
        }
    }

    AudioSource player;
    public void PlayerShotSE()
    {
        player = GetUnusedAudioSource();
        if (player != null)
        {
            player.loop = true;
            player.clip = playerShot;
            player.Play();
        }
    }

    public void PlayerSEStop()
    {
        player.Stop();
    }

    AudioSource liftSE;
    public void LiftSE()
    {
        liftSE = GetUnusedAudioSource();
        if (liftSE != null)
        {
            liftSE.loop = true;
            liftSE.clip = lift;
            liftSE.Play();
        }
    }

    public void LiftSEStop()
    {
        liftSE.Stop();
    }
}
