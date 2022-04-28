using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeniOku : MonoBehaviour
{
    /*
    ---------------------------------- DINNER PUZZLE NOTLARI  --------------------------------------------------
    * KARAKTERLER ...
    * Karakterler bos bir gameobje icerisinde child olarak eklenecek. Parent objeye herhangi bir tag veya komponent eklenmeyecek.
    * 
    * Karakterler   Assets\Prefabs\Ekipler  klasoru icerisinde verilen duzenlerde olmali. 
    * 
    * Karakterlerin her birinde colider, rigidbody, script veya tag gibi ozellikleri mutlaka Ekipler klasorundeki ornek karakterler gibi
    * duzenlenmeli
    * 
    * Tum karakterlerin tagleri drag olacak. !!!
    * 
    * Karakterlerin scriptleri icerisinde (inspectorda) karakterin ismi, tipi ve verecegi tepki efektleri karaktere ozel
    * ayarlanabilir.
    * 
    * isim ve tip kodun duzgun calisabilmesi icin onemli. Eklenecek her yeni karakter icin developera bilgi verilip 
    *  kod uzerinde ufak duzenlemeleri tamamlamasi istenmeli. isim degiskenleri kucuk harfle yazilmali. Type lar integer
    *  asagida type lar listeleniyor. Gozat.
    *  
    *  
    *  
    *  MASALAR ....
    *  Masa duzenlemeleri Assets\Prefabs\MasaTakimlari klasorunde yer aldigi gibi duzenlenmeli. Masanin bir onemi yok onemli olan
    *  sandalyelerimiz. 
    *  
    *  Sandalyelere orneklerde oldugu gibi script ve diger komponentler eklenmeli. Burada scriptin ayari onemli. Her sandalyenin iki 
    *  komsusu olmasi gerekmektedir. Masalarin durumlarina göre sag - sol veya karsilikli olarak sandalyeler komsu eklenebilir.
    *  Bu komsuluk meselesi karakterlerin dogru yerlerde olup olmamasýný etkilemektedir. Bu ayarlar inspektor uzerinden yapýlacak.
    *  
    *  Hem sandalye hem de karakter scriptinde type degiskeni bulunmaktadir. Bu degisken ozel bir karakterin ozel bir sandalyeye
    *  oturmasi gerektigi senaryolarda kullanilacak. Hem ozel karakter hem de sandalye type'i ayni sayi girilmeli. Default type 0.
    *  Ornegin bir patronu masanýn basindaki sandalyeye oturtmak veya kedinin kedi kabina kopegin kopek kabina yerlesmesini saglamak 
    *  veya bunlarin kontrolunu saglamak icin type degiskeni onemlidir.
    *  
    *  LEVELCONTROLLER AYARLARI .....
    *  
    *  
    *  
    *  OZEL TYPE LAR  (Her ozel type buraya eklenirse designer ve developer arasi koordinasyon daha guzel saglanacaktir.)
    *  (Sayilarin ne oldugu onemlidir. Buyukluk kucuklugu onemli degildir.)
    *  0 - Default : single karakterler, aileler, ciftler, calisanlar icin kullanilabilir.
    *  1 - Patron gibi statu olarak ekibinden ustun olan karakterler icin kullanilacak.
    *  2 - Kedi 
    *  3 - Kopek
    *  4 - Singlelar   etkisiz
    *  5 - ebe
    *  6 - dede
    *  7 - kodcular
    *  8 - sekreterler
    *  9 - sanatcilar
    *  
    *  
    * 



    -------------------------------  TEMPLATE NOTLARI   --------------------------------------------------
    => score : Oyuncunun aktif levelde aldigi score , totalScore : Oyuncunun levellerde aldigi skorlarin toplami.
    bu score GameController da tutulurken, totalScore playerprephfs ile tutuluyor. Farkli oyunlarda farkli isler
    icin kullanilabilirler. Ornegin score degil para birikiyorsa para olarak dusunun. Elmas icin farklý degiskenler
    tanimlanacak. 

    => elmas : Oyuncunun aktif levelde aldigi elmaslar, totalElmas : Oyuncunun levellerde aldigi elmaslarin toplami
    Bu ikisini ekliyoruz. Ancak gerekli olan kullanilir gerekli olmayan kullanilmaz. Yine degiskenlerin tutuldugu yerler
    score ile ayni. elmas yerine farkli collectiblelar da kullanildiðinda yine elmas ismiyle tutulacaktir. Leveldeki elmas 
    sayisi icin bir text ui koymadik simdilik. Total elmas icin var. Gerekli gorulurse elmas da eklenir.
     
     
    =>isContinue : bu bool degiskeni ile oyunun aktif olup olmadigi kontrol ediliyor. Oyuncu fail durumunda ya da
    finishe ulastiginda bu degisken false yapilacak. Oyuncu ilerlerken true yapilacak. Baska kontrollerde de kullanýlabilir.

    => instance : bu degisken her classta sadece bir ornek olusturmak icin yani singleton yapisi icin kullaniliyor.
    Bir classtan public bir degiskene veya fonksiyona ulasmak icin class isminden sonra bu yazilip sonra degisken 
    veya fonksiyon ismi yazilacak ORNEK KULLANIM : UIController.instance.SetScore()  gibi...

    => Singleton yapisi sayesinde player scriptine, ui scriptine veya herhangi bir scripte kendinizin ekleyeceginiz 
    public fonksiyonu veya degiskeni diger scriptler icerisinden yukaridaki ornek kullanimda oldugu gibi cagirip calistirabilirsiniz.
     

    => Oyunlarda collectiblelara çarpýnca oluþacak olan score artýþýnýn deðeri inspektörde PlayerController dan ayarlanacak.
     
     
     */
}
