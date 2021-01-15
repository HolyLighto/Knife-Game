using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Wood : MonoBehaviour
{
    [SerializeField] private float _radius;
    [SerializeField] private float _power;
    private Rigidbody[] _rb;
    [SerializeField]private Transform _explosionPosition;
    private bool _isGameEnded = false;
    [SerializeField]private int ScoreToFinish = 5;
    private LayerMask _mask;


    private void Update()
    {
        if(!_isGameEnded) transform.rotation *= Quaternion.Euler(0, 2, 0);
    }

    private void Start()
    {
        _explosionPosition = transform;
        _rb = GetComponentsInChildren<Rigidbody>();
        _mask = LayerMask.NameToLayer("Wood");
    }

    private void EndGame()
    {
        _isGameEnded = !_isGameEnded;
        foreach (var a in _rb)
        {
            a.isKinematic = false;
            a.useGravity = true;
        }
        var b = FindObjectsOfType<Knife>();
        foreach(var a in b)
        {
            a.EnableGravity();
        }
        Collider[] colliders = Physics.OverlapSphere(_explosionPosition.position, _radius);
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            //if (rb != null) rb.AddExplosionForce(_power, _explosionPosition.position, _radius, 3.0f);
            if (rb != null) rb.AddForce((hit.transform.position - _explosionPosition.position) * _power, ForceMode.Impulse);
        }
        Invoke("ReloadScene", 5);
    }

    public void MinusScore()
    {
        if (ScoreToFinish > 0) ScoreToFinish--;
        if (ScoreToFinish <= 0) EndGame();
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
