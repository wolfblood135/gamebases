using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stamppass : MonoBehaviour
{
public GameObject pass;
public Vector3 firstpos;

private void Start() {
  firstpos = transform.position;
}
public void OnMouseDown() {
  
  GetComponent<AudioSource>().Play();
  StartCoroutine("bas");
  
}
IEnumerator bas(){
  float y = transform.position.y;
  for(int i=0;i<10;i++){
    yield return new WaitForSeconds(0.03F);
    transform.position = new Vector3(transform.position.x,y-0.8F,transform.position.z);
  }
Instantiate(pass,transform.position,transform.rotation);
y = transform.position.y;
  for(int i=0;i<10;i++){
    yield return new WaitForSeconds(0.03F);
    transform.position = new Vector3(transform.position.x,y+0.8F,transform.position.z);
  }
  transform.position = firstpos;
  
}
}

