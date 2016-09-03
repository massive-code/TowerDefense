using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class scr_GameEngine : MonoBehaviour {
    ///////////////////////////////////
    //движок игры
    ///////////////////////////////////
    //глобальная пауза
    public bool pb_Pause = true;
    //объекты польз интерфейса
    [System.Serializable]
    public struct str_UserInterface
    {
        public GameObject Money;
        public GameObject Health;
        public GameObject StartStop;
        public GameObject Exit;
        public GameObject GameOver;
    }
    //завершена ли игра
    bool b_GameOver = false;
    public str_UserInterface l_UI = new str_UserInterface();
    ///////////////////////////////////
    public cl_GameData _cl_GD = new cl_GameData();
    ///////////////////////////////////
    //объект дом
    public GameObject pgo_House;
    //его жизни
    public int pi_HouseHealth = 5;
    ///////////////////////////////////
    //волны, позиции юнитов и кол-во юнитов
    public List<cl_Wave> _cl_Wave = new List<cl_Wave>();
    public List<GameObject> list_UnitLocations = new List<GameObject>();
    public List<GameObject> list_Units = new List<GameObject>();
    ///////////////////////////////////
    //объект башня
    public GameObject _goTower;
    //меторасположения
    public List<GameObject> list_TowerLocations = new List<GameObject>();
    //объект куда можно поставить башню
    public GameObject go_TowerPlace;
    ///////////////////////////////////
    //текущая волна и юнит при создании волн
    int CurrentWave;
    int CurrentUnit;
    ///////////////////////////////////
    //таймер волн
    public float timer_wave;
    //таймер юнитов в волне
    public float timer_unit;
    //создавать ли юнитов
    bool CreateUnits;
    //скорость камеры
    public float pf_CameraSpeed;
    void Start()
    {
        //определяем данные в класса в принципе можно все данные перенести в этот скрипт
        _cl_GD.pv_ManageData();
        /////////////////////
        timer_wave = _cl_GD.pf_TimerWave;
        timer_unit = _cl_GD.pf_TimerUnit;
        CreateUnits = _cl_GD.pb_CreateUnits;
        /////////////////////
        //если камера разблокирована
        if (_cl_GD.pb_LockCamera == false)
        {
            pf_CameraSpeed = _cl_GD.pf_CameraSpeed;
        }
        else { pf_CameraSpeed = 0; }
        //создаем дом
        v_CreateHouse();
        //создаем места для башень
        v_CreateTowerPlace();
    }
    void v_CreateTowerPlace()
    {
        //создаем места башень в каждой точке локации башень
        foreach (GameObject go_temp in list_TowerLocations)
        {
            Instantiate(go_TowerPlace, go_temp.transform.position, Quaternion.identity);
        }
    }
    //создаем дом
    void v_CreateHouse()
    {
        pgo_House = (GameObject)Instantiate(pgo_House, list_UnitLocations[list_UnitLocations.Count-1].transform.position, Quaternion.identity);
    }
    void Update()
    {
        //определяем сздавать ли юнитов
        if (pb_Pause == false)
        {
            if (CreateUnits == true)
            {
                v_WaveTimer();
            }
        }
        //обновляем значения денег и жизней
        l_UI.Money.GetComponent<TextMesh>().text = "MONEY: " + _cl_GD.pi_Money;
            l_UI.Health.GetComponent<TextMesh>().text = "HEALTH: " + pi_HouseHealth;

        //завершаем игру если жизней нет
        if (pi_HouseHealth <= 0 & b_GameOver == false)
        {
            Instantiate(l_UI.GameOver);
            b_GameOver = true;
        }
    }
    //разделил создание юнитов в волне что бы легче было разобраться в таймерах
    //таймер волн
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
    //текушая волна
    void v_Wave()
    {
        if (CurrentWave <= _cl_Wave.Count - 1)
        {
            if (timer_unit <= 0)
            {
                //создаем юнитов
                v_SpawnUnit();
            }
            else
            {
                timer_unit -= Time.deltaTime;
            }
        }

        else
        {
            CreateUnits = false;
        }
    }
    void v_SpawnUnit()
    {
        if (CurrentUnit <= _cl_Wave[CurrentWave].Units.Count-1)
        {
            //создаем объекты юнитов
            list_Units.Add((GameObject)Instantiate(_cl_Wave[CurrentWave].Units[CurrentUnit], list_UnitLocations[0].transform.position, Quaternion.identity));
            CurrentUnit++;
            timer_unit = _cl_GD.pf_TimerUnit;
        }
        else
        {
            CurrentWave++;
            CurrentUnit = 0;
            timer_wave = _cl_GD.pf_TimerWave;
        }

    }
}
