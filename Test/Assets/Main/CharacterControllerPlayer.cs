using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CharacterControllerPlayer : MonoBehaviour
{
    public GameObject player;
    public GameObject playerAnimation;
    static CharacterController playerController;
    public Animator playerAnimator;

    public float moveWalkPlayer;
    public float moveSpeedWalkPlayer;
    public float speedWalkPlayer;
    public float speedFallPlayer;
    public float powerJumpPlayer;

    public Vector3 playerMove;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerController = player.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        controller();
        physicsPlayer();
    }

    void controller()
    {
        {
            if (Input.GetKey(KeyCode.A))
            {
                playerMove.x -= speedWalkPlayer;
                moveWalkPlayer += moveSpeedWalkPlayer;
            }
            if (Input.GetKey(KeyCode.D))
            {
                playerMove.x  += speedWalkPlayer;
                moveWalkPlayer += moveSpeedWalkPlayer;
            }
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)
                & playerController.isGrounded)
            {
                playerAnimator.SetFloat("Speed", moveWalkPlayer / 10);
                playerAnimator.SetFloat("MotionSpeed", moveWalkPlayer / 10);
            }
            if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
            {
                playerMove.x = 0;
                moveWalkPlayer = 0;
                playerAnimator.SetFloat("Speed", 0);
                playerAnimator.SetFloat("MotionSpeed", 0);
            }


            if (Input.GetKey(KeyCode.Space) & playerController.isGrounded)
            {
                playerMove.y += powerJumpPlayer;
                playerAnimator.SetBool("Grounded", false);
                playerAnimator.SetBool("Jump", true);
            }
            if (!playerController.isGrounded)
            {
                playerAnimator.SetBool("Grounded", true);
                playerAnimator.SetBool("Jump", false);
            }
            playerController.Move(playerMove * Time.deltaTime);
        }
    }
    void physicsPlayer()
    {
        if(!playerController.isGrounded)
        {
            playerMove.y -= speedFallPlayer * Time.deltaTime;
        }
    }
}
