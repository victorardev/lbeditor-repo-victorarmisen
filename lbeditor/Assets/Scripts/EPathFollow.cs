using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EPathFollow : MonoBehaviour
{
    public int indexPath = 0;
    public GameManager manager;
    float t = 0.0f;
    public float speed;
    private Rigidbody body;

    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("Manager").GetComponent<GameManager>();
        body = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Vector3 desiredVelocity = manager.pointList[indexPath] - transform.position;
        desiredVelocity.Normalize();
        //desiredVelocity *= 0.05f;
        body.velocity = desiredVelocity;

        if (Vector3.Distance(transform.position, manager.pointList[indexPath]) < 0.05f) //If we're using really small sizes, we will have errors in distances. 
        {
            indexPath++;
        }
        if (indexPath >= manager.pointList.ToArray().Length)
        {
            //Destroy(this.gameObject);
            indexPath = 0;
        }
    }
}
