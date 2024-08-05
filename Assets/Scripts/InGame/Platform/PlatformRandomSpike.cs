using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformRandomSpike : MonoBehaviour
{
    [Header("Random Range")]
    [Range(-1, 100)]
    [SerializeField] private int randomValue = 20;

    [Header("Count Spikes")]
    [SerializeField] private int countSpikes;

    [Header("Spike")]
    [SerializeField] private GameObject spike;

    private PlatformRandomGrass randomGrass;

    private void Start()
    {
        randomGrass = GetComponent<PlatformRandomGrass>();

        bool spawn = Random.Range(0, 100) < randomValue;

        if(spawn)
        {
            for (int i = 0; i < Random.Range(1, countSpikes); i++)
            {
                Instantiate(spike, randomGrass.RandomPosition(), Quaternion.identity);
            }
        }
    }
}
