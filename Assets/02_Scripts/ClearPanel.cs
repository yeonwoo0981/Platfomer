using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClearPanel : MonoBehaviour
{
    public GameObject _clearPanel;

    private void Start()
    {
        _clearPanel.gameObject.SetActive(false);
    }

    public void RestartGame()
   {
       SceneManager.LoadScene(1);
       Time.timeScale = 1;
   }

   public void QuitGame()
   {
       Application.Quit();
   }
}
