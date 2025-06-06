using UnityEngine;

public class Player : MonoBehaviour
{
    Vector3[] mousePos = new Vector3[2];
    bool mouseOnPlayer = false;
    bool playerShot = false;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mousePos[0] = Camera.main.ScreenToWorldPoint(Input.mousePosition)-transform.position;
            mousePos[0].z = 0;
            if (mousePos[0].magnitude < 1.0f)
            {
                mouseOnPlayer = true;
            }
        }
        if (Input.GetMouseButton(0) && mouseOnPlayer)
        {
            mousePos[1] = Camera.main.ScreenToWorldPoint(Input.mousePosition)-transform.position;
            mousePos[1].z = 0;
            transform.right = mousePos[0] - mousePos[1];
        }
        if (Input.GetMouseButtonUp(0) && mouseOnPlayer)
        {
            playerShot = true;
        }

        if (playerShot)
        {
            transform.position = new Vector3(0, 0, 0);
        }
    }
}
