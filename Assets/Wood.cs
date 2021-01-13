using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wood : MonoBehaviour
{

    private void Update()
    {
        transform.rotation *= Quaternion.Euler(0, 2, 0);
    }
}
