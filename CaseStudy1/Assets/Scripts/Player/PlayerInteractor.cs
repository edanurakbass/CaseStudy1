using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(Rigidbody))]
public class PlayerInteractor : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Collectable collectable))
        {
            collectable.Collect();
            Destroy(collectable.gameObject);
        }
    }
}
