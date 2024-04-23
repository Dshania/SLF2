using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneFadeTransition : MonoBehaviour
{
    public Animator transition;
    private void Start()
    {
        gameObject.SetActive(true);
    }
    public void Next()
    {
        StartCoroutine(fadeTransition(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator fadeTransition(int levelIndex)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(levelIndex);
    }
}
