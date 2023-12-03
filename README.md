# RehberApp
proje 3 app içeriyor,
raporApp ve asenkron rapor talepleri  durumları görülecek ConsoleApp.
swagger üzerinden işlemler gerçekleştirilir.
raporApp için docker kuruldu ve rabbıt mq ile asenkron durumları görebilmek için kuyruk yapısı oluşturuldu.
consoleapp' de ise kuyruga atılan rapor durumları okunur.

## rapor talebi için girilmesi gereken parametreler bilgi tipi : konum => burada bilgi tipleri getlist methotundan konum 
bilgi tipinin id'si ve talep olunacak konum içeriği (örn: kayseri) girilmelidir, girilen parametrelere göre rehber servisine client ile baglanıp  rapor oluşturur ve rapor bilgilerini resutl'ta kullanıcıya sunar. bu sırada rapor talebi gerçekleştiğinde kuyruga hazırlanıyor ve rapor sonucu geldıgınde  kuyruga tamamlandı mesajı atar

## cosoleApp te ise kuruk mesajlarını görüntüleyebiliriz.
