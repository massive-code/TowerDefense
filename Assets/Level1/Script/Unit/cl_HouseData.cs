using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class cl_HouseData {

    public struct str_HouseData
    {
        public int pi_Health;
    }
    public str_HouseData _str_ManageData()
    {
        str_HouseData _str_temp = new str_HouseData();
        _str_temp.pi_Health = 10;
        return _str_temp;
    }
  

}
