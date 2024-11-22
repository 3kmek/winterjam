using UnityEngine;

public class ConveyorBelt : MonoBehaviour
{
    [SerializeField] private float speed; // Conveyor hız
    [SerializeField] private Material material; // Conveyor material
    private Vector2 offset; // Texture kaydırma
    private Vector3 conveyorDirection; // Belt'in yönü

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
        // Doku kaydırma
        offset.y -= speed * Time.deltaTime;
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
            Vector3 newPosition = other.transform.position + conveyorDirection * speed * Time.deltaTime;
            rb.MovePosition(newPosition);
        }
    }

}
