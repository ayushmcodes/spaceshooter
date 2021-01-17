using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerscript : MonoBehaviour
{
    [SerializeField] float health = 1000f;
    [Header("Player Movement")]
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float xpadding = 1f;
    [SerializeField] float ypadding = 5f;
    [Header("Projectile")]
    [SerializeField] GameObject laserprefab;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float projectileFiringPeriod = 0.1f;
    Vector2 initial_pos;
    // Start is called before the first frame update
    float xMin, xMax, yMin, yMax;
    Coroutine firecoroutine;
    void Start()
    {
        SetUpMoveBoundaries();
    }
    private void SetUpMoveBoundaries()
    {
        Camera gameCamera = Camera.main;
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + xpadding;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - xpadding;
        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + xpadding;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - ypadding;
        Debug.Log("xMin is " + xMin);
        Debug.Log("xMax is " + xMax);
    }
    // Update is called once per frame

    void Update()
    {
        Move();
        Fire();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        damagedealer damage = other.gameObject.GetComponent<damagedealer>();
        health = health - damage.GetDamage();
        if (health <= 0)
            Destroy(gameObject);
    }
    private void Fire()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            firecoroutine = StartCoroutine(FireContinously());
        }
        if(Input.GetButtonUp("Fire1"))
        {
            StopCoroutine(firecoroutine);
        }
    }
    IEnumerator FireContinously()
    {
        while (true)
        {
            GameObject laser = Instantiate(laserprefab, transform.position, Quaternion.identity) as GameObject;
            laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, projectileSpeed);
            yield return new WaitForSeconds(projectileFiringPeriod);
        }
    }
    private void Move()
    {
        float deltaX = Input.GetAxis("Mouse X") * Time.deltaTime * moveSpeed;
        
        float newXPos = Mathf.Clamp(transform.position.x + deltaX, xMin, xMax);
        
        transform.position = new Vector2(newXPos,transform.position.y);
    }
}
