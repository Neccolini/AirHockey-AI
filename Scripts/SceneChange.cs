using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class SceneChange : MonoBehaviour
{
    public void NextScene() //タイトル画面からゲーム画面に移動
    {
        if (SceneManager.GetActiveScene().name == "Title")//もし現在のシーンがタイトル画面だったら
        {
            SceneManager.LoadScene("Play");//ゲーム画面に移動
        }
    }
    public void NextTitle() //結果画面からタイトル画面に移動
    {
        if (SceneManager.GetActiveScene().name == "Result")//もし現在のシーンが結果画面だったら
        {
            SceneManager.LoadScene("Title");//タイトル画面に移動
        }
    }
    public void BackToGame()
    {
        if(SceneManager.GetActiveScene().name == "Result")
        {
            SceneManager.LoadScene("Play");
        }
    }
}