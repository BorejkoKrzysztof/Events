using Events.Database;
using Events.Entities;
using Events.interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Events.services
{
    public class DataRepository : IDataRepository
    {
        IPasswordHasher<Account> _hasher;
        EventDbContext _dbContext;

        public DataRepository(IPasswordHasher<Account> hasher, EventDbContext dbContext)
        {
            _hasher = hasher;
            _dbContext = dbContext;
        }


        public bool CreateDefaultCollectionEvents()
        {
            if (_dbContext.Users.Any() == true)
            {
                var events = new List<Event>() {
                new Event("Koncert Charytatywny", Events.enums.EventType.Concert, 250M, enums.Currency.PLN, 1000, new DateTime(2021,9,20,20,0,0),
                false, new Adress()
                    {
                        Street = "Stare Miasto",
                        City = "Wrocław",
                        PostalCode = "59-001",
                        Country = "Poland"
                    },
                    _dbContext.Users.FirstOrDefault(x => x.LastName == "Borejko")),

                new Event("Urodziny Roberta", Events.enums.EventType.Birthday, 0, null, 25, new DateTime(2021,8,25,19,30,0), true,
                new Adress()
                    {
                        Street = "Rock Cafe",
                        City = "New York",
                        PostalCode = "354-891",
                        Country = "USA"
                    }, _dbContext.Users.FirstOrDefault(x => x.LastName == "Kubica")),

                new Event(".NET Training", Events.enums.EventType.Training, 150.99M, enums.Currency.PLN, 100, new DateTime(2021,10,1,14,30,0), false,
                new Adress()
                    {
                        Street = "Złota",
                        HouseNumber ="44",
                        City = "Warszawa",
                        PostalCode = "58-347",
                        Country = "Poland"
                    }, _dbContext.Users.FirstOrDefault(x => x.LastName == "Jantar")
                ),

                new Event("Programming skils competition", Events.enums.EventType.Other, 0, null, 100, new DateTime(2021,10,10,16,8,0),
                false, new Adress()
                    {
                        Street = "Paryska",
                        HouseNumber ="44",
                        City = "Wrocław",
                        PostalCode = "58-346",
                        Country = "Poland"
                    }, _dbContext.Users.FirstOrDefault(x => x.LastName == "Borejko")),


                new Event("Run for 10km", Events.enums.EventType.Other, 0, null, 1000, new DateTime(2021,10,10,16,8,0),
                false, new Adress()
                    {
                        Street = "Półwiejska",
                        City = "Poznań",
                        PostalCode = "60-000",
                        Country = "Poland"
                    }, _dbContext.Users.FirstOrDefault(x => x.LastName == "Kubica"))
            };


                _dbContext.Events.AddRange(events);
                _dbContext.SaveChanges();

                var eventId1 = _dbContext.Events.FirstOrDefault(x => x.Name == "Koncert Charytatywny").Id;

                for (int i = 0; i < 1000; i++)
                {
                    _dbContext.Tickets.Add(new Ticket()
                    {
                        EventId = eventId1
                    });
                }

                _dbContext.SaveChanges();

                var eventId2 = _dbContext.Events.FirstOrDefault(x => x.Name == "Urodziny Roberta").Id;

                for (int i = 0; i < 25; i++)
                {
                    _dbContext.Tickets.Add(new Ticket()
                    {
                        EventId = eventId2
                    });
                }

                _dbContext.SaveChanges();

                var eventId3 = _dbContext.Events.FirstOrDefault(x => x.Name == ".NET Training").Id;

                for (int i = 0; i < 100; i++)
                {
                    _dbContext.Tickets.Add(new Ticket()
                    {
                        EventId = eventId3
                    });
                }

                _dbContext.SaveChanges();

                var eventId4 = _dbContext.Events.FirstOrDefault(x => x.Name == "Programming skils competition").Id;

                for (int i = 0; i < 100; i++)
                {
                    _dbContext.Tickets.Add(new Ticket()
                    {
                        EventId = eventId4
                    });
                }

                _dbContext.SaveChanges();

                var eventId5 = _dbContext.Events.FirstOrDefault(x => x.Name == "Run for 10km").Id;

                for (int i = 0; i < 1000; i++)
                {
                    _dbContext.Tickets.Add(new Ticket()
                    {
                        EventId = eventId5
                    });
                }

                _dbContext.SaveChanges();

                return true;
            }
            else
                return false;
        }

        public void CreateDefaultsAccounts()
        {
            var accounts = new List<Account>()
            {
                new Account()
                {
                    BankAccountNumber = 716161616165,
                    PayPalAccountNumber = 2131616616,
                    AccountOwner = new User()
                    {
                        FirstName = "Krzysztof",
                        LastName = "Borejko",
                        DateOfBirth = new DateTime(1998,4,20),
                        Sex = Events.enums.Sex.Male,
                        Adress = new Adress
                        {
                            Street = "Traugutta",
                            HouseNumber = "40c",
                            City = "Wrocław",
                            PostalCode = "59-001",
                            Country = "Poland"
                        }
                    },
                    EmailAdress = "borejkokrzysztof55@gmail.com",
                    Role = Events.enums.RoleType.Admin
                },
                new Account()
                {
                    BankAccountNumber = 461646161,
                    PayPalAccountNumber = 6464646,
                    AccountOwner = new User()
                    {
                        FirstName = "Anna",
                        LastName = "Jantar",
                        DateOfBirth = new DateTime(2000,2,12),
                        Sex = Events.enums.Sex.Female,
                        Adress = new Adress
                        {
                            Street = "Wojska Polskiego",
                            HouseNumber = "3/4",
                            City = "Poznań",
                            PostalCode = "60-312",
                            Country = "Poland"
                        }
                    },
                    EmailAdress = "annajantar@gmail.com",
                    Role = Events.enums.RoleType.User
                },
                new Account()
                {
                    BankAccountNumber = 4616161161,
                    PayPalAccountNumber = 2546166,
                    AccountOwner = new User()
                    {
                        FirstName = "Robert",
                        LastName = "Kubica",
                        DateOfBirth = new DateTime(1983,8,25),
                        Sex = Events.enums.Sex.Male,
                        Adress = new Adress
                        {
                            Street = "Grove Street",
                            HouseNumber = "321154",
                            City = "Los Angeles",
                            PostalCode = "789-359",
                            Country = "USA"
                        }
                    },
                    EmailAdress = "robertkubica@02.com",
                    Role = Events.enums.RoleType.User
                }
            };

            accounts[0].PasswordHash = _hasher.HashPassword(accounts[0], "haslo1");
            accounts[1].PasswordHash = _hasher.HashPassword(accounts[1], "haslo2");
            accounts[2].PasswordHash = _hasher.HashPassword(accounts[2], "haslo3");


            _dbContext.Accounts.AddRange(accounts);
            _dbContext.SaveChanges();
        }

        public void DeleteDefaultsCollectionEvents()
        {
            var events = _dbContext.Events.ToList();
            var tickets = _dbContext.Tickets.ToList();
            var eventAdresses = _dbContext.Adresses.Where(x => x.EventId != null).ToList();


            _dbContext.Adresses.RemoveRange(eventAdresses);
            _dbContext.Events.RemoveRange(events);
            _dbContext.Tickets.RemoveRange(tickets);


            _dbContext.SaveChanges();
        }

        public bool DeleteAccounts()
        {
            if (_dbContext.Events.Any() == false)
            {
                var accounts = _dbContext.Accounts.ToList();
                var users = _dbContext.Users.ToList();
                var userAdresses = _dbContext.Adresses.Where(x => x.EventId == null).ToList();

                _dbContext.Accounts.RemoveRange(accounts);
                _dbContext.Adresses.RemoveRange(userAdresses);
                _dbContext.Users.RemoveRange(users);


                _dbContext.SaveChanges();


                return true;
            }
            else
                return false;
        }

    }
}
