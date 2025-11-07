using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    
    void Start()
    {
        ScoreManager.FinishGame();
    }

    
   public void Quit()
    {
        Application.Quit();
    }

   public void Restart()
    {
        SceneManager.LoadScene("Scene 1");
    }
}
