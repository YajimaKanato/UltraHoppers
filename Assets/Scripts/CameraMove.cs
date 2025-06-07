using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [Header("Player")]
    [SerializeField]
    Transform player;
    private void Update()
    {
        
        transform.position = player.position + new Vector3(7, 2, -10);
    }
}
