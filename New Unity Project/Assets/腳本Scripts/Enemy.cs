using UnityEngine;

public class Enemy : MonoBehaviour
{
    #region 欄位
    [Header("移動速度"), Range(0, 100)]
    public float speed = 1f;
    [Header("攻擊力"), Range(0, 100)]
    public float attack = 10f;
    [Header("攻擊冷卻"), Range(0, 30)]
    public float cd = 3;
    [Header("血量"), Range(0, 500)]
    public float hp = 200f;

    [Header("追蹤範圍"), Range(0, 50)]
    public float radiusTrack = 5;
    [Header("攻擊範圍"), Range(0, 30)]
    public float radiusAttack = 2;

    private Animator ani;
    private Rigidbody2D rig;
    private Transform player;
    /// <summary>
    /// 計時器：紀錄攻擊冷卻
    /// </summary>
    private float timer;
    #endregion

    #region 事件
    private void Start()


    

    {
        ani = GetComponent<Animator>();
        rig = GetComponent<Rigidbody2D>();

        // 玩家 = 遊戲物件.尋找("物件名稱") - 搜尋場景內所有的物件
        // transform.Find("子物件名稱") - 搜尋此物件的子物件
        player = GameObject.Find("玩家").transform;

        // 讓敵人一開始就進行攻擊
        timer = cd;
    }

    [Header("偵測地板的位移與半徑")]
    public Vector3 geoundOffset;
    public float groundRadius = 0.1f;

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(0, 1, 0, 0.3f);
        Gizmos.DrawSphere(transform.position, radiusTrack);

        Gizmos.color = new Color(1, 0, 0, 0.3f);
        Gizmos.DrawSphere(transform.position, radiusAttack);

        Gizmos.color = new Color(0.6f, 0.9f, 1, 0.7f);
        Gizmos.DrawSphere(transform.position + transform.right * geoundOffset.x + transform.up * geoundOffset.y, groundRadius);
    }

    private void Update()
    {
        Move();
    }
    #endregion

    #region 方法
    /// <summary>
    /// 移動：偵測是否進入追蹤範圍
    /// </summary>
    private void Move()
    {
        //距離 = 三維向量.距離(A點.B點)
        float dis = Vector3.Distance(player.position, transform.position);

        //如果 距離 小於等於 攻擊範圍 就攻擊
        if (dis <= radiusAttack)
        {
            Attack();
        }
        //否則 如果 玩家跟敵人 的 距離 小於等於 追蹤範圍 就移動
        else if (dis <= radiusTrack)
        {
            rig.velocity = transform.right * speed * Time.deltaTime;
            ani.SetBool("走路開關", true);
            LookAtPlayer();
        }
        else
        {
            ani.SetBool("走路開關", false);
        }

        
    }

    /// <summary>
    /// 攻擊
    /// </summary>
    private void Attack()
    {
        ani.SetBool("走路開關", false);

        //如果 計時器 <= 攻擊冷卻 就累加
        if (timer <= cd)
        {
            timer += Time.deltaTime;
        }
        //否則 攻擊 並將計時器歸零
        else
        {
            timer = 0;
            ani.SetTrigger("攻擊開關");
        }
    }

    /// <summary>
    /// 面向玩家
    /// </summary>
    private void LookAtPlayer()
    {
        // 如果 敵人 x 大於 玩家 x 就表示玩家在左邊 角度 180
        if (transform.position.x > player.position.x)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        // 否則 敵人 x 小於 玩家 x 就表示玩家在右邊 角度 0
        else
        {
            transform.eulerAngles = Vector3.zero;
        }
    }




    #endregion

}
