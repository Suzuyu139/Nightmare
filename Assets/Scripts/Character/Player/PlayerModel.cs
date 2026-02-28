using UnityEngine;
using R3;

public class PlayerModel
{
    public float MoveSpeed { get; private set; } = 10.0f;
    public void SetMoveSpeed(float speed) => MoveSpeed = speed;

    public float SensiSpeedVertical { get; private set; } = 40.0f;
    public void SetSensiSpeedVertical(float speed) => SensiSpeedVertical = speed;
    public float SensiSpeedHorizontal { get; private set; } = 40.0f;
    public void SetSensiSpeedHorizontal(float speed) => SensiSpeedHorizontal = speed;
    public float LookVerticalMax { get; private set; } = 90.0f;
    public float LookVerticalMin { get; private set; } = -90.0f;
}
