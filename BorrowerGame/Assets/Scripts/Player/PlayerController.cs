using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Transform playerTransform;
    Transform objectiveToScale;
    [SerializeField] float gradesMultiply;
    float movX, movZ;
    [SerializeField] float speed;
    [SerializeField] Rigidbody myRb;
    Vector3 moveInput;
    Quaternion rotateInput;

    void Start()
    {
        playerTransform = GetComponent<Transform>();
        myRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        movX = Input.GetAxis("Horizontal");
        movZ = Input.GetAxis("Vertical");

    }
    private void FixedUpdate()
    {

        if (Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
        {
            ControlMovement();
        }

    }
    void ControlMovement()
    {
        moveInput = new Vector3(movX, moveInput.y, movZ);
        Vector3 directionToMove = myRb.rotation * moveInput;
        rotateInput = Quaternion.Euler(rotateInput.x, movX * gradesMultiply, rotateInput.z);

        myRb.MovePosition(myRb.position + directionToMove * speed * Time.fixedDeltaTime);
        myRb.MoveRotation(myRb.rotation * rotateInput);

    }
}
