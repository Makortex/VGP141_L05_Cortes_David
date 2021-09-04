using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform target;
    public GameObject EnemyBullet;
    public Transform firePoint;

    public GameObject observer;
    private Observer obs;


    public float time;
    public float bulletForce = 20f;
    public float moveSpeed = 0.2f;
    public bool angry;

    private void Start()
    {
        obs = observer.GetComponent<Observer>();
    }
    // Update is called once per frame
    void Update()
    {
        if (angry)
        { 
            RotateTowards(target.position);
            Move();
        }
        //CD
        time += Time.deltaTime;
        if (time >= 4)
        {
            time = 0;
            if (angry)
            {
                Shoot();
            }
        }
    }
    void RotateTowards(Vector2 target)
    {
        var offset =-90f;
        Vector2 direction = target - (Vector2)transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(Vector3.forward * (angle + offset));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PlayerBullet")
        {
            //angry = true;
            obs.notified = true;
        }
    }
    void Shoot()
    {
        GameObject bullet = Instantiate(EnemyBullet, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }

    void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, moveSpeed * Time.deltaTime);
    }

}
