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

    bool inTransition = false;

     void Start() 
    {
        myAudioSource = GetComponent<AudioSource>();
    }
    void OnCollisionEnter(Collision other) 
    {
        if(inTransition){return;}
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
        myAudioSource.PlayOneShot(crashSound);      
        GetComponent<Movment>().enabled = false;
        Invoke("ReloadLevel",delayTime);

    }

    void FinishSequence()
    {
        inTransition = true;
        myAudioSource.Stop();
        myAudioSource.PlayOneShot(winSound);
        GetComponent<Movment>().enabled = false;
        Invoke("LoadNextLevel",delayTime);

    }
}
