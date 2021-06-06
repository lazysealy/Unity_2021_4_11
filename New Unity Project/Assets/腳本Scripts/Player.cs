
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
    [Header("開槍音效"), Tooltip("開槍使用的聲音")]
    public AudioClip ShotSound;

    private AudioSource Aud;
    private Rigidbody2D Rig2D;
    private Animator Ani;

    #endregion


    #region 事件
    private void Start()
    {
        // 利用程式取得元件
        // 傳回元件 取得元件<元件名稱>() - <泛型>
        // 取得跟此腳本同一層的元件
        Rig2D = GetComponent<Rigidbody2D>();
        Ani = GetComponent<Animator>();
        Aud = GetComponent<AudioSource>();
    }

    // 一秒約執行 60 次
    private void Update()
    {
        移動();
        跳躍();
        開槍();
    }

    [Header("判斷地板碰撞的位移與半徑")]
    public Vector3 groundOffset;
    public float groundRadius = 0.2f;

    //繪製圖示 - 輔助編輯時的圖形線條
    private void OnDrawGizmos()
    {
        // 1.指定顏色
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        // 2.繪製圖形
        // transform 可以抓到此腳本同一層的變形元件
        // 繪製球體(中心點，半徑)
        // 物件的右方 X 軸 : transform.right
        // 物件的右方 Y 軸 : transform.up
        // 物件的右方 Z 軸 : transform.forward
        Gizmos.DrawSphere(transform.position + transform.right * groundOffset.x + transform.up * groundOffset.y, groundRadius);
    }
    #endregion

    #region 方法

    /// <summary>
    /// 移動
    /// </summary>
    private void 移動()
    {
        // 1.要抓到玩家按下左右鍵的資訊
        float h = Input.GetAxis("Horizontal");
        //註解print("水平的值:" + h);

        // 2.使用左右鍵的資訊控制角色移動
        // 鋼體.加速度 = 二維向量(水平 * 速度 * 一幀的時間， 指定回原本的 Y 軸加速度)
        // 一幀
        Rig2D.velocity = new Vector2(h * MovingSpeed * Time.deltaTime, Rig2D.velocity.y);


        // 如果 按下 D 面向右邊 0 0 0
        if (Input.GetKeyDown (KeyCode.D))
        {
            transform.eulerAngles = Vector3.zero;
        }
        // 否則 如果 按下 A 面向左邊 0 180 0
        else if (Input.GetKeyDown(KeyCode.A))
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }

        //　設定動畫
        // 水平值 不等於 零 布林值 打勾
        // 水平值 等於 零 布林值 取消
        // 不等於 !=
        Ani.SetBool("走路開關", h != 0);
    }

    /// <summary>
    /// 跳躍
    /// </summary>
    private void 跳躍()
    {
        // "如果"玩家 按下 空白鍵 並且 在地板上 就 往上跳躍
        // 判斷式 C#
        #region 判斷式 if 基本語法

        /* private bool test1 = true;
         * Main 等於 Unity 的Start (記得刪除static)
         * public void Main()
	{
		// 判斷式 if 
        // 語法 :
        // if (布林值) {當布林值等於 true 時會實行這裡的程式}
		if (test1)
		{
			// Console.WriteLine 等於 Unity 的 print
			Console.WriteLine("123");
		}*/
        #endregion
        // ※ 傳回值為布林值的方法可以當成布林值使用
        // 1. OnTheGround == true (原本寫法)
        // 2. OnTheGround (簡寫)
        if (Input.GetKeyDown(KeyCode.Space) && OnTheGround == true)
        {
            //鋼體.添加推力(二維向量)
            Rig2D.AddForce(new Vector2(0, jump));
        }

        // 碰到的物件 = 2D 物理,覆蓋圖形(中心點,半徑,圖層)
        Collider2D hit = Physics2D.OverlapCircle(transform.position + transform.right * groundOffset.x + transform.up * groundOffset.y, groundRadius, 1 << 8);

        // print("碰到的物件：" + hit.name);

        // 如果 碰到的物件 存在 而且 碰到的物件名稱 等於 地板 就代表在地板上
        // 並且 && (Shift + 7
        // 等於 ==
        // 或者 || (Shift + \)
        // 或者 名稱 等於 跳台

        if (hit && (hit.name == "地板" || hit.name == "跳台"))
        {
            OnTheGround = true;
        }
        // 否則 不再地板上
        // 否則 else
        // 語法 : else { 程式區塊 } - 僅能寫在 if 下方
        else
        {
            OnTheGround = false;
        }
    }

    /// <summary>
    /// 開槍
    /// </summary>
    private void 開槍()
    {
        // 如果 玩家按下左鍵 就開槍 - 動畫與音效 發射子彈
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Ani.SetTrigger("攻擊觸發");
            Aud.PlayOneShot(ShotSound, 0.5f);
        }
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
