using Events.Database;
using Events.Entities;
using Events.interfaces;
using Events.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;

namespace Events.services
{
    public class DataRepository : IDataRepository
    {
        IPasswordHasher<Account> _hasher;
        EventDbContext _dbContext;
        private readonly IConfiguration _configuration;

        public DataRepository(IPasswordHasher<Account> hasher, EventDbContext dbContext, IConfiguration configuration)
        {
            _hasher = hasher;
            _dbContext = dbContext;
            _configuration = configuration;
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

                new Event(".NET Training", Events.enums.EventType.Training, 150.99M, enums.Currency.USD, 100, new DateTime(2021,10,1,14,30,0), false,
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

        public void DeleteCollectionOfEvents()
        {
            var events = _dbContext.Events.ToList();
            var tickets = _dbContext.Tickets.ToList();
            var eventAdresses = _dbContext.Adresses.Where(x => x.EventId != null).ToList();

            _dbContext.Adresses.RemoveRange(eventAdresses);
            _dbContext.Events.RemoveRange(events);
            _dbContext.Tickets.RemoveRange(tickets);

            _dbContext.SaveChanges();

            if (Directory.Exists("wwwroot/Images/EventsIMGs/Custom"))
            {
                var customSubDirectories = Directory.GetDirectories("wwwroot/Images/EventsIMGs/Custom");
                foreach (var directory in customSubDirectories)
                    Directory.Delete(directory, true);
            }

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

        public void SaveDatasToJSON()
        {
            CopyFilesToBackUp();
            CreateJsonFileWithDbData();
        }

        public void ReadDatasFromJSON()
        {
            FillDbFromJSON();
            CopyFilesFromBackUp();
            Directory.Delete(_configuration.GetSection("DirectoryMainBackUpFolder").Value, true);
        }

        private void CopyFilesToBackUp()
        {
            if (!Directory.Exists(_configuration.GetSection("DirectoryBackUpFiles").Value))
                Directory.CreateDirectory(_configuration.GetSection("DirectoryBackUpFiles").Value);


            var source = Directory.GetDirectories("wwwroot/Images/EventsIMGs/Custom");

            if (source.Length > 0)
            {
                foreach (var dir in source)
                {
                    string targetDirectory = $"{_configuration.GetSection("DirectoryBackUpFiles").Value}/{dir.Split("\\").Last()}";

                    if (!Directory.Exists(targetDirectory))
                    {
                        Directory.CreateDirectory(targetDirectory);
                    }

                    foreach (var fi in new DirectoryInfo($"wwwroot/Images/EventsIMGs/Custom/{$"{dir.Split("\\").Last()}"}").GetFiles())
                    {
                        fi.CopyTo(Path.Combine(targetDirectory, fi.Name), true);
                    }
                }
            }
        }

        private void CreateJsonFileWithDbData()
        {
            var savedDatas = new archiveToJSON()
            {
                Accounts = _dbContext.Accounts.Include(x => x.AccountOwner).Include(y => y.AccountOwner.Adress).ToList(),
                Comments = _dbContext.Comments.ToList(),
                Events = _dbContext.Events.Include(x => x.EventAdress).ToList(),
                Participants = _dbContext.Participants.ToList(),
                Tickets = _dbContext.Tickets.ToList(),
                Users = _dbContext.Users.ToList()
            };

            string json = JsonSerializer.Serialize(savedDatas);
            File.WriteAllText(_configuration.GetSection("DirectoryBackUpJsonFile").Value, json);
        }

        private void FillDbFromJSON()
        {
            if (File.Exists(_configuration.GetSection("DirectoryBackUpJsonFile").Value))
            {
                var savedDatas = ReadFromJSONtext();
                var conn = new SqlConnection();
                conn.ConnectionString = _configuration.GetConnectionString("ConnectionstringLocalDb");

                foreach (var savedAccount in savedDatas.Accounts)
                {
                    if (_dbContext.Accounts.Any(x => x.Id == savedAccount.Id) == false)
                    {
                        using (var accountsSqlCmd = new SqlCommand())
                        {
                            accountsSqlCmd.CommandText = "SET IDENTITY_INSERT dbo.Accounts ON; " +
                              "INSERT INTO dbo.Accounts (Id, BankAccountNumber, PayPalAccountNumber, EmailAdress, " +
                              "PasswordHash, Role) " +
                              "VALUES (@accountId, @bankAccountNumber, @accountPayPalNumber, " +
                              "@accountEmailAdress, @accountPassword, @accountRole); " +
                              "SET IDENTITY_INSERT dbo.Accounts OFF;";

                            accountsSqlCmd.Parameters.AddWithValue("@accountId", savedAccount.Id);
                            accountsSqlCmd.Parameters.AddWithValue("@bankAccountNumber", savedAccount.BankAccountNumber);
                            accountsSqlCmd.Parameters.AddWithValue("@accountPayPalNumber", savedAccount.PayPalAccountNumber);
                            accountsSqlCmd.Parameters.AddWithValue("@accountEmailAdress", savedAccount.EmailAdress);
                            accountsSqlCmd.Parameters.AddWithValue("@accountPassword", savedAccount.PasswordHash);
                            accountsSqlCmd.Parameters.AddWithValue("@accountRole", (int)savedAccount.Role);

                            conn.Open();
                            accountsSqlCmd.Connection = conn;
                            accountsSqlCmd.ExecuteNonQuery();
                            conn.Close();
                        }

                        using (var usersSqlCmd = new SqlCommand())
                        {
                            usersSqlCmd.CommandText = "SET IDENTITY_INSERT dbo.Users ON; " +
                            "INSERT INTO dbo.Users (Id, FirstName, LastName, DateOfBirth, Sex) " +
                            "VALUES (@userId, @firstName, @lastName, @dateOfBirth, @sex); " +
                            "SET IDENTITY_INSERT dbo.Users OFF;";

                            usersSqlCmd.Parameters.AddWithValue("@userId", savedAccount.AccountOwner.Id);
                            usersSqlCmd.Parameters.AddWithValue("@firstName", savedAccount.AccountOwner.FirstName);
                            usersSqlCmd.Parameters.AddWithValue("@lastName", savedAccount.AccountOwner.LastName);
                            usersSqlCmd.Parameters.AddWithValue("@dateOfBirth", savedAccount.AccountOwner.DateOfBirth.ToString("yyyy-MM-dd"));
                            usersSqlCmd.Parameters.AddWithValue("@sex", (int)savedAccount.AccountOwner.Sex);
               

                            conn.Open();
                            usersSqlCmd.Connection = conn;
                            usersSqlCmd.ExecuteNonQuery();
                            conn.Close();
                        }

                        _dbContext.Accounts.FirstOrDefault(x => x.Id == savedAccount.Id).AccountOwnerId = savedAccount.AccountOwnerId;
                        _dbContext.SaveChanges();

                        using (var adressSqlCmd = new SqlCommand())
                        {
                            adressSqlCmd.CommandText = $"SET IDENTITY_INSERT dbo.Adresses ON; " +
                            $"INSERT INTO dbo.Adresses (Id, Street, HouseNumber, City, PostalCode, Country, UserId) " +
                            $"VALUES (@id, @street, @houseNumber, @city, @postalCode, @country, @userId); " +
                            $"SET IDENTITY_INSERT dbo.Adresses OFF;";

                            adressSqlCmd.Parameters.AddWithValue("@id", savedAccount.AccountOwner.Adress.Id);
                            adressSqlCmd.Parameters.AddWithValue("@street", savedAccount.AccountOwner.Adress.Street);
                            adressSqlCmd.Parameters.AddWithValue("@houseNumber", savedAccount.AccountOwner.Adress.HouseNumber);
                            adressSqlCmd.Parameters.AddWithValue("@city", savedAccount.AccountOwner.Adress.City);
                            adressSqlCmd.Parameters.AddWithValue("@postalCode", savedAccount.AccountOwner.Adress.PostalCode);
                            adressSqlCmd.Parameters.AddWithValue("@country", savedAccount.AccountOwner.Adress.Country);
                            adressSqlCmd.Parameters.AddWithValue("@userId", savedAccount.AccountOwner.Adress.UserId);

                            conn.Open();
                            adressSqlCmd.Connection = conn;
                            adressSqlCmd.ExecuteNonQuery();
                            conn.Close();

                            var accOwner = _dbContext.Users.FirstOrDefault(x => x.Id == savedAccount.AccountOwner.Id);
                            var userAdress = _dbContext.Adresses.FirstOrDefault(x => x.Id == savedAccount.AccountOwner.Adress.Id);

                            _dbContext.Accounts.FirstOrDefault(x => x.Id == savedAccount.Id).AccountOwner = accOwner;
                            _dbContext.Users.FirstOrDefault(x => x.Id == savedAccount.AccountOwner.Id).Adress = userAdress;
                            _dbContext.SaveChanges();
                        }
                    }
                }

                foreach (var savedEvent in savedDatas.Events)
                {
                    if (_dbContext.Events.Any(x => x.Id == savedEvent.Id) == false)
                    {

                        using (var eventSqlCmd = new SqlCommand())
                        {
                            eventSqlCmd.CommandText = "SET IDENTITY_INSERT dbo.Events ON; " +
                            "INSERT INTO dbo.Events (Id, Name, EventType, TicketQuantity, StartDate, " +
                            "OnlyForAdults, PossibleTicketForBuyQuantity, EventCreatorId) " +
                            "VALUES (@id, @name, @eventType, @ticketQuantity, @startDate, @onlyForAdults," +
                            "@possibleTicketQuantity, @eventCreatorId); " +
                            "SET IDENTITY_INSERT dbo.Events OFF;";

                            eventSqlCmd.Parameters.AddWithValue("@id", savedEvent.Id);
                            eventSqlCmd.Parameters.AddWithValue("@name", savedEvent.Name);
                            eventSqlCmd.Parameters.AddWithValue("@eventType", (int)savedEvent.EventType);
                            eventSqlCmd.Parameters.AddWithValue("@ticketQuantity", savedEvent.TicketQuantity);
                            eventSqlCmd.Parameters.AddWithValue("@startDate", savedEvent.StartDate.ToString("yyyy-MM-dd HH:MM:ss"));
                            eventSqlCmd.Parameters.AddWithValue("@onlyForAdults", savedEvent.OnlyForAdults);
                            eventSqlCmd.Parameters.AddWithValue("@possibleTicketQuantity", savedEvent.PossibleTicketForBuyQuantity);
                            eventSqlCmd.Parameters.AddWithValue("@eventCreatorId", savedEvent.EventCreator.Id);

                            conn.Open();
                            eventSqlCmd.Connection = conn;
                            eventSqlCmd.ExecuteNonQuery();
                            conn.Close();
                        }


                        if (savedEvent.TicketPrice != 0)
                            _dbContext.Events.FirstOrDefault(x => x.Id == savedEvent.Id).TicketPrice = savedEvent.TicketPrice;

                        if (savedEvent.Currency != null)
                            _dbContext.Events.FirstOrDefault(x => x.Id == savedEvent.Id).Currency = savedEvent.Currency.Value;

                        if (savedEvent.TitlePhoto != null)
                            _dbContext.Events.FirstOrDefault(x => x.Id == savedEvent.Id).TitlePhoto = savedEvent.TitlePhoto;

                        _dbContext.SaveChanges();

                        using (var adressSqlCmd = new SqlCommand())
                        {
                            adressSqlCmd.CommandText = "SET IDENTITY_INSERT dbo.Adresses ON; " +
                            "INSERT INTO dbo.Adresses (Id, Street, City, PostalCode, Country, EventId) " +
                            "VALUES(@id, @street, @city, @postalCode, @country, @eventId) " +
                            "SET IDENTITY_INSERT dbo.Adresses OFF;";

                            adressSqlCmd.Parameters.AddWithValue("@id", savedEvent.EventAdress.Id);
                            adressSqlCmd.Parameters.AddWithValue("@street", savedEvent.EventAdress.Street);
                            adressSqlCmd.Parameters.AddWithValue("@city", savedEvent.EventAdress.City);
                            adressSqlCmd.Parameters.AddWithValue("@postalCode", savedEvent.EventAdress.PostalCode);
                            adressSqlCmd.Parameters.AddWithValue("@country", savedEvent.EventAdress.Country);
                            adressSqlCmd.Parameters.AddWithValue("@eventId", savedEvent.EventAdress.EventId);

                            conn.Open();
                            adressSqlCmd.Connection = conn;
                            adressSqlCmd.ExecuteNonQuery();
                            conn.Close();
                        }

                        if (savedEvent.EventAdress.HouseNumber != null)
                        {
                            _dbContext.Adresses.FirstOrDefault(x => x.Id == savedEvent.EventAdress.Id).HouseNumber =
                                                                                        savedEvent.EventAdress.HouseNumber;
                            _dbContext.SaveChanges();
                        }
                    }
                }

                foreach (var savedComment in savedDatas.Comments)
                {
                    if (_dbContext.Comments.Any(x => x.Id == savedComment.Id) == false)
                    {
                        using (var commentsSqlCmd = new SqlCommand())
                        {
                            commentsSqlCmd.CommandText = "SET IDENTITY_INSERT dbo.Comments ON; " +
                                    "INSERT INTO dbo.Comments (Id, EventId, UserId, Message) " +
                                    "VALUES (@id, @eventId, @userId, @message); " +
                                    "SET IDENTITY_INSERT dbo.Comments OFF;";

                            commentsSqlCmd.Parameters.AddWithValue("@id", savedComment.Id);
                            commentsSqlCmd.Parameters.AddWithValue("@eventId", savedComment.EventId);
                            commentsSqlCmd.Parameters.AddWithValue("@userId", savedComment.UserId);
                            commentsSqlCmd.Parameters.AddWithValue("@message", savedComment.Message);

                            conn.Open();
                            commentsSqlCmd.Connection = conn;
                            commentsSqlCmd.ExecuteNonQuery();
                            conn.Close();
                        }
                    }
                }

                foreach (var savedTicket in savedDatas.Tickets)
                {
                    if (_dbContext.Tickets.Any(x => x.Id == savedTicket.Id) == false)
                    {
                        using (var ticketSqlCmd = new SqlCommand())
                        {
                            ticketSqlCmd.CommandText = "SET IDENTITY_INSERT dbo.Tickets ON; " +
                            "INSERT INTO dbo.Tickets (Id, EventId) " +
                            "VALUES (@id, @eventId); " +
                            "SET IDENTITY_INSERT dbo.Tickets OFF;";

                            ticketSqlCmd.Parameters.AddWithValue("@id", savedTicket.Id);
                            ticketSqlCmd.Parameters.AddWithValue("@eventId", savedTicket.EventId);

                            conn.Open();
                            ticketSqlCmd.Connection = conn;
                            ticketSqlCmd.ExecuteNonQuery();
                            conn.Close();
                        }

                        if (savedTicket.UserId != null)
                        {
                            _dbContext.Tickets.FirstOrDefault(x => x.Id == savedTicket.Id).UserId = savedTicket.UserId;
                            _dbContext.SaveChanges();
                        }
                    }
                }

                foreach (var savedParticipant in savedDatas.Participants)
                {
                    if (_dbContext.Participants.Any(x => x.Id == savedParticipant.Id) == false)
                    {
                        using (var participantSqlCmd = new SqlCommand())
                        {
                            participantSqlCmd.CommandText = "SET IDENTITY_INSERT dbo.Participants ON; " +
                            "INSERT INTO dbo.Participants (Id, EventId) " +
                            "VALUES (@id, @eventId); " +
                            "SET IDENTITY_INSERT dbo.Participants OFF;";

                            participantSqlCmd.Parameters.AddWithValue("@id", savedParticipant.Id);
                            participantSqlCmd.Parameters.AddWithValue("@eventId", savedParticipant.EventId);

                            conn.Open();
                            participantSqlCmd.Connection = conn;
                            participantSqlCmd.ExecuteNonQuery();
                            conn.Close();
                        }

                        if (savedParticipant.UserId != null)
                        {
                            _dbContext.Tickets.FirstOrDefault(x => x.Id == savedParticipant.Id).UserId = savedParticipant.UserId;
                            _dbContext.SaveChanges();
                        }
                    }
                }
            }
        }

        private archiveToJSON ReadFromJSONtext()
        {
            string jsonText = File.ReadAllText(_configuration.GetSection("DirectoryBackUpJsonFile").Value);
            return JsonSerializer.Deserialize<archiveToJSON>(jsonText);
        }

        private void CopyFilesFromBackUp()
        {
            if (Directory.Exists(_configuration.GetSection("DirectoryBackUpFiles").Value))
            {
                var source = Directory.GetDirectories(_configuration.GetSection("DirectoryBackUpFiles").Value);

                if (source.Length > 0)
                {
                    foreach (var dir in source)
                    {
                        string targetDirectory = $"wwwroot/Images/EventsIMGs/Custom/{dir.Split("\\").Last()}";

                        if (!Directory.Exists(targetDirectory))
                        {
                            Directory.CreateDirectory(targetDirectory);
                        }

                        foreach (var fi in new DirectoryInfo($"{_configuration.GetSection("DirectoryBackUpFiles").Value}/{dir.Split("\\").Last()}").GetFiles())
                        {
                            fi.CopyTo(Path.Combine(targetDirectory, fi.Name), true);
                        }
                    }
                }

                Directory.Delete(_configuration.GetSection("DirectoryBackUpFiles").Value, true);
            }
        }
    }
}
