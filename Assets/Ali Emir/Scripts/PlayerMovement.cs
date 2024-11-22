using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float sensivity = 5f;
    private float rotX, mouseX, mouseY;
    private float rotY = 90f;
    [SerializeField] private Camera _camera;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        _camera = Camera.main;
        Cursor.lockState = CursorLockMode.Locked;
        rb.isKinematic = true; // Rigidbody'nin hareketi manuel olarak kontrol edileceği için.
    }

    private void Update()
    {
        HandleMouse();
        RotatePlayerLeftRight();
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Yerel koordinatlara göre hareket yönü
        Vector3 dir = transform.right * horizontalInput + transform.forward * verticalInput;

        // Hareketi uygulama
        rb.MovePosition(transform.position + dir * moveSpeed * Time.fixedDeltaTime);
    }

    private void HandleMouse()
    {
        mouseX = Input.GetAxis("Mouse X") * sensivity;
        mouseY = Input.GetAxis("Mouse Y") * sensivity;
    }

    private void RotatePlayerLeftRight()
    {
        rotY += mouseX;

        // Dönüşü uygula
        transform.rotation = Quaternion.Euler(0, rotY, 0);
    }

    private void RotatePlayerUpDown()
    {
        rotX -= mouseY;
        rotX = Mathf.Clamp(rotX, -70f, 70f);

        _camera.transform.localRotation = Quaternion.Euler(rotX, 0, 0);
    }
}
