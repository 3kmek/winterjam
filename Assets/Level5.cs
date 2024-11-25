using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level5 : MonoBehaviour
{
    
    
    public void SonuKontrolEt()
    {
        if (PuanManager.iyiPuan >= PuanManager.kotuPuan)
        {
            // İyi son sahnesine geçiş yap
            SceneManager.LoadScene("BadEnding");
        }
        else
        {
            // Kötü son sahnesine geçiş yap
            SceneManager.LoadScene("GoodEnding");
        }
    }
}
