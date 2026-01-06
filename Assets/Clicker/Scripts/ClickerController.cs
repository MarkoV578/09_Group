using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class ClickerController : MonoBehaviour
{
    #region Const value
    private const string Save_Click = "TotalClicks";
    private const string Save_Price_Bonus_1 = "SavePrice1";
    private const string Save_Price_Bonus_2 = "SavePrice2";
    private const string Save_Price_Bonus_3 = "SavePrice3";
    private const string Save_Click_Now = "SaveClickNow";    
    private const string Bonus_Level_Save = "BONUS_LEVEL_SAVE";
    private const string Save_Auto_Click = "Autoclick";
    private const float Coefecient = 1.35f;
    #endregion

    #region Value

    [SerializeField] private Text clickText;
    [SerializeField] private Text bonuseText1;
    [SerializeField] private Text bonuseText2;
    [SerializeField] private Text bonuseText3;
    [SerializeField] private Button bonuseProButton;
    [SerializeField] private Sprite bonuseProSpriteFull;
    [SerializeField] private Sprite bonuseProSprite;
    [SerializeField] private int bonusPrice1 = 100;
    [SerializeField] private int bonusPrice2 = 1250;
    [SerializeField] private int bonusPrice3 = 2500;
    
    private int totalclick = 0;
    private int clickNow = 1;

    private int bonusClick = 0;
    private int autoClick = 0; 
    private bool isCoroutineRunning = false;

    #endregion

    #region Game Manager
    void Awake()
    {
        Load();
        clickNow = 150;
        totalclick += bonusClick;
        
        BonuseProButtonActivation();
        UpdateClickText();
        
        if (autoClick >= 1)
        {
            StartCoroutine(StartAutoClick());
            isCoroutineRunning = true;
        }
    }
    private void UpdateClickText()
    {
        clickText.text = totalclick.ToString();
        bonuseText1.text = bonusPrice1.ToString();
        bonuseText2.text = bonusPrice2.ToString();
        bonuseText3.text = bonusPrice3.ToString();
    }
    public void ClickButton()
    {
        totalclick += clickNow;
        
        BonuseProButtonActivation();
        UpdateClickText();
    }

    private void BonuseProButtonActivation()
    {
        if (totalclick <= 1000)
        {
            bonuseProButton.interactable = false;
            return;
        }
        
        bonuseProButton.GetComponent<Image>().sprite = bonuseProSpriteFull;
        bonuseProButton.interactable = true;
        
    }

    public void LoadBonusProLevel()
    {
        totalclick -= 1000;
        Save();
        BonuseProButtonActivation();
        SceneManager.LoadScene("BonusProLevel");
    }

    public void LoadBonuseLevel()
    {
        Save();
        SceneManager.LoadScene("BonusScene");
    }

    public void BonuseClick_1()
    {
        if (totalclick >= bonusPrice1)
        {
            totalclick -= bonusPrice1;
            clickNow += 1;
            bonusPrice1 = (int)(bonusPrice1 * Coefecient);
        }
        BonuseProButtonActivation();
        UpdateClickText();
    }

    public void BonuseClick_2()
    {
        if(totalclick >= bonusPrice2)
        {
            totalclick -= bonusPrice2;
            autoClick++;
            bonusPrice2 = (int)(bonusPrice2 * Coefecient);
            BonuseProButtonActivation();
            if (!isCoroutineRunning)
            {
                StartCoroutine(StartAutoClick());
            }
        }
    }

    IEnumerator StartAutoClick()
    {
        while (true)
        {
            totalclick += autoClick;
            UpdateClickText();
            yield return new WaitForSeconds(1);
        }
    }
    
    public void BonuseClick_3()
    {
        if (totalclick >= bonusPrice3)
        {
            totalclick -= bonusPrice3;
            bonusPrice3 = (int)(bonusPrice3 * Coefecient);
            
            if (Random.Range(0, 1) == 0)
            {
                totalclick = 0;
            }
            else
            {
                totalclick *= 2;
            }
        }
        BonuseProButtonActivation();
        UpdateClickText();
    }
    
    #endregion

    #region Save Method
    private void OnApplicationQuit()
    {
        Save();
    }
    private void OnApplicationPause() 
    { 
        Save(); 
    }

    public void ResetProgress()
    {
        PlayerPrefs.DeleteAll();
        Load();
        clickNow = 150;
        BonuseProButtonActivation();
        UpdateClickText();
    }

    private void Load()
    {
        clickNow = PlayerPrefs.GetInt(Save_Click_Now, 1);
        bonusPrice1 = PlayerPrefs.GetInt(Save_Price_Bonus_1, 100);
        bonusPrice2 = PlayerPrefs.GetInt(Save_Price_Bonus_2, 1250);
        bonusPrice3 = PlayerPrefs.GetInt(Save_Price_Bonus_3, 2500);
        totalclick = PlayerPrefs.GetInt(Save_Click, 0);
        autoClick = PlayerPrefs.GetInt(Save_Auto_Click, 0);
        bonusClick = PlayerPrefs.GetInt(Bonus_Level_Save, 0); 
    }
    private void Save()
    {
        PlayerPrefs.SetInt(Save_Click_Now, clickNow);
        PlayerPrefs.SetInt(Save_Price_Bonus_1, bonusPrice1);
        PlayerPrefs.SetInt(Save_Price_Bonus_2, bonusPrice2);
        PlayerPrefs.SetInt(Save_Price_Bonus_3, bonusPrice3);
        PlayerPrefs.SetInt(Save_Auto_Click, autoClick);
        PlayerPrefs.SetInt(Bonus_Level_Save, 0);
    }
    #endregion
}
