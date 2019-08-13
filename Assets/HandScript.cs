using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandScript : MonoBehaviour {

    public GameObject hand;
    public bool myHands = false;
    public GameObject curItem;
    public float handPower = 10f;
    public Transform exitCamTarget;

    //old item data
    Collider itemCol;
    Rigidbody itemRig;

    public Camera cam;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ExitCam()
    {
        cam.transform.LookAt(exitCamTarget);
    }

    public void GetToHand(GameObject item)
    {
        //idfc how but it works
        //itemCol = item.GetComponent<BoxCollider>();
        //itemRig = item.GetComponent<Rigidbody>();

        //get into hands
        item.transform.SetParent(hand.transform);
        item.transform.localPosition = new Vector3(0, -1.2f, 0);
        curItem = item;

        //Item won't fall
        curItem.GetComponent<Rigidbody>().velocity = Vector3.zero;
        curItem.GetComponent<BoxCollider>().isTrigger = true;
        curItem.GetComponent<Rigidbody>().useGravity = false;
        //itemCol.isTrigger = true;
        //itemRig.useGravity = false;
        Debug.Log("to");
    }

    public void GetOutHand()
    {
        //cam = GetComponentInChildren<Camera>();


        curItem.GetComponent<BoxCollider>().isTrigger = false;
        curItem.GetComponent<Rigidbody>().useGravity = true;
        curItem.transform.SetParent(null);
        curItem.GetComponent<Rigidbody>().velocity = cam.transform.rotation * Vector3.forward * handPower;

        Debug.Log("out");
    }
}
