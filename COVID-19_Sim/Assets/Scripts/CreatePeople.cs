using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePeople : MonoBehaviour
{
    public personlogic personTemplate;
    public personlogic[] peopleArray = new personlogic[50];

    int toSpawn;
    int timestamps = 0;

    // Start is called before the first frame update
    void Start()
    {
        toSpawn = 10;
    }
    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Time.time);
        if (Time.time > timestamps)
        {
            if (toSpawn > 0)
            {
                timestamps = timestamps+1;
                toSpawn--;
                for (int i = 0; i<5;i++)
                {
                    personlogic personClone = Instantiate(personTemplate, new Vector3(23.5f, 0.5f, -52.15f), Quaternion.identity);
                    if (toSpawn == 3)
                    {
                        personClone.infect();
                    }
                    
                }

                

            }
        }
    }
}

