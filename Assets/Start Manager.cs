using UnityEngine;
using UnityEngine.SceneManagement;

public class LetsGO : MonoBehaviour
{
    
    public void BallStart()
    {
       SceneManager.LoadScene("Scene 1");
    }

    
    public void Quit()
    {
        Application.Quit();
    }
}
