using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class AI_Movement : MonoBehaviour
{
    Animator animator;
    public float moveSpeed = 0.2f;
    Vector3 stopPosition;
    float walkTime;
    public float walkCounter;
    float waitTime;
    public float waitCounter;
    int WalkDirection;
    public bool isWalking;

    void Start()
    {
        animator = GetComponent<Animator>();
        walkTime = Random.Range(3, 7);
        waitTime = Random.Range(0, 4);
        waitCounter = waitTime;
        walkCounter = walkTime;
        ChooseDirection();
    }

    void Update()
    {
        if (isWalking)
        {
            animator.SetBool("isWalking", true);
            walkCounter -= Time.deltaTime;

            switch (WalkDirection)
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
                stopPosition = transform.position;
                isWalking = false;
                transform.position = stopPosition;
                animator.SetBool("isWalking", false);
                waitCounter = waitTime;
            }
        }
        else
        {
            waitCounter -= Time.deltaTime;
            if (waitCounter <= 0)
                ChooseDirection();
        }
    }

    public void ChooseDirection()
    {
        WalkDirection = Random.Range(0, 4);
        isWalking = true;
        walkCounter = walkTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Wall"))
            ChooseDirection();
    }
}