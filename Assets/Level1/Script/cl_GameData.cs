using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class cl_GameData  {

    public bool pb_CreateUnits;

    public float pf_TimerWave;
    public float pf_TimerUnit;

    public float pf_CameraSpeed;
    public bool pb_LockCamera;

    public int pi_Money;
    public int pi_TowerCost;

    public void pv_ManageData()
    {
        pb_CreateUnits = true;
        /////////////////////////////
        pf_TimerWave = 1F;
        pf_TimerUnit = 1F;
        /////////////////////////////
        pb_LockCamera = true;
        pf_CameraSpeed = 3F;
        /////////////////////////////
        pi_Money = 20;
        pi_TowerCost = 10;
    }

}
