using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIPanel : MonoBehaviour
{
    public List<UIPanelText> infoContent = new List<UIPanelText>();
    public TextMeshProUGUI titleText;
    public TextMeshProUGUI contentText;
    public int count;
    public Button nextBtn;

    public static UIPanel instance;

    public void Awake()
    {
        if (instance != null)
        {
            Destroy(instance);
        }
        else
        {
            instance = this;
        }

        nextBtn.onClick.AddListener(NextbuttonClick);
        ShowText(0);
    }

    public void NextbuttonClick()
    {
        count++;
        ShowText(count);
    }

    public void ShowText(int count)
    {
        if(count < 0)
            return;

        if (count >= infoContent.Count)
            return;

        titleText.text = infoContent[count].title;
        contentText.text =infoContent[count].Info;
    }
}

[System.Serializable]
public class UIPanelText
{
    public string title;
    public string Info;
}
