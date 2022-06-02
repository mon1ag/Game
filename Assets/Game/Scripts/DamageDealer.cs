using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    DamageDealer(GameObject _initiator, float _damage)
    {
        Initiator = _initiator;
        Damage = _damage;
    }

    GameObject Initiator;
    float Damage;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {

        }
    }
}
