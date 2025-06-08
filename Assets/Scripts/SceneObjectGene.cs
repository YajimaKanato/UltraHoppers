using UnityEngine;

public class SceneObjectGene : MonoBehaviour
{
    [Header("SceneObject")]
    [SerializeField]
    GameObject sceneObject;

    [Header("from Player to This")]
    [SerializeField]
    float width;

    GameObject player;

    Vector3 basePos;
    int generatCount = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        basePos = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.x - basePos.x > width * generatCount)
        {
            generatCount++;
            Instantiate(sceneObject, new Vector3(width * generatCount, transform.position.y, transform.position.z), Quaternion.identity);
        }
    }
}
