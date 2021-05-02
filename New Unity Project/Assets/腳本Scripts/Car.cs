using UnityEngine;

public class Car : MonoBehaviour
{
    #region 欄位
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
    #endregion

    #region 事件
    public int number = 1;
    public bool test = false;
    public string prop = "紅色藥水";

    // 事件：在特定時間點會被執行的方法
    //Unity 提供的事件：開始、更新

    //開始事件時行的時間點與次數：播放遊戲後執行一次
    //應用：數值初始畫，例如：遊戲一開始都金幣或生命質等等...
    private void Start()
    {
        // print(任何資料)－輸出資料到 Console 儀表板上
        print("我是開始事件~");

        // 欄位存取
        // 取得
        // 語法：欄位名稱
        print("取得欄位:" + number);

        // 存放
        // 語法：欄位名稱 指定 值 ;
        // ※值必須與此欄位類型相同
        test = true;
        print("存放欄位後的結果:" + test);

        prop = "藍色藥水";
        print("存放後的道具名稱:" + prop);

        // ※ 呼叫方法
        // 方法名稱() ;
        Test();
        // 傳回方法:
        // 傳回類型 t->名稱(可自行命名) = 傳回方法() ;
        int t = Ten();
        print("傳回方法的結果:" + t);
    }

    // 更新事件時行時間點與次數：開始事件後以每秒約六十次執行 60FPS
    // 應用：監聽玩家輸入與物件持續行為，例如：玩家有沒有按按鈕或讓物件持續移動
    private void Update()
    {
        print("我是更新事件");
    }


    #endregion

    #region 方法
    // 方法 : 保存較複雜或演算法的程式區塊
    // 語法 : 
    // 修飾詞 傳回類型 名稱() { 較複雜或演算法的程式區塊 }
    // void 無傳回 : 使用這個方法不會有傳回
    // 方法需要被【呼叫】才會執行
    /// <summary>
    /// 我是一個測試方法
    /// </summary>
    private void Test()
    {
        print("我是測試方法");
    }

    // 如果不是無傳回 void
    //在大括號內必須使用 傳回 return 值 (必須與傳回類型相同)
    /// <summary>
    /// 這是傳回整數十的方法
    /// </summary>
    /// <returns>整數十</returns>
    private int Ten()
    {
        return 10;
    }
    #endregion
}
