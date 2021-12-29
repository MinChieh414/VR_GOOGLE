using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class CountdownAndDoSomething : MonoBehaviour
{
    #region 欄位與屬性
    [Header("倒數時間"), Range(1, 5)]
    public float timeCountDown = 3;
    [Header("倒數後事件")]
    public UnityEvent onTimeUp;
    [Header("介面")]
    public Image imageBar;

    private float timeMax;
    private float timer;
    /// <summary>
    /// 開始倒數 : true 開始 , false 停止
    /// Unity Event 可以存取
    /// 1.實體物件存取元件內的API
    /// 2.存取方法僅限 : 無或者一個參數 ，有資料類型限制(基本類型)
    /// 3.存取公開屬性 : 有資料類型限制(基本類型)
    /// </summary>
    public bool startCountDowm { get; set; }
    #endregion
    #region 倒數功能
    // 喚醒事件 : 在 Start 前執行一次
    private void Awake()
    {
        timeMax = timeCountDown;
    }1

    private void Update()
    {
        CountDown();
    }

    /// <summary>
    /// 計時器
    /// </summary>
    private void CountDown()
    {
        if (startCountDowm)                   //如果開始倒數
        {
            if (timer < timeCountDown)        //如果 計時器 小於 倒數時間            
                timer += Time.deltaTime;      //累加時間 (於 Update 內呼叫)            
            else
                onTimeUp.Invoke();            //否則 計時器 大於等於 倒數時間 就 呼叫事件
            
            imageBar.fillAmount = timer / timeMax;   //長度 =  當前時間 / 最大時間
        }
        else                                  //否則 沒有看著按鈕 就停止
        {
            timer = 0;                        //歸零
            imageBar.fillAmount = 0;          //長度歸零
        }                        
    }
    #endregion
}
