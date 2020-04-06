using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadScene : MonoBehaviour
{

    public GameObject loadScreen;
    public Slider loadingBar;

    public List<GameObject> textList;


    public void StartLoadingScene(int sceneIndex)
    {
        StartCoroutine(LoadingScene(sceneIndex));
        StartCoroutine(LoadingText(sceneIndex));
    }



    public void SwitchToModeScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);


    }

    IEnumerator LoadingScene(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        loadScreen.SetActive(true);
        
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);

            Debug.Log(progress);
            loadingBar.value = progress;
            yield return null;
        }
    }
    IEnumerator LoadingText(int sceneIndex)
    {
        Debug.Log("enter function");
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        while (!operation.isDone)
        {
            for (int i = 0; i < 4; i++)
            {
                textList[i].SetActive(true);
                textList[i - 1].SetActive(false);
                yield return new WaitForSeconds(0.5f);

            }


        }

    }




}
