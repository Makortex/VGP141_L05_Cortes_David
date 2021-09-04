using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observer : MonoBehaviour
{
    public bool notified;
    public GameObject[] enemies;
    //public GameObject enemy;
    private Enemy ene;

    private void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        if (notified)
        {
            for (int i = 0; i < enemies.Length; i++)
            {
                ene = enemies[i].GetComponent<Enemy>();
                ene.angry = true;
            }
        }
    }
}
