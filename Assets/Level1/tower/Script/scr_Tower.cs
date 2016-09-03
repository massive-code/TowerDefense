using UnityEngine;
using System.Collections;

public class scr_Tower : MonoBehaviour
{
    public cl_TowerData _clTD = new cl_TowerData();
    bool _bAttack = true;
    bool _bReload = false;
    scr_GameEngine _scrGE;

    void Start()
    {
        _scrGE = GameObject.Find("plain_GameEngine").GetComponent<scr_GameEngine>();
    }

    void Update()
    {
        if (_scrGE.pb_Pause == false)
        {
            if (_bAttack == true)
            {
                for (int i = 0; i < _scrGE.list_Units.Count; i++)
                {
                    if (Vector3.Distance(transform.position, _scrGE.list_Units[i].transform.position) < _clTD.distance)
                    {
                        //GameObject _BulletObj = _clTD.bulletpref;
                        //scr_Bullet _BulletScr = _BulletObj.GetComponent<scr_Bullet>();
                        //_BulletScr._Target = _scrGE.list_Units[i];
                        //_BulletObj = (GameObject)Instantiate(_BulletObj, _clTD.bulletspawn.transform.position, Quaternion.identity);

                        //GameObject _BulletObj = (GameObject)Instantiate(_clTD.bulletpref, _clTD.bulletspawn.transform.position, Quaternion.identity);
                        //scr_Bullet _BulletScr = _BulletObj.GetComponent<scr_Bullet>();
                        //_BulletScr._Target = _scrGE.list_Units[i];
                        //_BulletScr.f_Speed = _clTD.bltspeed;
                        //_BulletScr.i_Damage = _clTD.damage;

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
