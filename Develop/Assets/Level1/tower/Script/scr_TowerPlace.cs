using UnityEngine;
using System.Collections;

public class scr_TowerPlace : MonoBehaviour
{
    //ссылка на движок
    scr_GameEngine l_GameEngine;
    //находится ли на месте башня
    bool b_TowerStay = false;
    void Start()
    {
        //получаем объект по имени
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
        //если кол-во денег позволяет ставим башню
        if (b_TowerStay == false)
        {
            if (l_GameEngine._cl_GD.pi_Money >= l_GameEngine._cl_GD.pi_TowerCost)
            {
                Instantiate(l_GameEngine._goTower, gameObject.transform.position, Quaternion.identity);
                l_GameEngine._cl_GD.pi_Money -= l_GameEngine._cl_GD.pi_TowerCost;
                b_TowerStay = true;
            }
        }

    }
}
