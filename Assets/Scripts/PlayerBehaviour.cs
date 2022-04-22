using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBehaviour : MonoBehaviour
{
    // Player attributes
    [SerializeField]
    private float speed = 10;

    // Movement references
    Vector3 moveDirection = Vector3.zero;
    private Vector2 moveInput = Vector2.zero;

    // Game Manager
    [SerializeField]
    private GameManager gameManager;

    // Update is called once per frame
    void Update()
    {
        if (gameManager.GamePaused()) return;

        if (!(moveInput.magnitude > 0)) moveDirection = Vector3.zero;

        moveDirection = transform.forward * moveInput.y + transform.right * moveInput.x;

        Vector3 movementDirection = moveDirection * (speed * Time.deltaTime);

        transform.position += movementDirection;

        if (transform.position.y < -3.0f)
        {
            transform.position = new Vector3(18,2,18);
            gameManager.LoseLives();
            GetComponent<AudioSource>().Play();
        }
    }

    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }
}
