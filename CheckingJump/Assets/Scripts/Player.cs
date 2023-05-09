using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Transform playerTransform;
    private Rigidbody2D playerRigidBody;
    [SerializeField] private float jumpForce;
    [SerializeField] private float velocity;
    private bool isOnFloor = true;
    
    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GetComponent<Transform>();
        playerRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal") * velocity * Time.deltaTime;
        playerTransform.Translate(new Vector3(moveX, 0));

        if(Input.GetButtonDown("Jump") && isOnFloor /*isOnFloor == true*/)
        {
            isOnFloor = false;
            playerRigidBody.AddForce(Vector2.up * jumpForce);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isOnFloor = true;

        if(collision.gameObject.tag == "Enemy")
        {
            Destroy(this.gameObject);
        }
    }

}
