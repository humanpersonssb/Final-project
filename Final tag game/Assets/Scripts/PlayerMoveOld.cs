using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveOld : MonoBehaviour
{
    public CharacterController2D controller;

    float horizontalmove = 0f;
    float horizontalmoveL = 0f;

    public float runspeed = 40f;
    [SerializeField] private int playernumber = 0;
    public int whichplayer = 1;
    public int letterplayer = 2;
    bool jump = false;
    bool crouch = false;
    bool jumpL = false;
    bool crouchL = false;
    public bool countd = false;
    [SerializeField] public GameObject countp;
    [SerializeField] public float boomtimerp = 5;
    public int score = 0;
    [SerializeField] GameObject scoretxt;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // horizontalmove = Input.GetAxisRaw("Horizontal") * runspeed;
        //horizontalmoveL = Input.GetAxisRaw("Horizontal") * runspeed;
        // left and right
        if (Input.GetKeyDown(KeyCode.A))
        {
            horizontalmoveL = -1 * runspeed;
        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            horizontalmoveL = 0;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            horizontalmoveL = 1 * runspeed;
        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            horizontalmoveL = 0;
        }
        // key movement
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            horizontalmove = 1 * runspeed;
        }
        else if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            horizontalmove = 0;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            horizontalmove = -1 * runspeed;
        }
        else if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            horizontalmove = 0;
        }

        //jumping
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            jump = true;
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            jumpL = true;
        }

        // switch characters
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (letterplayer == 1)
            {
                if (whichplayer == 2) letterplayer = 3;
                else
                    letterplayer = 2;
            }
            else if (letterplayer == 2)
            {
                if (whichplayer == 3) letterplayer = 1;
                else
                    letterplayer = 3;
            }
            else if (letterplayer == 3)
            {
                if (whichplayer == 1) letterplayer = 2;
                else
                    letterplayer = 1;
            }
        }

        if (Input.GetKeyDown(KeyCode.RightShift))
        {
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
                else
                    whichplayer = 1;
            }
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            crouch = true;
        }
        else if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            crouch = false;
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            crouchL = true;
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            crouchL = false;
        }
    }


    void FixedUpdate()
    {
        if (playernumber == whichplayer)
        {
            controller.Move(horizontalmove * Time.fixedDeltaTime, crouch, jump);
        }

        if (playernumber == letterplayer)
        {
            controller.Move(horizontalmoveL * Time.fixedDeltaTime, crouchL, jumpL);
        }
        jump = false;
        jumpL = false;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("enemy touched");

        if (other.gameObject.tag == "Enemy")
        {
            //Debug.Log("enemy touched");
            /*
            if (other.GetComponent<Enemy>().countdown == true)
            {
                Debug.Log("Player is it from player");
                countd = true;
                other.GetComponent<Enemy>().countdown = false;
                countp.SetActive(true);
            }
            else if (countd == true)
            {
                Debug.Log("Enemy is it from player");
                countd = false;
                other.GetComponent<Enemy>().countdown = true;
                countp.SetActive(false);
            }
            */
        }

    }



    public IEnumerator playerboom()
    {
        yield return new WaitForSeconds(1f);
        if (countd)
        {
            Debug.Log("pboom");

            boomtimerp--;
            ////timer work
            if (boomtimerp <= 0)
            {
                pscore();
                boomtimerp = 5;
                StartCoroutine(playerboom());
            }
            else
            {
                StartCoroutine(playerboom());
            }
        }

    }

    //scoring method
    public void pscore()
    {
        //method scores a point
        Debug.Log("enemy score");
        score++;
        scoretxt.GetComponent<UnityEngine.UI.Text>().text = "Player 2 Score: " + score;
    }

}
