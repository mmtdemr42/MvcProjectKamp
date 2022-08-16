# MvcProjectKamp
![image](https://user-images.githubusercontent.com/89140860/184127577-4dc63577-c4df-420a-a418-9dcefdc47be4.png)
<h1>ASP .NET MVC NEDİR?</h1>
Asp .Net Mvc web teknolojilerinde büyüyen projelerden ve yazılan kod sayılarının artması sebebiyle kodların daha okunaklı ve düzenli bir şekilde yazılabilmesi amacıyla 2007 yılında ortaya çıkmıştır.

<h3>Yeni bir Proje Oluşturma</h3>
 Visyal Studio açılır Create New Project>Asp .Net MVC(.Net Framework) seçilir, projenin ismi ve bilgisayarda depolanacağı alan seçilerek proje oluşturulur. Oluşturulan projenin klasör yapısı aşağıdaki gibidir.

![Mvc](https://user-images.githubusercontent.com/89140860/184851699-cb135610-92e9-4c93-86fb-9412c8f12180.png)

1. App_Data: Uygulamanın database yedeklerinin tutulduğu klasördür.
2. AppStart: Uygulamanın başlangıç konumlarının belirlendiği klasördür.
3. Content: Bootstarp, css gibi front-end kısmını ilgilendiren yapıların bulunduğu klasördür.
4. Controllers: Controllerların tanımlandığı klasördür.
5. Fonts: Uygulamada kullanılan yazı türlerinin tanımlandığı klasördür.
6. Models: Model veri tiplerimizi oluşturduğumuz klasördür.
7. Scripts: Javascript kütüphanelerinin olduğu klasördür.
8. Views: Arayüzlerin olduğu (.cshtml) klasördür.
9. favicon.ico: Uygulamanın iconunu barındıran kısımdır.
10. Global.asax: Tüm uygulamayı ilgilendiren işlemlerin yapıldığı kısımdır. Authorized gibi.
11. Web.config: Database, error, gibi uygulamayla ilgili bağlantıların yapılacağı kısımdır.

<h6>Biz burada daha çok Model, View ve Controller klasörlerini ele alacağız.</h6> 

<h3>Model-View-Controller</h3>
<strong>Model</strong>: Veritabanı ile bağlantılarımızı sağlayan kısımdır.<br/>
<strong>View</strong>: Ekranı yani görünümün sağlandığı kısımdır.<br/>
<strong>Controller</strong>: Kullanıcıdan gelen istekleri karşılayan ve bu isteklere göre gerekli işlemlerin yapılarak View'a yansıtılmasını sağlayan kısımdır. Controller sınıfından 
inheritance alır. İçerisinde yer alan ActionResult methotları sayesinde istekleri karşılar. İsteği karşılayan contoller gelen isteğe göre işlemleri yapar ve geriye View döndürür.
<br/>

![image](https://user-images.githubusercontent.com/89140860/184472183-414e8e2a-2397-4b56-956e-d55e7854fc88.png)


 Geriye göndürülen View .cshtml uzantılıdır. .cshtml uzantılı View sayesinde dinamik olarak almış olduğumuz verileri statik olarak html formatına çevirmemizi sağlar.
 Controllers kalsörünü altına tanımlanan her Controller için View klasörünün altında Controllerla aynı isimde bir tane klasör oluşturulur. Bu klasörde bu contollere ait view sayfaları bulunur. View kalsöründe başalangıçta ise 2 adet klasör 1 adet _ViewStart dosyası oluşturularak gelir. Klasörlerden ilki Shared klasörüdür. Bu klasörün içerisinde birden fazla View tarafından kullanılan sayfa yapıları bulunur. Bunlardan en önemlileri ise Layout dediğimiz yapıdır. İkinci klasör ise Home klasörüdür, bu klasörde ise uygulamanın anasayfası oluşurulur, bu istenildiği zaman App_Start klasörünün altında bulunan Route.config dosyasından defaulta istenen dosya ismi verilerek değiştirilebilir. _ViewStart dosyası ise default layoutun hangisinin olacağının tanımlandığı dosyadır.
 
  <h3>View Nedir ve Nasıl Tanımlanır?</h3>
 View arayüzdür. Her controller için Views klasörünün altında controllerla aynı isimde bir klasör oluşturulur. Controllerın içinde yer alan ActionMethodlarından Viewları getirmekle görevli olanlar için ActionMethod ismiyle aynı olan ActionResult türünde View dönen bir method tanımlanır. Bu View'e sağ tıklanır, AddViewe tıklandıktan sonra gelen pencerede <strong>Layout</strong> seçimi yapılır ve View oluşturulur. View'ın ana amacı gelen verileri ekrana yansıtmaktır. Bu yansıtacağı veri türünü de model olarak alması gerekmektedir. Her View sadece bir tane model alabilmektedir.Bu model veritabanındaki sınıfla aynı olabilir fakat birden fazla sınıf kullanılması ya da birden fazla bilgi aktarılması gereken durumlarda ViewBag yapısı ya da multiple objects in model yapısı kullanılabilir. 
 <a href="https://github.com/mmtdemr42/MvcProjectKamp/blob/main/MvcProjectKamp/Views/WriterMessage/GetByMessage.cshtml">Viewda Model Kullanımı</a>
 
 <h3>Layout Nedir?</h3>
 Web sayfalarında sayfalar değişse bile değişmeyen yerlerin sadece bir yerde tanımlanarak kullanmamıza olanak sağlayan yapıdır. Bu yapı kod tekrarının azaltılmasına, kod okunabilirliğinin artmasına ve yapılacak hataların önüne geçilmesine olanak sağlar.
 
  <h3>Layout Nasıl Kullanılır?</h3>
  Layoutun ortak bir dil oluşturmak amacıyla ~/Views/Shared/_Layout.csthtml şeklinde tanımlanması önerilmektedir. Proje oluşturulurken otomatik olarak(css, bootstrap, jquary gibi kütüphanelerinide tanımlayarak) bu yapı oluşur. Burada tanımlanan Layout diğer sayfalarda nereden Layout alacağını tanımlamasak bile defult olarak bu Layoutu temel olarak alır. (Layout kullanmak istemezsek kullanmak istemediğimiz .cshtml uzantılı dosyanın en başına @{Layout=null;} kodunu eklememiz gerekmektedir.)
Birden fazla sayfada kullanılırken değişecek olan yerler için <strong>@RenderBody()</strong> komutu değişmesini istediğimiz yere yazılır. Kısaca RenderBody diğer sayfalarda değişecek olan alanı temsil eder. Diğer sayfalarda html iskeletini tekrar yazıp css gibi frontend elemanlarını tekrar tanımlamak yerine sadece o sayafada değişecek olan alan için kod yazılır. Bu da bizi kod tekrarından kurtarır ve kodu düzenlememizi kolaylaştırır.

 <h3>Razor Nedir?</h3>
 C# konutlarını html iskeletinde kullanmamıza olanak sağlar.
 
 Örneğin: 
 
 ![image](https://user-images.githubusercontent.com/89140860/184867830-dabe24a8-af7f-4acf-8856-33faeed3eed8.png)
 
 Viewlerin içindeki yapılar razor sayesinde dinamik hale getirlir.
<h3>Section Nedir?</h3>
Laytoutu dinamik hale getirmek amacıyla kullanılır. Layoutu bazı yerlerde col-md-8 ve col-md-4 bazı yerlerde işse col-md-12 olarak kullanmak istediğimiz zaman kullandığımız yapıdır. Section ile işaretlediğimiz yere Sectiondan gelen veriler diğer yere ise RenderBodyden gelen veriler aktarılmış olur.

Layoutta kullanımı:

![image](https://user-images.githubusercontent.com/89140860/184934531-ad5506b1-5a21-4dcb-96ca-a53a917e9234.png)

Viewda tanımlaması:

![image](https://user-images.githubusercontent.com/89140860/184934754-ffeccaef-9921-4ddb-b547-a5e737a208a0.png)




 
 <h3>Partial View Nedir?</h3>
Parçalayarak modelleme anlamına gelir. Layout sayesinde sayfa bazında tanımlamayabiliyoruz. PartialView sayesinde ise birden fazla sayfada kullanılan yapıları bir yerde tanımlayıp Html helper komutları sayesinde diğer yerlerde de kullanmamıza olanak sağlar.

<h3>Partial View Nasıl Kullanılır?</h3>
Controller içinde ActionResult dönen method yerine PartialViewResult dönen bir method yazılır. Bu method View yerine PartialView döndürür. PartialView'ın üzerine gelinir sağ tıklanır ve Add Viewe tıklanır. Gelen sayfada create partial view seçilir ve partial view tanımlanmış olur. Viewlarda olduğu gibi partialView sayfasının da bir tane model alması gerekmektedir. Bir örneğine aşağıdan ulaşabilirsiniz.

 <a href="https://github.com/mmtdemr42/MvcProjectKamp/blob/main/MvcProjectKamp/Controllers/WriterMessageController.cs">Örnek Controller</a>
 
![image](https://user-images.githubusercontent.com/89140860/184889246-98a4795b-e565-4213-9791-7d7d24f29bdc.png)
 
 <a style="color:red;" href="https://github.com/mmtdemr42/MvcProjectKamp/blob/main/MvcProjectKamp/Views/WriterMessage/Index.cshtml">Örnek View</a>

![image](https://user-images.githubusercontent.com/89140860/184889622-c9c072bb-165c-4347-8072-7d18b4f520b2.png)


<h3>Model Nedir?</h3>
Viewe yönlendirilecek verilerin ya da veritabanına yapılacak olan kayıtların paketlenmesi amacıyla kullanılır. Viewe bir tane veri seti gönderilecekse @model Models.model şeklinde gönderilir. Birden fazla gönderilecekse bu yöntem kullanılmaz o zaman multiple object in model yapısı kullanılır.

<h3>Multiple Objects In Model Nedir?</h3>
Viewe birden fazla dataseti gönderilecekse bu yapı kullanılır. Birtane model sınıfı tanımlanır ve bu model sınıfıana gerekli sınıflar liste şeklinde property olarak tanımlanır. Viewde de bu model çağırılır, @model Models.ÇokluModelAdı şeklinde viewe model olarak verilir.

 <h1>HTTP Protokolü</h1>
 1990 yılından beri dünya çapında ağ üzerinde kullanılan bir iletişim protokolüdür. HTTP‘nin açılımı “Hyper Text Transfer Protocol” yani “Hiper Metin Transfer Protokolü“dür. HTTP protokolü ağ üzerinden web sayfalarının görüntülenmesini sağlayan protokoldür. HTTP protokolü istemci (PC) ile sunucu (server) arasındaki alışveriş kurallarını belirler. Port olarak ise 80 portunu kullanır. İstemci sunucuya bir istek gönderir. Bu istek Internet Explorer, Google Chrome veya Mozilla Firefox gibi web browser’lar aracılığıyla iletilir. Sunucu bu isteği alır ve Apache veya IIS gibi web sunucu programları aracılığıyla cevap verir.

<h3>Http Methotları</h3>
1. HttpGet => Okuma <br/>
2. HttpPost => Kayıt Etme<br/>
3. HttpPut => Güncelleme<br/>
4. HttpDelete => Silme <br/>
Bu işlemlerin tamamına CRUD işlemler adı verilir.


ActionMethotlarda Get methodu View okuma amcıyla kullanılır Viewde bir arama, kayıt işlemi olması halinde post işlemi kullanılır. Formun doldurulabilmesi için ilk önce sayfanın yüklenmesi gerekir bundan dolayı da HttpGet methodunun, sayfadaki formu doldurduktan sonra ise post methodunun çalışması gerekir bundan dolayı da kayıt işemleri gibi post gerektiren işlemlerde sayfa yüklenmesi için get formun kayıt edilebilmesi içinse post methodu gerekmektedir. 

![image](https://user-images.githubusercontent.com/89140860/184937744-df06da50-b356-41ff-bb61-7c96100adf8c.png)

Aynı durum güncellem işlemi için de geçerlidir. İlk önce güncellenmek istenen veri ekrana getirilmeli daha sonra değişiklikler yapılınca veri kayıt edilmelidir. Yukardaki gibi burada da hem get hem de post methodunun yazılması gerekmektedir.

![image](https://user-images.githubusercontent.com/89140860/184938116-7936959b-9b52-4757-8392-b79384d806b9.png)

Form Oluşturma Örneği:

![image](https://user-images.githubusercontent.com/89140860/184939907-5f81482e-a660-4fd6-aa84-2847b103474c.png)

1. Html.ValidationSummary() => Veri girişinde bir hata olamsı halinde kullanıcıyı bilgilendirme amacıyla kullanılır.
2. Html.BeginForm => Form tanımlama amacıyla kullanılır. Html.BeginForm("ActionMethodAdı", "ControllerAdı", FormMethod.işlemegöre(post, get...))
3. Html.AntiForgeryToken() => üretilen bir key actionmethoda gönderilir ve güvenlik açısından önemlidir.
4. Html.Label => Label tanımlamak amacıyla kullanılır.
5. Html.TextBoxFor => Tek satırlık veri girişi için kullanılır, inputta kullanılabilir.
6. Html.TextAreaFor => Birden fazla satırlık veri girişi için kullanılır.
7. Html.ValidationMessageFor(x => x.CategoryDescription) => CategoryDescription'a ait veri girişinde hata olması halinde kullanıcıya bilgi vermesi amacıyla kullanılır.
8. Html.ActionLink => Sayfalar arası geçiş amacıyla kullanılır: 

![image](https://user-images.githubusercontent.com/89140860/184941245-93a11d00-3dba-4ce6-9bee-32fc47ee7034.png)

<h4>Form İşlemleri Özet:</h4>
1. Get methodu ile sayfa yüklenir.
2. Form tanımlanır.
3. Formun kaydet düğmesine basıldığı zaman post işlemi çağrılır bu action methoda biligiler paketlenerek gönderilir.
4. Hata olmaması halinde kayıt işelmi gerçekleşir.
5. Kullanıcı listeleme sayfasına yönlendirilir.

<h3>Model Binding Nedir?</h3>
Formdan paketlenerek gelen bilgiler viewe verilen modele göre yapılır kayıt işemi de buna göre yapılır. Bu olaya model binding denir. Güncelleme işlemlerinde farklı model tanımlayarak sadece güncellenecek yerler verilerek buna göre bir işlem yapılabilir.

