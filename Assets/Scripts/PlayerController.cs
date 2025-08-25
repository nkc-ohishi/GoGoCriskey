using UnityEngine;
using UnityEngine.InputSystem.XR;

public class PlayerController : MonoBehaviour
{
    public float speed;         // 前進の速度
    public float rotationSpeed; // 回転の速度（度/秒）

    public float gravity;       // 重力加速度
    public float jumpPower;     // ジャンプ力
    private Vector3 velocity;   // 上下の速度 

    private CharacterController charCon;

    void Start()
    {
        // 各種コンポーネントの取得
        charCon = GetComponent<CharacterController>(); // キャラクターコントローラー
    }

    void Update()
    {
        // 左右の回転
        float horizontal = Input.GetAxis("Horizontal");
        transform.Rotate(0, horizontal * rotationSpeed * Time.deltaTime, 0);

        // 前進または後退
        float vertical          = Input.GetAxis("Vertical"); // 上下の矢印キーの入力を取得
        Vector3 forwardMovement = transform.forward * vertical * speed;

        // 上下の移動
        if (charCon.isGrounded)
        {
            // 地面にいる場合は垂直方向の速度をリセット
            // 0だとisGroundedの値が安定しないので-0.5にした
            velocity.y = -0.5f; 
            
            // ジャンプ
            if(Input.GetKeyDown(KeyCode.Z))
            {
                velocity.y = jumpPower;
            }
        }
        else
        {
            velocity.y += gravity * Time.deltaTime; // 空中にいる場合は重力を適用
        }
        charCon.Move( (forwardMovement + velocity) * Time.deltaTime); // 速度に基づいて移動

    }
}