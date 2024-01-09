using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Bunny Bunny;
    public Transform Camera;
    public bool isMoving = false;
    private float speed;
    private float amountToMove;
    private float startTime;
    private Vector3 startPosition;
    private Vector3 endPosition;

    void Update()
    {
        speed = GameplayParameters.CameraMoveSpeed;
        amountToMove = GameplayParameters.CameraMoveAmount;

        if (isMoving)
            MoveCameraSmoothly();
    }

    public void StartMoving()
    {
        isMoving = true;
        startTime = Time.time;
        RecordStartAndEndPoints();
    }

    private void MoveCameraSmoothly()
    {
        float distToMove = (Time.time - startTime) * speed;
        float fractionMoved = distToMove / amountToMove;

        Camera.position = Vector3.Lerp(startPosition, endPosition, fractionMoved);

        if (fractionMoved >= 1f)
            isMoving = false;
    }

    private void RecordStartAndEndPoints()
    {
        startPosition = Camera.position;
        endPosition = new Vector3(Camera.position.x,
            Camera.position.y + amountToMove,
            Camera.position.z);
    }

    public void ResetCameraPostion()
    {
        Camera.position = startPosition;
    }
}
