using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    public GameObject target;
    public float attackTimer;
    public float cooldown;

    // Start is called before the first frame update
    void Start()
    {
        attackTimer = 0f;
        cooldown = .3f;
    }

    // Update is called once per frame
    void Update()
    {
        if (attackTimer > 0)
        {
            attackTimer -= Time.deltaTime;
        }
        if (attackTimer < 0)
        {
            attackTimer = 0;
        }
        if (Input.GetKeyUp(KeyCode.F))
        {
            if (attackTimer == 0)
            {
                 Attack();
                this.GetComponent<Animator>().SetTrigger("Attack");
                attackTimer = cooldown;
            }

        }
    }

    private void Attack()
    {
        float distance = Vector3.Distance(target.transform.position, transform.position);
        //Debug.Log(distance);

        Vector3 dir = (target.transform.position - transform.position).normalized;
        float direction = Vector3.Dot(dir, transform.forward);

        if (distance < 2.5)
        {
            if (direction > 0)
            {
                Debug.Log("Attack Possible");

            }

            else
            {
                Debug.Log("Attack missed - Wrong direction");
            }

        }

        else
        {
            Debug.Log("Attack missed - Too far away");
        }
    }

    public void Damage()
    {
        EnemyHealth eh = (EnemyHealth)target.GetComponent("EnemyHealth");
        eh.CurrentHealthAdjustment(-10);
    }
}
