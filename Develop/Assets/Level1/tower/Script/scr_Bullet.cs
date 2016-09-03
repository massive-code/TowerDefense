using UnityEngine;
using System.Collections;

public class scr_Bullet : MonoBehaviour {

    //объект полученный от башни к которому будет лететь пуля
    public GameObject _Target;
    public float f_Speed;
    public int i_Damage;
	void Start ()
    {
        //передаем пуле компонент веса для определения соприкосновения с юнитом
        //можно и через дистанцию
        Rigidbody rb_RB = gameObject.AddComponent<Rigidbody>();
    }
    void Update()
    {
        //если объект уже был уничтожен другой башней
        //то удалить пулю
        if (_Target != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, _Target.transform.position, 4 * Time.deltaTime);
        }
        else { DestroyObject(gameObject); }
    }
    void OnCollisionEnter(Collision _Coll)
    {
        //при столкнов с юнитом отнять у юнита жизни
        if (_Coll.gameObject.tag == "tag_unit")
        {
            _Target.GetComponent<scr_Unit>()._str_UD.health -= i_Damage;
            DestroyObject(gameObject);
        }
    }
}
