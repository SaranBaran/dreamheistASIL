using UnityEngine;

public class ObjectAngle : MonoBehaviour {
    
    [SerializeField] private BillboardType billboardType;
    
    [Header("Lock Rotation")]
    [SerializeField] private bool lockX;
    [SerializeField] private bool lockY;
    [SerializeField] private bool lockZ;

    private Vector3 originalRotation;

    public enum BillboardType { LookAtCamera, CameraForward };

    private SpriteRenderer spriteRenderer;

    public Sprite N, W, S, E;

    public CameraManager cameraManager;

    private void Awake()
    {
        originalRotation = transform.rotation.eulerAngles;
    }

    public void Start() => spriteRenderer = GetComponent<SpriteRenderer>();

    public void Update()
    {

        float angle = Camera.main.transform.eulerAngles.y;

        angle = (angle + 360f) % 360f;

    if (angle >= 315f || angle < 45f)
    {
        spriteRenderer.sprite = N;
    }
    else if (angle >= 45f && angle < 135f)
    {
        spriteRenderer.sprite = E;
    }
    else if (angle >= 135f && angle < 225f)
    {
        spriteRenderer.sprite = S;
    }
    else
    {
        spriteRenderer.sprite = W;
    }

    }

    void LateUpdate()
    {

        switch (billboardType)
        {
            case BillboardType.CameraForward:
                transform.forward = Camera.main.transform.forward;
                break;
            default:
                break;

        }

        // Modify the rotation in Euler space to lock certain dimensions.
        Vector3 rotation = transform.rotation.eulerAngles;
        if (lockX) { rotation.x = originalRotation.x; }
        if (lockY) { rotation.y = originalRotation.y; }
        if (lockZ) { rotation.z = originalRotation.z; }
        transform.rotation = Quaternion.Euler(rotation);
    }
}
