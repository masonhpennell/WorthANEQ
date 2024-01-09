using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Saws : MonoBehaviour
{
    public SpriteRenderer FrogSpriteRenderer;
    public SpriteRenderer HardSaw;
    public Vector3 walkIncrement = new Vector3(1, 0, 0);
    private bool isWaitingToEasyWalk = false;
    private bool isWaitingToHardWalk = false;
    protected float waitToEasyWalkSeconds = 0.5f;
    protected float waitToHardWalkSeconds = 0.2f;
    void Update()
    {
        if (!isWaitingToEasyWalk)
        {
            StartCoroutine(CountdownUntilEasyWalk());
            isWaitingToEasyWalk = true;
        }
        if (!isWaitingToHardWalk)
        {
            StartCoroutine(CountdownUntilHardWalk());
            isWaitingToHardWalk = true;
        }
    }
    private void EasyWalking()
    {
        FrogSpriteRenderer.transform.Translate(-walkIncrement);
        TeleportToOtherSideOfScreen(FrogSpriteRenderer);
    }
    private void HardWalking()
    {
        HardSaw.transform.Translate(-walkIncrement);
        TeleportToOtherSideOfScreen(HardSaw);
    }
    IEnumerator CountdownUntilEasyWalk()
    {
        yield return new WaitForSeconds(waitToEasyWalkSeconds);
        EasyWalking();
        isWaitingToEasyWalk = false;
    }
    IEnumerator CountdownUntilHardWalk()
    {
        yield return new WaitForSeconds(waitToHardWalkSeconds);
        HardWalking();
        isWaitingToHardWalk = false;
    }
    private void TeleportToOtherSideOfScreen(SpriteRenderer SpriteRenderer)
    {
        Vector3 currentScreenPosition = SpriteRenderer.transform.position;
        if (currentScreenPosition.x <= -9)
        { //if screenpositionx is at the end screen positionx is put on the other side
            currentScreenPosition.x = 7;
        }
        SpriteRenderer.transform.position = currentScreenPosition;
    }
}