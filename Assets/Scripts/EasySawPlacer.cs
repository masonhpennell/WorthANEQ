using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasySawPlacer : MonoBehaviour
{
    public GameObject EasySawPrefab;

    void Start()
    {
        PlaceEasyPrefabs();
    }

    public void PlaceEasyPrefabs()
    {
        Instantiate(EasySawPrefab, RandomRightOfTheScreenLocation(1), Quaternion.identity);
        Instantiate(EasySawPrefab, RandomRightOfTheScreenLocation(10), Quaternion.identity);
        Instantiate(EasySawPrefab, RandomRightOfTheScreenLocation(18), Quaternion.identity);
        StartCoroutine(RandomEasySpawnPlacement());
    }

    private Vector3 RandomRightOfTheScreenLocation(int yLevel)
    {
        int randomRangeToPlacePrefabs = Random.Range(8,14);
        return new Vector3(randomRangeToPlacePrefabs, yLevel, 0);
    }

    IEnumerator RandomEasySpawnPlacement()
    {
        yield return new WaitForSeconds(GameplayParameters.randomSecondsToPlaceEasySaw);
        PlaceEasyPrefabs();
    }
}
