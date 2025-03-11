using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    public Slider LoadingSlide;
    public Text ProgressText;
    public void PlayGame(int sceneIndex)
    {
        StartCoroutine(LoadAsynchronously(sceneIndex));

    }
    IEnumerator LoadAsynchronously(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);


        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f); 
            
            LoadingSlide.value = progress;

            ProgressText.text = progress * 100f + "%";

            yield return null;
        }
    }
    
    public void QuitGame()
    {
        Application.Quit();
    }

    
}
