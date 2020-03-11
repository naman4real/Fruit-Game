using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particleEffectScript : MonoBehaviour
{
    // Start is called before the first frame update
    public ParticleSystem ps;
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        ps.Play();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("fruits"))
        {
            Instantiate(ps,collision.collider.transform.position,Quaternion.Euler(-90f,0,0));
            //ps.transform.position = collision.collider.transform.position;
            ps.Play();
            collision.gameObject.GetComponent<Rigidbody>().isKinematic = true;

        }

    }
}
