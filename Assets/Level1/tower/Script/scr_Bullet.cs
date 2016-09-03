using UnityEngine;
using System.Collections;

public class scr_Bullet : MonoBehaviour {

    public GameObject _Target;
    public float f_Speed;
    public int i_Damage;

	void Start ()
    {
        Rigidbody rb_RB = gameObject.AddComponent<Rigidbody>();
    }

    void Update()
    {
        if (_Target != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, _Target.transform.position, 4 * Time.deltaTime);
        }
        else { DestroyObject(gameObject); }
    }

    void OnCollisionEnter(Collision _Coll)
    {
        if (_Coll.gameObject.tag == "tag_unit")
        {
            _Target.GetComponent<scr_Unit>()._str_UD.health -= i_Damage;
            DestroyObject(gameObject);
        }
    }
}
