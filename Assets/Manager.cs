using UnityEngine;

public class Manager : MonoBehaviour
{
    public static Manager instance;

    // Taşımak istediğiniz değişkenler
    public int İyiSkor;
    public int KötüSkor;
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