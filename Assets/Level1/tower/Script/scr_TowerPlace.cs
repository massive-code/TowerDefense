using UnityEngine;
using System.Collections;

public class scr_TowerPlace : MonoBehaviour
{
    scr_GameEngine l_GameEngine;

    void Start()
    {
        l_GameEngine = GameObject.Find("plain_GameEngine").GetComponent<scr_GameEngine>();
    }

    void OnMouseEnter()
    {
        gameObject.GetComponent<Renderer>().material.color = Color.green;
    }

    void OnMouseExit()
    {
        gameObject.GetComponent<Renderer>().material.color = Color.white;
    }

    void OnMouseDown()
    {
        if (l_GameEngine._cl_GD.pi_Money > l_GameEngine._cl_GD.pi_TowerCost)
        {
            Instantiate(l_GameEngine._goTower, gameObject.transform.position, Quaternion.identity);
            l_GameEngine._cl_GD.pi_Money -= l_GameEngine._cl_GD.pi_TowerCost;
        }
    }
}
