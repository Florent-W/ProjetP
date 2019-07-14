using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MySql.Data.MySqlClient;


namespace ClassLibrary2
{
    /// <summary> 
    /// Classe permettant d'obtenir des personnages ayant des pokemons, des objets
    /// </summary>
    public class Personnage
    {
        private string m_nom;
        private int m_age;

        private List <Pokemon> pokemon_equipe = new List<Pokemon>();
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
        /// <param name=poke, age>Un pokémon</param>
        public void attraperPokemon(Pokemon poke)
        {
            poke.setPvRestant(poke.getPvRestant());
            pokemon_equipe.Add(poke);
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
        /// Cette méthode permet de retourner tous les pokemon de l'équipe du personnage
        /// </summary>
        /// <returns>Récupère la liste des pokémon du personnage</returns>
        public List<Pokemon> getPokemonEquipe()
        {
            return (List<Pokemon>) pokemon_equipe;
        }

    }

    /// <summary> 
    /// Classe Pokémon qui possède des attaques, un numéro dans le pokédex
    /// </summary>
    public class Pokemon
    {
        private int m_id;
        private int m_no_id_pokedex;
        private string m_nom;
        private string m_sexe;

        private int m_statistiques_pv;
        private int m_statistiques_attaque;
        private int m_statistiques_defense;
        private int m_statistiques_vitesse;
        private int m_statistiques_attaque_speciale;
        private int m_statistiques_defense_speciale;
        private double m_statistiques_precision = 1;
        private double m_statistiques_esquive = 1;
        private int m_niveau = 1;
        private int m_pv_restant;
        private string m_nature;
        private string m_type;
        private int m_niveau_chance_coup_critique = 1;
        private int m_experience = 0;
        private string m_courbe_experience;
        private int m_gain_experience; 

        private int m_base_pv;
        private int m_base_attaque;
        private int m_base_defense;
        private int m_base_vitesse;
        private int m_base_attaque_speciale;
        private int m_base_defense_speciale;

        private int m_iv_pv;
        private int m_iv_attaque;
        private int m_iv_defense;
        private int m_iv_vitesse;
        private int m_iv_attaque_speciale;
        private int m_iv_defense_speciale;

        private int m_ev_pv;
        private int m_ev_attaque;
        private int m_ev_defense;
        private int m_ev_vitesse;
        private int m_ev_attaque_speciale;
        private int m_ev_defense_speciale;

        private int m_gain_ev_pv;
        private int m_gain_ev_attaque;
        private int m_gain_ev_defense;
        private int m_gain_ev_vitesse;
        private int m_gain_ev_attaque_speciale;
        private int m_gain_ev_defense_speciale;

        private List<Attaque> m_liste_attaque = new List<Attaque>();

        private List<int> m_liste_id_attaque = new List<int>();

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

        public int getExperience()
        {
            return this.m_experience;
        }

        public string getTypeCourbeExperience()
        {
            return this.m_courbe_experience;
        }

