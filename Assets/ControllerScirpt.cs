using BulletUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerScirpt : MonoBehaviour
{
    BCharacterController controller;
    [SerializeField] Transform FPCamera;
    [SerializeField] float mouseYSensitivity;
    [SerializeField] float mouseXSensitivity;
    [SerializeField] float defaultSpeed;
    [SerializeField] float gravity = -9.8f;
    private float cameraPitch;
    public bool pause = false;

    void Start()
    {
        controller = GetComponent<BCharacterController>();
        pause = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!pause)
        {
            UpdateMouseLook();
            UpdateKeyboard();
        }
    }

    void UpdateMouseLook()
    {
        Vector2 mouse = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"))  * Time.deltaTime;
        cameraPitch -= mouse.y * mouseYSensitivity;
        cameraPitch = Mathf.Clamp(cameraPitch, -90.0f, 90.0f);
        FPCamera.localRotation = Quaternion.Euler(cameraPitch, 0, 0);
        controller.Rotate(mouse.x * mouseXSensitivity);
    }

    void UpdateKeyboard()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            controller.Jump();
        }

        if(Input.GetKey(KeyCode.W))
        {
            controller.Move(FPCamera.forward * 0.1f * defaultSpeed);            
        }
        else if(Input.GetKey(KeyCode.S))
        {
            controller.Move(- FPCamera.forward * 0.1f * defaultSpeed);
        }
        else
        {
            controller.Move(new Vector3(0, 0, 0));
        }
    }
}