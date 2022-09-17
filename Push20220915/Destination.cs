using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destination : MonoBehaviour
{
    public GameObject nextTarget;       //次の目的地のゲームオブジェクトを設定
    public bool firstTarget = false;    //最初の目的地か
    public AudioSource searchAudio;     //探索時の効果音
    public AudioSource OKAudio;        //到達時の効果音
    public AudioSource NGAudio;         //失敗時の効果音
    public float playSpan = 3f;         //演奏間隔の秒数
    public float playStartOffset = 1f;  //演奏開始のオフセット時間(秒)

    private Renderer render;                //マテリアルの色を決定
    private bool soundPermission = false;   //音を発しても良いか
    private bool destinationReached = false;    // 目的地に到達したか

    private float currentTime = 0f;
    private GameObject StageController;
    private StageController script;

    void Start()
    {
        //StageControllerのGameObject型の情報を取得
        StageController = GameObject.Find("StageController");
        //StageControllerのスクリプトコンポーネントを呼び出す
        script = StageController.GetComponent<StageController>();
        //目的地の色を変更
        render = GetComponent<Renderer>();
        render.material.color = Color.red;
    }

    void Update()
    {
        if (! destinationReached)
        {
            if (soundPermission)
            {
                currentTime += Time.deltaTime;
                if (currentTime > playSpan){
                    // 効果音を発する
                    searchAudio.Play();
                    currentTime = 0f;
                }
            }
            else if (firstTarget && script.destinationCheck())
            {
                targetSoundStart();
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Blue") && destinationReached == false)
        {
            if (soundPermission) {
                destinationReached = true;
                //オブジェクトの色を変更する
                render.material.color = Color.white;
                //効果音を発する
                searchAudio.Stop();
                OKAudio.Play();
                //到達した目的地カウントを１増やす
                script.destinationReached();
                if (nextTarget != null)
                {
                    //次の目的地の効果音を演奏開始する
                    Destination nextTargetScript = nextTarget.GetComponent<Destination>();
                    nextTargetScript.targetSoundStart();
                }
            }
            else
            {
                //効果音を発する
                searchAudio.Stop();
                NGAudio.Play();
            }
        }

    }

    //効果音を演奏開始する
    public void targetSoundStart()
    {
        soundPermission = true;
        currentTime = playStartOffset;
    }
}
