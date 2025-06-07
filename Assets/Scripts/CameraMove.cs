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
            pos.x += 7;
        }
        else
        {
            pos.x = 0;
        }
        if (player.position.y < 75 - 7)
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
