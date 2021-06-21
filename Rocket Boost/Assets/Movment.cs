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
            transform.Rotate(Vector3.forward*rotateThrust*Time.deltaTime);
        }
        else if(Input.GetKey(KeyCode.D))
        {
            transform.Rotate(-Vector3.forward*rotateThrust*Time.deltaTime);

        }
    }
}
