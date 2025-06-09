using UnityEngine;

public class SelectSky : MonoBehaviour
{
    Vector3 basePos;
    private void Start()
    {
        basePos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= new Vector3(0.005f, 0, 0);
        if (transform.position.x - basePos.x <= -40)
        {
            transform.position = basePos;
        }
    }
}
