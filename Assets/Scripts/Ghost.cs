using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    public GameObject target;
    void Update()
    {
        Vector3 temp = new Vector3 (target.transform.position.x, 0.0f, target.transform.position.z);
        this.transform.position = temp;
    }
}
