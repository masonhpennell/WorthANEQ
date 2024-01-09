using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HardSawWalk : MonoBehaviour
{
    public SpriteRenderer HardSawSprite;
    private bool isWaitingToHardWalk = false;

    void Update()
    {
        if (!isWaitingToHardWalk)
        {
            StartCoroutine(CountdownUntilHardWalk());
            isWaitingToHardWalk = true;
        }
    }

    private void HardWalking()
    {
        HardSawSprite.transform.Translate(-GameplayParameters.walkIncrement);
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(HardSawSprite.transform.position);
        if(screenPosition.x < -9)
        {
            Destroy(this.gameObject);
        }
    }

    IEnumerator CountdownUntilHardWalk()
    {
        yield return new WaitForSeconds(GameplayParameters.waitToHardWalkSeconds);
        HardWalking();
        isWaitingToHardWalk = false;
    }
}
