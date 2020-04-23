using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HayController : MonoBehaviour
{
    public float speed;
    public float left_limit;
    public float right_limit;
    public GameObject hay_prefab;
    public Transform haySpawnpoint;
    public float shootInterval;
    private float shootTimer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal_input = Input.GetAxisRaw("Horizontal");

        if (horizontal_input < 0 && transform.position.x > left_limit) // 1
        {
            transform.Translate(transform.right * -speed * Time.deltaTime);
        }
        else if (horizontal_input > 0 && transform.position.x < right_limit) // 2
        {
            transform.Translate(transform.right * speed * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            ShootHay();
        }

        UpdateShooting();
    }

    private void UpdateShooting()
    {
        shootTimer -= Time.deltaTime;
        if (shootTimer <= 0 && Input.GetKey(KeyCode.Space))
        {
            shootTimer = shootInterval;
            ShootHay();
        }
    }


    private void ShootHay()
    {
        Instantiate(hay_prefab, haySpawnpoint.position, Quaternion.identity);
    }


}
