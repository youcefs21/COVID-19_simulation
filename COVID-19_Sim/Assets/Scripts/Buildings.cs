using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buildings : MonoBehaviour {
    public GameObject parent;
    public static List <Building> buildings = new List <Building>();

    //BRO DON"T FORGET THIS IS THE TYPE FLOAT
    // 1 = Residential
    //2 = Workplace
    //3 = Store
    // 4 = Hospital
    void Start(){
        foreach (Transform child in parent.transform){
            float x,z;
            float type = 0;
            x = child.transform.position.x;
            z = child.transform.position.z;

            if (child.CompareTag("Residential")){
                type = 1;
            }
            else if (child.CompareTag("workplace")){
                type = 2;
            }
            else if (child.CompareTag("grocery")){
                type = 3;
            }
            else if (child.CompareTag("hospitals")){
                type = 4;
            }

            if(type!=0){
                Building temp = new Building (x,z,type);
                buildings.Add (temp);
            }
           
        }
    }
    public List<Building> getBuildingList () {
        return buildings;
    }

    public struct Building {
        float x,z,type;
        public Building (float x, float z, float type){
            this.x = x;
            this.z = z;
            this.type = type;
        }

        public float getX()
        {
            return this.x;
        }

        public float getZ()
        {
            return this.z;
        }

    }

}
