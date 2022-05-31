using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAttack
{
    void Attack();
}

public class Weapon : MonoBehaviour, IAttack
{
    bool IsReloading = false;
    int AllCharges = 5;
    int CurrentCharges = 5;
    int ClipSize = 5;
    int AttackCost = 1;
    public GameObject DamageDealer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    bool TryAttack()
    {
        if (AllCharges < AttackCost || IsReloading)
            return false;
        return true;
    }

    void Attack()
    {
        if (CurrentCharges > AttackCost)
        {
            Instantiate(DamageDealer);
            CurrentCharges -= AttackCost;
        }
        if(CurrentCharges<AttackCost)
        {
            Reload();
        }

    }
    void Reload()
    {
        if(AllCharges > 0)
        {
            int ReloadingCount = ClipSize - CurrentCharges;
            if (AllCharges < ClipSize)
            {
                if (AllCharges < ReloadingCount)
                    ReloadingCount = AllCharges;
            }
            CurrentCharges = ReloadingCount;
            AllCharges -= ReloadingCount;
        }
    }

    void IAttack.Attack()
    {
        TryAttack();
    }
}
