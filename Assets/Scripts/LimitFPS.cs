using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitFPS : MonoBehaviour
{
    // Start is called before the first frame update
    private void Awake()
    {
        Application.targetFrameRate = GameplayParameters.FrameRate;
    }
}
