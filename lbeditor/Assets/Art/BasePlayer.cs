using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePlayer : MonoBehaviour
{
    public int live = 100;
    public GameObject dieParticle;
    private void Update()
    {
        if(live <= 0)
        {
            Destroy(gameObject);
            //PARTICLE:
            GameObject par = Instantiate(dieParticle, transform.position, dieParticle.transform.rotation);
            Destroy(par, 3.0f);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            live -= 10;
        }
    }
}
