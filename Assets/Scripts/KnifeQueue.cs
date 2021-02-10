using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeQueue : MonoBehaviour
{
    [SerializeField]private int _queueMax = 6;
    [SerializeField]private float _timeToReload;
    private bool _readyToFire = true;
    private Queue<Knife> _queue = new Queue<Knife>();

    public Knife Knife;
    public int KnifeCount { get => _queueMax; }
    void Awake()
    {
        for (int i = 0; i < _queueMax; i++)
        {
            var temp = Instantiate(Knife, transform.position, Quaternion.identity);
            temp.KnifeInWood();
            temp.SetBoxCollider(false);
            _queue.Enqueue(temp);
        }
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0) && !GameState.IsGameEnded)
        {
            if (_queue.Count > 0 && _readyToFire)
            {
                _readyToFire = false;
                _queueMax--;
                Knife knife = _queue.Dequeue();
                knife.SetBoxCollider(true);
                knife.Throw();
                Invoke("ReadyToFire", _timeToReload);
            }
        }
    }

    private void ReadyToFire()
    {
        _readyToFire = true;
    }
}
