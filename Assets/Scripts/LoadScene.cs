using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    [SerializeField]
    private string _sceneName;

    // Start is called before the first frame update
    public void ButtonPressed()
    {
        SceneManager.LoadScene(_sceneName);
    }
}
