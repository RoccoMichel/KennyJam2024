using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    [Header("Information")]
    public Vector2 rotation;
    public float zoom;
    [Header("Atributes")]

    public float moveSpeed;
    public float zoomSpeed;
    public Vector2 mixMaxRotation;
    public Vector2 mixMaxZoom;

    void Start()
    {

    }

    void Update()
    {
        //Inputs
        rotation.x += Input.GetAxisRaw("Vertical") * Time.deltaTime * moveSpeed;
        rotation.y -= Input.GetAxisRaw("Horizontal") * Time.deltaTime * moveSpeed;

        zoom -= Input.mouseScrollDelta.y * Time.deltaTime * zoomSpeed;

        //Safty Clamping
        zoom = Mathf.Clamp(zoom, mixMaxZoom.x, mixMaxZoom.y);
        rotation.x = Mathf.Clamp(rotation.x, mixMaxRotation.x, mixMaxRotation.y);

        //Applying
        transform.localScale = new Vector3(zoom, zoom, zoom);
        transform.eulerAngles = new Vector3(rotation.x, rotation.y, 0f);
    }
}
