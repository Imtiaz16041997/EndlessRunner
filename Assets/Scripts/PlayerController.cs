using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public bool jump = false;
    public bool slide = false;
    public Animator anim;
    public GameObject trigger;

    public float score = 0;
  

    public bool boost = false;
    public Rigidbody rbody;
    public CapsuleCollider myCollider;

    public bool death = false;
    public Image gameOverImg;
    public Text scoreText;
    public float lastScore;
    public Text bestScoreText;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator> ();
        // after boost will control this part so initialize it 
        rbody = GetComponent<Rigidbody> ();
        myCollider = GetComponent<CapsuleCollider> ();

        lastScore = PlayerPrefs.GetFloat ("MyScore");



    }

    // Update is called once per frame
    void Update()



    {



        scoreText.text = score.ToString();  //scoreadd to text which is ui canvas


        if(score > lastScore)
        {
            bestScoreText.text ="Best Score : " + score.ToString();
        }

        else
        {
            bestScoreText.text ="Your Score : " + score.ToString();
        }

        if(death == true)
        {
            gameOverImg.gameObject.SetActive(true);
        }

        // player controll start
        if (score >= 100 && death != true)
        {
            transform.Translate(0, 0, 0.05f);  // this is for Running/Runspeed Code 
        }
        else if(score >= 500 && death != true)
        {
            transform.Translate(0, 0, 0.07f); // set the speedrange with score
        }

        else if(death == true)
        {
            transform.Translate(0, 0, 0);
        }


        else
        {
            transform.Translate(0, 0, 0.01f);
        }

        //Boost
        if(boost == true)
        {
            transform.Translate(0, 0, 1f);
            myCollider.enabled = false; // collider na thakle disabled korbe 
            rbody.isKinematic = true; // collider na thakle character nicher dike fall korbe, kinamtic kore dile gravity pabe na  
        }
        else // boost false hoile 
        {
            myCollider.enabled = true;
            rbody.isKinematic = false;
        }





        if (Input.GetKey(KeyCode.Space)) //jumping code 
        {
            jump = true;
        }
        else
        {
            jump = false;
        }


        if (Input.GetKey(KeyCode.DownArrow)) // sliding code 
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
            myCollider.height = 1f;

        }
        else if (slide == false)
        {
            anim.SetBool("isSlide", slide);
            //transform.Translate(0, 0, 0.01f);
            myCollider.height = 2.05f;

        }

        trigger = GameObject.FindGameObjectWithTag("Obstacle");

    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "PlayerTrigger")
        {

            Destroy(trigger.gameObject);
         
        }

        if (other.gameObject.tag == "Coin") // Collecting Coin 
        {

            Destroy(other.gameObject, 0.5f);
            score = score + 5f; // score 

        }

        if (other.gameObject.tag == "Boost") // Boost true
        {

            Destroy (other.gameObject);
           StartCoroutine (BoostController ()); // call korbe

        }

        if (other.gameObject.tag == "DeathPoint") // Boost true
        {
            death = true;

            if(score > lastScore)
            {
                PlayerPrefs.SetFloat("MyScore",score);
            }
            // call korbe

        }
    }

    //Boost up Coding 

    IEnumerator BoostController()
    {
        boost = true;
        yield return new WaitForSeconds(3);
        boost = false;
    }

    //Go To Menu 
    public void GoToMenu()
    {
        SceneManager.LoadScene(0);
    }

    //Restart
    public void PlayAgain()
    {
        SceneManager.LoadScene(1);
    }
}
