using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasySawWalk : MonoBehaviour
{
    public SpriteRenderer CorgiSpriteRenderer;
    private bool isWaitingToEasyWalk = false;

    void Update()
    {
    if (!isWaitingToEasyWalk)
        {
            StartCoroutine(CountdownUntilEasyWalk());
            isWaitingToEasyWalk = true;
        }
    }

    private void EasyWalking()
    {
        CorgiSpriteRenderer.transform.Translate(-GameplayParameters.walkIncrement);
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(CorgiSpriteRenderer.transform.position);
        if(screenPosition.x < -9)
        {
            Destroy(this.gameObject);
        }
    }

    IEnumerator CountdownUntilEasyWalk()
    {
        yield return new WaitForSeconds(GameplayParameters.waitToEasyWalkSeconds);
        EasyWalking();
        isWaitingToEasyWalk = false;
    }
}
