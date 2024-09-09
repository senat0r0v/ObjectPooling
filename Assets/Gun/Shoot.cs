﻿using UnityEngine;

public class Shoot : MonoBehaviour 
{
    public GameObject spawnPos;
    public GameObject player;
    AudioSource gunSound;
    float shootCoolDown = 0;

	void Start()
    {
        player = GameObject.Find("Player");
        gunSound = this.GetComponent<AudioSource>();
	}

    void ShootBullet()
    {
        BulletPooler.Instance.SpawnFromPool("Bullet", spawnPos.transform.position, spawnPos.transform.rotation);
        gunSound.Play();
    }

    float turnSpeed = 1.0f;


	void Update() 
    {

        if (player)
        {
            Vector3 direction = player.transform.position - this.transform.position;
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation,
                                Quaternion.LookRotation(direction),
                                turnSpeed * Time.smoothDeltaTime);
            
            if (shootCoolDown <= 0)
            {
                ShootBullet();
                shootCoolDown = Random.Range(3,5);
            }
            
            else
            {
                shootCoolDown -= 0.1f;
            }
        }
	}
}
