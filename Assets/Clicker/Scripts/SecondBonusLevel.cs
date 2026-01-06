using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class SecondBonusLevel : MonoBehaviour
{
    private const string TotalClicks = "TotalClicks";
    [SerializeField] private TMP_Text TotalClicksText;
    private int clicks = 0;
    [HideInInspector]public int clicksCurrent = 0;
    void Start()
    {
        UpdateText();
        LoadBonus();
    }
    
    public void LoadMainScene()
    {
        SaveBonus();
        SceneManager.LoadScene("MainScene");
    }

    public void UpdateText()
    {
        TotalClicksText.text = "Colected: " + clicksCurrent.ToString();
    }

    private void SaveBonus()
    {
        
        PlayerPrefs.SetInt(TotalClicks, clicks + clicksCurrent);
    }

    private void LoadBonus()
    {
        clicks = PlayerPrefs.GetInt(TotalClicks, 0);
    }
}
