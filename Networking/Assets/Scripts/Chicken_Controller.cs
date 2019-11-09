using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Chicken_Controller : MonoBehaviourPun
{
    Animator animator;
    [SerializeField] float moveSpeed = 8;

    UnityEngine.UI.Text scoreBox;

    int score = 0;
    [SerializeField] float timeToScore = 2;
    float currentScoreTimer = 0;

    private void Start()
    {
        animator = GetComponent<Animator>();
        scoreBox = GameObject.Find("txtScore").GetComponent<UnityEngine.UI.Text>();
    }

    private void Update()
    {
        if (!photonView.IsMine)
        {
            return;
        }
        Vector3 movement = new Vector3(-Input.GetAxis("Vertical"), 0, Input.GetAxis("Horizontal"));

        if (movement.sqrMagnitude == 0)
        {
            animator.SetBool("Walk", false);

            if(Input.GetKey(KeyCode.Space))
            {
                animator.SetBool("Eat", true);
                DoScoring();
            }
            else
            {
                animator.SetBool("Eat", false);
            }
        }
        else
        {
            animator.SetBool("Walk", true);
            animator.SetBool("Eat", false);
            transform.position += movement.normalized * (moveSpeed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(0, Mathf.Atan2(movement.x, movement.z) * Mathf.Rad2Deg, 0);
        }
        scoreBox.text = string.Format("Score: {0}", score);
    }

    void DoScoring()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            currentScoreTimer = timeToScore;
        }

        else
        {
            currentScoreTimer -= Time.deltaTime;
            if (currentScoreTimer <= 0)
            {
                score++;
                currentScoreTimer += timeToScore;

            }
        }
    }
}
