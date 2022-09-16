using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindDestination : MonoBehaviour
{
    public GameObject DestinationTarget;
    
    void Update() {
        if (true == Input.GetMouseButtonDown(0)) {
            RaycastHit hit;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity)) DestinationTarget.transform.position = hit.point;
            
        }
    }


}

