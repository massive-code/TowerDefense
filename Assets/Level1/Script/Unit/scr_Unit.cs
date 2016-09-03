using UnityEngine;
using System.Collections;

public class scr_Unit : MonoBehaviour {

    cl_UnitData _cl_UD = new cl_UnitData();
    public cl_UnitData.str_Unit _str_UD = new cl_UnitData.str_Unit(); 

    scr_GameEngine _scr_GE;

    bool move = true;
    int key = 1;

    void Start ()
    {
        _scr_GE = GameObject.Find("plain_GameEngine").GetComponent<scr_GameEngine>();
        //Убираем Copy
        string[] ls_GO_Name = gameObject.name.Split(new string[]{"(Clone)"}, System.StringSplitOptions.RemoveEmptyEntries);

        switch (ls_GO_Name[0])
        {
            case "Unit_1": _str_UD = _cl_UD.pstr_U1(); break;
            case "Unit_2": _str_UD = _cl_UD.pstr_U2(); break;
            case "Unit_3": _str_UD = _cl_UD.pstr_U3(); break;
        }
	}

    void Update()
    {
        if (_scr_GE.pb_Pause == false)
        {
            if (move == true)
            {
                if (key <= _scr_GE.list_UnitLocations.Count - 1)
                {
                    if (Vector3.Distance(transform.position, _scr_GE.list_UnitLocations[key].transform.position) > 0)
                    {
                        transform.position = Vector3.MoveTowards(transform.position, _scr_GE.list_UnitLocations[key].transform.position, _str_UD.speed * Time.deltaTime);
                    }
                    else
                    {
                        key++;
                    }
                }
                else
                {
                    move = false;
                }
            }

            if (_str_UD.health <= 0)
            {
                _scr_GE._cl_GD.pi_Money += 5;
                _scr_GE.list_Units.Remove(gameObject);
                DestroyObject(gameObject);
            }
        }
    }
}
