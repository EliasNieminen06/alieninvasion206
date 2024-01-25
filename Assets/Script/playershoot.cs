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
    public GameObject camera;
    private WaitForSeconds shotDuration;
    private LineRenderer bulletTrail;
    private float nextFire;
    private int damage;
    [SerializeField] GameManager gameManager;

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
            Vector3 endPos = camera.transform.position + camera.transform.forward * weaponRange;
            RaycastHit hit;
            bulletTrail.SetPosition(0, gunEnd.position);

            if (Physics.Raycast(gunEnd.transform.position, camera.transform.forward, out hit, weaponRange))
            {
                bulletTrail.SetPosition(1, endPos);
                if (hit.transform.gameObject.tag == "Enemy")
                {
                    hit.transform.gameObject.GetComponent<EnemyAI>().Damage();
                    gameManager.score += 47;
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