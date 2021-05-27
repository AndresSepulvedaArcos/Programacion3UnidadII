using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleSort : MonoBehaviour
{
    public int[] randomNumbers;
    public int sizeArray = 0;
    public float waitTime=0.1f;
    // Start is called before the first frame update
    void Start()
    {
        randomNumbers = new int[sizeArray];

        for (int i = 0; i < sizeArray; i++)
        {
            randomNumbers[i] = Random.Range(0, 100);
        }

    }


    /// <summary>
    ///  *  *  *  *  *  *  * *  10 * 15 *
    /// </summary> 
    IEnumerator  ExecuteBubbleSort(int[] UnsortedArray)
    {
        for (int i = 0; i < UnsortedArray.Length; i++)
        {
            for (int j = 0; j < UnsortedArray.Length-1; j++)
            {
                if(UnsortedArray[j]>UnsortedArray[j+1])
                {
                    int tmpInt = UnsortedArray[j + 1];
                    UnsortedArray[j + 1] = UnsortedArray[j];
                    UnsortedArray[j] = tmpInt;

                   yield return new WaitForSeconds(waitTime);
                  

                }

            }
        }

        


    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Jump"))
        {
           StartCoroutine(  ExecuteBubbleSort(randomNumbers));
        }
        
    }
}
