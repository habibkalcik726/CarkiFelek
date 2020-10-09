using CarkiFelek.Model;
using CarkiFelek.Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarkiFelek
{
    class Program
    {
        static void Main(string[] args)
        {
            RandomGift();
        }

        /// <summary>
        /// Select a point from db randomly
        /// </summary>
        /// <returns></returns>
        private static DTOPoint RandomPoint()
        {

            using (DatabaseContext db = new DatabaseContext())
            {

                var rnd = new Random();
                var pointList = db.Points.ToList();

                var convertedPoints = new List<DTOPoint>(pointList.Count);
                var pointPossibilitySum = 0.0;
                foreach (var item in pointList.Take(pointList.Count))
                {
                    pointPossibilitySum += Convert.ToDouble(item.Possibility) / 100;
                    convertedPoints.Add(new DTOPoint { Possibility = pointPossibilitySum, PointScore = item.PointScore });
                }
                //convertedPoints.Add(new DTOPoint { Possibility = 1.0, PointScore = pointList.Last().PointScore });

                var pointPossibility = rnd.NextDouble();
                var selectedPoint = convertedPoints.SkipWhile(i => i.Possibility < pointPossibility).First();

                return selectedPoint;
            }
        }

        /// <summary>
        /// selects Gifts from db randomly and prints the selected gift and its point.
        /// </summary>
        private static void RandomGift()
        {

            using (DatabaseContext db = new DatabaseContext())
            {
                var giftList = db.Gifts.ToList();

                var convertedGifts = new List<DTOGift>(giftList.Count);
                var giftPossibilitySum = 0.0;
                foreach (var item in giftList.Take(giftList.Count))
                {
                    giftPossibilitySum += Convert.ToDouble(item.Possibility) / 100;
                    convertedGifts.Add(new DTOGift { Possibility = giftPossibilitySum, GiftName = item.GiftName, CanGetPoint = item.CanGetPoint });
                }
                //convertedGifts.Add(new DTOGift { Possibility = 1.0, GiftName = giftList.Last().GiftName });

                var rnd = new Random();

                while (true)
                {
                    var giftPossibility = rnd.NextDouble();
                    var selectedGift = convertedGifts.SkipWhile(i => i.Possibility < giftPossibility).First();


                    if (selectedGift.CanGetPoint)
                    {

                        var selectedPoint = RandomPoint();
                        Console.WriteLine($"Selected item = {selectedGift.GiftName}, Point = {selectedPoint.PointScore}");
                    }
                    else
                    {
                        Console.WriteLine($"Selected item = {selectedGift.GiftName}");

                    }
                }

                //Random rnd = new Random();

            }


        }

        /// <summary>
        /// Get Summary from News
        /// </summary>
        /// <param name="newText"></param>
        /// <returns></returns>
        private static string GetSummary(string newText)
        {

//            newText = "Korona günlerinde arabalı sinema keyfi.  " +
//"İzmir Büyükşehir Belediyesi, 15 Mayıs Cuma günü açık havada sinema gösterimi yapacak. Altı noktada eşzamanlı " +
//"olarak 'Bayi Toplantısı' filminin gösterileceği etkinlikte vatandaşlara maske dağıtılacak ve gösterimin yapılacağı " +
//"alanda yurttaşların araçlarından inmelerine izin verilmeyecek. " +
//"Koronavirüs önlemleri nedeniyle sinemaya gidemeyen İzmirliler, İzmir Büyükşehir Belediyesinin düzenlediği " +
//"yapılacak. Bostanlı, Üçkuyular, Fuar İzmir, Bornova Aşık Veysel Rekreasyon Alanı Buz Pisti yanı, Buca ve Çiğli’de " +
//"nostaljik arabalı sinema etkinliğinde buluşacak. Film gösterimi 15 Mayıs Cuma günü altı noktada eşzamanlı " +
//"kurulacak dev perdede yönetmenliğini Bedran Güzel'in yaptığı 'Bayi Toplantısı' filmi ücretsiz gösterilecek. " +
//"Sinemaseverler arabalarından inmeden güvenli bir şekilde sinema keyfi yaşayacak. Başrollerini İbrahim Büyükak, " +
//"Onur Buldu, Doğu Demirkol'un paylaştığı, mecburen katıldıkları bayi toplantısında kendilerini birbirinden eğlenceli " +
//"maceraların içinde bulan üç beyaz eşya satıcısının hikayesini konu eden film 21.00'da başlayacak. Filmin sesi radyo " +
//"frekansı üzerinden arabalardan dinlenebilecek. 2 saat sürecek film gösterimi sırasında izleyicilere patlamış mısır ve " +
//"gazoz da ikram edilecek. " +
//"Kayıtlar 11 Mayıs'ta başlıyor. " +
//"Belirli sayıda otomobilin girişine izin verilecek etkinliğe katılmak isteyen İzmirliler 11 Mayıs Pazar akşamı saat " +
//"21.00'dan itibaren www.arabalisinema.com.tr adresinden kayıt yaptırması gerekiyor. Kayıt yaptıran ilk 750 araç " +
//"sahibi etkinliğe katılım hakkı kazanacak. İstenilen bölgedeki arabalı sinema etkinliğinin kontenjanın dolması halinde " +
//"katılımcılar kendilerine en yakın bölgedeki arabalı sinema etkinliğine yönlendirilecek.Etkinlik günü katılım hakkı " +
//"kazanmış ve listeye alınmış kişilerin araçlarıyla arabalı sinema etkinliğinin yapıldığı alana girişine izin verilecek. " +


//"Gösterimin yapıldığı alana girdikten sonra vatandaşların araçlardan çıkılmasına izin verilmeyecek.";



            //haber texti ". " 'a göre cümlelere ayrılıp listelenir 
            var list = newText.Split(new string[] { ". " }, StringSplitOptions.None).ToList();
            //cities.Add(String.Concat(Regex.Replace(city, "([a-zA-Z])([a-zA-Z]+)", "$1").ToUpper(System.Globalization.CultureInfo.InvariantCulture), Regex.Replace(city, "([a-zA-Z])([a-zA-Z]+)", "$2").ToLower(System.Globalization.CultureInfo.InvariantCulture)));

            //ilk cümle çekilir, kelimelere split edilir.
            var headersItems = list[0].Split(' ').ToList();

            var summary = new List<string>();

            //var allApproved = newText.All(word => headersItems.Contains(word));


            //ilk cümlenin yani başlığın kelimelerinden en az iki tanesinin geçtiği bir cümle olursa özete aktarılır.
            foreach (var item in list.Skip(1))
            {
                var itemCont = 0;
                foreach (var subitem in headersItems)
                {
                    if (item.Contains(subitem))
                    {
                        itemCont++;
                        if (!summary.Contains(item) && itemCont > 1)
                        {
                            summary.Add(item);
                            break;
                        }
                    }
                }


            }

            var sum = summary.Distinct().ToList().Skip(1).Aggregate((i, j) => i +". "+ j);
            return sum;
        }
    }
}
