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
    public RaycastHit hit;
    public Ray ray;
    public Vector2 home;
    public Vector2 work;
    public Vector2 store;
    public bool infected;
    public int needWork;
    public int needStore;
    public int workTime;
    public int storeTime;
    public bool working;
    public bool shopping;
    public bool atHome;
    
    int time = 0;


    void Start()
    {
        //findHome();

    }

    public void infect()
    {
        
        rend = agent.GetComponent<Renderer>();
        rend.sharedMaterial = mater[1];
        this.tag = "Infected";
        CreatePeople.infected++;
        CreatePeople.susceptible--;
        Debug.Log(CreatePeople.infected + " infected, and " + CreatePeople.susceptible + " not");
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




    void FixedUpdate()
    {
        //Debug.Log(Time.deltaTime);
        //Debug.Log(time);
        //if (Time.deltaTime>time){
            time++;
            //Debug.Log(time);
            //Debug.Log(Time.deltaTime);
            if (!working)
        {
            needWork--;
        }
        if (!shopping)
        {
            needStore--;
        }

        if (needWork == 0 && !shopping)
        {
            Debug.Log("need work");
            working = true;
            gameObject.SetActive(true);
            agent.SetDestination(new Vector3(work.x, work.y, 0.5f));
        }

        if (needStore == 0 && !working)
        {
            shopping = true;
            int ultimatebrahmoment = Buildings.stores.Count;
            gameObject.SetActive(true);

            agent.SetDestination(new Vector3(Buildings.stores[ultimatebrahmoment].getX(), Buildings.stores[ultimatebrahmoment].getZ(), 0.5f));
            store = new Vector2(Buildings.stores[ultimatebrahmoment].getX(), Buildings.stores[ultimatebrahmoment].getZ());
        }

        if (shopping && transform.position.x == store.x && transform.position.z == store.y)
        {
            gameObject.SetActive(false);
            storeTime--;

            if (storeTime == 0)
            {
                storeTime = 50;
                needStore = 150;

                agent.SetDestination(new Vector3(home.x, home.y, 0.5f));
                gameObject.SetActive(true);
            }
        }

        if (working && transform.position.x == work.x && transform.position.z == work.y)
        {
            gameObject.SetActive(false);
            workTime--;

            if (workTime == 0)
            {
                workTime = 50;
                needWork = 150;

                agent.SetDestination(new Vector3(home.x, home.y, 0.5f));
                gameObject.SetActive(true);
            }
        }


        int rand = Random.Range(0, 1000);
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

        //}
    }
    public void goHome()
    {

    }

}
