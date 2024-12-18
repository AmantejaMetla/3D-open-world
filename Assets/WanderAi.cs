using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderAi : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float rotSpeed = 100f;

    private bool isWandering = false;
    private bool isRotatingLeft = false;
    private bool isRotatingRight = false;
    private bool isWalking = false;

    void Update()
    {
        if (!isWandering)
        {
            StartCoroutine(Wander());
        }

        if (isRotatingRight)
        {
            transform.Rotate(Vector3.up * Time.deltaTime * rotSpeed);
        }
        else if (isRotatingLeft)
        {
            transform.Rotate(Vector3.up * Time.deltaTime * -rotSpeed);
        }

        if (isWalking)
        {
            // Move forward while the walking animation plays by default
            transform.position += transform.forward * moveSpeed * Time.deltaTime;
        }
    }

    IEnumerator Wander()
    {
        int rotTime = Random.Range(1, 3);
        int rotateWait = Random.Range(1, 4);
        int rotateLorR = Random.Range(1, 3);
        int walkWait = Random.Range(1, 5);
        int walkTime = Random.Range(1, 6);

        isWandering = true;

        yield return new WaitForSeconds(walkWait);
        isWalking = true; // Start walking
        yield return new WaitForSeconds(walkTime);
        isWalking = false; // Stop walking

        yield return new WaitForSeconds(rotateWait);
        if (rotateLorR == 1)
        {
            isRotatingRight = true;
            yield return new WaitForSeconds(rotTime);
            isRotatingRight = false;
        }
        else if (rotateLorR == 2)
        {
            isRotatingLeft = true;
            yield return new WaitForSeconds(rotTime);
            isRotatingLeft = false;
        }

        isWandering = false;
    }
}
