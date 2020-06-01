using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePeople : MonoBehaviour
{
    int p = 2;
    public personlogic personTemplate;
    public personlogic[] peopleArray;
    public static int susceptible;
    public static int infected = 0;

    float timestamps = 0;

    // Start is called before the first frame update
    void Start()
    {
        susceptible = p;

        peopleArray = new personlogic[p];
        int houses = Buildings.residental.Count;
        int jobs = Buildings.workplaces.Count;
        bool infected = false;
        Debug.Log(houses);
        for (int i = 0; i < p; i++)
        {
            int brah = Random.Range(0, houses - 1);
            float x = Buildings.residental[brah].getX();
            float z = Buildings.residental[brah].getZ();

            brah = Random.Range(0, jobs - 1);
            float x2 = Buildings.workplaces[brah].getX();
            float z2 = Buildings.workplaces[brah].getZ();

            if (i == 21)
            {
                infected = true;
            }

            

            personlogic person = Instantiate(personTemplate, new Vector3(x, 0.5f, z), Quaternion.identity);

            person.home = new Vector2(x, z);
            person.work = new Vector2(x2, z2);
            person.atHome = true;
            person.working = false;
            person.shopping = false;

            person.needStore = Random.Range(0, 10);
            person.needWork = Random.Range(0, 10);

            if (person.needWork == person.needStore)
            {
                person.needWork += Random.Range(0, 5);
            }

            person.workTime = Random.Range(0, 10);
            person.storeTime = Random.Range(0, 10);
            if (infected)
            {
                person.infect();
                infected = false;
            }
            
            //person.gameObject.SetActive(false);
        }

    }
}

