using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController instance; 
    [HideInInspector]public int score, elmas, para, levelPara; 
    [HideInInspector] public bool isContinue,masaDolu, isEkipTime;
    public int ekipNo;
	LevelAdapter adapter;
	public Vector3 mevcutEkipPos, siradakiEkipPos, ekipLookAtPos;
	public int cozulenPuzzle,toplamPuzzle,toplamKisiSayisi,oturanKisiSayisi;


	private void Awake()
	{
        if (instance == null) instance = this;
        else Destroy(this);
	}

	void Start()
    {
		para = PlayerPrefs.GetInt("para");
        isContinue = false;
        StartingEvents();
    }



	public void IncreaseScore()
	{
		score += 2;
		Debug.Log("score" + score);
		levelPara += 10;
		UIController.instance.SetProgressBar();
    }

	public void DecreaseScore()
	{
		score -= 1;
		if (score < 0) score = 0;
		UIController.instance.SetProgressBar();
	}

    public void StartingEvents()
	{
        masaDolu = false;
        ekipNo = 0;
		score = 0;
		levelPara = 0;
		cozulenPuzzle = 0;
		oturanKisiSayisi = 0;
		StartCoroutine(SelectAndPlaceEkip());
		UIController.instance.KarakterOraniText();
		UIController.instance.SetProgressBar();
	}

    public IEnumerator SelectAndPlaceEkip()
	{
        yield return new WaitForSeconds(.1f);

        adapter = LevelController.instance.currentLevelObj.GetComponent<LevelAdapter>();

		for (int i = 0; i < adapter.ekipler.Count; i++)
		{
            adapter.ekipler[i].transform.position = new Vector3(100,100,100);
		}
		if (ekipNo < adapter.ekipler.Count)
		{
			adapter.ekipler[ekipNo].transform.position = new Vector3(mevcutEkipPos.x,mevcutEkipPos.y,mevcutEkipPos.z) ;
			adapter.ekipler[ekipNo].transform.LookAt(ekipLookAtPos,Vector3.up);
		}
		else
		{
			ControlAndFinishGame();
			
		}
		yield return new WaitForSeconds(.1f);
		isEkipTime = true;
	}

	public void ControlEkipBosMu()
	{
		if (adapter.ekipler[ekipNo].transform.childCount == 0)
		{
			isEkipTime = false;
			if (ekipNo < adapter.ekipler.Count - 1) ekipNo++;
			else ControlAndFinishGame();
		    StartCoroutine(SelectAndPlaceEkip());
		}
		
	}

	public void ControlAndFinishGame()
	{
		if(UIController.instance.slider.value >= .5f)
		{
			// baþarýlý..
			Debug.Log("baþarýlý...");
			UIController.instance.ActivateWinScreen();
			para += levelPara;
			PlayerPrefs.SetInt("para", para);
			isContinue = false;
		}
		else
		{
			// baþarýsýz..
			Debug.Log("baþarýsýz...");
			UIController.instance.ActivateLooseScreen();
			isContinue = false;
		}
	}

}
