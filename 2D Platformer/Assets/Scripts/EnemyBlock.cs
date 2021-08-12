using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBlock : MonoBehaviour
{
    public float moveSpeed = 10;
    public Transform endPoint, startPoint;
    private bool isFalling;

    // Start is called before the first frame update
    void Start()
    {
        startPoint.parent = null;
        endPoint.parent = null;
        isFalling = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isFalling)
        {
            transform.position = Vector3.MoveTowards(transform.position, endPoint.position, moveSpeed * Time.deltaTime);
            if(transform.position == endPoint.position)
            {
                isFalling = false;
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, startPoint.position, (moveSpeed / 3) * Time.deltaTime);
            if (transform.position == endPoint.position)
            {
                isFalling = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            isFalling = true;
        }
    }

}
