using UnityEngine;

public class GravityMovement : MonoBehaviour
{
    public float gravity = -9.81f; // 重力加速度
    private Vector3 velocity; // キャラクターの速度 

    CharacterController controller;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (controller.isGrounded)
        {
            velocity.y = 0f; // 地面にいる場合は垂直方向の速度をリセット
        }
        else
        {
            velocity.y += gravity * Time.deltaTime; // 空中にいる場合は重力を適用
        }
        controller.Move(velocity * Time.deltaTime); // 速度に基づいて移動
    }
}