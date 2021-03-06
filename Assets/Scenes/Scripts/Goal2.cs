using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Goal2 : MonoBehaviour
{
    public string Score1Text; // 表示する文字列 Player1: x点
    public static int Player1Score = 0; // 点数
    const int EndCount=3; //終了する点数 <-ここを変える
    GameObject puck; //パック
    GameObject targetText; //テキストオブジェクト
    private bool isGoal=false;
    void Start()
    {
        Player1Score=0;
        puck=GameObject.Find("puck");
        targetText=GameObject.Find("RightText");
    }
    void Update()
    {
        //Player1側のゴールにパックが入ったら
        if(puck.transform.position.x>10.0f && isGoal==false){
            Player1Score++;
            Score1Text= ("Player1:" + Player1Score + "点");
            targetText.GetComponent<Text>().text=Score1Text;
            isGoal=true;
            //ゲーム終了
            if(Player1Score>=EndCount){
                targetText.GetComponent<Text>().text="You lose...";
                Debug.Log("Quit");
                QuitClass q=new QuitClass();
                q.Quit();
            }
            Invoke("ResetPuck", 3.5f);
        }
    }
    //パックをリセット
    private void ResetPuck()
    {
        puck.transform.position=new Vector3(0.0f,0.0f,0.0f);
        puck.transform.eulerAngles= new Vector3(0, Random.Range(0,360),0);
        puck.GetComponent<Rigidbody>().velocity/=10.0f;
        isGoal=false;
    }
}