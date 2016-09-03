using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class scr_GameEngine : MonoBehaviour {

    cl_GameData _cl_GD = new cl_GameData();

    public GameObject pgo_House;

    public List<cl_Wave> _cl_Wave = new List<cl_Wave>();
    public List<GameObject> list_UnitLocations = new List<GameObject>();
    public List<GameObject> list_Units = new List<GameObject>();

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
            pf_CameraSpeed = _cl_GD.pf_CamersSpeed;
        }
        else { pf_CameraSpeed = 0; }
        v_CreateHouse();
	}

    void v_CreateHouse()
    {
        Instantiate(pgo_House, list_UnitLocations[list_UnitLocations.Count-1].transform.position, Quaternion.identity);
    }

    void Update()
    {
        if (CreateUnits == true)
        {
            v_WaveTimer();
        }
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
                Debug.Log(_cl_Wave[CurrentWave].Name);
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
            Debug.Log("END");
            CreateUnits = false;
        }
    }

    void v_SpawnUnit()
    {
        if (CurrentUnit <= _cl_Wave[CurrentWave].Units.Count-1)
        {
            Debug.Log(_cl_Wave[CurrentWave].Units[CurrentUnit].name);
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
