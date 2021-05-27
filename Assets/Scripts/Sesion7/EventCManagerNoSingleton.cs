using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EPlayerState {Init, Explode }
public class EventCManagerNoSingleton : MonoBehaviour
{

    public delegate void FNotify(EPlayerState playerState);
    public static event FNotify OnPlayerStateChange;



    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            OnPlayerStateChange?.Invoke(EPlayerState.Init);

        }
    }


}
