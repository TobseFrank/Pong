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
    public float maximalerWinkel;

    public bool nachRechts = true;
    public bool nachOben = false;
    public bool nachUnten = false;

    bool gameLive;
    float aktuelleGeschwindigkeit;
    float aktuellerWinkel;
    int kollisionen;
    Vector3 richtung = Vector3.zero;

    void Start()
    {
        gameLive = true;
    }

    void Update()
    {
        if (gameLive){
            if (aktuelleGeschwindigkeit < Geschwindigkeit)
            {
                aktuelleGeschwindigkeit += Beschleunigung * Time.deltaTime;
            }
            
            BallBewegen();
            this.transform.position += richtung * aktuelleGeschwindigkeit * Time.deltaTime;
        }
    }

    void BallBewegen()
    {
        float x = 0f;
        float z = 0f;
      
        if (nachRechts){
            x++;
        }
        else {
            x--;
        }

        //Muss genauer aufgelöst werden
        if(aktuellerWinkel== 45.0f){
                z++;
        }
        if (aktuellerWinkel == -45.0f){
                z--;          
        }

        if (nachOben){
            if (z < 0) {
                z*=-1;
            }
        }
        if (nachUnten){
            if (z > 0) {
                z*=-1;
            }
        }
        
        richtung = new Vector3(x, 0f, z);
     }

    void OnCollisionEnter(Collision collision)
    {
        ContactPoint contact = collision.contacts[0];

        GameObject otherObject = contact.otherCollider.gameObject;
        
        Vector3 otherObjectPoint = contact.otherCollider.attachedRigidbody.position;
        Vector3 position = contact.point;

        if (otherObject.name == "Spieler 1" || otherObject.name == "Spieler 2"){
         kollisionen++;
         Debug.Log("Kollisionsnummer"+ kollisionen
         + "\nzwischen Ball und " + otherObject 
         + "\n an Position:" + position 
         + "\nSpieler war auf:" + otherObjectPoint);
        aktuellerWinkel = KollisionsPunktMitSpielerBerechnen(position.z,otherObjectPoint.z);
        }

        if(otherObject.name == "Spieler 1"){
            nachRechts = true;
            nachOben = false;
            nachUnten = false;
        }

        if (otherObject.name == "Spieler 2"){
            nachRechts = false;
            nachOben = false;
            nachUnten = false;
        }

        if(otherObject.name == "Wand Unten"){
            nachOben = true;
            nachUnten = false;
        }

        if(otherObject.name == "Wand Oben"){
            nachOben = false;
            nachUnten = true;
        }
        if(otherObject.name == "Wand von Spieler 1"){
            gameLive = false;
            Debug.Log("Punkt für Spieler 2");
        }
        if(otherObject.name == "Wand von Spieler 2"){
            gameLive = false;
            Debug.Log("Punkt für Spieler 1");
        }

        //Debug.Log(contact.point);  //Postion auf dem Feld der Kollision
        //Debug.Log("An der Stelle: "+ contact.otherCollider.gameObject.transform.position);   //Postion auf dem Feld der Kollision
        
    }

    float KollisionsPunktMitSpielerBerechnen(float zBall, float zSpieler){
        float winkelBerechnungsPosition = zBall - zSpieler;
        Debug.Log("Ball z position: " + zBall 
        +"\n Spieler z position: " + zSpieler
        +"\n Kollision des Balls auf: " + winkelBerechnungsPosition);

        if (winkelBerechnungsPosition > 0.7f){
            return +45.0f;
        }
        
        if (winkelBerechnungsPosition < -0.7f){
            return -45.0f;
        } 

        return 0.0f;
    }
}
