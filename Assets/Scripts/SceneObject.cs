using UnityEngine;

public class SceneObject : MonoBehaviour
{
    [Header("from Player to This")]
    [SerializeField]
    float width;

    GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.x - transform.position.x > width)
        {
            Destroy(gameObject);
        }
    }
}
