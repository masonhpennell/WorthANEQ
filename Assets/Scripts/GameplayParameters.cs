using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public static class GameplayParameters
{
    public static int SmallFlameTime = 1;
    public static int BigFlameTime = 1;
    public static float FlameSecondsOffScreen = 1;
    public static float FlameSpeedSubtracter = 0.1f;
    public static float BunnyMoveAmount = 0.13f;
    public static int BunnyLives = 10;
    public static int FrameRate = 48;
    public static float CameraMoveSpeed = 0.8f;
    public static int CameraMoveAmount = 18;
    public static float GameSpeedMultiplier = 0.15f;
    public static float GettingReady = 1.5f;
    public static int randomSecondsToPlaceEasySaw = 7;
    public static int randomSecondsToPlaceHardSaw = 4;
    public static Vector3 walkIncrement = new Vector3(1, 0, 0);
    public static float waitToEasyWalkSeconds = 0.6f;
    public static float waitToHardWalkSeconds = 0.2f;
    public static float SawSpeedSubtracter = 0.01f;
}
