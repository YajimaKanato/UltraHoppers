using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    //プレイヤーごとのステータス
    [Header("Mass")]
    [Tooltip("体重")]
    [SerializeField]
    float mass;

    [Header("Lift")]
    [Tooltip("揚力")]
    [SerializeField]
    float lift;


    Vector3[] mousePos = new Vector3[2];
    bool mouseOnPlayer = false;
    bool playerShot = false;
    bool falling = false;
    Rigidbody2D rigid2d;

    Coroutine addForceCoroutine;
    private void Start()
    {
        rigid2d = GetComponent<Rigidbody2D>();
        rigid2d.bodyType = RigidbodyType2D.Kinematic;
    }

    Coroutine coroutine;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !playerShot)
        {
            mousePos[0] = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            mousePos[0].z = 0;
            if (mousePos[0].magnitude < 1.0f)
            {
                mouseOnPlayer = true;
            }
        }
        if (Input.GetMouseButton(0) && mouseOnPlayer && !playerShot)
        {
            mousePos[1] = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            mousePos[1].z = 0;
            transform.right = mousePos[0] - mousePos[1];
            
        }
        if (Input.GetMouseButtonUp(0) && mouseOnPlayer && !playerShot)
        {
            playerShot = true;
            rigid2d.bodyType = RigidbodyType2D.Dynamic;
            rigid2d.AddForce((mousePos[0] - mousePos[1]) * 30 / Vector3.Distance(mousePos[0], mousePos[1]), ForceMode2D.Impulse);
        }

        if (playerShot)
        {
            if (coroutine == null && rigid2d.linearVelocity.y < 1)
            {
                coroutine = StartCoroutine(RotateCoroutine());
                falling = true;
            }
        }

        if (falling)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("滞空");
                StartCoroutine(ForceCoroutine());
            }
        }
    }


    IEnumerator RotateCoroutine()
    {
        while (transform.localRotation.z > 0)//回転を元に戻す
        {
            transform.Rotate(0, 0, -0.5f);
            yield return null;
        }
        falling = true;
    }

    IEnumerator ForceCoroutine()
    {
        rigid2d.AddForce(Vector3.up * 1f, ForceMode2D.Impulse);
        yield return null;
    }

    float ShotForce()
    {
        return 0;
    }
}
