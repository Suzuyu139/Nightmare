using UnityEngine;

public class PlayerLookView : MonoBehaviour
{
    Transform _charaTransform = null;
    Transform _mainCameraTransform = null;

    private void Awake()
    {
        _mainCameraTransform = Camera.main.transform;
        _charaTransform = this.transform;

        _mainCameraTransform.localRotation = Quaternion.identity;
    }

    public void UpdateRotation(Quaternion cameraRot, Quaternion charaRot)
    {
        _mainCameraTransform.localRotation = cameraRot;
        _charaTransform.Rotate(charaRot.eulerAngles);
    }

    public Quaternion GetCameraRotation()
    {
        return _mainCameraTransform.localRotation;
    }

    public Quaternion GetCharaRotation()
    {
        return _charaTransform.localRotation;
    }
}
