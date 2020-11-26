using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puck : MonoBehaviour
{
    private Rigidbody RB{get;set;}
    private Vector3 StartPosition {get;set;}
    // Start is called before the first frame update
    void Start()
    {
        RB=GetComponent<Rigidbody>();
        StartPosition=transform.position;
        //初期化(ランダムな方向に力を加える)
        this.transform.eulerAngles= new Vector3(0, Random.Range(0,360),0);
        this.GetComponent<Rigidbody>().AddForce(transform.forward*500);
    }

    public void ResetParams()
    {
        RB.position=StartPosition;
        RB.rotation=Quaternion.identity;
        RB.velocity=Vector3.zero;
        this.transform.eulerAngles = new Vector3(0, Random.Range(0, 360), 0);
        RB.AddForce(transform.forward * 500);
    }
    
    // ??
    public int GetState()
    {
        return 0;
    }

}
