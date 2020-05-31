using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityBehaviour : MonoBehaviour {
    static double infectionDistance = 3.00; //to be slidered
    static double deathRate = 0.10; //0 to 1
    static double infectedRate = 0.98; //0 to 1

    bool infected = false;
    bool infected= false;
    bool immune = false;
    double socialDistance = 2.00; //to be adjustible
    bool quarantined = false;
    bool dead = false;
    int quarantineTimer = 0; //24 ticks per day, 336 ticks for full quarantine
    int infectedTimer = 0;
    int asymptomaticTimer =0;

    public EntityBehaviour(){


    }

    
    void Start() { // Start is called before the first frame update
        
    }

    void Update() {
        if (infected){
            runStatus();
        }
        else{
            //run daily life
        }

    }

    void infect(){
        infected = true;
        infectedTimer = 168;
    }

    void decideQuarantine(){
        //choose to enter hospital or stay home or neither
    }

    void checkDead(){
        //run probability to see if dead
        //make dead true if so
    }

    // Update is called once per frame
    

    void runStatus(){
        //if infected but not infected
        if (infectedTimer>0){
            infectedTimer--;
            //now decide if symptoms
            if (infectedTimer==0){
                UnityEngine.Random.value();
            }
            else{
                //don't know sick yet, will continue life
            }
        }
        else if (asymptomaticTimer>0){
            //decrease symptomatic timer, if 0 then cure
            //run daily life
        }
        else if (quarantined){
            //check dead
            
            quarantineTimer--;
            if (quarantineTimer==0){ //yay, can go outside now!
                quarantined = false;
                infected = false;
                immune = true;
            }
        }

    }
}