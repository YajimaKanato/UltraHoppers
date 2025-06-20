using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Audio;

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

    [Header("SetGround")]
    [SerializeField]
    AudioClip setGround;

    [Header("AudioMixer")]
    [SerializeField]
    AudioMixerGroup mixer;

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

    void SetMixer(AudioSource source)
    {
        source.outputAudioMixerGroup = mixer;
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
            SetMixer(audiosource);
            audiosource.PlayOneShot(sceneButton);
        }
    }

    public void InfoButtonSE()
    {
        var audiosource = GetUnusedAudioSource();
        if (audiosource != null)
        {
            SetMixer(audiosource);
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
        
        if (gauge == null)
        {
            gauge = GetUnusedAudioSource();
            gauge.clip = gaugeCharge[index];
            gauge.Play();
        }
    }

    public void GaugeChargeStopSE()
    {
        if (gauge != null)
        {
            gauge.Stop();
            gauge = null;
        }
    }

    public void GaugeSetSE()
    {
        var audiosource = GetUnusedAudioSource();
        if (audiosource != null)
        {
            audiosource.PlayOneShot(gaugeSet);
        }
    }

    AudioSource player;
    public void PlayerShotSE()
    {
        
        if (player == null)
        {
            player = GetUnusedAudioSource();
            SetMixer(player);
            player.loop = true;
            player.clip = playerShot;
            player.Play();
        }
    }

    public void PlayerSEStop()
    {
        if(player != null)
        {
            player.Stop();
            player = null;
        }
    }

    AudioSource liftSE;
    public void LiftSE()
    {
        
        if (liftSE == null)
        {
            liftSE = GetUnusedAudioSource();
            liftSE.loop = true;
            liftSE.clip = lift;
            liftSE.Play();
        }
    }

    public void LiftSEStop()
    {
        liftSE.Stop();
    }

    public void SetGroundSE()
    {
        var audiosource = GetUnusedAudioSource();
        if (audiosource != null)
        {
            audiosource.PlayOneShot(setGround);
        }
    }
}
