using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public interface ITakingDamage
{
    void GetDamage(float Damage);
}
public class DamageTarget : MonoBehaviour, ITakingDamage
{
    public DamagePopup DamageUI;
    public float Heach = 100f;
    public float Armor = 0;
    bool isDead;
    public void GetDamage(float Damage)
    {
        Heach -= Damage - Armor;
        DamagePopup text = Instantiate(DamageUI, transform.position, Quaternion.identity);
        text.SetText(Damage - Armor);
        CheckDeath();
    }

    public void CheckDeath()
    {
        if (Heach <= 0)
            isDead = true;
        GetComponent<Collider2D>().enabled = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
