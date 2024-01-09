using UnityEngine;

public class Bunny : MonoBehaviour
{
    public SpriteRenderer BunnySpriteRenderer;
    public Game Game;
    private bool isFacingUp = true;
    private Vector3 startPosition;

    void Start()
    {
        startPosition = this.gameObject.transform.position;
    }
    void Update()
    {
        KeepOnScreen();
    }
    public void Reset()
    {
        this.gameObject.transform.position = startPosition;
    }
    public void MoveManually(Vector2 direction)
    {
        Vector3 amountToMove = CalculateAmountToMove(direction);
        BunnySpriteRenderer.transform.Translate(amountToMove, Space.World);
        FaceCorrectDirection(direction);
        KeepOnScreen();
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Obstacle")
            Game.LoseBunny();
        else
            Game.GoToNextLevel();
    }

    private Vector3 CalculateAmountToMove(Vector2 direction)
    {
        float amountX = direction.x * GameplayParameters.BunnyMoveAmount;
        float amountY = direction.y * GameplayParameters.BunnyMoveAmount;

        return new Vector3(amountX, amountY, 0);
    }

    private void FaceCorrectDirection(Vector2 direction)
    {
        // if hopping right
        if (direction.x == 1)
        {
            if (isFacingUp == true)
                RotateLeftFacingUp();
            else
                RotateLeftFacingDown();
        }
            
        // if hopping left
        else if (direction.x == -1)
        {
            if (isFacingUp == true)
                RotateRightFacingUp();
            else
                RotateRightFacingDown();
        }

        // if hopping up
        else if (direction.y == 1)
        {
            isFacingUp = true;
            BunnySpriteRenderer.flipY = false;
            BunnySpriteRenderer.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }

        // if hopping down
        else if (direction.y == -1)
        {
            isFacingUp = false;
            BunnySpriteRenderer.flipY = true;
            BunnySpriteRenderer.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }

    }

    private void RotateRightFacingUp()
    {
        BunnySpriteRenderer.transform.rotation = Quaternion.Euler(0f, 0f, 90f);
    }

    private void RotateLeftFacingUp()
    {
        BunnySpriteRenderer.transform.rotation = Quaternion.Euler(0f, 0f, -90f);
    }

    private void RotateRightFacingDown()
    {
        BunnySpriteRenderer.transform.rotation = Quaternion.Euler(0f, 0f, -90f);
    }

    private void RotateLeftFacingDown()
    {
        BunnySpriteRenderer.transform.rotation = Quaternion.Euler(0f, 0f, 90f);
    }

    private void KeepOnScreen()
    {
        BunnySpriteRenderer.transform.position = SpriteTools.ConstrainToScreen(BunnySpriteRenderer);
    }
}
