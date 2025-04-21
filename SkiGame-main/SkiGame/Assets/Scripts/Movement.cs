using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private KeyCode leftInput, rightInput;
    [SerializeField] private float acceleration = 100f, turnSpeed = 100f, minSpeed = 0f, maxSpeed = 500f, minAcc = -250, maxAcc = 250;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform groundTransform;
    [SerializeField] private TakeDamage takeDamage;
    
    private Animator animator;
    private Rigidbody rb;
    private float speed = 0f;
    
    
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        if (takeDamage.isHurt)
        {
            return;
        }
        
        float angle = Mathf.Abs(transform.eulerAngles.y - 180);
        acceleration = Remap(0, 90, maxAcc, minAcc, angle); // Transfroms angle values into acceleration values
        speed += acceleration * Time.fixedDeltaTime;
        speed = Mathf.Clamp(speed ,minSpeed, maxSpeed);
        Vector3 velocity = transform.forward * (speed * Time.fixedDeltaTime);
        rb.velocity = new Vector3(velocity.x, rb.velocity.y, velocity.z);
    }

    private void Update()
    {
        bool isGrounded = Physics.Linecast(transform.position, groundTransform.position, groundLayer);

        if (isGrounded && !takeDamage.isHurt)
        {
            if (Input.GetKey(leftInput) && transform.eulerAngles.y < 269)
            {
                transform.Rotate(new Vector3(0f, turnSpeed * Time.deltaTime, 0f), Space.Self);
            }
        
            if (Input.GetKey(rightInput) && transform.eulerAngles.y > 91)
            {
                transform.Rotate(new Vector3(0f, -turnSpeed * Time.deltaTime, 0f), Space.Self);
            }
        }
        
        animator.SetFloat("playerSpeed", speed );
        animator.SetBool("grounded", isGrounded);
        
    }

    public float Remap(float oldMin, float oldMax, float newMin, float newMax, float oldValue)
    {
        float oldRange = (oldMax - oldMin);
        float newRange = (newMax - newMin);
        float newValue = (((oldValue - oldMin) / oldRange) * newRange + newMin);
        return newValue;
    }
}
