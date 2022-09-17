using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointTouched : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        //StageControllerのGameObject型の情報を取得
        GameObject StageController = GameObject.Find("StageController");
        //StageControllerのスクリプトコンポーネントを呼び出す
        StageController script = StageController.GetComponent<StageController>();
        //チェックポイントに触れたら目的地へ到達可能にする
        script.destinationApproved();
    }
}
