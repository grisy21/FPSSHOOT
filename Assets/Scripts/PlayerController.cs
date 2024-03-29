using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class NewBehaviourScript : MonoBehaviour
{
    

    [Header("General")]
    public float gravityScale = -20f;
    public Camera palyerCamera;

    [Header("Movement")]
    public float walkSpeed = 5f;
    public float runSpeed = 10f;

    [Header("Jump")]
    public float jumHeight = 1.9f;

    [Header("Rotacion")]
    public float rotationSensibility = 10f;
    private float cameraVerticalAngle;

    Vector3 moveInput = Vector3.zero;
    Vector3 rotationinput = Vector3.zero;

    CharacterController CharacterController;

    public void Awake()
    {
        CharacterController = GetComponent<CharacterController>();

    }

    private void Update ()
    {
        Move();
        Look();
    }

    private void Move()
    {
        if (CharacterController.isGrounded)
        {
            moveInput = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
            moveInput = Vector3.ClampMagnitude(moveInput, 1f);

            if (Input.GetButton("Sprint"))
            {
                moveInput = transform.TransformDirection(moveInput) * runSpeed;
            }
            else
            {
                moveInput = transform.TransformDirection(moveInput) * walkSpeed;
            }

            if (Input.GetButtonDown("Jump"))
            {
                moveInput.y = Mathf.Sqrt(jumHeight * -2f * gravityScale);
            }
        }

        moveInput.y += gravityScale * Time.deltaTime;
        CharacterController.Move(moveInput * Time.deltaTime);
    }

    private void Look()
    {
        rotationinput.x = Input.GetAxis("Mouse X") * rotationSensibility * Time.deltaTime;
        rotationinput.y = Input.GetAxis("Mouse Y") * rotationSensibility * Time.deltaTime;

        cameraVerticalAngle += rotationinput.y;
        cameraVerticalAngle = Mathf.Clamp(cameraVerticalAngle, -70, 70);

        transform.Rotate(Vector3.up * rotationinput.x);
        palyerCamera.transform.localRotation = Quaternion.Euler(-cameraVerticalAngle, 0f, 0f);
    }


}
