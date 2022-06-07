using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    public float Speed;
    public float TimeBeforeDestroy = 0;
    public void Init(GameObject _initiator, float _damage)
    {
        Initiator = _initiator;
        Damage = _damage;
        if (!isMovable)
            transform.SetParent(Initiator.transform);
    }
    public bool isMovable = false;
    GameObject Initiator;
    float Damage;

    private void Start()
    {
        if(!isMovable)
            Invoke("DestroySelf", TimeBeforeDestroy);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Damageble"))
        {
            collision.gameObject.GetComponent<ITakingDamage>().GetDamage(Damage);
        }
        Invoke("DestroySelf", TimeBeforeDestroy);
        return;
    }

    private void FixedUpdate()
    {
        if (isMovable)
            transform.position += transform.right* Speed* Time.fixedDeltaTime;
    }

    private void DestroySelf()
    {
        Destroy(gameObject);
    }
}
