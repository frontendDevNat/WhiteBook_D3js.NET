using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WhiteBook.Models
{
    public class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            if (!context.Countries.Any())
            {
                context.Countries.AddRange(
                    new Country { Descr = "Россия" },
                    new Country { Descr = "Германия" }
                );
                context.SaveChanges();
            }

            if (!context.Religions.Any())
            {
                context.Religions.AddRange(
                    new Religion { Descr = "христианство" },
                    new Religion { Descr = "ислам" },
                    new Religion { Descr = "буддизм" },
                    new Religion { Descr = "иудаизм" }
                );
                context.SaveChanges();
            }

            if (!context.Confessions.Any())
            {
                Religion religion = context.Religions.SingleOrDefault(r => r.Descr == "христианство");

                if (religion != null)
                {
                    context.Confessions.AddRange(
                        new Confession { Descr = "православие", ReligionId = religion.Id},
                        new Confession { Descr = "католицизм", ReligionId = religion.Id },
                        new Confession { Descr = "протестанизм", ReligionId = religion.Id }
                    );
                    context.SaveChanges();
                }


                religion = context.Religions.SingleOrDefault(r => r.Descr == "ислам");

                if (religion != null)
                {
                    context.Confessions.AddRange(
                        new Confession { Descr = "суннизм", ReligionId = religion.Id },
                        new Confession { Descr = "шиизм", ReligionId = religion.Id },
                        new Confession { Descr = "ибадизм", ReligionId = religion.Id }
                    );
                    context.SaveChanges();
                }


                religion = context.Religions.SingleOrDefault(r => r.Descr == "буддизм");

                if (religion != null)
                {
                    context.Confessions.AddRange(
                        new Confession { Descr = "тхеравада", ReligionId = religion.Id },
                        new Confession { Descr = "махаяна", ReligionId = religion.Id },
                        new Confession { Descr = "ваджраяна", ReligionId = religion.Id }
                    );
                    context.SaveChanges();
                }


                religion = context.Religions.SingleOrDefault(r => r.Descr == "иудаизм");

                if (religion != null)
                {
                    context.Confessions.AddRange(
                        new Confession { Descr = "ортодоксальный иудаизм", ReligionId = religion.Id },
                        new Confession { Descr = "хасидизм", ReligionId = religion.Id },
                        new Confession { Descr = "реформистский иудаизм", ReligionId = religion.Id }
                    );
                    context.SaveChanges();
                }
            }

            if (!context.GermanyRegions.Any())
            {
                context.GermanyRegions.AddRange(
                    new GermanyRegion { Code = "BW", Descr = "Баден-Вюртемберг" },
                    new GermanyRegion { Code = "BY", Descr = "Свободное государство Бавария" },
                    new GermanyRegion { Code = "BE", Descr = "Берлин" },
                    new GermanyRegion { Code = "BB", Descr = "Бранденбург" },
                    new GermanyRegion { Code = "HB", Descr = "Свободный ганзейский город Бремен" },
                    new GermanyRegion { Code = "HH", Descr = "Свободный и ганзейский город Гамбург" }
                    );
                context.SaveChanges();                
            }

            if (!context.GermanyCities.Any())
            {
                context.GermanyCities.AddRange(
                    new GermanyCity { Descr = "Штутгарт", GermanyRegionId = context.GermanyRegions.SingleOrDefault(g=>g.Code=="BW").Id },
                    new GermanyCity { Descr = "Мюнхен", GermanyRegionId = context.GermanyRegions.SingleOrDefault(g => g.Code == "BY").Id },
                    new GermanyCity { Descr = "Берлин", GermanyRegionId = context.GermanyRegions.SingleOrDefault(g => g.Code == "BE").Id },
                    new GermanyCity { Descr = "Потсдам", GermanyRegionId = context.GermanyRegions.SingleOrDefault(g => g.Code == "BB").Id },
                    new GermanyCity { Descr = "Бремен", GermanyRegionId = context.GermanyRegions.SingleOrDefault(g => g.Code == "HB").Id },
                    new GermanyCity { Descr = "Гамбург", GermanyRegionId = context.GermanyRegions.SingleOrDefault(g => g.Code == "HH").Id }
                );
                context.SaveChanges();
            }


            if (!context.TerroristAttackTypes.Any())
            {
                context.TerroristAttackTypes.AddRange(
                    new TerroristAttackType { Descr = "Взрыв" },
                    new TerroristAttackType { Descr = "Захват" }
                );
                context.SaveChanges();
            }

            if (!context.Dangers.Any())
            {
                context.Dangers.AddRange(
                    new Danger { Descr = "1. Террористичекие атаки" },
                    new Danger { Descr = "2. Агрессивная политика" },
                    new Danger { Descr = "3. Кибератаки на систему информационной безопасности" },
                    new Danger { Descr = "4. Приток мигрантов" },
                    new Danger { Descr = "5. Рост националистически настроенных организаций" },
                    new Danger { Descr = "6. Гонка вооружений" },
                    new Danger { Descr = "7. Внешние факторы угрожающие энергетической независимости" },
                    new Danger { Descr = "8. Изменения климата" },
                    new Danger { Descr = "9. Угроза эпидемий" },
                    new Danger { Descr = "10. Рост поддержки терроризма со стороны мусульманских стран" }                    
                );
                context.SaveChanges();
            }

            if (!context.Years.Any())
            {
                for (int i = 1991; i < 2018; i++)
                {
                    Year year = new Year { Value = i };

                    context.Years.Add(year);
                }

                context.SaveChanges();
            }

        }

    }
}
