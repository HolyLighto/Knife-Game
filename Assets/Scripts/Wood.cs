using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Wood : MonoBehaviour
{
    [SerializeField] private float _radius;
    [SerializeField] private float _power;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private Transform _explosionPosition;
    private int _scoreToFinish;
    private Rigidbody[] _rb;
    private KnifeQueue _knifeQueue;

    public GameObject Menu;


    private void FixedUpdate()
    {
        if(!GameState.IsGameEnded) transform.rotation *= Quaternion.Euler(0, _rotationSpeed, 0);
    }

    private void Awake()
    {
        GameState.GameStart();
        _knifeQueue = FindObjectOfType<KnifeQueue>();
        _scoreToFinish = _knifeQueue.KnifeCount;
        Time.timeScale = 1f;
        Debug.Log("loaded");
    }

    private void EndGame()
    {
        _rb = GetComponentsInChildren<Rigidbody>();
        Vibration.Vibrate(1000);
        GameState.GameOver();
        ScoreAndStage.AddStage();
        foreach (var a in _rb)
        {
            if(_rb != null) a.isKinematic = false;
            if(_rb != null) a.useGravity = true;
        }
        var b = FindObjectsOfType<Knife>();
        foreach(var a in b)
        {
            a.EnableGravity();
            a.EnableRotation();
        }
        Collider[] colliders = Physics.OverlapSphere(_explosionPosition.position, _radius);
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if (rb != null) rb.AddForce((hit.transform.position - _explosionPosition.position) * _power, ForceMode.Impulse);
            if (rb != null) rb.AddForce(-Vector3.forward * _power, ForceMode.Impulse);
        }
        Invoke("ReloadScene", 2);
    }

    public void MinusScore()
    {
        if (_scoreToFinish > 0) _scoreToFinish--;
        if (_scoreToFinish <= 0) EndGame();
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(1);
    }
}
