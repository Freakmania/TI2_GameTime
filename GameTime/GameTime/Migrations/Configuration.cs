namespace GameTime.Migrations
{
    using GameTime.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<GameTime.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(GameTime.Models.ApplicationDbContext context)
        {
            //*********************************************************************
            // adiciona UTILIZADOR
            var utilizadores = new List<Utilizador>
            {
                new Utilizador {Id=1, Nome="Asdrúbal Dinossauro", Password="123_Asd",
                    Email ="asdrubal@sapo.pt", NomeUtilizador="asdrubal@sapo.pt",Foto="asdrubal.jpg"},
                new Utilizador {Id=2, Nome="António Lopes", Password="123_Asd",
                    Email ="antonio@sapo.pt", NomeUtilizador="antonio@sapo.pt",Foto="antonio.jpg"},
                new Utilizador {Id=3, Nome="Bárbara Castro", Password="123_Asd",
                    Email ="barbara@sapo.pt", NomeUtilizador="barbara@sapo.pt",Foto="barbara.jpg"},
                new Utilizador {Id=4, Nome="Alexandra Lima", Password="123_Asd",
                    Email ="alexandra@sapo.pt", NomeUtilizador="alexandra@sapo.pt",Foto="alexandra.jpg"},
                new Utilizador {Id=5, Nome="João Canoso", Password="123_Asd",
                    Email ="joao@sapo.pt", NomeUtilizador="joao@sapo.pt",Foto="joao.jpg"},
                new Utilizador {Id=6, Nome="Miguel Silva", Password="123_Asd",
                    Email ="miguel@sapo.pt", NomeUtilizador="miguel@sapo.pt",Foto="miguel.jpg"},
                new Utilizador {Id=7, Nome="Tânia", Password="123_Asd",
                    Email="tania@mail.pt", NomeUtilizador="tania@mail.pt", Foto="tania.jpg"}
            };
            utilizadores.ForEach(uu => context.Utilizador.AddOrUpdate(u => u.Nome, uu));
            context.SaveChanges();

            //*********************************************************************
            // adiciona GENERO
            var genero = new List<Genero> {
                new Genero {Id=1, Nome="Platform"},
                new Genero {Id=2, Nome="Shooter"},
                new Genero {Id=3, Nome="Fighting"},
                new Genero {Id=4, Nome="Stealth"},
                new Genero {Id=5, Nome="Survival"},
                new Genero {Id=6, Nome="Rhythm"},
                new Genero {Id=7, Nome="MMORPG"},
                new Genero {Id=8, Nome="Fantasy"},
                new Genero {Id=9, Nome="RPG"},
                new Genero {Id=10, Nome="Strategy"}
            };
            genero.ForEach(gg => context.Genero.AddOrUpdate(g => g.Nome, gg));
            context.SaveChanges();

            //*********************************************************************
            // adiciona ESTADO do jogo
            var estadoJogo = new List<EstadoJogo> {
                new EstadoJogo {Id=1, Nome="Published"},
                new EstadoJogo {Id=2, Nome="Unpublished"},
            };
            estadoJogo.ForEach(ee => context.EstadoJogo.AddOrUpdate(e => e.Nome, ee));
            context.SaveChanges();

            //*********************************************************************
            // adiciona ESTADO do jogador
            var estadoJogador = new List<EstadoJogador> {
                new EstadoJogador {Id=1, Nome="Played"},
                new EstadoJogador {Id=2, Nome="Will Play"},
                new EstadoJogador {Id=3, Nome="Playing"},
            };
            estadoJogador.ForEach(zz => context.EstadoJogador.AddOrUpdate(z => z.Nome, zz));
            context.SaveChanges();

            //*********************************************************************
            // adiciona JOGO
            var jogo = new List<Jogo> {
                new Jogo {Id=1, Nome="The Elder Scrolls V: Skyrim",
                    Descricao ="The Elder Scrolls V: Skyrim is an action role-playing video game developed by Bethesda Game Studios and published by Bethesda Softworks. It is the fifth main installment in The Elder Scrolls series, following The Elder Scrolls IV: Oblivion, and was originally released worldwide for Microsoft Windows, PlayStation 3, and Xbox 360 on November 11, 2011." +
                    "The game's main story revolves around the player character's quest to defeat Alduin the World-Eater, a dragon who is prophesied to destroy the world. The game is set 200 years after the events of Oblivion and takes place in the fictional province of Skyrim. Over the course of the game, the player completes quests and develops the character by improving skills. The game continues the open-world tradition of its predecessors by allowing the player to travel anywhere in the game world at any time, and to ignore or postpone the main storyline indefinitely.",
                    Capa ="Skyrim_capa.png", Editora="Bethesda", EstadoJogoFK=1, GeneroJogo=9},
                new Jogo {Id=2, Nome="The Witcher 3",
                    Descricao ="The Witcher 3: Wild Hunt is a story-driven, next-generation open world role-playing game, set in a visually stunning fantasy universe, full of meaningful choices and impactful consequences. You play as Geralt of Rivia, a monster hunter tasked with finding a child from an ancient prophecy." +
                    "Geralt of Rivia, is a witcher, or monster hunter for hire, a white - haired and cat - eyed legend in his own time.Trained from early childhood and mutated to gain superhuman skills, strength and reflexes, witchers like Geralt are a natural consequence of and counterbalance to the monster - infested world in which they live.As Geralt, you’ll embark on an epic journey in a war - ravaged world that will inevitably lead you to confront a foe darker than anything humanity has faced so far—the Wild Hunt.",
                    Capa ="Witcher3_capa.png", Editora="CD Projekt",EstadoJogoFK=1, GeneroJogo=9},
                new Jogo {Id=3, Nome="The Elder Scrolls IV: Oblivion",Descricao="Lorem ipsum dolor sit amet, purto patrioque ad sea. Iudicabit patrioque vim ei, id sed everti liberavisse. Everti euismod salutatus et pro, pri habemus repudiare ea, no minim paulo graece eam. No nam stet erant iudico, vis utinam ubique abhorreant et.",
                    Capa ="Oblivion_capa.png", Editora="Bethesda", EstadoJogoFK=1, GeneroJogo=9},
                new Jogo {Id=4, Nome="The Elder Scrolls III: Morrowind",Descricao="Lorem ipsum dolor sit amet, purto patrioque ad sea. Iudicabit patrioque vim ei, id sed everti liberavisse. Everti euismod salutatus et pro, pri habemus repudiare ea, no minim paulo graece eam. No nam stet erant iudico, vis utinam ubique abhorreant et.",
                    Capa ="Morrowind_capa.png", Editora="Bethesda", EstadoJogoFK=1,GeneroJogo=9},
                new Jogo {Id=5, Nome="The Elder Scrolls II: Daggerfall",Descricao="Lorem ipsum dolor sit amet, purto patrioque ad sea. Iudicabit patrioque vim ei, id sed everti liberavisse. Everti euismod salutatus et pro, pri habemus repudiare ea, no minim paulo graece eam. No nam stet erant iudico, vis utinam ubique abhorreant et.",
                    Capa ="Daggerfall_capa.png", Editora="Bethesda", EstadoJogoFK=1, GeneroJogo=9},
                new Jogo {Id=6, Nome="Counter strike: Global offensive",Descricao="Lorem ipsum dolor sit amet, purto patrioque ad sea. Iudicabit patrioque vim ei, id sed everti liberavisse. Everti euismod salutatus et pro, pri habemus repudiare ea, no minim paulo graece eam. No nam stet erant iudico, vis utinam ubique abhorreant et.",
                    Capa ="CSGO_capa.png", Editora="Valve", EstadoJogoFK=1, GeneroJogo=2},
                new Jogo {Id=7, Nome="Grand Theft Auto V",Descricao="Lorem ipsum dolor sit amet, purto patrioque ad sea. Iudicabit patrioque vim ei, id sed everti liberavisse. Everti euismod salutatus et pro, pri habemus repudiare ea, no minim paulo graece eam. No nam stet erant iudico, vis utinam ubique abhorreant et.",
                    Capa ="GTA5_capa.png", Editora="Rockstar", EstadoJogoFK=1, GeneroJogo=2},
                new Jogo {Id=8, Nome="Grand Theft Auto IV",Descricao="Lorem ipsum dolor sit amet, purto patrioque ad sea. Iudicabit patrioque vim ei, id sed everti liberavisse. Everti euismod salutatus et pro, pri habemus repudiare ea, no minim paulo graece eam. No nam stet erant iudico, vis utinam ubique abhorreant et.",
                    Capa ="GTA4_capa.png", Editora="Valve", EstadoJogoFK=1, GeneroJogo=2},
                new Jogo {Id=9, Nome="Grand Theft Auto III",Descricao="Lorem ipsum dolor sit amet, purto patrioque ad sea. Iudicabit patrioque vim ei, id sed everti liberavisse. Everti euismod salutatus et pro, pri habemus repudiare ea, no minim paulo graece eam. No nam stet erant iudico, vis utinam ubique abhorreant et.",
                    Capa ="GTA3_capa.png", Editora="Rockstar", EstadoJogoFK=1, GeneroJogo=2},
                new Jogo {Id=10, Nome="Age of Empires II",Descricao="Lorem ipsum dolor sit amet, purto patrioque ad sea. Iudicabit patrioque vim ei, id sed everti liberavisse. Everti euismod salutatus et pro, pri habemus repudiare ea, no minim paulo graece eam. No nam stet erant iudico, vis utinam ubique abhorreant et.",
                    Capa ="AOE_capa.png", Editora="Microsoft", EstadoJogoFK=1, GeneroJogo=10}
            };
            jogo.ForEach(jj => context.Jogo.AddOrUpdate(j => j.Nome, jj));
            context.SaveChanges();

            //*********************************************************************
            // adiciona LISTA
            var lista = new List<Lista> {
                new Lista {UtilizadorFK=7, JogoFK=1, EstadoJogadorFK=1},
                new Lista {UtilizadorFK=7, JogoFK=2, EstadoJogadorFK=1},
                new Lista {UtilizadorFK=7, JogoFK=3, EstadoJogadorFK=1},
                new Lista {UtilizadorFK=2, JogoFK=1, EstadoJogadorFK=1},
                new Lista {UtilizadorFK=2, JogoFK=2, EstadoJogadorFK=1},
                new Lista {UtilizadorFK=2, JogoFK=3, EstadoJogadorFK=1},
                new Lista {UtilizadorFK=3, JogoFK=1, EstadoJogadorFK=1},
                new Lista {UtilizadorFK=3, JogoFK=2, EstadoJogadorFK=1}
            };
            lista.ForEach(ll => context.Lista.AddOrUpdate(l => l.EstadoJogador, ll));
            context.SaveChanges();

        }
    }
}