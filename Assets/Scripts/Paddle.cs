using System;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    private float horizontal;
    private float vertical;
    private float clampFactor = 2.87f;
    private float interpolateConst = 0.8f;

    private void Update()
    {
        MoveHorizontal();
    }

    /*VERTICAL MOVEMENT
    private void MoveVertical()
    {
        vertical = Input.GetAxisRaw("Vertical");
        float coefficent = 10;

        Vector3 tempY = transform.localPosition;
        tempY.y += vertical * Time.deltaTime * coefficent;
        tempY.y = Mathf.Clamp(tempY.y, -6, -5);
        transform.localPosition = Vector3.Lerp(transform.localPosition, tempY, interpolateConst);
    }
    */

    private void MoveHorizontal()
    {
        horizontal = InputPanel.instance.horizontal;
        float coefficent = 400;

//#if UNITY_EDITOR
//        horizontal = Input.GetAxisRaw("Horizontal");
//        coefficent = 10;
//#endif

        Vector3 tempX = transform.localPosition;
        tempX.x += horizontal * Time.deltaTime * coefficent;
        tempX.x = Mathf.Clamp(tempX.x, -clampFactor, clampFactor);
        transform.localPosition = Vector3.Lerp(transform.localPosition, tempX, interpolateConst);
    }
}