using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f; // Hareket hızı
    [SerializeField] private float sensitivity = 5f; // Mouse hassasiyeti
    private float rotationX = 0f; // Yukarı-aşağı dönüş için değişken
    private Camera playerCamera; // Karakterin kamerası

    private void Start()
    {
        playerCamera = Camera.main; // Ana kamerayı al
        Cursor.lockState = CursorLockMode.Locked; // Mouse'u oyun ekranına kilitle
    }

    private void Update()
    {
        HandleMovement(); // Hareketi kontrol et
        HandleMouseLook(); // Mouse ile bakış kontrolü
    }

    private void HandleMovement()
    {
        // Klavyeden girişleri al
        float horizontalInput = Input.GetAxis("Horizontal"); // A-D (sol-sağ)
        float verticalInput = Input.GetAxis("Vertical");     // W-S (ileri-geri)

        // Hareket yönünü hesapla
        Vector3 moveDirection = transform.right * horizontalInput + transform.forward * verticalInput;

        // Hareketi uygula
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.World);
    }

    private void HandleMouseLook()
    {
        // Mouse hareketlerini al
        float mouseX = Input.GetAxis("Mouse X") * sensitivity; // Sağ-sol dönüş
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity; // Yukarı-aşağı dönüş

        // Sağa-sola dönüş (karakterin kendi ekseni)
        transform.Rotate(Vector3.up * mouseX);

        // Yukarı-aşağı bakış (kamerayı döndür)
        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, -70f, 70f); // Yukarı ve aşağı bakış sınırları
        playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
    }
}
