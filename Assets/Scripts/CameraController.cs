using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Target for the camera
    public Transform target;

    // References to the background images
    public Transform farBackground, middleBackground;

    // Camera restrictions
    public float minHeight, maxHeight;

    //private float lastXPos;
    private Vector2 lastPos;

    // Start is called before the first frame update
    void Start()
    {
        //lastXPos = transform.position.x;
        lastPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Camera control
        /*transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);

        // Restrictions for vertical camera movement
        float clampedY = Mathf.Clamp(transform.position.y, minHeight, maxHeight);
        transform.position = new Vector3(transform.position.x, clampedY, transform.position.z);*/

        transform.position = new Vector3(target.position.x, Mathf.Clamp(target.position.y, minHeight, maxHeight), transform.position.z);

        // Parallex effect by moving backgrounds at different speeds related to camera
        //float amountToMoveX = transform.position.x - lastXPos;
        Vector2 amountToMove = new Vector2(transform.position.x - lastPos.x, transform.position.y - lastPos.y);

        farBackground.position = farBackground.position + new Vector3(amountToMove.x, amountToMove.y, 0f);
        middleBackground.position += new Vector3(amountToMove.x, amountToMove.y, 0f) * .5f;

        //lastXPos = transform.position.x;
        lastPos = transform.position;
    }
}
