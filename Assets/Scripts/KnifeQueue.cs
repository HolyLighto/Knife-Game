using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeQueue : MonoBehaviour
{
    Queue<Knife> _queue = new Queue<Knife>();
    public Knife Knife;
    [SerializeField]private int _queueMax = 6;
    void Start()
    {
        //for(int i = 0; i < _queueMax; i++)
        //{
        //    _queue.Enqueue(Instantiate(Knife, transform.position, Quaternion.identity));
        //}
    }

    // Update is called once per frame
    void Update()
    {
        if(_queue.Count == 0 && _queueMax > 0)
        {
            _queue.Enqueue(Instantiate(Knife, transform.position, Quaternion.identity));
            _queueMax--;
        }

        if(Input.GetMouseButtonDown(0))
        {
            Knife knife = _queue.Dequeue();
            knife.EnableBoxCollider();
            knife.Throw();
        }
    }
}
