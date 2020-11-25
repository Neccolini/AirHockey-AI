using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuckStart : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //初期化(ランダムな方向に力を加える)
        this.transform.eulerAngles= new Vector3(0, Random.Range(0,360),0);
        this.GetComponent<Rigidbody>().AddForce(transform.forward*500);
    }


}
