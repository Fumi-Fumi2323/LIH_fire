using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageController : MonoBehaviour
{
    public string destinationTagName;   //目的地のタグ名

    private GameObject[] destinationObjects;    //複数の目的地のゲームオブジェクトを格納
    private int destinationTotalCounts;         //目的地の総数をカウント
    private int destinationReachedCounts = 0;   //到達した目的地をカウント
    private bool destinationAccess = false;     //目的地が到達可能か？

    //コンストラクタ処理
    void Start()
    {
        destinationObjects = GameObject.FindGameObjectsWithTag(destinationTagName);
        destinationTotalCounts = destinationObjects.Length;
    }

    //目的地を到達可能にする
    public void destinationApproved()
    {
        destinationAccess = true;
    }

    //目的地に到達可能なのか
    public bool destinationCheck()
    {
        return destinationAccess;
    }

    //到達した目的地を一つ増やす
    public void destinationReached()
    {
        destinationReachedCounts++;
    }

    //全ての目的地に到達しているか
    public bool goalCondition()
    {
        if (destinationReachedCounts >= destinationTotalCounts)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
