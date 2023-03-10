using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour {

    public static SceneLoader Instance;
    [HideInInspector]
    public string prevScene, currentScene;

    AsyncOperation operation;

    [SerializeField]
    GameObject loadingPanel,mainCanvas;

    [SerializeField]
    Text downloadPercent;

    [SerializeField]
    Image downloadImage, loadingImage;

    [SerializeField]
    AudioSource musicSource;
    
    // Use this for initialization
    void Awake ()
    {
        if (Instance == null)
            Instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
        
        DontDestroyOnLoad(gameObject);
        loadingPanel.SetActive(false);
        mainCanvas.SetActive(false);
	}
	
    public void LoadScene(string sceneName)
    {
        prevScene = SceneManager.GetActiveScene().name;
        currentScene = sceneName;
        mainCanvas.SetActive(true);
        StartCoroutine(Load());
        downloadPercent.text = "Loading ... 00%";
        
    }

    IEnumerator Load()
    {
        Color tempColor=Color.white;
        tempColor.a = 0;
        loadingImage.color = tempColor;
        while (tempColor.a<1)
        {
            tempColor.a += Time.deltaTime;
            loadingImage.color = tempColor;
            yield return null;
        }

        loadingPanel.SetActive(true);
        yield return new WaitForSeconds(1);
        operation = SceneManager.LoadSceneAsync(currentScene);
        while(operation.progress<1)
        {
            yield return null;
            downloadImage.fillAmount = operation.progress;
            downloadPercent.text = "Loading ... "+(operation.progress * 100).ToString("00") + "%";
        }
        downloadImage.fillAmount = 1;
        downloadPercent.text = "100%";
        yield return new WaitForSeconds(1);
        loadingPanel.SetActive(false);
        tempColor.a = 1;
        while (tempColor.a > 0)
        {
            tempColor.a -= Time.deltaTime;
            loadingImage.color = tempColor;
            yield return null;
        }
        mainCanvas.SetActive(false);
        if (SceneManager.GetActiveScene().name.Contains("Animation"))
        {
            musicSource.Pause();
        }
        else
        {
            musicSource.Play();
        }
    }
}
