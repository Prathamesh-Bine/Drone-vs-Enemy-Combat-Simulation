using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameSceneManager : MonoBehaviour
{
    public void ReloadLevel()
    {
        StartCoroutine(ReloadLevelRoutine());
    }

    IEnumerator ReloadLevelRoutine()
    {
    
        yield return new WaitForSeconds(1f);
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
