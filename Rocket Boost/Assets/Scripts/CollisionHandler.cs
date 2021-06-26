using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float delayTime = 1f;

    [SerializeField] AudioClip crashSound;

    [SerializeField] AudioClip winSound;

    AudioSource myAudioSource;

     void Start() 
    {
        myAudioSource = GetComponent<AudioSource>();
    }
    void OnCollisionEnter(Collision other) 
    {

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
        myAudioSource.PlayOneShot(crashSound);      
        GetComponent<Movment>().enabled = false;
        Invoke("ReloadLevel",delayTime);
    }

    void FinishSequence()
    {
         myAudioSource.PlayOneShot(winSound);
        GetComponent<Movment>().enabled = false;
        Invoke("LoadNextLevel",delayTime);
    }
}
