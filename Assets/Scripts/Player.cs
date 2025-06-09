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

    [Header("Jump")]
    [Tooltip("跳躍力")]
    [SerializeField]
    float jump;

    [Header("Arrow")]
    [SerializeField]
    GameObject arrow;

    [Header("GameDirector")]
    [SerializeField]
    GameDirector director;

    Vector3[] mousePos = new Vector3[2];
    bool mouseOnPlayer = false;//マウスがプレイヤーに重なっているか
    bool playerShot = false;//ショットしたかどうか
    bool falling = false;//落下し始めたかどうか
    Rigidbody2D rigid2d;
    Animator animator;
    Coroutine coroutine;

    private void Start()
    {
        rigid2d = GetComponent<Rigidbody2D>();
        rigid2d.bodyType = RigidbodyType2D.Kinematic;
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !playerShot)
        {
            mousePos[0] = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            mousePos[0].z = 0;
            if (mousePos[0].magnitude < 1.0f)//マウスとプレイヤーの距離
            {
                mouseOnPlayer = true;
            }
        }
        if (Input.GetMouseButton(0) && mouseOnPlayer && !playerShot)
        {
            mousePos[1] = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            mousePos[1].z = 0;
            transform.right = mousePos[0] - mousePos[1];//マウスのドラッグを取得
        }
        if (Input.GetMouseButtonUp(0) && mouseOnPlayer && !playerShot)
        {
            playerShot = true;
            rigid2d.bodyType = RigidbodyType2D.Dynamic;
            rigid2d.mass = mass;
            rigid2d.AddForce((mousePos[0] - mousePos[1]) * jump / Vector3.Distance(mousePos[0], mousePos[1]), ForceMode2D.Impulse);
            arrow.SetActive(false);
        }

        if (playerShot)
        {
            if (coroutine == null && rigid2d.linearVelocity.y < 1)
            {
                animator.SetBool("Fly", true);
                coroutine = StartCoroutine(RotateCoroutine());
                falling = true;
            }
        }

        if (falling)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
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
    }

    IEnumerator ForceCoroutine()
    {
        rigid2d.AddForce(Vector3.up * lift, ForceMode2D.Impulse);
        yield return null;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        director.PlayerStop();
        rigid2d.bodyType = RigidbodyType2D.Kinematic;
        rigid2d.linearVelocity = Vector3.zero;
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sortingOrder = -99;
    }
}
