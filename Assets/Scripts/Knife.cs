﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Knife : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private BoxCollider _boxCollider;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _boxCollider = GetComponent<BoxCollider>();
        _boxCollider.enabled = false;
        
    }

    public void EnableBoxCollider()
    {
        _boxCollider.enabled = true;
    }
    public void Throw()
    {
        _rigidbody.AddForce(Vector3.up * 30, ForceMode.Impulse);
        Debug.Log("throw");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wood"))
        {
            gameObject.transform.SetParent(collision.transform);
        }
        if(collision.gameObject.CompareTag("Knife"))
        {
            SceneManager.LoadScene(0);
        }
    }
}
