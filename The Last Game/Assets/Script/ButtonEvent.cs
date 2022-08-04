using UnityEngine;
using UnityEngine.SceneManagement; // 이걸 써야 SceneManager를 사용할 수있음
public class ButtonEvent : MonoBehaviour
{
   public void SceneLoader(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
