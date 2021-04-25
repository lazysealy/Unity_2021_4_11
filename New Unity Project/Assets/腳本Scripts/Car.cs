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
    public Color 自訂義顏色 = new Color(0.3f,0,0.6f);         //Color(紅,綠,藍)
    public Color 自訂義顏色包涵透明度 = new Color(0,0.5f,0.5f);  //Color(紅,綠,藍,透明度)

    // 座標二維~四維 Vector2~4
}
