using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform target;
    public int moveSpeed;
    public int rotationSpeed;

    private Transform myTransform;

    public Animator anim;

    private void Awake()
    {
        myTransform = transform;
    }

    // Start is called before the first frame update
    void Start()
    {
        GameObject go = GameObject.FindGameObjectWithTag("Player");
        target = go.transform;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawLine(target.position, myTransform.position, Color.clear);

        //Look
        myTransform.rotation = Quaternion.Slerp(myTransform.rotation, Quaternion.LookRotation(target.position - myTransform.position), rotationSpeed * Time.deltaTime);

        //Move

        myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;
        Attack();
    
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
                anim.SetTrigger("Attack");
            }

          /*  else
            {
                Debug.Log("Attack missed - Wrong direction");
            }*/

        }

       /* else
        {
            Debug.Log("Attack missed - Too far away");
        }*/
    }
}
