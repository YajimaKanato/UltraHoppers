using UnityEngine;

public class CameraMove : MonoBehaviour
{
    GameObject player;
    Vector3 pos;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void Update()
    {
        pos = player.transform.position;
        if (player.transform.position.x >= -7)
        {
            pos.x += 7;
        }
        else
        {
            pos.x = 0;
        }
        if (player.transform.position.y < 75 - 7)
        {
            pos.y += 2;
        }
        else
        {
            pos.y = 75 - 7 + 2;
        }
        pos.z = -10;
        transform.position = pos;
    }
}
