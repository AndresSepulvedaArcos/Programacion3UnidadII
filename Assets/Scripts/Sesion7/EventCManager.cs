using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EventCManager : MonoBehaviour
{
    public delegate void FEventTrigger();//defino  signature
    public delegate void FNotifyFloat(float FloatValue);// defino siganture conun float

    public event FEventTrigger OnEventTrigger; //defino mi evento
    public event FNotifyFloat OnShowTime,OnShowDamage,OnShowHP,OnSpeedChange;//defino mi evento con float,

    /*Esto es para hacerlo singleton*/
    private static  EventCManager instance;
    public static  EventCManager Instance { get { return instance; } }


    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        int a=2;
        if(a>10)
        {
            a = 5;
        }else
        {
            a = 3;
        }

        a = a > 10 ? 5 : 3;
         

    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            OnEventTrigger?.Invoke();             

            OnShowTime?.Invoke(Time.realtimeSinceStartup);  

        }
    }
}
