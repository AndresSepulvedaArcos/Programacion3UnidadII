using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sesion6Debug : MonoBehaviour
{

    public Vector3[] path;
    public float pointRadius = 0.2f;

    // Start is called before the first frame update
    void Start()
    {

#if UNITY_ANDROID

        Debug.Log("<color=magenta>Script</color>"+ this,this);

        Debug.LogFormat("Este es el debug {0}  el segundo indice es  {1} puedo ocupar de nuevo  {0}, aca va el el 2  {2} ", 1, gameObject, Vector2.right);

        string debugMessage = string.Format(" Formateo con string {0} luego {1} y de nuevo {0}", 1, Time.realtimeSinceStartup);

        Debug.Log(debugMessage);

        Debug.LogWarning("esto es un warning");
        Debug.LogError("esta linea es un error , hay que arreglarlo");

        Debug.Assert(1 >2, "assert", this);


#endif

#if UNITY_IOS
    
#endif


        Debug.Log("entra?");

        CountDown(5);

        ///fps frames per seconds
        ///   Time.deltaTime  tiempo entre frame y frame
    }

    private void OnDrawGizmosSelected()
    {

       // Gizmos.DrawCube(transform.position, Vector3.one);

        for (int i = 0; i < path.Length; i++)
        {

            Gizmos.DrawWireSphere(path[i], pointRadius);


            if(i>0)
            {
                Gizmos.color = Color.green;
                Gizmos.DrawLine(path[i - 1], path[i] );

            }

            Gizmos.color = Color.blue;
            Gizmos.DrawCube(path[0], Vector3.one * pointRadius);

        }

      
        

    }

    public void CountDown(int StartCount)
    {
        if(StartCount==0)
        {
            Debug.Log("Boom");
            return;
        }

        Debug.Log("<color=yellow>" + StartCount + "</color>", this);

        CountDown(StartCount - 1);


    }

    // Update is called once per frame
    void Update()
    {
      //  Debug.Log(Time.realtimeSinceStartup);

        float fps = 1f / Time.deltaTime;
      //  Debug.Log(fps);

        Debug.DrawLine(transform.position, transform.position + Vector3.forward * 10,Color.magenta);

        Debug.DrawRay(transform.position, transform.up,Color.red);

    }
}
