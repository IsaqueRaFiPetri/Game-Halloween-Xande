using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnebleCollision : MonoBehaviour
{
    public HingeJoint joint;

    public Transform rot;

    

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            joint.axis = new Vector3(0, 0, 1);
        }
    }
    
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            joint.axis = new Vector3(0, 1, 0);
        }
    }
}
