using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StageClearManager : MonoBehaviour
{
    [SerializeField] private float flashSpeed = 1f;
    [SerializeField] private Text stageClearText;
    [SerializeField] private Text pressKeyText;
    private float alphatime = 0f;

    void Start()
    {
        stageClearText.text = "Stage " + StageSelectManager.currentStage.ToString() + "  CLEAR!!";
        if (StageSelectManager.currentStage < StageSelectManager.stageNumber)
        {
            StageSelectManager.currentStage++;
        }
    }

    void Update()
    {
        // テキストを点滅
        pressKeyText.color = GetAlphaColor(pressKeyText.color);
        // スペースキーでステージ選択画面
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("StageSelect");
        }
    }

    // テキストをSin関数で点滅
    Color GetAlphaColor(Color color)
    {
        alphatime += Time.deltaTime * 5.0f * flashSpeed;
        color.a = Mathf.Sin(alphatime);
        return color;
    }
}
