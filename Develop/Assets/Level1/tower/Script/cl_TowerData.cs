using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class cl_TowerData
{
    //данные башни
    public string name;
    public int damage;
    public float atkspeed;
    public float bltspeed;
    public float reload;
    public GameObject bulletpref;
    public GameObject bulletspawn;
    public float distance;
}