        public int getGainExperiencePokemon()
        {
            return this.m_gain_experience;
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
        /// Cette méthode permet de récupérer l'attaque4 d'un pokémon
        /// </summary>
        /// <returns>Récupère l'attaque 4 du pokémon</returns>
        public Attaque getAttaque4()
        {
            return m_liste_attaque[3];
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

        public int getGainEvPv()
        {
            return m_gain_ev_pv;
        }

        public int getGainEvAttaque()
        {
            return m_gain_ev_attaque;
        }

        public int getGainEvDefense()
        {
            return m_gain_ev_defense;
        }

        public int getGainEvVitesse()
        {
            return m_gain_ev_vitesse;
        }

        public int getGainEvAttaqueSpeciale()
        {
            return m_gain_ev_attaque_speciale;
        }

        public int getGainEvDefenseSpeciale()
        {
            return m_gain_ev_defense_speciale;
        }

        public void setPvJoueur()
        {
            m_statistiques_pv = 200;
        }

        public void setPvRestant(int pvRestant)
        {
            m_pv_restant = pvRestant;
        }

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


        public Pokemon setPokemon()
        {
            List<Pokemon> liste_pokemon = pokemon.selectionListePokemon();
            Random rand = new Random();

            int index = rand.Next(liste_pokemon.Count);

            return liste_pokemon[index];
        }


        public void setBasePvPokemon(int basePv)
        {
            this.m_base_pv = basePv;
        }

        public void setIdPokemon(Pokemon poke)
        {
            this.m_id = pokemon.selectionIdPokemon(poke);
        }

        public void setIdPokemonAvecId(int id)
        {
            this.m_id = id;
        }

        public void setNoPokedexPokemon(int no_id_pokedex)
        {
            this.m_no_id_pokedex = no_id_pokedex;
        }

        public int setPv(Pokemon p1)
        {

            ArrayList pv = pokemon.selectionPvPokemon(p1.getNom().ToString());
            Random rand = new Random();
            int index = rand.Next(pv.Count);
            return Convert.ToInt32(pv[index]);
        }

        public void setPokemon(string nom)
        {
            this.m_nom = nom;
        }

        public void setSexe(string sexe)
        {
            this.m_sexe = sexe;
        }

        public void setSexeRand()
        {
            List<string> liste_sexe = new List<string>();
            Random rand = new Random();
           
            liste_sexe.Add("Masculin");
            liste_sexe.Add("Feminin");

            int index = rand.Next(liste_sexe.Count);

            this.m_sexe = liste_sexe[index];
        }

        public void setNature(string nature)
        {
            this.m_nature = nature;
        }

        public void setType(string type)
        {
            this.m_type = type;
        }

        public void setNiveauCritique(int niveauCritique)
        {
            this.m_niveau_chance_coup_critique = niveauCritique;
        }

        public void setExperience(int experience)
        {
            this.m_experience = experience;
        }

        public void setTypeCourbeExperience(string typeCourbeExperience)
        {
            this.m_courbe_experience = typeCourbeExperience;
        }

        public void setGainExperiencePokemon(int gainExperience)
        {
            this.m_gain_experience = gainExperience;
        }

        public Pokemon setPokemonStarter(string nomPokemon)
        {
            return pokemon.selectionPokemonStatsStarter(nomPokemon);
        }

        public void setIdAttaque1(int id)
        {
            this.m_liste_id_attaque.Add(id);
        }

        public void setIdAttaque2(int id)
        {
            this.m_liste_id_attaque.Add(id);
        }

        public void setIdAttaque3(int id)
        {
            this.m_liste_id_attaque.Add(id);
        }

        public void setIdAttaque4(int id)
        {
            this.m_liste_id_attaque.Add(id);
        }

        public void setAttaque1(Attaque attaque)
        {
            this.m_liste_attaque.Add(attaque);
        }

        public void setAttaque2(Attaque attaque)
        {
            this.m_liste_attaque.Add(attaque);
        }

        public void setAttaque3(Attaque attaque)
        {
            this.m_liste_attaque.Add(attaque);
        }

        public void setAttaque4(Attaque attaque)
        {
            this.m_liste_attaque.Add(attaque);
        }

        public decimal getProbabiliteReussiteAttaque(Pokemon pokemonOffensif, Pokemon pokemonDefenseur, Attaque attaqueLancer)
        {
            decimal probabiliteReussite = (decimal)attaqueLancer.getPrecisionAttaque() * decimal.Divide((decimal)pokemonOffensif.getStatistiquesPrecisionPokemon(), (decimal)pokemonDefenseur.getStatistiquesEsquivePokemon());
            return probabiliteReussite;
        }

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

        public int attaqueWithNomAttaque(Pokemon pokemonOffensif, Pokemon pokemonDefenseur, Attaque attaque, double bonusCritique)
        {
            for (int i = 0; i < pokemonOffensif.getListeAttaque().Count; i++)
            {
                if (pokemonOffensif.getListeAttaque()[i] == attaque)
                {
                    pokemonOffensif.getListeAttaque()[i].setPPRestant(pokemonOffensif.getListeAttaque()[i].getPPRestant() - 1);
                }                
            }
           
            int nbDegats = (int)this.calculDegatsAttaque(attaque, pokemonOffensif, pokemonDefenseur, bonusCritique);
            pokemonDefenseur.m_pv_restant = pokemonDefenseur.m_pv_restant - nbDegats;

            return nbDegats;
        }

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

        public void setPrecision(double precisionPokemon)
        {
            this.m_statistiques_precision = precisionPokemon;
        }

        public void setEsquive(double esquivePokemon)
        {
            this.m_statistiques_esquive = esquivePokemon;
        }

        public void setNiveau(int niveauPokemon)
        {
            this.m_niveau = niveauPokemon;
        }

        public void setBaseAttaque(int baseAttaque)
        {
            this.m_base_attaque = baseAttaque;
        }

        public void setBaseDefense(int baseDefense)
        {
            this.m_base_defense = baseDefense;
        }

        public void setBaseVitesse(int baseVitesse)
        {
            this.m_base_vitesse = baseVitesse;
        }

        public void setBaseAttaqueSpeciale(int baseAttaqueSpeciale)
        {
            this.m_base_attaque_speciale = baseAttaqueSpeciale;
        }

        public void setBaseDefenseSpeciale(int baseDefenseSpeciale)
        {
            this.m_base_defense_speciale = baseDefenseSpeciale;
        }

        public void setIvPv(int ivPv)
        {
            this.m_iv_pv = ivPv;
        }

        public void setIvAttaque(int ivAttaque)
        {
            this.m_iv_attaque = ivAttaque;
        }

        public void setIvDefense(int ivDefense)
        {
            this.m_iv_defense = ivDefense;
        }

        public void setIvVitesse(int ivVitesse)
        {
            this.m_iv_vitesse = ivVitesse;
        }

        public void setIvAttaqueSpeciale(int ivAttaqueSpeciale)
        {
            this.m_iv_attaque_speciale = ivAttaqueSpeciale;
        }

        public void setIvDefenseSpeciale(int ivDefenseSpeciale)
        {
            this.m_iv_defense_speciale = ivDefenseSpeciale;
        }

        public void setEvPv(int evPv)
        {
            this.m_ev_pv = evPv;
        }

        public void setEvAttaque(int evAttaque)
        {
            this.m_ev_attaque = evAttaque;
        }

        public void setEvDefense(int evDefense)
        {
            this.m_ev_defense = evDefense;
        }

        public void setEvVitesse(int evVitesse)
        {
            this.m_ev_vitesse = evVitesse;
        }

        public void setEvAttaqueSpeciale(int evAttaqueSpeciale)
        {
            this.m_ev_attaque_speciale = evAttaqueSpeciale;
        }

        public void setEvDefenseSpeciale(int evDefenseSpeciale)
        {
            this.m_ev_defense_speciale = evDefenseSpeciale;
        }

        public void setGainEvPv(int gainEvPv)
        {
            this.m_gain_ev_pv = gainEvPv;
        }

        public void setGainEvAttaque(int gainEvAttaque)
        {
            this.m_gain_ev_attaque = gainEvAttaque;
        }

        public void setGainEvDefense(int gainEvDefense)
        {
            this.m_gain_ev_defense = gainEvDefense;
        }

        public void setGainEvVitesse(int gainEvVitesse)
        {
            this.m_gain_ev_vitesse = gainEvVitesse;
        }

        public void setGainEvAttaqueSpeciale(int gainEvAttaqueSpeciale)
        {
            this.m_gain_ev_attaque_speciale = gainEvAttaqueSpeciale;
        }

        public void setGainEvDefenseSpeciale(int gainEvDefenseSpeciale)
        {
            this.m_gain_ev_defense_speciale = gainEvDefenseSpeciale;
        }

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

            int resultat = (int) degats;

            return resultat;
        }

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

        public int getExperiencePokemonCourbeRapide()
        {
            double experience = Math.Round(0.8 * Math.Pow(this.m_niveau, 3), MidpointRounding.AwayFromZero);
            return (int)experience;
        }

        public int getExperiencePokemonCourbeMoyenne()
        {
            double experience = Math.Round(Math.Pow(this.m_niveau, 3), MidpointRounding.AwayFromZero);
            return (int)experience;
        }

        public int getExperiencePokemonCourbeParabolique()
        {
            double experience = Math.Round(1.2 * Math.Pow(this.m_niveau, 3) - 15 * Math.Pow(this.m_niveau, 2) + (100 * this.m_niveau) - 140, MidpointRounding.AwayFromZero);
            if(experience < 0)
            {
                experience = 0;
            }

            return (int)experience;
        }

        public int getExperiencePokemonCourbeLente()
        {
            double experience = Math.Round(1.25 * Math.Pow(this.m_niveau, 3), MidpointRounding.AwayFromZero);
            return (int)experience;
        }

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

        public int getExperiencePokemonProchainNiveauCourbeRapide()
        {
            double niveauPokemon = this.m_niveau + 1;
            double experienceProchainNiveau = Math.Round(0.8 * Math.Pow(niveauPokemon, 3), MidpointRounding.AwayFromZero);

            return (int)experienceProchainNiveau;
        }

        public int getExperiencePokemonProchainNiveauCourbeMoyenne()
        {
            double niveauPokemon = this.m_niveau + 1;
            double experienceProchainNiveau = Math.Round(Math.Pow(niveauPokemon, 3), MidpointRounding.AwayFromZero);
            return (int)experienceProchainNiveau;
        }

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

        public int getExperiencePokemonProchainNiveauCourbeLente()
        {
            double niveauPokemon = this.m_niveau + 1;
            double experienceProchainNiveau = Math.Round(1.25 * Math.Pow(niveauPokemon, 3), MidpointRounding.AwayFromZero);
            return (int)experienceProchainNiveau;
        }

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

        public void attaque(Pokemon pokemon)
        {
            pokemon.m_pv_restant = pokemon.m_pv_restant - 20;
        }

        public string retournerTypePokemon(int numeroType)
        {
            type.Add("Plante");
            type.Add("Feu");

            return type.ToString();
        }

        public override string ToString()
        {
            return type.ToString();
        }

    }

