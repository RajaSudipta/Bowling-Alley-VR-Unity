using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour
{
    public Rigidbody rb;
    // public float power;

    // public float speed = 0;
    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody>();
        rb.maxAngularVelocity = 7 * 3;
    }

    // Update is called once per frame
    void Update()
    {

    }


    void OnTriggerEnter(Collider other){
        if(other.gameObject.name=="Sphere"){
            AudioSource source = GetComponent<AudioSource>();
			source.Play();
        }
    }
}
