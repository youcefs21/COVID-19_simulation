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

    void Start()
    {
        float x = Buildings.buildings[0].getX();
        float y = 0.5f;
        float z = Buildings.buildings[0].getZ();

        Vector3 destination = new Vector3(x, y, z);
        agent.SetDestination(destination);
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
       ray = new Ray(transform.position, Vector3.back);
       Debug.DrawRay(transform.position, Vector3.back, Color.yellow);

       if (Physics.Raycast(ray, out hit, infectionRadius) && hit.transform.CompareTag("Infected"))
       {
            //PROBABILITY STUFF HERE
            personlogic person = hit.collider.GetComponent<personlogic>();
            person.infect();
            this.tag = "Infected";
       }

       ray.direction = Vector3.forward;
       Debug.DrawRay(transform.position, Vector3.forward, Color.yellow);
        
        if (Physics.Raycast(ray, out hit, infectionRadius) && hit.transform.CompareTag("Infected"))
       {
            //PROBABILITY STUFF HERE
            personlogic person = hit.collider.GetComponent<personlogic>();
            person.infect();
            this.tag = "Infected";
       }

       ray.direction = Vector3.left;
       Debug.DrawRay(transform.position, Vector3.left, Color.yellow);

       if (Physics.Raycast(ray, out hit, infectionRadius) && hit.transform.CompareTag("Infected"))
       {
            //PROBABILITY STUFF HERE
            personlogic person = hit.collider.GetComponent<personlogic>();
            person.infect();
            this.tag = "Infected";
       }

       ray.direction = Vector3.right;
       Debug.DrawRay(transform.position, Vector3.right, Color.yellow);

       if (Physics.Raycast(ray, out hit, infectionRadius) && hit.transform.CompareTag("Infected"))
       {
            //PROBABILITY STUFF HERE
            personlogic person = hit.collider.GetComponent<personlogic>();
            person.infect();
            this.tag = "Infected";
       }


   }

}
