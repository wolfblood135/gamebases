using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using Random = UnityEngine.Random;

public class hital : MonoBehaviour
{
    public float Health = 100;

    public GameObject hitxtts;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Health <= 0)
        {
            Destroy(this.gameObject,.2F);
        }
    }

    public void hasarver(float a)
    {
        GameObject res = Instantiate(hitxtts);
        res.transform.position = transform.position;
        res.transform.GetChild(0).GetComponent<hittxt>().hpex = Convert.ToInt32(a);
        Destroy(res,2F);
        Health -= a;
        Time.timeScale = Random.Range(1,1);
        GetComponent<SpriteRenderer>().color = Color.red;
        Invoke("geribeyaz",.1F);
    }

    private  void geribeyaz()
    {
        
        Time.timeScale = 1F;
        GetComponent<SpriteRenderer>().color = Color.white;
        
    }
}
