using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject spawnPos;
    public Transform player;
    AudioSource gunSound;
    float turnSpeed = 1.0f;
    float shootCoolDown = 0;

    Transform myTransform;

    void Start()
    {
        GameObject playerObject = GameObject.Find("Player");
        gunSound = GetComponent<AudioSource>();

        myTransform = this.transform;
        if (playerObject)
        {
            player = playerObject.transform;
            StartCoroutine(StartShoot());
        }
    }

    void ShootBullet()
    {
        BulletPooler.Instance.SpawnFromPool("Bullet", spawnPos.transform.position, spawnPos.transform.rotation);
        gunSound.Play();
    }

    private void Update()
    {
        if (player)
        {
            myTransform.rotation = Quaternion.Slerp(myTransform.rotation,
                                Quaternion.LookRotation(player.position - myTransform.position),
                                turnSpeed * Time.smoothDeltaTime);
        }

    }


    IEnumerator StartShoot()
    {
        while (true)
        {


            ShootBullet();
            shootCoolDown = Random.Range(3, 5);



            yield return new WaitForSeconds(shootCoolDown);
        }
    }
 }

