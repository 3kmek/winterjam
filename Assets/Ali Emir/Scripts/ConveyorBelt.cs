using UnityEngine;

public class ConveyorBelt : MonoBehaviour
{
    [SerializeField] public float RaySpeed = 0.8f; // Conveyor hız
    [SerializeField] private Material material; // Conveyor material
    private Vector2 offset; // Texture kaydırma
    private Vector3 conveyorDirection; // Belt'in yönü

    private float timer = 0f; // Zamanlayıcı
     
    
    void Start()
    {
        // Conveyor yönü (lokal Z ekseni)
        conveyorDirection = transform.right;

        // Malzeme cache'le
        if (material == null)
        {
            material = GetComponent<MeshRenderer>().material;
        }

        offset = Vector2.zero;
        
        
    }

    void Update()
    {
        if (timer < 3.5f) // 5 saniye dolana kadar kaydırma işlemi
        {
            Sliding();
        }
        else
        {
            RaySpeed = 0f; // 5 saniye sonra hızı sıfırla
        }
    }

    void Sliding()
    {
        timer += Time.deltaTime;
        offset.y -= RaySpeed * Time.deltaTime;
        material.mainTextureOffset = offset;
    }

    // Objeler trigger içine girdiğinde
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            return;
        }

        Rigidbody rb = other.GetComponent<Rigidbody>();
        if (rb != null)
        {
            // Objeyi manuel olarak pozisyonla hareket ettir
            Vector3 newPosition = other.transform.position + conveyorDirection * RaySpeed * Time.deltaTime * -2.5f;
            rb.MovePosition(newPosition);
        }
    }

}
