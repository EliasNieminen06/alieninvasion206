using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootingHandler : MonoBehaviour
{
    public int gunDamage;
    public int weaponRange;
    public float fireRate;
    public Transform gunEnd;
    public GameObject player;
    private WaitForSeconds shotDuration;
    private LineRenderer bulletTrail;
    private float nextFire;
    private int damage;

    void Start()
    {
        gunDamage = 1;
        fireRate = 0.25f;
        weaponRange = 20;
        shotDuration = new WaitForSeconds(0.07f);

        bulletTrail = GetComponent<LineRenderer>();
        player = this.gameObject;
        damage = 1;

    }
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Vector3 endPos = gunEnd.transform.position + player.transform.forward * weaponRange;
            RaycastHit hit;
            bulletTrail.SetPosition(0, gunEnd.position);

            if (Physics.Raycast(gunEnd.transform.position, gunEnd.transform.forward, out hit, weaponRange))
            {
                bulletTrail.SetPosition(1, hit.point);

                if (hit.transform.gameObject.tag == "Enemy")
                {
                    // damage the enemy
                }

            }
            else
            {
                bulletTrail.SetPosition(1, endPos);
            }
            StartCoroutine(ShotEffect());

        }
    }

    private IEnumerator ShotEffect()
    {
        bulletTrail.enabled = true;

        yield return shotDuration;

        bulletTrail.enabled = false;
    }
}