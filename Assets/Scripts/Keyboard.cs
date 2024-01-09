using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keyboard : MonoBehaviour
{
    public Bunny Bunny;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
            Bunny.MoveManually(new Vector2(0, 1));

        if (Input.GetKey(KeyCode.S))
            Bunny.MoveManually(new Vector2(0, -1));

        if (Input.GetKey(KeyCode.A))
            Bunny.MoveManually(new Vector2(-1, 0));

        if (Input.GetKey(KeyCode.D))
            Bunny.MoveManually(new Vector2(1, 0));
    }
}
