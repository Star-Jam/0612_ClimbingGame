using UnityEngine.SceneManagement;

public static class SceneLoder
{
    public static void LoadScene(string name)
    {
        SceneManager.LoadSceneAsync(name);
    }
}
