
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("移動速度"), Range(0,1000)]
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
    



}
