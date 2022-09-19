using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class goal : MonoBehaviour
{
    private Renderer goalRenderer;
    private StageController script;
    private bool goalCondition;

    void Start() 
    {
        goalCondition = false;
        // ゴールのマテリアルを読み込み
        goalRenderer = GetComponent<Renderer>();
        goalRenderer.material.color = Color.yellow;
        // クリア判定の関数を読み込み
        GameObject stageController = GameObject.Find("StageController");
        script = stageController.GetComponent<StageController>();
    }

    void Update()
    {
        // ゴール可能なら色を変える
        if (!goalCondition && script.goalCondition())
        {
            goalCondition = true;
            goalRenderer.material.color = Color.blue;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // クリア可能か確認する
        // (ゴール条件 : 目的地を順番通り全て通過したか)
        // (チェックポイントを全て通ったかはゴール条件に含まれてないので要修正?)
        if (goalCondition && other.CompareTag("Blue"))
        {
            goalRenderer.material.color = Color.red;
            SceneManager.LoadScene("StageClear");
        }
    }
}
