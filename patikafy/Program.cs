
namespace SanatciListesi
{
    class Sanatci
    {
        public string AdSoyad { get; set; }
        public string MuzikTuru { get; set; }
        public int CikisYili { get; set; }
        public int AlbumSatislari { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Sanatci> sanatcilar = new List<Sanatci>
            {
                new Sanatci { AdSoyad = "Ajda Pekkan", MuzikTuru = "Pop", CikisYili = 1968, AlbumSatislari = 20000000 },
                new Sanatci { AdSoyad = "Sezen Aksu", MuzikTuru = "Türk Halk Müziği / Pop", CikisYili = 1971, AlbumSatislari = 10000000 },
                new Sanatci { AdSoyad = "Funda Arar", MuzikTuru = "Pop", CikisYili = 1999, AlbumSatislari = 3000000 },
                new Sanatci { AdSoyad = "Sertab Erener", MuzikTuru = "Pop", CikisYili = 1994, AlbumSatislari = 5000000 },
                new Sanatci { AdSoyad = "Sila", MuzikTuru = "Pop", CikisYili = 2009, AlbumSatislari = 3000000 },
                new Sanatci { AdSoyad = "Serdar Ortaç", MuzikTuru = "Pop", CikisYili = 1994, AlbumSatislari = 10000000 },
                new Sanatci { AdSoyad = "Tarkan", MuzikTuru = "Pop", CikisYili = 1992, AlbumSatislari = 40000000 },
                new Sanatci { AdSoyad = "Hande Yener", MuzikTuru = "Pop", CikisYili = 1999, AlbumSatislari = 7000000 },
                new Sanatci { AdSoyad = "Hadise", MuzikTuru = "Pop", CikisYili = 2005, AlbumSatislari = 5000000 },
                new Sanatci { AdSoyad = "Gülben Ergen", MuzikTuru = "Pop / Türk Halk Müziği", CikisYili = 1997, AlbumSatislari = 10000000 },
                new Sanatci { AdSoyad = "Neşet Ertaş", MuzikTuru = "Türk Halk Müziği / Türk Sanat Müziği", CikisYili = 1960, AlbumSatislari = 2000000 }
            };

            // Adı 'S' ile başlayan şarkıcılar
            var sIleBaslayanlar = sanatcilar.Where(s => s.AdSoyad.StartsWith("S")).ToList();
            Console.WriteLine("Adı 'S' ile başlayan şarkıcılar:");
            foreach (var sanatci in sIleBaslayanlar)
            {
                Console.WriteLine(sanatci.AdSoyad);
            }

            // Albüm satışları 10 milyon'un üzerinde olan şarkıcılar
            var yuksekSatislilar = sanatcilar.Where(s => s.AlbumSatislari > 10000000).ToList();
            Console.WriteLine("\nAlbüm satışları 10 milyon'un üzerinde olan şarkıcılar:");
            foreach (var sanatci in yuksekSatislilar)
            {
                Console.WriteLine(sanatci.AdSoyad);
            }

            // 2000 yılı öncesi çıkış yapmış ve pop müzik yapan şarkıcılar
            var eskiPopcular = sanatcilar
                .Where(s => s.CikisYili < 2000 && s.MuzikTuru.Contains("Pop"))
                .OrderBy(s => s.CikisYili)
                .ThenBy(s => s.AdSoyad)
                .ToList();
            Console.WriteLine("\n2000 yılı öncesi çıkış yapmış ve pop müzik yapan şarkıcılar:");
            foreach (var sanatci in eskiPopcular)
            {
                Console.WriteLine($"{sanatci.AdSoyad} - {sanatci.CikisYili}");
            }

            // En çok albüm satan şarkıcı
            var enCokSatan = sanatcilar.OrderByDescending(s => s.AlbumSatislari).First();
            Console.WriteLine($"\nEn çok albüm satan şarkıcı: {enCokSatan.AdSoyad}");

            // En yeni çıkış yapan şarkıcı ve en eski çıkış yapan şarkıcı
            var enYeni = sanatcilar.OrderByDescending(s => s.CikisYili).First();
            var enEski = sanatcilar.OrderBy(s => s.CikisYili).First();
            Console.WriteLine($"\nEn yeni çıkış yapan şarkıcı: {enYeni.AdSoyad} - {enYeni.CikisYili}");
            Console.WriteLine($"En eski çıkış yapan şarkıcı: {enEski.AdSoyad} - {enEski.CikisYili}");
        }
    }
}