using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController instance; 
    [HideInInspector]public int score, elmas; 
    [HideInInspector] public bool isContinue,masaDolu, isEkipTime;
    public int ekipNo;
	LevelAdapter adapter;


	private void Awake()
	{
        if (instance == null) instance = this;
        else Destroy(this);
	}

	void Start()
    {
       isContinue = false;
        StartingEvents();
    }

	private void Update()
	{
		
	}


	public void SetScore(int eklenecekScore)
	{
        if(PlayerController.instance.collectibleVarMi) score += eklenecekScore;
        // Eðer oyunda collectible yok ise developer kendi score sistemini yazmalý...

    }

    public void StartingEvents()
	{
        masaDolu = false;
        ekipNo = 0;
        StartCoroutine(SelectAndPlaceEkip());
	}

    public IEnumerator SelectAndPlaceEkip()
	{
        yield return new WaitForSeconds(.1f);

        adapter = LevelController.instance.currentLevelObj.GetComponent<LevelAdapter>();

		for (int i = 0; i < adapter.ekipler.Count; i++)
		{
            adapter.ekipler[i].transform.position = new Vector3(0,0,-30);
		}
		if (ekipNo < adapter.ekipler.Count)
		{
            adapter.ekipler[ekipNo].transform.position = Vector3.zero;
		}
		else
		{
			// oyun bitirme olaylarý
		}
		yield return new WaitForSeconds(.1f);
		isEkipTime = true;
	}

	public void ControlEkipBosMu()
	{
		if (adapter.ekipler[ekipNo].transform.childCount == 0)
		{
			isEkipTime = false;
			ekipNo++;
		    StartCoroutine(SelectAndPlaceEkip());
		}
		
	}

}
