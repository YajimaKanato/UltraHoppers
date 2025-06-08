using UnityEngine;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour
{
    [Header("Player")]
    [SerializeField]
    Transform player;
    Vector3 basePos;

    private void Start()
    {
        basePos = player.position;
    }

    public float getMeter()
    {
        return player.position.x - basePos.x;
    }

    public void changeColor(Image image,Color color)
    {
        image.color = color;
    }
}
