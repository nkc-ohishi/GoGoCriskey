using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleLogoController : MonoBehaviour
{
    Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        startPos.z += Time.deltaTime;
        startPos.z = Mathf.Min(startPos.z, 0);

        transform.position = startPos;

        if(Input.GetKeyDown(KeyCode.Z))
        {
            SceneManager.LoadScene("GameScene");
        }
    }
}
