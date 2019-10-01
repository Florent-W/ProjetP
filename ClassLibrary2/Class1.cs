﻿using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Xml;
using System.Windows.Forms;

using MySql.Data.MySqlClient;


namespace ClassLibrary2
{
    /// <summary> 
    /// Classe permettant d'obtenir les attaques, les pokémon et les objets présents dans le jeu
    /// </summary>
    public class Jeu
    {
        private List<Attaque> liste_attaques = new List<Attaque>();
        private List<Pokemon> liste_pokemon = new List<Pokemon>();
        private List<Pokemon> liste_pokemon_starter = new List<Pokemon>();
        private List<Objet> liste_objets = new List<Objet>();

        /// <summary>
        /// Cette méthode permet de récupérer la liste des attaques présentes dans le jeu
        /// </summary>
        /// <returns>Récupère la liste des attaques du jeu</returns>
        public List<Attaque> getListeAttaques()
        {
            return this.liste_attaques;
        }

        /// <summary>
        /// Cette méthode permet de récupérer la liste des pokémon présents dans le jeu
        /// </summary>
        /// <returns>Récupère la liste des pokémon du jeu</returns>
        public List<Pokemon> getListePokemon()
        {
            return this.liste_pokemon;
        }

        /// <summary>
        /// Cette méthode permet de récupérer la liste des starters présents dans le jeu
        /// </summary>
        /// <returns>Récupère la liste des starters du jeu</returns>
        public List<Pokemon> getListePokemonStarter()
        {
            return this.liste_pokemon_starter;
        }

        /// <summary>
        /// Cette méthode permet de récupérer la liste des objets présents dans le jeu
        /// </summary>
        /// <returns>Récupère la liste des objets du jeu</returns>
        public List<Objet> getListeObjet()
        {
            return this.liste_objets;
        }

        /// <summary>
        /// Cette méthode permet d'initialiser la liste des attaques présents dans le jeu
        /// </summary>
        public void initialisationAttaques()
        {
            Attaque attaque = new Attaque();

            liste_attaques.Add(attaque.createAttaque(1, "Charge", 3, 10, "Normal", 40, "Physique", 35, 56, 0));
            liste_attaques.Add(attaque.createAttaque(2, "Vive-Attaque", 3, 10, "Normal", 40, "Physique", 30, 48, 0));
            liste_attaques.Add(attaque.createAttaque(3, "Vitesse ex", 3, 30, "Normal", 80, "Physique", 5, 8, 0));
            liste_attaques.Add(attaque.createAttaque(4, "ecras face", 3, 20, "Normal", 40, "Physique", 35, 56, 0));
            liste_attaques.Add(attaque.createAttaque(0, "default", 0, 0, "Default", 0, "", 0, 0, 0));
            liste_attaques.Add(attaque.createAttaque(5, "Lance-Flammes", 4, 20, "Feu", 90, "Speciale", 15, 24, 10));
            liste_attaques.Add(attaque.createAttaque(6, "Detritus", 5, 10, "Poison", 65, "Speciale", 20, 32, 30));
            liste_attaques.Add(attaque.createAttaque(7, "Crochetvenin", 5, 10, "Poison", 50, "Physique", 15, 24, 50));
            liste_attaques.Add(attaque.createAttaque(8, "Cage-Eclair", 2, 10, "Electrick", 0, "Statut", 20, 32, 100));
            liste_attaques.Add(attaque.createAttaque(9, "Laser Glace", 1, 10, "Glace", 90, "Speciale", 10, 16, 10));
            liste_attaques.Add(attaque.createAttaque(10, "Hypnose", 2, 10, "Psy", 0, "Statut", 20, 32, 60));
        }

        /// <summary>
        /// Cette méthode permet d'initialiser la liste des pokémon présents dans le jeu
        /// </summary>
        public void initialisationPokemon()
        {
            Pokemon pokemon = new Pokemon();

            liste_pokemon.Add(pokemon.createPokemon(45, "Bulbizarre", 1, 1, "Charge", "Laser Glace", "Vive-Attaque", "ecras face", 0, 21, "Calme", "Combat", "Parabolique", 64, 45, 12.5, 49, 49, 45, 65, 65, 31, 31, 31, 31, 31, 31, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, this));
            liste_pokemon.Add(pokemon.createPokemon(70, "Herbizarre", 2, 2, "Charge", null, null, null, 0, 20, "Assuré", "Combat", "Parabolique", 142, 45, 12.5, 12, 30, 120, 129, 30, 20, 12, 30, 1, 20, 10, 42, 43, 43, 33, 23, 23, 0, 0, 0, 0, 1, 1, this));
            liste_pokemon.Add(pokemon.createPokemon(120, "Florizarre", 3, 3, "Charge", null, null, null, 0, 40, null, "Glace", "Parabolique", 236, 45, 12.5, 20, 40, 32, 20, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 1, this));
            liste_pokemon.Add(pokemon.createPokemon(20, "Salamèche", 4, 4, "Charge", null, null, null, 0, 12, null, "Feu", "Parabolique", 62, 45, 12.5, 0, 0, 0, 0, 0, 12, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, this));
            liste_pokemon.Add(pokemon.createPokemon(70, "Reptincel", 5, 5, "Charge", null, null, null, 0, 20, null, "Feu", "Parabolique", 142, 45, 12.5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, this));
            liste_pokemon.Add(pokemon.createPokemon(130, "Dracaufeu", 6, 6, "Charge", null, null, null, 0, 8, null, "Feu", "Parabolique", 240, 45, 12.5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 0, this));
            liste_pokemon.Add(pokemon.createPokemon(20, "Carapuce", 7, 7, "Charge", null, null, null, 0, 15, null, "Eau", "Parabolique", 63, 45, 12.5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, this));
            liste_pokemon.Add(pokemon.createPokemon(70, "Carabaffe", 8, 8, "Laser Glace", null, null, null, 0, 30, null, "Eau", "Parabolique", 142, 45, 12.5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 1, this));
            liste_pokemon.Add(pokemon.createPokemon(150, "Tortank", 9, 9, "Charge", null, null, null, 0, 32, null, "Eau", "Parabolique", 239, 45, 12.5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, this));
        }

        /// <summary>
        /// Cette méthode permet d'initialiser la liste des starters présents dans le jeu
        /// </summary>
        public void initialisationPokemonStarter()
        {
            Pokemon pokemon = new Pokemon();

            liste_pokemon_starter.Add(pokemon.createPokemon(45, "Bulbizarre", 1, 1, "Charge", "Laser Glace", "Vive-Attaque", "ecras face", 0, 21, "Calme", "Combat", "Parabolique", 64, 45, 12.5, 49, 49, 45, 65, 65, 31, 31, 31, 31, 31, 31, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, this));
            liste_pokemon_starter.Add(pokemon.createPokemon(20, "Salamèche", 4, 4, "Charge", null, null, null, 0, 12, null, "Feu", "Parabolique", 62, 45, 12.5, 0, 0, 0, 0, 0, 12, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, this));
            liste_pokemon_starter.Add(pokemon.createPokemon(20, "Carapuce", 7, 7, "Charge", null, null, null, 0, 15, null, "Eau", "Parabolique", 63, 45, 12.5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, this));
        }

        /// <summary>
        /// Cette méthode permet d'initialiser la liste des objets présents dans le jeu
        /// </summary>
        public void initialisationObjets()
        {
            Objet objet = new Objet();

            liste_objets.Add(objet.createObjet(1, "Potion", "Soin", 30, 1));
            liste_objets.Add(objet.createObjet(2, "Hyper Potion", "Soin", 50, 1));
            liste_objets.Add(objet.createObjet(3, "Guerison", "Soin", 200, 1));
            liste_objets.Add(objet.createObjet(4, "Poke Ball", "Capture", 1, 1));
            liste_objets.Add(objet.createObjet(5, "Hyper Ball", "Capture", 2, 1));
            liste_objets.Add(objet.createObjet(8, "Master Ball", "Capture", 98, 1)); 
        }
    }

    /// <summary> 
    /// Classe permettant d'obtenir des personnages ayant des pokemons, des objets
    /// </summary>
    [DataContract]
    public class Personnage
    {
        [DataMember]
        private string m_nom;
        private int m_age;

        [DataMember]
        private List <Pokemon> pokemon_equipe = new List<Pokemon>();
        [DataMember]
        private List <Pokemon> pokemon_pc = new List<Pokemon>();
        [DataMember]
        private List <Objet> m_objets_sac = new List<Objet>();

        /// <summary>
        /// Cette méthode permet d'initialiser le nom et l'âge du personnage
        /// </summary>
        /// <param name=nom, age>Nom et âge du personnage</param>
        public void Perso(string nom, int age)
        {
            this.m_nom = nom;
            this.m_age = age;
        }

        /// <summary>
        /// Cette méthode permet de récupérer le nom du personnage
        /// </summary>
        /// <returns>Récupère le nom du personnage</returns>
        public string getNom()
        {
            return m_nom;
        }

        /// <summary>
        /// Cette méthode permet de récupérer l'âge du personnage
        /// </summary>
        /// <returns>Récupère l'âge du personnage</returns>
        public int getAge()
        {
            return m_age;
        }

        /// <summary>
        /// Cette méthode permet d'initialiser le nom du personnage
        /// </summary>
        /// <param name=nom>Nom du personnage</param>
        public void setNomPersonnage(string nom)
        {
            this.m_nom = nom;
        }

        /// <summary>
        /// Cette méthode permet d'initaliser l'âge du personnage
        /// </summary>
        /// <param name=age>Age du personnage</param>
        public void setAgePersonnage(int age)
        {
            this.m_age = age;
        }

        /// <summary>
        /// Cette méthode permet d'ajouter un pokémon à l'équipe du personnage
        /// </summary>
        /// <param name=poke>Un pokémon</param>
        public void ajouterPokemonEquipe(Pokemon poke)
        {
            poke.setPvRestant(poke.getPv());
            pokemon_equipe.Add(poke);
        }

        /// <summary>
        /// Cette méthode permet d'ajouter un pokémon à l'équipe du personnage
        /// </summary>
        /// <param name=poke>Un pokémon</param>
        public string attraperPokemon(Pokemon poke)
        {          
            poke.setPvRestant(poke.getPvRestant());
            if (this.pokemon_equipe.Count < 6)
            {
                pokemon_equipe.Add(poke);
                return "Equipe";
            }
            else
            {
                pokemon_pc.Add(poke);
                return "PC";
            }
        }

        /// <summary>
        /// Cette méthode permet d'ajouter un objet au sac du personnage
        /// </summary>
        /// <param name=objet>Un objet</param>
        public void ajouterObjetSac(Objet objet)
        {
            // m_objets_sac.Add(objet);
        }

        /*
        public Pokemon getPokemonEquipe2(int positionPokemonEquipe)
        {
            return (Pokemon) pokemon_equipe[positionPokemonEquipe];
        } 
        */

        /// <summary>
        /// Cette méthode permet de retourner tous les objets du sac du personnage
        /// </summary>
        /// <returns>Récupère la liste des objets du sac</returns>
        public List<Objet> getObjetsSac()
        {
            return (List<Objet>)this.m_objets_sac;
        }

        /// <summary>
        /// Cette méthode permet d'initialiser les objets du sac du personnage à partir des données inscrites dans la base de données
        /// </summary>
        public void setObjetsSac()
        {
            accesDonnees db = new accesDonnees();

            this.m_objets_sac = db.selectionObjetsSac();
        }

        /// <summary>
        /// Cette méthode permet d'initialiser les objets du sac du personnage à partir des données inscrites dans les statistiques du jeu
        /// </summary>
        /// <param name=jeu>Statistiques du jeu</param>
        public void setObjetsSacOffline(Jeu jeu)
        {
            this.m_objets_sac = jeu.getListeObjet();
        }

        /// <summary>
        /// Cette méthode permet de retourner tous les pokemon de l'équipe du personnage
        /// </summary>
        /// <returns>Récupère la liste des pokémon du personnage</returns>
        public List<Pokemon> getPokemonEquipe()
        {
            return (List<Pokemon>) pokemon_equipe;
        }

        public List<Pokemon> getPokemonPc()
        {
            return (List<Pokemon>)pokemon_pc;
        }
    }

    /// <summary> 
    /// Classe Pokémon qui possède des attaques, un numéro dans le pokédex
    /// </summary>
    [DataContract]
    public class Pokemon
    {
        [DataMember]
        private int m_id;
        [DataMember]
        private int m_no_id_pokedex;
        [DataMember]
        private string m_nom;
        [DataMember]
        private string m_sexe;

        private int m_statistiques_pv;
        private int m_statistiques_attaque;
        private int m_statistiques_defense;
        private int m_statistiques_vitesse;
        private int m_statistiques_attaque_speciale;
        private int m_statistiques_defense_speciale;
        [DataMember]
        private double m_statistiques_precision = 1;
        [DataMember]
        private double m_statistiques_esquive = 1;
        [DataMember]
        private int m_niveau = 1;
        [DataMember]
        private int m_pv_restant;
        [DataMember]
        private string m_nature;
        [DataMember]
        private string m_type;
        [DataMember]
        private int m_niveau_chance_coup_critique = 1;
        [DataMember]
        private int m_experience = 0;
        [DataMember]
        private string m_courbe_experience;
        [DataMember]
        private int m_gain_experience;
        [DataMember]
        private int m_taux_capture;
        [DataMember]
        private string m_statut = "Normal";

        [DataMember]
        private int m_base_pv;
        [DataMember]
        private int m_base_attaque;
        [DataMember]
        private int m_base_defense;
        [DataMember]
        private int m_base_vitesse;
        [DataMember]
        private int m_base_attaque_speciale;
        [DataMember]
        private int m_base_defense_speciale;
        [DataMember]
        private int m_iv_pv;
        [DataMember]
        private int m_iv_attaque;
        [DataMember]
        private int m_iv_defense;
        [DataMember]
        private int m_iv_vitesse;
        [DataMember]
        private int m_iv_attaque_speciale;
        [DataMember]
        private int m_iv_defense_speciale;

        [DataMember]
        private int m_ev_pv;
        [DataMember]
        private int m_ev_attaque;
        [DataMember]
        private int m_ev_defense;
        [DataMember]
        private int m_ev_vitesse;
        [DataMember]
        private int m_ev_attaque_speciale;
        [DataMember]
        private int m_ev_defense_speciale;
        [DataMember]
        private int m_gain_ev_pv;
        [DataMember]
        private int m_gain_ev_attaque;
        [DataMember]
        private int m_gain_ev_defense;
        [DataMember]
        private int m_gain_ev_vitesse;
        [DataMember]
        private int m_gain_ev_attaque_speciale;
        [DataMember]
        private int m_gain_ev_defense_speciale;

        [DataMember]
        private List<Attaque> m_liste_attaque = new List<Attaque>();
        [DataMember]
        private List<int> m_liste_id_attaque = new List<int>();
        [DataMember]
        private List<string> m_liste_nom_attaque = new List<string>();
        [DataMember]
        private int m_id_type;
        
        private ArrayList type = new ArrayList();

        accesDonnees pokemon = new accesDonnees();

        public void Personnage()
        {

        }

        /// <summary>
        /// Cette méthode permet de récupérer le nom d'un pokémon
        /// </summary>
        /// <returns>Récupère le nom du pokémon</returns>
        public string getNom()
        {
            return m_nom;
        }

        public string getSexe()
        {
            return m_sexe; 
        }

        /// <summary>
        /// Cette méthode permet de récupérer la statistique de base des PV d'un pokémon
        /// </summary>
        /// <returns>Récupère la statistique de base des PV du pokémon</returns>
        public int getBasePv()
        {
            return m_base_pv;
        }

        /// <summary>
        /// Cette méthode permet de récupérer les PV d'un pokémon
        /// </summary>
        /// <returns>Récupère les PV du pokémon</returns>
        public int getPv()
        {
            double niveau = this.m_niveau;
            double base_pv = this.m_base_pv;
            double iv_pv = this.m_iv_pv;
            double ev_pv = this.m_ev_pv;

            double pv = Math.Floor((iv_pv + (2 * base_pv) + (ev_pv / 4)) * (niveau / 100) + 10 + niveau);
            int resultat = (int)pv;
            return resultat;
        }

        // <summary>
        /// Cette méthode permet de récupérer la statistique attaque d'un pokémon
        /// </summary>
        /// <returns>Récupère la statistique attaque du pokémon</returns>
        public int getStatistiquesAttaque()
        {
            double bonusNature = 1;

            double niveau = this.m_niveau;
            double base_attaque = this.m_base_attaque;
            double iv_attaque = this.m_iv_attaque;
            double ev_attaque = this.m_ev_attaque;

            if(this.m_nature == "Solo" || this.m_nature == "Brave" || this.m_nature == "Rigide" || this.m_nature == "Mauvais")
            {
                bonusNature = 1.1; 
            }

            else if (this.m_nature == "Assuré" || this.m_nature == "Timide" || this.m_nature == "Modeste" || this.m_nature == "Calme")
            {
                bonusNature = 0.9;
            }

            double attaque = Math.Floor(Math.Floor((iv_attaque + 2 * base_attaque + Math.Floor(ev_attaque / 4)) * (niveau / 100) + 5) * bonusNature);
            int resultat = (int)attaque;
            return resultat;
        }

        // <summary>
        /// Cette méthode permet de récupérer la statistique défense d'un pokémon
        /// </summary>
        /// <returns>Récupère la statistique défense du pokémon</returns>
        public int getStatistiquesDefense()
        {
            double bonusNature = 1;

            double niveau = this.m_niveau;
            double base_defense = this.m_base_defense;
            double iv_defense = this.m_iv_defense;
            double ev_defense = this.m_ev_defense;

            if (this.m_nature == "Assuré" || this.m_nature == "Relax" || this.m_nature == "Malin" || this.m_nature == "Lâche")
            {
                bonusNature = 1.1;
            }

            else if (this.m_nature == "Solo" || this.m_nature == "Pressé" || this.m_nature == "Doux" || this.m_nature == "Gentil")
            {
                bonusNature = 0.9;
            }

            double defense = Math.Floor(Math.Floor((iv_defense + 2 * base_defense + Math.Floor(ev_defense / 4)) * (niveau / 100) + 5) * bonusNature);
            int resultat = (int)defense;
            return resultat;
        }

        // <summary>
        /// Cette méthode permet de récupérer la statistique vitesse d'un pokémon
        /// </summary>
        /// <returns>Récupère la statistique vitesse du pokémon</returns>
        public int getStatistiquesVitesse()
        {
            double bonusNature = 1;

            double niveau = this.m_niveau;
            double base_vitesse = this.m_base_vitesse;
            double iv_vitesse = this.m_iv_vitesse;
            double ev_vitesse = this.m_ev_vitesse;

            if (this.m_nature == "Timide" || this.m_nature == "Pressé" || this.m_nature == "Jovial" || this.m_nature == "Naif")
            {
                bonusNature = 1.1;
            }

            else if (this.m_nature == "Brave" || this.m_nature == "Relax" || this.m_nature == "Discret" || this.m_nature == "Malpoli")
            {
                bonusNature = 0.9;
            }

            double vitesse = Math.Floor(Math.Floor((iv_vitesse + 2 * base_vitesse + Math.Floor(ev_vitesse / 4)) * (niveau / 100) + 5) * bonusNature);

            if(this.m_statut == "Paralysie")
            {
                vitesse = vitesse / 2;
            }

            int resultat = (int)vitesse;
            return resultat;
        }

        // <summary>
        /// Cette méthode permet de récupérer la statistique attaque spéciale d'un pokémon
        /// </summary>
        /// <returns>Récupère la statistique attaque spéciale du pokémon</returns>
        public int getStatistiquesAttaqueSpeciale()
        {
            double bonusNature = 1;

            double niveau = this.m_niveau;
            double base_attaque_speciale = this.m_base_attaque_speciale;
            double iv_attaque_speciale = this.m_iv_attaque_speciale;
            double ev_attaque_speciale = this.m_ev_attaque_speciale;

            if (this.m_nature == "Modeste" || this.m_nature == "Doux" || this.m_nature == "Discret" || this.m_nature == "Foufou")
            {
                bonusNature = 1.1;
            }

            else if (this.m_nature == "Rigide" || this.m_nature == "Malin" || this.m_nature == "Jovial" || this.m_nature == "Prudent")
            {
                bonusNature = 0.9;
            }

            double attaque_speciale = Math.Floor(Math.Floor((iv_attaque_speciale + 2 * base_attaque_speciale + Math.Floor(ev_attaque_speciale / 4)) * (niveau / 100) + 5) * bonusNature);
            int resultat = (int)attaque_speciale;
            return resultat;
        }

