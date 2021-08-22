using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class poolmanagger : MonoBehaviour
{
    [System.Serializable]
    public class item{
        public string name;
        public GameObject prefab;
        public uint quantity=0;
    }
    class pl2
    {
        public Queue<GameObject> deactivated;
        public List<GameObject> activated;
        public pl2() {
            deactivated = new Queue<GameObject>();
            activated = new List<GameObject>();
        }
        public GameObject Pass2Activate()//nem aktiválja gameobjecket csak átteszi a másik sorba
        {
            if (deactivated.Count>0)
            {
                var temp = deactivated.Dequeue();
                activated.Add(temp);
                return temp;
                //temp.SetActive(true);
            }
                return null;
        }
        public void Deactivate(GameObject obj)
        {
            if(activated.Contains(obj))
            {
                activated.Remove(obj);
                obj.SetActive(false);
                deactivated.Enqueue(obj);
            }
        }

        internal void Clear()
        {
            foreach(GameObject i in activated)
            {
                Destroy(i);
            }
            activated.Clear();
            foreach(GameObject i in deactivated)
            {
                Destroy(i);
            }
            deactivated.Clear();
        }
    }

    public List<item> list;
    Dictionary<string,pl2> pool;

    
    public static poolmanagger POOL;

    private void Awake()
    {
        POOL = this;
    }





    void Start()
    {

        Loadlist();
        
    }


    void Loadlist()
    {
        pool = new Dictionary<string, pl2>();
        foreach (item i in list)
        {
            pl2 PL2 = new pl2();


            for (uint k = 0; k < i.quantity; k++)
            {
                var temp = Instantiate(i.prefab);
                //var temppoolable = temp.GetComponent<Poolable>();
                //temppoolable.Reset();
                temp.SetActive(false);
                PL2.deactivated.Enqueue(temp);
            }
            pool.Add(i.name, PL2);
        }
    }
    void Deletepool()
    {
        foreach(KeyValuePair<string,pl2> i in pool)
        {
            i.Value.Clear();
        }
        pool.Clear();
    }


    public GameObject Spawn(string name,Vector3 pos,Quaternion rot)
    {
        if(pool.ContainsKey(name))
        {
            var temp = pool[name].Pass2Activate();
            if (temp != null)
            {
                var temppoolable = temp.GetComponent<Poolable>();
                if (temppoolable != null)
                    temppoolable.Reset();
                temp.transform.position = pos;
                temp.transform.rotation = rot;
                temp.SetActive(true);
            }
        }
        //object not found
        return null;
    }
    public GameObject Disapear(string name,GameObject obj)
    {
        if (pool.ContainsKey(name))
        {
            pool[name].Deactivate(obj);
        }
        //object not found
        return null;
    }























    // Update is called once per frame
    void Update()
    {
        
    }
}
