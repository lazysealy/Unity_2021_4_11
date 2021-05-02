
using UnityEngine;

public class Player : MonoBehaviour
{
    #region 欄位
    [Header("移動速度"), Range(0, 1000)]
    public float MovingSpeed = 10.5f;
    [Header("跳越高度"), Range(0, 3000)]
    public int jump = 100;
    [Range(0, 200)]
    public float HP = 100;
    [Header("放置於地板"), Tooltip("讓角色與地板親密接觸")]
    public bool OnTheGround = false;
    [Header("子彈物件"), Tooltip("把子彈用出來")]
    public GameObject bullet;
    [Header("子彈生成點"), Tooltip("讓子彈出生的地方")]
    public Transform BulletSpawnPoint;
    [Header("子彈速度"), Range(0, 5000)]
    public int BulletSpeed = 800;
    [Header("音效"), Tooltip("開槍使用的聲音")]
    public AudioClip ShotSound;

    private AudioSource Aud;
    private Rigidbody2D Rig2D;
    private Animator Ani;

    #endregion

    #region 事件

    private void Start()
    {
        移動();
        跳躍();
        開槍();
        受傷(100);
    }

    private void Update()
    {

    }
    #endregion

    #region 方法

    /// <summary>
    /// 移動
    /// </summary>
    private void 移動()
    {
        print("移動");
    }

    /// <summary>
    /// 跳躍
    /// </summary>
    private void 跳躍()
    {
        print("跳躍");
    }

    /// <summary>
    /// 開槍
    /// </summary>
    private void 開槍()
    {
        print("開槍");
    }

    /// <summary>
    /// 受傷
    /// </summary>
    /// <param name="造成傷害">造成的傷害</param>
    private void 受傷(float 造成傷害)
    {
        print("受傷" + 造成傷害);
    }

    /// <summary>
    /// 死亡
    /// </summary>
    /// <returns>是否死亡</returns>
    private bool 死亡()
    {
        return false;
    }

    /// <summary>
    /// 吃道具
    /// </summary>
    /// <param name="道具">道具名稱</param>
    private void 吃道具(string 道具)
    {

    }
    #endregion
}
