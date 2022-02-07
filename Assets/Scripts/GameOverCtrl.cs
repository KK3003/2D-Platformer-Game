
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameOverCtrl : MonoBehaviour
{
    public Button btnrestart;


    private void Awake()
    {
        btnrestart.onClick.AddListener(ReloadLevel);
    }
    public void ShowGameOverMenu()
    {
        gameObject.SetActive(true);
    }

    void ReloadLevel()
    {
        SceneManager.LoadScene("Prototype");
    }
}
