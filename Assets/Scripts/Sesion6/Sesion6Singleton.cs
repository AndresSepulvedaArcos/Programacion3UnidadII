using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sesion6Singleton : MonoBehaviour
{
    private static Sesion6Singleton instance;

    public static Sesion6Singleton Instance { get { return instance; } }

    /// <summary>
    /// implementacion adicional
    /// </summary>
    public float timeLeft;

    //lazy initialize
    private void Awake()
    {
        instance = this;

    }

    /// <summary>
    /// adicional
    /// </summary>
    public void CallMessage()
    {
        Debug.Log("this is a singleton message");
     
    }
}
