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
            //var clients = new List<Client>
            //{

            //    new Client{FirstName="John", LastName="Hopkins" ,DOB=DateTime.Now,Gender="Male"},
            //    new Client{FirstName="Loraine", LastName="Hopkins" ,DOB=DateTime.Now,Gender="Female"},
            //    new Client{FirstName="Drew", LastName="Hopkins" ,DOB=DateTime.Now,Gender="Male"},
            //    new Client{FirstName="Judy", LastName="Hopkins" ,DOB=DateTime.Now,Gender="Female"},
            //    new Client{FirstName="John", LastName="Hopkins" ,DOB=DateTime.Now,Gender="Male"},
            //    new Client{FirstName="Andrew", LastName="Williams" ,DOB=DateTime.Now,Gender="Male"},
            //    new Client{FirstName="Loraine", LastName="Williams" ,DOB=DateTime.Now,Gender="Female"},
            //    new Client{FirstName="John", LastName="Williams" ,DOB=DateTime.Now,Gender="Male"},
            //    new Client{FirstName="Judy", LastName="Williams" ,DOB=DateTime.Now,Gender="Female"},
            //    new Client{FirstName="Sam", LastName="Williams" ,DOB=DateTime.Now,Gender="Male"}


            //};
            var adjectives = new List<Adjective>
            {
               new Adjective{AdjName="able",AdjDefinition="having the power, skill, means, or opportunity to do something",AdjType=1},
new Adjective{AdjName="accepting",AdjDefinition="tending to regard different AdjTypes of people and ways of life with tolerance and acceptance",AdjType=1},
new Adjective{AdjName="adaptable",AdjDefinition="capable of being or becoming adapted (suited by nature, character, or design to a particular use, purpose, or situation)",AdjType=1},
new Adjective{AdjName="bold",AdjDefinition="showing or requiring a fearless daring spirit",AdjType=1},
new Adjective{AdjName="brave",AdjDefinition="having or showing mental or moral strength to face danger, fear, or difficulty",AdjType=1},
new Adjective{AdjName="calm",AdjDefinition="a quiet and peaceful state or condition",AdjType=1},
new Adjective{AdjName="caring",AdjDefinition="feeling or showing concern for or kindness to others",AdjType=1},
new Adjective{AdjName="cheerful",AdjDefinition="full of good spirits",AdjType=1},
new Adjective{AdjName="clever",AdjDefinition="showing intelligent thinking",AdjType=1},
new Adjective{AdjName="complex",AdjDefinition="hard to separate, analyze, or solve",AdjType=1},
new Adjective{AdjName="confident",AdjDefinition="having a feeling or belief that you can do something well or succeed at something",AdjType=1},
new Adjective{AdjName="dependable",AdjDefinition="capable of being trusted or depended on",AdjType=1},
new Adjective{AdjName="dignified",AdjDefinition="showing or expressing dignity (the quality or state of being worthy, honored, or esteemed)",AdjType=1},
new Adjective{AdjName="energetic",AdjDefinition="operating with or marked by vigor or effect",AdjType=1},
new Adjective{AdjName="extroverted",AdjDefinition="possessing or arising from an outgoing and gregarious nature",AdjType=1},
new Adjective{AdjName="friendly",AdjDefinition="showing kindly interest and goodwill",AdjType=1},
new Adjective{AdjName="giving",AdjDefinition="affectionate and generous where one's feelings are concerned",AdjType=1},
new Adjective{AdjName="happy",AdjDefinition="showing or causing feelings of pleasure and enjoyment",AdjType=1},
new Adjective{AdjName="helpful",AdjDefinition="of service or assistance",AdjType=1},
new Adjective{AdjName="idealistic",AdjDefinition="having a strong belief in perfect standards and trying to achieve them, even when this is not realistic",AdjType=1},
new Adjective{AdjName="independent",AdjDefinition="confident and free to do things without needing help from other people",AdjType=1},
new Adjective{AdjName="ingenious",AdjDefinition="having a lot of clever new ideas and good at inventing things",AdjType=1},
new Adjective{AdjName="intelligent",AdjDefinition="good at learning, understanding and thinking in a logical way about things; showing this ability",AdjType=1},
new Adjective{AdjName="introverted",AdjDefinition="more interested in your own thoughts and feelings than in spending time with other people",AdjType=1},
new Adjective{AdjName="kind",AdjDefinition="caring about others; gentle, friendly and generous",AdjType=1},
new Adjective{AdjName="knowledgeable",AdjDefinition="knowing a lot",AdjType=1},
new Adjective{AdjName="logical",AdjDefinition="following or able to follow the rules of logic in which ideas or facts are based on other true ideas or facts",AdjType=1},
new Adjective{AdjName="loving",AdjDefinition="feeling or showing love and care for somebody/something",AdjType=1},
new Adjective{AdjName="mature",AdjDefinition="behaving in a sensible way",AdjType=1},
new Adjective{AdjName="modest",AdjDefinition="not talking much about your own abilities or possessions",AdjType=1},
new Adjective{AdjName="nervous",AdjDefinition="easily worried or frightened",AdjType=1},
new Adjective{AdjName="observant",AdjDefinition="good at noticing things around you",AdjType=1},
new Adjective{AdjName="organized",AdjDefinition="able to plan your work, life, etc. well and in an efficient way",AdjType=1},
new Adjective{AdjName="patient",AdjDefinition="able to wait for a long time or accept annoying behaviour or difficulties without becoming angry",AdjType=1},
new Adjective{AdjName="powerful",AdjDefinition="being able to control and influence people and events",AdjType=1},
new Adjective{AdjName="proud",AdjDefinition="feeling pleased and satisfied about something that you own or have done, or are connected with",AdjType=1},
new Adjective{AdjName="quiet",AdjDefinition="(of a feeling or an attitude) definite but not expressed in an obvious way",AdjType=1},
new Adjective{AdjName="reflective",AdjDefinition="thinking deeply about things",AdjType=1},
new Adjective{AdjName="relaxed",AdjDefinition="calm and not anxious or worried",AdjType=1},
new Adjective{AdjName="spiritual",AdjDefinition="believing strongly in a particular religion and obeying its laws and practices",AdjType=1},
new Adjective{AdjName="responsive",AdjDefinition="reacting with interest or enthusiasm",AdjType=1},
new Adjective{AdjName="searching",AdjDefinition="trying to find out the truth about something; complete and serious",AdjType=1},
new Adjective{AdjName="self-assertive",AdjDefinition="very confident and not afraid to express your opinions",AdjType=1},
new Adjective{AdjName="self-conscious",AdjDefinition="nervous or embarrassed about your appearance or what other people think of you",AdjType=1},
new Adjective{AdjName="sensible",AdjDefinition="able to make good judgements based on reason and experience rather than emotion; practical",AdjType=1},
new Adjective{AdjName="sentimental",AdjDefinition="connected with your emotions, rather than reason",AdjType=1},
new Adjective{AdjName="shy",AdjDefinition="nervous or embarrassed about meeting and speaking to other people",AdjType=1},
new Adjective{AdjName="silly",AdjDefinition="showing a lack of thought, understanding, or judgement",AdjType=1},
new Adjective{AdjName="spontaneous",AdjDefinition="often doing things without planning to, because you suddenly want to do them",AdjType=1},
new Adjective{AdjName="sympathetic",AdjDefinition="kind to somebody who is hurt or sad; showing that you understand and care about their problems",AdjType=1},
new Adjective{AdjName="tense",AdjDefinition="nervous or worried, and unable to relax",AdjType=1},
new Adjective{AdjName="trustworthy",AdjDefinition="that you can rely on to be good, honest, sincere, etc.",AdjType=1},
new Adjective{AdjName="warm",AdjDefinition="showing enthusiasm, friendship or love",AdjType=1},
new Adjective{AdjName="wise",AdjDefinition="able to make sensible decisions and give good advice because of the experience and knowledge that you have",AdjType=1},
new Adjective{AdjName="witty",AdjDefinition="clever and humorous",AdjType=1},
new Adjective{AdjName="conscientious",AdjDefinition="taking care to do things carefully and correctly",AdjType=1},
new Adjective{AdjName="attentive",AdjDefinition="listening or watching carefully and with interest",AdjType=1},
new Adjective{AdjName="incompetent",AdjDefinition="not having the skill or ability to do your job or a task as it should be done",AdjType=0},
new Adjective{AdjName="violent",AdjDefinition="showing or caused by very strong emotion",AdjType=0},
new Adjective{AdjName="insecure",AdjDefinition="not confident about yourself or your relationships with other people",AdjType=0},
new Adjective{AdjName="hostile",AdjDefinition="aggressive or unfriendly and ready to argue or fight",AdjType=0},
new Adjective{AdjName="needy",AdjDefinition="not confident, and needing a lot of love and emotional support from other people",AdjType=0},
new Adjective{AdjName="ignorant",AdjDefinition="not having or showing much knowledge or information about things; not educated",AdjType=0},
new Adjective{AdjName="blasÃ©",AdjDefinition="not impressed, excited or worried about something, because you have seen or experienced it many times before",AdjType=0},
new Adjective{AdjName="embarrassed",AdjDefinition="shy, uncomfortable or ashamed, especially in a social situation",AdjType=0},
new Adjective{AdjName="insensitive",AdjDefinition="not realizing or caring how other people feel, and therefore likely to hurt or offend them",AdjType=0},
new Adjective{AdjName="dispassionate",AdjDefinition="not influenced by emotion",AdjType=0},
new Adjective{AdjName="inattentive",AdjDefinition="not paying attention to something/somebody",AdjType=0},
new Adjective{AdjName="intolerant",AdjDefinition="not willing to accept ideas or ways of behaving that are different from your own",AdjType=0},
new Adjective{AdjName="aloof",AdjDefinition="not friendly or interested in other people",AdjType=0},
new Adjective{AdjName="irresponsible",AdjDefinition="not thinking enough about the effects of what they do; not showing a feeling of responsibility",AdjType=0},
new Adjective{AdjName="selfish",AdjDefinition="caring only about yourself rather than about other people",AdjType=0},
new Adjective{AdjName="unimaginative",AdjDefinition="not having any original or new ideas",AdjType=0},
new Adjective{AdjName="irrational",AdjDefinition="not based on, or not using, clear logical thought",AdjType=0},
new Adjective{AdjName="imperceptive",AdjDefinition="lacking in perception or insight",AdjType=0},
new Adjective{AdjName="loud",AdjDefinition="talking very loudly, too much and in a way that is annoying",AdjType=0},
new Adjective{AdjName="self-satisfied",AdjDefinition="too pleased with yourself or your own achievements",AdjType=0},
new Adjective{AdjName="overdramatic",AdjDefinition="excessively dramatic or exaggerated",AdjType=0},
new Adjective{AdjName="unreliable",AdjDefinition="that cannot be trusted or depended on",AdjType=0},
new Adjective{AdjName="inflexible",AdjDefinition="unwilling to change their opinions, decisions, etc., or the way they do things",AdjType=0},
new Adjective{AdjName="glum",AdjDefinition="sad, quiet and unhappy",AdjType=0},
new Adjective{AdjName="vulgar",AdjDefinition="not having or showing good taste; not polite, pleasant or well behaved",AdjType=0},
new Adjective{AdjName="unhappy",AdjDefinition="not pleased or satisfied with somebody/something",AdjType=0},
new Adjective{AdjName="inane",AdjDefinition="stupid or silly; with no meaning",AdjType=0},
new Adjective{AdjName="distant",AdjDefinition="not friendly; not wanting a close relationship with somebody",AdjType=0},
new Adjective{AdjName="chaotic",AdjDefinition="without any order; in a completely confused state",AdjType=0},
new Adjective{AdjName="vacuous",AdjDefinition="showing no sign of intelligence or sensitive feelings",AdjType=0},
new Adjective{AdjName="passive",AdjDefinition="accepting what happens or what people do without trying to change anything or oppose them",AdjType=0},
new Adjective{AdjName="dull",AdjDefinition="not interesting or exciting",AdjType=0},
new Adjective{AdjName="cold",AdjDefinition="without emotion; not friendly",AdjType=0},
new Adjective{AdjName="timid",AdjDefinition="shy and nervous; not brave",AdjType=0},
new Adjective{AdjName="stupid",AdjDefinition="showing a lack of thought or good judgement",AdjType=0},
new Adjective{AdjName="lethargic",AdjDefinition="without any energy or enthusiasm for doing things",AdjType=0},
new Adjective{AdjName="unhelpful",AdjDefinition="not helpful or useful; not willing to help somebody",AdjType=0},
new Adjective{AdjName="brash",AdjDefinition="confident in an aggressive way",AdjType=0},
new Adjective{AdjName="childish",AdjDefinition="behaving in a stupid or silly way",AdjType=0},
new Adjective{AdjName="impatient",AdjDefinition="annoyed by somebody/something, especially because you have to wait for a long time",AdjType=0},
new Adjective{AdjName="panicky",AdjDefinition="very anxious about something; feeling or showing panic",AdjType=0},
new Adjective{AdjName="smug",AdjDefinition="looking or feeling too pleased about something you have done or achieved",AdjType=0},
new Adjective{AdjName="predictable",AdjDefinition="behaving or happening in a way that you would expect and therefore boring",AdjType=0},
new Adjective{AdjName="foolish",AdjDefinition="not showing good sense or judgement",AdjType=0},
new Adjective{AdjName="cowardly",AdjDefinition="not brave; not having the courage to do things that other people do not think are especially difficult",AdjType=0},
new Adjective{AdjName="simple",AdjDefinition="ordinary; not special",AdjType=0},
new Adjective{AdjName="withdrawn",AdjDefinition="not wanting to talk to other people; extremely quiet and shy",AdjType=0},
new Adjective{AdjName="cynical",AdjDefinition="believing that people only do things to help themselves rather than for good or honest reasons",AdjType=0},
new Adjective{AdjName="cruel",AdjDefinition="having a desire to cause physical or mental pain and make somebody suffer",AdjType=0},
new Adjective{AdjName="boastful",AdjDefinition="talking about yourself in a very proud way",AdjType=0},
new Adjective{AdjName="weak",AdjDefinition="easy to influence; not having much power",AdjType=0},
new Adjective{AdjName="unethical",AdjDefinition="not morally acceptable",AdjType=0},
new Adjective{AdjName="rash",AdjDefinition="doing something that may not be sensible without first thinking about the possible results; done in this way",AdjType=0},
new Adjective{AdjName="callous",AdjDefinition="not caring about other peopleâ€™s feelings, pain or problems",AdjType=0},
new Adjective{AdjName="humourless",AdjDefinition="not having or showing the ability to laugh at things that other people think are funny",AdjType=0},

            };
            
            foreach(Adjective f in adjectives)
            {
                dbContext.Adjectives.Add(f);
            }
            //foreach (Client f in clients)
            //{
            //    dbContext.Clients.Add(f);
            //}
            dbContext.SaveChanges();
        }
    }
}
