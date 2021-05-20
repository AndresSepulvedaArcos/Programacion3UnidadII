using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonDummy : MonoBehaviour
{
   
    // Start is called before the first frame update
    void Start()
    {      
        Sesion6Singleton.Instance.CallMessage();
        Sesion6Singleton.Instance.timeLeft = 2;
       

    }

    
}
