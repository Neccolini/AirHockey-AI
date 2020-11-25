using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Controll :MonoBehaviour
{
    // パックと衝突時にパックに与える力を増幅
    float radius = 1.0f;
    float power = 200.0f;

    void Start()
    {
        //pass
    }

    void Update()
    {
        // マウスの位置にPlayer1を置く
        Vector3 objectPointInScreen = Camera.main.WorldToScreenPoint(this.transform.position);
        Vector3 mousePointInScreen = new Vector3(Input.mousePosition.x,
                          Input.mousePosition.y,
                          objectPointInScreen.z);
        
        Vector3 mousePointInWorld = Camera.main.ScreenToWorldPoint(mousePointInScreen);
        this.transform.position = mousePointInWorld;
        // 動ける範囲を制限
        Vector3 pos=this.transform.position;
        this.transform.position = new Vector3(Mathf.Clamp(pos.x, -9.2f, -1.0f), 
            pos.y, Mathf.Clamp(pos.z, -5.2f, 5.3f));
    }

    // パックと衝突時にパックに与える力を増幅
    void OnCollisionEnter(Collision other){
        if(other.gameObject.tag=="puck"){
            Vector3 explosionPos = this.transform.position;
            Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
            foreach(Collider hit in colliders){
                Rigidbody rb=hit.GetComponent<Rigidbody>();
                if(rb!=null){
                    rb.AddExplosionForce(power, explosionPos, 5.0f);
                }
            }
        }
    }
}