    /// <summary> 
    /// Classe attaque
    /// </summary>
    public class Attaque
    {
        private int m_id_attaque;
        private string m_nom;

        private int m_valeur;
        private int m_puissance_base;
        private double m_precision = 1;
        private int m_priorite_attaque = 0;
        private int m_pp;
        private int m_pp_restant;
        private int m_pp_maximum;

        private int m_id_type_attaque;
        private string m_type_attaque;
        private string m_physique_speciale_attaque;

        public int getId()
        {
            return m_id_attaque;
        }

        public string getNom()
        {
            return m_nom;
        }

        public int getValeur()
        {
            return m_valeur;
        }

        public int getPuissanceBase()
        {
            return m_puissance_base;
        }

        public double getPrecisionAttaque()
        {
            return m_precision;
        }

        public int getPrioriteAttaque()
        {
            return m_priorite_attaque;
        }

        public int getPP()
        {
            return m_pp;
        }

        public int getPPRestant()
        {
            return m_pp_restant;
        }

        public int getPPMaximum()
        {
            return m_pp_maximum;
        }

        public int getIdTypeAttaque()
        {
            return m_id_type_attaque;
        }

        public string getTypeAttaque()
        {
            return m_type_attaque;
        }

        public string getPhysiqueOuSpécialeAttaque()
        {
            return m_physique_speciale_attaque;
        }

