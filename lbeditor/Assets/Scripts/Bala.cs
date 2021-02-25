using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    Rigidbody body;
    public Vector3 initForce;
    private void Start()
    {
        body = GetComponent<Rigidbody>();
        body.AddForce(initForce * 10.0f, ForceMode.Impulse);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyStats>().live -= 50;
            Destroy(gameObject);
        }
    }
}
