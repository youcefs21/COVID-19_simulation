using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePeople : MonoBehaviour
{
    public GameObject myPrefab;
    public static int x;
    public static int y;


    // Start is called before the first frame update
    void Start()
    {
        x = 100;
        y = 100;

        for (int i = 0; i < x; i++)
        {
            for (int j = 0; j < y; j++)
            {
                Instantiate(myPrefab, new Vector3(i, 0.5f, j), Quaternion.identity);
          

            }
        }

    }

    // Update is called once per frame
    void Update()
    {

       
    }
}

