using UnityEngine;
using System.Collections;

public class scr_StartStop : MonoBehaviour {

    scr_GameEngine l_GameEngine;
    bool b_Start = false;
    void Start () {

        l_GameEngine = GameObject.Find("plain_GameEngine").GetComponent<scr_GameEngine>();
    }
	
	void Update ()
    {
	
	}

    void OnMouseDown()
    {
        if (b_Start == false)
        {
            b_Start = true;
            l_GameEngine.pb_Pause = false;
            gameObject.GetComponent<TextMesh>().text = "STOP";
        }
        else
        {
            b_Start = false;
            l_GameEngine.pb_Pause = true;
            gameObject.GetComponent<TextMesh>().text = "START";
        }
    }

    void OnMouseEnter()
    {
        if (b_Start == false)
        {
            gameObject.GetComponent<Renderer>().material.color = Color.green;
        }
        else
        {
            gameObject.GetComponent<Renderer>().material.color = Color.red;
        }
    }

    void OnMouseExit()
    {
        gameObject.GetComponent<Renderer>().material.color = Color.white;
    }
}
