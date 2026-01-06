using System.Collections;
using UnityEngine;

public class CoffeSpawner : MonoBehaviour
{
    [SerializeField] private GameObject coffePrefab;

    void Start()
    {
        StartCoroutine("SpawnWithDelay");
    }

    IEnumerator SpawnWithDelay()
    {
        while ((true))
        {
            WaitForSeconds delay = new WaitForSeconds(Random.Range(1, 3));
        
            Instantiate(coffePrefab, transform.position, Quaternion.identity);
        
            yield return delay;
        }
    }

}
