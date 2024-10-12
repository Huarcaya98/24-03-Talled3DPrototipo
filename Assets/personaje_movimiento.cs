using UnityEngine;

public class personaje_movimiento : MonoBehaviour
{
    public float horizontalX;
    public float horizontalZ;
    private Vector3 playerInput;
    public CharacterController player;

    public float speed;
    private Vector3 movePlayer;

    public Camera mainCamera;
    private Vector3 camForward;
    private Vector3 camRight;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {
        horizontalX = Input.GetAxis("Horizontal");
        horizontalZ = Input.GetAxis("Vertical");

        playerInput = new Vector3(horizontalX, 0, horizontalZ);
        playerInput = Vector3.ClampMagnitude(playerInput, 1);

        camDirection();
        movePlayer = playerInput.x * camRight + playerInput.z * camForward;

        player.Move(movePlayer * speed * Time.deltaTime);
    }

    void camDirection()
    {
        camForward = mainCamera.transform.forward;
        camRight = mainCamera.transform.right;

        camForward.y = 0;
        camRight.y = 0;

        camForward = camForward.normalized;
        camRight = camRight.normalized;
    }
}
