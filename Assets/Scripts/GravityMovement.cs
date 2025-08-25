using UnityEngine;

public class GravityMovement : MonoBehaviour
{
    public float gravity = -9.81f; // �d�͉����x
    private Vector3 velocity; // �L�����N�^�[�̑��x 

    CharacterController controller;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (controller.isGrounded)
        {
            velocity.y = 0f; // �n�ʂɂ���ꍇ�͐��������̑��x�����Z�b�g
        }
        else
        {
            velocity.y += gravity * Time.deltaTime; // �󒆂ɂ���ꍇ�͏d�͂�K�p
        }
        controller.Move(velocity * Time.deltaTime); // ���x�Ɋ�Â��Ĉړ�
    }
}