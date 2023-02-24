using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScaleChange : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Sphere"))
        {
            transform.localScale += new Vector3(.2f, .2f, .2f);
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Cylinder"))
        {
            transform.localScale -= new Vector3(.2f, .2f, .2f);
            Destroy(other.gameObject);
            //Playera 20 puan ekle
        }
        else if (other.CompareTag("Cube"))
        {
            Destroy(other.gameObject);
            // playera 5 puan ekle
        }
    }
}
