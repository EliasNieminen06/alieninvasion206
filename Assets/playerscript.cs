using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerscript : MonoBehaviour
{
    [SerializeField] Transform pelaajaKamera;
    [SerializeField] [Range(0.0f, 0.5f)] float mouseSmoothTime;
    [SerializeField] bool osoitinLukko;
    [SerializeField] float mouseSensitivity = 3.5f;
    [SerializeField] float speed = 6f;
    [SerializeField] [Range(0.0f, 0.5f)] float moveSmoothTime;
    [SerializeField] float gravity = -30f;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask ground;
    [SerializeField] float jumpHeight = 6;
    private float velocityY;
    private bool onMaassa;
    private float cameraCap;
    private Vector2 currentMouseDelta;
    private Vector2 currentMouseDeltaVelocity;
    private CharacterController ohjain;
    private Vector2 currentDirVelocity;
    private Vector2 currentDir;
    private Vector3 velocity;
    // Start is called before the first frame update
    void Start()
    {
        ohjain = GetComponent<CharacterController>();
        if (osoitinLukko)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        PaivitaHiiri();
        PaivitaLiike();
    }

    void PaivitaHiiri()
    {
        Vector2 targetMouseDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        currentMouseDelta = Vector2.SmoothDamp(currentMouseDelta, targetMouseDelta, ref currentMouseDeltaVelocity, mouseSmoothTime);
        cameraCap -= currentMouseDelta.y * mouseSensitivity;
        cameraCap = Mathf.Clamp(cameraCap, -90, 90);
        pelaajaKamera.localEulerAngles = Vector3.right * cameraCap;
        transform.Rotate(Vector3.up * currentMouseDelta.x * mouseSensitivity);
    }

    void PaivitaLiike()
    {
        onMaassa = Physics.CheckSphere(groundCheck.position, 0.2f, ground);
        Vector2 targetDir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        targetDir.Normalize();
        currentDir = Vector2.SmoothDamp(currentDir, targetDir, ref currentDirVelocity, moveSmoothTime);
        velocityY += gravity * Time.deltaTime;
        Vector3 velocity = (transform.forward * currentDir.y + transform.right * currentDir.x) * speed + Vector3.up * velocityY;
        ohjain.Move(velocity * Time.deltaTime);
        if (onMaassa && Input.GetButtonDown("Jump"))
        {
            velocityY = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }
        if (onMaassa && velocityY < 1f)
        {
            velocityY = -8;
        }
    }
}
