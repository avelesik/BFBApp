using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BFBApp.Models
{
    public class ExchangeData
    {
        public static List<Currencies> GetCurrencies()
        {
            List<Currencies> currencies = new List<Currencies>()
            {
                new Currencies()
                {
                    Id=1,
                    Name="рубль",
                },
                new Currencies()
                {
                    Id=2,
                    Name="доллар",
                },
                new Currencies()
                {
                    Id=3,
                    Name="евро",
                },
            };
            return currencies;
        }
        public static List<Participants> GetParticipiants()
        {
            List<Participants> Participants = new List<Participants>()
            {
                new Participants()
                {
                    Id=1,
                    Name="участник1",
                },
                new Participants()
                {
                    Id=2,
                    Name="участник2",
                },
                new Participants()
                {
                    Id=3,
                    Name="участник3",
                },
                new Participants()
                {
                    Id=4,
                    Name="участник4",
                },
                new Participants()
                {
                    Id=5,
                    Name="участник5",
                },
            };
            return Participants;
        }
        public static List<Transactions> GetTransacions(ModelExchange context)
        {
            List<Transactions> Transactionss = new List<Transactions>()
            {
                new Transactions()
                {
                    Id=1,
                    Price=1.81m,
                    Amount=5,
                    DateTime=Convert.ToDateTime("10.06.2019"),
                    Participants=context.Participants.Where(p=>p.Name=="участник1").First(),
                    Participants1=context.Participants.Where(p=>p.Name=="участник5").First(),
                    Currencies=context.Currencies.Where(p=>p.Name=="рубль").First(),
                },
                new Transactions()
                {
                    Id=2,
                    Price=3.60m,
                    Amount=3,
                    DateTime=Convert.ToDateTime("10.06.2019"),
                    Participants=context.Participants.Where(p=>p.Name=="участник1").First(),
                    Participants1=context.Participants.Where(p=>p.Name=="участник4").First(),
                    Currencies=context.Currencies.Where(p=>p.Name=="доллар").First(),
                },
                new Transactions()
                {
                    Id=3,
                    Price=5.11m,
                    Amount=10,
                    DateTime=Convert.ToDateTime("10.06.2019"),
                    Participants=context.Participants.Where(p=>p.Name=="участник2").First(),
                    Participants1=context.Participants.Where(p=>p.Name=="участник1").First(),
                    Currencies=context.Currencies.Where(p=>p.Name=="евро").First(),
                },
                new Transactions()
                {
                    Id=4,
                    Price=3.77m,
                    Amount=11,
                    DateTime=Convert.ToDateTime("15.06.2019"),
                    Participants=context.Participants.Where(p=>p.Name=="участник2").First(),
                    Participants1=context.Participants.Where(p=>p.Name=="участник3").First(),
                    Currencies=context.Currencies.Where(p=>p.Name=="доллар").First(),
                },
                new Transactions()
                {
                    Id=5,
                    Price=1.83m,
                    Amount=6,
                    DateTime=Convert.ToDateTime("15.06.2019"),
                    Participants=context.Participants.Where(p=>p.Name=="участник4").First(),
                    Participants1=context.Participants.Where(p=>p.Name=="участник1").First(),
                    Currencies=context.Currencies.Where(p=>p.Name=="рубль").First(),
                },
                new Transactions()
                {
                    Id=6,
                    Price=4.11m,
                    Amount=8,
                    DateTime=Convert.ToDateTime("15.06.2019"),
                    Participants=context.Participants.Where(p=>p.Name=="участник4").First(),
                    Participants1=context.Participants.Where(p=>p.Name=="участник3").First(),
                    Currencies=context.Currencies.Where(p=>p.Name=="евро").First(),
                },
                new Transactions()
                {
                    Id=7,
                    Price=3.10m,
                    Amount=7,
                    DateTime=Convert.ToDateTime("20.06.2019"),
                    Participants=context.Participants.Where(p=>p.Name=="участник5").First(),
                    Participants1=context.Participants.Where(p=>p.Name=="участник3").First(),
                    Currencies=context.Currencies.Where(p=>p.Name=="доллар").First(),
                },
                new Transactions()
                {
                    Id=8,
                    Price=1.78m,
                    Amount=9,
                    DateTime=Convert.ToDateTime("20.06.2019"),
                    Participants=context.Participants.Where(p=>p.Name=="участник1").First(),
                    Participants1=context.Participants.Where(p=>p.Name=="участник5").First(),
                    Currencies=context.Currencies.Where(p=>p.Name=="рубль").First(),
                },
                new Transactions()
                {
                    Id=9,
                    Price=1.83m,
                    Amount=20,
                    DateTime=Convert.ToDateTime("29.06.2019"),
                    Participants=context.Participants.Where(p=>p.Name=="участник3").First(),
                    Participants1=context.Participants.Where(p=>p.Name=="участник4").First(),
                    Currencies=context.Currencies.Where(p=>p.Name=="рубль").First(),
                },
                new Transactions()
                {
                    Id=10,
                    Price=4.27m,
                    Amount=17,
                    DateTime=Convert.ToDateTime("20.06.2019"),
                    Participants=context.Participants.Where(p=>p.Name=="участник1").First(),
                    Participants1=context.Participants.Where(p=>p.Name=="участник2").First(),
                    Currencies=context.Currencies.Where(p=>p.Name=="евро").First(),
                },
                new Transactions()
                {
                    Id=11,
                    Price=4.11m,
                    Amount=71,
                    DateTime=Convert.ToDateTime("29.06.2019"),
                    Participants=context.Participants.Where(p=>p.Name=="участник5").First(),
                    Participants1=context.Participants.Where(p=>p.Name=="участник3").First(),
                    Currencies=context.Currencies.Where(p=>p.Name=="доллар").First(),
                },
                new Transactions()
                {
                    Id=12,
                    Price=4.20m,
                    Amount=23,
                    DateTime=Convert.ToDateTime("29.06.2019"),
                    Participants=context.Participants.Where(p=>p.Name=="участник1").First(),
                    Participants1=context.Participants.Where(p=>p.Name=="участник2").First(),
                    Currencies=context.Currencies.Where(p=>p.Name=="евро").First(),
                }
            };
            return Transactionss;
        }
    }
}