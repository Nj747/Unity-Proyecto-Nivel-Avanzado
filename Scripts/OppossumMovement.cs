using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OppossumMovement : MonoBehaviour {

    public int repeatRate;
    public int beginRate;
    public float velocity;

    int direction = -1;

    private void Awake()
    {
        InvokeRepeating("Flip", beginRate, repeatRate);   
    }

    void Flip()
    {
        direction *= -1;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    private void Update()
    {
        transform.Translate(new Vector3(1,0,0) * velocity * direction * Time.deltaTime);
    }
}