        public void setId(int id)
        {
            this.m_id_attaque = id;
        }

        public void setNom(string nom)
        {
            this.m_nom = nom;
        }

        public void setValeur(int valeur)
        {
            this.m_valeur = valeur;
        }

        public void setPuissanceBase(int puissanceBase)
        {
            this.m_puissance_base = puissanceBase;
        }

        public void setPrecisionAttaque(double precisionAttaque)
        {
            this.m_precision = precisionAttaque;
        }

        public void setPrioriteAttaque(int prioriteAttaque)
        {
            this.m_priorite_attaque = prioriteAttaque;
        }

        public void setPP(int ppAttaque)
        {
            this.m_pp = ppAttaque;
        }

        public void setPPRestant(int ppRestant)
        {
            this.m_pp_restant = ppRestant;
        }

        public void setPPMaximum(int ppMaximum)
        {
            this.m_pp_maximum = ppMaximum;
        }

        public void setIdTypeAttaque(int id_type_attaque)
        {
            this.m_id_type_attaque = id_type_attaque;
        }

        public void setTypeAttaque(string type_attaque)
        {
            this.m_type_attaque = type_attaque;
        }

        public void setPhysiqueOuSpecialeAttaque(string type_physique_ou_speciale_attaque)
        {
            this.m_physique_speciale_attaque = type_physique_ou_speciale_attaque;
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
    public class Objet
    {
        private int m_id;
        private string m_nom;
        private string m_type_objet;
        private int m_quantite;
        private int m_valeur;
        
        public string getNom()
        {
            return m_nom;
        }

        public void setNom(string nom)
        { 
                this.m_nom = nom;
        }

        public int getIdObjet()
        {
            return m_id;
        }

        public void setIdObjet(int id)
        {
            this.m_id = id;
        }

        public string getTypeObjet()
        {
            return m_type_objet;
        }

        public void setTypeObjet(string type_objet)
        {
            this.m_type_objet = type_objet;
        }

        public int getQuantiteObjet()
        {
            return m_quantite;
        }

        public void setQuantiteObjet(int quantiteObjet)
        {
            this.m_quantite = quantiteObjet;
        }

        public int getValeurObjet()
        {
            return m_valeur;
        }

        public void setValeurObjet(int valeurObjet)
        {
            this.m_valeur = valeurObjet;
        }
        
        public void Soin(Pokemon poke, Objet objet)
        {
            if (objet.getTypeObjet() == "Soin" && objet.getQuantiteObjet() > 0)
            {
                if (poke.getPvRestant() + objet.getValeurObjet() < poke.getPv())
                {
                    poke.setPvRestant(poke.getPvRestant() + objet.getValeurObjet());
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


                /* Ecriture de l'id du visiteur et de la date présente dans la fiche de frais dans un fichier de log. */
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

                /* Ecriture de l'id du visiteur et de la date présente dans la fiche de frais dans un fichier de log. */
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

                /* Ecriture de l'id du visiteur et de la date présente dans la fiche de frais dans un fichier de log. */
                while (reader.Read())
                {
                    int textReadBasePvPokemon = Convert.ToInt32(reader["base_pv"]);
                    string textReadNomPokemon = reader["nom"].ToString();
                    int textReadIdPokemon = Convert.ToInt32(reader["Id"]);
                    int textReadNoIdPokedex = Convert.ToInt32(reader["no_id"]);
                    int textReadIdAttaque1 = Convert.ToInt32(reader["id_attaque_1"]);
                    int textReadIdAttaque2 = Convert.ToInt32(reader["id_attaque_2"]);
                    int textReadIdAttaque3 = Convert.ToInt32(reader["id_attaque_3"]);
                    int textReadIdAttaque4 = Convert.ToInt32(reader["id_attaque_4"]);
                    int textReadIdType = Convert.ToInt32(reader["id_type"]);
                    int textReadNiveau = Convert.ToInt32(reader["Niveau"]);
                    string textReadNature = reader["nature"].ToString();
                    string textReadType = reader["type"].ToString();
                    string textReadCourbeExperience = reader["courbe_experience"].ToString();
                    int textReadGainExperience = Convert.ToInt32(reader["gain_experience"]);

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
                    poke.setSexeRand();
                    poke.setIdAttaque1(textReadIdAttaque1);
                    poke.setIdAttaque2(textReadIdAttaque2);
                    poke.setIdAttaque3(textReadIdAttaque3);
                    poke.setIdAttaque4(textReadIdAttaque4);
                    poke.setNiveau(textReadNiveau);
                    poke.setNature(textReadNature);
                    poke.setType(textReadType);
                    poke.setTypeCourbeExperience(textReadCourbeExperience);
                    poke.setGainExperiencePokemon(textReadGainExperience);
                    poke.getExperiencePokemon();

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

                /* Ecriture de l'id du visiteur et de la date présente dans la fiche de frais dans un fichier de log. */
                while (reader.Read())
                {
                    int textReadBasePvPokemon = Convert.ToInt32(reader["statistiques_pv"]);
                    string textReadNomPokemon = reader["nom"].ToString();
                    int textReadIdPokemon = Convert.ToInt32(reader["Id"]);
                    int textReadNoIdPokedex = Convert.ToInt32(reader["no_id"]);
                    int textReadIdAttaque1 = Convert.ToInt32(reader["id_attaque_1"]);
                    int textReadIdAttaque2 = Convert.ToInt32(reader["id_attaque_2"]);
                    int textReadIdAttaque3 = Convert.ToInt32(reader["id_attaque_3"]);
                    int textReadIdAttaque4 = Convert.ToInt32(reader["id_attaque_4"]);
                    int textReadIdType = Convert.ToInt32(reader["id_type"]);
                    int textReadNiveau = Convert.ToInt32(reader["Niveau"]);
                    string textReadNature = reader["nature"].ToString();
                    string textReadType = reader["type"].ToString();
                    string textReadCourbeExperience = reader["courbe_experience"].ToString();
                    int textReadGainExperience = Convert.ToInt32(reader["gain_experience"]);

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
                    poke.setSexeRand();
                    poke.setIdAttaque1(textReadIdAttaque1);
                    poke.setIdAttaque2(textReadIdAttaque2);
                    poke.setIdAttaque3(textReadIdAttaque3);
                    poke.setIdAttaque4(textReadIdAttaque4);
                    poke.setNiveau(textReadNiveau);
                    poke.setNature(textReadNature);
                    poke.setType(textReadType);
                    poke.setTypeCourbeExperience(textReadCourbeExperience);
                    poke.setGainExperiencePokemon(textReadGainExperience);
                    poke.getExperiencePokemon();

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

        public Pokemon selectionPokemonStatsStarter(string nomPokemon)
        {
            MySqlCommand command = new MySqlCommand();
            command.Connection = connexion;

            // string pathCommandesStarter = AppDomain.CurrentDomain.BaseDirectory + "commandesStarter1.txt";

            Pokemon poke = new Pokemon();

            // tentative de connexion à la base de données
            try
            {
                connexion.Open();

                command.CommandText = "SELECT * FROM pokemon WHERE (Id = 1 OR Id = 4 OR Id = 7) AND nom='" + nomPokemon + "'";

                MySqlDataReader reader = command.ExecuteReader();

                /* Ecriture de l'id du visiteur et de la date présente dans la fiche de frais dans un fichier de log. */
                while (reader.Read())
                {
                    int textReadBasePvPokemon = Convert.ToInt32(reader["base_pv"]);
                    string textReadNomPokemon = reader["nom"].ToString();
                    int textReadIdPokemon = Convert.ToInt32(reader["Id"]);
                    int textReadNoIdPokemon = Convert.ToInt32(reader["no_id"]);
                    int textReadIdAttaque1 = Convert.ToInt32(reader["id_attaque_1"]);
                    int textReadIdAttaque2 = Convert.ToInt32(reader["id_attaque_2"]);
                    int textReadIdAttaque3 = Convert.ToInt32(reader["id_attaque_3"]);
                    int textReadIdAttaque4 = Convert.ToInt32(reader["id_attaque_4"]);
                    int textReadNiveau = Convert.ToInt32(reader["Niveau"]);
                    string textReadNature = reader["nature"].ToString();
                    string textReadType = reader["type"].ToString();
                    string textReadCourbeExperience = reader["courbe_experience"].ToString();
                    int textReadGainExperience = Convert.ToInt32(reader["gain_experience"]);

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

                    // System.IO.File.AppendAllText(pathCommandesStarter, textReadIdAttaque1 + " ");

                    poke.setPokemon(textReadNomPokemon);
                    poke.setIdPokemonAvecId(textReadIdPokemon);
                    poke.setNoPokedexPokemon(textReadNoIdPokemon);
                    poke.setSexeRand();
                    poke.setIdAttaque1(textReadIdAttaque1);
                    poke.setIdAttaque2(textReadIdAttaque2);
                    poke.setIdAttaque3(textReadIdAttaque3);
                    poke.setIdAttaque4(textReadIdAttaque4);
                    poke.setNiveau(textReadNiveau);
                    poke.setNature(textReadNature);
                    poke.setType(textReadType);
                    poke.setTypeCourbeExperience(textReadCourbeExperience);
                    poke.setGainExperiencePokemon(textReadGainExperience);
                    poke.getExperiencePokemon();

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

                /* Ecriture de l'id du visiteur et de la date présente dans la fiche de frais dans un fichier de log. */
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

                /* Ecriture de l'id du visiteur et de la date présente dans la fiche de frais dans un fichier de log. */
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

                /* Ecriture de l'id du visiteur et de la date présente dans la fiche de frais dans un fichier de log. */
                while (reader.Read())
                {

                    string textReadNomObjet = reader["nom"].ToString();
                    int textReadIdObjet = Convert.ToInt32(reader["id"]);
                    string textReadType = reader["type_objet"].ToString();
                    int textReadValeurObjet = Convert.ToInt32(reader["valeur"]);
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

                /* Ecriture de l'id du visiteur et de la date présente dans la fiche de frais dans un fichier de log. */
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

                /* Ecriture de l'id du visiteur et de la date présente dans la fiche de frais dans un fichier de log. */
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

                /* Ecriture de l'id du visiteur et de la date présente dans la fiche de frais dans un fichier de log. */
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

                /* Ecriture de l'id du visiteur et de la date présente dans la fiche de frais dans un fichier de log. */
                while (reader.Read())
                {
                    int textReadIdAttaque = Convert.ToInt32(reader["id"]);
                    int textReadType = Convert.ToInt32(reader["id_type_attaque"]);
                    int textReadValeurAttaque = Convert.ToInt32(reader["degats"]);
                    int textReadPuissanceBaseAttaque = Convert.ToInt32(reader["puissance_base"]);
                    string textReadPhysiqueSpecialeAttaque = reader["physique_ou_speciale"].ToString();
                    int textReadPPAttaque = Convert.ToInt32(reader["pp"]);
                    int textReadPPMaximum = Convert.ToInt32(reader["pp_maximum"]);

                    attaque.setNom(nom);
                    attaque.setId(textReadIdAttaque);
                    attaque.setIdTypeAttaque(textReadType);
                    attaque.setValeur(textReadValeurAttaque);
                    attaque.setPuissanceBase(textReadPuissanceBaseAttaque);
                    attaque.setPhysiqueOuSpecialeAttaque(textReadPhysiqueSpecialeAttaque);
                    attaque.setPP(textReadPPAttaque);
                    attaque.setPPRestant(textReadPPAttaque);
                    attaque.setPPMaximum(textReadPPMaximum);
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

                /* Ecriture de l'id du visiteur et de la date présente dans la fiche de frais dans un fichier de log. */
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
