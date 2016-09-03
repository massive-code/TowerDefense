using UnityEngine;
using System.Collections;

public class scr_camera : MonoBehaviour {

    public scr_GameEngine _scr_GE;

	void Start () {
	
	}
	
	void Update () {

        if (Input.mousePosition.x < 2F)
        {
            transform.position -= new Vector3(_scr_GE.pf_CameraSpeed * Time.deltaTime, 0, 0);
        }

        if (Input.mousePosition.x > (Screen.width - 2F))
        {
            transform.position += new Vector3(_scr_GE.pf_CameraSpeed * Time.deltaTime, 0, 0);
        }

        if (Input.mousePosition.y < 2F)
        {
            transform.position -= new Vector3(0, 0, _scr_GE.pf_CameraSpeed * Time.deltaTime);
        }

        if (Input.mousePosition.y > (Screen.height - 2F))
        {
            transform.position += new Vector3(0, 0, _scr_GE.pf_CameraSpeed * Time.deltaTime);
        }

        if (Input.GetAxis("Mouse ScrollWheel") <0)
        {
            transform.position += new Vector3(0,  _scr_GE.pf_CameraSpeed * Time.deltaTime,0);
        }
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            transform.position -= new Vector3(0, _scr_GE.pf_CameraSpeed * Time.deltaTime, 0);
        }
        //Debug.Log(_scr_GE.pf_CameraSpeed);
    }
}
