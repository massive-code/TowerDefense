using UnityEngine;
using System.Collections;

public class scr_Exit : MonoBehaviour {

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
