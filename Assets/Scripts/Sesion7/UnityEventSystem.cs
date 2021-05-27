using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UnityEventSystem : MonoBehaviour
{
    public UnityEvent OnEventTrigger;//signature 
    public UnityEvent<float> OnTimeCall;


    // Start is called before the first frame update
    void Start()
    {

     

    }

    private void Update()
    {
        if(Input.GetButtonDown("Jump"))
        {
            OnEventTrigger.Invoke();

            OnTimeCall.Invoke(Time.realtimeSinceStartup);
        }
    }

}
