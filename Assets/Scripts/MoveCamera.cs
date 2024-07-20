using Unity.VisualScripting;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    [Header("Information")]
    public Vector2 rotation;
    public float zoom;

    [Header("Atributes")]
    public float sensetivity;
    public float moveSpeed;
    public float zoomSpeed;
    public Vector2 mixMaxRotation;
    public Vector2 mixMaxZoom;

    void Update()
    {
        if (!Options._paused)
        {
            //INPUTS
            //rotating
            rotation.x += Input.GetAxisRaw("Vertical") * Time.deltaTime * moveSpeed;
            rotation.y -= Input.GetAxisRaw("Horizontal") * Time.deltaTime * moveSpeed;
            if (Input.GetMouseButton(0))
            {
                rotation.x -= sensetivity * Input.GetAxis("Mouse Y");
                rotation.y += sensetivity * Input.GetAxis("Mouse X");
            }

            //zooming
            zoom -= Input.mouseScrollDelta.y * Time.deltaTime * zoomSpeed;
            if (Input.GetKey(KeyCode.E)) zoom -= 0.2f * Time.deltaTime * zoomSpeed;
            if (Input.GetKey(KeyCode.Q)) zoom += 0.2f * Time.deltaTime * zoomSpeed;

            //SAFTY CLAMPING
            zoom = Mathf.Clamp(zoom, mixMaxZoom.x, mixMaxZoom.y);
            rotation.x = Mathf.Clamp(rotation.x, mixMaxRotation.x, mixMaxRotation.y);

            //APPLYING
            transform.localScale = new Vector3(zoom, zoom, zoom);
            transform.eulerAngles = new Vector2(rotation.x, rotation.y);
        }
    }
}
