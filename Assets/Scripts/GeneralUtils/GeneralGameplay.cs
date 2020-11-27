using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GeneralGameplay : MonoBehaviour
{
    // Start is called before the first fram
    public static GeneralGameplay instance { get; private set; }

    public GameObject WinGameObject;
    public GameObject DefeatGameObject;

    public bool alwaysRestarts = true;

    private void Awake()
    {
        if (!instance)
        {
            instance = this;
        }


    }
    private void Start()
    {
        StopAllCoroutines();
        GameManagerActions.current.winEvent.AddListener(MoveWinScene);
        GameManagerActions.current.defeatEvent.AddListener(MoveLoseScene);
    }
    public void MoveWinScene()
    {
        WinGameObject.SetActive(true);
        StartCoroutine(LoadNextDelayed(4f));
        //SceneManager.LoadScene("floor2");
    }
    public void MoveLoseScene()
    {
        DefeatGameObject.SetActive(true);
        StartCoroutine(LoadNextDelayed(4f));
        //SceneManager.LoadScene("floor2");
    }
    private IEnumerator LoadNextDelayed(float t)
    {
        yield return new WaitForSecondsRealtime(t);
        SceneManager.LoadScene(alwaysRestarts ? SceneManager.GetActiveScene().buildIndex : SceneManager.GetActiveScene().buildIndex +1 ); //reset scene
    }

    public void BackToMenu() { 
        SceneManager.LoadScene(0);
    }

    public IEnumerator<bool> TimerProto(float timeMax)
    {
        var timer = 0f;
        while ((timer += Time.deltaTime) < timeMax)
        {
            yield return false;
        }
        yield return true;
    }
}
