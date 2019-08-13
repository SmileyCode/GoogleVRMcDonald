using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Rotator : MonoBehaviour {

    //public float spinForce;// rotation

    public float gazeTime = 2f;

    private float timer;
    private bool gazedAt;


    public GameObject item;
    public HandScript handManager;
    //public GameObject hand;
 //   bool inHand = false;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //transform.Rotate(0, spinForce * Time.deltaTime, 0);
        if (gazedAt)
        {
            timer += Time.deltaTime;

            if(timer>=gazeTime)
            {
                ExecuteEvents.Execute(gameObject, new PointerEventData(EventSystem.current), ExecuteEvents.pointerClickHandler);
                timer = 0f;
            }
        }
    }

    //public void ChangeSpin()
    //{
    //    spinForce = -spinForce;
    //}

    public void PointerEnter()
    {
        gazedAt = true;
    }

    public void PointerExit()
    {
        gazedAt = false;
    }

    public void PointerClick()
    {
        if (!handManager.myHands)
        {
            handManager.GetToHand(item);
            handManager.myHands = true;
        }
        else if(handManager.myHands)
        {
            //item.transform.SetParent(null);
            //item.transform.localPosition = new Vector3(0, 0, 0);
            handManager.GetOutHand();
            handManager.myHands = false;
        }

    }
}
