using System;
using UnityEngine;

public class BulletMove : MonoBehaviour
{

    [SerializeField] private float maxDist = 30f;
    [SerializeField] private float _speed = 10f;
    Vector3 initPos;
    
    private void OnEnable()
    {
        initPos = transform.position;
    }

    void Update()
    {
        transform.Translate(Vector3.forward * _speed * Time.deltaTime, Space.Self);
        if (Vector3.Distance(initPos, transform.position) >= maxDist)
        {
            this.gameObject.SetActive(false);
        }
    }
    
}
