using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class cl_GameData  {

    public bool pb_CreateUnits;

    public float pf_TimerWave;
    public float pf_TimerUnit;

    public float pf_CamersSpeed;
    public bool pb_LockCamera;
    public void pv_ManageData()
    {
        pb_CreateUnits = true;
        /////////////////////////////
        pf_TimerWave = 1F;
        pf_TimerUnit = 1F;
        /////////////////////////////
        pb_LockCamera = true;
        pf_CamersSpeed = 3F;
    }

}
