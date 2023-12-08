using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class standing_up : MonoBehaviour
{
    public Rigidbody BodyPart;
    public Rigidbody Feet1; 
    public Rigidbody Feet2;
    public float constantForceMagnitude = 10f;

    // Update is called once per frame
    void Update()
    {
        Vector3 constantForce = Vector3.up * constantForceMagnitude;
        Vector3 constantForceDown = Vector3.down * (constantForceMagnitude / 2);
        BodyPart.AddForce(constantForce);
        Feet1.AddForce(constantForceDown);
        Feet2.AddForce(constantForceDown);
    }
}
