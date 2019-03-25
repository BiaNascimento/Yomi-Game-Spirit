using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataforma : MonoBehaviour
{

    public float fallDelay = 2.0f;
    public float sumir;
    public int flashLength = 5;
    public GameObject plataforma;

    void OnCollisionEnter2D(Collision2D collidedWithThis)
    {
        if (collidedWithThis.gameObject.tag == "Player")
        {
            StartCoroutine(FallAfterDelay());
            StartCoroutine(Destruir());
            

        }
    }

    IEnumerator FallAfterDelay()
    {
        yield return new WaitForSeconds(fallDelay);
        GetComponent<Rigidbody2D>().isKinematic = false;
        
    }

    IEnumerator Destruir()
    {
        {
            yield return new WaitForSeconds(sumir);
            Destroy(plataforma);
        }

   
    }
}