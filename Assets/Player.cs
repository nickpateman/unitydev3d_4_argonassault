using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    [SerializeField] float XSpeed = 5f;
    [SerializeField] float XRange = 6f;
    [SerializeField] float YSpeed = 6f;
    [SerializeField] float YRange = 4.5f;
    [SerializeField] float PositionPitchFactor = -2f;
    [SerializeField] float ControlPitchFactor = -10f;
    [SerializeField] float PositionYawFactor = -2f;
    [SerializeField] float ControlYawFactor = -10f;
    [SerializeField] float PositionRollFactor = -2f;
    [SerializeField] float ControlRollFactor = -30f;

    private float _xThrow = 0f;
    private float _yThrow = 0f;

    void Start()
    {
        
    }

    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
    }

    private void ProcessTranslation()
    {
        _xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        _yThrow = CrossPlatformInputManager.GetAxis("Vertical");
        float xOffset = _xThrow * XSpeed * Time.deltaTime;
        float yOffset = _yThrow * YSpeed * Time.deltaTime;
        float newXPos = Mathf.Clamp(transform.localPosition.x + xOffset, -XRange, XRange);
        float newYPos = Mathf.Clamp(transform.localPosition.y + yOffset, -YRange, YRange);
        transform.localPosition = new Vector3(newXPos, newYPos, transform.localPosition.z);
    }

    private void ProcessRotation()
    {
        float pitch = (transform.localPosition.y * PositionPitchFactor) + (_yThrow * ControlPitchFactor);
        float yaw = transform.localPosition.x * PositionYawFactor;
        float roll = _xThrow * ControlRollFactor;
        transform.localRotation = Quaternion.Euler(new Vector3(pitch, yaw, roll));
    }
}
