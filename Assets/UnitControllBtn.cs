using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;

public class UnitControllBtn : MonoBehaviour, IPointerClickHandler
{
    Text btnText;
    // Start is called before the first frame update
    void Start()
    {
        btnText = transform.Find("Text").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    bool isOnClick;
    public void OnPointerClick(PointerEventData eventData)
    {
        isOnClick = !isOnClick;
        UnitManagement.instance.isSeekerOnOff = isOnClick;

        if (!isOnClick)
        {
            btnText.text = "OFF";
        }
        else
        {
            btnText.text = "ON";
        }
    }
}
