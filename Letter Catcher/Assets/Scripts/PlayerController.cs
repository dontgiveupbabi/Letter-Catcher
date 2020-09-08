using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject jumpArea;
    private TextPrinter textPrinterScript;
    
    public GameObject[] parabolaRoots;
    [SerializeField] private ParabolaController parabolaControllerScript;
    private Rigidbody myRigidbody;
    private bool isGrounded;
    Animator animator;

    public bool inInnerCircle;
    public bool inOutercircle;
    public bool isOutOfCircle = true;

    [SerializeField] private float jumpFactor;

    
    
    void Start()
    {
        textPrinterScript = GetComponent<TextPrinter>();
        myRigidbody = GetComponent<Rigidbody>();
        isGrounded = true;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        JumpHandler();
    }

    public void SetParabolaRoots(float xPosP1, float yPosP1,float zPosP1,float xPosP2, float yPosP2,float zPosP2,float xPosP3, float yPosP3,float zPosP3 )
    {
        parabolaRoots[0].transform.localPosition= new Vector3(xPosP1,yPosP1,zPosP1);
        parabolaRoots[1].transform.localPosition=new Vector3(xPosP2,yPosP2,zPosP2);
        parabolaRoots[2].transform.localPosition=new Vector3(xPosP3,yPosP3,zPosP3);
    }
    
    private void JumpHandler()
    {
        if (Input.GetMouseButtonDown(0)&& isGrounded && inOutercircle)
        {
           // SetParabolaRoots(0,0,0,0,2.5f,2,0,0f,5);
            //parabolaControllerScript.FollowParabola();
            myRigidbody.AddForce(Vector3.up*jumpFactor,ForceMode.Impulse);
                isGrounded = false;
               // animator.SetTrigger("Jumping");
                
        }
        
        if (Input.GetMouseButtonDown(0)&& isGrounded && inInnerCircle)
        {
            //SetParabolaRoots(0,0,0,0,5f,2,0,0f,5);
            //parabolaControllerScript.FollowParabola();
            myRigidbody.AddForce(Vector3.up*jumpFactor*1.5f,ForceMode.Impulse);
            isGrounded = false;
           // animator.SetTrigger("Jumping");
        }
        
        
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.gameObject.CompareTag("Platform"))
        {
            Debug.Log("Right here");
            isGrounded = true;
            animator.SetTrigger("Running");
            if (textPrinterScript.levelTaskList.Count > textPrinterScript.letterIndex + 1)
            {
                Debug.Log("Right right here");
                GameObject nextJumpCircle = Instantiate(jumpArea,
                    this.transform.parent.transform.position + new Vector3(0, 0, 20), Quaternion.identity) as GameObject;
            }
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
       
        if (other.transform.gameObject.CompareTag("OuterCircle"))
        {
            inOutercircle = true;
            inInnerCircle = false;
            isOutOfCircle = false;
        }
        else if (other.transform.gameObject.CompareTag("InnerCircle"))
        {
            inOutercircle = false;
            inInnerCircle = true;
            isOutOfCircle = false;
        }
        else if (other.transform.gameObject.CompareTag("OutOfCircle"))
        {
            inOutercircle = false;
            inInnerCircle = false;
            isOutOfCircle = true;
           
        }        
        
    }

}
