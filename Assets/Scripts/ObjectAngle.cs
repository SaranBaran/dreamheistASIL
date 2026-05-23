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

        var angle = cameraManager.endValue;

        if (angle < 45.0f) spriteRenderer.sprite = N;
        else if (angle < 135.0f) spriteRenderer.sprite = E;
        else if (angle < 225.0f) spriteRenderer.sprite = W;
        else spriteRenderer.sprite = S;

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
