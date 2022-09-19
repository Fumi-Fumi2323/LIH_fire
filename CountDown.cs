using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 
public class CountDown : MonoBehaviour
{
    //時間設定
    private float time = 10.0f;
    public Text timerText;
    public Text timeUpText;
 
    void Update()
    {
        if (0 < time) {
            time -= Time.deltaTime;
            //コンマ1秒単位の表示
            timerText.text = time.ToString("F1");
        }
        //もし0秒になった時に、TIMEUPのテキスト表示
        else if (time < 0){
            timeUpText.text = "TIME UP";
        }
    }
}
