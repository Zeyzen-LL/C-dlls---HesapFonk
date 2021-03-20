using System;
using System.Reflection;

namespace hesaplama{
    public class hesaplama{
        public double Hesaplama(double x){
            //(2 + x) * (x - 3)
            string adres = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            double sonuc = 0;
            var bolmeDllAdresi = Assembly.LoadFile(adres + @"\bolme.dll").GetType("bolme.bolme");
            var getBolme = Activator.CreateInstance(bolmeDllAdresi);
            var bolmeFonk = bolmeDllAdresi.GetMethod("Bolme");

            var toplamaDllAdresi = Assembly.LoadFile(adres + @"\toplama.dll").GetType("toplama.toplama");
            var getToplama = Activator.CreateInstance(toplamaDllAdresi);
            var toplamaFonk = toplamaDllAdresi.GetMethod("Toplama");
            var a = (double)toplamaFonk.Invoke(getToplama, new object[] { 2, x });

            var cikarmaDllPathAdresi = Assembly.LoadFile(adres + @"\cikarma.dll").GetType("cikarma.cikarma");
            var getCikarma = Activator.CreateInstance(cikarmaDllPathAdresi);
            var cikarFonk = cikarmaDllPathAdresi.GetMethod("Cikarma");
            var b = (double)cikarFonk.Invoke(getCikarma, new object[] { x, 3 });

            var carpmaDllAdresi = Assembly.LoadFile(adres + @"\carpma.dll").GetType("carpma.carpma");
            var getCarpma = Activator.CreateInstance(carpmaDllAdresi);
            var carpmaFonk = carpmaDllAdresi.GetMethod("Carpma");
            sonuc = (double)carpmaFonk.Invoke(getCarpma, new object[] { a, b });

            return sonuc;
        }
    }
}
