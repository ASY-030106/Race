using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        transform.Rotate(Vector3.down * 17 * Time.deltaTime, Space.World);
    }
}
