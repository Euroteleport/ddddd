using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemiDeplacement : MonoBehaviour
{
   public float speed;
    public Transform[] waypoints;
    private Transform target;
    private int destPoint = 0;
    
    void Start()
    {
       target = waypoints[0];
    }

    // Update is called once per frame
    void Update()
    {
      Vector3 dir = target.position - target.position;
      transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

      if(Vector3.Distance(transform.position, target.position) < 0.3f)
      {
        destPoint = destPoint + 1 % waypoints.Length;
        target = waypoints[destPoint];
      }
    }
   

    private void OnCollisionEnter2D(Collision2D collision) 
    {
      if(collision.transform.CompareTag("Player"))
      {
        FritzVie1 fritzVie = collision.transform.GetComponent<FritzVie1>();
        fritzVie.TakeDamage(20);
      }
    }
   }
