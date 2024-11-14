using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class enemy_spawner_script : MonoBehaviour
{
    public GameObject enemy_prefab;
    public score_script score_script;
    public TextMeshProUGUI winText;
    private int enemies_remaining = 5;

    public Vector3 spawnRange = new Vector3(50f, 0f, 50f);

    // Start is called before the first frame update
    void Start()
    {
        score_script = GameObject.FindGameObjectWithTag("Score_manager").GetComponent<score_script>();
        score_script.UpdateEnemyCount(enemies_remaining);

        winText.text = "";

        Debug.Log("just before spawn");
        spawn_enemies();
    }

    // Update is called once per frame
    //void Update()
    //{
        
    //}

    public void onEnemyKilled()
    {
        enemies_remaining -= 1;
        score_script.UpdateEnemyCount(enemies_remaining);

        if (enemies_remaining <= 0)
        {
            winText.text = "You win!!";
        }
    }

    [ContextMenu("spawn")]
    public void spawn_enemies()
    {
        Debug.Log("in spawn enemies");
        for(int i=0; i< enemies_remaining; i++)
        {
            //console.log("in spawn");
            Vector3 spawn_location = new Vector3(
                Random.Range(-spawnRange.x, spawnRange.x),
                0.5f,
                Random.Range(-spawnRange.z, spawnRange.z)
                );

            GameObject enemy = Instantiate(enemy_prefab, spawn_location, Quaternion.identity);
            enemy.tag = "Enemy";

            Rigidbody enemyRigidbody = enemy.GetComponent<Rigidbody>();
            if (enemyRigidbody != null)
            {
                // Freeze rotation on X and Z axes
                enemyRigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
            }

        }
    }

}
