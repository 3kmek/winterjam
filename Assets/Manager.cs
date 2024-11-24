using UnityEngine;

public class Manager : MonoBehaviour
{
    public static Manager instance;

    // Taşımak istediğiniz değişkenler
    public int İyiSkor = 0;
    public int KötüSkor = 0;
    public string oyuncuAdi;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Diğer fonksiyonlar ve değişkenler...
}