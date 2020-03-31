using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperBird : MonoBehaviour
{
    Rigidbody rb;
    public float jumpPower = 3f;
    public float forwardSpeed = 2f;
    GamePlayManager gm;
    public float maxSpeed = 3f;


    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        gm = FindObjectOfType<GamePlayManager>();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
        }
        
    }

    void FixedUpdate()
    {
        rb.AddForce(Vector3.right * forwardSpeed);
        if(rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);
        }
    }


    void OnCollisionEnter(Collision collision)
    {
        gm.GameOver();
        rb.isKinematic = true;
    }
}
