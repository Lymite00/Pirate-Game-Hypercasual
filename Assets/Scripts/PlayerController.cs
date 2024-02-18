using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    public float moveSpeed;
    public float sideLimit;
    public float forwardSpeed;

    private Vector2 touchStartPosition = Vector2.zero;
    private bool isTouching = false;
    private float moveHorizontal = 0f;

    private void Awake()
    {
        instance = this;
    }

    private void FixedUpdate()
    {
        if (isTouching)
        {
            float dragDistance = Input.touches[0].position.x - touchStartPosition.x;
            moveHorizontal = Mathf.Clamp(dragDistance / Screen.width * 2f, -1f, 1f);
        }
        else
        {
            moveHorizontal = Input.GetAxisRaw("Horizontal");
        }

        Vector3 movement = new Vector3(moveHorizontal * moveSpeed * Time.fixedDeltaTime, 0f, forwardSpeed * Time.fixedDeltaTime);
        Vector3 position = transform.position + movement;
        position.x = Mathf.Clamp(position.x, -sideLimit, sideLimit);
        transform.position = position;
    }

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                touchStartPosition = touch.position;
                isTouching = true;
            }
            else if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
            {
                isTouching = false;
            }
        }
    }
}