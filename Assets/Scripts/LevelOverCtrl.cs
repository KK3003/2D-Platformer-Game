
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelOverCtrl : MonoBehaviour
{

    public string sceneName;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(sceneName);
            Debug.Log("LEVEL COMPLETED");
        }
    }
}
