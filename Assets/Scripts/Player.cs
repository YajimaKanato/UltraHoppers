using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    //プレイヤーごとのステータス
    [Header("Lift")]
    [Tooltip("揚力")]
    [SerializeField]
    float lift;

    [Header("Jump")]
    [Tooltip("跳躍力")]
    [SerializeField]
    float maxJump;

    [Header("GaugeSpeed")]
    [Tooltip("ゲージ速度（何秒でゲージが満タンになるか）")]
    public float speed;

    [Header("Arrow")]
    [SerializeField]
    GameObject arrow;

    [Header("GameDirector")]
    [SerializeField]
    GameDirector director;

    [Header("Gauge")]
    [SerializeField]
    Gauge gauge;

    [Header("GaugeMax")]
    [SerializeField]
    GameObject gaugeMax;

    [Header("Space")]
    [SerializeField]
    GameObject spaceKey;

    [Header("Ranking")]
    [SerializeField]
    GameObject ranking;

    Vector3[] mousePos = new Vector3[2];
    bool mouseOnPlayer = false;//マウスがプレイヤーに重なっているか
    bool playerShot = false;//ショットしたかどうか
    bool falling = false;//落下し始めたかどうか
    bool spaceEnable = true;
    Rigidbody2D rigid2d;
    Animator animator;
    Coroutine coroutine;

    SEManager se;
    private void Start()
    {
        rigid2d = GetComponent<Rigidbody2D>();
        rigid2d.bodyType = RigidbodyType2D.Kinematic;
        animator = GetComponent<Animator>();
        se = GameObject.FindGameObjectWithTag("SEManager").GetComponent<SEManager>();
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
                gauge.StartCharge();
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
            gaugeMax.SetActive(false);
            gauge.StopCharge();
            playerShot = true;
            StartCoroutine(ShotCoroutine());
        }

        if (playerShot)
        {
            if (rigid2d.linearVelocity.y < 2.0f && rigid2d.bodyType == RigidbodyType2D.Dynamic && spaceKey.activeInHierarchy == false)
            {
                spaceKey.SetActive(true);
            }

            if (coroutine == null && rigid2d.linearVelocity.y < 1.0f && rigid2d.bodyType == RigidbodyType2D.Dynamic)
            {
                animator.SetBool("Fly", true);
                coroutine = StartCoroutine(RotateCoroutine());
                se.LiftSE();
                falling = true;
            }
        }

        if (falling)
        {
            if (Input.GetKeyDown(KeyCode.Space) && spaceEnable)
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

    IEnumerator ShotCoroutine()
    {
        Debug.Log(gauge.GetComponent<Gauge>().charge);
        yield return new WaitForSeconds(0.5f);
        rigid2d.bodyType = RigidbodyType2D.Dynamic;
        rigid2d.AddForce((mousePos[0] - mousePos[1]).normalized * maxJump * (1 / 3f + 2 * gauge.GetComponent<Gauge>().charge / 3f), ForceMode2D.Impulse);
        arrow.SetActive(false);
        se.PlayerShotSE();
    }//

    IEnumerator ForceCoroutine()
    {
        spaceEnable = false;
        //rigid2d.AddForce(Vector3.up * lift, ForceMode2D.Impulse);
        rigid2d.gravityScale = lift;
        yield return new WaitForSeconds(1/16f);
        rigid2d.gravityScale = 1.0f;
        //yield return new WaitForSeconds(0.08f);
        spaceEnable = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        ranking.SetActive(true);
        director.PlayerStop();
        spaceKey.SetActive(false);
        se.PlayerSEStop();
        se.LiftSEStop();
        se.SetGroundSE();
        rigid2d.bodyType = RigidbodyType2D.Kinematic;
        rigid2d.linearVelocity = Vector3.zero;
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sortingOrder = -99;
    }
}
