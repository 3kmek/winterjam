using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    // Bu fonksiyonu seviyenin tamamlandığı zaman çağırın
    public void NextLevel()
    {
        int mevcutSahneIndex = SceneManager.GetActiveScene().buildIndex;
        int sonrakiSahneIndex = mevcutSahneIndex + 1;

        // Sonraki sahnenin olup olmadığını kontrol et
        if (sonrakiSahneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(sonrakiSahneIndex);
        }
        else
        {
            // Eğer başka sahne yoksa, oyun sonu ekranı veya ana menüye dön
            Debug.Log("Tüm bölümler tamamlandı!");
            // Örneğin ana menüye dönmek isterseniz:
            // SceneManager.LoadScene("AnaMenu");
        }
    }
}