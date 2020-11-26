using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class AirHockeyAgent :Agent
{
    //現在のステップ数
    [SerializeField] private int currentStep = 0;
    private int CurrentStep{get {return currentStep;} set{currentStep=value;}}

    //手前側
    [SerializeField] private MalletController mallet1;
    private MalletController Mallet1 {get {return mallet1;}}

    //奥側
    [SerializeField] private MalletController mallet2;
    private MalletController Mallet2 {get{return mallet2;}}

    //全てのパックのリスト
    [SerializeField] private List<Rigidbody> pucks;
    private List<Rigidbody> Pucks{get{return pucks;}}

    private int CurrentStepMax{get;set;}

    private List<MalletController> MalletControllers{get;set;}

    //それぞれのパックの初期位置
    private List<Vector3> StartPuckPositions{get;set;}

    //エージェントの位置
    private Vector3 MyPosition {get;set;}

    // 要素別の報酬のリスト
    // (各要素の積で報酬を与えることで、すべての要素を満たす方が
    // 良い報酬が得られる関数となる)
    private List<float> RewardList{get;set;}
    public int Score{get;private set;}

    void Awake()
    {
        MalletControllers=new List<MalletController> {Mallet1, Mallet2};
        StartPuckPositions=Pucks.Select(x=>x.position).ToList(); //??
        MyPosition=transform.position;

        // 報酬に関して
        RewardList=new List<float>(){0,0};
        //報酬を加算
        //
    }
    void FixedUpdate()
    {
    }
    public void Norendering()
    {

    }
    public override void AgentReset()
    {

    }

    public override int GetState()
    {
        return 0;
    }

    public override List<double> CollectObservations()
    {
        return null;
    }
    public override double[] ActionNumberToVectorAction(int ActionNumber)
    {
        return null;
    }

    public override void AgentAction(double[] vectorAction)
    {

    }
    public override void Stop()
    {

    }


}
