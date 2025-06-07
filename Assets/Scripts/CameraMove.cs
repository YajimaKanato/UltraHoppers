using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [Header("Player")]
    [SerializeField]
    Transform player;
    Vector3 pos;
    private void Update()
    {
        pos = player.position;
        if (player.position.x >= -7)
        {
            pos += new Vector3(7, 0, 0);
        }
        else
        {
            pos += new Vector3(-player.position.x, 0, 0);
        }
        if (player.position.y < 10)
        {
            pos += new Vector3(0, 2, 0);
        }
        else
        {
            pos += new Vector3(0, -player.position.y, 0);
        }
            pos += new Vector3(0, 0, -10);
        transform.position = pos;
    }
}
