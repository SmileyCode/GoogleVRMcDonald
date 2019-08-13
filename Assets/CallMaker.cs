using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CallMaker : MonoBehaviour {


    public float gazeTime = 2f;

    private float timer;
    private bool gazedAt;

    private float playTimer;
    private float timeToExit = 0;

    public TextMesh callText;
    public TextMesh scoreText;
    public GameObject[] names = new GameObject[4];
    public GameObject[] call = new GameObject[2];
    public SalverScript salver;

    // Use this for initialization
    void Start () {
        UpdateCall();
    }
	
	// Update is called once per frame
	void Update () {
        if (gazedAt)
        {
            timer += Time.deltaTime;

            if (timer >= gazeTime)
            {

                PointerClick();
                timer = 0f;
            }
        }
        playTimer += Time.deltaTime;
        if(playTimer >= 60f)
        {
            timeToExit += Time.deltaTime;
            scoreText.text = "Score: " + salver.GetScore();
            if(timeToExit >= 10f) salver.handManager.ExitCam();
        }
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
        salver.SaveScore();
        ResetItems();
        UpdateCall();
        salver.LoadScore();
    }

    public void UpdateCall()
    {
        for (int i = 0; i < call.Length; i++)
        {
            bool isTrue = false;
            while (!isTrue)
            {
                int value = Random.Range(0, names.Length);
                call[i] = names[value];
                isTrue = true;
                for (int j = 0; j < i; j++)
                {
                    if (call[j].name == call[i].name)
                    {
                        isTrue = false;
                    }
                }
            }
            call[i].gameObject.tag = "OkItem";
        }
        callText.text = "";
        for (int i = 0; i < call.Length; i++)
        {
            callText.text += call[i].name + "\n";
        }
    }

    public void ResetItems()
    {
        foreach (var item in names)
        {
            item.transform.localPosition = new Vector3(Random.Range(-12, -6), 14, Random.Range(-2, 8));
            item.gameObject.tag = "Untagged";
        }
    }
}
