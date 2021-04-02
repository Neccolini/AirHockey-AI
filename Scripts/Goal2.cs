using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Goal2 : MonoBehaviour
{
    public string Score2Text; // 表示する文字列 Player1: x点
    private static int Player2Score = 0; // 点数
    const int EndCount=3; //終了する点数 <-ここを変える
    private GameObject targetText; //テキストオブジェクト
    private bool isGoal=false;
    [SerializeField] private Puck puck1;
    private Puck puck{get {return puck1;}}

    private Vector3 StartPosition{get;set;}
    public AudioClip sound;
    public AudioSource audioSource;
    void Start()
    {
        Player2Score=0;
        targetText=GameObject.Find("RightText");
        StartPosition=puck.transform.position;
        audioSource = GetComponent<AudioSource>();
    }
    void Update()
    {
        //Player1側のゴールにパックが入ったら
        if(puck.transform.position.x>10.0f && isGoal==false && puck.transform.position.x<12.0f){
            audioSource.PlayOneShot(sound);
            isGoal=true;
            Player2Score++;
            Score2Text= ("AI:" + Player2Score + "点");
            targetText.GetComponent<Text>().text=Score2Text;
            Invoke("ResetPuck", 2.5f);
            //ゲーム終了
            if(Player2Score>=EndCount){
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