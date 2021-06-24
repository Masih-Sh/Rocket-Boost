using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    void OnCollisionEnter(Collision other) 
    {
        switch(other.gameObject.tag)
        {
            case "Friendly":
            Debug.Log("this thing is friendly");
            break;

            case "Finish":
            Debug.Log("this is the landing pad");
            break;

            case "Fuel":
            Debug.Log("this is fuel");
            break;

            default :
            Debug.Log("BOOM!!!");
            break;
        }
    }
}
