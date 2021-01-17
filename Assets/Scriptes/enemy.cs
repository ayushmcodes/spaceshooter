using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    float shotcounter;
    [SerializeField] int health =300;
    [SerializeField] float mintimebetweenshots = 1f;
    [SerializeField] float maxtimebetweenshots = 2f;
    [SerializeField] GameObject projectile;
    [SerializeField] float projectilespeed=5f;
    [SerializeField] GameObject deathvfx;
    [SerializeField] AudioClip deathsfx;
    [SerializeField] [Range(0,1)] float volumelevel=0.5f;
    // Start is called before the first frame update
    void Start()
    {
        shotcounter = Random.Range(mintimebetweenshots, maxtimebetweenshots);
    }

    // Update is called once per frame
    void Update()
    {
        CountDownAndShoot();
    }

    private void CountDownAndShoot()
    {
        shotcounter -= Time.deltaTime;
        Debug.Log("time.deltatime is " + Time.deltaTime);
        Debug.Log("shotcounter is "+ shotcounter);
        if (shotcounter <= 0f)
        {
            Fire();
            shotcounter = Random.Range(mintimebetweenshots, maxtimebetweenshots);
        }
    }

    private void Fire()
    {
        GameObject laser=Instantiate(
            projectile,
            transform.position,
            Quaternion.identity
            ) as GameObject;
        laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0,-projectilespeed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
        damagedealer a = collision.gameObject.GetComponent<damagedealer>();
        health = health - a.GetDamage();
        if (health <= 0)
        {
            Destroy(gameObject);
            GameObject explosion = Instantiate(deathvfx, transform.position, transform.rotation);
            Destroy(explosion, .3f);
            AudioSource.PlayClipAtPoint(deathsfx, Camera.main.transform.position, volumelevel);

        }
    }
}
