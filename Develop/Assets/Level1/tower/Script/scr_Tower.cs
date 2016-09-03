using UnityEngine;
using System.Collections;

public class scr_Tower : MonoBehaviour
{
    //данные башни
    public cl_TowerData _clTD = new cl_TowerData();
    bool _bAttack = true;
    bool _bReload = false;
    //ссылка на движок
    scr_GameEngine _scrGE;
    void Start()
    {
        //получаем объект по имени
        _scrGE = GameObject.Find("plain_GameEngine").GetComponent<scr_GameEngine>();
    }
    void Update()
    {
        //если игра не на паузе
        if (_scrGE.pb_Pause == false)
        {
            //если не перезарядка башни
            if (_bAttack == true)
            {
                for (int i = 0; i < _scrGE.list_Units.Count; i++)
                {
                    //получ дист до всех юнитов - если дист достаточ для атаки - атакуем
                    if (Vector3.Distance(transform.position, _scrGE.list_Units[i].transform.position) < _clTD.distance)
                    {
                        //созд объект пули для передачи ему объекта юнита
                        GameObject _BulletObj = _clTD.bulletpref;
                        scr_Bullet _BulletScr = _BulletObj.GetComponent<scr_Bullet>();
                        _BulletScr._Target = _scrGE.list_Units[i];
                        _BulletScr.f_Speed = _clTD.bltspeed;
                        _BulletScr.i_Damage = _clTD.damage;
                        Instantiate(_BulletObj, _clTD.bulletspawn.transform.position, Quaternion.identity);
                        _bAttack = false;
                        _bReload = true;
                    }
                }
            }
        }

        //перезарядка башни таймер
        if (_bReload == true)
        {
            if (_clTD.reload < 0)
            {
                _bAttack = true;
                _clTD.reload = 1F;
            }
            else
            {
                _clTD.reload -= Time.deltaTime;
            }
        }
    }
}
