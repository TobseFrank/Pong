using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spieler1Verhalten : MonoBehaviour
{
    Vector3 richtung = Vector3.zero;

    [SerializeField]
    float speed;

    float aktuelleGeschwindigkeit = 2f;

    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Transform>().position = new Vector3(-4.5f, 0.5f, 0);

        //oder 

        transform.position = new Vector3(-4.5f, 0.5f, 0);
    }

    // Update is called once per frame
    void Update()
    {

        //möglichkeiten
        while (false)
        {
            //transform.position = transform.position + new Vector3(0.01f, 0, 0);

            //Input.GetKeyDown(KeyCode.W) nur beim ersten Frame wenn geklickt wird
            //Input.GetKeyUp(KeyCode.W) nur beim letzten Frame wenn der Button logeslassen wird
            //Input.GetKey(KeyCode.W) Jedes Frame, solange der Button betätigt ist

            //float dir = Input.GetAxis("Horizontal"); bezieht sich dann auf den Edit->Preferences->InputManager
            //transform.position += new Vector3(dir*speed ,0 ,0);
            //transform.position += new Vector3(dir*speed+Time.deltaTiem ,0 ,0); Tume.deltaTime für FrameUnabhängigkeit!
        }





        if (Input.GetKey(KeyCode.W)){
            float z = 0f;
            z++;
            this.gameObject.transform.position += new Vector3(0f, 0f, z)*aktuelleGeschwindigkeit*Time.deltaTime;
        } else if (Input.GetKey(KeyCode.S)){
            float z = 0f;
            z--;
            this.gameObject.transform.position += new Vector3(0f, 0f, z)*aktuelleGeschwindigkeit*Time.deltaTime;
        }
    }
}
