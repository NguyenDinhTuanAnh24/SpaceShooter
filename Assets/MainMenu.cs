using UnityEngine;
using UnityEngine.SceneManagement; // Thư viện để quản lý chuyển cảnh

public class MainMenu : MonoBehaviour
{
    // Hàm này sẽ được gọi khi bấm nút Play
    public void OnPlayButtonClicked()
    {
        // "Battle" là tên Scene màn chơi chính của bạn
        SceneManager.LoadScene("Battle");
    }
}