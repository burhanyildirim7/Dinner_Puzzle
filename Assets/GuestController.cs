using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GuestController : MonoBehaviour
{
	bool oturdu;
	Vector3 firstPosition;
	public string isim;

	private void Start()
	{
		firstPosition = transform.position;
	}


	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("sandalye") && !other.GetComponent<SandalyeController>().dolu)
		{		
			Debug.Log("saldayle");
			oturdu = true;
			transform.parent = other.transform;
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.CompareTag("sandalye") )
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

			transform.localPosition = Vector3.zero;
			transform.parent.GetComponent<SandalyeController>().dolu = true;
			ControlNeighBours();
		}	
		yield return new WaitForSeconds(.1f);
		if (!oturdu)
		{
			transform.parent = null;
			transform.position = firstPosition;
		}
	}

	void ControlNeighBours()
	{
		SandalyeController komsularim = transform.parent.GetComponent<SandalyeController>();
		if (komsularim.sag != null && komsularim.sag.transform.childCount > 0)
		{
			Debug.Log("buraya girdi SAG");
			ControlKisi(isim,komsularim.sag.transform.GetChild(komsularim.sag.transform.childCount -1).GetComponent<GuestController>().isim);
		}
		else if (komsularim.sol != null && komsularim.sol.transform.childCount > 0)
		{
			Debug.Log("buraya girdi SOL");
			ControlKisi(isim, komsularim.sol.transform.GetChild(komsularim.sol.transform.childCount - 1).GetComponent<GuestController>().isim);
		}
		else if (komsularim.karsi != null && komsularim.karsi.transform.childCount > 0)
		{
			Debug.Log("buraya girdi KARSI");
			ControlKisi(isim, komsularim.karsi.transform.GetChild(komsularim.karsi.transform.childCount - 1).GetComponent<GuestController>().isim);
		}
		else if (komsularim.carpraz != null && komsularim.carpraz.transform.childCount > 0)
		{
			Debug.Log("buraya girdi CARPRAZ");
			if(isim == "anne" || isim == "baba" || isim == "cocuk")ControlKisi(isim, komsularim.carpraz.transform.GetChild(komsularim.carpraz.transform.childCount - 1).GetComponent<GuestController>().isim);
		}
		else
		{		
			if (!GameController.instance.masaDolu)
			{
				Debug.Log("masada kimse yok mu yoksa kontrol yapmalýyýz..");
				GameController.instance.masaDolu = true;
				return;
			}
			else
			{
				Debug.Log("üzüyorsun beni");
			}
		}

	}

	void ControlKisi(string isim1 , string isim2 )
	{
		if (isim1 == "anne" && isim2 == "baba")
		{
			Debug.Log("merhaba kocacým saðýmdasýn");
			return;
		}
		else if (isim1 == "baba" && isim2 == "anne")
		{
			Debug.Log("merhaba merhaba karýcým saðýmdasýn");
			return;
		}
		else if (isim1 == "baba" && isim2 == "cocuk")
		{
			Debug.Log("merhaba merhaba karýcým saðýmdasýn");
			return;
		}
		else if (isim1 == "anne" && isim2 == "cocuk")
		{
			Debug.Log("merhaba merhaba karýcým saðýmdasýn");
			return;
		}
		else if (isim1 == "cocuk" && isim2 == "cocuk")
		{
			Debug.Log("merhaba merhaba karýcým saðýmdasýn");
			return;
		}
		else if (isim1 == "cocuk" && isim2 == "anne")
		{
			Debug.Log("merhaba merhaba karýcým saðýmdasýn");
			return;
		}
		else if (isim1 == "cocuk" && isim2 == "baba")
		{
			Debug.Log("merhaba merhaba karýcým saðýmdasýn");
			return;
		}
		else if (isim1 == "kari" && isim2 == "koca")
		{
			Debug.Log("merhaba merhaba karýcým saðýmdasýn");
			return;
		}
		else if (isim1 == "koca" && isim2 == "kari")
		{
			Debug.Log("merhaba merhaba karýcým saðýmdasýn");
			return;
		}
		else if (isim1 == "isci" && isim2 == "isci")
		{
			Debug.Log("merhaba merhaba karýcým saðýmdasýn");
			return;
		}
		else if (isim1 == "isci" && isim2 == "patron")
		{
			Debug.Log("merhaba merhaba karýcým saðýmdasýn");
			return;
		}
		else if (isim1 == "patron" && isim2 == "isci") // burasda kral koltuðu kontrolü yapýlacak...
		{
			Debug.Log("merhaba merhaba karýcým saðýmdasýn");
			return;
		}
	}

	
}
