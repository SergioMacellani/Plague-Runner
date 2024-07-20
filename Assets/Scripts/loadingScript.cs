using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class loadingScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 61;
        if (PlayerPrefs.GetInt("Tutorial") == 0)
        {
            StartCoroutine(LoadAsync("Tutorial"));
            PlayerPrefs.DeleteAll();
            QualitySettings.SetQualityLevel(2);
            PlayerPrefs.SetInt("quality", 2);
            PlayerPrefs.SetInt("pfx", 1);
        }
        else
        {
            StartCoroutine(LoadAsync("Game"));
        }
    }

    IEnumerator LoadAsync(string sceneIndex)
    {
        AsyncOperation load = SceneManager.LoadSceneAsync(sceneIndex);

        while (!load.isDone)
        {
            Debug.Log(load.progress);
            transform.GetChild(1).GetComponent<Slider>().value = load.progress;
            float percentage = load.progress * 100;
            transform.GetChild(2).GetComponent<Text>().text = (int)percentage + "%";
            yield return null;
        }
    }
}
