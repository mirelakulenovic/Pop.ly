namespace Pop.ly.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Pop.ly.Models.Database;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Microsoft.AspNet.Identity;
    using Models;
    using System.Collections.Generic;

    internal sealed class Configuration : DbMigrationsConfiguration<Pop.ly.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Pop.ly.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            //Seeds an administrator role if it doesn't already exist
            if (!context.Roles.Any(r => r.Name == "Administrator"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "Administrator" };
                manager.Create(role);
            }
            //Seeds an administrator account. Obviously this is a poor idea for an actual application
            if (!context.Users.Any(u => u.UserName == "admin@app.com"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var AdminUser = new ApplicationUser
                {
                    FirstName = "Admin",
                    LastName = "I. Strator",
                    UserName = "admin@app.com",
                    Email = "admin@app.com",
                };


                manager.Create(AdminUser, "P@ssword1");
                manager.AddToRole(AdminUser.Id, "Administrator");
            }

            var m1 = new Movie
            {
                ID = 1,
                Title = "Interstellar",
                ReleaseYear = 2014,
                Director = " Christopher Nolan",
                Genre = "Drama",
                Description = "Earth's future has been riddled by disasters, famines, and droughts. There is only one way to ensure mankind's survival: Interstellar travel. A newly discovered wormhole in the far reaches of our solar system allows a team of astronauts to go where no man has gone before, a planet that may have the right environment to sustain human life.",
                Price = 20,
                CoverArt = @"/Content/Images/Movies/Interstellar_Cover.jpg",
                PromoArt = @"/Content/Images/Movies/Interstellar_Promo.jpg",
                TrailerURL = @"2LqzF5WauAw"
            };

            var m2 = new Movie
            {
                ID = 2,
                Title = "The Notebook",
                ReleaseYear = 2004,
                Director = "Nick Cassavetes",
                Genre = "Romance",
                Description = "In a nursing home, resident Duke reads a romance story to an old woman who has senile dementia with memory loss. In the late 1930s, wealthy seventeen year-old Allie Hamilton is spending summer vacation in Seabrook. Local worker Noah Calhoun meets Allie at a carnival and they soon fall in love with each other. One day, Noah brings Allie to an ancient house that he dreams of buying and restoring and they attempt to make love but get interrupted by their friend. Allie's parents do not approve of their romance since Noah belongs to another social class, and they move to New York with her. Noah writes 365 letters (A Year) to Allie, but her mother Anne Hamilton does not deliver them to her daughter. Three years later, the United States joins the World War II and Noah and his best friend Fin enlist in the army, and Allie works as an army nurse. She meets injured soldier Lon Hammond in the hospital. After the war, they meet each other again going on dates and then, Lon, who is wealthy and ...",
                Price = 5,
                CoverArt = @"/Content/Images/Movies/notebook_cover.jpg",
                PromoArt = @"/Content/Images/Movies/notebook_promo.jpg",
                TrailerURL = @"yDJIcYE32NU"

            };

            var m3 = new Movie
            {
                ID = 3,
                Title = "Ice Age 3: Dawn of the Dinosaurs",
                ReleaseYear = 2009,
                Director = "Carlos Saldanha",
                Genre = "Comedy, Adventure",
                Description = "After the events of 'Ice Age: The Meltdown', life begins to change for Manny and his friends: Scrat is still on the hunt to hold onto his beloved acorn, while finding a possible romance in a female sabre-toothed squirrel named Scratte. Manny and Ellie, having since become an item, are expecting a baby, which leaves Manny anxious to ensure that everything is perfect for when his baby arrives. Diego is fed up with being treated like a house-cat and ponders the notion that he is becoming too laid-back. Sid begins to wish for a family of his own, and so steals some dinosaur eggs which leads to Sid ending up in a strange underground world where his herd must rescue him, while dodging dinosaurs and facing danger left and right, and meeting up with a one-eyed weasel known as Buck who hunts dinosaurs intently.",
                Price = 10,
                CoverArt = @"/Content/Images/Movies/iceage3_cover.jpg",
                PromoArt = @"/Content/Images/Movies/iceage3_promo.jpg",
                TrailerURL = @"Y_nSwh2WjAM"

            };
            var m4 = new Movie
            {
                ID = 4,
                Title = "Moana",
                ReleaseYear = 2016,
                Director = "Ron Clements",
                Genre = "Comedy, Adventure",
                Description = "Moana Waialiki is a sea voyaging enthusiast and the only daughter of a chief in a long line of navigators. When her island's fishermen can't catch any fish and the crops fail, she learns that the demigod Maui caused the blight by stealing the heart of the goddess, Te Fiti. The only way to heal the island is to persuade Maui to return Te Fiti's heart, so Moana sets off on an epic journey across the Pacific. The film is based on stories from Polynesian mythology.",
                Price = 26,
                CoverArt = @"/Content/Images/Movies/moana_cover.jpg",
                PromoArt = @"/Content/Images/Movies/moana_promo.jpg",
                TrailerURL = @"LKFuXETZUsI"

            };
            var m5 = new Movie
            {
                ID = 5,
                Title = "Jurassic World",
                ReleaseYear = 2015,
                Director = "Colin Trevorrow",
                Genre = "Action, Adventure, Sci-Fi",
                Description = "22 years after the original Jurassic Park failed, the new park (also known as Jurassic World) is open for business. After years of studying genetics the scientists on the park genetically engineer a new breed of dinosaur. When everything goes horribly wrong, will our heroes make it off the island?",
                Price = 24,
                CoverArt = @"/Content/Images/Movies/jurassic_world_cover.jpg",
                PromoArt = @"/Content/Images/Movies/jurassic_world_promo.jpg",
                TrailerURL = @"RFinNxS5KN4"
            };
            var m6 = new Movie
            {
                ID = 6,
                Title = "Peter Rabbit",
                ReleaseYear = 2018,
                Director = "Will Gluck",
                Genre = "Action, Adventure, Sci-Fi",
                Description = "Based on the books by Beatrix Potter: Peter Rabbit (James Corden;) his three sisters: Flopsy (Margot Robbie,) Mopsy (Elizabeth Debicki) and Cotton Tail (Daisy Ridley) and their cousin Benjamin (Colin Moody) enjoy their days harassing Mr McGregor in his vegetable garden. Until one day he dies and no one can stop them roaming across his house and lands for a full day or so. However, when one of Mr McGregor's relatives inherits the house and goes to check it out, he finds much more than he bargained for. What ensues, is a battle of wills between the new Mr McGregor and the rabbits. But when he starts to fall in love with Bea (Rose Byrne,) a real lover of all nature, his feelings towards them begin to change. But is it too late?",
                Price = 30,
                CoverArt = @"/Content/Images/Movies/peterrabbit_cover.jpg",
                PromoArt = @"/Content/Images/Movies/peterrabbit_promo.jpg",
                TrailerURL = @"7Pa_Weidt08"
            };
            var m7 = new Movie
            {
                ID = 7,
                Title = "The Greatest Showman",
                ReleaseYear = 2017,
                Director = "Michael Gracey",
                Genre = "Romance, Drama, Musical",
                Description = "Orphaned, penniless but ambitious and with a mind crammed with imagination and fresh ideas, the American Phineas Taylor Barnum will always be remembered as the man with the gift to effortlessly blur the line between reality and fiction. Thirsty for innovation and hungry for success, the son of a tailor will manage to open a wax museum but will soon shift focus to the unique and peculiar, introducing extraordinary, never-seen-before live acts on the circus stage. Some will call Barnum's wide collection of oddities, a freak show; however, when the obsessed showman gambles everything on the opera singer Jenny Lind to appeal to a high-brow audience, he will somehow lose sight of the most important aspect of his life: his family. Will Barnum risk it all to be accepted?",
                Price = 22,
                CoverArt = @"/Content/Images/Movies/TheGreatestShowman_cover.jpg",
                PromoArt = @"/Content/Images/Movies/TheGreatestShowman_promo.jpg",
                TrailerURL = @"AXCTMGYUg9A"
            };
            var m8 = new Movie
            {
                ID = 8,
                Title = "Tomb Raider",
                ReleaseYear = 2018,
                Director = "Roar Uthaug",
                Genre = "Action, Adventure, Drama",
                Description = "Lara Croft is the fiercely independent daughter of an eccentric adventurer who vanished when she was scarcely a teen. Now a young woman of 21 without any real focus or purpose, Lara navigates the chaotic streets of trendy East London as a bike courier, barely making the rent, and takes college courses, rarely making it to class. Determined to forge her own path, she refuses to take the reins of her father's global empire just as staunchly as she rejects the idea that he's truly gone.",
                Price = 30,
                CoverArt = @"/Content/Images/Movies/TombRaider2018_cover.jpg",
                PromoArt = @"/Content/Images/Movies/TombRaider2018_promo.jpg",
                TrailerURL = @"rOEHpkZCc1Y"
            };
            var m9 = new Movie
            {
                ID = 9,
                Title = "Game Night",
                ReleaseYear = 2018,
                Director = "John Francis Daley",
                Genre = "Comedy",
                Description = "Max and his wife, Annie, and their friends get together for 'Game Night' on a regular basis. His brother, Brooks, who's hosting the event this time, informs them that they're having a murder mystery party. Someone in the room will be kidnapped during the party. The other players must do everything they can to find him to win the grand prize. Brooks warns them that they won't know what is real or fake. When the door breaks open suddenly and Brooks is kidnapped, Max and the other players believe that it's merely the start of the mystery. What happens next proves that a real kidnapping can cause a lot of hilarious and even deadly confusion when everyone thinks it's just a game.",
                Price = 25,
                CoverArt = @"/Content/Images/Movies/gamenight_cover.jpg",
                PromoArt = @"/Content/Images/Movies/gamenight_promo.jpg",
                TrailerURL = @"qmxMAdV6s4U"
            };
            var m10 = new Movie
            {
                ID = 10,
                Title = "Ready Player One",
                ReleaseYear = 2018,
                Director = "Steven Spielberg",
                Genre = "Action, Adventure, Sci-Fi",
                Description = "In the year 2045, the real world is a harsh place. The only time Wade Watts (Tye Sheridan) truly feels alive is when he escapes to the OASIS, an immersive virtual universe where most of humanity spends their days. In the OASIS, you can go anywhere, do anything, be anyone-the only limits are your own imagination. The OASIS was created by the brilliant and eccentric James Halliday (Mark Rylance), who left his immense fortune and total control of the Oasis to the winner of a three-part contest he designed to find a worthy heir. When Wade conquers the first challenge of the reality-bending treasure hunt, he and his friends-aka the High Five-are hurled into a fantastical universe of discovery and danger to save the OASIS.",
                Price = 30,
                CoverArt = @"/Content/Images/Movies/readyplayerone_cover.jpg",
                PromoArt = @"/Content/Images/Movies/readyplayerone_promo.jpg",
                TrailerURL = @"cSp1dM2Vj48"
            };
            var m11 = new Movie
            {
                ID = 11,
                Title = "Show Dogs",
                ReleaseYear = 2018,
                Director = "Raja Gosnell",
                Genre = "Action, Adventure, Comedy",
                Description = "Max, a macho, solitary Rottweiler police dog is ordered to go undercover as a primped show dog in a prestigious Dog Show, along with his human partner, to avert a disaster from happening.",
                Price = 30,
                CoverArt = @"/Content/Images/Movies/showdogs_cover.jpg",
                PromoArt = @"/Content/Images/Movies/showdogs_promo.jpg",
                TrailerURL = @"eT9eWtb7C4c"
            };
            var m12 = new Movie
            {
                ID = 12,
                Title = "Beast",
                ReleaseYear = 2017,
                Director = "Michael Pearce",
                Genre = "Drama",
                Description = "A troubled woman living in an isolated community finds herself pulled between the control of her oppressive family and the allure of a secretive outsider suspected of a series of brutal murders.",
                Price = 28,
                CoverArt = @"/Content/Images/Movies/beast2017_cover.jpg",
                PromoArt = @"/Content/Images/Movies/beast2017_promo.jpg",
                TrailerURL = @"l6CWOjYSGH8"
            };
            var m13 = new Movie
            {
                ID = 13,
                Title = "Life of the Party",
                ReleaseYear = 2018,
                Director = "Ben Falcone",
                Genre = "Comedy",
                Description = "When her husband suddenly dumps her, longtime dedicated housewife Deanna turns regret into re-set by going back to college - landing in the same class and school as her daughter, who's not entirely sold on the idea. Plunging headlong into the campus experience, the increasingly outspoken Deanna -- now Dee Rock -- embraces freedom, fun, and frat boys on her own terms, finding her true self in a senior year no one ever expected.",
                Price = 30,
                CoverArt = @"/Content/Images/Movies/LifeOfTheParty_cover.jpg",
                PromoArt = @"/Content/Images/Movies/LifeOfTheParty_promo.jpg",
                TrailerURL = @"T1B1CxmAXLk"
            };
            var m14 = new Movie
            {
                ID = 14,
                Title = "Deadpool 2",
                ReleaseYear = 2018,
                Director = "David Leitch",
                Genre = "Action, Adventure, Comedy",
                Description = "After surviving a near fatal bovine attack, a disfigured cafeteria chef (Wade Wilson) struggles to fulfill his dream of becoming Mayberry's hottest bartender while also learning to cope with his lost sense of taste. Searching to regain his spice for life, as well as a flux capacitor, Wade must battle ninjas, the Yakuza, and a pack of sexually aggressive canines, as he journeys around the world to discover the importance of family, friendship, and flavor - finding a new taste for adventure and earning the coveted coffee mug title of World's Best Lover.",
                Price = 30,
                CoverArt = @"/Content/Images/Movies/Deadpool2_cover.jpg",
                PromoArt = @"/Content/Images/Movies/Deadpool2_promo.jpg",
                TrailerURL = @"D86RtevtfrA"
            };
            var m15 = new Movie
            {
                ID = 15,
                Title = "Book Club",
                ReleaseYear = 2018,
                Director = "Bill Holderman",
                Genre = "Comedy",
                Description = "Four older women spend their lives attending a book club where they bond over the typical suggested literature. One day, they end up reading Fifty Shades of Grey and are turned on by the content. Viewing it as a wake up call, they decide to expand their lives and chase pleasures that have eluded them.",
                Price = 30,
                CoverArt = @"/Content/Images/Movies/BookClub_cover.jpg",
                PromoArt = @"/Content/Images/Movies/BookClub_promo.jpg",
                TrailerURL = @"LDxgPIsv6sY"
            };
            var m16 = new Movie
            {
                ID = 16,
                Title = "Alice in Wonderland",
                ReleaseYear = 1999,
                Director = "Nick Welling",
                Genre = "Adventure, Comedy, Family",
                Description = "Alice follows a white rabbit down a rabbit-hole into a whimsical Wonderland, where she meets characters like the delightful Cheshire Cat, the clumsy White Knight, a rude caterpillar, and the hot-tempered Queen of Hearts and can grow ten feet tall or shrink to three inches. But will she ever be able to return home?",
                Price = 12,
                CoverArt = @"/Content/Images/Movies/Alice1999_cover.jpg",
                PromoArt = @"/Content/Images/Movies/Alice1999_promo.jpg",
                TrailerURL = @"LDxgPIsv6sY"
            };
            var m17 = new Movie
            {
                ID = 17,
                Title = "A Fistful of Dollars",
                ReleaseYear = 1964,
                Director = "Sergio Leone",
                Genre = "Western",
                Description = "An anonymous, but deadly man rides into a town torn by war between two factions, the Baxters and the Rojo's. Instead of fleeing or dying, as most other would do, the man schemes to play the two sides off each other, getting rich in the bargain.",
                Price = 5,
                CoverArt = @"/Content/Images/Movies/FistfulOfDollars_cover.jpg",
                PromoArt = @"/Content/Images/Movies/FistfulOfDollars_promo.jpg",
                TrailerURL = @"X2DtiE7VLw"
            };
            var m18 = new Movie
            {
                ID = 18,
                Title = "Casablanca",
                ReleaseYear = 1942,
                Director = "Michael Curtiz",
                Genre = "Drama, Romance",
                Description = "The story of Rick Blaine, a cynical world-weary ex-patriate who runs a nightclub in Casablanca, Morocco during the early stages of WWII. Despite the pressure he constantly receives from the local authorities, Rick's cafe has become a kind of haven for refugees seeking to obtain illicit letters that will help them escape to America. But when Ilsa, a former lover of Rick's, and her husband, show up to his cafe one day, Rick faces a tough challenge which will bring up unforeseen complications, heartbreak and ultimately an excruciating decision to make ",
                Price = 6,
                CoverArt = @"/Content/Images/Movies/casablanca_cover.jpg",
                PromoArt = @"/Content/Images/Movies/casablanca_cover.jpg",
                TrailerURL = @"BkL9l7qovsE"
            };
            var m19 = new Movie
            {
                ID = 19,
                Title = "Titanic",
                ReleaseYear = 1997,
                Director = "James Cameron",
                Genre = "Drama, Romance",
                Description = "84 years later, a 100 year-old woman named Rose DeWitt Bukater tells the story to her granddaughter Lizzy Calvert, Brock Lovett, Lewis Bodine, Bobby Buell and Anatoly Mikailavich on the Keldysh about her life set in April 10th 1912, on a ship called Titanic when young Rose boards the departing ship with the upper-class passengers and her mother, Ruth DeWitt Bukater, and her fiancE Caledon Hockley. Meanwhile, a drifter and artist named Jack Dawson and his best friend Fabrizio De Rossi win third-class tickets to the ship in a game. And she explains the whole story from departure until the death of Titanic on its first and last voyage April 15th, 1912 at 2:20 in the morning.",
                Price = 8,
                CoverArt = @"/Content/Images/Movies/Titanic_Cover.jpg",
                PromoArt = @"/Content/Images/Movies/Titanic_Promo.jpg",
                TrailerURL = @"2e-eXJ6HgkQ"
            };
            var m20 = new Movie
            {
                ID = 20,
                Title = "The Dark Knight",
                ReleaseYear = 2008,
                Director = "Christopher Nolan",
                Genre = "Action, Crime, Drama",
                Description = "Set within a year after the events of Batman Begins, Batman, Lieutenant James Gordon, and new district attorney Harvey Dent successfully begin to round up the criminals that plague Gotham City until a mysterious and sadistic criminal mastermind known only as the Joker appears in Gotham, creating a new wave of chaos. Batman's struggle against the Joker becomes deeply personal, forcing him to 'confront everything he believes' and improve his technology to stop him.",
                Price = 12,
                CoverArt = @"/Content/Images/Movies/DarkKnight_Cover.jpg",
                PromoArt = @"/Content/Images/Movies/DarkKnight_Promo.jpg",
                TrailerURL = @"EXeTwQWrcwY"
            };
            var m21 = new Movie
            {
                ID = 21,
                Title = "Lord of the Rings: The Fellowship of the Ring",
                ReleaseYear = 2001,
                Director = "Peter Jackson",
                Genre = "Adventure, Drama, Fantasy",
                Description = "The Lord of the Rings: The Fellowship of the Ring is the first movie in Peter Jackson's epic fantasy trilogy. An ancient Ring thought lost for centuries has been found, and through a strange twist in fate has been given to a small Hobbit named Frodo. When Gandalf discovers the Ring is in fact the One Ring of the Dark Lord Sauron, Frodo must make an epic quest in order to destroy it!",
                Price = 8,
                CoverArt = @"/Content/Images/Movies/LotR1_Cover.jpg",
                PromoArt = @"/Content/Images/Movies/LotR1_Promo.jpg",
                TrailerURL = @"V75dMMIW2B4"
            };
            var m22 = new Movie
            {
                ID = 22,
                Title = "Gladiator",
                ReleaseYear = 2000,
                Director = "Ridley Scott",
                Genre = "Action, Adventure, Drama",
                Description = "Maximus is a powerful Roman general, loved by the people and the aging Emperor, Marcus Aurelius. Before his death, the Emperor chooses Maximus to be his heir over his own son, Commodus, and a power struggle leaves Maximus and his family condemned to death. The powerful general is unable to save his family, and his loss of will allows him to get captured and put into the Gladiator games until he dies. The only desire that fuels him now is the chance to rise to the top so that he will be able to look into the eyes of the man who will feel his revenge.",
                Price = 8,
                CoverArt = @"/Content/Images/Movies/Gladiator_Cover.jpg",
                PromoArt = @"/Content/Images/Movies/Gladiator_Promo.jpg",
                TrailerURL = @"VB5aBE6e00U"
            };
            var m23 = new Movie
            {
                ID = 23,
                Title = "Inglorious Basterds",
                ReleaseYear = 2009,
                Director = "Quentin Tarantino",
                Genre = "Adventure, Drama, War",
                Description = "In German-occupied France, young Jewish refugee Shosanna Dreyfus witnesses the slaughter of her family by Colonel Hans Landa. Narrowly escaping with her life, she plots her revenge several years later when German war hero Fredrick Zoller takes a rapid interest in her and arranges an illustrious movie premiere at the theater she now runs. With the promise of every major Nazi officer in attendance, the event catches the attention of the 'Basterds', a group of Jewish-American guerrilla soldiers led by the ruthless Lt. Aldo Raine. As the relentless executioners advance and the conspiring young girl's plans are set in motion, their paths will cross for a fateful evening that will shake the very annals of history.",
                Price = 8,
                CoverArt = @"/Content/Images/Movies/Basterds_Cover.jpg",
                PromoArt = @"/Content/Images/Movies/Basterds_Promo.jpg",
                TrailerURL = @"6AtLlVNsuAc"
            };
            var m24 = new Movie
            {
                ID = 24,
                Title = "I Am Legend",
                ReleaseYear = 2007,
                Director = "Francis Lawrence",
                Genre = "Drama, Horror, Sci-Fi",
                Description = "Robert Neville is a scientist who was unable to stop the spread of the terrible virus that was incurable and man-made. Immune, Neville is now the last human survivor in what is left of New York City and perhaps the world. For three years, Neville has faithfully sent out daily radio messages, desperate to find any other survivors who might be out there. But he is not alone. Mutant victims of the plague -- The Infected -- lurk in the shadows... watching Neville's every move... waiting for him to make a fatal mistake.",
                Price = 10,
                CoverArt = @"/Content/Images/Movies/IAmLegend_Cover.jpg",
                PromoArt = @"/Content/Images/Movies/IAmLegend_Cover.jpg",
                TrailerURL = @"dtKMEAXyPkg"
            };
            context.Movies.AddOrUpdate(m => m.ID, m1, m2, m3, m4, m5, m6, m7, m8, m9, m10, m11, m12, m13, m14, m15, m16, m17, m18, m19, m20, m21, m22, m23, m24);


            //Seeds users/customers to the database
            if (!context.Users.Any(u => u.UserName == "hannah_rockz@hotmail.com"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var C1 = new ApplicationUser
                {
                    FirstName = "Hannah",
                    LastName = "Handlebars",
                    BillingAddress = "23 Floof Rd.",
                    BillingZip = "64477",
                    BillingCity = "Fluffington",
                    PhoneNumber = "0722267435",
                    UserName = "hannah_rockz@hotmail.com",
                    Email = "hannah_rocks@hotmail.com",
                };
                var C2 = new ApplicationUser
                {
                    FirstName = "Ronald",
                    LastName = "Racuous",
                    BillingAddress = "23 Floof Rd.",
                    BillingZip = "64477",
                    BillingCity = "Fluffington",
                    Email = "rockin_ron@aweso.me",
                    PhoneNumber = "0762458731",
                    UserName = "rockin_ron@aweso.me"
                };
                var C3 = new ApplicationUser
                {
                    FirstName = "Pia",
                    LastName = "Pajama",
                    BillingAddress = "18 Bunnyhop Ln.",
                    BillingZip = "64458",
                    BillingCity = "Fluffington",
                    Email = "pia_loves_bunnies@floof.com.au",
                    UserName = "pia_loves_bunnies@floof.com.au",
                    PhoneNumber = "0708742354"
                };
                var C4 = new ApplicationUser
                {
                    FirstName = "Marjory",
                    LastName = "Delaqua",
                    BillingAddress = "14 Grenth Plaza.",
                    BillingZip = "66645",
                    BillingCity = "Divinity's Reach",
                    Email = "srs_bznz@thepact.com",
                    UserName = "srs_bznz@thepact.com",
                    PhoneNumber = "0757896521"
                };
                var C5 = new ApplicationUser
                {
                    FirstName = "Kasmeer",
                    LastName = "Meade",
                    BillingAddress = "14 Grenth Plaza.",
                    BillingZip = "66645",
                    BillingCity = "Divinity's Reach",
                    Email = "pink_butterflies@thepact.com",
                    UserName = "pink_butterflies@thepact.com",
                    PhoneNumber = "0748942482"
                };
                var C6 = new ApplicationUser
                {
                    FirstName = "Frederique",
                    LastName = "Gaston",
                    BillingAddress = "2 Barley Ave.",
                    BillingZip = "87954",
                    BillingCity = "Thompton",
                    Email = "ihatebeer@gmail.com",
                    UserName = "ihatebeer@gmail.com",
                    PhoneNumber = "0724821212"
                };
                var C7 = new ApplicationUser
                {
                    FirstName = "Eoghan",
                    LastName = "McGrath",
                    BillingAddress = "1 Spice Plaza Apts.",
                    BillingZip = "78545",
                    BillingCity = "Verilla",
                    Email = "notavampire@simail.com",
                    UserName = "notavampire@simail.com",
                    PhoneNumber = "0765484852"
                };


                manager.Create(C1, "P@ssword1");
                manager.Create(C2, "P@ssword1");
                manager.Create(C3, "P@ssword1");
                manager.Create(C4, "P@ssword1");
                manager.Create(C5, "P@ssword1");
                manager.Create(C6, "P@ssword1");
                manager.Create(C7, "P@ssword1");
            }
            //Seeds reviews for Interstellar
            var rev1 = new Review
            {
                ID = 1,
                UserID = context.Users.SingleOrDefault(u => u.Email == "notavampire@simail.com").Id,
                MovieID = 1,
                Rating = 5,
                Comment = "This movie is totally awesome. It completely changed my life. Spoiler warning: when the thing happened I was just so thrilled! It's so cool to see Actors performance in this role. Director did the director stuff really well too. I can't wait for a sequel!"
            };
            var rev2 = new Review
            {
                ID = 2,
                UserID = context.Users.SingleOrDefault(u => u.Email == "srs_bznz@thepact.com").Id,
                MovieID = 6,
                Rating = 1,
                Comment = "Meh... The shiny stuff wasn't as shiny as I would've hoped, and the lines were dumb. I particularly hated it when the actor went all 'Hurr durr I'm the protagonist I can do things!' That's just lazy writing."
            };
            var rev3 = new Review
            {
                ID = 3,
                UserID = context.Users.SingleOrDefault(u => u.Email == "pia_loves_bunnies@floof.com.au").Id,
                MovieID = 12,
                Rating = 3,
                Comment = "It's a movie. It is an OK movie. I liked it."
            };
            var rev4 = new Review
            {
                ID = 4,
                UserID = context.Users.SingleOrDefault(u => u.Email == "pink_butterflies@thepact.com").Id,
                MovieID = 2,
                Rating = 5,
                Comment = "Oh my goose, I absolutely LOVE this movie! I've seen it so many times that my disc is all worn out. Jory is getting kind of tired of it, but I can just keep watching it over, and over again! I ordered an extra copy for the commander!"
            };
            var rev5 = new Review
            {
                ID = 5,
                UserID = context.Users.SingleOrDefault(u => u.Email == "srs_bznz@thepact.com").Id,
                MovieID = 2,
                Rating = 4,
                Comment = "I really enjoy this movie. Kas is under the impression that I'm not too fond of it, but the acting is superb and the story is fantastic."
            };
            context.Reviews.AddOrUpdate(r => r.ID, rev1, rev2, rev3, rev4, rev5);

            //Seeds orders
            var order1 = new Order
            {
                ID = 1,
                UserID = context.Users.SingleOrDefault(u => u.Email == "pia_loves_bunnies@floof.com.au").Id,
                OrderDate = DateTime.Now
            };
            var order2 = new Order
            {
                ID = 2,
                UserID = context.Users.SingleOrDefault(u => u.Email == "pink_butterflies@thepact.com").Id,
                OrderDate = DateTime.Now
            };
            context.Orders.AddOrUpdate(or => or.ID, order1, order2);
            //Seeds rows for the orders
            var or1r1 = new OrderRow
            {
                ID = 1,
                MovieID = 6,
                OrderID = 1,
                Price = m6.Price,
                Quantity = 1
            };
            var or1r2 = new OrderRow
            {
                ID = 2,
                MovieID = 3,
                OrderID = 1,
                Price = m3.Price,
                Quantity = 1
            };
            var or2r1 = new OrderRow
            {
                ID = 3,
                MovieID = 2,
                OrderID = 2,
                Price = m2.Price,
                Quantity = 2
            };
            var or2r2 = new OrderRow
            {
                ID = 4,
                MovieID = 4,
                OrderID = 2,
                Price = m4.Price,
                Quantity = 1
            };
            context.OrderRows.AddOrUpdate(row => row.ID, or1r1, or1r2, or2r1, or2r2);


        }
    }
}
