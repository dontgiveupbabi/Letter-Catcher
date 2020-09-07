using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody myRigidbody;
    private bool isGrounded;
    private Animator animator;

    [SerializeField] private float jumpFactor;
    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
        isGrounded = true;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        JumpHandler();
    }

    private void JumpHandler()
    {
        if (Input.GetMouseButtonDown(0)&& isGrounded )
        {
            myRigidbody.AddForce(Vector3.up*jumpFactor,ForceMode.Impulse);
            isGrounded = !isGrounded;
            animator.SetTrigger("Jumping");
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.gameObject.CompareTag("Platform"))
        {
            isGrounded = true;
            animator.SetTrigger("Running");
        }
    }
}
