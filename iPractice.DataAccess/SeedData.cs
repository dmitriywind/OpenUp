using System;
using System.Collections.Generic;
using System.Linq;
using iPractice.DataAccess.Entity.Models;

namespace iPractice.DataAccess.Entity
{
    public class SeedData
    {
        private const int NoClients = 50;
        private const int NoPsychologists = 20;
        
        private readonly ApplicationDbContext _context;
        
        public SeedData(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            var psychologists = CreatePsychologists();
            _context.Psychologists.AddRange(psychologists);
            
            var clients = CreateClients(psychologists);
            _context.Clients.AddRange(clients);
            
            _context.SaveChanges();
        }

        private static List<ClientEntity> CreateClients(List<PsychologistEntity> psychologists)
        {
            var random = new Random();
            
            List<ClientEntity> clients = new List<ClientEntity>();
            for (int i = 0; i < NoClients; i++)
            {
                clients.Add(new ClientEntity()
                {
                    Name = $"Client {i + 1}",
                    Psychologists = new List<PsychologistEntity>(new[]
                    {
                        psychologists.Skip(random.Next(NoPsychologists)).First(),
                        psychologists.Skip(random.Next(NoPsychologists)).First()
                    })
                });
            }

            return clients;
        }

        private static List<PsychologistEntity> CreatePsychologists()
        {
            List<PsychologistEntity> psychologists = new List<PsychologistEntity>();
            for (int i = 0; i < NoPsychologists; i++)
            {
                psychologists.Add(new PsychologistEntity
                {
                    Name = $"Psychologist {i + 1}"
                });
            }

            return psychologists;
        }
    }
}