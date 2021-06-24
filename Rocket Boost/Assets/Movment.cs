using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movment : MonoBehaviour
{
    [SerializeField] float boostThrust = 100f;
    [SerializeField] float rotateThrust = 100f;
    Rigidbody myRigidBody;
    // Start is called before the first frame update
    void Start()
    {        
        myRigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Boost();
        Rotation();
    }

    void Boost()
    {
        if(Input.GetKey(KeyCode.Space))
        {
           myRigidBody.AddRelativeForce(Vector3.up* boostThrust * Time.deltaTime);
        }        
    }

    void Rotation()
    {
        if(Input.GetKey(KeyCode.A))
        {
            ApplyRotation(rotateThrust);
        }
        else if(Input.GetKey(KeyCode.D))
        {
            ApplyRotation(-rotateThrust);

        }
    }

    void ApplyRotation(float rotationValue)
    {
        myRigidBody.freezeRotation = true;
        transform.Rotate(Vector3.forward * rotationValue * Time.deltaTime);
        myRigidBody.freezeRotation = false;
    }
}
