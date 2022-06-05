using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IndieMarc.TopDown
{
    [RequireComponent(typeof(PlayerCharacter))]
    public class CharacterHoldItem : MonoBehaviour
    {
        public Transform hand;
        public Transform UIAmmoCounter;

        private PlayerCharacter character;

        private List<CarryItem> held_item;
        int CurrentItem = 0;

        public delegate void DUpdateWeaponUI();
        public DUpdateWeaponUI UpdateWeaponUIDelegate;
        void Awake()
        {
            character = GetComponent<PlayerCharacter>();
        }

        private void Start()
        {
            UpdateWeaponUIDelegate += UpdateWeaponUI;
            held_item = new List<CarryItem>();
            character.onDeath += DropItem;
        }

        private void Update()
        {
            if (held_item.Count > 0)
            {
                if (Input.GetKeyDown(KeyCode.Mouse0))
                    held_item[CurrentItem].GetComponent<IItemActions>().MainAction();
            }
        }

        void FixedUpdate()
        {
            if (held_item.Count > 0)
            {
                var lookAtPos = Input.mousePosition;
                
                lookAtPos.z = -10;
                lookAtPos = Camera.main.ScreenToWorldPoint(lookAtPos);
                float angle = AngleBetweenPoints(transform.position, lookAtPos);

                //Ta daa
                held_item[CurrentItem].transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
            

            float AngleBetweenPoints(Vector2 a, Vector2 b)
            {
                return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
            }
            }
        }

        public void TakeItem(CarryItem item) {

            if (!item)
                return;
            item.transform.position = hand.position;
            held_item.Add(item);
            item.transform.SetParent(hand);
            item.GetComponent<Collider2D>().enabled = false;
            item.GetComponent<Weapon>().Hands = this;
            UpdateWeaponUI();
        }

        void UpdateWeaponUI()
        {

            Weapon Current = held_item[CurrentItem].GetComponent<Weapon>();
            UIAmmoCounter.localScale = (new Vector3(((Current.AllCharges + Current.CurrentCharges) / Current.MaxCharges), 1,1));
            Debug.Log("UpdateUI " + (Current.AllCharges + Current.CurrentCharges) + " " + Current.MaxCharges );
        }

        public void DropItem()
        {

        }

        public PlayerCharacter GetCharacter()
        {
            return character;
        }

        public CarryItem GetHeldItem()
        {
            return held_item[CurrentItem];
        }

        public Vector3 GetHandPos()
        {
            if (hand)
                return hand.transform.position;
            return transform.position;
        }

        public Vector2 GetMove()
        {
            return character.GetMove();
        }

        public Vector2 GetFacing()
        {
            return character.GetFacing();
        }
    }

}
