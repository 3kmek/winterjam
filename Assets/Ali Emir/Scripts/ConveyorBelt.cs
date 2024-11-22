using UnityEngine;

public class ConveyorBelt : MonoBehaviour
{
    [SerializeField] private float speed; // Kaydırma hızı
    [SerializeField] private Material material; // Conveyor belt'in malzemesi

    private Vector2 offset; // Texture kaydırma için vektör

    void Start()
    {
        // MeshRenderer'ın materialine eriş
        if (material == null)
        {
            material = GetComponent<MeshRenderer>().material;
        }

        // Başlangıç kaydırma vektörünü sıfırla
        offset = Vector2.zero;
    }

    void Update()
    {
        // Y ekseni boyunca kaydırma
        offset.y -= speed * Time.deltaTime;

        // Malzeme üzerindeki texture kaydırmasını uygula
        material.mainTextureOffset = offset;
    }
}
