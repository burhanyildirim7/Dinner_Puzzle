using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ElephantSDK;

public class LevelController : MonoBehaviour
{
    public static LevelController instance;
    public int levelNo, tempLevelNo, totalLevelNo; // totallevelno tum leveller bitip random level gelmeye baslayinca kullaniliyor
    public List<GameObject> levels = new List<GameObject>();
    public GameObject currentLevelObj;

    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(this);
    }

    private void Start()
    {
        //PlayerPrefs.DeleteAll();
        totalLevelNo = PlayerPrefs.GetInt("level");
        if (totalLevelNo == 0)
        {
            totalLevelNo = 1;
            levelNo = 1;
        }
        UIController.instance.SetLevelText(totalLevelNo);
        LevelStartingEvents();
    }


    public void IncreaseLevelNo()
    {
        tempLevelNo = levelNo;
        totalLevelNo++;
        PlayerPrefs.SetInt("level", totalLevelNo);
        UIController.instance.SetLevelText(totalLevelNo);
    }

    public void LevelStartingEvents()
    {
        if (totalLevelNo > levels.Count)
        {
            levelNo = Random.Range(1, levels.Count + 1);
            if (levelNo == tempLevelNo) levelNo = Random.Range(1, levels.Count + 1);
        }
        else
        {
            levelNo = totalLevelNo;
        }
        UIController.instance.SetLevelText(totalLevelNo);
        currentLevelObj = Instantiate(levels[levelNo - 1], Vector3.zero, Quaternion.identity);
        Elephant.LevelStarted(totalLevelNo);
        StartCoroutine(StartingEvents());
    }

    IEnumerator StartingEvents()
	{
        yield return new WaitForSeconds(.1f);
        GameController.instance.mevcutEkipPos = currentLevelObj.GetComponent<LevelAdapter>().mevcutEkipPos.transform.position;
        GameController.instance.siradakiEkipPos = currentLevelObj.GetComponent<LevelAdapter>().siradakiEkipPos.transform.position;
        GameController.instance.toplamPuzzle = currentLevelObj.GetComponent<LevelAdapter>().puzzleSayisi;
        GameController.instance.toplamKisiSayisi = currentLevelObj.GetComponent<LevelAdapter>().toplamKisiSayisi;
        currentLevelObj.GetComponent<LevelAdapter>().ekipler[0].transform.position = GameController.instance.mevcutEkipPos;
        UIController.instance.KarakterOraniText();
        GameController.instance.StartingEvents();
        UIController.instance.SetProgressBar();

    }

    public void NextLevelEvents()
    {
        Elephant.LevelCompleted(totalLevelNo);
        Destroy(currentLevelObj);
        IncreaseLevelNo();
        LevelStartingEvents();
    }

    public void LevelRestartEvents()
    {
        UIController.instance.SetLevelText(totalLevelNo);
        currentLevelObj = Instantiate(levels[levelNo - 1], Vector3.zero, Quaternion.identity);
        Elephant.LevelStarted(totalLevelNo);
        StartCoroutine(StartingEvents());
        
    }


    public void RestartLevelEvents()
    {
        Elephant.LevelFailed(totalLevelNo);
        Destroy(currentLevelObj);
        LevelRestartEvents();
    }
}
