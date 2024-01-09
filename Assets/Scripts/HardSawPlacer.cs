using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HardSawPlacer : MonoBehaviour
{
    public GameObject HardSawPrefab;

    void Start()
    {
        PlaceHardPrefabs();
    }


    public void PlaceHardPrefabs()
    {
        Instantiate(HardSawPrefab, RandomRightOfTheScreenLocation(3), Quaternion.identity);
        Instantiate(HardSawPrefab, RandomRightOfTheScreenLocation(5), Quaternion.identity);
        Instantiate(HardSawPrefab, RandomRightOfTheScreenLocation(8), Quaternion.identity);
        StartCoroutine(RandomHardSpawnPlacement());
    }

    private Vector3 RandomRightOfTheScreenLocation(int yLevel)
    {
        int randomRangeToPlacePrefabs = Random.Range(8,14);
        return new Vector3(randomRangeToPlacePrefabs, yLevel, 0);
    }

    IEnumerator RandomHardSpawnPlacement()
    {
        yield return new WaitForSeconds(GameplayParameters.randomSecondsToPlaceHardSaw);
        PlaceHardPrefabs();
    }
}
