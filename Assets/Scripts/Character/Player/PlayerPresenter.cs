using UnityEngine;
using R3;
using R3.Triggers;

public class PlayerPresenter : PresenterBase
{
    PlayerModel _model = new PlayerModel();

    [SerializeField] PlayerInputEvent _inputEvent;

    [SerializeField] PlayerMoveView _moveView;
    [SerializeField] PlayerLookView _lookView;

    float _gravity = 0.0f;
    Quaternion _cameraRot = new Quaternion();
    Quaternion _charaRot = new Quaternion();

    private void Start()
    {
        _cameraRot = _lookView.GetCameraRotation();
        _charaRot = _lookView.GetCharaRotation();

        this.UpdateAsObservable().Subscribe(OnUpdate).AddTo(gameObject);

        IsInitialized = true;
    }

    void OnUpdate(Unit unit)
    {
        Move();
        Look();
    }

    void Move()
    {
        var move = Vector3.zero;

        move.x = _inputEvent.MoveInput.x;
        move.z = _inputEvent.MoveInput.y;

        move *= _model.MoveSpeed * Time.deltaTime;

        _gravity += Physics.gravity.y * Time.deltaTime;
        move.y = _gravity;

        _moveView.Move(move, out _gravity);
    }

    void Look()
    {
        _cameraRot *= Quaternion.Euler(-_inputEvent.LookInput.y * Time.deltaTime * _model.SensiSpeedVertical, 0.0f, 0.0f);
        _charaRot = Quaternion.Euler(0.0f, _inputEvent.LookInput.x * Time.deltaTime * _model.SensiSpeedHorizontal, 0.0f);
        _cameraRot = ClampRotation(_cameraRot);

        _lookView.UpdateRotation(_cameraRot, _charaRot);
    }

    Quaternion ClampRotation(Quaternion rot)
    {
        //q = x,y,z,w (x,y,zはベクトル（量と向き）：wはスカラー（座標とは無関係の量）)

        rot.x /= rot.w;
        rot.y /= rot.w;
        rot.z /= rot.w;
        rot.w = 1f;

        float angleX = Mathf.Atan(rot.x) * Mathf.Rad2Deg * 2f;

        angleX = Mathf.Clamp(angleX, _model.LookVerticalMin, _model.LookVerticalMax);

        rot.x = Mathf.Tan(angleX * Mathf.Deg2Rad * 0.5f);

        return rot;
    }
}
