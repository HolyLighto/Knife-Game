using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Knife : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private BoxCollider _boxCollider;
    private bool _isScoreTaken = false;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _boxCollider = GetComponent<BoxCollider>();
        _boxCollider.enabled = false;
        Vibration.Init();
        
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

    public void EnableGravity()
    {
        _rigidbody.useGravity = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wood") && _isScoreTaken == false)
        {
            gameObject.transform.SetParent(collision.transform);
            Vibration.Vibrate(100);
            var temp = collision.gameObject.GetComponentInParent<Wood>();
            temp.MinusScore();
            //_rigidbody.isKinematic = true;
            _isScoreTaken = true;
            
        }
        if(collision.gameObject.CompareTag("Knife") && _isScoreTaken == false)
        {
            Vibration.Vibrate();
            SceneManager.LoadScene(0);
        }
    }
}
