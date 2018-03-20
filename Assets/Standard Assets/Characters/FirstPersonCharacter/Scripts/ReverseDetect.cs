using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class ReverseDetect : MonoBehaviour {
    private bool isTriggered = false;
    private bool buttonCheck = false;
    private Vector3 actualPlace;
    private Quaternion actualRot;
    public GameObject ObjetDetruit;
    public GameObject MainObj;


    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isTriggered == true && this.tag == "Collectible")
        {

            MainObj.GetComponent<Animator>().Play("Anim_Regard_Haut");
            Destroy(this.gameObject);
            GameManager.s_Singleton.IncrementeObjet();
            SetInteract(false);
        }

        if ((Input.GetKeyDown(KeyCode.E) && (isTriggered == true)) && ((this.tag == "SecBout") && (buttonCheck = false)))
        {
            //Changer l'objet 
            
            GameManager.s_Singleton.OpenDoor();
            SetInteract(false);
        }

        if ((Input.GetKeyDown(KeyCode.E) && (isTriggered == true)) && ((this.tag == "SecBout") && (buttonCheck = true)))
        {
            if(GameManager.s_Singleton.ReturnObjet() < 5)
            {
                GameManager.s_Singleton.CloseDoor();
            }
            //Changer l'objet
            SetInteract(false);
        }

        if (Input.GetKeyDown(KeyCode.F) && isTriggered == true && this.tag == "Destructible")
        {
            actualPlace = this.transform.position;
            actualRot = this.transform.rotation;
            Destroy(this.gameObject);
            Instantiate(ObjetDetruit, actualPlace, actualRot);
            SetHit(false);
        }
    }

    void OnTriggerEnter(Collider collisionInfo)
    {

        if (collisionInfo.GetComponent<Collider>().tag == "Detecteur" && this.tag == "Collectible")
        {
            SetInteract(true);
        }

        if (collisionInfo.GetComponent<Collider>().tag == "Detecteur" && this.tag == "Destructible")
        {
            SetHit(true);
        }

        if (collisionInfo.GetComponent<Collider>().tag == "Detecteur" && this.tag == "Trigger")
        {
            
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
}
