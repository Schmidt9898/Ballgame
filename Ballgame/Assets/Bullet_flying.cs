using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_flying : MonoBehaviour, Poolable
{
    Vector3 nextpos;
    [Header("Speed of the projectile. u/s")]
    public float velocity = 1f;
    [Header("Layers that can efect the bullet.")]
    public LayerMask hitlayer;
    [Header("Name in the object pool.")]
    public string mypoolname = "bullet0";//make this automatic from a table
    [Header("Damage when hit.")]
    public float damage = 100;
    float t = 0f;
    [Header("Bullet lifetime.")]
    public float lifetime = 3f;

    //Visuals
    //public GameObject hiteffect;
    // sounds, marker, stat change 



    void Start()
    {
 



    }

    // Update is called once per frame
    void Update()
    {
        //Bulet life time
        if (Time.time > t + 3)
        {
            poolmanagger.POOL.Disapear(mypoolname, this.gameObject);
            Debug.Log("time is up.");
        }

        if (check())
        {
            transform.position = nextpos;
            /* var targetrb = hit.collider.GetComponent<Rigidbody>();
             if (targetrb != null)
                 targetrb.AddForce(transform.forward * damage);
             var _shotable = hit.collider.GetComponent<shotable>();
             if (_shotable != null)
                 _shotable.TakeShot(this.gameObject, damage);


             var effect = Instantiate(hiteffect, hit.point, Quaternion.identity);
             Destroy(effect, 0.5f);
            */
             poolmanagger.POOL.Disapear(mypoolname, this.gameObject);
             //Destroy(this.gameObject);

             //Debug.LogError("NEM jó");
            
            Debug.Log("találat");



        }
        else
            transform.position = nextpos;


    }

    RaycastHit hit;
    bool check()
    {
        //nextpos = transform.position + velocity * Time.deltaTime();
        if (Physics.Raycast(transform.position, transform.forward, out hit, velocity * Time.deltaTime, hitlayer))
        {
            nextpos = hit.point;
            return true;
            //todo deal damage and ...
        }
        else
        {
            nextpos = transform.position + transform.forward * velocity * Time.deltaTime;
            return false;
        }

    }
    public void Reset()
    {
        t = Time.time;
    }
}
