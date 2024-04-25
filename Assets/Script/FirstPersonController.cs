using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonController : MonoBehaviour
{
    public Camera Eyes;
    public Rigidbody RB;
    public float MouseSensitivity = 3;
    public float WalkSpeed = 10;
    public float JumpPower = 7;
    public List<GameObject> Floors;
    public Vector2 look;
    
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    
    void Update()
    {
        look.x = Input.GetAxis("Mouse X") * MouseSensitivity;
        look.y = -Input.GetAxis("Mouse Y") * MouseSensitivity;

        look.y = Mathf.Clamp(look.y, -89f, 89f);
            
        Eyes.transform.Rotate(look.y,0,0);
        transform.Rotate(0,look.x,0);
        
        
        if (WalkSpeed > 0)
        {
            Vector3 move = Vector3.zero;
            if (Input.GetKey(KeyCode.W))
                move += transform.forward;
            if (Input.GetKey(KeyCode.S))
                move -= transform.forward;
            if (Input.GetKey(KeyCode.A))
                move -= transform.right;
            if (Input.GetKey(KeyCode.D))
                move += transform.right;
            move = move.normalized * WalkSpeed;
            
            //if (JumpPower > 0 && Input.GetKeyDown(KeyCode.Space) && OnGround())
            //    move.y = JumpPower;
            //else
            move.y = RB.velocity.y;
            RB.velocity = move;
        }
    }

    public bool OnGround()
    {
        return Floors.Count > 0;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (!Floors.Contains(other.gameObject))
            Floors.Add(other.gameObject);
    }

    private void OnCollisionExit(Collision other)
    {
        Floors.Remove(other.gameObject);
    }
}
