using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StageSelectManager : MonoBehaviour
{

    public static int stageNumber = 3;                      //ステージの総数
    [HideInInspector] public static int currentStage;       //現在のステージ
    [HideInInspector] public static string sceneFileName;   //ステージのシーン名
    [SerializeField] private Text stageText;        //ステージ名のテキスト
    [SerializeField] private Text leftArrowText;    //左矢印のテキスト
    [SerializeField] private Text rightArrowText;   //右矢印のテキスト

    void Start()
    {
        if (currentStage < 1 || currentStage > stageNumber)
        {
            currentStage = 1;
        }
        stageNameDisplay(currentStage);
        arrowDisplay(currentStage);
    }

    void Update()
    {
        // 左右キーでステージ選択
        if (Input.GetKeyDown(KeyCode.LeftArrow) && currentStage >= 2)
        {
            currentStage--;
            stageNameDisplay(currentStage);
            arrowDisplay(currentStage);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) && currentStage < stageNumber)
        {
            currentStage++;
            stageNameDisplay(currentStage);
            arrowDisplay(currentStage);
        }
        // スペースキーでステージ開始
        if (Input.GetKeyDown(KeyCode.Space))
        {
            sceneFileName = "stage" + currentStage.ToString();
            SceneManager.LoadScene(sceneFileName);
        }
        // Escキーでタイトル画面へ
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("GameTitle");
        }
    }

    //ステージ名表示
    void stageNameDisplay(int stageNum)
    {
        stageText.text = "Stage " + stageNum.ToString();
    }

    //矢印を表示
    void arrowDisplay(int stageNum)
    {
        leftArrowText.text = "←";
        rightArrowText.text = "→";
        if (stageNum == 1)
        {
            leftArrowText.text = "";
        }
        else if (stageNum == stageNumber)
        {
            rightArrowText.text = "";
        }
    }
}
