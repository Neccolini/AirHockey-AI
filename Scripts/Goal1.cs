using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Goal1: MonoBehaviour
{

    public string Score1Text; // 表示する文字列 Player1: x点
    private static int Player1Score=0; // 点数
    const int EndCount=3; // 終了する点数 <-ここを変える
    [SerializeField] private Puck puck1;
    private Puck puck {get {return puck1;}}
    private GameObject targetText; //テキストオブジェクト
    private bool isGoal=false;
    private Vector3 StartPosition{get;set;}
    public static bool player1win=false;
    public AudioClip sound;
    public AudioSource audioSource;
    void Start()
    {
        Player1Score=0;
        targetText=GameObject.Find("LeftText");
        StartPosition=puck.transform.position;
        audioSource = GetComponent<AudioSource>();
    }
    void Update()
    {
        //Player1側のゴールにパックが入ったら
        if(puck.transform.position.x<-10.0f && isGoal==false && puck.transform.position.x>-12.0f){
            audioSource.PlayOneShot(sound);
            isGoal=true;
            Player1Score++;
            Score1Text= ("Player: " + Player1Score + "点");
            targetText.GetComponent<Text>().text=Score1Text;
            Invoke("ResetPuck", 2.5f);
            //ゲーム終了
            if(Player1Score>=EndCount){
                player1win=true;
                SceneManager.LoadScene("Result");
                audioSource.PlayOneShot(sound);
            }
        }
    }


    //パックをリセット
    private void ResetPuck()
    {
        puck.ResetParams();
        isGoal=false;
    }
}

