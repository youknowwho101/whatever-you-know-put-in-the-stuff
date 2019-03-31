using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public Rigidbody rb;
    public GameObject player;
    private Vector3 offset;

    public float MoveSpeed = 10f;
    public float jumpSpeed = 8;
    private Vector3 initialPosition;
    private Quaternion initialRotation;

    // Use this for initialization
    void Start()
    {
        {
            initialPosition = transform.position;
            initialRotation = transform.rotation;
        }
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        print(Input.GetAxis("Vertical"));


        transform.Translate(Input.GetAxis("Horizontal") * Time.deltaTime, 0f, Input.GetAxis("Vertical") * Time.deltaTime);
        transform.Translate(Vector3.forward * MoveSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(0f, .5f, 0f, ForceMode.Impulse);
        }
        if (gameObject.transform.position.x >= 10)
        {
            transform.rotation = initialRotation;
            transform.position = initialPosition;
        }

    }
    void OnCollisionEnter(Collision c)
    {
        if (c.gameObject.tag == "Cube") { 
       
            transform.rotation = initialRotation;
            transform.position = initialPosition;
        }
        
    }
}
    
