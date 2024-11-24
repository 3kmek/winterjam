using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private Manager Manager;
    // Bu fonksiyonu seviyenin tamamlandığı zaman çağırın
    public void NextLevel()
    {
        int mevcutSahneIndex = SceneManager.GetActiveScene().buildIndex;
        int sonrakiSahneIndex = mevcutSahneIndex + 1;

        // Sonraki sahnenin olup olmadığını kontrol et
        if (sonrakiSahneIndex < SceneManager.sceneCountInBuildSettings)
        {
            if (SceneManager.GetActiveScene().name == "Level5")
            {
                if (Manager.İyiSkor >= Manager.KötüSkor)
                {
                    SceneManager.LoadScene("GoodEnding");
                }
                if (Manager.KötüSkor > Manager.İyiSkor)
                {
                    SceneManager.LoadScene("BadEnding");
                }
            }
            else
            {
                SceneManager.LoadScene(sonrakiSahneIndex);
            }
        }
        else
        {
            // Eğer başka sahne yoksa, oyun sonu ekranı veya ana menüye dön
            Debug.Log("Tüm bölümler tamamlandı!");
            // Örneğin ana menüye dönmek isterseniz:
            // SceneManager.LoadScene("AnaMenu");
        }
    }

    public void GoToLevel1()
    {
        SceneManager.LoadScene("Level1");
    }
    
    public void Gameover()
    {
        SceneManager.LoadScene("GameOver");
    }
}