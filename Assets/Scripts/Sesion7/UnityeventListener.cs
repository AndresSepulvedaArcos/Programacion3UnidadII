using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityeventListener : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ShowMessageListen()
    {
        Debug.Log(" i'm listening ==>"+ gameObject.name);
    }
     
    public void ShowTimeListen(float TimeToListen)
    {
        Debug.Log(TimeToListen);

    }
}
