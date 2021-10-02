using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext dbContext)
        {
            dbContext.Database.EnsureCreated();

            if(dbContext.Adjectives.Any())
            {
                return; //DB has been seeded
            }
            var clients = new List<Client>
            {

                new Client{FirstName="John", LastName="Hopkins" ,DOB=DateTime.Now,Gender="Male"},
                new Client{FirstName="Loraine", LastName="Hopkins" ,DOB=DateTime.Now,Gender="Female"},
                new Client{FirstName="Drew", LastName="Hopkins" ,DOB=DateTime.Now,Gender="Male"},
                new Client{FirstName="Judy", LastName="Hopkins" ,DOB=DateTime.Now,Gender="Female"},
                new Client{FirstName="John", LastName="Hopkins" ,DOB=DateTime.Now,Gender="Male"},
                new Client{FirstName="Andrew", LastName="Williams" ,DOB=DateTime.Now,Gender="Male"},
                new Client{FirstName="Loraine", LastName="Williams" ,DOB=DateTime.Now,Gender="Female"},
                new Client{FirstName="John", LastName="Williams" ,DOB=DateTime.Now,Gender="Male"},
                new Client{FirstName="Judy", LastName="Williams" ,DOB=DateTime.Now,Gender="Female"},
                new Client{FirstName="Sam", LastName="Williams" ,DOB=DateTime.Now,Gender="Male"}


            };
            var adjectives = new List<Adjective>
            {
                new Adjective{AdjName="able",AdjDefinition="",AdjType=1 },
                new Adjective{AdjName="accepting",AdjDefinition="",AdjType=1 },
                new Adjective{AdjName="adaptable",AdjDefinition="",AdjType=1 },
                 new Adjective{AdjName="bold",AdjDefinition="",AdjType=1 },
                new Adjective{AdjName="brave",AdjDefinition="",AdjType=1 },
                new Adjective{AdjName="calm",AdjDefinition="",AdjType=1 },
                 new Adjective{AdjName="caring",AdjDefinition="",AdjType=1 },
                new Adjective{AdjName="cheerful",AdjDefinition="",AdjType=1 },
                new Adjective{AdjName="clever",AdjDefinition="",AdjType=1 },
                 new Adjective{AdjName="complex",AdjDefinition="",AdjType=1 },
                new Adjective{AdjName="confident",AdjDefinition="",AdjType=1 },
                new Adjective{AdjName="dependable",AdjDefinition="",AdjType=1 },
                 new Adjective{AdjName="dignified",AdjDefinition="",AdjType=1 },
                new Adjective{AdjName="energetic",AdjDefinition="",AdjType=1 },
                new Adjective{AdjName="extroverted",AdjDefinition="",AdjType=1 },
                 new Adjective{AdjName="friendly",AdjDefinition="",AdjType=1 },
                new Adjective{AdjName="giving",AdjDefinition="",AdjType=1 },
                new Adjective{AdjName="happy",AdjDefinition="",AdjType=1 },
                 new Adjective{AdjName="helpful",AdjDefinition="",AdjType=1 },

                new Adjective{AdjName="idealistic",AdjDefinition="",AdjType=1 },
                new Adjective{AdjName="independent",AdjDefinition="",AdjType=1 },
                 new Adjective{AdjName="ingenious",AdjDefinition="",AdjType=1 },
                new Adjective{AdjName="intelligent",AdjDefinition="",AdjType=1 },
                new Adjective{AdjName="introverted",AdjDefinition="",AdjType=1 },
                 new Adjective{AdjName="kind",AdjDefinition="",AdjType=1 },
                new Adjective{AdjName="knowledgeable",AdjDefinition="",AdjType=1 },
                new Adjective{AdjName="logical",AdjDefinition="",AdjType=1 },
                 new Adjective{AdjName="loving",AdjDefinition="",AdjType=1 },
                new Adjective{AdjName="mature",AdjDefinition="",AdjType=1 },
                new Adjective{AdjName="modest",AdjDefinition="",AdjType=1 },
                 new Adjective{AdjName="nervous",AdjDefinition="",AdjType=1 },

                new Adjective{AdjName="observant",AdjDefinition="",AdjType=1 },
                new Adjective{AdjName="organized",AdjDefinition="",AdjType=1 },
                 new Adjective{AdjName="patient",AdjDefinition="",AdjType=1 },
                new Adjective{AdjName="proud",AdjDefinition="",AdjType=1 },
                new Adjective{AdjName="powerful",AdjDefinition="",AdjType=1 },
                 new Adjective{AdjName="quiet",AdjDefinition="",AdjType=1 },
                new Adjective{AdjName="reflective",AdjDefinition="",AdjType=1 },
                new Adjective{AdjName="relaxed",AdjDefinition="",AdjType=1 },
                 new Adjective{AdjName="religious",AdjDefinition="",AdjType=1 },
                new Adjective{AdjName="responsive",AdjDefinition="",AdjType=1 },
                new Adjective{AdjName="searching",AdjDefinition="",AdjType=1 },
                 new Adjective{AdjName="self-assertive ",AdjDefinition="",AdjType=1 },
                new Adjective{AdjName="self-conscious",AdjDefinition="",AdjType=1 },

                new Adjective{AdjName="sensible",AdjDefinition="",AdjType=1 },
                 new Adjective{AdjName="sentimental",AdjDefinition="",AdjType=1 },
                new Adjective{AdjName="shy",AdjDefinition="",AdjType=1 },
                new Adjective{AdjName="silly",AdjDefinition="",AdjType=1 },

                 new Adjective{AdjName="spontaneous",AdjDefinition="performed or occurring as a result of a sudden inner impulse or inclination and without premeditation or external stimulus",AdjType=1 },
                new Adjective{AdjName="sympathetic",AdjDefinition="feeling, showing, or expressing sympathy",AdjType=1 },
                 new Adjective{AdjName="tense",AdjDefinition="become tense, typically through anxiety or nervousness",AdjType=1 },
                new Adjective{AdjName="trustworthy",AdjDefinition="able to be relied on as honest or truthfu",AdjType=1 },

                new Adjective{AdjName="warm",AdjDefinition="having, showing, or expressive of enthusiasm, affection, or kindness",AdjType=1 },
                 new Adjective{AdjName="wise",AdjDefinition="having or showing experience, knowledge, and good judgment",AdjType=1 },
                new Adjective{AdjName="witty",AdjDefinition="showing or characterized by quick and inventive verbal humo",AdjType=0 },
               



                //negative
                 new Adjective{AdjName="incompetent",AdjDefinition="not having or showing the necessary skills to do something successfully",AdjType=0 },
                new Adjective{AdjName="insecure",AdjDefinition="not confident or assured; uncertain and anxious",AdjType=0 },
                 new Adjective{AdjName="hostile",AdjDefinition="unfriendly; antagonistic",AdjType=0 },
                new Adjective{AdjName="needy",AdjDefinition="lacking the necessities of life; very poor",AdjType=0 },
                new Adjective{AdjName="ignorant",AdjDefinition="lacking knowledge or awareness in general; uneducated or unsophisticated",AdjType=0 },
                 new Adjective{AdjName="blase",AdjDefinition="",AdjType=0 },
                new Adjective{AdjName="embarrassed",AdjDefinition="",AdjType=0 },
                new Adjective{AdjName="insensitive",AdjDefinition="",AdjType=0 },
                 new Adjective{AdjName="dispassionate",AdjDefinition="",AdjType=0 },
                new Adjective{AdjName="inattentive",AdjDefinition="",AdjType=0 },
                new Adjective{AdjName="intolerant",AdjDefinition="",AdjType=0 },
                 new Adjective{AdjName="aloof",AdjDefinition="",AdjType=0 },
                new Adjective{AdjName="irresponsible",AdjDefinition="",AdjType=0 },
                new Adjective{AdjName="selfish",AdjDefinition="",AdjType=0 },
                 new Adjective{AdjName="unimaginative",AdjDefinition="",AdjType=0 },

                new Adjective{AdjName="irrational",AdjDefinition="",AdjType=0 },
                new Adjective{AdjName="imperceptive",AdjDefinition="",AdjType=0 },
                 new Adjective{AdjName="loud",AdjDefinition="",AdjType=0 },

                new Adjective{AdjName="self-satisfied ",AdjDefinition="",AdjType=0 },
                new Adjective{AdjName="overdramatic",AdjDefinition="",AdjType=0 },
                 new Adjective{AdjName="unreliable",AdjDefinition="",AdjType=0 },
                new Adjective{AdjName="inflexible",AdjDefinition="",AdjType=0 },
                new Adjective{AdjName="glum",AdjDefinition="looking or feeling dejected; morose",AdjType=0 },
                 new Adjective{AdjName="vulgar",AdjDefinition="",AdjType=0 },
                new Adjective{AdjName="unhappy",AdjDefinition="",AdjType=0 },
                new Adjective{AdjName="inane",AdjDefinition="silly; stupid",AdjType=0 },

                 new Adjective{AdjName="distant",AdjDefinition="",AdjType=0 },
                new Adjective{AdjName="chaotic",AdjDefinition="",AdjType=0 },
                new Adjective{AdjName="passive",AdjDefinition="",AdjType=0 },
                 new Adjective{AdjName="dull",AdjDefinition="",AdjType=0 },

                  new Adjective{AdjName="cold",AdjDefinition="",AdjType=0 },
                new Adjective{AdjName="timid",AdjDefinition="",AdjType=0 },
                new Adjective{AdjName="stupid",AdjDefinition="",AdjType=0 },
                 new Adjective{AdjName="lethargic",AdjDefinition="affected by lethargy; sluggish and apathetic",AdjType=0 },

                  new Adjective{AdjName="brash",AdjDefinition="",AdjType=0 },
                new Adjective{AdjName="childish",AdjDefinition="",AdjType=0 },
                new Adjective{AdjName="impatient",AdjDefinition="",AdjType=0 },
                 new Adjective{AdjName="panicky",AdjDefinition="",AdjType=0 },

                   new Adjective{AdjName="smug",AdjDefinition="",AdjType=0 },
                new Adjective{AdjName="predictable",AdjDefinition="",AdjType=0 },
                new Adjective{AdjName="foolish",AdjDefinition="",AdjType=0 },
                 new Adjective{AdjName="cowardly",AdjDefinition="affected by lethargy; sluggish and apathetic",AdjType=0 },

                  new Adjective{AdjName="simple",AdjDefinition="",AdjType=0 },
                new Adjective{AdjName="withdrawn",AdjDefinition="not wanting to communicate with other people",AdjType=0 },
                new Adjective{AdjName="cynical",AdjDefinition="believing that people are motivated by self-interest; distrustful of human sincerity or integrity",AdjType=0 },
                 new Adjective{AdjName="cruel",AdjDefinition="",AdjType=0 },

                   new Adjective{AdjName="boastful",AdjDefinition="",AdjType=0 },
                new Adjective{AdjName="weak",AdjDefinition="",AdjType=0 },
                new Adjective{AdjName="unethical",AdjDefinition="",AdjType=0 },
                 new Adjective{AdjName="rash",AdjDefinition="",AdjType=0 },

                  new Adjective{AdjName="callous",AdjDefinition="",AdjType=0 },
                new Adjective{AdjName="humourless",AdjDefinition="",AdjType=0 }
                 

            };
            
            foreach(Adjective f in adjectives)
            {
                dbContext.Adjectives.Add(f);
            }
            foreach (Client f in clients)
            {
                dbContext.Clients.Add(f);
            }
            dbContext.SaveChanges();
        }
    }
}
