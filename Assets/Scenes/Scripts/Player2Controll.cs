using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Controll : MonoBehaviour
{
    // パックを追跡
    public Transform target;
    public float speed;
    // パックと衝突時にパックに与える力を増幅
    float radius = 1.0f;
    float power = 200.0f;
    void Update()
    {
        // 動ける範囲を制限
        Vector3 pos=this.transform.position;
        this.transform.position = new Vector3(Mathf.Clamp( pos.x, 1.0f, 8.0f),
            pos.y, Mathf.Clamp(pos.z, -2.5f, 2.5f));
        // パックを追跡
        this.transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(target.position - transform.position), 0.1f);
        this.transform.position+=transform.forward*speed;
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