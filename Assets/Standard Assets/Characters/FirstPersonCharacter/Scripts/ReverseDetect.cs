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
    public Animation anim;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isTriggered == true && this.tag == "Collectible")
        {


            MainObj.GetComponent<Animator>().Play("Robot_Anim_Interact1");
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
            if(isTriggered == true && this.tag == "Destructible")
            {
                actualPlace = this.transform.position;
                actualRot = this.transform.rotation;

                Instantiate(ObjetDetruit, actualPlace, actualRot);
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

    public void Destruction()
    {
        Destroy(this.gameObject);
    }
}
