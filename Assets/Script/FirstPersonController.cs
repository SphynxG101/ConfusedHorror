using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Cursor = UnityEngine.Cursor;
using Random = UnityEngine.Random;

public class FirstPersonController : MonoBehaviour
{
    public Camera Eyes;
    public Rigidbody RB;
    public float MouseSensitivity = 3;
    public float WalkSpeed = 10;
    public List<GameObject> Floors;
    public Vector2 look;
    public TextMeshProUGUI keytext;
    public int keycount = 0;
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        keycount = 0;
        PlayerPrefs.SetInt("KeyCount", keycount);
        //transform.position = new Vector3(Random.Range(-48.5f, 46.5f), 1, Random.Range(-53f, 42f));
    }

    
    void Update()
    {
        
        //look.y = -Input.GetAxis("Mouse Y") * MouseSensitivity;
        //look.y = Mathf.Clamp(look.y, -89f, 89f);
        //Eyes.transform.Rotate(look.y,0,0);
        
        look.x = Input.GetAxis("Mouse X") * MouseSensitivity;
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

    public void OnTriggerEnter(Collider other)
    {
        KeyScript key = other.gameObject.GetComponent<KeyScript>();
        if (key != null)
        {
            keycount++;
            PlayerPrefs.SetInt("KeyCount", keycount);
            keytext.text = "Keys Collected: " + keycount + "/5";
            key.getBumped();
        }
    }
}
