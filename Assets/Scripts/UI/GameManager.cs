using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject _settingsPanel;
    
    public void LoadGameScene()
    {
        SceneManager.LoadScene(0);
    }

    public void SettingsPanel()
    {
        _settingsPanel.SetActive(true);
    }

    public void MenuPanel()
    {
        _settingsPanel.SetActive(false);
    }

}
