using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public ControlType controlType;
    public Joystick joystick;
    public float speed;

    public enum ControlType {PC, Android}

    private Rigidbody2D rb;
    private Vector2 moveInput;
    private Vector2 movelocity;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (controlType == ControlType.PC)
        {
            moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        }
        else if (controlType == ControlType.Android)
        {
            moveInput = new Vector2(joystick.Horizontal, joystick.Vertical);
        }
        movelocity = moveInput.normalized * speed;
    }

    void FixedUpdate()
    {
       rb.MovePosition(rb.position + movelocity * Time.fixedDeltaTime);
    }
}       
       