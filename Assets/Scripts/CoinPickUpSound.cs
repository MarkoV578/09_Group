using UnityEngine;

public class CoinPickUpSound : MonoBehaviour
{
    private AudioSource _audioSource;

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            _audioSource.Play();
            Destroy(gameObject, _audioSource.clip.length);
        }
    }

}
