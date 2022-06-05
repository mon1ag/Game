using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    public float Speed;
    DamageDealer(GameObject _initiator, float _damage)
    {
        Initiator = _initiator;
        Damage = _damage;
    }
    public bool isMovable = false;
    GameObject Initiator;
    float Damage;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {

        }
    }

    private void FixedUpdate()
    {
        if (isMovable)
            transform.position += transform.right* Speed* Time.fixedDeltaTime;
    }
}
