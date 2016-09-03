using UnityEngine;
using System.Collections;

public class scr_House : MonoBehaviour {

    //ссылка на движок
    scr_GameEngine _scrGE;
	void Start ()
    {
        //получаем объект по имени 
        _scrGE = GameObject.Find("plain_GameEngine").GetComponent<scr_GameEngine>();
    }
	void Update ()
    {
        //если жизней нет то окрасить черным
        if (_scrGE.pi_HouseHealth < 0)
        {
            gameObject.GetComponent<Renderer>().material.color = Color.black;
        }
    }
    void OnCollisionEnter(Collision lco_Coll)
    {
        //при столкновении опред что это юнит по тегу
        //отнять жизни в соотв с поврежд юнита
        //затем уничтожаем сам объект юнита и удаляем из коллекции движка
        if (lco_Coll.gameObject.tag == "tag_unit")
        {
            scr_Unit _scr_temp = lco_Coll.gameObject.GetComponent<scr_Unit>();
            _scrGE.pi_HouseHealth -= _scr_temp._str_UD.damage;
            DestroyObject(lco_Coll.gameObject);
            _scrGE.list_Units.Remove(lco_Coll.gameObject);
        }
    }
}
