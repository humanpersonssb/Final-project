using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Enemy : MonoBehaviour
{
    // controller
    public CharacterController2D controller;

    float horizontalmove = 0f;
    float horizontalmoveL = 0f;

    public float runspeed = 40f;
    [SerializeField] private int Enemynumber = 0;
    public int whichenemy = 1;
    public int letterenemy = 2;
    bool jump = false;
    bool crouch = false;
    bool jumpL = false;
    bool crouchL = false;

    // timers/score
    public bool countdown = false;
    public bool cantrigger = true;
    public int escore = 0;
    [SerializeField] GameObject txt;
    [SerializeField] GameObject count;
    [SerializeField] private float boomtimer = 5;

    private PlayerInput playerInput;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        playerInput.onActionTriggered += PlayerInput_onActionTriggered;
    }

    public void  PlayerInput_onActionTriggered(InputAction.CallbackContext context)
        {
        Debug.Log(context);
        }
    // Update is called once per frame
    void Update()
    {
        if (Enemynumber == whichenemy)
        {
            controller.Move(horizontalmove * Time.fixedDeltaTime, crouch, jump);
        }

        if (Enemynumber == letterenemy)
        {
            controller.Move(horizontalmoveL * Time.fixedDeltaTime, crouchL, jumpL);
        }
        jump = false;
        jumpL = false;

    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("player touched");

        if (other.gameObject.tag == "Player")
        {
            //Debug.Log("player touched");

            if (other.GetComponent<PlayerMove>().countd == true)
            {
                //cooldown
                if (cantrigger)
                {
                    cantrigger = false;
                    StartCoroutine(triggercd());
                    Debug.Log("enemy is it");
                    countdown = true;
                    other.GetComponent<PlayerMove>().countd = false;
                    other.GetComponent<PlayerMove>().countp.SetActive(false);
                    count.SetActive(true);
                    boomtimer = 5;
                    other.GetComponent<PlayerMove>().boomtimerp = 5;
                    StartCoroutine(boom());
                    StopCoroutine(other.GetComponent<PlayerMove>().playerboom());
                }
            }
            else if (countdown == true)
            {
                if (cantrigger)
                {
                    cantrigger = false;
                    StartCoroutine(triggercd());
                    Debug.Log("Player is it");
                    countdown = false;
                    other.GetComponent<PlayerMove>().countd = true;
                    count.SetActive(false);
                    StopCoroutine(boom());
                    other.GetComponent<PlayerMove>().boomtimerp = 5;
                    other.GetComponent<PlayerMove>().countp.SetActive(true);
                    StartCoroutine(other.GetComponent<PlayerMove>().playerboom());
                    boomtimer = 5;
                }

            }
        }
    }


    //cooldown method
    public IEnumerator triggercd()
    {
        yield return new WaitForSeconds(1f);
        cantrigger = true;
    }
    //timer method
    public IEnumerator boom()
    {
        yield return new WaitForSeconds(1f);
        if (countdown)
        {
            Debug.Log("boom");

            boomtimer--;
            ////timer work
            if (boomtimer <= 0)
            {
                score();
                boomtimer = 5;
                StartCoroutine(boom());
            }
            else
            {
                StartCoroutine(boom());
            }
        }

    }

    //scoring method
    public void score()
    {
        //method scores a point
        Debug.Log("enemy score");
        escore++;
        txt.GetComponent<UnityEngine.UI.Text>().text = "Player 1 Score: " + escore;
    }








    //////////////movement
   public void OnSwapR()
        {
        Debug.Log("yes");
        /*
            if (whichplayer == 1)
            {
                if (letterplayer == 2) whichplayer = 3;
                else
                    whichplayer = 2;
            }
            else if (whichplayer == 2)
        {
        if (letterplayer == 3) whichplayer = 1;
        else
            whichplayer = 3;
        }
        else if (whichplayer == 3)
        {
        if (letterplayer == 1) whichplayer = 2;
            else whichplayer = 1;
        }*/
   }


    public void OnTest()
    {
        Debug.Log("yes");
        /*
            if (whichplayer == 1)
            {
                if (letterplayer == 2) whichplayer = 3;
                else
                    whichplayer = 2;
            }
            else if (whichplayer == 2)
        {
        if (letterplayer == 3) whichplayer = 1;
        else
            whichplayer = 3;
        }
        else if (whichplayer == 3)
        {
        if (letterplayer == 1) whichplayer = 2;
            else whichplayer = 1;
        }*/
    }

    public void testmethod()
    {
        Debug.Log("77777");
    }
}
