using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    float moveSpeedHorizontal;
    float moveSpeedVertical;
    string moveDirection = "right";

    public int framesBetweenMoves;
    public int wineMeter = 3;

    // timer is solely here for debugging purposes. Allows me to slow down the gameplay to observe interactions. Always leave at 0 unless debugging
    // and control the speed of the tractor with the 'framesBetweenMoves' variable.
    public int timer;
    int localTimer;

    int tileCount;

    public GameObject tile1;
    public GameObject tile2;
    public GameObject tile3;
    float leftRightSpace;
    float upDownSpace;

    // Use this for initialization
    void Start()
    {
        leftRightSpace = Mathf.Abs(tile1.transform.position.x) - Mathf.Abs(tile2.transform.position.x);
        upDownSpace = Mathf.Abs(tile1.transform.position.y) - Mathf.Abs(tile3.transform.position.y);

        localTimer = timer;

        tileCount = GameObject.FindGameObjectsWithTag("tile").Length;
        print(tileCount);
    }

    // Update is called once per frame
    void Update()
    {

        moveSpeedHorizontal = Input.GetAxisRaw("Horizontal");
        moveSpeedVertical = Input.GetAxisRaw("Vertical");
        if (moveSpeedVertical == 1) { moveDirection = "up"; }
        if (moveSpeedVertical == -1) { moveDirection = "down"; }
        if (moveSpeedHorizontal == 1) { moveDirection = "right"; }
        if (moveSpeedHorizontal == -1) { moveDirection = "left"; }


        if (localTimer == 0)
        {
            switch (moveDirection)
            {
                case "right":
                    gameObject.transform.position = (new Vector3((gameObject.transform.position.x + leftRightSpace / framesBetweenMoves), gameObject.transform.position.y, gameObject.transform.position.z));
                    break;

                case "left":
                    gameObject.transform.position = (new Vector3((gameObject.transform.position.x - leftRightSpace / framesBetweenMoves), gameObject.transform.position.y, gameObject.transform.position.z));
                    break;

                case "down":
                    gameObject.transform.position = (new Vector3(gameObject.transform.position.x, (gameObject.transform.position.y - leftRightSpace / framesBetweenMoves), gameObject.transform.position.z));
                    break;

                case "up":
                    gameObject.transform.position = (new Vector3(gameObject.transform.position.x, (gameObject.transform.position.y + leftRightSpace / framesBetweenMoves), gameObject.transform.position.z));
                    break;

                default:
                    print("Something is broken here hehe");
                    break;
            }
            localTimer = timer;
        }
        else
        {
            localTimer = localTimer - 1;
        }

    }

    private void consumeWine()
    {
        if (framesBetweenMoves - wineMeter > 0)
        {
            framesBetweenMoves -= wineMeter;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        print("collision");
        if (collision.gameObject.tag == "wine")
        {
            collision.gameObject.SetActive(false);
            consumeWine();
            tileCount--;

            if (tileCount == 0)
            {
                print("Game Over!");
                gameObject.SetActive(false);//game over
            }
        }

        if (collision.gameObject.tag == "grass")
        {
            collision.gameObject.SetActive(false);
            tileCount--;

            if (tileCount == 0)
            {
                print("Game over!");
                gameObject.SetActive(false);//game over
            }
           
        }
    }
}
