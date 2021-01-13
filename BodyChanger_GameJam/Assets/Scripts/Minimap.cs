using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minimap : MonoBehaviour
{

    public Transform target;
    //public Transform player;

    void Start()
    {
      //  target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void LateUpdate()
    {
        Vector3 newPosition = target.position;
        newPosition.y = transform.position.y;
        transform.position = newPosition;

        transform.rotation = Quaternion.Euler(90f,target.eulerAngles.y,0f);
    }
}
