using UnityEngine;

public class Players : MonoBehaviour
{
    [Header("L or R")]
    [SerializeField]
    GameObject lorr;

    GameObject director;

    public static Players instance;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(instance == null)
        {
            Debug.Log("ê∂ê¨");
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Debug.Log("îjä¸");
            Destroy(gameObject);
        }

        director = GameObject.Find("Director");
    }

    // Update is called once per frame
    void Update()
    {
    }
}
