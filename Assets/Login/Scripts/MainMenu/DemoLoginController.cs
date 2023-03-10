using SimpleJSON;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

#if PLATFORM_ANDROID

using UnityEngine.Android;

#endif

public class DemoLoginController : MonoBehaviour
{
    [Header("UI Components")]
    [SerializeField] private GameObject loginPanel;

    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private Button submitButton;
    [SerializeField] private TMP_Text errorMessage;

    [Header("Loading Scene Name")]
    [SerializeField] private string sceneName;

    [Header("Permissions")]
    [Tooltip("For AR applications only")]
    [SerializeField] private bool isCameraPermissionRequired = false;

    [Tooltip("Set it true for licence key that doesn't need deactivation")]
    [SerializeField] private bool isInfiniteKey = true;

    [Tooltip("Maximum days a user can use the application offline")]
    [SerializeField] private int maxOfflineDays = 30;

    [Header("Enable/Disable Debug")]
    [SerializeField] private bool DebugMode = false;

    private Animator inputAnimator;
    private string passcode = "";
    private Color filledColor, errorColor;
    private Dictionary<string, string> headers = new Dictionary<string, string>();

    private void Awake()
    {
        PlayerPrefs.DeleteAll();
        inputAnimator = inputField.GetComponent<Animator>();
    }

