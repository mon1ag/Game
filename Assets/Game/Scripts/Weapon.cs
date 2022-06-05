using IndieMarc.TopDown;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IItemActions
{
    void MainAction();
}

public class Weapon : MonoBehaviour, IItemActions
{
    public Transform DamageParentPoint;

    bool IsReloading = false;
    public float AllCharges = 5;
    public float MaxCharges = 5;
    public float CurrentCharges = 5;
    public float ClipSize = 5;
    public float AttackCost = 1;
    public GameObject DamageDealer;

    public CharacterHoldItem Hands;
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
        if (CurrentCharges < AttackCost || IsReloading)
            return false;
        Attack();
        return true;
    }

    void Attack()
    {
        Debug.Log("Attack");
        if (CurrentCharges >= AttackCost)
        {
            Instantiate(DamageDealer, DamageParentPoint.position, DamageParentPoint.rotation);
            CurrentCharges -= AttackCost;
            Hands.UpdateWeaponUIDelegate.Invoke();
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
            float ReloadingCount = ClipSize - CurrentCharges;
            if (AllCharges < ClipSize)
            {
                if (AllCharges < ReloadingCount)
                    ReloadingCount = AllCharges;
            }
            CurrentCharges = ReloadingCount;
            AllCharges -= ReloadingCount;
        }
    }

    void IItemActions.MainAction()
    {
        TryAttack();
    }
}
