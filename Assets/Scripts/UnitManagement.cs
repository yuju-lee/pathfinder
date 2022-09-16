using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitManagement : MonoBehaviour
{
    public static UnitManagement instance;
    public Transform randomStartPos;
    public List<Transform> radomStartPosList = new List<Transform>();

    public float minVelocity = 5;       
    public float maxVelocity = 50;       
    public int flockSize = 20;          
    public float centerWeight = 2;      
    public float velocityWeight = 10;    
    public float separationWeight = 5; 
    public float followWeight = 5;      
    public float randomizeWeight = 3;   

    public Flock prefab;
    public Transform seeker;
    public Transform target;        

    public Vector3 FlockCenter;     
    public Vector3 FlockVelocity;   

    public readonly ArrayList FlockList = new ArrayList();

    public bool isSeekerOnOff;

    private void Awake()
    {
        instance = this;
        radomStartPosList.AddRange(randomStartPos.GetComponentsInChildren<Transform>());
    }

    void Start()
    {
        for (int i = 0; i < flockSize; i++)
        {
            Flock flock = Instantiate(prefab, new Vector3(0.0f, 0.0f, 0.0f), transform.rotation) as Flock;
            if (flock != null)
            {
                flock.transform.parent = transform;
                flock.unitManagement = this;
                flock.transform.position = transform.position + Random.insideUnitSphere * centerWeight;
                flock.transform.localPosition = new Vector3(flock.transform.localPosition.x, 0);
                FlockList.Add(flock);
            }
        }
        
    }
    void Update()
    {
        Vector3 center = Vector3.zero;
        Vector3 velocity = Vector3.zero;

        foreach (Flock flock in FlockList)
        {
            center += flock.transform.position;
            velocity += flock.Rigid.velocity;
        }

        FlockCenter = center / flockSize;
        FlockVelocity = velocity / flockSize;
    }

}
