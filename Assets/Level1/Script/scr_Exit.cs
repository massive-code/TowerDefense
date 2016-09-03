using UnityEngine;
using System.Collections;

public class scr_Exit : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseDown()
    {
        Application.Quit();
    }


    void OnMouseEnter()
    {
        gameObject.GetComponent<Renderer>().material.color = Color.green;
    }

    void OnMouseExit()
    {
        gameObject.GetComponent<Renderer>().material.color = Color.white;
    }
}
