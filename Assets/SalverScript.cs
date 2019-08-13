using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SalverScript : MonoBehaviour {

    //public float spinForce;// rotation

    public float gazeTime = 2f;

    private float timer;
    private bool gazedAt;

    public HandScript handManager;

    private int score = 0;
    private int oldscore = 0;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //transform.Rotate(0, spinForce * Time.deltaTime, 0);
        if (gazedAt)
        {
            timer += Time.deltaTime;

            if (timer >= gazeTime)
            {
                PointerClick();
                timer = 0f;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "OkItem")
        {
            score++;
        }
        else score--;
        Debug.Log(score);
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "OkItem")
        {
            score--;
        }
        else score++;
        Debug.Log(score);
    }

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
        if (handManager.myHands)
        {
            //item.transform.SetParent(null);
            //item.transform.localPosition = new Vector3(0, 0, 0);
            handManager.GetOutHand();
            handManager.myHands = false;
        }

    }

    public void SaveScore()
    {
        oldscore = score;
    }

    public void LoadScore()
    {
        score = oldscore;
    }

    public int GetScore()
    {
        return score;
    }
}