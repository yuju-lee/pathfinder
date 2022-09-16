using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Flock : MonoBehaviour
{
    public Rigidbody Rigid;
    public float speed;
    public float maxDiff;
    public float RandomFreq = 10f;
    private float randomLoop;
    private Vector3 randomize;

    public UnitManagement unitManagement;

    void Awake()
    {
        Rigid = GetComponent<Rigidbody>();
        RandomFreq = 1f / RandomFreq;
    }
    public void Update()
    {
        if (!UnitManagement.instance.isSeekerOnOff)
        {
            Rigid.velocity = Vector3.zero;
            return;
        }

        if (unitManagement)
        {
            float diff = Vector3.Distance(unitManagement.target.position, transform.position);
            if(diff < maxDiff)
            {
                Rigid.velocity = Vector3.zero;
                return;
            }

            Vector3 relativePos = Steer() * Time.deltaTime;
            if (relativePos != Vector3.zero)
            {
                Rigid.velocity = relativePos * this.speed;
            }
            
            Vector3 velocity = Rigid.velocity;
            float speed = velocity.magnitude;
            if (speed > unitManagement.maxVelocity)
                Rigid.velocity = velocity.normalized * unitManagement.maxVelocity;
            else if (speed < unitManagement.minVelocity)
                Rigid.velocity = velocity.normalized * unitManagement.minVelocity;


            Vector3 vec = unitManagement.target.position - transform.position;
            vec.Normalize();
            Quaternion q = Quaternion.LookRotation(vec);
            q.x = 0;
            q.z = 0;
            transform.rotation = q;
            //transform.rotation = Quaternion.LookRotation(Rigid.velocity);
        }
    }



    private Vector3 Steer()
    {
        Vector3 center = unitManagement.FlockCenter - transform.position;
        Vector3 velocity = unitManagement.FlockVelocity - Rigid.velocity;
        Vector3 follow = unitManagement.target.position - transform.position;
        Vector3 separation = Vector3.zero;

        foreach (Flock flock in unitManagement.FlockList)
        {
            if (flock != this)
            {
                Vector3 relativePos = transform.position - flock.transform.position;
                separation += relativePos / (relativePos.sqrMagnitude);
            }
        }

        return (unitManagement.centerWeight * center + unitManagement.velocityWeight * velocity + unitManagement.separationWeight * separation +
            unitManagement.followWeight * follow);
    }
    
}
