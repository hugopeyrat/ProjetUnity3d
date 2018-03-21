using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class ReverseDetect : MonoBehaviour {
    private bool isTriggered = false;
    private bool buttonCheck = false;
    public bool StartDoor_isOpen = false;
    private bool Is_Active = false;
    private Vector3 actualPlace;
    private Quaternion actualRot;
    public GameObject ObjetDetruit;
    public GameObject MainObj;
    
    public GameObject PorteDebut;
    private int ObjectCount;
    

    // Use this for initialization
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.E) && isTriggered == true && this.tag == "Collectible")
        {

            Debug.Log("interact ok");
            ObjectCount++;
            MainObj.GetComponent<Animator>().Play("Robot_Anim_Interact1");
            if(ObjectCount == 1)
            {
                Destroy(PorteDebut);
            }
            GameManager.s_Singleton.IncrementeObjet();
            SetInteract(false);
        }

        if ((Input.GetKeyDown(KeyCode.E) && (isTriggered == true)) && ((this.tag == "SecBout") && (buttonCheck = false)))
        {
            GameManager.s_Singleton.OpenDoor();

            actualPlace = this.transform.position;
            actualRot = this.transform.rotation;
            Destruction();
            Instantiate(ObjetDetruit, actualPlace, actualRot);
            buttonCheck = true;

            SetInteract(false);
        }

        else if ((Input.GetKeyDown(KeyCode.E) && (isTriggered == true)) && ((this.tag == "SecBout") && (buttonCheck = true)))
        {
            if (GameManager.s_Singleton.ReturnObjet() < 5)
            {
                GameManager.s_Singleton.CloseDoor();
            }

            actualPlace = this.transform.position;
            actualRot = this.transform.rotation;
            Destruction();
            Instantiate(ObjetDetruit, actualPlace, actualRot);
            buttonCheck = false;

            SetInteract(false);
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            MainObj.GetComponent<Animator>().Play("Robot_Animation1");
            if (isTriggered == true && this.tag == "Destructible")
            {
                /*actualPlace = this.transform.position;
                actualRot = this.transform.rotation;

                Instantiate(ObjetDetruit, actualPlace, actualRot);*/
                Destroy(this);
                SetHit(false);
            }
        }


      

 
    }

    void OnTriggerEnter(Collider collisionInfo)
    {



            if (collisionInfo.GetComponent<Collider>().tag == "Detecteur" && (this.tag == "Collectible" || this.tag == "SecBout"))
            {
                SetInteract(true);
            }

            if (collisionInfo.GetComponent<Collider>().tag == "Detecteur" && this.tag == "Destructible")
            {
            Debug.Log("Détecté");
            SetHit(true);
            }

        
        if (collisionInfo.GetComponent<Collider>().tag == "Detecteur" && this.tag == "Trigger")
        {
            Debug.Log("Triggered");
            Is_Active = true;
            MainObj.GetComponent<Animator>().Play("Anim_Regard_Haut");
            
            Destroy(this);

        }
    }

    void OnTriggerExit(Collider collisionInfo)
    {

        if (collisionInfo.GetComponent<Collider>().tag == "Detecteur" && this.tag == "Collectible")
        {
            SetInteract(false);
        }

        if (collisionInfo.GetComponent<Collider>().tag == "Detecteur" && this.tag == "Destructible")
        {
            SetHit(false);
        }
    }


    private void SetInteract(bool arg)
    {
        GameObject.Find("UI/UI_Interact").GetComponent<Image>().enabled = arg;

        isTriggered = arg;
    }

    private void SetHit(bool arg)
    {
        GameObject.Find("UI/UI_Hit").GetComponent<Image>().enabled = arg;
        isTriggered = arg;
    }

    public void Destruction()
    {
        Destroy(this.gameObject);
    }

    public void SetActiveDetect()
    {
        Is_Active = true;
    }
}
