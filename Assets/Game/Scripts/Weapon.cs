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
    public float Damage = 1;
    public float AttackSpeed = 1;

    public Animator Animator;

    public CharacterHoldItem Hands;

    private bool IsAttack;
    // Start is called before the first frame update
    void Start()
    {
        Animator = GetComponent<Animator>();
        Animator.speed = AttackSpeed;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void TryAttack()
    {
        if (!IsAttack)
        {
            if (CurrentCharges < AttackCost || IsReloading)
                return;

            Attack();
        }
    }

    void Attack()
    {
        if (CurrentCharges >= AttackCost)
        {
            IsAttack = true;
            GameObject DamageObj = Instantiate(DamageDealer, DamageParentPoint.position, DamageParentPoint.rotation);
            DamageObj.GetComponent<DamageDealer>().Init(this.gameObject, Damage);
            CurrentCharges -= AttackCost;
            Hands.UpdateWeaponUIDelegate.Invoke();

            Animator.SetTrigger("Attack");
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

    void AttackEnded()
    {
        IsAttack = false;
    }
}
