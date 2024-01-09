using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flame : MonoBehaviour
{
    public SpriteRenderer FlameSprite;
    public Sprite SmallFlame;
    public Sprite BigFlame;
    public BoxCollider damage;
    public GameObject EffectPrefab;
    private bool isReadyToFlame = true;

    void Update()
    {
        if (isReadyToFlame)
            StartCoroutine(CountdownTilCreation());
    }

    IEnumerator CountdownTilCreation()
    {
        isReadyToFlame = false;
        yield return new WaitForSeconds(GameplayParameters.FlameSecondsOffScreen);
        FlameSprite.sprite = SmallFlame;
        StartCoroutine(CountdownToBigFlame());
    }

    IEnumerator CountdownToBigFlame()
    {
        yield return new WaitForSeconds(GameplayParameters.SmallFlameTime);
        FlameSprite.sprite = BigFlame;
        damage.enabled = true;
        //Instantiate(EffectPrefab, transform.position, Quaternion.identity);
        StartCoroutine(CountdownToExtinguish());
    }

    IEnumerator CountdownToExtinguish()
    {
        yield return new WaitForSeconds(GameplayParameters.BigFlameTime);
        FlameSprite.sprite = null;
        damage.enabled = false;
        isReadyToFlame = true;
    }
}
