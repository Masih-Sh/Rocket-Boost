using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float delayTime = 1f;

    [SerializeField] AudioClip crashSound;

    [SerializeField] AudioClip winSound;


    [SerializeField] ParticleSystem crashParticle;

    [SerializeField] ParticleSystem winParticle;

    AudioSource myAudioSource;

    bool inTransition = false;

    bool collisionDisable = false;

     void Start() 
    {
        myAudioSource = GetComponent<AudioSource>();
    }

    void Update() 
    {
        DebugKeys();
    }

    void DebugKeys()
    {
        if(Input.GetKeyDown(KeyCode.L))
        {
            LoadNextLevel();
        }
        if(Input.GetKeyDown(KeyCode.C))
        {
            collisionDisable = !collisionDisable;
        }
    }

    void OnCollisionEnter(Collision other) 
    {
        if(inTransition || collisionDisable){return;}
        switch(other.gameObject.tag)
        {
            case "Friendly":
            Debug.Log("this thing is friendly");
            break;

            case "Finish":
            FinishSequence();
            break;           

            default:
            CrashSequence();
             break;
        }
    }

    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        if(nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }
        SceneManager.LoadScene(nextSceneIndex);
    }

    void CrashSequence()
    {
        inTransition = true;
        myAudioSource.Stop();
        crashParticle.Play();
        myAudioSource.PlayOneShot(crashSound);      
        GetComponent<Movment>().enabled = false;
        Invoke("ReloadLevel",delayTime);

    }

    void FinishSequence()
    {
        inTransition = true;
        myAudioSource.Stop();
        winParticle.Play();
        myAudioSource.PlayOneShot(winSound);
        GetComponent<Movment>().enabled = false;
        Invoke("LoadNextLevel",delayTime);

    }
}
