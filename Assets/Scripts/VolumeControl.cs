using UnityEngine;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{
    public Slider Slider;
    private AudioSource _audioSource;
    
    private const string VOLUME = "Volume";
    private float _volume;
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        
        Load();
        
        _audioSource.volume = _volume;
        Slider.value = _audioSource.volume;
    }

    public void ChangeVolume()
    {
        _audioSource.volume = Slider.value;
        Save();
    }

    private void Load()
    {
        _volume = PlayerPrefs.GetFloat(VOLUME, 0.5f);
    }

    private void Save()
    {
        PlayerPrefs.SetFloat(VOLUME, _volume);
    }

}
