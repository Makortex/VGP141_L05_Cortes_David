using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyWalk : MonoBehaviour
{
    int RNG;
    public string pathNodeName = "PatrolNode";

    [SerializeField]
    private Transform[] nodes;

    [SerializeField]
    float moveSpeed = 2f;

    int nodeIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        RNG = UnityEngine.Random.Range(1, 9);

        transform.position = nodes[RNG].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {

        if (nodeIndex <= nodes.Length - 1)
        {
            transform.position = Vector2.MoveTowards(transform.position, nodes[RNG].transform.position, moveSpeed * Time.deltaTime);

            //transform.position = Vector2.MoveTowards(transform.position, nodes[nodeIndex].transform.position, moveSpeed * Time.deltaTime);

            if (transform.position == nodes[RNG].transform.position)
            {
                RNG = UnityEngine.Random.Range(1, 9);
                nodeIndex = RNG;
                Debug.Log(RNG);

            }
        }

    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            RNG = 0;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            RNG = UnityEngine.Random.Range(1, 9);

        }
    }
}
