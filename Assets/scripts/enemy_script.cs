using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_script : MonoBehaviour
{
    public float moveSpeed = 3.0f;  
    public enemy_spawner_script enemy_spawner;
    private Transform player;
    private bool isAlive = true;

    // Start is called before the first frame update
    void Start()
    {
        enemy_spawner = GameObject.FindGameObjectWithTag("Enemy_Manager").GetComponent<enemy_spawner_script>();
        player = GameObject.FindGameObjectWithTag("Player").transform;

        ApplyRandomColor();
    }

    // Update is called once per frame
    void Update()
    {
        if (isAlive && player != null)
        {
            Vector3 direction = (player.position - transform.position).normalized;
            transform.position += direction * moveSpeed * Time.deltaTime;
        }

    }

    public void Get_Killed()
    {
        isAlive = false;
        enemy_spawner.onEnemyKilled();

        Destroy(gameObject);

    }

    void ApplyRandomColor()
    {
        Renderer enemy_renderer = GetComponent<Renderer>();
        float r = Random.Range(0.0f, 1f);
        float g = Random.Range(0.0f, 1f);
        float b = Random.Range(0.0f, 1f);
        Color randomColor = new Color(r,g,b);
        enemy_renderer.material.color = randomColor;
    }

}
