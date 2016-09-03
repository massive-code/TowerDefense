using UnityEngine;
using System.Collections;

public class scr_House : MonoBehaviour {

    cl_HouseData _cl_HD = new cl_HouseData();
    public cl_HouseData.str_HouseData _str_HD = new cl_HouseData.str_HouseData();
    scr_GameEngine _scrGE;

	void Start ()
    {
        _str_HD = _cl_HD._str_ManageData();
        _scrGE = GameObject.Find("plain_GameEngine").GetComponent<scr_GameEngine>();
    }
	
	void Update ()
    {
	
	}

    void OnCollisionEnter(Collision lco_Coll)
    {
        if (lco_Coll.gameObject.tag == "tag_unit")
        {
            scr_Unit _scr_temp = lco_Coll.gameObject.GetComponent<scr_Unit>();
            _str_HD.pi_Health -= _scr_temp._str_UD.damage;
            DestroyObject(lco_Coll.gameObject);
            _scrGE.list_Units.Remove(lco_Coll.gameObject);
        }

        //string[] ls_GO_UnitName = lco_Coll.gameObject.name.Split(new string[] { "(Clone)" }, System.StringSplitOptions.RemoveEmptyEntries);
        //scr_Unit _scr_temp;
        //switch (ls_GO_UnitName[0])
        //{
        //    case "Unit_1": _scr_temp = lco_Coll.gameObject.GetComponent<scr_Unit>(); _str_HD.pi_Health -= _scr_temp._str_UD.damage; DestroyObject(lco_Coll.gameObject); break;
        //    case "Unit_2": _scr_temp = lco_Coll.gameObject.GetComponent<scr_Unit>(); _str_HD.pi_Health -= _scr_temp._str_UD.damage; DestroyObject(lco_Coll.gameObject); break;
        //    case "Unit_3": _scr_temp = lco_Coll.gameObject.GetComponent<scr_Unit>(); _str_HD.pi_Health -= _scr_temp._str_UD.damage; DestroyObject(lco_Coll.gameObject); break;
        //}

        if (_str_HD.pi_Health < 0)
        {
            gameObject.GetComponent<Renderer>().material.color = Color.black;
        }
    }
}
