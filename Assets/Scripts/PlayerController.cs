using UnityEngine;
using UnityEngine.InputSystem.XR;

public class PlayerController : MonoBehaviour
{
    public float speed;         // �O�i�̑��x
    public float rotationSpeed; // ��]�̑��x�i�x/�b�j

    public float gravity;       // �d�͉����x
    public float jumpPower;     // �W�����v��
    private Vector3 velocity;   // �㉺�̑��x 

    private CharacterController charCon;

    void Start()
    {
        // �e��R���|�[�l���g�̎擾
        charCon = GetComponent<CharacterController>(); // �L�����N�^�[�R���g���[���[
    }

    void Update()
    {
        // ���E�̉�]
        float horizontal = Input.GetAxis("Horizontal");
        transform.Rotate(0, horizontal * rotationSpeed * Time.deltaTime, 0);

        // �O�i�܂��͌��
        float vertical          = Input.GetAxis("Vertical"); // �㉺�̖��L�[�̓��͂��擾
        Vector3 forwardMovement = transform.forward * vertical * speed;

        // �㉺�̈ړ�
        if (charCon.isGrounded)
        {
            // �n�ʂɂ���ꍇ�͐��������̑��x�����Z�b�g
            // 0����isGrounded�̒l�����肵�Ȃ��̂�-0.5�ɂ���
            velocity.y = -0.5f; 
            
            // �W�����v
            if(Input.GetKeyDown(KeyCode.Z))
            {
                velocity.y = jumpPower;
            }
        }
        else
        {
            velocity.y += gravity * Time.deltaTime; // �󒆂ɂ���ꍇ�͏d�͂�K�p
        }
        charCon.Move( (forwardMovement + velocity) * Time.deltaTime); // ���x�Ɋ�Â��Ĉړ�

    }
}