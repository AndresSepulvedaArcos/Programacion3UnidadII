using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventCListener : MonoBehaviour
{

    private void OnEnable()
    {
        EventCManagerNoSingleton.OnPlayerStateChange += EventCManagerNoSingleton_OnPlayerStateChange;
    }


    private void OnDisable()
    {
        EventCManagerNoSingleton.OnPlayerStateChange -= EventCManagerNoSingleton_OnPlayerStateChange;
    }


    private void EventCManagerNoSingleton_OnPlayerStateChange(EPlayerState playerState)
    {
        Debug.Log(" Minuevo estado es ---->" + playerState);
    }
    // Start is called before the first frame update
    void Start()
    {
        EventCManager.Instance.OnEventTrigger += TriggerResponse;

        EventCManager.Instance.OnShowTime += Instance_OnShowTime;
    }

    private void Instance_OnShowTime(float FloatValue)
    {
        Debug.LogFormat("El tiempo es ---> {0} <--", FloatValue);
    }

    void TriggerResponse()
    {
        Debug.Log("Cevent listen suscrito " + gameObject.name);
    }
     
}
