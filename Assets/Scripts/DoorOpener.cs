using System;
using UnityEngine;

public class DoorOpener : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    void Start()
    {
        _animator = gameObject.GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _animator.SetBool("isOpened", true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _animator.SetBool("isOpened", false);
        }
    }
}
