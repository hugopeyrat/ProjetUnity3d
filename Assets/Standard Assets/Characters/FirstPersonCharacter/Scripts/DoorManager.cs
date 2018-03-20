using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManager : MonoBehaviour {
    private bool is_triggered;
    private int incTrig = 0;
    public GameObject PorteFermee;
    public GameObject PorteOuverte;
    public GameObject PorteAbimee;
    public GameObject PorteCassee;
    private Vector3 actualPlace;
    private Quaternion actualRot;

    void Start () {
        actualPlace = this.transform.position;
        actualRot = this.transform.rotation;
        SwitchPorte("Closed");
    }

    void Update()
    {
        if (GameManager.s_Singleton.ReturnDoor())
        {
            SwitchPorte("Open");
        }
        else if(!GameManager.s_Singleton.ReturnDoor())
        {
           // if()
             SwitchPorte("Closed");
        }
        


      //  if (is_triggered &&)
    }


        void OnTriggerEnter(Collider collisionInfo)
        {
            if(collisionInfo.GetComponent<Collider>().tag == "Detecteur")
            {
                is_triggered = true;
            }

        }

        void OnTriggerExit(Collider collisionInfo)
        {
            if (collisionInfo.GetComponent<Collider>().tag == "Detecteur")
            {
                is_triggered = false;
            }

        }

    void SwitchPorte(string arg)
    {
        switch(arg){
            case "Open":
                PorteFermee.SetActive(false);
                PorteAbimee.SetActive(false);
                PorteCassee.SetActive(false);
                PorteOuverte.SetActive(true);
                break;

            case "Closed":
                PorteFermee.SetActive(true);
                PorteAbimee.SetActive(false);
                PorteCassee.SetActive(false);
                PorteOuverte.SetActive(false);
                break;

            case "UnCoup":
                PorteFermee.SetActive(false);
                PorteAbimee.SetActive(true);
                PorteCassee.SetActive(false);
                PorteOuverte.SetActive(false);
                break;

            case "Detruite":
                PorteFermee.SetActive(false);
                PorteAbimee.SetActive(false);
                PorteCassee.SetActive(true);
                PorteOuverte.SetActive(false);
                break;
        }
    }



    }
