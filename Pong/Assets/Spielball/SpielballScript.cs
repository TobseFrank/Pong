using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpielballScript : MonoBehaviour
{
  
    // public member eines Scripts können bequem
    // im Unity Editor gesetzt und auch während
    // das Spiel getestet wird verändert werden.
  
    public float Geschwindigkeit;
    public float Beschleunigung;

    public bool nachRechts = true;

    float aktuelleGeschwindigkeit =0;
    Vector3 richtung = Vector3.zero;

    void Start()
    {
    }

    void Update()
    {
            if (aktuelleGeschwindigkeit < Geschwindigkeit)
            {
                aktuelleGeschwindigkeit += Beschleunigung * Time.deltaTime;
            }
            
            BallBewegen();
            this.transform.position += richtung * aktuelleGeschwindigkeit * Time.deltaTime;
    }

    private void BallBewegen()
    {
        float x = 0f;
        float z = 0f;
      
        if (nachRechts)
        {
            x++;
        }
        else {
            x--;
        }
        richtung = new Vector3(x, 0f, z);
    }

    public void RichtungWechseln()
    {
        if (nachRechts)
        {
            nachRechts = false;
        } 
        else {
            nachRechts = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Eine Kollision");
        RichtungWechseln();
    }
}
