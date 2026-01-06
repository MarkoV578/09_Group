using System;
using UnityEngine;

public class CoffeInCupCheck : MonoBehaviour
{
    [SerializeField] private SecondBonusLevel _gameManager;
    
    private void OnTriggerStay(Collider other)
    {
        if (Input.GetMouseButton(0))
        {
            _gameManager.clicksCurrent += 50;
            _gameManager.UpdateText();
            Destroy(other.gameObject);
        }
    }
}
