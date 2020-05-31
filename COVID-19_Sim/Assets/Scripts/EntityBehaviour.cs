using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityBehaviour : MonoBehaviour {
    static double infectionDistance = 3.00; //to be slidered
    static double deathRate = 0.10;
    static double symptomaticRate = 0.98;

    bool infected = false;
    bool symptomatic= false;
    bool immune = false;
    double socialDistance = 2.00; //to be adjustible
    bool quarantined = false;
    bool dead = false;
    int quarantineTimer = 0; //24 ticks per day, 336 ticks for full quarantine

    

    public EntityBehaviour(){


    }

    
    void Start() { // Start is called before the first frame update
        
    }

    void infect(){
        infected = true;
        if (UnityEngine.Random.value<=symptomaticRate) {
            symptomatic = true;
            decideQuarantine();
            if (quarantined){ //if quarantined, quarantine for 14 days
                quarantineTimer = 336;
            }
        }
    }

    void decideQuarantine(){
        //choose to enter hospital or stay home or neither
    }

    void checkDead(){
        //run probability to see if dead
        //make dead true if so
    }

    // Update is called once per frame
    void Update() {
        if (quarantined){
            //check dead
            
            quarantineTimer--;
            if (quarantineTimer==0){ //yay, can go outside now!
                quarantined = false;
                infected = false;
                immune = true;
            }

        }
        else{
            //run daily life
        }
    }
}
