using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buildings : MonoBehaviour {
    public GameObject parent;
    public static List<Building> residental = new List<Building>();
    public static List<Building> workplaces = new List<Building>();
    public static List<Building> stores = new List<Building>();
    public static List<Building> hospitals = new List<Building>();

    //BRO DON"T FORGET THIS IS THE TYPE FLOAT
    // 1 = Residential
    //2 = Workplace
    //3 = Store
    // 4 = Hospital
    void Awake()
    {
        foreach (Transform child in parent.transform)
        {
            float x, z;
            float type = 0;
            x = child.transform.position.x;
            z = child.transform.position.z;

            if (child.CompareTag("Residential"))
            {
                type = 1;
                Building temp = new Building(x, z, type);
                residental.Add(temp);
            }
            else if (child.CompareTag("workplace"))
            {
                type = 2;
                Building temp = new Building(x, z, type);
                workplaces.Add(temp);
            }
            else if (child.CompareTag("grocery"))
            {
                type = 3;
                Building temp = new Building(x, z, type);
                stores.Add(temp);
            }
            else if (child.CompareTag("hospitals"))
            {
                type = 4;
                Building temp = new Building(x, z, type);
                hospitals.Add(temp);
            }

        }
        Debug.Log("done");
    }


    public struct Building
    {
        float x, z, type, people;
        public Building(float x, float z, float type)
        {
            this.x = x;
            this.z = z;
            this.type = type;
            this.people = 0;
        }

        public float getX()
        {
            return this.x;
        }

        public float getZ()
        {
            return this.z;
        }

        public float getType()
        {
            return this.type;
        }

        public float getPeople()
        {
            return this.people;
        }

        public void addPeople(float num)
        {
            this.people += num;
        }

        public void setPeople(float num)
        {
            this.people = num;
        }

    }

}
