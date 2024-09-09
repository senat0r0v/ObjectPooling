using System;
using System.Collections;
using UnityEngine;

public class BulletMove : MonoBehaviour
{

    [SerializeField] private float maxDist = 30f;
    [SerializeField] private float _speed = 2.5f;
    Transform myTransform;
    Vector3 initPos;

    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        myTransform = transform;
    }

    private void OnEnable()
    {
        initPos = transform.position;
        if (!myTransform)
            myTransform = transform;
        StartCoroutine(Despawn());
    }

    void FixedUpdate()
    {
        rb.MovePosition(_speed * myTransform.forward + myTransform.position);
    }
    
    IEnumerator Despawn ()
    {
        yield return new WaitUntil(() => Vector3.Distance(initPos, myTransform.position) >= maxDist);
        gameObject.SetActive(false);
        BulletPooler.Instance.poolDictionary["Bullet"].Enqueue(gameObject);
    }
}
