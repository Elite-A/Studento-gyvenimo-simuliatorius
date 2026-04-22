using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI_Movement : MonoBehaviour
{

   // Animator animator;

    //public so u can change it from inspector
    public float moveSpeed = 0.2f;

    //saves the stopped position 
    Vector3 stopPosition;

    //randomly assigned time ai will walk
    float walkTime;
    public float walkCounter;
    //randomly assigned time ai will wait
    float waitTime;
    public float waitCounter;

    int WalkDirection;

    public bool isWalking;

    // Start is called before the first frame update
    void Start()
    {
        //take previously created animator
        //animator = GetComponent<Animator>();

        //So that all the prefabs don't move/stop at the same time
        walkTime = Random.Range(3, 6);
        waitTime = Random.Range(10, 15);


        waitCounter = waitTime;
        walkCounter = walkTime;

        ChooseDirection();
    }

    // Update is called once per frame
    void Update()
    {
        if (isWalking)
        {
            //say its running
            //animator.SetBool("isWalking", true);

            walkCounter -= Time.deltaTime;

            switch (WalkDirection)
            //we check which direction we randomly chose
            {
                case 0:
                    transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                    transform.position += Vector3.back * moveSpeed * Time.deltaTime; 
                    break;
                case 1:
                    transform.rotation = Quaternion.Euler(0f, 90f, 0f);
                    transform.position += Vector3.left * moveSpeed * Time.deltaTime; 
                    break;
                case 2:
                    transform.rotation = Quaternion.Euler(0f, -90f, 0f);
                    transform.position += Vector3.right * moveSpeed * Time.deltaTime; 
                    break;
                case 3:
                    transform.rotation = Quaternion.Euler(0f, 180f, 0f);
                    transform.position += Vector3.forward * moveSpeed * Time.deltaTime; 
                    break;
            }

            if (walkCounter <= 0)
            {
                stopPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                isWalking = false;
                //stop movement
                transform.position = stopPosition;
               // animator.SetBool("isWalking", false);
                //reset the waitCounter
                waitCounter = waitTime;
            }


        }
        else
        {

            waitCounter -= Time.deltaTime;

            if (waitCounter <= 0)
            {
                ChooseDirection();
            }
        }
    }


    public void ChooseDirection()
    {
        WalkDirection = Random.Range(0, 4);

        isWalking = true;
        //we need to reset it every time we start walking
        walkCounter = walkTime;
    }
}