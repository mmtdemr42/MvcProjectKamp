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
 Controllers kalsörünü altına tanımlanan her Controller için View klasörünün altında Controllerla aynı isimde bir tane klasör oluşturulur. Bu klasörde bu contollere ait view sayfaları bulunur. View kalsöründe başalangıçta ise 2 adet klasör 1 adet _ViewStart dosyası oluşturularak gelir. Klasörlerden ilki Shared klasörüdür. Bu klasörün içerisinde birden fazla View tarafından kullanılan sayfa yapıları bulunur. Bunlardan en önemlileri ise Layout dediğimiz yapıdır.
 
 <h3>Layout Nedir?</h3>
 Web sayfalarında sayfalar değişse bile değişmeyen yerlerin sadece bir yerde tanımlanarak kullanmamıza olanak sağlayan yapıdır. Bu yapı bize kod tekrarını azaltmamızı, kod okunabilirliğinin azaltılmasına ve yapılacak hataların önüne geçmemize olanak sağlar.
 
  <h3>Layout Nasıl Kullanılır?</h3>
  Layoutun ortak bir dil oluşturmak amacıyla ~/Views/Shared/_Layout.csthtml şeklinde tanımlanması önerilmektedir. Proje oluşturulurken otomatik olarak(css, bootstrap, jquary gibi kütüphanelerinide tanımlayarak) bu yapı oluşur. 



