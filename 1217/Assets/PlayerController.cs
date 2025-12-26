using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class NewMonoBehaviourScript : MonoBehaviour
{
    Rigidbody2D rigid2D;
    Animator animator;
    float jumpForce = 680.0f;
    float walkForce = 30.0f;
    float maxWalkSpeed = 2.0f;

    void Start()
    {
        Application.targetFrameRate = 60;
        this.rigid2D = GetComponent<Rigidbody2D>();
        this.animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)&&this.rigid2D.linearVelocity.y == 0)
        {
            this.rigid2D.AddForce(transform.up * this.jumpForce);
        }
        int key = 0;
        if (Input.GetKey(KeyCode.RightArrow)) key = 1;
        if (Input.GetKey(KeyCode.LeftArrow)) key = -1;
        float speedx = Mathf.Abs(this.rigid2D.linearVelocity.x);
        if (speedx < this.maxWalkSpeed)
        {
            this.rigid2D.AddForce(transform.right * key * this.walkForce);
        }
        if (key != 0)
        {
            transform.localScale = new Vector3(key, 1, 1);
        }
        this.animator.speed = speedx / 2.0f;
        if (transform.position.y < -10)
        {
            SceneManager.LoadScene("GameScene");
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("���I");
        SceneManager.LoadScene("ClearScene");
    }
}
