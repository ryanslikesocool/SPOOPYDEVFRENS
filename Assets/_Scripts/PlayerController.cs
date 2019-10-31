using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 velocity;
    private Camera cam;


    [SerializeField] private float speed = 5f;
    [SerializeField] private float sensitivity = 3f;
    [SerializeField] private float jumpForce = 20f;

    private Vector3 startPos;



    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        cam = gameObject.GetComponentInChildren<Camera>();
        startPos = new Vector3(transform.position.x,transform.position.y,transform.position.z);
    }

    void Update()
    {
        //Calculate player speed as Vector3
        float xMov = Input.GetAxisRaw("Horizontal");
        float zMov = Input.GetAxisRaw("Vertical");

        Vector3 moveHorizontal = transform.right * xMov; //transform.right = local Vector3(1,0,0)
        Vector3 moveVertical = transform.forward * zMov; //transform.forward = local Vector3(0,0,1)

        velocity = (moveHorizontal + moveVertical).normalized * speed; // Normalizing means total length of the vector = 1  
        rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);


        //Calculate rotation as a Vector3
        float yRotation = Input.GetAxisRaw("Mouse X"); //y rotation affects player (turning left and right)
        Vector3 rotation = new Vector3(0f, yRotation, 0f) * sensitivity;
        rb.MoveRotation(rb.rotation * Quaternion.Euler(rotation));

        //Calculate camera rotation as a Vector3
        float xRotation = Input.GetAxisRaw("Mouse Y");
        Vector3 camRotation = new Vector3(xRotation, 0f, 0f) * sensitivity;
        cam.transform.Rotate(-camRotation);


        if (Input.GetButtonDown("Jump"))
        {
            Vector3 jump = Vector3.up * jumpForce;
            rb.AddForce(jump);
        }
    }

    void OnTriggerEnter(Collider col){
        if(col.name == "Respawn"){
            transform.position = startPos;
        }
    }
}
