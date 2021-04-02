using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultText : MonoBehaviour
{
    public Text winnerText;

    void Start()
    {
        if (Goal1.player1win == true) //もし「KabeLeftOut.cs」のResultwinnerがtrueだったら
        {
            winnerText.text = ("あなたの勝利"); //winnerTextにPlayer1の勝利と表示
            Goal1.player1win=false;
        }
        else if (Goal1.player1win == false) //もし「KabeLeftOut.cs」のResultwinnerがfalseだったら
        {
            winnerText.text = ("AIの勝利"); //winnerTextにPlayer2の勝利と表示
        }
    }
}