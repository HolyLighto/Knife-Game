using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Count : MonoBehaviour
{
    private Text _text;
    [SerializeField] private KnifeQueue _knifeQueue;

    private void Start()
    {
        _text = GetComponent<Text>();
        _knifeQueue = FindObjectOfType<KnifeQueue>();
    }

    private void Update()
    {
        _text.text = _knifeQueue.KnifeCount.ToString();
    }
}

