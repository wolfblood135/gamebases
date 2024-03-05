using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class kameratakip : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
public Transform TARGET;
public float kamerafarkiise;
public Vector3 farkz;
float farktop;
public GameObject box; 
public float smoothspeed = 0.125f;
public Vector3 offset;

    // Use this for initialization
 
    // Update is called once per frame
    private void Start()
    {
        if (!TARGET)
        {
            TARGET = Camera.main.transform;
        }
    }

    private void FixedUpdate()
    {
        Vector3 desiredpos = TARGET.position +offset;
        Vector3 smoothed = Vector3.Lerp(transform.position, desiredpos,smoothspeed);
        transform.position = smoothed;
    }

    void Update()
    {
     

    
     
    
    
        
    }
    
  public IEnumerable sallan(){
      offset = new Vector3(2,0,0);
      yield return new WaitForSeconds(0.02F);
       offset = new Vector3(2,0,0);

     
  }









}
