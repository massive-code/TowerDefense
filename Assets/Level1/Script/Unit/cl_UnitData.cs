using UnityEngine;
using System.Collections;

[System.Serializable]
public class cl_UnitData
{
    
    public struct str_Unit
    {
        public float speed;
        public string name;
        public float health;
        public int armor;
        public int damage;
    }

    #region Unit_1
    public str_Unit pstr_U1()
    {
        str_Unit lstr_Temp = new str_Unit();
        lstr_Temp.health = 2;
        lstr_Temp.name = "unit_1";
        lstr_Temp.speed = 2F;
        lstr_Temp.armor = 1;
        lstr_Temp.damage = 1;
        return lstr_Temp;
    }
    #endregion

    #region Unit_2

    public str_Unit pstr_U2()
    {
        str_Unit lstr_Temp = new str_Unit();
        lstr_Temp.health = 3;
        lstr_Temp.name = "unit_2";
        lstr_Temp.speed = 3F;
        lstr_Temp.armor = 2;
        lstr_Temp.damage = 2;
        return lstr_Temp;
    }
    #endregion

    #region Unit_3

    public str_Unit pstr_U3()
    {
        str_Unit lstr_Temp = new str_Unit();
        lstr_Temp.health = 4;
        lstr_Temp.name = "unit_3;";
        lstr_Temp.speed = 4F;
        lstr_Temp.armor = 3;
        lstr_Temp.damage = 3;
        return lstr_Temp;
    }
    #endregion

}
