using UnityEngine;

public class BallPickup : MonoBehaviour
{
    public Transform holdPoint;
    public float pickupDistance = 3f;
    public float throwForce = 10f;
    public float upwardForce = 2f;

    private Rigidbody rb;
    private Collider ballCollider;
    private bool isHeld = false;
    private Camera cam;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        ballCollider = GetComponent<Collider>();
        cam = Camera.main;
    }

    private void Update()
    {
        if (!BasketballMinigameManager.Instance.IsGameActive())
            return;

        if (Input.GetKeyDown(KeyCode.F) && !isHeld)
        {
            TryPickup();
        }

        if (isHeld)
        {
            transform.position = holdPoint.position;
            transform.rotation = holdPoint.rotation;

            if (Input.GetMouseButtonDown(0))
            {
                ThrowBall();
            }
        }

        if (transform.position.y < -10f)
        {
            BasketballMinigameManager.Instance.ResetBall();
        }
    }

    private void TryPickup()
    {
        float dist = Vector3.Distance(transform.position, cam.transform.position);

        if (dist <= pickupDistance)
        {
            isHeld = true;

            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            rb.useGravity = false;
            rb.isKinematic = true;

            if (ballCollider != null)
                ballCollider.enabled = false;
        }
    }

    private void ThrowBall()
    {
        isHeld = false;

        transform.position = holdPoint.position;
        transform.rotation = holdPoint.rotation;

        if (ballCollider != null)
            ballCollider.enabled = true;

        rb.isKinematic = false;
        rb.useGravity = true;
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        Vector3 throwDirection = cam.transform.forward;
        rb.AddForce(throwDirection * throwForce + Vector3.up * upwardForce, ForceMode.Impulse);
    }
}