using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.Serialization;

public class PlaneBorder : MonoBehaviour
{
    [SerializeField] 
    private float _positionX;
    
    [SerializeField] 
    private float _positionZ;
    
    private void Update()
    {
        if (transform.position.z >= _positionZ || transform.position.z <= - _positionZ)
        {
            var pos = transform.position;
            var z = pos.z > 0? -pos.z: Mathf.Abs(pos.z);

            transform.position = new Vector3(pos.x, pos.y, z);
        }

        if (transform.position.x >= _positionX  || transform.position.x <= - _positionX)
        {
            var pos = transform.position;
            var x = pos.x > 0? -pos.x: Mathf.Abs(pos.x);

            transform.position = new Vector3(x, pos.y, pos.z);
        }
    }
}
