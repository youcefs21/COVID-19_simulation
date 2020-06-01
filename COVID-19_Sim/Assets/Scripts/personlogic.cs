using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class personlogic : MonoBehaviour
{
    // Start is called before the first frame update
    public Camera cam;
    public Material[] mater;
    public NavMeshAgent agent;
    Renderer rend = new Renderer();
    public float infectionRadius;
    RaycastHit hit;
    Ray ray;
    int home;

    void Start()
    {
        findHome();
    }

    public void infect()
    {
        rend = agent.GetComponent<Renderer>();
        rend.sharedMaterial = mater[1];
        this.tag = "Infected";
    }
    // Update is called once per frame
    /*
   void Update()
   {
       //mouse follow
       if (Input.GetMouseButtonDown(0))
       {
           Ray ray = cam.ScreenPointToRay(Input.mousePosition);

           if (Physics.Raycast(ray, out RaycastHit hit))
           {
               //move agent
               agent.SetDestination(hit.point);
           }
       }
   }
    */

    private void FixedUpdate()
   {
       int rand = Random.Range(0, 100);
       ray = new Ray(transform.position, Vector3.back);
       //Debug.DrawRay(transform.position, Vector3.back, Color.yellow);

       if (Physics.Raycast(ray, out hit, infectionRadius) && hit.transform.CompareTag("Infected"))
       {
            //PROBABILITY STUFF HERE
            if (rand == 69)
            {
                personlogic person = hit.collider.GetComponent<personlogic>();
                person.infect();
                this.tag = "Infected";
            }
       }

       ray.direction = Vector3.forward;
       //Debug.DrawRay(transform.position, Vector3.forward, Color.yellow);
        
        if (Physics.Raycast(ray, out hit, infectionRadius) && hit.transform.CompareTag("Infected"))
       {
            //PROBABILITY STUFF HERE
            if (rand == 69)
            {
                personlogic person = hit.collider.GetComponent<personlogic>();
                person.infect();
                this.tag = "Infected";
            }
       }

       ray.direction = Vector3.left;
       //Debug.DrawRay(transform.position, Vector3.left, Color.yellow);

       if (Physics.Raycast(ray, out hit, infectionRadius) && hit.transform.CompareTag("Infected"))
       {
            //PROBABILITY STUFF HERE
            if (rand == 69)
            {
                personlogic person = hit.collider.GetComponent<personlogic>();
                person.infect();
                this.tag = "Infected";
            }
        }

       ray.direction = Vector3.right;
      // Debug.DrawRay(transform.position, Vector3.right, Color.yellow);

       if (Physics.Raycast(ray, out hit, infectionRadius) && hit.transform.CompareTag("Infected"))
       {
            //PROBABILITY STUFF HERE
            if (rand == 69)
            {
                personlogic person = hit.collider.GetComponent<personlogic>();
                person.infect();
                this.tag = "Infected";
            }
       }


   }
    public void findHome()
    {
        bool homeFound = false;
        while (!homeFound)
        {
            int j = Random.Range(0, Buildings.buildings.Count);
            if (Buildings.buildings[j].getPeople() < 200 && Buildings.buildings[j].getType() == 1)
            {
                this.home = j;
                agent.SetDestination(new Vector3(Buildings.buildings[j].getX(), 0.5f, Buildings.buildings[j].getZ()));
                Debug.Log(j);
                homeFound = true;
            }else Debug.Log(j + " bad home");
        }
    }
    public void goHome()
    {

    }

}
