using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool jump = false;
    public bool slide = false;
    public Animator anim;
    public GameObject trigger;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>(); 
    }

    // Update is called once per frame
    void Update()
    {     
         transform.Translate(0, 0,0.05f);  // this is for Running Code 

        if (Input.GetKey(KeyCode.Space))
        {
            jump = true;
        }
        else
        {
            jump = false;
        }


        if (Input.GetKey(KeyCode.DownArrow))
        {
            slide = true;
        }
        else
        {
            slide = false;
        }



        if (jump == true)  // This is for Jumping
        {
            anim.SetBool("isJump", jump);
            transform.Translate(0, 0.04f, 0.01f);

        }
        else if (jump == false)
        {
            anim.SetBool("isJump", jump);
            //transform.Translate(0, 0, 0.01f);

        }


        if (slide == true)  // This is for Sliding part 
        {
            anim.SetBool("isSlide", slide);
            transform.Translate(0, 0, 0.01f);

        }
        else if (slide == false)
        {
            anim.SetBool("isSlide", slide);
            //transform.Translate(0, 0, 0.01f);

        }

        trigger = GameObject.FindGameObjectWithTag("Obstacle");

    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "PlayerTrigger")
        {

            Destroy(trigger.gameObject);
         
        }
    }
}
