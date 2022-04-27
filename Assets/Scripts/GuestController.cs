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
            GameController.instance.oturanKisiSayisi++;
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
        if(type == 4) // etkisiz elemanlar singlelar... 
		{
            GameController.instance.masaDolu = true;
            GameController.instance.ControlEkipBosMu();
            return;
        }

        SandalyeController sandalyem = transform.parent.GetComponent<SandalyeController>();

        if(sandalyem.type == type)
		{
            if (sandalyem.komsu1 != null && sandalyem.komsu1.GetComponent<SandalyeController>().dolu)
			{
                GameController.instance.masaDolu = true;
                Vector3 ortaNokta = (transform.position + sandalyem.komsu1.transform.position) / 2 + new Vector3(0, 1, 0);
                ControlKisi(isim, sandalyem.komsu1.transform.GetChild(sandalyem.komsu1.transform.childCount - 1).GetComponent<GuestController>().isim, ortaNokta);
            }
            else if(sandalyem.komsu2 != null && sandalyem.komsu2.GetComponent<SandalyeController>().dolu)
			{
                GameController.instance.masaDolu = true;
                Vector3 ortaNokta = (transform.position + sandalyem.komsu2.transform.position) / 2 + new Vector3(0, 1, 0);
                ControlKisi(isim, sandalyem.komsu2.transform.GetChild(sandalyem.komsu2.transform.childCount - 1).GetComponent<GuestController>().isim, ortaNokta);
            }
            else if (type == 2 || type == 3) // kedi köpeði direk kontrol ediyorum...
			{
                if (sandalyem.type == type)
                {
                    GameController.instance.cozulenPuzzle++;
                    GameController.instance.masaDolu = true;
                    happy.SetActive(true);
                    GameController.instance.IncreaseScore();
                }
                else
                {
                    GameController.instance.masaDolu = true;
                    sad.SetActive(true);
                }
            }
            else if(type == 1 || type == 7 || type == 8 ||type == 9)  // patron kodcu sanatcý v.s. zaten direk kendi koltuðundadýr mutlu olur...
			{
                GameController.instance.cozulenPuzzle++;
                GameController.instance.masaDolu = true;
                happy.SetActive(true);
                GameController.instance.IncreaseScore();
                GameController.instance.ControlEkipBosMu();
                return;
            }
		}
		else
		{
            // burada üzgün yapabiliriz..
            GameController.instance.masaDolu = true;
            sad.SetActive(true);
        }
        GameController.instance.ControlEkipBosMu();

        //if (sandalyem.komsu1 != null && sandalyem.type == type && sandalyem.komsu1.transform.childCount > 2)
        //{
        //    GameController.instance.masaDolu = true;
        //    Vector3 ortaNokta = (transform.position + sandalyem.komsu1.transform.position) / 2 + new Vector3(0, 1, 0);
        //    ControlKisi(isim, sandalyem.komsu1.transform.GetChild(sandalyem.komsu1.transform.childCount - 1).GetComponent<GuestController>().isim, ortaNokta);
        //}
        //else if (sandalyem.komsu2 != null && sandalyem.type == type && sandalyem.komsu2.transform.childCount > 2)
        //{
        //    GameController.instance.masaDolu = true;
        //    Vector3 ortaNokta = (transform.position + sandalyem.komsu1.transform.position) / 2 + new Vector3(0, 1, 0);
        //    ControlKisi(isim, sandalyem.komsu2.transform.GetChild(sandalyem.komsu2.transform.childCount - 1).GetComponent<GuestController>().isim, ortaNokta);
        //}
        //else if (sandalyem.type == 2 || sandalyem.type == 3)  // kedi kopek kontrolu
        //{
        //    if (sandalyem.type == type)
        //    {
        //        happy.SetActive(true);
        //        GameController.instance.IncreaseScore();
        //    }
        //    else
        //    {
        //        sad.SetActive(true);
        //        GameController.instance.DecreaseScore();
        //    }
        //}
        //else if (sandalyem.type == 1) // bir ekipteki lider konumunda karakter varsa
        //{
        //    if (type == 1)
        //    {
        //        happy.SetActive(true);
        //        GameController.instance.IncreaseScore();
        //    }
        //    else
        //    {
        //        sad.SetActive(true);
        //        GameController.instance.DecreaseScore();
        //    }
        //}
        //else
        //{
        //    if (!GameController.instance.masaDolu)
        //    {
        //        GameController.instance.masaDolu = true;
        //        GameController.instance.ControlEkipBosMu();
        //        return;
        //    }
        //    else
        //    {
        //        sad.SetActive(true);
        //    }
        //}
        //GameController.instance.ControlEkipBosMu();
    }

    void ControlKisi(string isim1, string isim2, Vector3 ortaNokta)
    {
        if (isim1 == "anne" && isim2 == "baba")
        {
            HappyActivities(ortaNokta);
            return;
        }
        else if (isim1 == "baba" && isim2 == "anne")
        {
            HappyActivities(ortaNokta);
            return;
        }
        else if (isim1 == "baba" && isim2 == "cocuk")
        {
            HappyActivities(ortaNokta);
            return;
        }
        else if (isim1 == "anne" && isim2 == "cocuk")
        {
            HappyActivities(ortaNokta);
            return;
        }
        else if (isim1 == "cocuk" && isim2 == "cocuk")
        {
            HappyActivities(ortaNokta);
            return;
        }
        else if (isim1 == "cocuk" && isim2 == "anne")
        {
            HappyActivities(ortaNokta);
            return;
        }
        else if (isim1 == "cocuk" && isim2 == "baba")
        {
            HappyActivities(ortaNokta);
            return;
        }
        else if (isim1 == "kari" && isim2 == "koca")
        {
            HappyActivities(ortaNokta);
            return;
        }
        else if (isim1 == "koca" && isim2 == "kari")
        {
            HappyActivities(ortaNokta);
            return;
        }
        else if (isim1 == "kiz" && isim2 == "oglan")
        {
            HappyActivities(ortaNokta);
            return;
        }
        else if (isim1 == "oglan" && isim2 == "kiz")
        {
            HappyActivities(ortaNokta);
            return;
        }
        else if (isim1 == "isci" && isim2 == "patron")
        {
            HappyActivities(ortaNokta);
            return;
        }
        else if (isim1 == "isci" && isim2 == "isci")
        {
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
        Instantiate(happyPrefab, ortaNokta+ new Vector3(0,3,0), Quaternion.identity);
        GameController.instance.IncreaseScore();
        GameController.instance.cozulenPuzzle++;
        UIController.instance.SetProgressBar();
        GameController.instance.ControlEkipBosMu();
    }


}
