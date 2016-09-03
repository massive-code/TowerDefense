using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class scr_GameEngine : MonoBehaviour {

    public bool pb_Pause = true;


    [System.Serializable]
    public struct str_UserInterface
    {
        public GameObject Money;
        public GameObject Health;
        public GameObject StartStop;
        public GameObject Exit;
    }
    public str_UserInterface l_UI = new str_UserInterface();

    public cl_GameData _cl_GD = new cl_GameData();

    public GameObject pgo_House;
    public int pi_HouseHealth = 5;

    public List<cl_Wave> _cl_Wave = new List<cl_Wave>();
    public List<GameObject> list_UnitLocations = new List<GameObject>();
    public List<GameObject> list_Units = new List<GameObject>();

    public GameObject _goTower;
    public List<GameObject> list_TowerLocations = new List<GameObject>();
    public GameObject go_TowerPlace;

    int CurrentWave;
    int CurrentUnit;

    public float timer_wave;
    bool _b_ShowWaveName = true;
    public float timer_unit;

    bool CreateUnits;

    public float pf_CameraSpeed;
    void Start()
    {
        _cl_GD.pv_ManageData();
        /////////////////////
        timer_wave = _cl_GD.pf_TimerWave;
        timer_unit = _cl_GD.pf_TimerUnit;
        CreateUnits = _cl_GD.pb_CreateUnits;
        /////////////////////
        if (_cl_GD.pb_LockCamera == false)
        {
            pf_CameraSpeed = _cl_GD.pf_CameraSpeed;
        }
        else { pf_CameraSpeed = 0; }
        v_CreateHouse();
        v_CreateTowerPlace();
        //v_CreateTowers();

        
    }

    void v_CreateTowerPlace()
    {
        foreach (GameObject go_temp in list_TowerLocations)
        {
            Instantiate(go_TowerPlace, go_temp.transform.position, Quaternion.identity);
        }
    }

    void v_CreateTowers()
    {
        foreach (GameObject go_temp in list_TowerLocations)
        {
            Instantiate(_goTower, go_temp.transform.position, Quaternion.identity);
        }
    }

    void v_CreateHouse()
    {
        pgo_House = (GameObject)Instantiate(pgo_House, list_UnitLocations[list_UnitLocations.Count-1].transform.position, Quaternion.identity);
    }

    void Update()
    {
        if (pb_Pause == false)
        {
            if (CreateUnits == true)
            {
                v_WaveTimer();
            }
        }
            l_UI.Money.GetComponent<TextMesh>().text = "MONEY: " + _cl_GD.pi_Money;
            l_UI.Health.GetComponent<TextMesh>().text = "HEALTH: " + pi_HouseHealth;
        
    }

    void v_WaveTimer()
    {
        if (timer_wave <= 0)
        {
            v_Wave();
        }
        else
        {
            timer_wave -= Time.deltaTime;
        }
    }

    void v_Wave()
    {
        if (CurrentWave <= _cl_Wave.Count - 1)
        {
            if (_b_ShowWaveName == true)
            {
                //Debug.Log(_cl_Wave[CurrentWave].Name);
                _b_ShowWaveName = false;
            }

            if (timer_unit <= 0)
            {
                v_SpawnUnit();
            }
            else
            {
                timer_unit -= Time.deltaTime;
            }
        }

        else
        {
            //Debug.Log("END");
            CreateUnits = false;
        }
    }

    void v_SpawnUnit()
    {
        if (CurrentUnit <= _cl_Wave[CurrentWave].Units.Count-1)
        {
            //Debug.Log(_cl_Wave[CurrentWave].Units[CurrentUnit].name);
            ///////////////////
            v_CreateObjects();
            ///////////////////
            CurrentUnit++;
            timer_unit = _cl_GD.pf_TimerUnit;
        }
        else
        {
            CurrentWave++;
            CurrentUnit = 0;
            timer_wave = _cl_GD.pf_TimerWave;
            _b_ShowWaveName = true;
        }

    }

    void v_CreateObjects()
    {
        list_Units.Add((GameObject)Instantiate(_cl_Wave[CurrentWave].Units[CurrentUnit], list_UnitLocations[0].transform.position, Quaternion.identity));
    }



}
