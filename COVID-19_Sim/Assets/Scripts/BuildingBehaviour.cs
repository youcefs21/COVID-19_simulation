using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingBehaviour : MonoBehaviour {

    ArrayList <EntityBehaviour> occupants = new ArrayList<EntityBehaviour>();

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        
    }

    void addOccupant(EntityBehaviour entity){
        occupants.Add(entity);
    }

    void removeOccupant(EntityBehaviour entity){
        occupants.Remove(entity);
    }

    double getInfectionRisk(){

    }
}
