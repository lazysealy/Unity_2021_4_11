using UnityEngine;

public class Car : MonoBehaviour
{
    // 單行註解 2021.4.25 練習
    /*
     * 多行註解
     * 2021.4.25
     * 練習
     */

    // 物件資料 - 欄位 Field :儲存物件資料
    // 欄位語法
    // 修飾詞 類型 名稱 指定 預設值 結尾

    // 四大類型
    // 整　數 int:任何沒有小數點的正負數值
    // 浮點數 float:任何有小數點的正負數值，結尾要加f(大小寫皆可)
    // 字　串 string:任何文字，必須使用雙引號""
    // 布林植 bool:正反 true 、false

    // 關鍵字 顏色:藍色
    // 自訂名稱 顏色:白色

    // 修飾詞
    // 私人:不顯示 pruvate(預設值)
    // 公開:顯  示 public

    // 欄位屬性
    // 屬性明稱("屬性內容")]
    // 標題 Header("字串)
    // 提示 ToolTip("字串")
    // 範圍 Range(最小值，最大值)－限定數值類型

    [Header("汽車 cc 數")]
    [Tooltip("這是汽車的cc數")]
    [Range(1000, 5000)]
    public int cc = 2000;
    [Header("汽車重量"),Tooltip("這是汽車重量"),Range(0.5f, 10)]
    public float weight = 1.5f;
    [Header("汽車品牌")]
    public string brand = "BMW";
    [Header("有無天窗")]
    public bool hasWindow = true ;

    // Unity 常見類型
    // 顏色 Color
    public Color color;
    public Color 紅 = Color.red;
    public Color 黃 = Color.yellow;
    public Color 自訂義顏色 = new Color(0.3f,0,0.6f);            //Color(紅,綠,藍)
    public Color 自訂義顏色包涵透明度 = new Color(0,0.5f,0.5f);   //Color(紅,綠,藍,透明度)

    // 座標二維~四維 Vector2~4
    public Vector2 v2預設;
    public Vector2 v2數值為0 = Vector2.zero;
    public Vector2 v2數值為1 = Vector2.one;
    public Vector2 v2自訂 = new Vector2(7, 9);

    public Vector3 三維座標XYZ = new Vector3(1, 2, 3);
    public Vector4 四維座標XYZW = new Vector4(1, 2, 3, 4);

    // 按鍵 KeyCode
    public KeyCode 按鍵預設;                                // 不指定為 None (無)
    public KeyCode 按鍵自訂 = KeyCode.A;
    public KeyCode 滑鼠按鍵 = KeyCode.Mouse0;               // 左 0,右 1,滾輪 2
    public KeyCode 搖桿按鍵 = KeyCode.Joystick1Button0;

    // 遊戲物件與元件
    // 遊戲物件GameObject
    public GameObject 物件1;
    public GameObject 物件2;
    // 元件 Component - 屬性面板上可摺疊的
    // 名稱去掉空格
    public Transform tra;                                   //可儲存任何包含 Transform 元件的物件
    public SpriteRenderer spr;                              //可儲存任何包含 SpriteRenderer元件的物件
}
