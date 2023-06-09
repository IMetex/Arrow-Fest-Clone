using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject arrowPrefabs;

    [SerializeField] private float xSpeed;
    public float forwardSpeed;
    private float touchX = 0;
    private float limitX = 2;
    private float newXValue;
    //private bool isMoving;

    void Update()
    {
        SwipeCheck();
        Debug.Log(transform.childCount);

    }
    void SwipeCheck()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            touchX = Input.GetTouch(0).deltaPosition.x / Screen.width;
        }
        else if (Input.GetMouseButton(0))
        {
            touchX = Input.GetAxis("Mouse X");
        }
        else
        {
            touchX = 0;
        }

        newXValue = transform.position.x + xSpeed * touchX * Time.deltaTime;
        newXValue = Mathf.Clamp(newXValue, -limitX, limitX);

        Vector3 newPosition = new Vector3(newXValue, transform.position.y, transform.position.z + forwardSpeed * Time.deltaTime);

        transform.position = newPosition;

    }
}
