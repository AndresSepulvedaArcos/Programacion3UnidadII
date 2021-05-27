using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityListenerII : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ///
        ///bottom up --> singleton 
        ///top bottom ->> eventos
    }

    public void AlsoListenTimeLog(float TimeToLog)
    {
        Debug.LogWarning("time is =>" + TimeToLog.ToString());

    }
}
