using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class Player3Controller : MonoBehaviour
{
    [SerializeField] private MalletController mallet;
    private MalletController Mallet{get{return mallet;}}
    private NNBrain brain;
    private List<MalletController> MalletControllers{get;set;}
    private Vector3 MyPosition{get;set;}
    [SerializeField] private Puck puck1;
    private Puck puck{get{return puck1;}}
    private Rigidbody puckRB;
    [SerializeField]private MalletController mallet1;
    private MalletController Mallet1{get{return mallet1;}}
    private Vector3 StartPuckPosition { get; set; }
    // パックと衝突時にパックに与える力を増幅
    float radius = 1.0f;
    float power = 200.0f;
    private Vector3 Velocity { get; set; } = Vector3.zero;
    public Rigidbody RB { get; set; }
    private Vector3 StartPosition { get; set; }
    private Quaternion StartRotation { get; set; }
    private Vector3 Area { get; set; } = new Vector3(3.2f, 0f, 3.2f);


    // NNの入力層のサイズ
    [SerializeField] private int inputSize = 8;
    private int InputSize { get { return inputSize; } }

    // NNの隠れ層のサイズ
    [SerializeField] private int hiddenSize = 10;
    private int HiddenSize { get { return hiddenSize; } }

    // NNの隠れ層の数
    [SerializeField] private int hiddenLayers = 2;
    private int HiddenLayers { get { return hiddenLayers; } }

    // NNの出力層のサイズ
    [SerializeField] private int outputSize = 6;
    private int OutputSize { get { return outputSize; } }
    [Header("Save/Load"), SerializeField] private TextAsset learningData = null;
    private TextAsset LearningData { get { return learningData; } }
    void Start()
    {
        //ロードデータをコピー
        brain=NNBrain.Load(learningData);
        RB = this.GetComponent<Rigidbody>();
        puckRB=puck.GetComponent<Rigidbody>();
        StartPuckPosition=puckRB.position;
        StartPosition = transform.localPosition;
        StartRotation = transform.rotation;
        MalletControllers=new List<MalletController>{Mallet};
        MyPosition=transform.position;
    }

    void Update()
    {

        // マウスの位置にPlayer1を置く
        // 動ける範囲を制限
        //RB.velocity = Velocity;
        AgentUpdate(brain);
        transform.localPosition = new Vector3(
            Mathf.Clamp(transform.localPosition.x, StartPosition.x - Area.x, StartPosition.x + Area.x),
            Mathf.Clamp(transform.localPosition.y, StartPosition.y - Area.y, StartPosition.y + Area.y),
            Mathf.Clamp(transform.localPosition.z, StartPosition.z - Area.z, StartPosition.z + Area.z)
        );
    }
    private void AgentUpdate(NNBrain b)
    {
        var observation = this.CollectObservations();
        var action = b.GetAction(observation);
        this.AgentAction(action);
    }

    private List<double> CollectObservations()
    {
        var observations = new List<double>();
        MalletControllers.ForEach(x =>
        {
            observations.Add(x.RB.position.x - MyPosition.x);
            observations.Add(x.RB.position.z - MyPosition.z);
        });
        observations.Add(mallet1.RB.position.x- MyPosition.x);
        observations.Add(mallet1.RB.position.z - MyPosition.z);
              observations.Add(puckRB.position.x - MyPosition.x);
              observations.Add(puckRB.position.z - MyPosition.z);
              observations.Add(puckRB.velocity.x);
              observations.Add(puckRB.velocity.z);
        return observations;
    }
    private void AgentAction(double[] vectorAction)
    {

        var force = new Vector3(Mathf.Clamp((float)vectorAction[0], -12.0f, 12.0f),
            0.0f, Mathf.Clamp((float)vectorAction[1], -12.0f, 12.0f));

        MalletControllers[0].transform.position += force / 2.0f;
        MalletControllers[0].RB.AddForce(force * 800.0f);

    }
    // パックと衝突時にパックに与える力を増幅
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "puck")
        {
            Vector3 explosionPos = this.transform.position;
            Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
            foreach (Collider hit in colliders)
            {
                Rigidbody rb = hit.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.AddExplosionForce(power, explosionPos, 5.0f);
                }
            }
        }
    }
    private void Stop()
    {
        MalletControllers.ForEach(x=>x.Velocity=Vector3.zero);
    }

}