
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenechanger : MonoBehaviour
{
    public string sceneName;
    
    public void LoadScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