        // <summary>
        /// Cette méthode permet de récupérer la statistique défense spéciale d'un pokémon
        /// </summary>
        /// <returns>Récupère la statistique de base des PV du pokémon</returns>
        public int getStatistiquesDefenseSpeciale()
        {
            double bonusNature = 1;

            double niveau = this.m_niveau;
            double base_defense_speciale = this.m_base_defense_speciale;
            double iv_defense_speciale = this.m_iv_defense_speciale;
            double ev_defense_speciale = this.m_ev_defense_speciale;

            if (this.m_nature == "Calme" || this.m_nature == "Gentil" || this.m_nature == "Malpoli" || this.m_nature == "Prudent")
            {
                bonusNature = 1.1;
            }

            else if (this.m_nature == "Mauvais" || this.m_nature == "Lâche" || this.m_nature == "Naif" || this.m_nature == "Foufou")
            {
                bonusNature = 0.9;
            }

            double defense_speciale = Math.Floor(Math.Floor((iv_defense_speciale + 2 * base_defense_speciale + Math.Floor(ev_defense_speciale / 4)) * (niveau / 100) + 5) * bonusNature);
            int resultat = (int)defense_speciale;
            return resultat;
        }

        // <summary>
        /// Cette méthode permet de récupérer la statistique précision d'un pokémon
        /// </summary>
        /// <returns>Récupère la statistique précision du pokémon</returns>
        public double getStatistiquesPrecisionPokemon()
        {
            return this.m_statistiques_precision;
        }

        // <summary>
        /// Cette méthode permet de récupérer la statistique esquive d'un pokémon
        /// </summary>
        /// <returns>Récupère la statistique esquive du pokémon</returns>
        public double getStatistiquesEsquivePokemon()
        {
            return this.m_statistiques_esquive;
        }

        // <summary>
        /// Cette méthode permet de récupérer les PV restant d'un pokémon
        /// </summary>
        /// <returns>Récupère les PV restants du pokémon</returns>
        public int getPvRestant()
        {
            return m_pv_restant;
        }

        // <summary>
        /// Cette méthode permet de récupérer le niveau d'un pokémon
        /// </summary>
        /// <returns>Récupère le niveau du pokémon</returns>
        public int getNiveau()
        {
            return m_niveau;
        }

        // <summary>
        /// Cette méthode permet de récupérer l'id d'un pokémon
        /// </summary>
        /// <returns>Récupère l'id du pokémon</returns>
        public int getIdPokedex()
        {
            return m_id;
        }

        // <summary>
        /// Cette méthode permet de récupérer le numéro du pokédex d'un pokémon
        /// </summary>
        /// <returns>Récupère le numéro du pokédex d'un pokémon</returns>
        public int getNoIdPokedex()
        {
            return m_no_id_pokedex;
        }

        // <summary>
        /// Cette méthode permet de récupérer la nature d'un pokémon
        /// </summary>
        /// <returns>Récupère la nature du pokémon</returns>
        public string getNature()
        {
            return this.m_nature;
        }

        // <summary>
        /// Cette méthode permet de récupérer le type d'un pokémon
        /// </summary>
        /// <returns>Récupère le type du pokémon</returns>
        public string getType()
        {
            return this.m_type;
        }

        // <summary>
        /// Cette méthode permet de récupérer le niveau de chance de coup critique d'un pokémon
        /// </summary>
        /// <returns>Récupère le niveau de chance de coup critique du pokémon</returns>
        public int getNiveauCoupCritique()
        {
            return this.m_niveau_chance_coup_critique;
        }

        // <summary>
        /// Cette méthode permet de retourner l'expérience du pokémon
        /// </summary>
        /// <returns>Récupère l'expérience du pokémon</returns>
        public int getExperience()
        {
            return this.m_experience;
        }

        // <summary>
        /// Cette méthode permet de récupérer le type de courbe d'expérience du pokémon
        /// </summary>
        /// <returns>Récupère le type de la courbe d'expérience du pokémon</returns>
        public string getTypeCourbeExperience()
        {
            return this.m_courbe_experience;
        }

        // <summary>
        /// Cette méthode permet de récupérer l'expérience (qui sert dans la formule pour calculer l'expérience gagné) que peut obtenir le pokémon adverse une fois celui-ci battu
        /// </summary>
        /// <returns>Récupère le gain d'expérience du pokémon une fois celui-ci battu</returns>
        public int getGainExperiencePokemon()
        {
            return this.m_gain_experience;
        }

        // <summary>
        /// Cette méthode permet de récupérer le taux de capture d'un pokémon (qui sert pour la formule pour calculer le taux de capture)
        /// </summary>
        /// <returns>Récupère le taux de capture du pokémon</returns>
        public int getTauxCapturePokemon()
        {
            return this.m_taux_capture;
        }

        // <summary>
        /// Cette méthode permet de récupérer le statut du pokémon
        /// </summary>
        /// <returns>Récupère le statut du pokémon</returns>
        public string getStatutPokemon()
        {
            return this.m_statut;
        }

        // <summary>
        /// Cette méthode permet de récupérer l'ID de l'attaque 1 d'un pokémon
        /// </summary>
        /// <returns>Récupère l'ID de l'attaque 1 du pokémon</returns>
        public int getIdAttaque1()
        {
            return m_liste_id_attaque[0];
        }

        // <summary>
        /// Cette méthode permet de récupérer l'ID de l'attaque 2 d'un pokémon
        /// </summary>
        /// <returns>Récupère l'ID de l'attaque 2 du pokémon</returns>
        public int getIdAttaque2()
        {
            return m_liste_id_attaque[1];
        }

        // <summary>
        /// Cette méthode permet de récupérer l'ID de l'attaque 3 d'un pokémon
        /// </summary>
        /// <returns>Récupère l'ID de l'attaque 3 du pokémon</returns>
        public int getIdAttaque3()
        {
            return m_liste_id_attaque[2];
        }

        // <summary>
        /// Cette méthode permet de récupérer l'ID de l'attaque 4 d'un pokémon
        /// </summary>
        /// <returns>Récupère l'ID de l'attaque 4 du pokémon</returns>
        public int getIdAttaque4()
        {
            return m_liste_id_attaque[3];
        }

        // <summary>
        /// Cette méthode permet de récupérer l'attaque 1 d'un pokémon
        /// </summary>
        /// <returns>Récupère l'attaque 1 du pokémon</returns>
        public Attaque getAttaque1()
        {
            return m_liste_attaque[0];
        }

        // <summary>
        /// Cette méthode permet de récupérer l'attaque 2 d'un pokémon
        /// </summary>
        /// <returns>Récupère l'attaque 2 du pokémon</returns>
        public Attaque getAttaque2()
        {
            return m_liste_attaque[1];
        }

        // <summary>
        /// Cette méthode permet de récupérer l'attaque 3 d'un pokémon
        /// </summary>
        /// <returns>Récupère l'attaque 3 du pokémon</returns>
        public Attaque getAttaque3()
        {
            return m_liste_attaque[2];
        }

        // <summary>
        /// Cette méthode permet de récupérer l'attaque 4 d'un pokémon
        /// </summary>
        /// <returns>Récupère l'attaque 4 du pokémon</returns>
        public Attaque getAttaque4()
        {
            return m_liste_attaque[3];
        }

        // <summary>
        /// Cette méthode permet de récupérer le nom de l'attaque 1 d'un pokémon
        /// </summary>
        /// <returns>Récupère le nom de l'attaque 1 du pokémon</returns>
        public string getNomAttaque1()
        {
            return m_liste_nom_attaque[0];
        }

        // <summary>
        /// Cette méthode permet de récupérer le nom de l'attaque 2 d'un pokémon
        /// </summary>
        /// <returns>Récupère le nom de l'attaque 2 du pokémon</returns>
        public string getNomAttaque2()
        {
            return m_liste_nom_attaque[1];
        }

        // <summary>
        /// Cette méthode permet de récupérer le nom de l'attaque 3 d'un pokémon
        /// </summary>
        /// <returns>Récupère le nom de l'attaque 3 du pokémon</returns>
        public string getNomAttaque3()
        {
            return m_liste_nom_attaque[2];
        }

        // <summary>
        /// Cette méthode permet de récupérer le nom de l'attaque 4 d'un pokémon
        /// </summary>
        /// <returns>Récupère le nom de l'attaque 4 du pokémon</returns>
        public string getNomAttaque4()
        {
            return m_liste_nom_attaque[3];
        }

        // <summary>
        /// Cette méthode permet de récupérer toutes les attaques d'un pokémon
        /// </summary>
        /// <returns>Récupère les attaques du pokémon</returns>
        public List<Attaque> getListeAttaque()
        {
            return m_liste_attaque;
        }

        // <summary>
        /// Cette méthode permet de récupérer la statistique de base d'attaque d'un pokémon
        /// </summary>
        /// <returns>Récupère la statistique de base d'attaque du pokémon</returns>
        public int getBaseAttaque()
        {
            return m_base_attaque;
        }

        // <summary>
        /// Cette méthode permet de récupérer la statistique de base de défense d'un pokémon
        /// </summary>
        /// <returns>Récupère la statistique de base de défense du pokémon</returns>
        public int getBaseDefense()
        {
            return m_base_defense;
        }

        // <summary>
        /// Cette méthode permet de récupérer la statistique de base de vitesse d'un pokémon
        /// </summary>
        /// <returns>Récupère la statistique de base de vitesse du pokémon</returns>
        public int getBaseVitesse()
        {
            return m_statistiques_vitesse;
        }

        // <summary>
        /// Cette méthode permet de récupérer la statistique de base d'attaque spéciale d'un pokémon
        /// </summary>
        /// <returns>Récupère la statistique de base d'attaque spéciale du pokémon</returns>
        public int getBaseAttaqueSpeciale()
        {
            return m_statistiques_attaque_speciale;
        }

        // <summary>
        /// Cette méthode permet de récupérer la statistique de base de défense spéciale d'un pokémon
        /// </summary>
        /// <returns>Récupère la statistique de base de défense spéciale du pokémon</returns>
        public int getBaseDefenseSpeciale()
        {
            return m_statistiques_defense_speciale;
        }

        // <summary>
        /// Cette méthode permet de récupérer les IV PV d'un pokémon
        /// </summary>
        /// <returns>Récupère les IV PV du pokémon</returns>
        public int getIvPv()
        {
            return m_iv_pv;
        }

        // <summary>
        /// Cette méthode permet de récupérer les IV Attaque d'un pokémon
        /// </summary>
        /// <returns>Récupère les IV Attaque du pokémon</returns>
        public int getIvAttaque()
        {
            return m_iv_attaque;
        }

        // <summary>
        /// Cette méthode permet de récupérer les IV Défense d'un pokémon
        /// </summary>
        /// <returns>Récupère les IV Défense du pokémon</returns>
        public int getIvDefense()
        {
            return m_iv_defense;
        }

        // <summary>
        /// Cette méthode permet de récupérer les IV Vitesse d'un pokémon
        /// </summary>
        /// <returns>Récupère les IV Vitesse du pokémon</returns>
        public int getIvVitesse()
        {
            return m_iv_vitesse;
        }

        // <summary>
        /// Cette méthode permet de récupérer les IV Attaque Spéciale d'un pokémon
        /// </summary>
        /// <returns>Récupère les IV Attaque Spéciale du pokémon</returns>
        public int getIvAttaqueSpeciale()
        {
            return m_iv_attaque_speciale;
        }

        // <summary>
        /// Cette méthode permet de récupérer les IV Défense Spéciale d'un pokémon
        /// </summary>
        /// <returns>Récupère les IV Défense Spéciale du pokémon</returns>
        public int getIvDefenseSpeciale()
        {
            return m_iv_defense_speciale;
        }

        // <summary>
        /// Cette méthode permet de récupérer les EV PV d'un pokémon
        /// </summary>
        /// <returns>Récupère les EV PV du pokémon</returns>
        public int getEvPv()
        {
            return m_ev_pv;
        }

        // <summary>
        /// Cette méthode permet de récupérer les EV Attaque d'un pokémon
        /// </summary>
        /// <returns>Récupère les EV Attaque du pokémon</returns>
        public int getEvAttaque()
        {
            return m_ev_attaque;
        }

        // <summary>
        /// Cette méthode permet de récupérer les EV Défense d'un pokémon
        /// </summary>
        /// <returns>Récupère les EV Défense du pokémon</returns>
        public int getEvDefense()
        {
            return m_ev_defense;
        }

        // <summary>
        /// Cette méthode permet de récupérer les EV Vitesse d'un pokémon
        /// </summary>
        /// <returns>Récupère les EV Vitesse du pokémon</returns>
        public int getEvVitesse()
        {
            return m_ev_vitesse;
        }

        // <summary>
        /// Cette méthode permet de récupérer les EV Attaque Spéciale d'un pokémon
        /// </summary>
        /// <returns>Récupère les EV Attaque Spéciale du pokémon</returns>
        public int getEvAttaqueSpeciale()
        {
            return m_ev_attaque_speciale;
        }

        // <summary>
        /// Cette méthode permet de récupérer les EV Défense Spéciale d'un pokémon
        /// </summary>
        /// <returns>Récupère les EV Défense Spéciale du pokémon</returns>
        public int getEvDefenseSpeciale()
        {
            return m_ev_defense_speciale;
        }

        // <summary>
        /// Cette méthode permet de récupérer les EV PV que peut obtenir le pokémon adverse une fois celui-ci battu
        /// </summary>
        /// <returns>Récupère le gain d'EV PV du pokémon une fois celui-ci battu</returns>
        public int getGainEvPv()
        {
            return m_gain_ev_pv;
        }

        // <summary>
        /// Cette méthode permet de récupérer les EV Attaque que peut obtenir le pokémon adverse une fois celui-ci battu
        /// </summary>
        /// <returns>Récupère le gain d'EV Attaque du pokémon une fois celui-ci battu</returns>
        public int getGainEvAttaque()
        {
            return m_gain_ev_attaque;
        }

        // <summary>
        /// Cette méthode permet de récupérer les EV Défense que peut obtenir le pokémon adverse une fois celui-ci battu
        /// </summary>
        /// <returns>Récupère le gain d'EV Défense du pokémon une fois celui-ci battu</returns>
        public int getGainEvDefense()
        {
            return m_gain_ev_defense;
        }

        // <summary>
        /// Cette méthode permet de récupérer les EV Vitesse que peut obtenir le pokémon adverse une fois celui-ci battu
        /// </summary>
        /// <returns>Récupère le gain d'EV Vitesse du pokémon une fois celui-ci battu</returns>
        public int getGainEvVitesse()
        {
            return m_gain_ev_vitesse;
        }

        // <summary>
        /// Cette méthode permet de récupérer les EV Attaque Spéciale que peut obtenir le pokémon adverse une fois celui-ci battu
        /// </summary>
        /// <returns>Récupère le gain d'EV Attaque Spéciale du pokémon une fois celui-ci battu</returns>
        public int getGainEvAttaqueSpeciale()
        {
            return m_gain_ev_attaque_speciale;
        }

        // <summary>
        /// Cette méthode permet de récupérer les EV Défense que peut obtenir le pokémon adverse une fois celui-ci battu
        /// </summary>
        /// <returns>Récupère le gain d'EV Défense Spéciale du pokémon une fois celui-ci battu</returns>
        public int getGainEvDefenseSpeciale()
        {
            return m_gain_ev_defense_speciale;
        }

        // <summary>
        /// Cette méthode permet d'initialiser les pv
        /// </summary>
        public void setPvJoueur()
        {
            m_statistiques_pv = 200;
        }

        /// <summary>
        /// Cette méthode permet d'initialiser les pv restants d'un pokémon
        /// </summary>
        /// <param name=pvRestant>Le nombre de pv restant du pokémon</param>
        public void setPvRestant(int pvRestant)
        {
            m_pv_restant = pvRestant;
        }

        /// <summary>
        /// Cette méthode permet de choisir l'attaque d'un pokemon adversaire au hasard
        /// </summary>
        /// <param name=pokemonOffensif, pokemonDefenseur>Un pokémon qui attaque, un autre qui défend</param>
        /// <returns>Attaque choisi au hasard parmi la liste d'attaque du pokémon</returns>
        public Attaque attaqueAdversaire(Pokemon pokemonOffensif, Pokemon pokemonDefenseur)
        {
            List<Attaque> liste_attaque = new List<Attaque>();

            for (int i = 0; i < m_liste_attaque.Count; i++)
            {
                if (m_liste_attaque[i].getId() > 0 && m_liste_attaque[i].getPPRestant() > 0)
                {
                    liste_attaque.Add(m_liste_attaque[i]);
                }
            }

            if (liste_attaque.Count > 0)
            {
                Random rand = new Random();
                int index = rand.Next(liste_attaque.Count);
                return liste_attaque[index]; 
            }
            else
            {
                return null;
            }

         //  MessageBox.Show(liste_attaque[index].getNom().ToString());
            
        }

