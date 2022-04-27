using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class GuestController : MonoBehaviour
{
    bool oturdu;
    public Vector3 targetPosition;
    public string isim;
    public GameObject happy, sad, happyPrefab;
    public int type;
    public bool insanMi;

    private void Start()
    {

    }

	private void Update()
	{
        Debug.Log(oturdu);
	}


	private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("sandalye") && !other.GetComponent<SandalyeController>().dolu)
        {
            oturdu = true;
            transform.parent = other.transform;
            Debug.Log("sandalye");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("sandalye"))
        {
            oturdu = false;
            transform.parent = null;

        }
    }

    public IEnumerator ControlSandalye()
    {
        yield return new WaitForSeconds(.1f);
        GetComponent<Collider>().enabled = true;
        yield return new WaitForSeconds(.05f);
        if (oturdu)
        {
            GetComponent<Collider>().enabled = false;
            Debug.Log("burada oturdu");
            if (insanMi)
            {
                GetComponentInChildren<Animator>().SetTrigger("sit");
              
            }
            SandalyeController sandalyem = transform.parent.GetComponent<SandalyeController>();
            transform.position = sandalyem.oturmaPos.position;
            transform.LookAt(sandalyem.bakmaRot.position,Vector3.up);
            sandalyem.dolu = true;
            ControlNeighBours();
            GameController.instance.oturanKarakterSayisi++;
            UIController.instance.KarakterOraniText();
        }
        yield return new WaitForSeconds(.1f);
        if (!oturdu)
        {
            transform.parent = null;
            transform.position = targetPosition;
        }
    }

    void ControlNeighBours()
    {
        SandalyeController komsularim = transform.parent.GetComponent<SandalyeController>();
        if (komsularim.komsu1 != null && komsularim.type == type && komsularim.komsu1.transform.childCount > 0)
        {
            GameController.instance.masaDolu = true;
            Vector3 ortaNokta = (transform.position + komsularim.komsu1.transform.position) / 2 + new Vector3(0, 1, 0);
            ControlKisi(isim, komsularim.komsu1.transform.GetChild(komsularim.komsu1.transform.childCount - 1).GetComponent<GuestController>().isim, ortaNokta);
        }
        else if (komsularim.komsu2 != null && komsularim.type == type && komsularim.komsu2.transform.childCount > 0)
        {
            GameController.instance.masaDolu = true;
            Vector3 ortaNokta = (transform.position + komsularim.komsu1.transform.position) / 2 + new Vector3(0, 1, 0);
            ControlKisi(isim, komsularim.komsu2.transform.GetChild(komsularim.komsu2.transform.childCount - 1).GetComponent<GuestController>().isim, ortaNokta);
        }
        else if (komsularim.type == 2 || komsularim.type == 3)  // kedi kopek kontrolu
        {
            if (komsularim.type == type)
            {
                happy.SetActive(true);
                GameController.instance.IncreaseScore();
            }
            else
            {
                sad.SetActive(true);
                GameController.instance.DecreaseScore();
            }
        }
        else if (komsularim.type == 1) // bir ekipteki lider konumunda karakter varsa
        {
            if (type == 1)
            {
                happy.SetActive(true);
                GameController.instance.IncreaseScore();
            }
            else
            {
                sad.SetActive(true);
                GameController.instance.DecreaseScore();
            }
        }
        else
        {
            if (!GameController.instance.masaDolu)
            {
                GameController.instance.masaDolu = true;
                GameController.instance.ControlEkipBosMu();
                return;
            }
            else
            {
                sad.SetActive(true);
            }
        }
        GameController.instance.ControlEkipBosMu();
    }

    void ControlKisi(string isim1, string isim2, Vector3 ortaNokta)
    {
        if (isim1 == "anne" && isim2 == "baba")
        {
            //happy.SetActive(true);
            HappyActivities(ortaNokta);
            return;
        }
        else if (isim1 == "baba" && isim2 == "anne")
        {
            //happy.SetActive(true);
            HappyActivities(ortaNokta);
            return;
        }
        else if (isim1 == "baba" && isim2 == "cocuk")
        {
            //happy.SetActive(true);
            HappyActivities(ortaNokta);
            return;
        }
        else if (isim1 == "anne" && isim2 == "cocuk")
        {
            //happy.SetActive(true);
            HappyActivities(ortaNokta);
            return;
        }
        else if (isim1 == "cocuk" && isim2 == "cocuk")
        {
            //happy.SetActive(true);
            HappyActivities(ortaNokta);
            return;
        }
        else if (isim1 == "cocuk" && isim2 == "anne")
        {
            //happy.SetActive(true);
            HappyActivities(ortaNokta);
            return;
        }
        else if (isim1 == "cocuk" && isim2 == "baba")
        {
            //happy.SetActive(true);
            HappyActivities(ortaNokta);
            return;
        }
        else if (isim1 == "kari" && isim2 == "koca")
        {
            //happy.SetActive(true);
            HappyActivities(ortaNokta);
            return;
        }
        else if (isim1 == "koca" && isim2 == "kari")
        {
            //happy.SetActive(true);
            HappyActivities(ortaNokta);
            return;
        }
        else if (isim1 == "kiz" && isim2 == "oglan")
        {
            //happy.SetActive(true);
            HappyActivities(ortaNokta);
            return;
        }
        else if (isim1 == "oglan" && isim2 == "kiz")
        {
            //happy.SetActive(true);
            HappyActivities(ortaNokta);
            return;
        }
        else if (isim1 == "isci" && isim2 == "patron")
        {
            //happy.SetActive(true);
            HappyActivities(ortaNokta);
            return;
        }
        else if (isim1 == "isci" && isim2 == "isci")
        {
            //happy.SetActive(true);
            HappyActivities(ortaNokta);
            return;
        }
        else
        {
            sad.SetActive(true);
            GameController.instance.DecreaseScore();
            GameController.instance.ControlEkipBosMu();
        }
    }

    void HappyActivities(Vector3 ortaNokta)
    {
        Instantiate(happyPrefab, ortaNokta, Quaternion.identity);
        GameController.instance.IncreaseScore();
        GameController.instance.ControlEkipBosMu();
    }


}
