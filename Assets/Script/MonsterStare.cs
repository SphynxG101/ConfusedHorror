using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterStare : MonoBehaviour
{
    public Transform target;

    public Rigidbody rb;
    void Update()
    {
        if(target != null)
        {
            Quaternion rotation = Quaternion.LookRotation(target.transform.position - transform.position);
            transform.rotation = rotation * Quaternion.Euler(180,0, 0);
            rb.constraints = RigidbodyConstraints.FreezeAll;
        }
    }
}
