using UnityEngine;
using System.Collections.Generic;

public class TreeGene : MonoBehaviour
{
    [Header("SceneObject")]
    [SerializeField]
    List<GameObject> sceneObject;

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
            int rand = Random.Range(0, sceneObject.Count);
            generatCount++;
            Instantiate(sceneObject[rand], new Vector3(width * generatCount + 10, transform.position.y + 2, transform.position.z), Quaternion.identity);
        }
    }
}