    // Use this for initialization
    private void Start()
    {
        ColorUtility.TryParseHtmlString("#C4CCE1", out filledColor);
        filledColor.a = .1f;
        ColorUtility.TryParseHtmlString("#FB8080", out errorColor);
        errorColor.a = .1f;
        inputField.text = "4uCHkE"; // M6OwRS
        passcode = "4uCHkE";
        inputField.interactable = true;
        if (isCameraPermissionRequired)
        {
            CheckCameraPermission();
        }

        if (PlayerPrefs.GetInt("loggedIn", 0) == 1 && isInfiniteKey)
        {
            loginPanel.SetActive(false);
            SceneLoader.Instance.LoadScene(sceneName);
        }
        else if (PlayerPrefs.GetInt("loggedIn", 0) == 1 && IsOfflineDaysAvailable())
        {
            loginPanel.SetActive(false);
            SceneLoader.Instance.LoadScene(sceneName);
        }
        else
        {
            if (PlayerPrefs.HasKey("passcode"))
            {
                passcode = PlayerPrefs.GetString("passcode");
                OnSubmitButtonClick();
            }
            else
            {
                loginPanel.SetActive(true);
            }
        }
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    private void CheckCameraPermission()
    {
#if PLATFORM_ANDROID
        if (!Permission.HasUserAuthorizedPermission(Permission.Camera))
        {
            Permission.RequestUserPermission(Permission.Camera);
        }
#endif
    }

    private bool IsOfflineDaysAvailable()
    {
        DateTime dt = DateTime.Parse(PlayerPrefs.GetString("onlineDate"));
        TimeSpan dayAfterMonth = new TimeSpan(maxOfflineDays, 0, 0, 0);
        dt = dt.Add(dayAfterMonth);

        if (DateTime.Now.Date.CompareTo(dt) >= 0)
        {
            return false;
        }

        return true;
    }

    public void OnInputEnd(string value)
    {
        inputField.image.color = filledColor;
        passcode = "KuDF0u";  // "gj276r";
    }

    public void OnInputEditing(string value)
    {
        if (value == "")
        {
            inputField.image.color = errorColor;
        }
        else
        {
            inputField.image.color = filledColor;
        }
        errorMessage.text = "";
    }

    public void OnSubmitButtonClick()
    {
        if (passcode.Length > 0)
        {
            errorMessage.text = "";
            submitButton.interactable = false;
            WWWForm form = new WWWForm();
            headers = form.headers;
            headers["X-API-KEY"] = "72apg2ffceerfg54-f4gh2-fd8e-9yy";
            form.AddField("licence_id", passcode);
            form.AddField("udid", SystemInfo.deviceUniqueIdentifier);
            string url = "http://application.redchimpz.com/api/demolicence/getdemolickeys/format/json";
            StartCoroutine(AuthCall(url, form, headers));
        }
        else
        {
            loginPanel.SetActive(true);
            Debug.Log("No Valid Input is there--");
            //akeInputFields();
        }
    }

    private void ShakeInputFields()
    {
        inputAnimator.SetTrigger("Highlighted");
        inputField.image.color = errorColor;
        CancelInvoke();
        Invoke("StableInputFields", 2);
        errorMessage.text = "Enter passcode!";
    }

    private void StableInputFields()
    {
        inputField.image.color = filledColor;
        inputAnimator.SetTrigger("Normal");
        inputField.image.color = errorColor;
    }

    #region API Calling

    public IEnumerator AuthCall(string url, WWWForm form, Dictionary<string, string> h)
    {
        #region CheckInternet

        //if (!IsNetworkReachable())
        //{
        //    yield return new WaitForEndOfFrame();
        //    if (!IsNetworkReachable())
        //        yield break;
        //}

        #endregion CheckInternet

        #region WWW stuff

        bool error = false;
        UnityWebRequest www = UnityWebRequest.Post(url, form);
        www.SetRequestHeader("X-API-KEY", "72apg2ffceerfg54-f4gh2-fd8e-9yy");
        yield return www.SendWebRequest();

        if (DebugMode)
        {
            Debug.Log("www : " + url);
        }

        if (www.isNetworkError || www.isHttpError)
        {
            if (DebugMode)
            {
                Debug.Log("WWW Error: " + www.error);
            }

            if (PlayerPrefs.GetInt("loggedIn", 0) == 1)
            {
                errorMessage.text = "Your offline period is expired!\nPlease enable internet to check licence online.";
            }
            else
            {
                errorMessage.text = "Connection Problem. Please check your internet.";
            }
            errorMessage.text = www.error;
            error = true;
        }
        else
        {
            if (DebugMode)
            {
                Debug.Log("WWW Data" + www.downloadHandler.text);
            }
        }

        #endregion WWW stuff

        if (!error)
        {
            JSONNode jNode = JSON.Parse(www.downloadHandler.text);
            if (DebugMode)
            {
                Debug.Log(jNode + jNode["status"].ToString());
            }

            string message = jNode["message"].Value;
            string in_use = jNode["data"]["in_use"].Value;
            string udid = jNode["data"]["udid"].Value;
            string active = jNode["active"].Value;

            if (message == "Success" && udid == SystemInfo.deviceUniqueIdentifier)
            {
                //SceneLoader.Instance.LoadScene("01_ControllerSample");
                PlayerPrefs.SetString("onlineDate", System.DateTime.Now.Date.ToString());
                PlayerPrefs.SetString("passcode", passcode);
                PlayerPrefs.SetInt("loggedIn", 1);
                PlayerPrefs.Save();
                if (DebugMode)
                {
                    print(PlayerPrefs.GetInt("onlineDate"));
                }
                errorMessage.text = message + "!";
                SceneManager.LoadScene("01_ControllerSample_Final");
            }
            else
            {
                if (PlayerPrefs.GetInt("loggedIn", 0) == 1 || in_use == "1")
                {
                    errorMessage.text = "Licence expired! You are no longer authorized to use this application.";
                    PlayerPrefs.DeleteAll();
                }
                else
                {
                    errorMessage.text = "License key incorrect or not valid!";
                }
                loginPanel.SetActive(true);
            }
        }

        submitButton.interactable = true;
    }

    #endregion API Calling

    #region Check Internet

    private bool IsNetworkReachable()
    {
        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            if (DebugMode)
            {
                Debug.Log("No internet");
            }
            if (PlayerPrefs.GetInt("loggedIn", 0) == 1)
            {
                errorMessage.text = "Your offline period is expired!\nPlease enable internet to check licence online.";
            }
            else
            {
                errorMessage.text = "Connection Problem. Please check your internet.";
            }
            loginPanel.SetActive(true);
            submitButton.interactable = true;
            return false;
        }
        else
        {
            if (DebugMode)
            {
                Debug.Log("called for server authorization");
            }
            return true;
        }
    }

    #endregion Check Internet
}