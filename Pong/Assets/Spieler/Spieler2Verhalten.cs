using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spieler2Verhalten : MonoBehaviour
{
    Vector3 richtung = Vector3.zero;
    float aktuelleGeschwindigkeit = 2f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow)){
            float z = 0f;
            z++;
            this.gameObject.transform.position += new Vector3(0f, 0f, z)*aktuelleGeschwindigkeit*Time.deltaTime;
        } else  if (Input.GetKey(KeyCode.DownArrow)){
            float z = 0f;
            z--;
            this.gameObject.transform.position += new Vector3(0f, 0f, z)*aktuelleGeschwindigkeit*Time.deltaTime;    
        }
    }
}
