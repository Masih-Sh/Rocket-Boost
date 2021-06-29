using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movment : MonoBehaviour
{
    [SerializeField] float boostThrust = 100f;
    [SerializeField] float rotateThrust = 100f;


    [SerializeField] ParticleSystem mainEngineParticle;
    [SerializeField] ParticleSystem rightThrusterParticle;
    [SerializeField] ParticleSystem leftThrusterParticle;

    [SerializeField] AudioClip mainEngine;
    Rigidbody myRigidBody;
    AudioSource myAudioSource;
    // Start is called before the first frame update
    void Start()
    {        
        myRigidBody = GetComponent<Rigidbody>();
        myAudioSource = GetComponent<AudioSource>();
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
            StartThrusting();
        }
        else
        {
            StopThrusting();
        }
    }
    void Rotation()
    {
        if(Input.GetKey(KeyCode.A))
        {
            RotatingLeft();

        }
        else if(Input.GetKey(KeyCode.D))
        {
            RotationgRight();
        }
        else
        {
            StopRotating();
        }
    }

    void StopThrusting()
    {
        myAudioSource.Stop();
        mainEngineParticle.Stop();
    }

    void StartThrusting()
    {
        myRigidBody.AddRelativeForce(Vector3.up * boostThrust * Time.deltaTime);
        if (!myAudioSource.isPlaying)
        {
            myAudioSource.PlayOneShot(mainEngine);
        }
        if (!mainEngineParticle.isPlaying)
        {
            mainEngineParticle.Play();
        }
    }    

    private void StopRotating()
    {
        rightThrusterParticle.Stop();
        leftThrusterParticle.Stop();
    }

    private void RotationgRight()
    {
        ApplyRotation(-rotateThrust);
        if (!leftThrusterParticle.isPlaying)
        {
            leftThrusterParticle.Play();
        }
    }

    private void RotatingLeft()
    {
        ApplyRotation(rotateThrust);
        if (!rightThrusterParticle.isPlaying)
        {
            rightThrusterParticle.Play();
        }
    }

    void ApplyRotation(float rotationValue)
    {
        myRigidBody.freezeRotation = true;
        transform.Rotate(Vector3.forward * rotationValue * Time.deltaTime);
        myRigidBody.freezeRotation = false;
    }
}