        /// <summary>
        /// Cette méthode permet de vérifier si le pokémon a des attaques
        /// </summary>
        /// <param name=poke>Un pokémon</param>
        /// <returns>Vrai si le pokémon a des attaques sinon faux</returns>
        public bool pokemonADesAttaques(Pokemon poke)
        {
            if(poke.m_liste_attaque.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /*
        public string getNomPokemon(int id_pokedex)
        {
            string[] Pokemon = { "Bulbizarre", "Herbizarre", "Florizarre", "Carapuce", "Carabaffe", "Tortank", "Salamèche", "Reptincel", "Dracaufeu" };
            return Pokemon[id_pokedex];
        }
       */

        /// <summary>
        /// Cette méthode permet de récupérer le nom d'un pokémon au hasard dans la base de données
        /// </summary>
        /// <returns>Nom d'un pokémon au hasard</returns>
        public string setNom()
        {
            /*
            string[] Pokemon = { "Bulbizarre", "Carapuce", "Salamèche" };
            Random rand = new Random();
            int index = rand.Next(Pokemon.Length);
            return Pokemon[index];
            
             */

            ArrayList nomPokemon = pokemon.selectionPokemon();
            Random rand = new Random();

            int index = rand.Next(nomPokemon.Count);
            return nomPokemon[index].ToString();
        }

        /// <summary>
        /// Cette méthode permet de récupérer un pokémon au hasard dans la base de données
        /// </summary>
        /// <returns>Pokémon au hasard</returns>
        public Pokemon setPokemon()
        {
            List<Pokemon> liste_pokemon = pokemon.selectionListePokemon();
            Random rand = new Random();

            int index = rand.Next(liste_pokemon.Count);

            return liste_pokemon[index];
        }

        /// <summary>
        /// Cette méthode permet de créer et d'initialiser un pokémon
        /// </summary>
        /// <param name=basePvPokemon>Base pv</param>
        /// <param name=nomPokémon>Nom</param>
        /// <param name=idPokemon>Id du pokémon</param>
        /// <param name=noIdPokedex>Numéro du pokémon dans le pokédex</param>
        /// <param name=nomAttaque1>Nom de l'attaque 1</param>
        /// <param name=nomAttaque2>Nom de l'attaque 2</param>
        /// <param name=nomAttaque3>Nom de l'attaque 3</param>
        /// <param name=nomAttaque4>Nom de l'attaque 4</param>
        /// <param name=idType>Id du type du pokémon</param>
        /// <param name=niveau>Niveau du pokémon</param>
        /// <param name=nature>Nature du pokémon</param>
        /// <param name=type>Type du pokémon</param>
        /// <param name=courbeExperience>Type de courbe de l'expérience du pokémon</param>
        /// <param name=gainExperience>Nombre de point d'expérience reçu si le pokémon est battu</param>
        /// <param name=tauxCapture>Le taux de capture du pokémon</param>
        /// <param name=probabiliteSexeFeminin>Probabilité que le pokémon soit féminin</param>
        /// <param name=baseAttaque>Base attaque</param>
        /// <param name=baseDefense>Base défense</param>
        /// <param name=baseVitesse>Base vitesse</param>
        /// <param name=baseAttaqueSpeciale>Base attaque spéciale</param>
        /// <param name=baseDefenseSpeciale>Base défense spéciale</param>
        /// <param name=ivPv>IV PV</param>
        /// <param name=ivAttaque>IV Attaque</param>
        /// <param name=ivDefense>IV Défense</param>
        /// <param name=ivVitesse>IV Vitesse</param>
        /// <param name=ivAttaqueSpeciale>IV Attaque Spéciale</param>
        /// <param name=ivDefenseSpeciale>IV Defense Spéciale</param>
        /// <param name=evPv>EV PV</param>
        /// <param name=evAttaque>EV Attaque</param>
        /// <param name=evDefense>EV Défense</param>
        /// <param name=evVitesse>EV Vitesse</param>
        /// <param name=evAttaqueSpeciale>EV Attaque Spéciale</param>
        /// <param name=evDefenseSpeciale>EV Defense Spéciale</param>
        /// <param name=gainEvPv>Gain d'EV PV une fois le pokémon battu</param>
        /// <param name=gainEvAttaque>Gain d'EV Attaque une fois le pokémon battu</param>
        /// <param name=gainEvDefense>Gain d'EV Défense une fois le pokémon battu</param>
        /// <param name=gainEvVitesse>Gain d'EV Vitesse une fois le pokémon battu</param>
        /// <param name=gainEvAttaqueSpeciale>Gain d'EV Attaque Spéciale une fois le pokémon battu</param>
        /// <param name=gainEvDefenseSpeciale>Gain d'EV Défense Spéciale une fois le pokémon battu</param>
        /// <param name=jeu>Statistiques et données du jeu</param>
        /// <returns>Le pokémon</returns>
        public Pokemon createPokemon(int basePvPokemon, string nomPokemon, int idPokemon, int noIdPokedex, string nomAttaque1, string nomAttaque2, string nomAttaque3, string nomAttaque4, int idType, int niveau, string nature, string type, string courbeExperience, int gainExperience, int tauxCapture, double probabiliteSexeFeminin, int baseAttaque, int baseDefense, int baseVitesse, int baseAttaqueSpeciale, int baseDefenseSpeciale, int ivPv, int ivAttaque, int ivDefense, int ivVitesse, int ivAttaqueSpeciale, int ivDefenseSpeciale, int evPv, int evAttaque, int evDefense, int evVitesse, int evAttaqueSpeciale, int evDefenseSpeciale, int gainEvPv, int gainEvAttaque, int gainEvDefense, int gainEvVitesse, int gainEvAttaqueSpeciale, int gainEvDefenseSpeciale, Jeu jeu)
        {
            Pokemon poke = new Pokemon();

            poke.setPokemon(nomPokemon);
            poke.setIdPokemonAvecId(idPokemon);
            poke.setNoPokedexPokemon(noIdPokedex);
            poke.setSexeRand(probabiliteSexeFeminin);
            poke.setNomAttaque1(nomAttaque1);
            poke.setNomAttaque2(nomAttaque2);
            poke.setNomAttaque3(nomAttaque3);
            poke.setNomAttaque4(nomAttaque4);
            poke.setNiveau(niveau);
            poke.setNature(nature);
            poke.setType(type);
            poke.setTypeCourbeExperience(courbeExperience);
            poke.setGainExperiencePokemon(gainExperience);
            poke.getExperiencePokemon();
            poke.setTauxCapturePokemon(tauxCapture);

            poke.setBasePvPokemon(basePvPokemon);
            poke.setBaseAttaque(baseAttaque);
            poke.setBaseDefense(baseDefense);
            poke.setBaseVitesse(baseVitesse);
            poke.setBaseAttaqueSpeciale(baseAttaqueSpeciale);
            poke.setBaseDefenseSpeciale(baseDefenseSpeciale);

            poke.setIvPv(ivPv);
            poke.setIvAttaque(ivAttaque);
            poke.setIvDefense(ivDefense);
            poke.setIvVitesse(ivVitesse);
            poke.setIvAttaqueSpeciale(ivAttaqueSpeciale);
            poke.setIvDefenseSpeciale(ivDefenseSpeciale);

            poke.setEvPv(evPv);
            poke.setEvAttaque(evAttaque);
            poke.setEvDefense(evDefense);
            poke.setEvVitesse(evVitesse);
            poke.setEvAttaqueSpeciale(evAttaqueSpeciale);
            poke.setEvDefenseSpeciale(evDefenseSpeciale);

            poke.setGainEvPv(gainEvPv);
            poke.setGainEvAttaque(gainEvAttaque);
            poke.setGainEvDefense(gainEvDefense);
            poke.setGainEvVitesse(gainEvVitesse);
            poke.setGainEvAttaqueSpeciale(gainEvAttaqueSpeciale);
            poke.setGainEvDefenseSpeciale(gainEvDefenseSpeciale);

            // poke.setPvRestant(poke.getPv());
            poke.setAllAttacksWithNomOffline(jeu);

            return poke;
        }

        /// <summary>
        /// Cette méthode permet de retourner un pokémon aléatoire à partir des données du jeu
        /// </summary>
        /// <param name=jeu>Données du jeu</param>
        /// <returns>Un pokémon aléatoire</returns>
        public Pokemon setRandomPokemon(Jeu jeu)
        {
            List<Pokemon> liste_pokemon = jeu.getListePokemon();
            Random rand = new Random();

            int index = rand.Next(liste_pokemon.Count);

            return liste_pokemon[index];
        }

        /// <summary>
        /// Cette méthode permet de retourner un pokémon à partir du nom du pokémon recherché et des données du jeu
        /// </summary>
        /// <param name=nomPokemon>Nom du pokémon cherché</param>
        /// <param name=jeu>Données du jeu</param>
        /// <returns>Le pokémon cherché</returns>
        public Pokemon setChercherPokemon(string nomPokemon, Jeu jeu)
        {
            return jeu.getListePokemon().Find(pokemon => pokemon.getNom().Equals(nomPokemon));
        }


        /// <summary>
        /// Cette méthode permet de retourner un pokémon starter à partir du nom du pokémon recherché et des données du jeu
        /// </summary>
        /// <param name=nomPokemon>Nom du pokémon</param>
        /// <param name=jeu>Données du jeu</param>
        /// <returns>Le pokémon starter</returns>
        public Pokemon setChercherPokemonStarter(string nomPokemon, Jeu jeu)
        {
            return jeu.getListePokemonStarter().Find(pokemon => pokemon.getNom().Equals(nomPokemon));
        }

        /// <summary>
        /// Cette méthode permet d'initialiser la base des pv d'un pokémon
        /// </summary>
        /// <param name=basePv>La base pv du pokémon</param>
        public void setBasePvPokemon(int basePv)
        {
            this.m_base_pv = basePv;
        }

        /// <summary>
        /// Cette méthode permet d'initialiser l'ID d'un pokémon à l'aide de la base de données
        /// </summary>
        /// <param name=poke>Un pokémon</param>
        public void setIdPokemon(Pokemon poke)
        {
            this.m_id = pokemon.selectionIdPokemon(poke);
        }

        /// <summary>
        /// Cette méthode permet d'initialiser l'ID d'un pokémon
        /// </summary>
        /// <param name=id>L'ID du pokémon</param>
        public void setIdPokemonAvecId(int id)
        {
            this.m_id = id;
        }

        /// <summary>
        /// Cette méthode permet le numéro du pokédex d'un pokémon
        /// </summary>
        /// <param name=no_id_pokedex>Numéro du pokédex du pokémon</param>
        public void setNoPokedexPokemon(int no_id_pokedex)
        {
            this.m_no_id_pokedex = no_id_pokedex;
        }

        /// <summary>
        /// Cette méthode permet de retourner les pv d'un pokémon au hasard
        /// </summary>
        /// <param name=p1>Un pokémon</param>
        /// <returns>Des pv au hasard</returns>
        public int setPv(Pokemon p1)
        {

            ArrayList pv = pokemon.selectionPvPokemon(p1.getNom().ToString());
            Random rand = new Random();
            int index = rand.Next(pv.Count);
            return Convert.ToInt32(pv[index]);
        }

        /// <summary>
        /// Cette méthode permet d'initialiser le nom d'un pokémon
        /// </summary>
        /// <param name=poke>Un pokémon</param>
        public void setPokemon(string nom)
        {
            this.m_nom = nom;
        }

        /// <summary>
        /// Cette méthode permet d'initialiser le sexe d'un pokémon
        /// </summary>
        /// <param name=sexe>Le sexe du pokémon</param>
        public void setSexe(string sexe)
        {
            this.m_sexe = sexe;
        }

        /// <summary>
        /// Cette méthode permet d'initialiser le sexe d'un pokémon à l'aide de la probabilité qu'un pokémon soit de sexe féminin
        /// </summary>
        /// <param name=probabiliteSexeFeminin>La probabilité qu'un pokémon soit de sexe féminin</param>
        public void setSexeRand(double probabiliteSexeFeminin)
        {
            Random random = new Random();
            double rand = random.Next(0, 100);

            if (rand <= probabiliteSexeFeminin)
            {
                this.m_sexe = "Feminin";
            }
            else
            {
                this.m_sexe = "Masculin";
            }
        }

        /// <summary>
        /// Cette méthode permet d'initialiser la nature d'un pokémon
        /// </summary>
        /// <param name=nature>La nature du pokémon</param>
        public void setNature(string nature)
        {
            this.m_nature = nature;
        }

        /// <summary>
        /// Cette méthode permet d'initialiser le type d'un pokémon
        /// </summary>
        /// <param name=type>Le type du pokémon</param>
        public void setType(string type)
        {
            this.m_type = type;
        }

        /// <summary>
        /// Cette méthode permet d'initialiser le niveau de chance du coup critique d'un pokémon (pour la formule)
        /// </summary>
        /// <param name=niveauCritique>Le niveau de chance de coup critique d'un pokémon</param>
        public void setNiveauCritique(int niveauCritique)
        {
            this.m_niveau_chance_coup_critique = niveauCritique;
        }

        /// <summary>
        /// Cette méthode permet d'initialiser l'expérience d'un pokémon
        /// </summary>
        /// <param name=experience>L'expérience du pokémon</param>
        public void setExperience(int experience)
        {
            this.m_experience = experience;
        }

        /// <summary>
        /// Cette méthode permet d'initialiser le type de courbe d'expérience d'un pokémon
        /// </summary>
        /// <param name=typeCourbeExperience>Le type de courbe d'expérience du pokémon</param>
        public void setTypeCourbeExperience(string typeCourbeExperience)
        {
            this.m_courbe_experience = typeCourbeExperience;
        }

        /// <summary>
        /// Cette méthode permet d'initialiser le gain d'expérience que le pokémon adverse gagne une fois celui-ci battu (pour la formule)
        /// </summary>
        /// <param name=gainExperience>Gain d'expérience que le pokémon adverse gagne une fois celui-ci battu</param>
        public void setGainExperiencePokemon(int gainExperience)
        {
            this.m_gain_experience = gainExperience;
        }

        /// <summary>
        /// Cette méthode permet d'initialiser le taux de capture d'un pokémon (pour la formule)
        /// </summary>
        /// <param name=tauxCapture>Taux de capture utilisé dans la formule pour calculer la probabilité de capture de pokémon</param>
        public void setTauxCapturePokemon(int tauxCapture)
        {
            this.m_taux_capture = tauxCapture;
        }

        /// <summary>
        /// Cette méthode permet d'initialiser le statut d'un pokémon
        /// </summary>
        /// <param name=statut>Le statut du pokémon</param>
        public void setStatutPokemon(string statut)
        {
            this.m_statut = statut;
        }

        /// <summary>
        /// Cette méthode permet de récupérer le taux de chance de capture d'un pokémon après divers paramètres tels que le statut du pokémon, la pokéball, le  nombre de point de vie restant
        /// </summary>
        /// <param name=ball>La pokéball utilisée</param>
        /// <returns>Le taux de chance de capture du pokémon</returns>
        public double getTauxCaptureModifier(Objet ball)
        {
            double bonusStatut;

            if(this.getStatutPokemon() == "Sommeil" || this.getStatutPokemon() == "Gelé")
            {
                bonusStatut = 2.5;
            }
            else if(this.getStatutPokemon() == "Empoisonnement normal" || this.getStatutPokemon() == "Empoisonnement grave" || this.getStatutPokemon() == "Brulure" || this.getStatutPokemon() == "Paralysie")
            {
                bonusStatut = 1.5;
            }
            else
            {
                bonusStatut = 1;
            }

            double a = (((3 * this.getPv() - 2 * this.getPvRestant()) * this.getTauxCapturePokemon() * ball.getValeurObjet()) / (3 * this.getPv())) * bonusStatut;

            return a;
        }

        /// <summary>
        /// Cette méthode permet de récupérer la probabilité que le test du mouvement de la pokéball réussisse
        /// </summary>
        /// <param name=tauxCaptureModifier>Le taux de chance de capture du pokémon</param>
        /// <returns>La probabilite que le test du mouvement de la pokéball réussisse</returns>
        public int probabiliteMouvementsBall(double tauxCaptureModifier)
        {
            Int32 nombreArrondi = 1 / 4096;

            double bPremierePartie = Math.Round(Math.Pow(255 / tauxCaptureModifier, 0.1875), 4);

            double b = Math.Floor(65536 / bPremierePartie);

            return (int)b;
        }

        /// <summary>
        /// Cette méthode permet de récupérer le nombre de mouvement que la pokéball va effectuer (0 = ne bouge pas, 1 = fait un mouvement, 2 = fait deux mouvements, 3 = fait trois mouvements, 4 = fait quatre mouvements et est capturé)
        /// </summary>
        /// <param name=probabiliteMouvementsBall>La probabilité que le test de mouvement réussisse</param>
        /// <returns>Le nombre de mouvement de la pokéball</returns>
        public int nombreMouvementsBall(int probabiliteMouvementsBall)
        {
            Random random = new Random();
            double rand = random.Next(0, 65535);

            if (rand >= probabiliteMouvementsBall)
            {
                return 0;
            }
            else
            {
                rand = random.Next(0, 65535);

                if (rand >= probabiliteMouvementsBall)
                {
                    return 1;
                }
                else
                {
                    rand = random.Next(0, 65535);

                    if (rand >= probabiliteMouvementsBall)
                    {
                        return 2;
                    }
                    else
                    {
                        rand = random.Next(0, 65535);

                        if (rand >= probabiliteMouvementsBall)
                        {
                            return 3;
                        }
                        else
                        {
                            return 4;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Cette méthode permet de récupérer et de seléctionner le pokémon starter et ses statistiques à partir de la base de données
        /// </summary>
        /// <param name=nomPokemon>Le nom du pokémon</param>
        /// <returns>Le pokémon choisi comme starter</returns>
        public Pokemon setPokemonStarter(string nomPokemon)
        {
            return pokemon.selectionPokemonStatsStarter(nomPokemon);
        }

        /// <summary>
        /// Cette méthode permet de définir l'id de l'attaque une d'un pokémon
        /// </summary>
        /// <param name=id>Id de l'attaque</param>
        public void setIdAttaque1(int id)
        {
            this.m_liste_id_attaque.Add(id);
        }

        /// <summary>
        /// Cette méthode permet de définir l'id de l'attaque deux d'un pokémon
        /// </summary>
        /// <param name=id>Id de l'attaque</param>
        public void setIdAttaque2(int id)
        {
            this.m_liste_id_attaque.Add(id);
        }

        /// <summary>
        /// Cette méthode permet de définir l'id de l'attaque trois d'un pokémon
        /// </summary>
        /// <param name=id>Id de l'attaque</param>
        public void setIdAttaque3(int id)
        {
            this.m_liste_id_attaque.Add(id);
        }

        /// <summary>
        /// Cette méthode permet de définir l'id de l'attaque quatre d'un pokémon
        /// </summary>
        /// <param name=id>Id de l'attaque</param>
        public void setIdAttaque4(int id)
        {
            this.m_liste_id_attaque.Add(id);
        }

        /// <summary>
        /// Cette méthode permet de définir l'attaque une d'un pokémon
        /// </summary>
        /// <param name=attaque>Attaque</param>
        public void setAttaque1(Attaque attaque)
        {
            this.m_liste_attaque.Add(attaque);
        }

        /// <summary>
        /// Cette méthode permet de définir l'attaque deux d'un pokémon
        /// </summary>
        /// <param name=attaque>Attaque</param>
        public void setAttaque2(Attaque attaque)
        {
            this.m_liste_attaque.Add(attaque);
        }

        /// <summary>
        /// Cette méthode permet de définir l'attaque trois d'un pokémon
        /// </summary>
        /// <param name=attaque>Attaque</param>
        public void setAttaque3(Attaque attaque)
        {
            this.m_liste_attaque.Add(attaque);
        }

        /// <summary>
        /// Cette méthode permet de définir l'attaque quatre d'un pokémon
        /// </summary>
        /// <param name=attaque>Attaque</param>
        public void setAttaque4(Attaque attaque)
        {
            this.m_liste_attaque.Add(attaque);
        }

        /// <summary>
        /// Cette méthode permet de définir le nom de l'attaque une d'un pokémon
        /// </summary>
        /// <param name=nomAttaque>Nom de l'attaque</param>
        public void setNomAttaque1(string nomAttaque)
        {
            this.m_liste_nom_attaque.Add(nomAttaque);
        }

        /// <summary>
        /// Cette méthode permet de définir le nom de l'attaque deux d'un pokémon
        /// </summary>
        /// <param name=nomAttaque>Nom de l'attaque</param>
        public void setNomAttaque2(string nomAttaque)
        {
            this.m_liste_nom_attaque.Add(nomAttaque);
        }

        /// <summary>
        /// Cette méthode permet de définir le nom de l'attaque trois d'un pokémon
        /// </summary>
        /// <param name=nomAttaque>Nom de l'attaque</param>
        public void setNomAttaque3(string nomAttaque)
        {
            this.m_liste_nom_attaque.Add(nomAttaque);
        }

        /// <summary>
        /// Cette méthode permet de définir le nom de l'attaque quatre d'un pokémon
        /// </summary>
        /// <param name=nomAttaque>Nom de l'attaque</param>
        public void setNomAttaque4(string nomAttaque)
        {
            this.m_liste_nom_attaque.Add(nomAttaque);
        }

        /// <summary>
        /// Cette méthode permet de récupérer et de seléctionner la probabilité de la réussite d'une attaque du pokémon offensif contre un pokémon
        /// </summary>
        /// <param name=pokemonOffensif>Le pokémon qui attaque</param>
        /// <param name=pokemonDefensif>Le pokémon qui défend</param>
        /// <param name=attaqueLancer>L'attaque lancé par le pokémon</param>
        /// <returns>La probabilité de la réussite de l'attaque</returns>
        public decimal getProbabiliteReussiteAttaque(Pokemon pokemonOffensif, Pokemon pokemonDefenseur, Attaque attaqueLancer)
        {
            decimal probabiliteReussite = (decimal)attaqueLancer.getPrecisionAttaque() * decimal.Divide((decimal)pokemonOffensif.getStatistiquesPrecisionPokemon(), (decimal)pokemonDefenseur.getStatistiquesEsquivePokemon());
            return probabiliteReussite;
        }

        /// <summary>
        /// Cette méthode permet de savoir si l'attaque du pokémon a réussi
        /// </summary>
        /// <param name=probabiliteReussiteAttaque>La probabilité de la réussite de l'attaque du pokémon</param>
        /// <returns>Booléen qui dit si l'attaque à réussit ou non</returns>
        public bool getReussiteAttaque(decimal probabiliteReussiteAttaque)
        {
            Random random = new Random();
            double rand = random.NextDouble();

            decimal randDecimal = Convert.ToDecimal(rand);

            if (randDecimal < probabiliteReussiteAttaque)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        /// <summary>
        /// Cette méthode permet de récupérer le nombre de tour qu'un pokémon endormi (statut = Sommeil) devra effectuer avant de se réveiller
        /// </summary>
        /// <returns>Nombre de tour avant que le statut du pokémon revienne à normal</returns>
        public int getNombreTourSommeilAEffectuer()
        {
            Random random = new Random();
            double rand = random.Next(0, 4);
            int nombreTourStatutAEffectuer = (int)rand;
            return nombreTourStatutAEffectuer;
        }

        /// <summary>
        /// Cette méthode permet au pokémon offensif d'attaquer un autre pokémon et de renvoyer le nombre de dégâts effectuer selon l'attaque, le bonusCritique, le statut des pokémon, elle va aussi baisser les pp de l'attaque du pokémon qui attaque
        /// </summary>
        /// <param name=pokemonOffensif>Le pokémon qui attaque</param>
        /// <param name=pokemonDefenseur>Le pokémon qui défend</param>
        /// <param name=attaque>L'attaque lancée</param>
        /// <param name=bonusCritique>Le bonus de dégats apportés par le coup critique (si il y en a un)</param>
        /// <param name=changementStatutPokemonReussi>Permet de savoir si un pokémon à changer de statut</param>
        /// <param name=nombreTourStatutSortie>Nombre de tour que le pokémon à un statut différent de normal</param>
        /// <param name=reussiteAttaqueParalyse>Booléen qui détermine si le pokémon a réussi à attaquer malgré la paralysie</param>
        /// <param name=reussiteAttaqueGel>Booléen qui détermine si le pokémon a réussi à attaquer malgré le gel</param>
        /// <param name=nombreTourSommeilSortie>Nombre de tour que le pokémon ait endormi</param>
        /// <returns>Le nombre de dégâts effectué par l'attaque</returns>
        public int attaqueWithNomAttaque(Pokemon pokemonOffensif, Pokemon pokemonDefenseur, Attaque attaque, double bonusCritique, bool changementStatutPokemonReussi, ref int nombreTourStatutSortie, ref bool reussiteAttaqueParalyse, ref bool reussiteAttaqueGel, ref int nombreTourSommeilSortie)
        {
            for (int i = 0; i < pokemonOffensif.getListeAttaque().Count; i++)
            {
                if (pokemonOffensif.getListeAttaque()[i] == attaque)
                {
                    pokemonOffensif.getListeAttaque()[i].setPPRestant(pokemonOffensif.getListeAttaque()[i].getPPRestant() - 1);
                }                
            }

            int nbDegats = 0;
            reussiteAttaqueParalyse = false;
            reussiteAttaqueGel = false;

            if (pokemonOffensif.getStatutPokemon() == "Paralysie")
            {
                Random random = new Random();
                double rand = random.Next(0, 100);

                if (rand >= 25)
                {
                    reussiteAttaqueParalyse = true;
                }
                else
                {
                    reussiteAttaqueParalyse = false;
                }
            }
            else if(pokemonOffensif.getStatutPokemon() == "Gelé")
            {
                Random random = new Random();
                double rand = random.Next(0, 100);

                if (rand <= 20)
                {
                    reussiteAttaqueGel = true;
                }
                else
                {
                    reussiteAttaqueGel = false;
                }
            }


            if ((pokemonOffensif.getStatutPokemon() != "Paralysie" && pokemonOffensif.getStatutPokemon() != "Gelé" && pokemonOffensif.getStatutPokemon() != "Sommeil") || (pokemonOffensif.getStatutPokemon() == "Paralysie" && reussiteAttaqueParalyse == true) || (pokemonOffensif.getStatutPokemon() == "Gelé" && reussiteAttaqueGel == true))
            {
                nbDegats = (int)this.calculDegatsAttaque(attaque, pokemonOffensif, pokemonDefenseur, bonusCritique);
                pokemonDefenseur.m_pv_restant = pokemonDefenseur.m_pv_restant - nbDegats;

                if (changementStatutPokemonReussi == true)
                { 
                    if (pokemonDefenseur.getStatutPokemon() == "Normal")
                    {
                        if (attaque.getNom() == "Lance-Flammes")
                        {
                            if (pokemonDefenseur.getType() != "Feu")
                            {
                                pokemonDefenseur.setStatutPokemon("Brulure");
                            }
                        }
                        else if (attaque.getNom() == "Detritus")
                        {
                            if (pokemonDefenseur.getType() != "Acier" && pokemonDefenseur.getType() != "Poison")
                            {
                                pokemonDefenseur.setStatutPokemon("Empoisonnement normal");
                            }
                        }
                        else if (attaque.getNom() == "Crochetvenin")
                        {
                            if (pokemonDefenseur.getType() != "Acier" && pokemonDefenseur.getType() != "Poison")
                            {
                                pokemonDefenseur.setStatutPokemon("Empoisonnement grave");
                                nombreTourStatutSortie = 1;
                            }
                        }
                        else if (attaque.getNom() == "Cage-Eclair")
                        {
                            pokemonDefenseur.setStatutPokemon("Paralysie");
                        }
                        else if (attaque.getNom() == "Laser Glace")
                        {
                            if (pokemonDefenseur.getType() != "Glace")
                            {
                                pokemonDefenseur.setStatutPokemon("Gelé");
                            }
                        }
                        else if(attaque.getNom() == "Hypnose")
                        {
                            if (nombreTourSommeilSortie == 0)
                            {
                                pokemonDefenseur.setStatutPokemon("Sommeil");
                            // nombreTourSommeilSortie = 1;
                            }
    
                        }
                    }
                }
            }
            else
            {
                nbDegats = 0;
            }

            return nbDegats;
        }

        /// <summary>
        /// Cette méthode permet à partir de l'id des attaques du pokémon et de la base de données, de récupérer les attaques correspondantes et de les transmettre au pokémon
        /// </summary>
        public void setAllAttacksWithId()
        {
            if (this.getIdAttaque1() != null)
            {
                this.setAttaque1(pokemon.selectionAttaqueId(this.getIdAttaque1()));

                if (this.getIdAttaque2() != null)
                {
                    this.setAttaque2(pokemon.selectionAttaqueId(this.getIdAttaque2()));

                    if (this.getIdAttaque3() != null)
                    {
                        this.setAttaque3(pokemon.selectionAttaqueId(this.getIdAttaque3()));

                        if (this.getIdAttaque4() != null)
                        {
                            this.setAttaque4(pokemon.selectionAttaqueId(this.getIdAttaque4()));

                        }

                    }
                }

            }
        }

        /// <summary>
        /// Cette méthode permet à partir du nom des attaques du pokémon et des paramètres, statistiques du jeu, de récupérer les attaques correspondantes et de les transmettre au pokémon
        /// </summary>
        /// <param name=jeu>Statisttiques, paramètres, attaques, objets, pokémon du jeu</param>
        public void setAllAttacksWithNomOffline(Jeu jeu)
        {
            if (this.getNomAttaque1() != null)
            {
                this.setAttaque1(jeu.getListeAttaques().Find(attaque => attaque.getNom().Equals(this.getNomAttaque1())));
                if (this.getNomAttaque2() != null)
                {
                    this.setAttaque2(jeu.getListeAttaques().Find(attaque => attaque.getNom().Equals(this.getNomAttaque2())));
                    if (this.getNomAttaque3() != null)
                    {
                        this.setAttaque3(jeu.getListeAttaques().Find(attaque => attaque.getNom().Equals(this.getNomAttaque3())));
                        if (this.getNomAttaque4() != null)
                        {
                            this.setAttaque4(jeu.getListeAttaques().Find(attaque => attaque.getNom().Equals(this.getNomAttaque4())));
                        }
                    }

                }
            }

        }

        /// <summary>
        /// Cette méthode permet à partir du nom des attaques du pokémon et de la base de données, de récupérer les attaques correspondantes et de les transmettre au pokémon
        /// </summary>
        public void setAllAttacksWithNom()
        {
            if (this.getNomAttaque1() != null)
            {
                this.setAttaque1(pokemon.selectionAttaque(this.getNomAttaque1()));
                if (this.getNomAttaque2() != null)
                {
                    this.setAttaque2(pokemon.selectionAttaque(this.getNomAttaque2()));
                    if (this.getNomAttaque3() != null)
                    {
                        this.setAttaque3(pokemon.selectionAttaque(this.getNomAttaque3()));
                        if (this.getNomAttaque4() != null)
                        {
                            this.setAttaque4(pokemon.selectionAttaque(this.getNomAttaque4()));
                        }

                    }

                }
            }

        }

        /// <summary>
        /// Cette méthode permet de définir la précision du pokémon
        /// </summary>
        /// <param name=precisionPokemon>Précision du pokémon</param>
        public void setPrecision(double precisionPokemon)
        {
            this.m_statistiques_precision = precisionPokemon;
        }

        /// <summary>
        /// Cette méthode permet de définir l'esquive du pokémon
        /// </summary>
        /// <param name=esquivePokemon>Esquive du pokémon</param>
        public void setEsquive(double esquivePokemon)
        {
            this.m_statistiques_esquive = esquivePokemon;
        }

        /// <summary>
        /// Cette méthode permet de définir le niveau du pokémon
        /// </summary>
        /// <param name=niveauPokemon>Niveau du pokémon</param>
        public void setNiveau(int niveauPokemon)
        {
            this.m_niveau = niveauPokemon;
        }

        /// <summary>
        /// Cette méthode permet de définir la base de l'attaque du pokémon
        /// </summary>
        /// <param name=baseAttaque>Base attaque du pokémon</param>
        public void setBaseAttaque(int baseAttaque)
        {
            this.m_base_attaque = baseAttaque;
        }

        /// <summary>
        /// Cette méthode permet de définir la base de la défense du pokémon
        /// </summary>
        /// <param name=baseDéfense>Base défense du pokémon</param>
        public void setBaseDefense(int baseDefense)
        {
            this.m_base_defense = baseDefense;
        }

        /// <summary>
        /// Cette méthode permet de définir la base de la vitesse du pokémon
        /// </summary>
        /// <param name=baseVitesse>Base vitesse du pokémon</param>
        public void setBaseVitesse(int baseVitesse)
        {
            this.m_base_vitesse = baseVitesse;
        }

        /// <summary>
        /// Cette méthode permet de définir la base de l'attaque spéciale du pokémon
        /// </summary>
        /// <param name=baseAttaqueSpeciale>Base attaque spéciale du pokémon</param>
        public void setBaseAttaqueSpeciale(int baseAttaqueSpeciale)
        {
            this.m_base_attaque_speciale = baseAttaqueSpeciale;
        }

        /// <summary>
        /// Cette méthode permet de définir la base de la défense spéciale du pokémon
        /// </summary>
        /// <param name=baseDéfenseSpeciale>Base défense spéciale du pokémon</param>
        public void setBaseDefenseSpeciale(int baseDefenseSpeciale)
        {
            this.m_base_defense_speciale = baseDefenseSpeciale;
        }

        /// <summary>
        /// Cette méthode permet de définir les IV PV du pokémon
        /// </summary>
        /// <param name=ivPv>IV PV du pokémon</param>
        public void setIvPv(int ivPv)
        {
            this.m_iv_pv = ivPv;
        }

        /// <summary>
        /// Cette méthode permet de définir les IV Attaque du pokémon
        /// </summary>
        /// <param name=ivAttaque>IV Attaque du pokémon</param>
        public void setIvAttaque(int ivAttaque)
        {
            this.m_iv_attaque = ivAttaque;
        }

        /// <summary>
        /// Cette méthode permet de définir les IV Défense du pokémon
        /// </summary>
        /// <param name=ivDéfense>IV Défense du pokémon</param>
        public void setIvDefense(int ivDefense)
        {
            this.m_iv_defense = ivDefense;
        }

        /// <summary>
        /// Cette méthode permet de définir les IV Vitesse du pokémon
        /// </summary>
        /// <param name=ivVitesse>IV Vitesse du pokémon</param>
        public void setIvVitesse(int ivVitesse)
        {
            this.m_iv_vitesse = ivVitesse;
        }

        /// <summary>
        /// Cette méthode permet de définir les IV Attaque Spéciale du pokémon
        /// </summary>
        /// <param name=ivAttaqueSpeciale>IV Attaque Spéciale du pokémon</param>
        public void setIvAttaqueSpeciale(int ivAttaqueSpeciale)
        {
            this.m_iv_attaque_speciale = ivAttaqueSpeciale;
        }

        /// <summary>
        /// Cette méthode permet de définir les IV Défense Spéciale du pokémon
        /// </summary>
        /// <param name=ivDéfenseSpéciale>IV Défense Spéciale du pokémon</param>
        public void setIvDefenseSpeciale(int ivDefenseSpeciale)
        {
            this.m_iv_defense_speciale = ivDefenseSpeciale;
        }

        /// <summary>
        /// Cette méthode permet de définir les EV PV du pokémon
        /// </summary>
        /// <param name=evPv>EV PV du pokémon</param>
        public void setEvPv(int evPv)
        {
            this.m_ev_pv = evPv;
        }

        /// <summary>
        /// Cette méthode permet de définir les EV Attaque du pokémon
        /// </summary>
        /// <param name=evAttaque>EV Attaque du pokémon</param>
        public void setEvAttaque(int evAttaque)
        {
            this.m_ev_attaque = evAttaque;
        }

        /// <summary>
        /// Cette méthode permet de définir les EV Défense du pokémon
        /// </summary>
        /// <param name=evDéfense>EV Défense du pokémon</param>
        public void setEvDefense(int evDefense)
        {
            this.m_ev_defense = evDefense;
        }

        /// <summary>
        /// Cette méthode permet de définir les EV Vitesse du pokémon
        /// </summary>
        /// <param name=evVitesse>EV Vitesse du pokémon</param>
        public void setEvVitesse(int evVitesse)
        {
            this.m_ev_vitesse = evVitesse;
        }

        /// <summary>
        /// Cette méthode permet de définir les EV Attaque Spéciale du pokémon
        /// </summary>
        /// <param name=evAttaqueSpeciale>EV Attaque Spéciale du pokémon</param>
        public void setEvAttaqueSpeciale(int evAttaqueSpeciale)
        {
            this.m_ev_attaque_speciale = evAttaqueSpeciale;
        }

        /// <summary>
        /// Cette méthode permet de définir les EV Défense Spéciale du pokémon
        /// </summary>
        /// <param name=evDefenseSpeciale>EV Défense Spéciale du pokémon</param>
        public void setEvDefenseSpeciale(int evDefenseSpeciale)
        {
            this.m_ev_defense_speciale = evDefenseSpeciale;
        }

        /// <summary>
        /// Cette méthode permet de définir le gain d'EV PV obtenu après avoir battu le pokémon
        /// </summary>
        /// <param name=gainEvPv>EV PV obtenu après avoir battu le pokémon</param>
        public void setGainEvPv(int gainEvPv)
        {
            this.m_gain_ev_pv = gainEvPv;
        }

        /// <summary>
        /// Cette méthode permet de définir le gain d'EV Attaque obtenu après avoir battu le pokémon
        /// </summary>
        /// <param name=gainEvAttaque>EV Attaque obtenu après avoir battu le pokémon</param>
        public void setGainEvAttaque(int gainEvAttaque)
        {
            this.m_gain_ev_attaque = gainEvAttaque;
        }

        /// <summary>
        /// Cette méthode permet de définir le gain d'EV Défense obtenu après avoir battu le pokémon
        /// </summary>
        /// <param name=gainEvDefense>EV Défense obtenu après avoir battu le pokémon</param>
        public void setGainEvDefense(int gainEvDefense)
        {
            this.m_gain_ev_defense = gainEvDefense;
        }

        /// <summary>
        /// Cette méthode permet de définir le gain d'EV Vitesse obtenu après avoir battu le pokémon
        /// </summary>
        /// <param name=gainEvVitesse>EV Vitesse obtenu après avoir battu le pokémon</param>
        public void setGainEvVitesse(int gainEvVitesse)
        {
            this.m_gain_ev_vitesse = gainEvVitesse;
        }

        /// <summary>
        /// Cette méthode permet de définir le gain d'EV Attaque Spéciale obtenu après avoir battu le pokémon
        /// </summary>
        /// <param name=gainEvAttaqueSpeciale>EV Attaque Spéciale obtenu après avoir battu le pokémon</param>
        public void setGainEvAttaqueSpeciale(int gainEvAttaqueSpeciale)
        {
            this.m_gain_ev_attaque_speciale = gainEvAttaqueSpeciale;
        }

        /// <summary>
        /// Cette méthode permet de définir le gain d'EV Défense Spéciale obtenu après avoir battu le pokémon
        /// </summary>
        /// <param name=gainEvDefenseSpeciale>EV Défense Spéciale obtenu après avoir battu le pokémon</param>
        public void setGainEvDefenseSpeciale(int gainEvDefenseSpeciale)
        {
            this.m_gain_ev_defense_speciale = gainEvDefenseSpeciale;
        }

        /// <summary>
        /// Cette méthode permet de définir aléatoirement de 0 à 31 chaque statistique d'IV d'un pokémon
        /// </summary>
        public void generateurIv()
        {
            List<int> liste_iv = new List<int>();
            Random rand = new Random();

            for(int i = 0; i <= 31; i++)
            {
                liste_iv.Add(i);
            }

            int index_iv_pv = rand.Next(liste_iv.Count);
            int index_iv_attaque = rand.Next(liste_iv.Count);
            int index_iv_defense = rand.Next(liste_iv.Count);
            int index_iv_vitesse = rand.Next(liste_iv.Count);
            int index_iv_attaque_speciale = rand.Next(liste_iv.Count);
            int index_iv_defense_speciale = rand.Next(liste_iv.Count);

            this.m_iv_pv = liste_iv[index_iv_pv];
            this.m_iv_attaque = liste_iv[index_iv_attaque];
            this.m_iv_defense = liste_iv[index_iv_defense];
            this.m_iv_vitesse = liste_iv[index_iv_vitesse];
            this.m_iv_attaque_speciale = liste_iv[index_iv_attaque_speciale];
            this.m_iv_defense_speciale = liste_iv[index_iv_defense_speciale];
        }

        /// <summary>
        /// Cette méthode permet de définir aléatoirement de 0 à 255 chaque statistique d'EV d'un pokémon
        /// </summary>
        public void generateurEv()
        {
            List<int> liste_ev = new List<int>();
            Random rand = new Random();

            for (int i = 0; i <= 255; i++)
            {
                liste_ev.Add(i);
            }

            int index_ev_pv = rand.Next(liste_ev.Count);
            int index_ev_attaque = rand.Next(liste_ev.Count);
            int index_ev_defense = rand.Next(liste_ev.Count);
            int index_ev_vitesse = rand.Next(liste_ev.Count);
            int index_ev_attaque_speciale = rand.Next(liste_ev.Count);
            int index_ev_defense_speciale = rand.Next(liste_ev.Count);

            this.m_ev_pv = liste_ev[index_ev_pv];
            this.m_ev_attaque = liste_ev[index_ev_attaque];
            this.m_ev_defense = liste_ev[index_ev_defense];
            this.m_ev_vitesse = liste_ev[index_ev_vitesse];
            this.m_ev_attaque_speciale = liste_ev[index_ev_attaque_speciale];
            this.m_ev_defense_speciale = liste_ev[index_ev_defense_speciale];
        }

        /// <summary>
        /// Cette méthode permet de calculer les dégâts que va faire une attaque
        /// </summary>
        /// <param name=attaqueLancer>L'attaque lancé par le pokémon offensif</param>
        /// <param name=pokemonOffensif>Pokémon qui attaque</param>
        /// <param name=pokemonDefenseur>Pokémon qui défend</param>
        /// <param name=bonusCritique>Bonus de dégâts si l'attaque à le droit à un critique</param>
        /// <returns>Le nombre de dégâts qu'a infligé l'attaque</returns>
        public int calculDegatsAttaque(Attaque attaqueLancer, Pokemon pokemonOffensif, Pokemon pokemonDefenseur, double bonusCritique)
        {
            double modificateurAvantConversion = 0;
            double bonus_attaque_type_efficace = 0.25, bonus_meme_type_pokemon_capacite = 0, bonus_autre = 1;
            double bonus_damage_roll = 0;

            bonus_attaque_type_efficace = this.getEfficaciteAttaque(attaqueLancer, pokemonDefenseur);

            if(attaqueLancer.getTypeAttaque() == pokemonOffensif.getType())
            {
                bonus_meme_type_pokemon_capacite = 1.5;
            }
            else
            {
                bonus_meme_type_pokemon_capacite = 1;
            }

            // bonusCritique = this.getCoupCritique(this.getProbabiliteCoupCritique(pokemonOffensif));
            bonus_damage_roll = this.getDamageRoll();

            modificateurAvantConversion = bonus_attaque_type_efficace * bonus_meme_type_pokemon_capacite * bonusCritique * bonus_autre * bonus_damage_roll;
            decimal modificateur = Convert.ToDecimal(modificateurAvantConversion);

            decimal degats;
            decimal niveauPokemonOffensif, StatistiquesAttaquePokemonOffensif, StatistiquesDefensePokemonDefenseur, baseAttaque;

            niveauPokemonOffensif = Convert.ToDecimal(pokemonOffensif.getNiveau());
            if (attaqueLancer.getPhysiqueOuSpécialeAttaque() == "Physique")
            {
                StatistiquesAttaquePokemonOffensif = Convert.ToDecimal(pokemonOffensif.getStatistiquesAttaque());
                StatistiquesDefensePokemonDefenseur = Convert.ToDecimal(pokemonDefenseur.getStatistiquesDefense());
            }
            else
            {
                StatistiquesAttaquePokemonOffensif = Convert.ToDecimal(pokemonOffensif.getStatistiquesAttaqueSpeciale());
                StatistiquesDefensePokemonDefenseur = Convert.ToDecimal(pokemonDefenseur.getStatistiquesDefenseSpeciale());
            }

            baseAttaque = Convert.ToDecimal(attaqueLancer.getPuissanceBase());

            degats = (decimal.Divide(2 * niveauPokemonOffensif + 10, 250) * decimal.Divide(StatistiquesAttaquePokemonOffensif, StatistiquesDefensePokemonDefenseur) * baseAttaque + 2) * modificateur;

            if (pokemonOffensif.getStatutPokemon() == "Brulure")
            {
                degats = degats / 2;
            }

            if (attaqueLancer.getPhysiqueOuSpécialeAttaque() == "Statut")
            {
                degats = 0;
            }

            int resultat = (int) degats;
            
            return resultat;
        }

        /// <summary>
        /// Cette méthode permet de retourner un chiffre pour voir si l'attaque est sans effet, peu efficace, normale, très efficace par rapport au type du pokémon défenseur
        /// </summary>
        /// <param name=attaqueEnvoyer>L'attaque lancé par le pokémon offensif</param>
        /// <param name=pokemon>Pokémon qui défend</param>
        /// <returns>Chiffre permettant de voir l'efficacité de l'attaque lancé par rapport à celle du pokémon défenseur</returns>
        public double getEfficaciteAttaque(Attaque attaqueEnvoyer, Pokemon pokemon)
        {
            if(attaqueEnvoyer.getTypeAttaque() == "Acier" && pokemon.getType() == "Acier" || attaqueEnvoyer.getTypeAttaque() == "Dragon" && pokemon.getType() == "Acier" || attaqueEnvoyer.getTypeAttaque() == "Fée" && pokemon.getType() == "Acier" || attaqueEnvoyer.getTypeAttaque() == "Glace" && pokemon.getType() == "Acier" || attaqueEnvoyer.getTypeAttaque() == "Insecte" && pokemon.getType() == "Acier" || attaqueEnvoyer.getTypeAttaque() == "Normal" && pokemon.getType() == "Acier" || attaqueEnvoyer.getTypeAttaque() == "Plante" && pokemon.getType() == "Acier" || attaqueEnvoyer.getTypeAttaque() == "Psy" && pokemon.getType() == "Acier" || attaqueEnvoyer.getTypeAttaque() == "Roche" && pokemon.getType() == "Acier" || attaqueEnvoyer.getTypeAttaque() == "Vol" && pokemon.getType() == "Acier"
               || attaqueEnvoyer.getTypeAttaque() == "Insecte" && pokemon.getType() == "Combat" || attaqueEnvoyer.getTypeAttaque() == "Roche" && pokemon.getType() == "Combat" || attaqueEnvoyer.getTypeAttaque() == "Ténèbres" && pokemon.getType() == "Combat"
               || attaqueEnvoyer.getTypeAttaque() == "Eau" && pokemon.getType() == "Dragon" || attaqueEnvoyer.getTypeAttaque() == "Eletrick" && pokemon.getType() == "Dragon" || attaqueEnvoyer.getTypeAttaque() == "Feu" && pokemon.getType() == "Dragon" || attaqueEnvoyer.getTypeAttaque() == "Plante" && pokemon.getType() == "Dragon"
               || attaqueEnvoyer.getTypeAttaque() == "Acier" && pokemon.getType() == "Eau" || attaqueEnvoyer.getTypeAttaque() == "Eau" && pokemon.getType() == "Eau" || attaqueEnvoyer.getTypeAttaque() == "Feu" && pokemon.getType() == "Eau" || attaqueEnvoyer.getTypeAttaque() == "Glace" && pokemon.getType() == "Eau"
               || attaqueEnvoyer.getTypeAttaque() == "Acier" && pokemon.getType() == "Eletrik" || attaqueEnvoyer.getTypeAttaque() == "Eletrik" && pokemon.getType() == "Eletrik" || attaqueEnvoyer.getTypeAttaque() == "Vol" && pokemon.getType() == "Eletrik"
               || attaqueEnvoyer.getTypeAttaque() == "Combat" && pokemon.getType() == "Fée" || attaqueEnvoyer.getTypeAttaque() == "Insecte" && pokemon.getType() == "Fée" || attaqueEnvoyer.getTypeAttaque() == "Ténèbres" && pokemon.getType() == "Fée"
               || attaqueEnvoyer.getTypeAttaque() == "Acier" && pokemon.getType() == "Feu" || attaqueEnvoyer.getTypeAttaque() == "Fée" && pokemon.getType() == "Feu" || attaqueEnvoyer.getTypeAttaque() == "Feu" && pokemon.getType() == "Feu" || attaqueEnvoyer.getTypeAttaque() == "Glace" && pokemon.getType() == "Feu" || attaqueEnvoyer.getTypeAttaque() == "Insecte" && pokemon.getType() == "Feu" || attaqueEnvoyer.getTypeAttaque() == "Plante" && pokemon.getType() == "Feu"
               || attaqueEnvoyer.getTypeAttaque() == "Glace" && pokemon.getType() == "Glace"
               || attaqueEnvoyer.getTypeAttaque() == "Combat" && pokemon.getType() == "Insecte" || attaqueEnvoyer.getTypeAttaque() == "Plante" && pokemon.getType() == "Insecte" || attaqueEnvoyer.getTypeAttaque() == "Sol" && pokemon.getType() == "Insecte"
               || attaqueEnvoyer.getTypeAttaque() == "Eau" && pokemon.getType() == "Plante" || attaqueEnvoyer.getTypeAttaque() == "Electrik" && pokemon.getType() == "Plante" || attaqueEnvoyer.getTypeAttaque() == "Plante" && pokemon.getType() == "Plante" || attaqueEnvoyer.getTypeAttaque() == "Sol" && pokemon.getType() == "Plante"
               || attaqueEnvoyer.getTypeAttaque() == "Combat" && pokemon.getType() == "Poison" || attaqueEnvoyer.getTypeAttaque() == "Fée" && pokemon.getType() == "Poison" || attaqueEnvoyer.getTypeAttaque() == "Insecte" && pokemon.getType() == "Poison" || attaqueEnvoyer.getTypeAttaque() == "Plante" && pokemon.getType() == "Poison" || attaqueEnvoyer.getTypeAttaque() == "Poison" && pokemon.getType() == "Poison"
               || attaqueEnvoyer.getTypeAttaque() == "Combat" && pokemon.getType() == "Psy" || attaqueEnvoyer.getTypeAttaque() == "Psy" && pokemon.getType() == "Psy"
               || attaqueEnvoyer.getTypeAttaque() == "Feu" && pokemon.getType() == "Roche" || attaqueEnvoyer.getTypeAttaque() == "Normal" && pokemon.getType() == "Roche" || attaqueEnvoyer.getTypeAttaque() == "Poison" && pokemon.getType() == "Roche" || attaqueEnvoyer.getTypeAttaque() == "Vol" && pokemon.getType() == "Roche"
               || attaqueEnvoyer.getTypeAttaque() == "Poison" && pokemon.getType() == "Sol" || attaqueEnvoyer.getTypeAttaque() == "Roche" && pokemon.getType() == "Sol"
               || attaqueEnvoyer.getTypeAttaque() == "Insecte" && pokemon.getType() == "Spectre" || attaqueEnvoyer.getTypeAttaque() == "Poison" && pokemon.getType() == "Spectre"
               || attaqueEnvoyer.getTypeAttaque() == "Spectre" && pokemon.getType() == "Ténèbres" || attaqueEnvoyer.getTypeAttaque() == "Ténèbres" && pokemon.getType() == "Ténèbres"
               || attaqueEnvoyer.getTypeAttaque() == "Combat" && pokemon.getType() == "Vol" || attaqueEnvoyer.getTypeAttaque() == "Insecte" && pokemon.getType() == "Vol" || attaqueEnvoyer.getTypeAttaque() == "Plante" && pokemon.getType() == "Vol") 
            {
                return 0.5;
            }

            else if(attaqueEnvoyer.getTypeAttaque() == "Poison" && pokemon.getType() == "Acier" || attaqueEnvoyer.getTypeAttaque() == "Dragon" && pokemon.getType() == "Fée" || attaqueEnvoyer.getTypeAttaque() == "Spectre" && pokemon.getType() == "Normal" || attaqueEnvoyer.getTypeAttaque() == "Eletrik" && pokemon.getType() == "Sol" || attaqueEnvoyer.getTypeAttaque() == "Combat" && pokemon.getType() == "Spectre" || attaqueEnvoyer.getTypeAttaque() == "Normal" && pokemon.getType() == "Spectre" || attaqueEnvoyer.getTypeAttaque() == "Psy" && pokemon.getType() == "Ténèbres" || attaqueEnvoyer.getTypeAttaque() == "Sol" && pokemon.getType() == "Vol")
            {
                return 0;
            }

            else if(attaqueEnvoyer.getTypeAttaque() == "Combat" && pokemon.getType() == "Acier" || attaqueEnvoyer.getTypeAttaque() == "Feu" && pokemon.getType() == "Acier" || attaqueEnvoyer.getTypeAttaque() == "Sol" && pokemon.getType() == "Acier"
                    || attaqueEnvoyer.getTypeAttaque() == "Fée" && pokemon.getType() == "Combat" || attaqueEnvoyer.getTypeAttaque() == "Psy" && pokemon.getType() == "Combat" || attaqueEnvoyer.getTypeAttaque() == "Vol" && pokemon.getType() == "Combat"
                    || attaqueEnvoyer.getTypeAttaque() == "Dragon" && pokemon.getType() == "Dragon" || attaqueEnvoyer.getTypeAttaque() == "Fée" && pokemon.getType() == "Dragon" || attaqueEnvoyer.getTypeAttaque() == "Fée" && pokemon.getType() == "Dragon" || attaqueEnvoyer.getTypeAttaque() == "Glace" && pokemon.getType() == "Dragon"
                    || attaqueEnvoyer.getTypeAttaque() == "Electrik" && pokemon.getType() == "Eau" || attaqueEnvoyer.getTypeAttaque() == "Plante" && pokemon.getType() == "Eau"
                    || attaqueEnvoyer.getTypeAttaque() == "Sol" && pokemon.getType() == "Electrik"
                    || attaqueEnvoyer.getTypeAttaque() == "Acier" && pokemon.getType() == "Fée" || attaqueEnvoyer.getTypeAttaque() == "Poison" && pokemon.getType() == "Fée"
                    || attaqueEnvoyer.getTypeAttaque() == "Eau" && pokemon.getType() == "Feu" || attaqueEnvoyer.getTypeAttaque() == "Roche" && pokemon.getType() == "Feu" || attaqueEnvoyer.getTypeAttaque() == "Sol" && pokemon.getType() == "Feu"
                    || attaqueEnvoyer.getTypeAttaque() == "Acier" && pokemon.getType() == "Glace" || attaqueEnvoyer.getTypeAttaque() == "Combat" && pokemon.getType() == "Glace" || attaqueEnvoyer.getTypeAttaque() == "Feu" && pokemon.getType() == "Glace" || attaqueEnvoyer.getTypeAttaque() == "Roche" && pokemon.getType() == "Glace"
                    || attaqueEnvoyer.getTypeAttaque() == "Feu" && pokemon.getType() == "Insecte" || attaqueEnvoyer.getTypeAttaque() == "Roche" && pokemon.getType() == "Insecte" || attaqueEnvoyer.getTypeAttaque() == "Vol" && pokemon.getType() == "Insecte"
                    || attaqueEnvoyer.getTypeAttaque() == "Combat" && pokemon.getType() == "Normal"
                    || attaqueEnvoyer.getTypeAttaque() == "Feu" && pokemon.getType() == "Plante" || attaqueEnvoyer.getTypeAttaque() == "Glace" && pokemon.getType() == "Plante" || attaqueEnvoyer.getTypeAttaque() == "Insecte" && pokemon.getType() == "Plante" || attaqueEnvoyer.getTypeAttaque() == "Poison" && pokemon.getType() == "Plante" || attaqueEnvoyer.getTypeAttaque() == "Vol" && pokemon.getType() == "Plante"
                    || attaqueEnvoyer.getTypeAttaque() == "Psy" && pokemon.getType() == "Poison" || attaqueEnvoyer.getTypeAttaque() == "Sol" && pokemon.getType() == "Poison"
                    || attaqueEnvoyer.getTypeAttaque() == "Insecte" && pokemon.getType() == "Psy" || attaqueEnvoyer.getTypeAttaque() == "Spectre" && pokemon.getType() == "Psy" || attaqueEnvoyer.getTypeAttaque() == "Ténèbres" && pokemon.getType() == "Psy"
                    || attaqueEnvoyer.getTypeAttaque() == "Acier" && pokemon.getType() == "Roche" || attaqueEnvoyer.getTypeAttaque() == "Combat" && pokemon.getType() == "Roche" || attaqueEnvoyer.getTypeAttaque() == "Eau" && pokemon.getType() == "Roche" || attaqueEnvoyer.getTypeAttaque() == "Plante" && pokemon.getType() == "Roche" || attaqueEnvoyer.getTypeAttaque() == "Sol" && pokemon.getType() == "Roche"
                    || attaqueEnvoyer.getTypeAttaque() == "Eau" && pokemon.getType() == "Sol" || attaqueEnvoyer.getTypeAttaque() == "Glace" && pokemon.getType() == "Sol" || attaqueEnvoyer.getTypeAttaque() == "Plante" && pokemon.getType() == "Sol"
                    || attaqueEnvoyer.getTypeAttaque() == "Spectre" && pokemon.getType() == "Spectre" || attaqueEnvoyer.getTypeAttaque() == "Ténèbres" && pokemon.getType() == "Spectre"
                    || attaqueEnvoyer.getTypeAttaque() == "Combat" && pokemon.getType() == "Ténèbres" || attaqueEnvoyer.getTypeAttaque() == "Fée" && pokemon.getType() == "Ténèbres" || attaqueEnvoyer.getTypeAttaque() == "Insecte" && pokemon.getType() == "Ténèbres"
                    || attaqueEnvoyer.getTypeAttaque() == "Electrik" && pokemon.getType() == "Vol" || attaqueEnvoyer.getTypeAttaque() == "Glace" && pokemon.getType() == "Vol" || attaqueEnvoyer.getTypeAttaque() == "Roche" && pokemon.getType() == "Vol")
            {
                return 2;
            }

            else
            { 
                return 1;
            }
        }

        /// <summary>
        /// Cette méthode permet de voir si l'attaque lancé est sans effet, peu efficace, normale, très efficace par rapport au type du pokémon défenseur
        /// </summary>
        /// <param name=efficaciteAttaque>Chiffre d'effficacité de l'attaque lancé par rapport à celle du pokémon défenseur</param>
        /// <returns>Efficacité de l'attaque lancé par rapport à celle du pokémon défenseur</returns>
        public string getEfficaciteAttaqueTexte(double efficaciteAttaque)
        {
            if(efficaciteAttaque == 0)
            {
                return "Cela n'affecte pas le pokémon";
            }
            else if(efficaciteAttaque == 0.5)
            {
                return "Ce n'est pas très efficace";
            }
            else if(efficaciteAttaque == 2)
            {
                return "C'est super efficace";
            }
            else
            {
                return "";
            }
        }

        /// <summary>
        /// Cette méthode permet d'obtenir la probabilité qu'un pokémon puisse faire un coup critique
        /// </summary>
        /// <param name=pokemon>Un pokémon</param>
        /// <returns>Probabilité qu'un pokémon puisse faire un coup critique</returns>
        public decimal getProbabiliteCoupCritique(Pokemon pokemon)
        {
            if(pokemon.getNiveauCoupCritique() == 1)
            {
                return 1m / 24m;
            }
            else if(pokemon.getNiveauCoupCritique() == 2)
            {
                return 1m / 8m;
            }
            else if (pokemon.getNiveauCoupCritique() == 3)
            {
                return 1m / 2m;
            }
            else if (pokemon.getNiveauCoupCritique() == 4 || pokemon.getNiveauCoupCritique() == 5)
            {
                return 1m;
            }
            else
            {
                return 1m / 24m;
            }
        }

        /// <summary>
        /// Cette méthode permet de savoir si le coup critique a bien lieu par rapport à sa probababilité
        /// </summary>
        /// <param name=probabiliteCoupCritique>Probabilité de coup critique</param>
        /// <returns>Chiffre permettant de savoir si il y a bien eu un coup critique ou non</returns>
        public double getCoupCritique(decimal probabiliteCoupCritique)
        {
            Random random = new Random();
            double rand = random.NextDouble();

            decimal randDecimal = Convert.ToDecimal(rand);

            if (randDecimal < probabiliteCoupCritique) 
            {
                return 1.5;
            }
            else
            {
                return 1;
            }

        }

        /// <summary>
        /// Cette méthode permet de recevoir un message pour savoir si le coup critique à bien eu lieu
        /// </summary>
        /// <param name=bonusCoupCritique>Coup critique ou non</param>
        /// <returns>Message permettant de savoir si il y a bien eu un coup critique ou non</returns>
        public string getCoupCritiqueMessage(double bonusCoupCritique)
        {
            if(bonusCoupCritique == 1.5)
            {
                return "Coup Critique";
            }
            else
            {
                return "";
            }
        }

        /// <summary>
        /// Cette méthode permet d'obtenir le damage roll (bonus d'attaque)
        /// </summary>
        /// <returns>Damage roll</returns>
        public Double getDamageRoll()
        {
            List<int> liste_nombre = new List<int>();
            Random rand = new Random();

            for (int i = 85; i <= 100; i++)
            {
                liste_nombre.Add(i);
            }

            int index = rand.Next(liste_nombre.Count);

            decimal damageRollAvantConversion = decimal.Divide(liste_nombre[index], 100);
            double damageRoll = Convert.ToDouble(damageRollAvantConversion);

            return damageRoll;
        }

        /// <summary>
        /// Cette méthode permet d'obtenir l'expérience au niveau actuel du pokémon si sa courbe d'expérience est rapide
        /// </summary>
        /// <returns>Expérience au niveau actuel
        public int getExperiencePokemonCourbeRapide()
        {
            double experience = Math.Round(0.8 * Math.Pow(this.m_niveau, 3), MidpointRounding.AwayFromZero);
            return (int)experience;
        }

        /// <summary>
        /// Cette méthode permet d'obtenir l'expérience au niveau actuel du pokémon si sa courbe d'expérience est moyenne
        /// </summary>
        /// <returns>Expérience au niveau actuel
        public int getExperiencePokemonCourbeMoyenne()
        {
            double experience = Math.Round(Math.Pow(this.m_niveau, 3), MidpointRounding.AwayFromZero);
            return (int)experience;
        }

        /// <summary>
        /// Cette méthode permet d'obtenir l'expérience au niveau actuel du pokémon si sa courbe d'expérience est parabolique
        /// </summary>
        /// <returns>Expérience au niveau actuel
        public int getExperiencePokemonCourbeParabolique()
        {
            double experience = Math.Round(1.2 * Math.Pow(this.m_niveau, 3) - 15 * Math.Pow(this.m_niveau, 2) + (100 * this.m_niveau) - 140, MidpointRounding.AwayFromZero);
            if(experience < 0)
            {
                experience = 0;
            }

            return (int)experience;
        }

        /// <summary>
        /// Cette méthode permet d'obtenir l'expérience au niveau actuel du pokémon si sa courbe d'expérience est lente
        /// </summary>
        /// <returns>Expérience au niveau actuel
        public int getExperiencePokemonCourbeLente()
        {
            double experience = Math.Round(1.25 * Math.Pow(this.m_niveau, 3), MidpointRounding.AwayFromZero);
            return (int)experience;
        }

        /// <summary>
        /// Cette méthode permet d'obtenir l'expérience au niveau actuel du pokémon si sa courbe d'expérience est erratique
        /// </summary>
        /// <returns>Expérience au niveau actuel
        public int getExperiencePokemonCourbeErratique()
        {
            double niveauPokemon = this.m_niveau;
            double experience;

            if (niveauPokemon > 0 && niveauPokemon <= 50)
            {
                experience = Math.Round(Math.Pow(niveauPokemon, 3) * ((100 - niveauPokemon) / 50), MidpointRounding.AwayFromZero);
            }
            else if (niveauPokemon >= 51 && niveauPokemon <= 68)
            {
                experience = Math.Round(Math.Pow(niveauPokemon, 3) * ((150 - niveauPokemon) / 100), MidpointRounding.AwayFromZero);
            }
            else if (niveauPokemon >= 69 && niveauPokemon <= 98)
            {
                double x = niveauPokemon % 3;
                double fonctionP = 0;

                if (x == 0)
                {
                    fonctionP = 0.000;
                }
                else if(x == 1)
                {
                    fonctionP = 0.008;
                }
                else if(x == 2)
                {
                    fonctionP = 0.014;
                }
             
                experience = Math.Round(Math.Pow(niveauPokemon, 3) * (1.274 - (1d/50) * (98d/3) - fonctionP), MidpointRounding.AwayFromZero);
            }
            else if (niveauPokemon >= 99 && niveauPokemon <= 100)
            {
                experience = Math.Round(Math.Pow(niveauPokemon, 3) * ((160 - niveauPokemon) / 100), MidpointRounding.AwayFromZero);
            }
            else
            {
                experience = 0;
            }

            return (int)experience;
        }

        /// <summary>
        /// Cette méthode permet d'obtenir l'expérience au niveau actuel du pokémon si sa courbe d'expérience est fluctuante
        /// </summary>
        /// <returns>Expérience au niveau actuel
        public int getExperiencePokemonCourbeFluctuante()
        {
            double niveauPokemon = this.m_niveau;
            double experience = 0;

            if (niveauPokemon > 0 && niveauPokemon <= 15)
            {
                experience = Math.Round(Math.Pow(niveauPokemon, 3) * ((24 + ((niveauPokemon + 1) / 3)) / 50), MidpointRounding.AwayFromZero);
            }
            else if(niveauPokemon >= 16 && niveauPokemon <= 35)
            {
                experience = Math.Round(Math.Pow(niveauPokemon, 3) * ((14 + niveauPokemon) / 50), MidpointRounding.AwayFromZero);
            }
            else if (niveauPokemon >= 36 && niveauPokemon <= 100)
            {
                experience = Math.Round(Math.Pow(niveauPokemon, 3) * ((32 + (niveauPokemon / 2)) / 50), MidpointRounding.AwayFromZero);
            }

            if (experience < 0)
            {
                experience = 0;
            }

            return (int)experience;
        }

        /// <summary>
        /// Cette méthode permet de ramener l'expérience du pokémon à celle du niveau actuel du pokémon
        /// </summary>
        public void getExperiencePokemon()
        {
            if (this.m_courbe_experience == "Rapide")
            {
                this.m_experience = this.getExperiencePokemonCourbeRapide();
            }
            else if (this.m_courbe_experience == "Moyenne")
            {
                this.m_experience = this.getExperiencePokemonCourbeMoyenne();
            }
            else if (this.m_courbe_experience == "Parabolique")
            {
                this.m_experience = this.getExperiencePokemonCourbeParabolique();
            }
            else if (this.m_courbe_experience == "Lente")
            {
                this.m_experience = this.getExperiencePokemonCourbeLente();
            }
            else if (this.m_courbe_experience == "Erratique")
            {
                this.m_experience = this.getExperiencePokemonCourbeErratique();
            }
            else if (this.m_courbe_experience == "Fluctuante")
            {
                this.m_experience = this.getExperiencePokemonCourbeFluctuante();
            }
            else
            {
                this.m_experience = 0;
            }
        }

        /// <summary>
        /// Cette méthode permet d'obtenir l'expérience au niveau actuel du pokémon (à l'aide des autres méthodes de calcul des courbes d'expériences
        /// </summary>
        /// <returns>Expérience au niveau actuel
        public int getExperiencePokemonReturn()
        {
            if (this.m_courbe_experience == "Rapide")
            {
                return this.getExperiencePokemonCourbeRapide();
            }
            else if (this.m_courbe_experience == "Moyenne")
            {
                return this.getExperiencePokemonCourbeMoyenne();
            }
            else if (this.m_courbe_experience == "Parabolique")
            {
                return this.getExperiencePokemonCourbeParabolique();
            }
            else if (this.m_courbe_experience == "Lente")
            {
                return this.getExperiencePokemonCourbeLente();
            }
            else if (this.m_courbe_experience == "Erratique")
            {
                return this.getExperiencePokemonCourbeErratique();
            }
            else if (this.m_courbe_experience == "Fluctuante")
            {
                return this.getExperiencePokemonCourbeFluctuante();
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// Cette méthode permet d'obtenir l'expérience au prochain niveau du pokémon si le pokémon à une courbe d'expérience rapide
        /// </summary>
        /// <returns>Expérience au prochain niveau
        public int getExperiencePokemonProchainNiveauCourbeRapide()
        {
            double niveauPokemon = this.m_niveau + 1;
            double experienceProchainNiveau = Math.Round(0.8 * Math.Pow(niveauPokemon, 3), MidpointRounding.AwayFromZero);

            return (int)experienceProchainNiveau;
        }

        /// <summary>
        /// Cette méthode permet d'obtenir l'expérience au prochain niveau du pokémon si le pokémon à une courbe d'expérience moyenne
        /// </summary>
        /// <returns>Expérience au prochain niveau
        public int getExperiencePokemonProchainNiveauCourbeMoyenne()
        {
            double niveauPokemon = this.m_niveau + 1;
            double experienceProchainNiveau = Math.Round(Math.Pow(niveauPokemon, 3), MidpointRounding.AwayFromZero);
            return (int)experienceProchainNiveau;
        }

        /// <summary>
        /// Cette méthode permet d'obtenir l'expérience au prochain niveau du pokémon si le pokémon à une courbe d'expérience parabolique
        /// </summary>
        /// <returns>Expérience au prochain niveau
        public int getExperiencePokemonProchainNiveauCourbeParabolique()
        {
            double niveauPokemon = this.m_niveau + 1;
            double experienceProchainNiveau = Math.Round(1.2 * Math.Pow(niveauPokemon, 3) - 15 * Math.Pow(niveauPokemon, 2) + (100 * niveauPokemon) - 140, MidpointRounding.AwayFromZero);
            if (experienceProchainNiveau < 0)
            {
                experienceProchainNiveau = 0;
            }

            return (int)experienceProchainNiveau;
        }

        /// <summary>
        /// Cette méthode permet d'obtenir l'expérience au prochain niveau du pokémon si le pokémon à une courbe d'expérience lente
        /// </summary>
        /// <returns>Expérience au prochain niveau
        public int getExperiencePokemonProchainNiveauCourbeLente()
        {
            double niveauPokemon = this.m_niveau + 1;
            double experienceProchainNiveau = Math.Round(1.25 * Math.Pow(niveauPokemon, 3), MidpointRounding.AwayFromZero);
            return (int)experienceProchainNiveau;
        }

        /// <summary>
        /// Cette méthode permet d'obtenir l'expérience au prochain niveau du pokémon si le pokémon à une courbe d'expérience erratique
        /// </summary>
        /// <returns>Expérience au prochain niveau
        public int getExperiencePokemonProchainNiveauCourbeErratique()
        {
            double niveauPokemon = this.m_niveau + 1;
            double experienceProchainNiveau;

            if (niveauPokemon > 0 && niveauPokemon <= 50)
            {
                experienceProchainNiveau = Math.Round(Math.Pow(niveauPokemon, 3) * ((100 - niveauPokemon) / 50), MidpointRounding.AwayFromZero);
            }
            else if (niveauPokemon >= 51 && niveauPokemon <= 68)
            {
                experienceProchainNiveau = Math.Round(Math.Pow(niveauPokemon, 3) * ((150 - niveauPokemon) / 100), MidpointRounding.AwayFromZero);
            }
            else if (niveauPokemon >= 69 && niveauPokemon <= 98)
            {
                double x = niveauPokemon % 3;
                double fonctionP = 0;

                if (x == 0)
                {
                    fonctionP = 0.000;
                }
                else if (x == 1)
                {
                    fonctionP = 0.008;
                }
                else if (x == 2)
                {
                    fonctionP = 0.014;
                }

                experienceProchainNiveau = Math.Round(Math.Pow(niveauPokemon, 3) * (1.274 - (1d / 50) * (98d / 3) - fonctionP), MidpointRounding.AwayFromZero);
            }
            else if (niveauPokemon >= 99 && niveauPokemon <= 100)
            {
                experienceProchainNiveau = Math.Round(Math.Pow(niveauPokemon, 3) * ((160 - niveauPokemon) / 100), MidpointRounding.AwayFromZero);
            }
            else
            {
                experienceProchainNiveau = 0;
            }

            return (int)experienceProchainNiveau;
        }

        /// <summary>
        /// Cette méthode permet d'obtenir l'expérience au prochain niveau du pokémon si le pokémon à une courbe d'expérience fluctuante
        /// </summary>
        /// <returns>Expérience au prochain niveau
        public int getExperiencePokemonProchainNiveauCourbeFluctuante()
        {
            double niveauPokemon = this.m_niveau + 1;
            double experienceProchainNiveau = 0;

            if (niveauPokemon > 0 && niveauPokemon <= 15)
            {
                experienceProchainNiveau = Math.Round(Math.Pow(niveauPokemon, 3) * ((24 + ((niveauPokemon + 1) / 3)) / 50), MidpointRounding.AwayFromZero);
            }
            else if (niveauPokemon >= 16 && niveauPokemon <= 35)
            {
                experienceProchainNiveau = Math.Round(Math.Pow(niveauPokemon, 3) * ((14 + niveauPokemon) / 50), MidpointRounding.AwayFromZero);
            }
            else if (niveauPokemon >= 36 && niveauPokemon <= 100)
            {
                experienceProchainNiveau = Math.Round(Math.Pow(niveauPokemon, 3) * ((32 + (niveauPokemon / 2)) / 50), MidpointRounding.AwayFromZero);
            }

            if (experienceProchainNiveau < 0)
            {
                experienceProchainNiveau = 0;
            }

            return (int)experienceProchainNiveau;
        }

        /// <summary>
        /// Cette méthode permet d'obtenir l'expérience au prochain niveau du pokémon (grâce aux différentes méthodes de calcul d'expérience du prochain niveau)
        /// </summary>
        /// <returns>Expérience au prochain niveau
        public int getExperiencePokemonProchainNiveau()
        {
            if (this.m_courbe_experience == "Rapide")
            {
                return this.getExperiencePokemonProchainNiveauCourbeRapide();
            }
            else if (this.m_courbe_experience == "Moyenne")
            {
                return this.getExperiencePokemonProchainNiveauCourbeMoyenne();
            }
            else if (this.m_courbe_experience == "Parabolique")
            {
               return this.getExperiencePokemonProchainNiveauCourbeParabolique();
            }
            else if (this.m_courbe_experience == "Lente")
            {
                return this.getExperiencePokemonProchainNiveauCourbeLente();
            }
            else if (this.m_courbe_experience == "Erratique")
            {
                return this.getExperiencePokemonProchainNiveauCourbeErratique();
            }
            else if (this.m_courbe_experience == "Fluctuante")
            {
                return this.getExperiencePokemonProchainNiveauCourbeFluctuante();
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// Cette méthode permet d'obtenir et d'additionner l'expérience gagné par le pokémon
        /// </summary>
        /// <param name=pokemon>Pokémon battu</param>
        /// <returns>L'expérience obtenu par le pokémon qui a gagné</returns>
        public double gainExperiencePokemonBattu(Pokemon pokemon)
        {
            double bonus = 1;
            double experience_base = 0;

            if (pokemon.getGainExperiencePokemon() != 0) {
                experience_base = pokemon.getGainExperiencePokemon();
            }
            double niveau_pokemon = pokemon.getNiveau();

            double experienceGagner = Math.Round(bonus * experience_base * (niveau_pokemon / 7), MidpointRounding.AwayFromZero);

            this.m_experience += (int)experienceGagner; 

            return experienceGagner;
        }

        /// <summary>
        /// Cette méthode permet de savoir si une attaque a permit au pokémon adverse de changer de statut
        /// </summary>
        /// <param name=attaque>Attaque</param>
        /// <returns>Retourne si oui ou non l'attaque a fait changer le statut du pokémon</returns>
        public bool getAttaqueChangementStatutPokemonAdverseReussi(Attaque attaque)
        {
            Random random = new Random();
            double rand = random.Next(0, 100);

            if (rand <= attaque.getProbabiliteChangementStatutPokemonAdverse())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Cette méthode permet au pokémon d'attaquer en infligeant 20 points de dégâts
        /// </summary>
        /// <param name=pokemon>Pokémon défensif</param>
        public void attaque(Pokemon pokemon)
        {
            pokemon.m_pv_restant = pokemon.m_pv_restant - 20;
        }

        /// <summary>
        /// Cette méthode permet de retourner le type d'un pokémon (ne sert à rien)
        /// </summary>
        /// <param name=numeroType>numéro du type du pokémon</param>
        /// <returns>Retourne le type du pokémon</returns>
        public string retournerTypePokemon(int numeroType)
        {
            type.Add("Plante");
            type.Add("Feu");

            return type.ToString();
        }

        /// <summary>
        /// Cette méthode permet de retourner une chaine de caractère
        /// </summary>
        /// <returns>Retourne une chaine de caractère</returns>
        public override string ToString()
        {
            return type.ToString();
        }

    }

    /// <summary> 
    /// Classe attaque
    /// </summary>
    [DataContract]
    public class Attaque
    {
        [DataMember]
        private int m_id_attaque;
        [DataMember]
        private string m_nom;

        [DataMember]
        private int m_valeur;
        [DataMember]
        private int m_puissance_base;
        [DataMember]
        private double m_precision = 1;
        [DataMember]
        private int m_priorite_attaque = 0;
        [DataMember]
        private int m_pp;
        [DataMember]
        private int m_pp_restant;
        [DataMember]
        private int m_pp_maximum;

        [DataMember]
        private int m_id_type_attaque;
        [DataMember]
        private string m_type_attaque;
        [DataMember]
        private string m_physique_speciale_attaque;
        [DataMember]
        private double m_probabilite_changement_statut;

        /// <summary>
        /// Cette méthode permet de retourner l'id d'une attaque (permet de faire correspondre les atttaques et les pokémon)
        /// </summary>
        /// <returns>Retourne l'id de l'attaque</returns>
        public int getId()
        {
            return m_id_attaque;
        }

        /// <summary>
        /// Cette méthode permet de retourner le nom d'une attaque (permet de faire correspondre les atttaques et les pokémon)
        /// </summary>
        /// <returns>Retourne le nom de l'attaque</returns>
        public string getNom()
        {
            return m_nom;
        }

        /// <summary>
        /// Cette méthode permet de retourner la valeur d'une attaque 
        /// </summary>
        /// <returns>Retourne la valeur de l'attaque</returns>
        public int getValeur()
        {
            return m_valeur;
        }

        /// <summary>
        /// Cette méthode permet de retourner la puissance de base d'une attaque
        /// </summary>
        /// <returns>Retourne la puissance de base de l'attaque</returns>
        public int getPuissanceBase()
        {
            return m_puissance_base;
        }

        /// <summary>
        /// Cette méthode permet de retourner la précision d'une attaque
        /// </summary>
        /// <returns>Retourne la précision de l'attaque</returns>
        public double getPrecisionAttaque()
        {
            return m_precision;
        }

        /// <summary>
        /// Cette méthode permet de retourner la valeur de la priorité d'une attaque
        /// </summary>
        /// <returns>Retourne la valeur de la priorité de l'attaque</returns>
        public int getPrioriteAttaque()
        {
            return m_priorite_attaque;
        }

        /// <summary>
        /// Cette méthode permet de retourner le nombre de pp d'une attaque
        /// </summary>
        /// <returns>Retourne le nombre de pp de l'attaque</returns>
        public int getPP()
        {
            return m_pp;
        }

        /// <summary>
        /// Cette méthode permet de retourner le nombre de pp restant d'une attaque
        /// </summary>
        /// <returns>Retourne le nombre de pp restant de l'attaque</returns>
        public int getPPRestant()
        {
            return m_pp_restant;
        }

        /// <summary>
        /// Cette méthode permet de retourner le nombre de pp maximum que peut avoir une attaque
        /// </summary>
        /// <returns>Retourne le nombre de pp maximum de l'attaque</returns>
        public int getPPMaximum()
        {
            return m_pp_maximum;
        }

        /// <summary>
        /// Cette méthode permet de retourner l'id du type d'une attaque (permet de faire correspondre les atttaques et les types)
        /// </summary>
        /// <returns>Retourne l'id du type de l'attaque</returns>
        public int getIdTypeAttaque()
        {
            return m_id_type_attaque;
        }

        /// <summary>
        /// Cette méthode permet de retourner le type d'une attaque
        /// </summary>
        /// <returns>Retourne le type de l'attaque</returns>
        public string getTypeAttaque()
        {
            return m_type_attaque;
        }

        /// <summary>
        /// Cette méthode permet de savoir si une attaque est physique ou spéciale ou statut
        /// </summary>
        /// <returns>Retourne une chaîne de caractères pour savoir si une attaque est physique ou spéciale ou statut</returns>
        public string getPhysiqueOuSpécialeAttaque()
        {
            return m_physique_speciale_attaque;
        }

        /// <summary>
        /// Cette méthode permet de retourner la probabilité qu'un pokémon adverse puisse changer de statut suite à une attaque
        /// </summary>
        /// <returns>Retourne la probabilité qu'un pokémon adverse puisse changer de statut suite à une attaque</returns>
        public double getProbabiliteChangementStatutPokemonAdverse()
        {
            return m_probabilite_changement_statut;
        }

        /// <summary>
        /// Cette méthode permet de définir l'id d'une attaque
        /// </summary>
        /// <param name=id>Id d'une attaque</param>
        public void setId(int id)
        {
            this.m_id_attaque = id;
        }

        /// <summary>
        /// Cette méthode permet de définir le nom de l'attaque
        /// </summary>
        /// <param name=nom>Nom de l'attaque</param>
        public void setNom(string nom)
        {
            this.m_nom = nom;
        }

        /// <summary>
        /// Cette méthode permet de définir la valeur de l'attaque
        /// </summary>
        /// <param name=valeur>Valeur de l'attaque</param>
        public void setValeur(int valeur)
        {
            this.m_valeur = valeur;
        }

        /// <summary>
        /// Cette méthode permet de définir la puissance de base de l'attaque
        /// </summary>
        /// <param name=puissanceBase>Puissance de base de l'attaque</param>
        public void setPuissanceBase(int puissanceBase)
        {
            this.m_puissance_base = puissanceBase;
        }

        /// <summary>
        /// Cette méthode permet de définir la précision de l'attaque
        /// </summary>
        /// <param name=precisionAttaque>Précision de l'attaque</param>
        public void setPrecisionAttaque(double precisionAttaque)
        {
            this.m_precision = precisionAttaque;
        }

        /// <summary>
        /// Cette méthode permet de définir la valeur de priorité de l'attaque
        /// </summary>
        /// <param name=prioriteAttaque>Priorité de l'attaque</param>
        public void setPrioriteAttaque(int prioriteAttaque)
        {
            this.m_priorite_attaque = prioriteAttaque;
        }

        /// <summary>
        /// Cette méthode permet de définir le nombre de pp de l'attaque
        /// </summary>
        /// <param name=ppAttaque>PP de l'attaque</param>
        public void setPP(int ppAttaque)
        {
            this.m_pp = ppAttaque;
        }

        /// <summary>
        /// Cette méthode permet de définir le nombre de pp restant de l'attaque
        /// </summary>
        /// <param name=ppRestant>PP restant de l'attaque</param>
        public void setPPRestant(int ppRestant)
        {
            this.m_pp_restant = ppRestant;
        }

        /// <summary>
        /// Cette méthode permet de définir le nombre de pp maximum de l'attaque
        /// </summary>
        /// <param name=ppMaximum>PP maximum de l'attaque</param>
        public void setPPMaximum(int ppMaximum)
        {
            this.m_pp_maximum = ppMaximum;
        }

        /// <summary>
        /// Cette méthode permet de définir l'id du type de l'attaque
        /// </summary>
        /// <param name=id_type_attaque>Id du type de l'attaque</param>
        public void setIdTypeAttaque(int id_type_attaque)
        {
            this.m_id_type_attaque = id_type_attaque;
        }

        /// <summary>
        /// Cette méthode permet de définir le type de l'attaque
        /// </summary>
        /// <param name=type_attaque>Type de l'attaque</param>
        public void setTypeAttaque(string type_attaque)
        {
            this.m_type_attaque = type_attaque;
        }

        /// <summary>
        /// Cette méthode permet de définir si l'attaque est physique, spéciale ou statut
        /// </summary>
        /// <param name=type_physique_ou_speciale_attaque>Chaîne de caractère contenant le type physique, spéciale ou statut de l'attaque</param>
        public void setPhysiqueOuSpecialeAttaque(string type_physique_ou_speciale_attaque)
        {
            this.m_physique_speciale_attaque = type_physique_ou_speciale_attaque;
        }

        /// <summary>
        /// Cette méthode permet de définir la probabilité de changement de statut d'un pokémon adverse suite à une attaque
        /// </summary>
        /// <param name=probabiliteChangementStatut>Probabilité de changement de statut d'un pokémon adverse suite à une attaque</param>
        public void setProbabiliteChangementStatutPokemonAdverse(double probabiliteChangementStatut)
        {
            this.m_probabilite_changement_statut = probabiliteChangementStatut;
        }

        /// <summary>
        /// Cette méthode permet de créer une attaque et de l'initialiser
        /// </summary>
        /// <param name=idAttaque>Id de l'attaque</param>
        /// <param name=nomAttaque>Nom de l'attaque</param>
        /// <param name=idTypeAttaque>Id du type de l'attaque</param>
        /// <param name=degats>Dégâts de l'attaque (ne sert à rien, il me semble)</param>
        /// <param name=typeAttaque>Type de l'attaque</param>
        /// <param name=puissanceBase>Puissance de base de l'attaque</param>
        /// <param name=physiqueOuSpeciale>Chaîne de caractère permettant de savoir si l'attaque est physique, spéciale ou statut</param>
        /// <param name=pp>Nombre de pp de l'attaque</param>
        /// <param name=ppMaximum>pp maximum de l'attaque</param>
        /// <param name=probabiliteChangementStatut>Probabilité pour que le pokémon adverse change de statut suite à l'attaque</param>
        /// <returns>Attaque</returns>
        public Attaque createAttaque(int idAttaque, string nomAttaque, int idTypeAttaque, int degats, string typeAttaque, int puissanceBase, string physiqueOuSpeciale, int pp, int ppMaximum, int probabiliteChangementStatut)
        {
            Attaque attaque = new Attaque();

            attaque.setId(idAttaque);
            attaque.setNom(nomAttaque);
            attaque.setIdTypeAttaque(idTypeAttaque);
            attaque.setValeur(degats);
            attaque.setTypeAttaque(typeAttaque);
            attaque.setPuissanceBase(puissanceBase);
            attaque.setPhysiqueOuSpecialeAttaque(physiqueOuSpeciale);
            attaque.setPP(pp);
            attaque.setPPRestant(pp);
            attaque.setPPMaximum(ppMaximum);
            attaque.setProbabiliteChangementStatutPokemonAdverse(probabiliteChangementStatut);

            return attaque;
        }
    }

    public class typePokemon
    {
        private string nom;
        private ArrayList faiblesse = new ArrayList();

        public void SetNom(string unNom)
        {
            this.nom = unNom;
        }
        public string GetNom()
        {
            return nom;
        }

    }
    public class faiblesse : typePokemon
    {

    }

    /// <summary> 
    /// Classe d'objet qui possède un nom, un type, une valeur, une quantité
    /// </summary>
    [DataContract]
    public class Objet
    {
        [DataMember]
        private int m_id;
        [DataMember]
        private string m_nom;
        [DataMember]
        private string m_type_objet;
        [DataMember]
        private int m_quantite;
        [DataMember]
        private double m_valeur;

        /// <summary>
        /// Cette méthode permet de retourner le nom de l'objet
        /// </summary>
        /// <returns>Retourne le nom de l'objet</returns>
        public string getNom()
        {
            return m_nom;
        }

        /// <summary>
        /// Cette méthode permet de définir le nom de l'objet
        /// </summary>
        /// <param name=nom>Nom de l'objet</param>
        public void setNom(string nom)
        { 
                this.m_nom = nom;
        }

        /// <summary>
        /// Cette méthode permet de retourner l'id de l'objet
        /// </summary>
        /// <returns>Retourne l'id de l'objet</returns>
        public int getIdObjet()
        {
            return m_id;
        }

        /// <summary>
        /// Cette méthode permet de définir l'id de l'objet
        /// </summary>
        /// <param name=id>Id de l'objet</param>
        public void setIdObjet(int id)
        {
            this.m_id = id;
        }

        /// <summary>
        /// Cette méthode permet de retourner le type de l'objet
        /// </summary>
        /// <returns>Retourne le type de l'objet</returns>
        public string getTypeObjet()
        {
            return m_type_objet;
        }

        /// <summary>
        /// Cette méthode permet de définir le type de l'objet
        /// </summary>
        /// <param name=type_objet>Type de l'objet</param>
        public void setTypeObjet(string type_objet)
        {
            this.m_type_objet = type_objet;
        }

        /// <summary>
        /// Cette méthode permet de retourner la quantité présente de l'objet
        /// </summary>
        /// <returns>Retourne la quantité présente de l'objet</returns>
        public int getQuantiteObjet()
        {
            return m_quantite;
        }

        /// <summary>
        /// Cette méthode permet de définir la quantité présente de l'objet
        /// </summary>
        /// <param name=quantiteObjet>Quantité de l'objet</param>
        public void setQuantiteObjet(int quantiteObjet)
        {
            this.m_quantite = quantiteObjet;
        }

        /// <summary>
        /// Cette méthode permet de retourner la valeur de l'objet (Objet de soin = combien va soigner l'objet, pokéball = valeur de capture)
        /// </summary>
        /// <returns>Retourne la valeur de l'objet</returns>
        public double getValeurObjet()
        {
            return m_valeur;
        }

        /// <summary>
        /// Cette méthode permet de définir la valeur de l'objet
        /// </summary>
        /// <param name=valeurObjet>Valeur de l'objet</param>
        public void setValeurObjet(double valeurObjet)
        {
            this.m_valeur = valeurObjet;
        }

        /// <summary>
        /// Cette méthode permet de créer et d'initialiser un objet
        /// </summary>
        /// <param name=id>Id de l'objet</param>
        /// <param name=nom>Nom de l'objet</param>
        /// <param name=typeObjet>Type de l'objet</param>
        /// <param name=valeur>Valeur de l'objet</param>
        /// <param name=quantite>Quantité de l'objet</param>
        /// <returns>Retourne l'objet</returns>
        public Objet createObjet(int id, string nom, string typeObjet, int valeur, int quantite)
        {
            Objet objet = new Objet();

            objet.setIdObjet(id);
            objet.setNom(nom);
            objet.setTypeObjet(typeObjet);
            objet.setValeurObjet(valeur);
            objet.setQuantiteObjet(quantite);

            return objet;
        }

        /// <summary>
        /// Cette méthode permet de chercher un objet dans les statistiques du jeu et de le retourner
        /// </summary>
        /// <param name=nomObjet>Nom de l'objet</param>
        /// <param name=jeu>Statistiques du jeu</param>
        /// <returns>Retourne l'objet trouvé</returns>
        public Objet setChercherObjet(string nomObjet, Jeu jeu)
        {
            return jeu.getListeObjet().Find(objet => objet.getNom().Equals(nomObjet));
        }

        /// <summary>
        /// Cette méthode permet de soigner un pokémon à l'aide d'un objet de soin
        /// </summary>
        /// <param name=poke>Pokémon qui va se faire soigner</param>
        /// <param name=objet>Objet de soin</param>
        public void Soin(Pokemon poke, Objet objet)
        {
            if (objet.getTypeObjet() == "Soin" && objet.getQuantiteObjet() > 0)
            {
                if (poke.getPvRestant() + objet.getValeurObjet() < poke.getPv())
                {
                    poke.setPvRestant(poke.getPvRestant() + (int)objet.getValeurObjet());
                }
                else
                {
                    poke.setPvRestant(poke.getPv());
                }
                objet.setQuantiteObjet(objet.getQuantiteObjet() - 1);
            }
        }
    }

    /// <summary>
    /// Classe d'accès aux données
    /// </summary>
    public class accesDonnees
    {
        MySqlConnection connexion = new MySqlConnection("database=pokemon; server=localhost; user id=root"); // Connexion à la base de données

        /// <summary>
        /// Cette méthode permet de sélectionner certaines statistiques des pokémon dans un fichier depuis la base de données
        /// </summary>
        public void selection()
        {
            MySqlCommand command = new MySqlCommand();
            command.Connection = connexion;

            string pathCommandes = AppDomain.CurrentDomain.BaseDirectory + "commandes.txt";

            // tentative de connexion à la base de données
            try
            {
                System.IO.File.AppendAllText(pathCommandes, "Connexion à MySQL... \n");
                connexion.Open();
                command.CommandText = "SELECT * FROM pokemon";

                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    string textReadIdPokemon = reader["id"].ToString();
                    string textReadNom = reader["nom"].ToString();
                    System.IO.File.AppendAllText(pathCommandes, textReadIdPokemon + " ");
                    System.IO.File.AppendAllText(pathCommandes, textReadNom + "\n");
                }
                reader.Close();
            }

            catch (Exception ex)
            {
                System.IO.File.AppendAllText(pathCommandes, ex.ToString() + "\n");
            }

            connexion.Close();
        }


        /// <summary>
        /// Cette méthode permet de sélectionner certaines statistiques des pokémon dans un arraylist depuis la base de données
        /// </summary>
        /// <returns>Retourne un arraylist avec les statistiques des pokémon trouvés</returns>
        public ArrayList selectionPokemon()
        {
            MySqlCommand command = new MySqlCommand();
            command.Connection = connexion;
            ArrayList test = new ArrayList();
            // tentative de connexion à la base de données
            try
            {
                connexion.Open();
                command.CommandText = "SELECT * FROM pokemon";
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    string textReadIdPokemon = reader["id"].ToString();
                    string textReadNom = reader["nom"].ToString();
                    string textReadPV = reader["PV"].ToString();
                    test.Add(textReadNom);

                }
                reader.Close();
                connexion.Close();
                return test;
            }

            catch (Exception ex)
            {
                // System.IO.File.AppendAllText(pathCommandes, ex.ToString() + "\n");
                test.Add("");
                connexion.Close();
                return test;

            }

        }

        /// <summary>
        /// Cette méthode permet de retourner la liste des pokémon avec leurs statistiques à l'aide de la base de données
        /// </summary>
        /// <returns>Retourne la liste des pokémon</returns>
        public List<Pokemon> selectionListePokemon()
        {
            MySqlCommand command = new MySqlCommand();
            command.Connection = connexion;

            List<Pokemon> liste_pokemon = new List<Pokemon>();

            string pathCommandesStarter = AppDomain.CurrentDomain.BaseDirectory + "commandesStart.txt";

            // tentative de connexion à la base de données
            try
            {
                connexion.Open();

                command.CommandText = "SELECT * FROM pokemon";

                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int textReadBasePvPokemon = Convert.ToInt32(reader["base_pv"]);
                    string textReadNomPokemon = reader["nom"].ToString();
                    int textReadIdPokemon = Convert.ToInt32(reader["Id"]);
                    int textReadNoIdPokedex = Convert.ToInt32(reader["no_id"]);
                    string textReadNomAttaque1 = reader["attaque_1"].ToString();
                    string textReadNomAttaque2 = reader["attaque_2"].ToString();
                    string textReadNomAttaque3 = reader["attaque_3"].ToString();
                    string textReadNomAttaque4 = reader["attaque_4"].ToString();
                    int textReadIdType = Convert.ToInt32(reader["id_type"]);
                    int textReadNiveau = Convert.ToInt32(reader["Niveau"]);
                    string textReadNature = reader["nature"].ToString();
                    string textReadType = reader["type"].ToString();
                    string textReadCourbeExperience = reader["courbe_experience"].ToString();
                    int textReadGainExperience = Convert.ToInt32(reader["gain_experience"]);
                    int textReadTauxCapture = Convert.ToInt32(reader["taux_capture"]);
                    double textReadProbabiliteSexeFeminin = Convert.ToDouble(reader["probabilite_sexe_feminin"]);

                    int textReadBaseAttaque = Convert.ToInt32(reader["base_attaque"]);
                    int textReadBaseDefense = Convert.ToInt32(reader["base_defense"]);
                    int textReadBaseVitesse = Convert.ToInt32(reader["base_vitesse"]);
                    int textReadBaseAttaqueSpeciale = Convert.ToInt32(reader["base_attaque_speciale"]);
                    int textReadBaseDefenseSpeciale = Convert.ToInt32(reader["base_defense_speciale"]);

                    int textReadIvPv = Convert.ToInt32(reader["iv_pv"]);
                    int textReadIvAttaque = Convert.ToInt32(reader["iv_attaque"]);
                    int textReadIvDefense = Convert.ToInt32(reader["iv_defense"]);
                    int textReadIvVitesse = Convert.ToInt32(reader["iv_vitesse"]);
                    int textReadIvAttaqueSpeciale = Convert.ToInt32(reader["iv_attaque_speciale"]);
                    int textReadIvDefenseSpeciale = Convert.ToInt32(reader["iv_defense_speciale"]);

                    int textReadEvPv = Convert.ToInt32(reader["ev_pv"]);
                    int textReadEvAttaque = Convert.ToInt32(reader["ev_attaque"]);
                    int textReadEvDefense = Convert.ToInt32(reader["ev_defense"]);
                    int textReadEvVitesse = Convert.ToInt32(reader["ev_vitesse"]);
                    int textReadEvAttaqueSpeciale = Convert.ToInt32(reader["ev_attaque_speciale"]);
                    int textReadEvDefenseSpeciale = Convert.ToInt32(reader["ev_defense_speciale"]);

                    int textReadGainEvPv = Convert.ToInt32(reader["gain_ev_pv"]);
                    int textReadGainEvAttaque = Convert.ToInt32(reader["gain_ev_attaque"]);
                    int textReadGainEvDefense = Convert.ToInt32(reader["gain_ev_defense"]);
                    int textReadGainEvVitesse = Convert.ToInt32(reader["gain_ev_vitesse"]);
                    int textReadGainEvAttaqueSpeciale = Convert.ToInt32(reader["gain_ev_attaque_speciale"]);
                    int textReadGainEvDefenseSpeciale = Convert.ToInt32(reader["gain_ev_defense_speciale"]);

                    System.IO.File.AppendAllText(pathCommandesStarter, textReadBasePvPokemon + " ");

                    Pokemon poke = new Pokemon();

                    poke.setPokemon(textReadNomPokemon);
                    poke.setIdPokemonAvecId(textReadIdPokemon);
                    poke.setNoPokedexPokemon(textReadNoIdPokedex);
                    poke.setSexeRand(textReadProbabiliteSexeFeminin);
                    poke.setNomAttaque1(textReadNomAttaque1);
                    poke.setNomAttaque2(textReadNomAttaque2);
                    poke.setNomAttaque3(textReadNomAttaque3);
                    poke.setNomAttaque4(textReadNomAttaque4);
                    poke.setNiveau(textReadNiveau);
                    poke.setNature(textReadNature);
                    poke.setType(textReadType);
                    poke.setTypeCourbeExperience(textReadCourbeExperience);
                    poke.setGainExperiencePokemon(textReadGainExperience);
                    poke.getExperiencePokemon();
                    poke.setTauxCapturePokemon(textReadTauxCapture);

                    poke.setBasePvPokemon(textReadBasePvPokemon);
                    poke.setBaseAttaque(textReadBaseAttaque);
                    poke.setBaseDefense(textReadBaseDefense);
                    poke.setBaseVitesse(textReadBaseVitesse);
                    poke.setBaseAttaqueSpeciale(textReadBaseAttaqueSpeciale);
                    poke.setBaseDefenseSpeciale(textReadBaseDefenseSpeciale);

                    poke.setIvPv(textReadIvPv);
                    poke.setIvAttaque(textReadIvAttaque);
                    poke.setIvDefense(textReadIvDefense);
                    poke.setIvVitesse(textReadIvVitesse);
                    poke.setIvAttaqueSpeciale(textReadIvAttaqueSpeciale);
                    poke.setIvDefenseSpeciale(textReadIvDefenseSpeciale);

                    poke.setEvPv(textReadEvPv);
                    poke.setEvAttaque(textReadEvAttaque);
                    poke.setEvDefense(textReadEvDefense);
                    poke.setEvVitesse(textReadEvVitesse);
                    poke.setEvAttaqueSpeciale(textReadEvAttaqueSpeciale);
                    poke.setEvDefenseSpeciale(textReadEvDefenseSpeciale);

                    poke.setGainEvPv(textReadGainEvPv);
                    poke.setGainEvAttaque(textReadGainEvAttaque);
                    poke.setGainEvDefense(textReadGainEvDefense);
                    poke.setGainEvVitesse(textReadGainEvVitesse);
                    poke.setGainEvAttaqueSpeciale(textReadGainEvAttaqueSpeciale);
                    poke.setGainEvDefenseSpeciale(textReadGainEvDefenseSpeciale);

                    liste_pokemon.Add(poke);

                }
                reader.Close();
                connexion.Close();

                return liste_pokemon;
            }

            catch (Exception ex)
            {
                connexion.Close();
                return liste_pokemon;
            }
        }

        /// <summary>
        /// Cette méthode permet de retourner un pokémon avec ses statistiques à l'aide de la base de données
        /// </summary>
        /// <returns>Retourne un pokémon</returns>
        public Pokemon selectionPokemonStats()
        {
            MySqlCommand command = new MySqlCommand();
            command.Connection = connexion;

            Pokemon poke = new Pokemon();

            // tentative de connexion à la base de données
            try
            {
                connexion.Open();

                command.CommandText = "SELECT * FROM pokemon";

                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int textReadBasePvPokemon = Convert.ToInt32(reader["statistiques_pv"]);
                    string textReadNomPokemon = reader["nom"].ToString();
                    int textReadIdPokemon = Convert.ToInt32(reader["Id"]);
                    int textReadNoIdPokedex = Convert.ToInt32(reader["no_id"]);
                    string textReadNomAttaque1 = reader["attaque_1"].ToString();
                    string textReadNomAttaque2 = reader["attaque_2"].ToString();
                    string textReadNomAttaque3 = reader["attaque_3"].ToString();
                    string textReadNomAttaque4 = reader["attaque_4"].ToString();
                    int textReadIdType = Convert.ToInt32(reader["id_type"]);
                    int textReadNiveau = Convert.ToInt32(reader["Niveau"]);
                    string textReadNature = reader["nature"].ToString();
                    string textReadType = reader["type"].ToString();
                    string textReadCourbeExperience = reader["courbe_experience"].ToString();
                    int textReadGainExperience = Convert.ToInt32(reader["gain_experience"]);
                    int textReadTauxCapture = Convert.ToInt32(reader["taux_capture"]);
                    double textReadProbabiliteSexeFeminin = Convert.ToDouble(reader["probabilite_sexe_feminin"]);

                    int textReadBaseAttaque = Convert.ToInt32(reader["base_attaque"]);
                    int textReadBaseDefense = Convert.ToInt32(reader["base_defense"]);
                    int textReadBaseVitesse = Convert.ToInt32(reader["base_vitesse"]);
                    int textReadBaseAttaqueSpeciale = Convert.ToInt32(reader["base_attaque_speciale"]);
                    int textReadBaseDefenseSpeciale = Convert.ToInt32(reader["base_defense_speciale"]);

                    int textReadIvPv = Convert.ToInt32(reader["iv_pv"]);
                    int textReadIvAttaque = Convert.ToInt32(reader["iv_attaque"]);
                    int textReadIvDefense = Convert.ToInt32(reader["iv_defense"]);
                    int textReadIvVitesse = Convert.ToInt32(reader["iv_vitesse"]);
                    int textReadIvAttaqueSpeciale = Convert.ToInt32(reader["iv_attaque_speciale"]);
                    int textReadIvDefenseSpeciale = Convert.ToInt32(reader["iv_defense_speciale"]);

                    int textReadEvPv = Convert.ToInt32(reader["ev_pv"]);
                    int textReadEvAttaque = Convert.ToInt32(reader["ev_attaque"]);
                    int textReadEvDefense = Convert.ToInt32(reader["ev_defense"]);
                    int textReadEvVitesse = Convert.ToInt32(reader["ev_vitesse"]);
                    int textReadEvAttaqueSpeciale = Convert.ToInt32(reader["ev_attaque_speciale"]);
                    int textReadEvDefenseSpeciale = Convert.ToInt32(reader["ev_defense_speciale"]);

                    int textReadGainEvPv = Convert.ToInt32(reader["gain_ev_pv"]);
                    int textReadGainEvAttaque = Convert.ToInt32(reader["gain_ev_attaque"]);
                    int textReadGainEvDefense = Convert.ToInt32(reader["gain_ev_defense"]);
                    int textReadGainEvVitesse = Convert.ToInt32(reader["gain_ev_vitesse"]);
                    int textReadGainEvAttaqueSpeciale = Convert.ToInt32(reader["gain_ev_attaque_speciale"]);
                    int textReadGainEvDefenseSpeciale = Convert.ToInt32(reader["gain_ev_defense_speciale"]);

                    poke.setPokemon(textReadNomPokemon);
                    poke.setIdPokemonAvecId(textReadIdPokemon);
                    poke.setNoPokedexPokemon(textReadNoIdPokedex);
                    poke.setSexeRand(textReadProbabiliteSexeFeminin);
                    poke.setNomAttaque1(textReadNomAttaque1);
                    poke.setNomAttaque2(textReadNomAttaque2);
                    poke.setNomAttaque3(textReadNomAttaque3);
                    poke.setNomAttaque4(textReadNomAttaque4);
                    poke.setNiveau(textReadNiveau);
                    poke.setNature(textReadNature);
                    poke.setType(textReadType);
                    poke.setTypeCourbeExperience(textReadCourbeExperience);
                    poke.setGainExperiencePokemon(textReadGainExperience);
                    poke.getExperiencePokemon();
                    poke.setTauxCapturePokemon(textReadTauxCapture);

                    poke.setBasePvPokemon(textReadBasePvPokemon);
                    poke.setBaseAttaque(textReadBaseAttaque);
                    poke.setBaseDefense(textReadBaseDefense);
                    poke.setBaseVitesse(textReadBaseVitesse);
                    poke.setBaseAttaqueSpeciale(textReadBaseAttaqueSpeciale);
                    poke.setBaseDefenseSpeciale(textReadBaseDefenseSpeciale);

                    poke.setIvPv(textReadIvPv);
                    poke.setIvAttaque(textReadIvAttaque);
                    poke.setIvDefense(textReadIvDefense);
                    poke.setIvVitesse(textReadIvVitesse);
                    poke.setIvAttaqueSpeciale(textReadIvAttaqueSpeciale);
                    poke.setIvDefenseSpeciale(textReadIvDefenseSpeciale);

                    poke.setEvPv(textReadEvPv);
                    poke.setEvAttaque(textReadEvAttaque);
                    poke.setEvDefense(textReadEvDefense);
                    poke.setEvVitesse(textReadEvVitesse);
                    poke.setEvAttaqueSpeciale(textReadEvAttaqueSpeciale);
                    poke.setEvDefenseSpeciale(textReadEvDefenseSpeciale);

                    poke.setGainEvPv(textReadGainEvPv);
                    poke.setGainEvAttaque(textReadGainEvAttaque);
                    poke.setGainEvDefense(textReadGainEvDefense);
                    poke.setGainEvVitesse(textReadGainEvVitesse);
                    poke.setGainEvAttaqueSpeciale(textReadGainEvAttaqueSpeciale);
                    poke.setGainEvDefenseSpeciale(textReadGainEvDefenseSpeciale);
                }
                reader.Close();
                connexion.Close();

                return poke;
            }

            catch (Exception ex)
            {
                connexion.Close();
                return poke;
            }
        }

        /// <summary>
        /// Cette méthode permet de retourner le pokémon starter sélectionner à l'aide de la base de données
        /// </summary>
        /// <param name=nomPokemon>Nom du pokémon</param>
        /// <returns>Retourne le pokémon</returns>
        public Pokemon selectionPokemonStatsStarter(string nomPokemon)
        {
            MySqlCommand command = new MySqlCommand();
            command.Connection = connexion;

            string pathCommandesStarter = AppDomain.CurrentDomain.BaseDirectory + "commandesStarte.txt";

            Pokemon poke = new Pokemon();

            // tentative de connexion à la base de données
            try
            {
                connexion.Open();

                command.CommandText = "SELECT * FROM pokemon WHERE (Id = 1 OR Id = 4 OR Id = 7) AND nom='" + nomPokemon + "'";

                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int textReadBasePvPokemon = Convert.ToInt32(reader["base_pv"]);
                    string textReadNomPokemon = reader["nom"].ToString();
                    int textReadIdPokemon = Convert.ToInt32(reader["Id"]);
                    int textReadNoIdPokemon = Convert.ToInt32(reader["no_id"]);
                    // int textReadIdAttaque1 = Convert.ToInt32(reader["id_attaque_1"]);
                    string textReadNomAttaque1 = reader["attaque_1"].ToString();
                    string textReadNomAttaque2 = reader["attaque_2"].ToString();
                    string textReadNomAttaque3 = reader["attaque_3"].ToString();
                    string textReadNomAttaque4 = reader["attaque_4"].ToString();
                    // int textReadIdAttaque2 = Convert.ToInt32(reader["id_attaque_2"]);
                    int textReadIdAttaque3 = Convert.ToInt32(reader["id_attaque_3"]);
                    int textReadIdAttaque4 = Convert.ToInt32(reader["id_attaque_4"]);
                    int textReadNiveau = Convert.ToInt32(reader["Niveau"]);
                    string textReadNature = reader["nature"].ToString();
                    string textReadType = reader["type"].ToString();
                    string textReadCourbeExperience = reader["courbe_experience"].ToString();
                    int textReadGainExperience = Convert.ToInt32(reader["gain_experience"]);
                    int textReadTauxCapture = Convert.ToInt32(reader["taux_capture"]);
                    double textReadProbabiliteSexeFeminin = Convert.ToDouble(reader["probabilite_sexe_feminin"]);

                    int textReadBaseAttaque = Convert.ToInt32(reader["base_attaque"]);
                    int textReadBaseDefense = Convert.ToInt32(reader["base_defense"]);
                    int textReadBaseVitesse = Convert.ToInt32(reader["base_vitesse"]);
                    int textReadBaseAttaqueSpeciale = Convert.ToInt32(reader["base_attaque_speciale"]);
                    int textReadBaseDefenseSpeciale = Convert.ToInt32(reader["base_defense_speciale"]);

                    int textReadIvPv = Convert.ToInt32(reader["iv_pv"]);
                    int textReadIvAttaque = Convert.ToInt32(reader["iv_attaque"]);
                    int textReadIvDefense = Convert.ToInt32(reader["iv_defense"]);
                    int textReadIvVitesse = Convert.ToInt32(reader["iv_vitesse"]);
                    int textReadIvAttaqueSpeciale = Convert.ToInt32(reader["iv_attaque_speciale"]);
                    int textReadIvDefenseSpeciale = Convert.ToInt32(reader["iv_defense_speciale"]);

                    int textReadEvPv = Convert.ToInt32(reader["ev_pv"]);
                    int textReadEvAttaque = Convert.ToInt32(reader["ev_attaque"]);
                    int textReadEvDefense = Convert.ToInt32(reader["ev_defense"]);
                    int textReadEvVitesse = Convert.ToInt32(reader["ev_vitesse"]);
                    int textReadEvAttaqueSpeciale = Convert.ToInt32(reader["ev_attaque_speciale"]);
                    int textReadEvDefenseSpeciale = Convert.ToInt32(reader["ev_defense_speciale"]);

                    int textReadGainEvPv = Convert.ToInt32(reader["gain_ev_pv"]);
                    int textReadGainEvAttaque = Convert.ToInt32(reader["gain_ev_attaque"]);
                    int textReadGainEvDefense = Convert.ToInt32(reader["gain_ev_defense"]);
                    int textReadGainEvVitesse = Convert.ToInt32(reader["gain_ev_vitesse"]);
                    int textReadGainEvAttaqueSpeciale = Convert.ToInt32(reader["gain_ev_attaque_speciale"]);
                    int textReadGainEvDefenseSpeciale = Convert.ToInt32(reader["gain_ev_defense_speciale"]);


                    poke.setPokemon(textReadNomPokemon);
                    poke.setIdPokemonAvecId(textReadIdPokemon);
                    poke.setNoPokedexPokemon(textReadNoIdPokemon);
                    poke.setSexeRand(textReadProbabiliteSexeFeminin);
                    poke.setNomAttaque1(textReadNomAttaque1);
                    poke.setNomAttaque2(textReadNomAttaque2);
                    poke.setNomAttaque3(textReadNomAttaque3);
                    poke.setNomAttaque4(textReadNomAttaque4);
                    poke.setNiveau(textReadNiveau);
                    poke.setNature(textReadNature);
                    poke.setType(textReadType);
                    poke.setTypeCourbeExperience(textReadCourbeExperience);
                    poke.setGainExperiencePokemon(textReadGainExperience);
                    poke.getExperiencePokemon();
                    poke.setTauxCapturePokemon(textReadTauxCapture);

                    poke.setBasePvPokemon(textReadBasePvPokemon);
                    poke.setBaseAttaque(textReadBaseAttaque);
                    poke.setBaseDefense(textReadBaseDefense);
                    poke.setBaseVitesse(textReadBaseVitesse);
                    poke.setBaseAttaqueSpeciale(textReadBaseAttaqueSpeciale);
                    poke.setBaseDefenseSpeciale(textReadBaseDefenseSpeciale);

                    poke.setIvPv(textReadIvPv);
                    poke.setIvAttaque(textReadIvAttaque);
                    poke.setIvDefense(textReadIvDefense);
                    poke.setIvVitesse(textReadIvVitesse);
                    poke.setIvAttaqueSpeciale(textReadIvAttaqueSpeciale);
                    poke.setIvDefenseSpeciale(textReadIvDefenseSpeciale);

                    poke.setEvPv(textReadEvPv);
                    poke.setEvAttaque(textReadEvAttaque);
                    poke.setEvDefense(textReadEvDefense);
                    poke.setEvVitesse(textReadEvVitesse);
                    poke.setEvAttaqueSpeciale(textReadEvAttaqueSpeciale);
                    poke.setEvDefenseSpeciale(textReadEvDefenseSpeciale);

                    poke.setGainEvPv(textReadGainEvPv);
                    poke.setGainEvAttaque(textReadGainEvAttaque);
                    poke.setGainEvDefense(textReadGainEvDefense);
                    poke.setGainEvVitesse(textReadGainEvVitesse);
                    poke.setGainEvAttaqueSpeciale(textReadGainEvAttaqueSpeciale);
                    poke.setGainEvDefenseSpeciale(textReadGainEvDefenseSpeciale);

                }

                reader.Close();
                connexion.Close();

                return poke;
            }

            catch (Exception ex)
            {
                connexion.Close();
                return poke;
            }
        }


        /*
        public List<Attaque> selectionListeAttaquePokemon(Pokemon poke)
        {
            MySqlCommand command = new MySqlCommand();
            command.Connection = connexion;

            List<Attaque> attaques = new List<Attaque>();

            // tentative de connexion à la base de données
            try
            {
                connexion.Open();

                command.CommandText = "SELECT DISTINCT * FROM pokemon";

                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int textReadIdAttaque1 = Convert.ToInt32(reader["id_attaque_1"]);
                    string textReadIdAttaque2 = reader["id_attaque_2"].ToString();
                    int textReadIdAttaque3 = Convert.ToInt32(reader["id_attaque_3"]);
                    int textReadIdAttaque4 = Convert.ToInt32(reader["id_attaque_4"]);

                    Attaque attaqueRecuperer = new Attaque();

                    attaques.Add(attaqueRecuperer);

                }
                reader.Close();
                connexion.Close();

                return attaques;
            }

            catch (Exception ex)
            {
                connexion.Close();
                return attaques;
            }
        }
    */

        /// <summary>
        /// Cette méthode permet de retourner l'id d'un pokémon à l'aide de la base de données
        /// </summary>
        /// <param name=poke>Pokémon</param>
        /// <returns>Retourne l'id du pokémon</returns>
        public int selectionIdPokemon(Pokemon poke)
        {
            MySqlCommand command = new MySqlCommand();
            command.Connection = connexion;

            int textReadIdPokemon = 0;

            string nomPokemon = poke.getNom();

            // tentative de connexion à la base de données
            try
            {
                connexion.Open();

                command.CommandText = "SELECT DISTINCT no_id FROM pokemon WHERE nom='" + nomPokemon + "'";

                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    textReadIdPokemon = Convert.ToInt32(reader["Id"]);
                }
                reader.Close();
                connexion.Close();
                return textReadIdPokemon;

            }
            catch (Exception ex)
            {
                connexion.Close();
                return 0;
            }

        }

        /// <summary>
        /// Cette méthode permet de retourner un arraylist d'un pokémon contenant l'id, le nom et les pv à l'aide de la base de données
        /// </summary>
        /// <param name=nomPokemon>Nom du pokémon</param>
        /// <returns>Retourne un arraylist d'un pokémon contenant l'id, le nom et les pv</returns>
        public ArrayList selectionPvPokemon(string nomPokemon)
        {
            MySqlCommand command = new MySqlCommand();
            command.Connection = connexion;
            ArrayList test = new ArrayList();
            // tentative de connexion à la base de données
            try
            {
                connexion.Open();
                command.CommandText = "SELECT * FROM pokemon WHERE nom = '" + nomPokemon + "'";
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {

                    string textReadIdPokemon = reader["id"].ToString();
                    string textReadNom = reader["nom"].ToString();
                    int textReadPV = Convert.ToInt32(reader["PV"]);
                    test.Add(textReadPV);
                }
                reader.Close();
                connexion.Close();
                return test;
            }


            catch (Exception ex)
            {
                test.Add("");
                connexion.Close();
                return test;

            }
        }

        /// <summary>
        /// Cette méthode permet de retourner la liste des objets contenu dans le sac à l'aide de la base de données
        /// </summary>
        /// <returns>Retourne la liste des objets contenu dans le sac</returns>
        public List<Objet> selectionObjetsSac()
        {
            MySqlCommand command = new MySqlCommand();
            command.Connection = connexion;

            List<Objet> objets = new List<Objet>();

            // tentative de connexion à la base de données
            try
            {
                connexion.Open();

                command.CommandText = "SELECT * FROM objet";

                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {

                    string textReadNomObjet = reader["nom"].ToString();
                    int textReadIdObjet = Convert.ToInt32(reader["id"]);
                    string textReadType = reader["type_objet"].ToString();
                    double textReadValeurObjet = Convert.ToDouble(reader["valeur"]);
                    int textReadQuantiteObjet = Convert.ToInt32(reader["quantite"]);

                    Objet objetRecuperer = new Objet();

                    objetRecuperer.setNom(textReadNomObjet);
                    objetRecuperer.setIdObjet(textReadIdObjet);
                    objetRecuperer.setValeurObjet(textReadValeurObjet);
                    objetRecuperer.setTypeObjet(textReadType);
                    objetRecuperer.setQuantiteObjet(textReadQuantiteObjet);

                    objets.Add(objetRecuperer);

                }
                reader.Close();
                connexion.Close();

                return objets;
            }

            catch (Exception ex)
            {
                connexion.Close();
                return objets;
            }
        }

        /// <summary>
        /// Cette méthode permet de retourner un objet à l'aide de la base de données
        /// </summary>
        /// <param name=nom>Nom de l'objet</param>
        /// <returns>Retourne l'objet</returns>
        public Objet selectionObjet(string nom)
        {
            MySqlCommand command = new MySqlCommand();
            command.Connection = connexion;

            Objet objet = new Objet();

            // tentative de connexion à la base de données
            try
            {
                connexion.Open();

                command.CommandText = "SELECT DISTINCT * FROM objet WHERE nom='" + nom + "'";

                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int textReadIdObjet = Convert.ToInt32(reader["id"]);
                    string textReadType = reader["type_objet"].ToString();
                    int textReadValeurObjet = Convert.ToInt32(reader["valeur"]);
                    int textReadQuantiteObjet = Convert.ToInt32(reader["quantite"]);

                    objet.setNom(nom);
                    objet.setIdObjet(textReadIdObjet);
                    objet.setTypeObjet(textReadType);
                    objet.setValeurObjet(textReadValeurObjet);
                    objet.setQuantiteObjet(textReadQuantiteObjet);
                }
                reader.Close();
                connexion.Close();

                return objet;
            }

            catch (Exception ex)
            {
                connexion.Close();
                return objet;
            }
        }

        /// <summary>
        /// Cette méthode permet de retourner la liste des attaques à l'aide de la base de données
        /// </summary>
        /// <returns>Retourne la liste des attaques</returns>
        public List<Attaque> selectionListeAttaque()
        {
            MySqlCommand command = new MySqlCommand();
            command.Connection = connexion;

            List<Attaque> attaques = new List<Attaque>();

            // tentative de connexion à la base de données
            try
            {
                connexion.Open();

                command.CommandText = "SELECT DISTINCT * FROM attaque";

                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int textReadIdAttaque = Convert.ToInt32(reader["id"]);
                    string textReadNomAttaque = reader["nom_attaque"].ToString();
                    int textReadType = Convert.ToInt32(reader["id_type_attaque"]);
                    int textReadValeurAttaque = Convert.ToInt32(reader["degats"]);
                    int textReadPuissanceBaseAttaque = Convert.ToInt32(reader["puissance_base"]);
                    string textReadTypeAttaque = reader["type_attaque"].ToString();
                    string textReadPhysiqueSpecialeAttaque = reader["physique_ou_speciale"].ToString();
                    int textReadPPAttaque = Convert.ToInt32(reader["pp"]);
                    int textReadPPMaximum = Convert.ToInt32(reader["pp_maximum"]);
                    double textReadProbabiliteChangementStatut = Convert.ToDouble(reader["probabilite_changement_statut"]);

                    Attaque attaqueRecuperer = new Attaque();

                    attaqueRecuperer.setNom(textReadNomAttaque);
                    attaqueRecuperer.setId(textReadIdAttaque);
                    attaqueRecuperer.setIdTypeAttaque(textReadType);
                    attaqueRecuperer.setValeur(textReadValeurAttaque);
                    attaqueRecuperer.setPuissanceBase(textReadPuissanceBaseAttaque);
                    attaqueRecuperer.setTypeAttaque(textReadTypeAttaque);
                    attaqueRecuperer.setPhysiqueOuSpecialeAttaque(textReadPhysiqueSpecialeAttaque);
                    attaqueRecuperer.setPP(textReadPPAttaque);
                    attaqueRecuperer.setPPRestant(textReadPPAttaque);
                    attaqueRecuperer.setPPMaximum(textReadPPMaximum);
                    attaqueRecuperer.setProbabiliteChangementStatutPokemonAdverse(textReadProbabiliteChangementStatut);

                    attaques.Add(attaqueRecuperer);

                }
                reader.Close();
                connexion.Close();

                return attaques;
            }

            catch (Exception ex)
            {
                connexion.Close();
                return attaques;
            }
        }

        /// <summary>
        /// Cette méthode permet de retourner une attaque à l'aide de son id et de la base de données
        /// </summary>
        /// <param name=id>Id de l'objet</param>
        /// <returns>Retourne l'attaque cherché</returns>
        public Attaque selectionAttaqueId(int id)
        {
            MySqlCommand command = new MySqlCommand();
            command.Connection = connexion;

            Attaque attaque = new Attaque();

            // tentative de connexion à la base de données
            try
            {
                connexion.Open();

                command.CommandText = "SELECT DISTINCT * FROM attaque WHERE id ='" + id + "'";

                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    string textReadNom = reader["nom_attaque"].ToString();
                    int textReadType = Convert.ToInt32(reader["id_type_attaque"]);
                    int textReadValeurAttaque = Convert.ToInt32(reader["degats"]);
                    int textReadPuissanceBaseAttaque = Convert.ToInt32(reader["puissance_base"]);
                    string textReadTypeAttaque = reader["type_attaque"].ToString();
                    string textReadPhysiqueSpecialeAttaque = reader["physique_ou_speciale"].ToString();
                    int textReadPPAttaque = Convert.ToInt32(reader["pp"]);
                    int textReadPPMaximum = Convert.ToInt32(reader["pp_maximum"]);
                    double textReadProbabiliteChangementStatut = Convert.ToDouble(reader["probabilite_changement_statut"]);

                    attaque.setNom(textReadNom);
                    attaque.setId(id);
                    attaque.setIdTypeAttaque(textReadType);
                    attaque.setValeur(textReadValeurAttaque);
                    attaque.setPuissanceBase(textReadPuissanceBaseAttaque);
                    attaque.setTypeAttaque(textReadTypeAttaque);
                    attaque.setPhysiqueOuSpecialeAttaque(textReadPhysiqueSpecialeAttaque);
                    attaque.setPP(textReadPPAttaque);
                    attaque.setPPRestant(textReadPPAttaque);
                    attaque.setPPMaximum(textReadPPMaximum);
                    attaque.setProbabiliteChangementStatutPokemonAdverse(textReadProbabiliteChangementStatut);

                }
                reader.Close();
                connexion.Close();

                return attaque;
            }

            catch (Exception ex)
            {
                connexion.Close();
                return attaque;
            }
        }

        /// <summary>
        /// Cette méthode permet de retourner une attaque à l'aide de son nom et de la base de données
        /// </summary>
        /// <param name=nom>Nom de l'objet</param>
        /// <returns>Retourne l'attaque cherché</returns>
        public Attaque selectionAttaque(string nom)
        {
            MySqlCommand command = new MySqlCommand();
            command.Connection = connexion;

            Attaque attaque = new Attaque();

            // tentative de connexion à la base de données
            try
            {
                connexion.Open();

                command.CommandText = "SELECT DISTINCT * FROM attaque WHERE nom_attaque='" + nom + "'";

                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int textReadIdAttaque = Convert.ToInt32(reader["id"]);
                    int textReadType = Convert.ToInt32(reader["id_type_attaque"]);
                    int textReadValeurAttaque = Convert.ToInt32(reader["degats"]);
                    int textReadPuissanceBaseAttaque = Convert.ToInt32(reader["puissance_base"]);
                    string textReadTypeAttaque = reader["type_attaque"].ToString();
                    string textReadPhysiqueSpecialeAttaque = reader["physique_ou_speciale"].ToString();
                    int textReadPPAttaque = Convert.ToInt32(reader["pp"]);
                    int textReadPPMaximum = Convert.ToInt32(reader["pp_maximum"]);
                    double textReadProbabiliteChangementStatut = Convert.ToDouble(reader["probabilite_changement_statut"]);

                    attaque.setNom(nom);
                    attaque.setId(textReadIdAttaque);
                    attaque.setIdTypeAttaque(textReadType);
                    attaque.setValeur(textReadValeurAttaque);
                    attaque.setPuissanceBase(textReadPuissanceBaseAttaque);
                    attaque.setTypeAttaque(textReadTypeAttaque);
                    attaque.setPhysiqueOuSpecialeAttaque(textReadPhysiqueSpecialeAttaque);
                    attaque.setPP(textReadPPAttaque);
                    attaque.setPPRestant(textReadPPAttaque);
                    attaque.setPPMaximum(textReadPPMaximum);
                    attaque.setProbabiliteChangementStatutPokemonAdverse(textReadProbabiliteChangementStatut);
                }
                reader.Close();
                connexion.Close();

                return attaque;
            }

            catch (Exception ex)
            {
                connexion.Close();
                return null;
            }
        }

        /// <summary>
        /// Cette méthode permet de retourner un arraylist des pokémon starter contenant leur nom l'aide de la base de données
        /// </summary>
        /// <returns>Retourne un arraylist des pokémon starter contenant leur nom</returns>
        public ArrayList selectionStarter()
        {
            MySqlCommand command = new MySqlCommand();
            command.Connection = connexion;
            ArrayList test = new ArrayList();
            string pathCommandesStarter = AppDomain.CurrentDomain.BaseDirectory + "commandesStarter.txt";

            // tentative de connexion à la base de données
            try
            {
                connexion.Open();
                command.CommandText = "SELECT DISTINCT nom FROM pokemon WHERE no_id = 1 OR no_id = 4 OR no_id = 7";

                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    string textReadNom = reader["nom"].ToString();
                    test.Add(textReadNom);
                }
                reader.Close();
                connexion.Close();
                return test;
            }
            catch (Exception ex)
            {
                test.Add("");
                connexion.Close();
                return test;

            }
        }
    }
}
