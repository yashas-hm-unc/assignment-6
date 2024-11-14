using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonSwordScript : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            enemy_script enemy = collision.gameObject.GetComponent<enemy_script>();
            if(enemy != null)
            {
                enemy.Get_Killed();
            }

        }
    }

}
