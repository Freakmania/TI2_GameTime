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
                new Utilizador {Id=1, Nome="Asdrúbal Dinossauro", Password="1234",
                    Email ="asdrubal@sapo.pt", NomeUtilizador="Asdrúbal",Foto="asdrubal.jpg"},
                new Utilizador {Id=2, Nome="António Lopes", Password="1234",
                    Email ="antonio@sapo.pt", NomeUtilizador="António",Foto="antonio.jpg"},
                new Utilizador {Id=3, Nome="Bárbara Castro", Password="1234",
                    Email ="barbara@sapo.pt", NomeUtilizador="Bárbara",Foto="barbara.jpg"},
                new Utilizador {Id=4, Nome="Alexandra Lima", Password="1234",
                    Email ="alexandra@sapo.pt", NomeUtilizador="Alexandra",Foto="alexandra.jpg"},
                new Utilizador {Id=5, Nome="João Canoso", Password="1234",
                    Email ="joao@sapo.pt", NomeUtilizador="João",Foto="joao.jpg"},
                new Utilizador {Id=6, Nome="Miguel Silva", Password="1234",
                    Email ="miguel@sapo.pt", NomeUtilizador="Miguel",Foto="miguel.jpg"}
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
                new Genero {Id=8, Nome="Fantasy"}
            };
            genero.ForEach(gg => context.Genero.AddOrUpdate(g => g.Nome, gg));
            context.SaveChanges();

            //*********************************************************************
            // adiciona ESTADO do jogo
            var estadoJogo = new List<EstadoJogo> {
                new EstadoJogo {Id=1, Nome="Publicado"},
                new EstadoJogo {Id=2, Nome="Por publicar"},
            };
            estadoJogo.ForEach(ee => context.EstadoJogo.AddOrUpdate(e => e.Nome, ee));
            context.SaveChanges();

            //*********************************************************************
            // adiciona ESTADO do jogador
            var estadoJogador = new List<EstadoJogador> {
                new EstadoJogador {Id=1, Nome="Jogado"},
                new EstadoJogador {Id=2, Nome="Por Jogar"},
                new EstadoJogador {Id=3, Nome="A Jogar"},
            };
            estadoJogador.ForEach(zz => context.EstadoJogador.AddOrUpdate(z => z.Nome, zz));
            context.SaveChanges();

            //*********************************************************************
            // adiciona JOGO
            var jogo = new List<Jogo> {
                new Jogo {Id=1, Nome="Skyrim",Descricao="best game eva", Capa="Skyrim_capa.png", Editora="Bethesda", EstadoJogoFK=1, GeneroJogo=1},
                new Jogo {Id=2, Nome="Witcher",Descricao="best game eva", Capa="", Editora="CD Projekt",EstadoJogoFK=1, GeneroJogo=1},
                new Jogo {Id=3, Nome="LOL",Descricao="best game eva", Capa="", Editora="Riot", EstadoJogoFK=1, GeneroJogo=1},
                new Jogo {Id=4, Nome="Minecraft",Descricao="best game eva", Capa="", Editora="Mojang", EstadoJogoFK=1,GeneroJogo=1},
                new Jogo {Id=5, Nome="Solitário",Descricao="best game eva", Capa="", Editora="", EstadoJogoFK=1, GeneroJogo=1},
                new Jogo {Id=6, Nome="Pinbal",Descricao="best game eva", Capa="", Editora="", EstadoJogoFK=1, GeneroJogo=1}
            };
            jogo.ForEach(jj => context.Jogo.AddOrUpdate(j => j.Nome, jj));
            context.SaveChanges();

            //*********************************************************************
            // adiciona LISTA
            var lista = new List<Lista> {
                new Lista { UtilizadorFK=1, JogoFK=1, EstadoJogadorFK=1},
                new Lista { UtilizadorFK=1, JogoFK=2, EstadoJogadorFK=1},
                new Lista { UtilizadorFK=1, JogoFK=3, EstadoJogadorFK=1},
                new Lista { UtilizadorFK=2, JogoFK=1, EstadoJogadorFK=1},
                new Lista { UtilizadorFK=2, JogoFK=2, EstadoJogadorFK=1},
                new Lista { UtilizadorFK=2, JogoFK=3, EstadoJogadorFK=1},
                new Lista { UtilizadorFK=3, JogoFK=1, EstadoJogadorFK=1},
                new Lista { UtilizadorFK=3, JogoFK=2, EstadoJogadorFK=1}
            };
            lista.ForEach(ll => context.Lista.AddOrUpdate(l => l.EstadoJogador, ll));
            context.SaveChanges();

        }
    }
}