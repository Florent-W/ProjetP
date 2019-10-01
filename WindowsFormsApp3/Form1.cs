using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Threading;
using System.Runtime.Serialization;
using System.Windows.Forms;


namespace WindowsFormsApp3
{
    
    public partial class frmSaisiesBoutons : Form
    {
        public class ButtonSansBordure : Button
        {
            protected override bool ShowFocusCues
            {
                get
                {
                    return false;
                }
            }
        }

        ClassLibrary2.Jeu jeu = new ClassLibrary2.Jeu(); // Parametres du jeu (attaque, pokemon)
        ClassLibrary2.Personnage Joueur = new ClassLibrary2.Personnage();
        ClassLibrary2.Pokemon pokemon = new ClassLibrary2.Pokemon();
        ClassLibrary2.accesDonnees db = new ClassLibrary2.accesDonnees();

        ClassLibrary2.Pokemon pokemonJoueurStarter = new ClassLibrary2.Pokemon();

        ClassLibrary2.Pokemon premierPokemonStarter = new ClassLibrary2.Pokemon();
        ClassLibrary2.Pokemon deuxiemePokemonStarter = new ClassLibrary2.Pokemon();
        ClassLibrary2.Pokemon troisiemePokemonStarter = new ClassLibrary2.Pokemon();
    
        ClassLibrary2.Pokemon pokemonJoueurSelectionner = new ClassLibrary2.Pokemon();

        ButtonSansBordure btn_choix_garçon = new ButtonSansBordure();
        ButtonSansBordure btn_choix_fille = new ButtonSansBordure();

        ClassLibrary2.Pokemon pokemonJoueur_2 = new ClassLibrary2.Pokemon();
        ClassLibrary2.Attaque attaqueLancerPokemon = new ClassLibrary2.Attaque();
        ClassLibrary2.Attaque attaqueLancerAdversaire = new ClassLibrary2.Attaque();

        int compteur = 0, compteurAdversaire = 0, compteurExperience = 0, nbDegats = 0, nombrePokemonAvantChargementSauvegarde = 0;
        int nombreMouvementsBall = -1, statutPokemonPerdPvJoueur = 0, statutPokemonPerdPvAdversaire = 0;
        double compteurAnimationCapturePartie1 = 0, compteurAnimationCapturePartie2 = 0, compteurAnimationCapturePartie3 = 0, compteurAnimationCapturePartie4 = 0, compteurAnimationCapturePartie5 = 0, compteurAnimationCapturePartie6 = 0, compteurAnimationCapturePartie7 = 0, compteurAnimationCapturePartie8 = 0;
        int nbPvGagner, statistiquesAttaqueGagner, statistiquesDefenseGagner, statistiquesVitesseGagner, statistiquesAttaqueSpecialeGagner, statistiquesDefenseSpecialeGagner, nombreTourStatut = 0, nombreTourStatutAdversaire = 0, nombreTourStatutAEffectuer = 0, nombreTourStatutAEffectuerAdversaire = 0, nombreTourSommeil = 0, nombreTourSommeilAdversaire = 0;
        bool gagnePvPokemonJoueur = false, pokemonJoueurAttaquePremier = true, reussiteAttaque = false, changement_pokemon = false, changementPokemonPokemonKo = false, showStatistiquesAugmenter = false, showStatistiquesNiveauSuivant = false, changementStatutPokemon = false, changementStatutAdversaire = false, reussiteAttaqueParalyse = false, reussiteAttaqueParalyseAdversaire = false, reussiteAttaqueGel = false, reussiteAttaqueGelAdversaire = false, reussiteAttaqueSommeil = false, reussiteAttaqueSommeilAdversaire = false;
        double bonusCritique = 1;

        Bitmap DrawAreaPokemonJoueur, DrawAreaPokemonAdversaire, DrawAreaExperiencePokemonJoueur;

        PictureBox[] pictureBoxPokemon = new PictureBox[6];
        PictureBox pictureBoxPokeball = new PictureBox();
        PictureBox pictureBoxCurseurPokemonStarter = new PictureBox();
        PictureBox pictureBoxCurseurChoixSexe = new PictureBox();
        Label[] label_pokemon = new Label[6];
        Label[] label_pv_pokemon = new Label[6];
        RadioButton[] radioBtn_pokemon = new RadioButton[6];

        // ClassLibrary2.Objet objet = new ClassLibrary2.Objet();

        public void rafraichirBarreViePokemonJoueur1()
        {
            Graphics g;

            g = Graphics.FromImage(DrawAreaPokemonJoueur);

            System.Drawing.SolidBrush fillGreen = new System.Drawing.SolidBrush(Color.Green);
            System.Drawing.SolidBrush fillRed = new System.Drawing.SolidBrush(Color.Red);
            System.Drawing.SolidBrush fillYellow = new System.Drawing.SolidBrush(Color.FromArgb(248, 222, 125));

            Pen black = new Pen(Color.Black);

            g.DrawRectangle(black, 0, 0, 100, 15);

            pictureBoxBarreViePokemonJoueur.Image = DrawAreaPokemonJoueur;

            if (pokemonJoueurSelectionner.getPvRestant() >= pokemonJoueurSelectionner.getPv() / 2)
            {
                g.Clear(SystemColors.Control);
                g.DrawRectangle(black, 0, 0, 100, 15);
                g.FillRectangle(fillGreen, 0, 0, (100 * pokemonJoueurSelectionner.getPvRestant()) / pokemonJoueurSelectionner.getPv(), 15);
                pictureBoxBarreViePokemonJoueur.Image = DrawAreaPokemonJoueur;

            }
            else if (pokemonJoueurSelectionner.getPvRestant() < pokemonJoueurSelectionner.getPv() / 2 && pokemonJoueurSelectionner.getPvRestant() >= pokemonJoueurSelectionner.getPv() / 5)
            {
                g.Clear(SystemColors.Control);
                g.DrawRectangle(black, 0, 0, 100, 15);
                g.FillRectangle(fillYellow, 0, 0, (100 * pokemonJoueurSelectionner.getPvRestant()) / pokemonJoueurSelectionner.getPv(), 15);
                pictureBoxBarreViePokemonJoueur.Image = DrawAreaPokemonJoueur;
            }
            else if (pokemonJoueurSelectionner.getPvRestant() < pokemonJoueurSelectionner.getPv() / 5 && pokemonJoueurSelectionner.getPvRestant() > 0)
            {
                g.Clear(SystemColors.Control);
                g.DrawRectangle(black, 0, 0, 100, 15);
                g.FillRectangle(fillRed, 0, 0, (100 * pokemonJoueurSelectionner.getPvRestant()) / pokemonJoueurSelectionner.getPv(), 15);
                pictureBoxBarreViePokemonJoueur.Image = DrawAreaPokemonJoueur;

            }

            else
            {
                g.Clear(SystemColors.Control);
                g.DrawRectangle(black, 0, 0, 100, 15);
                pictureBoxBarreViePokemonJoueur.Image = DrawAreaPokemonJoueur;
            }

            g.Dispose();
        }

        public void rafraichirBarreViePokemonJoueur()
        {
            if (statutPokemonPerdPvJoueur == 0)
            {
                if (gagnePvPokemonJoueur != true)
                {
                    for (int i = 0; i <= Joueur.getPokemonEquipe().Count - 1; i++)
                    {
                        if (pokemonJoueurSelectionner == Joueur.getPokemonEquipe()[i])
                        {
                            if (pokemon.getPvRestant() > 0)
                            {
                                if (pokemon.getListeAttaque().Count > 0 && pokemon.getAttaque1().getNom() != "default")
                                {
                                    if (nombreTourSommeilAdversaire > nombreTourStatutAEffectuerAdversaire && pokemon.getStatutPokemon() == "Sommeil")
                                    {
                                        textBox1.Text += pokemon.getNom() + " adverse se réveille" + Environment.NewLine;
                                        pokemon.setStatutPokemon("Normal");
                                        pictureBoxStatutPokemonCombatAdversaire.Image = null;
                                        nombreTourSommeilAdversaire = 0;
                                        nombreTourStatutAEffectuerAdversaire = 0;
                                    }
                                    attaqueLancerAdversaire = pokemon.attaqueAdversaire(pokemon, pokemonJoueurSelectionner);

                                    if (attaqueLancerAdversaire != null)
                                    {
                                        changementStatutPokemon = pokemon.getAttaqueChangementStatutPokemonAdverseReussi(attaqueLancerAdversaire);
                                        reussiteAttaque = pokemon.getReussiteAttaque(pokemonJoueurSelectionner.getProbabiliteReussiteAttaque(pokemon, pokemonJoueurSelectionner, attaqueLancerAdversaire));
                                        bonusCritique = pokemonJoueurSelectionner.getCoupCritique(pokemon.getProbabiliteCoupCritique(pokemon));
                                        nbDegats = pokemon.attaqueWithNomAttaque(pokemon, pokemonJoueurSelectionner, attaqueLancerAdversaire, bonusCritique, changementStatutPokemon, ref nombreTourStatut, ref reussiteAttaqueParalyseAdversaire, ref reussiteAttaqueGelAdversaire, ref nombreTourSommeilAdversaire);

                                        if (pokemon.getStatutPokemon() != "Sommeil")
                                        {
                                            if (reussiteAttaque == true)
                                            {
                                                textBox1.Text += Environment.NewLine + pokemon.getNom() + " adverse lance " + attaqueLancerAdversaire.getNom() + Environment.NewLine;

                                                if (pokemon.getStatutPokemon() != "Paralysie" || (pokemon.getStatutPokemon() == "Paralysie" && reussiteAttaqueParalyseAdversaire == true))
                                                {
                                                    if (pokemon.getStatutPokemon() != "Gelé" || (pokemon.getStatutPokemon() == "Gelé" && reussiteAttaqueGelAdversaire == true))
                                                    {

                                                        if (bonusCritique == 1.5)
                                                        {
                                                            textBox1.Text += "Coup Critique" + Environment.NewLine;
                                                            bonusCritique = 1;
                                                        }

                                                        if (pokemon.getEfficaciteAttaque(attaqueLancerAdversaire, pokemonJoueurSelectionner) != 1)
                                                        {
                                                            textBox1.Text += pokemon.getEfficaciteAttaqueTexte(pokemon.getEfficaciteAttaque(attaqueLancerAdversaire, pokemonJoueurSelectionner)) + Environment.NewLine;
                                                        }

                                                        if (reussiteAttaqueGelAdversaire == true)
                                                        {

                                                            textBox1.Text += pokemon.getNom() + " adverse redevient normal" + Environment.NewLine;
                                                            pokemon.setStatutPokemon("Normal");
                                                            pictureBoxStatutPokemonCombatAdversaire.Image = null;
                                                        }

                                                       

                                                        if (changementStatutPokemon == true)
                                                        {
                                                            string statutPokemon = pokemonJoueurSelectionner.getStatutPokemon();
                                                            if (statutPokemon != "Normal")
                                                            {
                                                                try
                                                                {
                                                                    Bitmap pngChangementStatutPokemon = new Bitmap(AppDomain.CurrentDomain.BaseDirectory + "\\Images\\Statut\\" + statutPokemon + ".png");
                                                                    pictureBoxStatutPokemonCombatJoueur.Image = pngChangementStatutPokemon;
                                                                }
                                                                catch
                                                                {
                                                                    MessageBox.Show("L'image du statut du pokémon n'a pas pu être chargée. Veuillez vérifier que celle-ci est bien présente dans le répertoire.", "Vérification de l'image du statut du pokémon", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                                }
                                                            }

                                                            changementStatutPokemon = false;
                                                        }

                                                        // textBox1.Text += pokemon.getNom() + " adverse a fait " + nbDegats + " dégâts " + Environment.NewLine;
                                                        // textBox1.Text += pokemon.getEfficaciteAttaqueTexte(pokemon.getEfficaciteAttaque(attaqueLancer, pokemonJoueurSelectionner)) + Environment.NewLine; 

                                                    }
                                                    else
                                                    {
                                                        textBox1.Text += pokemon.getNom() + " adverse est gelé. Il ne peut pas attaquer" + Environment.NewLine;
                                                    }
                                                }

                                                else
                                                {
                                                    textBox1.Text += pokemon.getNom() + " adverse est paralysé. Il ne peut pas attaquer" + Environment.NewLine;
                                                }
                                            }
                                            else
                                            {
                                                textBox1.Text += pokemon.getNom() + " rate son attaque" + Environment.NewLine;
                                            }
                                        }
                                        else
                                        {
                                            if (nombreTourStatutAEffectuerAdversaire == 0)
                                            {
                                                nombreTourStatutAEffectuerAdversaire = pokemon.getNombreTourSommeilAEffectuer();
                                            }
                                            textBox1.Text += pokemon.getNom() + " adverse est endormi. Il ne peut pas attaquer" + Environment.NewLine;
                                            nombreTourSommeilAdversaire++;

                                        }
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Le pokemon n'a aucune attaque", "Vérification des attaques", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }


                            }

                        }
                    }


                }
                else
                {
                    pokemonJoueurAttaquePremier = true;
                }
            }

            else if (statutPokemonPerdPvJoueur == 1)
            {
                statutPokemonPerdPvJoueur = 2;
            }

            if (pokemonJoueurAttaquePremier == true)
            {
                btn_attaque1.Enabled = false;
                btn_attraper.Enabled = false;
                btn_soigner.Enabled = false;
                btn_changement_pokemon.Enabled = false;
            }

            timerBarrePokemonJoueur.Start();
        }

        public void rafraichirLabelViePokemonEquipe()
        {
            for (int i = 0; i <= Joueur.getPokemonEquipe().Count - 1; i++)
            {
                if (pokemonJoueurSelectionner == Joueur.getPokemonEquipe()[i])
                {
                    if (compteur > 0)
                    {
                        label_pv_pokemon[i].Text = compteur.ToString() + " / " + pokemonJoueurSelectionner.getPv().ToString() + " PV";
                    }
                    else
                    {
                        label_pv_pokemon[i].Text = "K.O.";
                    }
                }
            }
        }

        public void rafraichirBarreExperiencePokemonJoueur()
        {
            btn_attaque1.Enabled = false;
            btn_attraper.Enabled = false;
            btn_soigner.Enabled = false;
            btn_changement_pokemon.Enabled = false;

            timerBarreExperiencePokemonJoueur.Start();
        }

        public void rafraichirAnimationCapture()
        {
            timerAnimationCapture.Start();
        }

        public void rafraichirBarreExperiencePokemonJoueur1()
        {
            Graphics gBarreExperience;

            gBarreExperience = Graphics.FromImage(DrawAreaExperiencePokemonJoueur);

            System.Drawing.SolidBrush fillBlue = new System.Drawing.SolidBrush(Color.Blue);

            Pen black = new Pen(Color.Black);

            gBarreExperience.DrawRectangle(black, 0, 0, 100, 15);

            pictureBoxBarreExperiencePokemonJoueur.Image = DrawAreaExperiencePokemonJoueur;

            gBarreExperience.Clear(SystemColors.Control);
            gBarreExperience.DrawRectangle(black, 0, 0, 100, 15);
            gBarreExperience.FillRectangle(fillBlue, 0, 0, (100 * (pokemonJoueurSelectionner.getExperience() - pokemonJoueurSelectionner.getExperiencePokemonReturn())) / (pokemonJoueurSelectionner.getExperiencePokemonProchainNiveau() - pokemonJoueurSelectionner.getExperiencePokemonReturn()), 15);
            pictureBoxBarreViePokemonJoueur.Image = DrawAreaPokemonJoueur;

            gBarreExperience.Dispose();
        }

        public void rafraichirBarreViePokemonAdversaire1()
        {
            Graphics gBarreAdversaire;

            gBarreAdversaire = Graphics.FromImage(DrawAreaPokemonAdversaire);

            System.Drawing.SolidBrush fillGreen = new System.Drawing.SolidBrush(Color.Green);
            System.Drawing.SolidBrush fillRed = new System.Drawing.SolidBrush(Color.Red);
            System.Drawing.SolidBrush fillYellow = new System.Drawing.SolidBrush(Color.FromArgb(248, 222, 125));

            Pen black = new Pen(Color.Black);

            gBarreAdversaire.DrawRectangle(black, 0, 0, 100, 15);

            pictureBoxBarreViePokemonAdversaire.Image = DrawAreaPokemonAdversaire;

            if (pokemon.getPvRestant() >= pokemon.getPv() / 2)
            {
                gBarreAdversaire.Clear(SystemColors.Control);
                gBarreAdversaire.DrawRectangle(black, 0, 0, 100, 15);
                gBarreAdversaire.FillRectangle(fillGreen, 0, 0, (100 * pokemon.getPvRestant()) / pokemon.getPv(), 15);
                pictureBoxBarreViePokemonAdversaire.Image = DrawAreaPokemonAdversaire;

            }
            else if (pokemon.getPvRestant() < pokemon.getPv() / 2 && pokemon.getPvRestant() >= pokemon.getPv() / 5)
            {
                gBarreAdversaire.Clear(SystemColors.Control);
                gBarreAdversaire.DrawRectangle(black, 0, 0, 100, 15);
                gBarreAdversaire.FillRectangle(fillYellow, 0, 0, (100 * pokemon.getPvRestant()) / pokemon.getPv(), 15);
                pictureBoxBarreViePokemonAdversaire.Image = DrawAreaPokemonAdversaire;
            }
            else if (pokemon.getPvRestant() < pokemon.getPv() / 5 && pokemon.getPvRestant() > 0)
            {
                gBarreAdversaire.Clear(SystemColors.Control);
                gBarreAdversaire.DrawRectangle(black, 0, 0, 100, 15);
                gBarreAdversaire.FillRectangle(fillRed, 0, 0, (100 * pokemon.getPvRestant()) / pokemon.getPv(), 15);
                pictureBoxBarreViePokemonAdversaire.Image = DrawAreaPokemonAdversaire;

            }

            else
            {
                gBarreAdversaire.Clear(SystemColors.Control);
                gBarreAdversaire.DrawRectangle(black, 0, 0, 100, 15);
                pictureBoxBarreViePokemonAdversaire.Image = DrawAreaPokemonAdversaire;
            }

            gBarreAdversaire.Dispose();
        }

        public void rafraichirBarreViePokemonAdversaire()
        {
            // MessageBox.Show(statutPokemonPerdPv.ToString());
            if (statutPokemonPerdPvAdversaire == 0)
            {
                if (pokemonJoueurSelectionner.getPvRestant() > 0)
                {
                    if (nombreTourSommeil > nombreTourStatutAEffectuer && pokemonJoueurSelectionner.getStatutPokemon() == "Sommeil")
                    {
                        textBox1.Text += pokemonJoueurSelectionner.getNom() + " se réveille" + Environment.NewLine;
                        pokemonJoueurSelectionner.setStatutPokemon("Normal");
                        pictureBoxStatutPokemonCombatJoueur.Image = null;
                        nombreTourSommeil = 0;
                        nombreTourStatutAEffectuer = 0;
                    }

                    changementStatutAdversaire = pokemonJoueurSelectionner.getAttaqueChangementStatutPokemonAdverseReussi(attaqueLancerPokemon);
                    reussiteAttaque = pokemonJoueurSelectionner.getReussiteAttaque(pokemonJoueurSelectionner.getProbabiliteReussiteAttaque(pokemonJoueurSelectionner, pokemon, attaqueLancerPokemon));
                    bonusCritique = pokemonJoueurSelectionner.getCoupCritique(pokemonJoueurSelectionner.getProbabiliteCoupCritique(pokemonJoueurSelectionner));
                    nbDegats = pokemonJoueurSelectionner.attaqueWithNomAttaque(pokemonJoueurSelectionner, pokemon, attaqueLancerPokemon, bonusCritique, changementStatutAdversaire, ref nombreTourStatutAdversaire, ref reussiteAttaqueParalyse, ref reussiteAttaqueGel, ref nombreTourSommeil);

                    if (pokemonJoueurSelectionner.getStatutPokemon() != "Sommeil")
                    {
                        if (reussiteAttaque == true)
                        {
                            textBox1.Text += Environment.NewLine + pokemonJoueurSelectionner.getNom() + " lance " + attaqueLancerPokemon.getNom() + Environment.NewLine;

                            if (pokemonJoueurSelectionner.getStatutPokemon() != "Paralysie" || (pokemonJoueurSelectionner.getStatutPokemon() == "Paralysie" && reussiteAttaqueParalyse == true))
                            {
                                if (pokemonJoueurSelectionner.getStatutPokemon() != "Gelé" || (pokemonJoueurSelectionner.getStatutPokemon() == "Gelé" && reussiteAttaqueGel == true))
                                {
                                
                                    if (bonusCritique == 1.5)
                                    {
                                        textBox1.Text += "Coup Critique" + Environment.NewLine;
                                        bonusCritique = 1;
                                    }

                                    if (pokemonJoueurSelectionner.getEfficaciteAttaque(attaqueLancerPokemon, pokemon) != 1)
                                    {
                                        textBox1.Text += pokemonJoueurSelectionner.getEfficaciteAttaqueTexte(pokemonJoueurSelectionner.getEfficaciteAttaque(attaqueLancerPokemon, pokemon)) + Environment.NewLine;
                                    }

                                    if (reussiteAttaqueGel == true)
                                    {
                                        textBox1.Text += pokemonJoueurSelectionner.getNom() + " redevient normal" + Environment.NewLine;
                                        pokemonJoueurSelectionner.setStatutPokemon("Normal");
                                        pictureBoxStatutPokemonCombatJoueur.Image = null;
                                        
                                    }


                                    if(changementStatutAdversaire == true)
                                    {
                                        string statutPokemonAdversaire = pokemon.getStatutPokemon();
                                        if (statutPokemonAdversaire != "Normal")
                                        {
                                            try
                                            {
                                                Bitmap pngStatutPokemonAdverse = new Bitmap(AppDomain.CurrentDomain.BaseDirectory + "\\Images\\Statut\\" + statutPokemonAdversaire + ".png");
                                                pictureBoxStatutPokemonCombatAdversaire.Image = pngStatutPokemonAdverse;
                                            }
                                            catch
                                            {
                                                MessageBox.Show("L'image du statut du pokémon adverse n'a pas pu être chargée. Veuillez vérifier que celle-ci est bien présente dans le répertoire.", "Vérification de l'image du statut du pokémon adverse", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            }
                                            //  statutPokemonPerdPv = 1;
                                        }
                                        changementStatutAdversaire = false;
                                    }
                           
                            }
                            else
                            {
                                textBox1.Text += pokemonJoueurSelectionner.getNom() + " est gelé. Il ne peut pas attaquer" + Environment.NewLine;
                            }
                        }
                        else
                        {
                            textBox1.Text += pokemonJoueurSelectionner.getNom() + " est paralysé. Il ne peut pas attaquer" + Environment.NewLine;
                        }
                    }
                    else
                    {
                        textBox1.Text += pokemonJoueurSelectionner.getNom() + " rate son attaque" + Environment.NewLine;
                    }

                }
                else
                { 
                    if (nombreTourStatutAEffectuer == 0)
                    {
                        nombreTourStatutAEffectuer = pokemonJoueurSelectionner.getNombreTourSommeilAEffectuer();
                    }
                    textBox1.Text += pokemonJoueurSelectionner.getNom() + " est endormi. Il ne peut pas attaquer" + Environment.NewLine;
                    nombreTourSommeil++;

                }
            }
        }

            else if(statutPokemonPerdPvAdversaire == 1)
            {
                statutPokemonPerdPvAdversaire = 2;
            }

            if (pokemonJoueurAttaquePremier == false)
            {
                btn_attraper.Enabled = false;
                btn_soigner.Enabled = false;
                btn_attaque1.Enabled = false;
                btn_changement_pokemon.Enabled = false;
            }

            timerBarrePokemonAdversaire.Start();
        }

        public void attaqueCombat(ClassLibrary2.Attaque attaqueLancerPokemonJoueur)
        {  

            ClassLibrary2.Attaque attaqueLancerAdversaire = pokemon.attaqueAdversaire(pokemon, pokemonJoueurSelectionner);

            if (attaqueLancerPokemonJoueur.getPrioriteAttaque() > attaqueLancerAdversaire.getPrioriteAttaque())
            {
                pokemonJoueurAttaquePremier = true;
                attaqueCombatPokemonJoueur(attaqueLancerPokemonJoueur);
                if (attaqueLancerAdversaire != null)
                {
                    attaqueCombatAdversaire(attaqueLancerAdversaire);
                }
            }
            else if (attaqueLancerPokemonJoueur.getPrioriteAttaque() < attaqueLancerAdversaire.getPrioriteAttaque())
            {
                pokemonJoueurAttaquePremier = false;
                if (attaqueLancerAdversaire != null)
                {
                    attaqueCombatAdversaire(attaqueLancerAdversaire);
                }
                attaqueCombatPokemonJoueur(attaqueLancerPokemonJoueur);
            }
            else
            {
                if (pokemonJoueurSelectionner.getStatistiquesVitesse() > pokemon.getStatistiquesVitesse())
                {
                    pokemonJoueurAttaquePremier = true;
                    attaqueCombatPokemonJoueur(attaqueLancerPokemonJoueur);
                    if (attaqueLancerAdversaire != null)
                    {
                        attaqueCombatAdversaire(attaqueLancerAdversaire);
                    }
                }
                else if (pokemonJoueurSelectionner.getStatistiquesVitesse() < pokemon.getStatistiquesVitesse())
                {
                    pokemonJoueurAttaquePremier = false;
                    if (attaqueLancerAdversaire != null)
                    {
                        attaqueCombatAdversaire(attaqueLancerAdversaire);
                    }
                    attaqueCombatPokemonJoueur(attaqueLancerPokemonJoueur);
                }
                else
                {
                    List<ClassLibrary2.Attaque> liste_attaque_vitesse = new List<ClassLibrary2.Attaque>();
                    Random rand = new Random();

                    liste_attaque_vitesse.Add(attaqueLancerPokemonJoueur);
                    liste_attaque_vitesse.Add(attaqueLancerAdversaire);

                    int index = rand.Next(liste_attaque_vitesse.Count);

                    if (liste_attaque_vitesse[index] == attaqueLancerPokemonJoueur)
                    {
                        pokemonJoueurAttaquePremier = true;
                        attaqueCombatPokemonJoueur(attaqueLancerPokemonJoueur);
                        if (attaqueLancerAdversaire != null)
                        {
                            attaqueCombatAdversaire(attaqueLancerAdversaire);
                        }
                    }
                    else if (liste_attaque_vitesse[index] == attaqueLancerAdversaire)
                    {
                        pokemonJoueurAttaquePremier = false;
                        if (attaqueLancerAdversaire != null)
                        {
                            attaqueCombatAdversaire(attaqueLancerAdversaire);
                        }
                        attaqueCombatPokemonJoueur(attaqueLancerPokemonJoueur);
                    }
                }
            }

        }

        public void attaqueCombatPokemonJoueur(ClassLibrary2.Attaque attaqueLancer)
        {
            if (pokemonJoueurSelectionner.getPvRestant() > 0)
            {
                attaqueLancerPokemon = attaqueLancer;
            }
        }

        public void attaqueCombatAdversaire(ClassLibrary2.Attaque attaqueLancer)
        {
            if (pokemonJoueurSelectionner == Joueur.getPokemonEquipe()[0])
            {
                
            }

            compteur = pokemonJoueurSelectionner.getPvRestant();

            btn_attaque_une.Visible = false;
            btn_attaque_deux.Visible = false;
            btn_attaque_trois.Visible = false;
            btn_attaque_quatre.Visible = false;
            label_pp_attaque_une.Visible = false;
            label_pp_attaque_deux.Visible = false;
            label_pp_attaque_trois.Visible = false;
            label_pp_attaque_quatre.Visible = false;
            btn_retour_choix_attaque.Visible = false;

            pictureBoxTypeAttaque1.Visible = false;
            pictureBoxTypeAttaque2.Visible = false;
            pictureBoxTypeAttaque3.Visible = false;
            pictureBoxTypeAttaque4.Visible = false;

            // pokemonJoueurAttaquePremier = true;
            attaqueLancerAdversaire = null;

            if (pokemonJoueurAttaquePremier == true && changement_pokemon == false) 
            {
                rafraichirBarreViePokemonAdversaire();
            }
            else if(changement_pokemon == true && changementPokemonPokemonKo == false)
            {
                changement_pokemon = false;
                rafraichirBarreViePokemonJoueur();
            }
            else if(changement_pokemon == true && changementPokemonPokemonKo == true)
            {
                changement_pokemon = false;
                changementPokemonPokemonKo = false;

                btn_attaque1.Enabled = true;
                btn_attraper.Enabled = true;
                btn_soigner.Enabled = true;
                btn_changement_pokemon.Enabled = true;
            }
            else
            {
                rafraichirBarreViePokemonJoueur();
            }

        }

        public void changementPokemon()
        {
            textBox1.Text += pokemonJoueurSelectionner.getNom() + " a " + pokemonJoueurSelectionner.getPvRestant() + " PV" + Environment.NewLine;
            label_pv_pokemon_combat_joueur.Text = pokemonJoueurSelectionner.getPvRestant().ToString() + " / " + pokemonJoueurSelectionner.getPv().ToString() + " PV";

            cb_choix_objets.Visible = false;
            btn_choix_objet.Visible = false;

            int idPokedexImage = pokemonJoueurSelectionner.getNoIdPokedex();
            try
            {
                Bitmap png = new Bitmap(AppDomain.CurrentDomain.BaseDirectory + "\\Images\\" + idPokedexImage + ".png");
                pictureBoxPokemonCombatJoueur.Image = png;
                pictureBoxPokemonCombatJoueur.Image.RotateFlip(RotateFlipType.Rotate180FlipY);
            }
            catch
            {
                MessageBox.Show("L'image du pokémon n'a pas pu être chargée. Veuillez vérifier que celle-ci est bien présente dans le répertoire.", "Vérification de l'image du pokémon", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            label_nom_pokemon_combat_joueur.Text = pokemonJoueurSelectionner.getNom();

            try
            {
                Bitmap pngIconePokemonMenuCombat = new Bitmap(AppDomain.CurrentDomain.BaseDirectory + "\\Images\\Icones\\" + pokemonJoueurSelectionner.getNoIdPokedex() + ".png");
                pictureBoxIconePokemon.Image = pngIconePokemonMenuCombat;
            }
            catch
            {
                MessageBox.Show("L'icône du pokémon n'a pas pu être chargée. Veuillez vérifier que celle-ci est bien présente dans le répertoire.", "Vérification de l'icône du pokémon", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (pokemonJoueurSelectionner.getSexe() == "Feminin")
            {
                label_sexe_pokemon_combat_joueur.Text = "♀";
                label_sexe_pokemon_combat_joueur.ForeColor = Color.Pink;
            }
            else if (pokemonJoueurSelectionner.getSexe() == "Masculin")
            {
                label_sexe_pokemon_combat_joueur.Text = "♂";
                label_sexe_pokemon_combat_joueur.ForeColor = Color.Blue;
            }

            panel_choix_pokemon_selection.Visible = false;

            compteur = pokemonJoueurSelectionner.getPvRestant();

            changement_pokemon = true;
            nombreTourStatut = 0;
            nombreTourSommeil = 0;
            nombreTourStatutAEffectuer = 0;
            
            rafraichirBarreViePokemonJoueur1();

            label_niveau_pokemon_combat_joueur.Text = "N. " + pokemonJoueurSelectionner.getNiveau().ToString();
            rafraichirBarreExperiencePokemonJoueur1();
        }

        public void choixPokemonStarter(DialogResult choixPersonnage)
        {
            if (choixPersonnage != null)
            {
                pictureBoxCurseurChoixSexe.Image = null;

                label_choix_pokemon_depart.Visible = true;

                btn_pokeball_premier_starter.Visible = true;
                btn_pokeball_deuxieme_starter.Visible = true;
                btn_pokeball_troisieme_starter.Visible = true;

                pictureBoxCurseurPokemonStarter.Size = new Size(41, 41);
                pictureBoxCurseurPokemonStarter.SizeMode = PictureBoxSizeMode.StretchImage;
                this.Controls.Add(pictureBoxCurseurPokemonStarter);

                try
                {
                    Bitmap pngCurseurPokemonStarter = new Bitmap(AppDomain.CurrentDomain.BaseDirectory + "\\Images\\Curseur.png");
                    pictureBoxCurseurPokemonStarter.Image = pngCurseurPokemonStarter;
                    pictureBoxCurseurPokemonStarter.Visible = true;
                }
                catch
                {
                    MessageBox.Show("L'image du curseur n'a pas pu être chargée. Veuillez vérifier que celle-ci est bien présente dans le répertoire.", "Vérification du curseur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                

                // cb_choix_pokemon_depart.Focus();
                btn_pokeball_premier_starter.Focus();

                if (btn_pokeball_premier_starter.Focused == true)
                {
                    pictureBoxCurseurPokemonStarter.Location = new System.Drawing.Point(86, 590);
                }
                else if (btn_pokeball_deuxieme_starter.Focused == true)
                {
                    pictureBoxCurseurPokemonStarter.Location = new System.Drawing.Point(154, 590);
                }
                else if (btn_pokeball_troisieme_starter.Focused == true)
                {
                    pictureBoxCurseurPokemonStarter.Location = new System.Drawing.Point(222, 590);
                }

                btn_choix_garçon.Enabled = false;
                btn_choix_fille.Enabled = false;
            }
        }

        public void choixPokemonStarterChoixEffectuer(ClassLibrary2.Pokemon pokemonStarter)
        {
            
                if (pokemonStarter != null)
                {
                    for (int i = 0; i <= 5; i++)
                    {
                        pictureBoxPokemon[i] = new PictureBox();
                        pictureBoxPokemon[i].Size = new Size(89, 77);
                        pictureBoxPokemon[i].SizeMode = PictureBoxSizeMode.CenterImage;
                        groupBoxPokemon.Controls.Add(pictureBoxPokemon[i]);
                    }
                    pictureBoxPokemon[0].Location = new System.Drawing.Point(10, 26);
                    pictureBoxPokemon[1].Location = new System.Drawing.Point(10, 111);
                    pictureBoxPokemon[2].Location = new System.Drawing.Point(10, 194);
                    pictureBoxPokemon[3].Location = new System.Drawing.Point(10, 277);
                    pictureBoxPokemon[4].Location = new System.Drawing.Point(10, 360);
                    pictureBoxPokemon[5].Location = new System.Drawing.Point(10, 444);

                    for (int i = 0; i <= 5; i++)
                    {
                        label_pokemon[i] = new Label();
                        label_pokemon[i].Text = "Pokemon " + i + 1;
                        label_pokemon[i].Size = new Size(69, 13);
                        label_pokemon[i].Visible = false;
                        groupBoxPokemon.Controls.Add(label_pokemon[i]);
                    }
                    label_pokemon[0].Location = new System.Drawing.Point(113, 56);
                    label_pokemon[1].Location = new System.Drawing.Point(113, 142);
                    label_pokemon[2].Location = new System.Drawing.Point(113, 225);
                    label_pokemon[3].Location = new System.Drawing.Point(113, 302);
                    label_pokemon[4].Location = new System.Drawing.Point(113, 386);
                    label_pokemon[5].Location = new System.Drawing.Point(113, 470);

                    for (int i = 0; i <= 5; i++)
                    {
                        label_pv_pokemon[i] = new Label();
                        label_pv_pokemon[i].Text = "PV Pokemon";
                        label_pv_pokemon[i].Size = new Size(80, 13);
                        label_pv_pokemon[i].Visible = false;
                        groupBoxPokemon.Controls.Add(label_pv_pokemon[i]);
                    }
                    label_pv_pokemon[0].Location = new System.Drawing.Point(196, 56);
                    label_pv_pokemon[1].Location = new System.Drawing.Point(196, 142);
                    label_pv_pokemon[2].Location = new System.Drawing.Point(196, 225);
                    label_pv_pokemon[3].Location = new System.Drawing.Point(196, 302);
                    label_pv_pokemon[4].Location = new System.Drawing.Point(196, 386);
                    label_pv_pokemon[5].Location = new System.Drawing.Point(196, 470);

                    for (int i = 0; i <= 5; i++)
                    {
                        radioBtn_pokemon[i] = new RadioButton();
                        radioBtn_pokemon[i].Size = new Size(14, 13);
                        radioBtn_pokemon[i].Visible = false;
                        panel_choix_pokemon_selection.Controls.Add(radioBtn_pokemon[i]);
                    }

                    radioBtn_pokemon[0].Location = new System.Drawing.Point(48, 28);
                    radioBtn_pokemon[1].Location = new System.Drawing.Point(48, 116);
                    radioBtn_pokemon[2].Location = new System.Drawing.Point(48, 199);
                    radioBtn_pokemon[3].Location = new System.Drawing.Point(48, 278);
                    radioBtn_pokemon[4].Location = new System.Drawing.Point(48, 360);
                    radioBtn_pokemon[5].Location = new System.Drawing.Point(48, 444);

                    labelSaisie.Visible = false;
                    textBoxSaisie.Visible = false;
                    Age.Visible = false;
                    textBoxAge.Visible = false;
                    buttonAfficher.Visible = false;

                    btn_choix_garçon.Visible = false;
                    btn_choix_fille.Visible = false;

                    btn_pokeball_premier_starter.Visible = false;
                    btn_pokeball_deuxieme_starter.Visible = false;
                    btn_pokeball_troisieme_starter.Visible = false;
                    pictureBoxPokeballPremierStarter.Visible = false;
                    pictureBoxPokeballDeuxiemeStarter.Visible = false;
                    pictureBoxPokeballTroisiemeStarter.Visible = false;
                    pictureBoxCurseurPokemonStarter.Visible = false;

                    pictureBoxCurseurPokemonStarter.Image = null;

                    label_choix_pokemon_depart.Visible = false;

                    groupBoxPokemon.Visible = true;
                    label_pokemon[0].Visible = true;
                    label_pv_pokemon[0].Visible = true;
                    radioBtn_pokemon[0].Visible = true;

                    combat_btn.Enabled = true;

                    combat_btn.Visible = true;
                    btn_pc.Visible = true;

                    groupBoxConnexion.Visible = false;

                    combat_btn.Focus();

                    //  pokemonJoueurStarter.setAttaque1(db.selectionAttaque("charge"));
                    //  pokemonJoueurStarter.setAttaque2(db.selectionAttaque("vive-attaque"));
                    //  pokemonJoueurStarter.setAttaque3(db.selectionAttaque("vitesse ex")); 
                    // pokemonJoueurStarter.setAttaque4(db.selectionAttaque("ecras face"));

                    Joueur.ajouterPokemonEquipe(pokemonStarter);
                   // Joueur.getPokemonEquipe()[0].setAllAttacksWithNom();

                // Joueur.getPokemonEquipe()[0].setAllAttacksWithId();

                    pokemonJoueurSelectionner = Joueur.getPokemonEquipe()[0];

                    // MessageBox.Show(pokemonJoueurSelectionner.getStatistiquesDefenseSpeciale().ToString() + " = " + pokemonJoueurSelectionner.getPv().ToString());

                    textBox1.Text += "Vous avez choisi " + Joueur.getPokemonEquipe()[0].getNom() + " !" + Environment.NewLine;
                    textBox1.Text += "Il a " + Joueur.getPokemonEquipe()[0].getPv() + " PV" + Environment.NewLine;

                    label_pv_pokemon_combat_joueur.Text = Joueur.getPokemonEquipe()[0].getPvRestant().ToString() + " / " + Joueur.getPokemonEquipe()[0].getPv().ToString() + " PV";

                    // label_pokemon1.Text = Joueur.getPokemonEquipe()[0].getNom();
                    label_pokemon[0].Text = Joueur.getPokemonEquipe()[0].getNom();

                    label_pv_pokemon[0].Text = Joueur.getPokemonEquipe()[0].getPvRestant().ToString() + " / " + Joueur.getPokemonEquipe()[0].getPv().ToString() + " PV";

                    Joueur.setObjetsSacOffline(jeu);

                    int idPokedexImage = Joueur.getPokemonEquipe()[0].getNoIdPokedex();

                    try
                    { 
                        Bitmap png = new Bitmap(AppDomain.CurrentDomain.BaseDirectory + "\\Images\\" + idPokedexImage + ".png");
                        pictureBoxPokemon[0].Image = png;
                        pictureBoxPokemon[0].Image.RotateFlip(RotateFlipType.Rotate180FlipY);
                    }
                    catch
                    {
                        MessageBox.Show("L'image du pokémon n'a pas pu être chargée. Veuillez vérifier que celle-ci est bien présente dans le répertoire.", "Vérification de l'image du pokémon", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    ouvrirToolStripMenuItem1.Enabled = true;
                    enregistrerToolStripMenuItem.Enabled = true;

                }
                else
                {
                    MessageBox.Show("Choisissez un starter...", "Vérification du starter", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            
        }

        public void changementMenuAttaqueCombat()
        {
            btn_attaque_une.Visible = false;
            btn_attaque_deux.Visible = false;
            btn_attaque_trois.Visible = false;
            btn_attaque_quatre.Visible = false;
            btn_retour_choix_attaque.Visible = false;

            pictureBoxTypeAttaque1.Visible = false;
            pictureBoxTypeAttaque2.Visible = false;
            pictureBoxTypeAttaque3.Visible = false;
            pictureBoxTypeAttaque4.Visible = false;

            label_pp_attaque_une.Visible = false;
            label_pp_attaque_deux.Visible = false;
            label_pp_attaque_trois.Visible = false;
            label_pp_attaque_quatre.Visible = false;

            pictureBoxMenuCombat.Image = null;
  
        }
        
        public void rafraichirApresChargementSauvegarde()
        {
            if (Joueur.getPokemonEquipe().Count >= 1)
            {
                pokemonJoueurSelectionner = Joueur.getPokemonEquipe()[0];
            }

            for(int i=0; i<nombrePokemonAvantChargementSauvegarde; i++)
            {
                pictureBoxPokemon[i].Image = null;
                label_pokemon[i].Text = null;
                label_pv_pokemon[i].Text = null;
            }
            
            for(int i = 0; i<Joueur.getPokemonEquipe().Count; i++)
            {
                int idPokedexImage = Joueur.getPokemonEquipe()[i].getNoIdPokedex();
                try
                {
                    Bitmap png = new Bitmap(AppDomain.CurrentDomain.BaseDirectory + "\\Images\\" + idPokedexImage + ".png");
                    pictureBoxPokemon[i].Image = png;
                    pictureBoxPokemon[i].Image.RotateFlip(RotateFlipType.Rotate180FlipY);
                }
                catch
                {
                    MessageBox.Show("L'image du pokémon n'a pas pu être chargée. Veuillez vérifier que celle-ci est bien présente dans le répertoire.", "Vérification de l'image du pokémon", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                label_pokemon[i].Text = Joueur.getPokemonEquipe()[i].getNom();
                label_pv_pokemon[i].Text = Joueur.getPokemonEquipe()[i].getPvRestant().ToString() + " / " + Joueur.getPokemonEquipe()[i].getPv().ToString() + " PV";

                if (i >= nombrePokemonAvantChargementSauvegarde)
                {
                    pictureBoxPokemon[i].Visible = true;
                    label_pokemon[i].Visible = true;
                    label_pv_pokemon[i].Visible = true;
                    radioBtn_pokemon[i].Visible = true;
                }

                if (combat_btn.Enabled != true)
                {
                    combat_btn.Enabled = true;
                }
                combat_btn.PerformClick();
            }
        }

        public frmSaisiesBoutons()
        {
            InitializeComponent();

            // db.selection();

            DrawAreaPokemonJoueur = new Bitmap(pictureBoxBarreViePokemonJoueur.Size.Width, pictureBoxBarreViePokemonJoueur.Size.Height);
            pictureBoxBarreViePokemonJoueur.Image = DrawAreaPokemonJoueur;

            DrawAreaExperiencePokemonJoueur = new Bitmap(pictureBoxBarreExperiencePokemonJoueur.Size.Width, pictureBoxBarreExperiencePokemonJoueur.Size.Height);
            pictureBoxBarreExperiencePokemonJoueur.Image = DrawAreaExperiencePokemonJoueur;

            DrawAreaPokemonAdversaire = new Bitmap(pictureBoxBarreViePokemonAdversaire.Size.Width, pictureBoxBarreViePokemonAdversaire.Size.Height);
            pictureBoxBarreViePokemonAdversaire.Image = DrawAreaPokemonAdversaire;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBoxSaisie.Select();
            this.KeyPreview = true;

            Thread threadInitialisationAttaque = new Thread(jeu.initialisationAttaques);
            threadInitialisationAttaque.Start();

            Thread threadInitialisationPokemon = new Thread(jeu.initialisationPokemon);
            threadInitialisationPokemon.Start();

            jeu.initialisationPokemonStarter();

            Thread threadInitialisationObjet = new Thread(jeu.initialisationObjets);
            threadInitialisationObjet.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //  button1.Text = "Bouton cliqué !";

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string nomPersonnageJoueur1 = textBoxSaisie.Text;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void buttonAfficher_Click(object sender, EventArgs e)
        {

            string texte = textBoxSaisie.Text.Trim();
            string texteAge = textBoxAge.Text.Trim();

            bool estConverti = false;
            int age;

            estConverti = int.TryParse(texteAge, out age);

            if (!estConverti)
            {
                MessageBox.Show("Erreur");
            }

            if (texte.Length != 0 && age != 0 && age is int)
            {
                // MessageBox.Show("Texte saisi= " + texte, "Vérification de la saisie", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // ClassLibrary2.Personnage Joueur1 = new ClassLibrary2.Personnage(texte, age);
                Joueur.setNomPersonnage(texte);

                // Joueur1.setPvJoueur();

                // MessageBox.Show(Joueur1.getNom());
                // MessageBox.Show(Joueur1.getAge().ToString());
                // MessageBox.Show(Joueur1.getPv().ToString());

                textBox1.Text += "Bienvenue " + Joueur.getNom() + Environment.NewLine;
                // textBox1.Text += "Vous avez " + Joueur1.getPv() + " PV" + Environment.NewLine;

                // cb_choix_pokemon_depart.Visible = true;
                // bt_choixPokemon.Visible = true;

                textBoxSaisie.Enabled = false;
                textBoxAge.Enabled = false;

                buttonAfficher.Enabled = false;

               

                pictureBoxCurseurChoixSexe.Size = new Size(41, 41);
                pictureBoxCurseurChoixSexe.SizeMode = PictureBoxSizeMode.StretchImage;
                this.Controls.Add(pictureBoxCurseurChoixSexe);

                try
                {
                    Bitmap pngCurseurChoixSexe = new Bitmap(AppDomain.CurrentDomain.BaseDirectory + "\\Images\\Curseur.png");
                    pictureBoxCurseurChoixSexe.Image = pngCurseurChoixSexe;
                    pictureBoxCurseurChoixSexe.Visible = true;
                }
                catch
                {
                    MessageBox.Show("L'image du curseur n'a pas pu être chargée. Veuillez vérifier que celle-ci est bien présente dans le répertoire.", "Vérification du curseur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
               
                btn_choix_garçon.Size = new Size(75, 134);
                btn_choix_fille.Size = new Size(75, 134);

                try
                {
                    Bitmap pngPersonnageGarçon = new Bitmap(AppDomain.CurrentDomain.BaseDirectory + "\\Images\\Joueur\\Red.png");
                    btn_choix_garçon.BackgroundImage = pngPersonnageGarçon;
                }
                catch
                {
                    MessageBox.Show("L'image du personnage joueur garçon n'a pas pu être chargée. Veuillez vérifier que celle-ci est bien présente dans le répertoire.", "Vérification du personnage", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                btn_choix_garçon.BackgroundImageLayout = ImageLayout.Stretch;
                btn_choix_garçon.BackColor = Color.Transparent;
                btn_choix_garçon.ForeColor = Color.Transparent;
                btn_choix_garçon.FlatStyle = FlatStyle.Flat;
                btn_choix_garçon.FlatAppearance.BorderSize = 0;

                try
                {
                    Bitmap pngPersonnageFille = new Bitmap(AppDomain.CurrentDomain.BaseDirectory + "\\Images\\Joueur\\Leaf.png");
                    btn_choix_fille.BackgroundImage = pngPersonnageFille;
                }
                catch
                {
                    MessageBox.Show("L'image du personnage joueur fille n'a pas pu être chargée. Veuillez vérifier que celle-ci est bien présente dans le répertoire.", "Vérification du personnage", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                btn_choix_fille.BackgroundImageLayout = ImageLayout.Zoom;
                btn_choix_fille.BackColor = Color.Transparent;
                btn_choix_fille.ForeColor = Color.Transparent;
                btn_choix_fille.FlatStyle = FlatStyle.Flat;
                btn_choix_fille.FlatAppearance.BorderSize = 0;

                this.Controls.Add(btn_choix_garçon);
                this.Controls.Add(btn_choix_fille);

                btn_choix_garçon.Location = new System.Drawing.Point(48, 256);
                btn_choix_fille.Location = new System.Drawing.Point(151, 256);

                btn_choix_garçon.Click += btn_choix_garçon_Click;
                btn_choix_garçon.PreviewKeyDown += btn_choix_garçon_PreviewKeyDown;
                btn_choix_garçon.KeyDown += btn_choix_garçon_KeyDown;

                btn_choix_fille.Click += btn_choix_fille_Click;
                btn_choix_fille.PreviewKeyDown += btn_choix_fille_PreviewKeyDown;
                btn_choix_fille.KeyDown += btn_choix_fille_KeyDown;

                btn_choix_garçon.Focus();

                if (btn_choix_garçon.Focused == true)
                {
                    pictureBoxCurseurChoixSexe.Location = new System.Drawing.Point(56, 205);
                }
                else if (btn_choix_fille.Focused == true)
                {
                    pictureBoxCurseurChoixSexe.Location = new System.Drawing.Point(159, 205);
                }

            }
            else
            {
                MessageBox.Show("Saisissez un texte...", "Vérification de la saisie", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_2(object sender, EventArgs e)
        {
            textBox1.SelectionStart = textBox1.Text.Length;
            textBox1.SelectionLength = 0;
            textBox1.ScrollToCaret();
            textBox1.Focus(); 
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (pictureBoxPokeball != null)
            {
                this.Controls.Remove(pictureBoxPokeball);
            }

            if (btn_soigner.Enabled != true)
            {
                btn_soigner.Enabled = true;
            }

            if (Joueur.getObjetsSac()[0].getQuantiteObjet() > 0)
            {
                btn_soigner.Enabled = true;
            }

            // ClassLibrary2.Pokemon pokemon2 = new ClassLibrary2.Pokemon();


            // MessageBox.Show(pokemon2.getNomAttaque1());

            //  pokemon = pokemon.setPokemon();
            pokemon = pokemon.setRandomPokemon(jeu);

            pokemon.setPvRestant(pokemon.getPv());
            // pokemon.setAllAttacksWithNom();

            //  Bitmap pngTypeTerrain = new Bitmap(AppDomain.CurrentDomain.BaseDirectory + "\\Images\\Combat\\Terrain_Herbe.png");
            //  pictureBoxTerrainCombat.Image = pngTypeTerrain;

            try
            {
                Bitmap pngBasePokemon = new Bitmap(AppDomain.CurrentDomain.BaseDirectory + "\\Images\\Combat\\Base_herbe.png");
                pictureBoxBasePokemonJoueur.Image = pngBasePokemon;
            }
            catch
            {
                MessageBox.Show("L'image de la base du terrain n'a pas pu être chargée. Veuillez vérifier que celle-ci est bien présente dans le répertoire.", "Vérification de la base du terrain", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            pictureBoxBasePokemonJoueur.Controls.Add(pictureBoxPokemonCombatJoueur);
            // pictureBoxPokemonCombatJoueur.Location = new Point(26, -11);
            pictureBoxPokemonCombatJoueur.Location = new Point(26, 8);

            try
            {
                Bitmap pngBasePokemonAdversaire = new Bitmap(AppDomain.CurrentDomain.BaseDirectory + "\\Images\\Combat\\Base_herbe.png");
                pictureBoxBasePokemonAdversaire.Image = pngBasePokemonAdversaire;
            }
            catch
            {
                MessageBox.Show("L'image de la base du terrain n'a pas pu être chargée. Veuillez vérifier que celle-ci est bien présente dans le répertoire.", "Vérification de la base du terrain", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            pictureBoxBasePokemonAdversaire.Controls.Add(pictureBoxPokemonCombatAdversaire);
            pictureBoxPokemonCombatAdversaire.Location = new Point(27, -8);

            int idPokedexImage = pokemonJoueurSelectionner.getNoIdPokedex();

            try
            {
                Bitmap png = new Bitmap(AppDomain.CurrentDomain.BaseDirectory + "\\Images\\" + idPokedexImage + ".png");
                pictureBoxPokemonCombatJoueur.Image = png;
                pictureBoxPokemonCombatJoueur.Image.RotateFlip(RotateFlipType.Rotate180FlipY);
            }
            catch
            {
                MessageBox.Show("L'image du pokémon n'a pas pu être chargée. Veuillez vérifier que celle-ci est bien présente dans le répertoire.", "Vérification de l'image du pokémon", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (pictureBoxPokemonCombatAdversaire.Visible == false)
            {
                pictureBoxPokemonCombatAdversaire.Visible = true;
            }

            int idPokedexImageCombat = pokemon.getNoIdPokedex();
            try
            {
                Bitmap pngPokemonAdversaire = new Bitmap(AppDomain.CurrentDomain.BaseDirectory + "\\Images\\" + idPokedexImageCombat + ".png");
                pictureBoxPokemonCombatAdversaire.Image = pngPokemonAdversaire;
            }
            catch
            {
                MessageBox.Show("L'image du pokémon adverse n'a pas pu être chargée. Veuillez vérifier que celle-ci est bien présente dans le répertoire.", "Vérification de l'image du pokémon adverse", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            textBox1.Text += Environment.NewLine; ;
            textBox1.Text += "Un " + pokemon.getNom() + " sauvage veut se battre" + Environment.NewLine;
            textBox1.Text += "Il a " + pokemon.getPv() + " PV" + Environment.NewLine;

            label_nom_pokemon_combat_joueur.Text = pokemonJoueurSelectionner.getNom();
            // label_pv_pokemon_combat_joueur.Text = Joueur.getPokemonEquipe()[0].getPvRestant().ToString() + " / " + Joueur.getPokemonEquipe()[0].getPv().ToString() + " PV";
            label_niveau_pokemon_combat_joueur.Text = "N. " + pokemonJoueurSelectionner.getNiveau().ToString();

            pictureBoxStatutPokemonCombatJoueur.Image = null;
            string statutPokemon = pokemonJoueurSelectionner.getStatutPokemon();
            if (statutPokemon != "Normal")
            {
                try
                {
                    Bitmap pngChangementStatutPokemon = new Bitmap(AppDomain.CurrentDomain.BaseDirectory + "\\Images\\Statut\\" + statutPokemon + ".png");
                    pictureBoxStatutPokemonCombatJoueur.Image = pngChangementStatutPokemon;
                }
                catch
                {
                    MessageBox.Show("L'image du statut du pokémon n'a pas pu être chargée. Veuillez vérifier que celle-ci est bien présente dans le répertoire.", "Vérification de l'image du statut du pokémon", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            if (pokemonJoueurSelectionner.getSexe() == "Feminin")
            {
                label_sexe_pokemon_combat_joueur.Text = "♀";
                label_sexe_pokemon_combat_joueur.ForeColor = Color.Pink;
            }
            else if(pokemonJoueurSelectionner.getSexe() == "Masculin")
            {
                label_sexe_pokemon_combat_joueur.Text = "♂";
                label_sexe_pokemon_combat_joueur.ForeColor = Color.Blue;
            }
                
            label_nom_pokemon_combat_adversaire.Text = pokemon.getNom();
            label_pv_pokemon_combat_adversaire.Text = pokemon.getPvRestant().ToString() + " / " + pokemon.getPv().ToString() + " PV";
            label_niveau_pokemon_combat_adversaire.Text = "N. " + pokemon.getNiveau().ToString();

            pictureBoxStatutPokemonCombatAdversaire.Image = null;
            string statutPokemonAdverse = pokemon.getStatutPokemon();
            if (statutPokemonAdverse != "Normal")
            {
                try
                {
                    Bitmap pngStatutPokemonAdverse = new Bitmap(AppDomain.CurrentDomain.BaseDirectory + "\\Images\\Statut\\" + statutPokemonAdverse + ".png");
                    pictureBoxStatutPokemonCombatAdversaire.Image = pngStatutPokemonAdverse;
                }
                catch
                {
                    MessageBox.Show("L'image du statut du pokémon adverse n'a pas pu être chargée. Veuillez vérifier que celle-ci est bien présente dans le répertoire.", "Vérification de l'image du statut du pokémon adverse", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            if (pokemon.getSexe() == "Feminin")
            {
                label_sexe_pokemon_combat_adversaire.Text = "♀";
                label_sexe_pokemon_combat_adversaire.ForeColor = Color.Pink;
            }
            else if (pokemon.getSexe() == "Masculin")
            {
                label_sexe_pokemon_combat_adversaire.Text = "♂";
                label_sexe_pokemon_combat_adversaire.ForeColor = Color.Blue;
            }

            label_nom_pokemon_combat_joueur.Visible = true;
            label_pv_pokemon_combat_joueur.Visible = true;
            label_sexe_pokemon_combat_joueur.Visible = true;
            label_niveau_pokemon_combat_joueur.Visible = true;
            pictureBoxStatutPokemonCombatJoueur.Visible = true;

            label_nom_pokemon_combat_adversaire.Visible = true;
            label_pv_pokemon_combat_adversaire.Visible = true;
            label_sexe_pokemon_combat_adversaire.Visible = true;
            label_niveau_pokemon_combat_adversaire.Visible = true;
            pictureBoxStatutPokemonCombatAdversaire.Visible = true;

            btn_attaque1.Enabled = true;
            combat_btn.Enabled = false;
            btn_pc.Enabled = false;
            btn_attraper.Enabled = true;
            btn_changement_pokemon.Enabled = true;

            btn_attaque1.Visible = true;
            btn_attraper.Visible = true;
            btn_soigner.Visible = true;
            btn_changement_pokemon.Visible = true;

            btn_attaque1.Focus();

            try
            {
                Bitmap pngMenuCombat = new Bitmap(AppDomain.CurrentDomain.BaseDirectory + "\\Images\\Combat\\menu_combat.png");
                pictureBoxMenuCombat.Image = pngMenuCombat;
                pictureBoxMenuCombat.Visible = true;
            }
            catch
            {
                MessageBox.Show("L'image du menu de combat n'a pas pu être chargée. Veuillez vérifier que celle-ci est bien présente dans le répertoire.", "Vérification de l'image du menu du combat", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            try
            {
                Bitmap pngIconePokemonMenuCombat = new Bitmap(AppDomain.CurrentDomain.BaseDirectory + "\\Images\\Icones\\" + pokemonJoueurSelectionner.getNoIdPokedex() + ".png");
                pictureBoxIconePokemon.Image = pngIconePokemonMenuCombat;
            }
            catch
            {
                MessageBox.Show("L'icône du pokémon n'a pas pu être chargée. Veuillez vérifier que celle-ci est bien présente dans le répertoire.", "Vérification de l'icône du pokémon", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            btn_attaque1.Controls.Add(pictureBoxIconePokemon);
            pictureBoxIconePokemon.Location = new System.Drawing.Point(65, 23);
            pictureBoxIconePokemon.Visible = true;

            compteur = pokemonJoueurSelectionner.getPvRestant();
            compteurAdversaire = pokemon.getPvRestant();

            rafraichirBarreViePokemonJoueur1();
            rafraichirBarreExperiencePokemonJoueur1();

            rafraichirBarreViePokemonAdversaire1();
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            /*
            if (btn_choix_objet.Visible = true && cb_choix_objets.Visible == true)
            {
                btn_choix_objet.Visible = false;
                cb_choix_objets.Visible = false;
            }

            pokemonJoueurSelectionner.attaque(pokemon);

            if (pokemon.getPvRestant() > 0)
            {
                textBox1.Text += pokemon.getNom() + " sauvage a " + pokemon.getPvRestant() + " PV" + Environment.NewLine;
                pokemon.attaque(pokemonJoueurSelectionner);

                label_pv_pokemon_combat_adversaire.Text = pokemon.getPvRestant().ToString() + " / " + pokemon.getPv().ToString() + " PV";

            }
            else
            {
                textBox1.Text += pokemon.getNom() + " sauvage est K.O." + Environment.NewLine;
                label_pv_pokemon_combat_adversaire.Text = "K.O.";

                combat_btn.Enabled = true;
                btn_attraper.Enabled = false;
                btn_soigner.Enabled = false;
                btn_attaque1.Enabled = false;
            }

            if (pokemonJoueurSelectionner == Joueur.getPokemonEquipe()[0])
            {
                if (pokemonJoueurSelectionner.getPvRestant() > 0)
                {
                    textBox1.Text += pokemonJoueurSelectionner.getNom() + " a " + pokemonJoueurSelectionner.getPvRestant() + " PV" + Environment.NewLine;
                    label_pv_pokemon1.Text = pokemonJoueurSelectionner.getPvRestant().ToString() + " / " + pokemonJoueurSelectionner.getPv().ToString() + " PV";

                }
                else
                {
                    textBox1.Text += pokemonJoueurSelectionner + " est K.O." + Environment.NewLine;
                    label_pv_pokemon1.Text = "K.O.";
                    label_pv_pokemon_combat_joueur.Text = "K.O.";
                    btn_attraper.Enabled = false;
                    btn_soigner.Enabled = false;
                    btn_attaque1.Enabled = false;
                }
            }

            else if (pokemonJoueurSelectionner == Joueur.getPokemonEquipe()[1])
            {
                if (pokemonJoueurSelectionner.getPvRestant() > 0)
                {
                    textBox1.Text += pokemonJoueurSelectionner.getNom() + " a " + pokemonJoueurSelectionner.getPvRestant() + " PV" + Environment.NewLine;
                    label_pv_pokemon2.Text = pokemonJoueurSelectionner.getPvRestant().ToString() + " / " + pokemonJoueurSelectionner.getPv().ToString() + " PV";

                }
                else
                {
                    textBox1.Text += pokemonJoueurSelectionner + " est K.O." + Environment.NewLine;
                    label_pv_pokemon2.Text = "K.O.";
                    label_pv_pokemon_combat_joueur.Text = "K.O.";
                    btn_attraper.Enabled = false;
                    btn_soigner.Enabled = false;
                    btn_attaque1.Enabled = false;
                }
            }

            else if (pokemonJoueurSelectionner == Joueur.getPokemonEquipe()[2])
            {
                if (pokemonJoueurSelectionner.getPvRestant() > 0)
                {
                    textBox1.Text += pokemonJoueurSelectionner.getNom() + " a " + pokemonJoueurSelectionner.getPvRestant() + " PV" + Environment.NewLine;
                    label_pv_pokemon3.Text = pokemonJoueurSelectionner.getPvRestant().ToString() + " / " + pokemonJoueurSelectionner.getPv().ToString() + " PV";

                }
                else
                {
                    textBox1.Text += pokemonJoueurSelectionner + " est K.O." + Environment.NewLine;
                    label_pv_pokemon3.Text = "K.O.";
                    label_pv_pokemon_combat_joueur.Text = "K.O.";
                    btn_attraper.Enabled = false;
                    btn_soigner.Enabled = false;
                    btn_attaque1.Enabled = false;
                }
            }

            else if (pokemonJoueurSelectionner == Joueur.getPokemonEquipe()[3])
            {
                if (pokemonJoueurSelectionner.getPvRestant() > 0)
                {
                    textBox1.Text += pokemonJoueurSelectionner.getNom() + " a " + pokemonJoueurSelectionner.getPvRestant() + " PV" + Environment.NewLine;
                    label_pv_pokemon4.Text = pokemonJoueurSelectionner.getPvRestant().ToString() + " / " + pokemonJoueurSelectionner.getPv().ToString() + " PV";

                }
                else
                {
                    textBox1.Text += pokemonJoueurSelectionner + " est K.O." + Environment.NewLine;
                    label_pv_pokemon4.Text = "K.O.";
                    label_pv_pokemon_combat_joueur.Text = "K.O.";
                    btn_attraper.Enabled = false;
                    btn_soigner.Enabled = false;
                    btn_attaque1.Enabled = false;
                }
            }

            if (pokemonJoueurSelectionner == Joueur.getPokemonEquipe()[4])
            {
                if (pokemonJoueurSelectionner.getPvRestant() > 0)
                {
                    textBox1.Text += pokemonJoueurSelectionner.getNom() + " a " + pokemonJoueurSelectionner.getPvRestant() + " PV" + Environment.NewLine;
                    label_pv_pokemon5.Text = pokemonJoueurSelectionner.getPvRestant().ToString() + " / " + pokemonJoueurSelectionner.getPv().ToString() + " PV";

                }
                else
                {
                    textBox1.Text += pokemonJoueurSelectionner + " est K.O." + Environment.NewLine;
                    label_pv_pokemon5.Text = "K.O.";
                    label_pv_pokemon_combat_joueur.Text = "K.O.";
                    btn_attraper.Enabled = false;
                    btn_soigner.Enabled = false;
                    btn_attaque1.Enabled = false;
                }
            }

            else if (pokemonJoueurSelectionner == Joueur.getPokemonEquipe()[5])
            {
                if (pokemonJoueurSelectionner.getPvRestant() > 0)
                {
                    textBox1.Text += pokemonJoueurSelectionner.getNom() + " a " + pokemonJoueurSelectionner.getPvRestant() + " PV" + Environment.NewLine;
                    label_pv_pokemon6.Text = pokemonJoueurSelectionner.getPvRestant().ToString() + " / " + pokemonJoueurSelectionner.getPv().ToString() + " PV";

                }
                else
                {
                    textBox1.Text += pokemonJoueurSelectionner + " est K.O." + Environment.NewLine;
                    label_pv_pokemon6.Text = "K.O.";
                    label_pv_pokemon_combat_joueur.Text = "K.O.";
                    btn_attraper.Enabled = false;
                    btn_soigner.Enabled = false;
                    btn_attaque1.Enabled = false;
                }
            }


            rafraichirBarreViePokemonJoueur();

            rafraichirBarreViePokemonAdversaire();
            */
        }

        public void textBox2_TextChanged(object sender, EventArgs e)
        {
        }

        private void label1_Click_2(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cb_choix_pokemon_depart_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void bt_choixPokemon_Click(object sender, EventArgs e)
        {
            if (pokemonJoueurStarter != null)
            {
                for (int i = 0; i <= 5; i++)
                {
                    pictureBoxPokemon[i] = new PictureBox();
                    pictureBoxPokemon[i].Size = new Size(89, 77);
                    pictureBoxPokemon[i].SizeMode = PictureBoxSizeMode.CenterImage;
                    groupBoxPokemon.Controls.Add(pictureBoxPokemon[i]);
                }
                pictureBoxPokemon[0].Location = new System.Drawing.Point(10, 26);
                pictureBoxPokemon[1].Location = new System.Drawing.Point(10, 111);
                pictureBoxPokemon[2].Location = new System.Drawing.Point(10, 194);
                pictureBoxPokemon[3].Location = new System.Drawing.Point(10, 277);
                pictureBoxPokemon[4].Location = new System.Drawing.Point(10, 360);
                pictureBoxPokemon[5].Location = new System.Drawing.Point(10, 444);

                for (int i = 0; i <= 5; i++)
                {
                    label_pokemon[i] = new Label();
                    label_pokemon[i].Text = "Pokemon " + i+1;
                    label_pokemon[i].Size = new Size(69, 13);
                    label_pokemon[i].Visible = false;
                    groupBoxPokemon.Controls.Add(label_pokemon[i]);
                }
                label_pokemon[0].Location = new System.Drawing.Point(113, 56);
                label_pokemon[1].Location = new System.Drawing.Point(113, 142);
                label_pokemon[2].Location = new System.Drawing.Point(113, 225);
                label_pokemon[3].Location = new System.Drawing.Point(113, 302);
                label_pokemon[4].Location = new System.Drawing.Point(113, 386);
                label_pokemon[5].Location = new System.Drawing.Point(113, 470);

                for (int i = 0; i <= 5; i++)
                {
                    label_pv_pokemon[i] = new Label();
                    label_pv_pokemon[i].Text = "PV Pokemon";
                    label_pv_pokemon[i].Size = new Size(80, 13);
                    label_pv_pokemon[i].Visible = false;
                    groupBoxPokemon.Controls.Add(label_pv_pokemon[i]);
                }
                label_pv_pokemon[0].Location = new System.Drawing.Point(196, 56);
                label_pv_pokemon[1].Location = new System.Drawing.Point(196, 142);
                label_pv_pokemon[2].Location = new System.Drawing.Point(196, 225);
                label_pv_pokemon[3].Location = new System.Drawing.Point(196, 302);
                label_pv_pokemon[4].Location = new System.Drawing.Point(196, 386);
                label_pv_pokemon[5].Location = new System.Drawing.Point(196, 470);

                for (int i = 0; i <= 5; i++)
                {
                    radioBtn_pokemon[i] = new RadioButton();
                    radioBtn_pokemon[i].Size = new Size(14, 13);
                    radioBtn_pokemon[i].Visible = false;
                    panel_choix_pokemon_selection.Controls.Add(radioBtn_pokemon[i]);
                }

                radioBtn_pokemon[0].Location = new System.Drawing.Point(48, 28);
                radioBtn_pokemon[1].Location = new System.Drawing.Point(48, 116);
                radioBtn_pokemon[2].Location = new System.Drawing.Point(48, 199);
                radioBtn_pokemon[3].Location = new System.Drawing.Point(48, 278);
                radioBtn_pokemon[4].Location = new System.Drawing.Point(48, 360);
                radioBtn_pokemon[5].Location = new System.Drawing.Point(48, 444);

                labelSaisie.Visible = false;
                textBoxSaisie.Visible = false;
                Age.Visible = false;
                textBoxAge.Visible = false;
                buttonAfficher.Visible = false;

                label_choix_pokemon_depart.Visible = false;

                groupBoxPokemon.Visible = true;
                label_pokemon[0].Visible = true;
                label_pv_pokemon[0].Visible = true;
                radioBtn_pokemon[0].Visible = true;

                combat_btn.Enabled = true;

                combat_btn.Visible = true;
                btn_attaque1.Visible = true;
                btn_attraper.Visible = true;
                groupBoxConnexion.Visible = false;
                btn_soigner.Visible = true;
                btn_changement_pokemon.Visible = true;

                combat_btn.Focus();
                
                //  pokemonJoueurStarter.setAttaque1(db.selectionAttaque("charge"));
                //  pokemonJoueurStarter.setAttaque2(db.selectionAttaque("vive-attaque"));
                //  pokemonJoueurStarter.setAttaque3(db.selectionAttaque("vitesse ex")); 
                // pokemonJoueurStarter.setAttaque4(db.selectionAttaque("ecras face"));

                Joueur.ajouterPokemonEquipe(pokemonJoueurStarter);
                Joueur.getPokemonEquipe()[0].setAllAttacksWithNom();

                pokemonJoueurSelectionner = Joueur.getPokemonEquipe()[0];

                // MessageBox.Show(pokemonJoueurSelectionner.getStatistiquesDefenseSpeciale().ToString() + " = " + pokemonJoueurSelectionner.getPv().ToString());

                textBox1.Text += "Vous avez choisi " + Joueur.getPokemonEquipe()[0].getNom() + " !" + Environment.NewLine;
                textBox1.Text += "Il a " + Joueur.getPokemonEquipe()[0].getPv() + " PV" + Environment.NewLine;

                label_pv_pokemon_combat_joueur.Text = Joueur.getPokemonEquipe()[0].getPvRestant().ToString() + " / " + Joueur.getPokemonEquipe()[0].getPv().ToString() + " PV";

                // label_pokemon1.Text = Joueur.getPokemonEquipe()[0].getNom();
                label_pokemon[0].Text = Joueur.getPokemonEquipe()[0].getNom();

                label_pv_pokemon[0].Text = Joueur.getPokemonEquipe()[0].getPvRestant().ToString() + " / " + Joueur.getPokemonEquipe()[0].getPv().ToString() + " PV";

                Joueur.setObjetsSac();

                int idPokedexImage = Joueur.getPokemonEquipe()[0].getNoIdPokedex();

                try
                {
                    Bitmap png = new Bitmap(AppDomain.CurrentDomain.BaseDirectory + "\\Images\\" + idPokedexImage + ".png");

                    pictureBoxPokemon[0].Image = png;
                    pictureBoxPokemon[0].Image.RotateFlip(RotateFlipType.Rotate180FlipY);
                }
                catch
                {
                    MessageBox.Show("L'image du pokémon n'a pas pu être chargée. Veuillez vérifier que celle-ci est bien présente dans le répertoire.", "Vérification de l'image du pokémon", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }
            else
            {
                MessageBox.Show("Choisissez un starter...", "Vérification du starter", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label1_Click_3(object sender, EventArgs e)
        {

        }

        private void btn_pokeball_premier_starter_Click(object sender, EventArgs e)
        {
            btn_pokeball_premier_starter.Focus();
            pictureBoxCurseurPokemonStarter.Location = new System.Drawing.Point(86, 590);

            // premierPokemonStarter = db.selectionPokemonStatsStarter("Bulbizarre");
            premierPokemonStarter = pokemon.setChercherPokemonStarter("Bulbizarre", jeu);
            try
            {
                Bitmap pngBasePokeballPremierStarter = new Bitmap(AppDomain.CurrentDomain.BaseDirectory + "\\Images\\" + premierPokemonStarter.getNoIdPokedex() + ".png");
                pictureBoxPokeballPremierStarter.Image = pngBasePokeballPremierStarter;
                pictureBoxPokeballPremierStarter.Image.RotateFlip(RotateFlipType.Rotate180FlipY);

                pictureBoxPokeballPremierStarter.Visible = true;
            }
            catch
            {
                MessageBox.Show("L'image du pokémon n'a pas pu être chargée. Veuillez vérifier que celle-ci est bien présente dans le répertoire.", "Vérification de l'image du pokémon", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }           

            DialogResult choixPremierStarter = MessageBox.Show("Voulez-vous vraiment choisir " + premierPokemonStarter.getNom() + " ? ", "Choix du starter", MessageBoxButtons.YesNo);

            if (choixPremierStarter == DialogResult.No)
            {
                pictureBoxPokeballPremierStarter.Visible = false;
            }
            else
            {
                choixPokemonStarterChoixEffectuer(premierPokemonStarter);
            }
        }

        private void btn_pokeball_deuxieme_starter_Click(object sender, EventArgs e)
        {
            btn_pokeball_deuxieme_starter.Focus();
            pictureBoxCurseurPokemonStarter.Location = new System.Drawing.Point(154, 590);

            // ClassLibrary2.Pokemon deuxiemePokemonStarter = db.selectionPokemonStatsStarter("Salameche");
            deuxiemePokemonStarter = pokemon.setChercherPokemonStarter("Salamèche", jeu);
            try
            {
                Bitmap pngBasePokeballDeuxiemeStarter = new Bitmap(AppDomain.CurrentDomain.BaseDirectory + "\\Images\\" + deuxiemePokemonStarter.getNoIdPokedex() + ".png");
                pictureBoxPokeballDeuxiemeStarter.Image = pngBasePokeballDeuxiemeStarter;
                pictureBoxPokeballDeuxiemeStarter.Image.RotateFlip(RotateFlipType.Rotate180FlipY);

                pictureBoxPokeballDeuxiemeStarter.Visible = true;
            }
            catch
            {
                MessageBox.Show("L'image du pokémon n'a pas pu être chargée. Veuillez vérifier que celle-ci est bien présente dans le répertoire.", "Vérification de l'image du pokémon", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            DialogResult choixDeuxiemeStarter = MessageBox.Show("Voulez-vous vraiment choisir " + deuxiemePokemonStarter.getNom() + " ? ", "Choix du starter", MessageBoxButtons.YesNo);

            if (choixDeuxiemeStarter == DialogResult.No)
            {
                pictureBoxPokeballDeuxiemeStarter.Visible = false;
            }
            else
            {
                choixPokemonStarterChoixEffectuer(deuxiemePokemonStarter);
            }
        }

        private void btn_pokeball_troisieme_starter_Click(object sender, EventArgs e)
        {
            btn_pokeball_troisieme_starter.Focus();
            pictureBoxCurseurPokemonStarter.Location = new System.Drawing.Point(222, 590);

            // troisiemePokemonStarter = db.selectionPokemonStatsStarter("Carapuce");
            ClassLibrary2.Pokemon troisiemePokemonStarter = pokemon.setChercherPokemonStarter("Carapuce", jeu);
            try
            {
                Bitmap pngBasePokeballTroisiemeStarter = new Bitmap(AppDomain.CurrentDomain.BaseDirectory + "\\Images\\" + troisiemePokemonStarter.getNoIdPokedex() + ".png");
                pictureBoxPokeballTroisiemeStarter.Image = pngBasePokeballTroisiemeStarter;
                pictureBoxPokeballTroisiemeStarter.Image.RotateFlip(RotateFlipType.Rotate180FlipY);

                pictureBoxPokeballTroisiemeStarter.Visible = true;
            }
            catch
            {
                MessageBox.Show("L'image du pokémon n'a pas pu être chargée. Veuillez vérifier que celle-ci est bien présente dans le répertoire.", "Vérification de l'image du pokémon", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            DialogResult choixTroisiemeStarter = MessageBox.Show("Voulez-vous vraiment choisir " + troisiemePokemonStarter.getNom() + " ? ", "Choix du starter", MessageBoxButtons.YesNo);

            if (choixTroisiemeStarter == DialogResult.No)
            {
                pictureBoxPokeballTroisiemeStarter.Visible = false;
            }
            else
            {
                choixPokemonStarterChoixEffectuer(troisiemePokemonStarter);
            }
        }

        private void btn_pokeball_premier_starter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                btn_pokeball_deuxieme_starter.Focus();
                pictureBoxCurseurPokemonStarter.Location = new System.Drawing.Point(154, 590);
            }
            else if(e.KeyCode == Keys.Left)
            {
               btn_pokeball_troisieme_starter.Focus();
               pictureBoxCurseurPokemonStarter.Location = new System.Drawing.Point(222, 590);
            }
        }

        private void btn_pokeball_premier_starter_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.Right)
            {
                e.IsInputKey = true;
            }
        }

        private void btn_pokeball_deuxieme_starter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                btn_pokeball_troisieme_starter.Focus();
                pictureBoxCurseurPokemonStarter.Location = new System.Drawing.Point(222, 590);
            }
            else if(e.KeyCode == Keys.Left)
            {
                btn_pokeball_premier_starter.Focus();
                pictureBoxCurseurPokemonStarter.Location = new System.Drawing.Point(86, 590);
            }

        }

        private void btn_pokeball_deuxieme_starter_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.Right)
            {
                e.IsInputKey = true;
            }
        }

        private void btn_pokeball_troisieme_starter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                btn_pokeball_deuxieme_starter.Focus();
                pictureBoxCurseurPokemonStarter.Location = new System.Drawing.Point(154, 590);
            }
            else if (e.KeyCode == Keys.Right)
            {
                btn_pokeball_premier_starter.Focus();
                pictureBoxCurseurPokemonStarter.Location = new System.Drawing.Point(86, 590);
            }
        }

        private void btn_pokeball_troisieme_starter_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.Right)
            {
                e.IsInputKey = true;
            }
        }

        private void btn_choix_garçon_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.Right)
            {
                btn_choix_fille.Focus();
                pictureBoxCurseurChoixSexe.Location = new System.Drawing.Point(159, 205);
            }
        }

        private void btn_choix_garçon_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.Right)
            {
                e.IsInputKey = true;
            }
        }

        private void btn_choix_fille_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.Right)
            {
                btn_choix_garçon.Focus();
                pictureBoxCurseurChoixSexe.Location = new System.Drawing.Point(56, 205);
            }
        }

        private void btn_choix_fille_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.Right)
            {
                e.IsInputKey = true;
            }
        }

        private void btn_choix_fille_Click(object sender, EventArgs e)
        {
            btn_choix_fille.Focus();
            pictureBoxCurseurChoixSexe.Location = new System.Drawing.Point(159, 205);

            DialogResult choixFille = MessageBox.Show("Voulez-vous choisir la fille ? ", "Choix du personnage", MessageBoxButtons.YesNo);

            if (choixFille == DialogResult.No)
            {

            }
            else
            {
                choixPokemonStarter(choixFille);            
            }
        }

        private void btn_choix_garçon_Click(object sender, EventArgs e)
        {
            btn_choix_garçon.Focus();
            pictureBoxCurseurChoixSexe.Location = new System.Drawing.Point(56, 205);

            DialogResult choixGarçon = MessageBox.Show("Voulez-vous choisir le garçon ? ", "Choix du personnage", MessageBoxButtons.YesNo);

            if (choixGarçon == DialogResult.No)
            {

            }
            else
            {
                choixPokemonStarter(choixGarçon);
            }
        }

        private void btn_attaque1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                btn_soigner.Focus();
            }
        }

        private void btn_attaque1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                e.IsInputKey = true;
            }
        }

        private void btn_soigner_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.Right)
            {
                btn_changement_pokemon.Focus();
            }
            else if(e.KeyCode == Keys.Up)
            {
                btn_attaque1.Focus();
            }
        }

        private void btn_soigner_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.Right || e.KeyCode == Keys.Up)
            {
                e.IsInputKey = true;
            }
        }

        private void btn_changement_pokemon_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.Right)
            {
                btn_soigner.Focus();
            }
            else if (e.KeyCode == Keys.Up)
            {
                btn_attaque1.Focus();
            }
        }

        private void btn_changement_pokemon_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.Right || e.KeyCode == Keys.Up)
            {
                e.IsInputKey = true;
            }
        }

        private void btn_pc_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            Form3 fenetrePCPokemon = new Form3(this);

            fenetrePCPokemon.personnageSelectionner(Joueur);
            fenetrePCPokemon.Show();
        }

        private void pictureBoxIconePokemon_Click(object sender, EventArgs e)
        {
            btn_attaque1.PerformClick();
        }

        private void pictureBoxTypeAttaque1_Click(object sender, EventArgs e)
        {
            btn_attaque_une.PerformClick();
        }

        private void pictureBoxTypeAttaque2_Click(object sender, EventArgs e)
        {
            btn_attaque_deux.PerformClick();
        }

        private void pictureBoxTypeAttaque3_Click(object sender, EventArgs e)
        {
            btn_attaque_trois.PerformClick();
        }

        private void pictureBoxTypeAttaque4_Click(object sender, EventArgs e)
        {
            btn_attaque_quatre.PerformClick();
        }

        private void label_pp_attaque_une_Click(object sender, EventArgs e)
        {
            btn_attaque_une.PerformClick();
        }

        private void label_pp_attaque_deux_Click(object sender, EventArgs e)
        {
            btn_attaque_deux.PerformClick();
        }

        private void label_pp_attaque_trois_Click(object sender, EventArgs e)
        {
            btn_attaque_trois.PerformClick();
        }

        private void label_pp_attaque_quatre_Click(object sender, EventArgs e)
        {
            btn_attaque_quatre.PerformClick();
        }

        private void timerAnimationKo_Tick_1(object sender, EventArgs e)
        {
            if (pictureBoxPokemonCombatAdversaire.Location.Y < 81)
            {
                pictureBoxPokemonCombatAdversaire.Location = new Point(pictureBoxPokemonCombatAdversaire.Location.X, pictureBoxPokemonCombatAdversaire.Location.Y + 12);
            }
            else
            {
                timerAnimationAdversaireKo.Stop();
            }
        }

        private void timerAnimationKo_Tick(object sender, EventArgs e)
        {
            if (pictureBoxPokemonCombatJoueur.Location.Y < 81)
            {
                pictureBoxPokemonCombatJoueur.Location = new Point(pictureBoxPokemonCombatJoueur.Location.X, pictureBoxPokemonCombatJoueur.Location.Y + 12);
            }
            else
            {
                timerAnimationKo.Stop();
            }
        }

        private void enregistrerToolStripMenuItem_Click(object sender, EventArgs e)
        {

            SaveFileDialog saveFileDialog = new SaveFileDialog();

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                var cheminFichier = saveFileDialog.FileName;
                XmlWriter writer = XmlWriter.Create(cheminFichier);

                DataContractSerializer serializer = new DataContractSerializer(typeof(ClassLibrary2.Personnage));

                try
                {
                    serializer.WriteObject(writer, Joueur);
                }
                catch(Exception erreur)
                {
                    MessageBox.Show("Impossible de serialiser : " + Environment.NewLine + erreur);
                }

                writer.Close();
            }
        }

        private void label_nom_attaque_une_Click(object sender, EventArgs e)
        {
            btn_attaque_une.PerformClick();
        }

        private void label_nom_attaque_deux_Click(object sender, EventArgs e)
        {
            btn_attaque_deux.PerformClick();
        }

        private void label_nom_attaque_trois_Click(object sender, EventArgs e)
        {
            btn_attaque_trois.PerformClick();
        }

        private void label_nom_attaque_quatre_Click(object sender, EventArgs e)
        {
            btn_attaque_quatre.PerformClick();
        }

        private void ouvrirToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            OpenFileDialog openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                var cheminFichier = openFileDialog.FileName;
                DataContractSerializer serializer = new DataContractSerializer(typeof(ClassLibrary2.Personnage));
                FileStream fs = new FileStream(cheminFichier, FileMode.Open);

                XmlDictionaryReader reader = XmlDictionaryReader.CreateTextReader(fs, new XmlDictionaryReaderQuotas());

                try
                {
                    nombrePokemonAvantChargementSauvegarde = Joueur.getPokemonEquipe().Count;
                    Joueur = (ClassLibrary2.Personnage)serializer.ReadObject(reader);
                    rafraichirApresChargementSauvegarde();

                }
                catch(Exception erreur)
                {
                    MessageBox.Show("Impossible de deserialiser : " + erreur);
                }
                reader.Close();

                
            }
        }

        private void pokemon1_Click(object sender, EventArgs e)
        {
        }

        private void btn_attraper_Click(object sender, EventArgs e)
        {
            int quantiteObjetSuperieurZero = 0;

            if (cb_choix_pokeball.SelectedItem != null)
            {
                cb_choix_pokeball.Items.Remove(cb_choix_pokeball.SelectedItem);
            }
            cb_choix_pokeball.Items.Clear();

            for (int i = 0; i < Joueur.getObjetsSac().Count; i++)
            {
                if (Joueur.getObjetsSac()[i].getQuantiteObjet() > 0 && Joueur.getObjetsSac()[i].getTypeObjet() == "Capture")
                {
                    cb_choix_pokeball.Items.Add(Joueur.getObjetsSac()[i].getNom());
                    quantiteObjetSuperieurZero++;
                }
            }

            if (quantiteObjetSuperieurZero > 0)
            {
                btn_attaque1.Enabled = false;
                btn_attraper.Enabled = false;
                btn_soigner.Enabled = false;
                btn_changement_pokemon.Enabled = false;

                cb_choix_pokeball.Visible = true;
                btn_choix_pokeball.Visible = true;
            }

            else
            {
                MessageBox.Show("Il n'y aucun objet", "Vérification objet", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void label1_Click_4(object sender, EventArgs e)
        {

        }

        private void btn_Soigner_Click(object sender, EventArgs e)
        {
            int quantiteObjetSuperieurZero = 0;

            if (panel_choix_attaque_selection.Visible == true)
            {
                panel_choix_attaque_selection.Visible = false;
            }

            if (cb_choix_objets.SelectedItem != null)
            {
                cb_choix_objets.Items.Remove(cb_choix_objets.SelectedItem);
            }
                cb_choix_objets.Items.Clear();

            for (int i = 0; i < Joueur.getObjetsSac().Count; i++)
            {
                if (Joueur.getObjetsSac()[i].getQuantiteObjet() > 0 && Joueur.getObjetsSac()[i].getTypeObjet() == "Soin")
                {
                    cb_choix_objets.Items.Add(Joueur.getObjetsSac()[i].getNom());
                    quantiteObjetSuperieurZero++;
                }
            }

            if (quantiteObjetSuperieurZero > 0)
            {
                btn_attaque1.Enabled = false;
                btn_attraper.Enabled = false;
                btn_soigner.Enabled = false;
                btn_changement_pokemon.Enabled = false;

                cb_choix_objets.Visible = true;
                btn_choix_objet.Visible = true;
                panel_choix_objets_selection.Visible = true;
            }

            else
            {
                MessageBox.Show("Il n'y aucun objet", "Vérification objet", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btn_choix_objet_Click(object sender, EventArgs e)
        {
            if (cb_choix_objets.SelectedItem != null)
            {
                label_potion.Text = cb_choix_objets.SelectedItem.ToString();

                for (int i = 0; i < Joueur.getObjetsSac().Count; i++)
                {
                    if (cb_choix_objets.SelectedItem.ToString() == Joueur.getObjetsSac()[i].getNom())
                    {
                        label_nb_potion.Text = Joueur.getObjetsSac()[i].getQuantiteObjet().ToString();

                        label_nb_potion.Visible = true;
                        label_potion.Visible = true;

                        if (pokemonJoueurSelectionner.getPvRestant() != pokemonJoueurSelectionner.getPv())
                        {
                            int pvRestantAvantSoin = pokemonJoueurSelectionner.getPvRestant();
                            gagnePvPokemonJoueur = true;
                            compteur = pokemonJoueurSelectionner.getPvRestant();

                            Joueur.getObjetsSac()[i].Soin(pokemonJoueurSelectionner, Joueur.getObjetsSac()[i]);

                            if (pokemonJoueurSelectionner.getPvRestant() + Joueur.getObjetsSac()[i].getValeurObjet() < pokemonJoueurSelectionner.getPv())
                            {
                                textBox1.Text += Environment.NewLine + pokemonJoueurSelectionner.getNom() + " regagne " + Joueur.getObjetsSac()[i].getValeurObjet() + " PV" + Environment.NewLine;
                            }
                            else
                            {
                                int pvObtenu = pokemonJoueurSelectionner.getPvRestant() - pvRestantAvantSoin;
                                textBox1.Text += Environment.NewLine + pokemonJoueurSelectionner.getNom() + " regagne " + pvObtenu + " PV" + Environment.NewLine;
                            }

                            textBox1.Text += pokemonJoueurSelectionner.getNom() + " a " + pokemonJoueurSelectionner.getPvRestant() + " PV" + Environment.NewLine;
                            label_nb_potion.Text = Joueur.getObjetsSac()[i].getQuantiteObjet().ToString();

                            // textBox1.Text += pokemon.getNom() + " sauvage a " + pokemon.getPvRestant() + " PV" + Environment.NewLine;

                            rafraichirBarreViePokemonJoueur();

                            // textBox1.Text += pokemonJoueurSelectionner.getNom() + " a " + pokemonJoueurSelectionner.getPvRestant() + " PV" + Environment.NewLine;

                            cb_choix_objets.Visible = false;
                            btn_choix_objet.Visible = false;

                            panel_choix_objets_selection.Visible = false;

                        

                        }
                        else
                        {
                            MessageBox.Show("Cela n'aura aucun effet", "Le pokemon a tous ses PV", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }
                }

            }

            else
            {
                MessageBox.Show("Choisissez un objet...", "Vérification de l'objet", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureBoxBarreViePokemon_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_attaque1_Click(object sender, EventArgs e)
        {
            panel_choix_attaque_selection.Visible = true;
            gagnePvPokemonJoueur = false;

                if (pokemonJoueurSelectionner.getListeAttaque().Count > 0)
                {
                    if (pokemonJoueurSelectionner.getAttaque1().getNom() != "default")
                    {
                        btn_attaque1.Visible = false; 
                        btn_soigner.Visible = false;
                        btn_changement_pokemon.Visible = false;

                        try
                        {
                            Bitmap pngMenuAttaque = new Bitmap(AppDomain.CurrentDomain.BaseDirectory + "\\Images\\Combat\\menu_attaque.png");
                            pictureBoxMenuCombat.Image = pngMenuAttaque;
                        }
                        catch
                        {
                        MessageBox.Show("L'image du menu d'attaque n'a pas pu être chargée. Veuillez vérifier que celle-ci est bien présente dans le répertoire.", "Vérification de l'image du menu d'attaque", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        if (pokemonJoueurSelectionner.getAttaque1().getPPRestant() <= 0)
                        {
                            btn_attaque_une.Enabled = false;
                        }

                        label_nom_attaque_une.Text = pokemonJoueurSelectionner.getAttaque1().getNom();
                        label_pp_attaque_une.Text = "PP " + pokemonJoueurSelectionner.getAttaque1().getPPRestant() + "/" + pokemonJoueurSelectionner.getAttaque1().getPP();
                     
                        btn_attaque_une.Controls.Add(label_pp_attaque_une);
                        btn_attaque_une.Controls.Add(label_nom_attaque_une);
                       
                        label_pp_attaque_une.Location = new System.Drawing.Point(57, 32);
                        label_pp_attaque_une.Visible = true;
                        label_nom_attaque_une.Location = new System.Drawing.Point(29, 14);
                        label_nom_attaque_une.Visible = true;

                        btn_retour_choix_attaque.Visible = true;

                        string typeAttaque1 = pokemonJoueurSelectionner.getAttaque1().getTypeAttaque();
                        if(typeAttaque1 != null)
                        {
                            try
                            {
                                Bitmap pngAttaque1 = new Bitmap(AppDomain.CurrentDomain.BaseDirectory + "\\Images\\Combat\\bouton_type_" + typeAttaque1 + ".png");
                                btn_attaque_une.Image = pngAttaque1;
                            }
                            catch
                            {
                                MessageBox.Show("L'image du bouton du type de l'attaque une n'a pas pu être chargée. Veuillez vérifier que celle-ci est bien présente dans le répertoire.", "Vérification de l'image du bouton du type de l'attaque une", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }

                            try
                            {
                                Bitmap pngTypeAttaque1 = new Bitmap(AppDomain.CurrentDomain.BaseDirectory + "\\Images\\Types\\" + typeAttaque1 + ".png");
                                pictureBoxTypeAttaque1.Image = pngTypeAttaque1;
                            }
                            catch
                            {
                                MessageBox.Show("L'image du type de l'attaque une n'a pas pu être chargée. Veuillez vérifier que celle-ci est bien présente dans le répertoire.", "Vérification de l'image du type de l'attaque une", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }

                            btn_attaque_une.Controls.Add(pictureBoxTypeAttaque1);
                            pictureBoxTypeAttaque1.Location = new System.Drawing.Point(8, 29);
                            pictureBoxTypeAttaque1.Visible = true;

                        }                     

                        if (pokemonJoueurSelectionner.getListeAttaque().Count > 1)
                        {
                            if (pokemonJoueurSelectionner.getAttaque2().getNom() != "default")
                            {
                                if (pokemonJoueurSelectionner.getAttaque2().getPPRestant() <= 0)
                                {
                                    btn_attaque_deux.Enabled = false;
                                }
                                label_nom_attaque_deux.Text = pokemonJoueurSelectionner.getAttaque2().getNom();
                                label_pp_attaque_deux.Text = "PP " + pokemonJoueurSelectionner.getAttaque2().getPPRestant() + "/" + pokemonJoueurSelectionner.getAttaque2().getPP();
                                
                                btn_attaque_deux.Controls.Add(label_pp_attaque_deux);
                                btn_attaque_deux.Controls.Add(label_nom_attaque_deux);
                              
                                label_pp_attaque_deux.Location = new System.Drawing.Point(57, 32);
                                label_pp_attaque_deux.Visible = true;
                                label_nom_attaque_deux.Location = new System.Drawing.Point(29, 14);
                                label_nom_attaque_deux.Visible = true;

                                string typeAttaque2 = pokemonJoueurSelectionner.getAttaque2().getTypeAttaque();
                                if (typeAttaque2 != null)
                                {
                                    try
                                    {
                                        Bitmap pngAttaque2 = new Bitmap(AppDomain.CurrentDomain.BaseDirectory + "\\Images\\Combat\\bouton_type_" + typeAttaque2 + ".png");
                                        btn_attaque_deux.Image = pngAttaque2;
                                    }
                                    catch
                                    {
                                        MessageBox.Show("L'image du bouton du type de l'attaque deux n'a pas pu être chargée. Veuillez vérifier que celle-ci est bien présente dans le répertoire.", "Vérification de l'image du bouton du type de l'attaque deux", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }

                                    try
                                    {
                                        Bitmap pngTypeAttaque2 = new Bitmap(AppDomain.CurrentDomain.BaseDirectory + "\\Images\\Types\\" + typeAttaque2 + ".png");
                                        pictureBoxTypeAttaque2.Image = pngTypeAttaque2;
                                        pictureBoxTypeAttaque2.Visible = true;
                                    }
                                    catch
                                    {
                                        MessageBox.Show("L'image du type de l'attaque deux n'a pas pu être chargée. Veuillez vérifier que celle-ci est bien présente dans le répertoire.", "Vérification de l'image du type de l'attaque une", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }

                                    btn_attaque_deux.Controls.Add(pictureBoxTypeAttaque2);
                                    pictureBoxTypeAttaque2.Location = new System.Drawing.Point(8, 29);
                                    pictureBoxTypeAttaque2.Visible = true;
                                }

                                if (pokemonJoueurSelectionner.getListeAttaque().Count > 2)
                                {
                                    if (pokemonJoueurSelectionner.getAttaque3().getNom() != "default")
                                    {
                                        if (pokemonJoueurSelectionner.getAttaque3().getPPRestant() <= 0)
                                        {
                                            btn_attaque_trois.Enabled = false;
                                        }

                                        label_nom_attaque_trois.Text = pokemonJoueurSelectionner.getAttaque3().getNom();
                                        label_pp_attaque_trois.Text = "PP " + pokemonJoueurSelectionner.getAttaque3().getPPRestant() + "/" + pokemonJoueurSelectionner.getAttaque3().getPP();

                                        btn_attaque_trois.Controls.Add(label_pp_attaque_trois);
                                        btn_attaque_trois.Controls.Add(label_nom_attaque_trois);                                      

                                        label_pp_attaque_trois.Location = new System.Drawing.Point(57, 32);
                                        label_pp_attaque_trois.Visible = true;

                                        label_nom_attaque_trois.Location = new System.Drawing.Point(29, 14);
                                        label_nom_attaque_trois.Visible = true;

                                        string typeAttaque3 = pokemonJoueurSelectionner.getAttaque3().getTypeAttaque();
                                        if (typeAttaque3 != null)
                                        {
                                            try
                                            {
                                                Bitmap pngAttaque3 = new Bitmap(AppDomain.CurrentDomain.BaseDirectory + "\\Images\\Combat\\bouton_type_" + typeAttaque3 + ".png");
                                                btn_attaque_trois.Image = pngAttaque3;
                                            }
                                            catch
                                            {
                                                MessageBox.Show("L'image du bouton du type de l'attaque trois n'a pas pu être chargée. Veuillez vérifier que celle-ci est bien présente dans le répertoire.", "Vérification de l'image du bouton du type de l'attaque trois", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            }

                                            try
                                            {
                                                Bitmap pngTypeAttaque3 = new Bitmap(AppDomain.CurrentDomain.BaseDirectory + "\\Images\\Types\\" + typeAttaque3 + ".png");
                                                pictureBoxTypeAttaque3.Image = pngTypeAttaque3;
                                                pictureBoxTypeAttaque3.Visible = true;
                                            }
                                            catch
                                            {
                                                MessageBox.Show("L'image du type de l'attaque trois n'a pas pu être chargée. Veuillez vérifier que celle-ci est bien présente dans le répertoire.", "Vérification de l'image du type de l'attaque trois", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            }

                                            btn_attaque_trois.Controls.Add(pictureBoxTypeAttaque3);
                                            pictureBoxTypeAttaque3.Location = new System.Drawing.Point(8, 29);
                                            pictureBoxTypeAttaque3.Visible = true;
                                        }
                                        
                                        if (pokemonJoueurSelectionner.getListeAttaque().Count > 3)
                                        {
                                            if (pokemonJoueurSelectionner.getAttaque4().getNom() != "default")
                                            {
                                                if (pokemonJoueurSelectionner.getAttaque4().getPPRestant() <= 0)
                                                {
                                                    btn_attaque_quatre.Enabled = false;
                                                }
                                                label_nom_attaque_quatre.Text = pokemonJoueurSelectionner.getAttaque4().getNom();
                                                label_pp_attaque_quatre.Text = "PP " + pokemonJoueurSelectionner.getAttaque4().getPPRestant() + "/" + pokemonJoueurSelectionner.getAttaque4().getPP();

                                                btn_attaque_quatre.Controls.Add(label_pp_attaque_quatre);
                                                btn_attaque_quatre.Controls.Add(label_nom_attaque_quatre);

                                                label_pp_attaque_quatre.Location = new System.Drawing.Point(57, 32);
                                                label_pp_attaque_quatre.Visible = true;
                                                label_nom_attaque_quatre.Location = new System.Drawing.Point(29, 14);
                                                label_nom_attaque_quatre.Visible = true;

                                                string typeAttaque4 = pokemonJoueurSelectionner.getAttaque4().getTypeAttaque();
                                                if (typeAttaque4 != null)
                                                {
                                                    try
                                                    {
                                                        Bitmap pngAttaque4 = new Bitmap(AppDomain.CurrentDomain.BaseDirectory + "\\Images\\Combat\\bouton_type_" + typeAttaque4 + ".png");
                                                        btn_attaque_quatre.Image = pngAttaque4;
                                                    }
                                                    catch
                                                    {
                                                        MessageBox.Show("L'image du bouton du type de l'attaque quatre n'a pas pu être chargée. Veuillez vérifier que celle-ci est bien présente dans le répertoire.", "Vérification de l'image du bouton du type de l'attaque quatre", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                    }

                                                    try
                                                    {
                                                        Bitmap pngTypeAttaque4 = new Bitmap(AppDomain.CurrentDomain.BaseDirectory + "\\Images\\Types\\" + typeAttaque4 + ".png");
                                                        pictureBoxTypeAttaque4.Image = pngTypeAttaque4;
                                                        pictureBoxTypeAttaque4.Visible = true;
                                                    }
                                                    catch
                                                    {
                                                        MessageBox.Show("L'image du type de l'attaque quatre n'a pas pu être chargée. Veuillez vérifier que celle-ci est bien présente dans le répertoire.", "Vérification de l'image du type de l'attaque quatre", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                    }

                                                    btn_attaque_quatre.Controls.Add(pictureBoxTypeAttaque4);
                                                    pictureBoxTypeAttaque4.Location = new System.Drawing.Point(8, 29);
                                                    pictureBoxTypeAttaque4.Visible = true;
                                                }
                                                
                                            }
                                            btn_attaque_quatre.Visible = true;
                                        }
                                    }
                                btn_attaque_trois.Visible = true;
                                }
                                
                            }
                            btn_attaque_deux.Visible = true;
                    }
                    btn_attaque_une.Visible = true;
                    btn_attaque_une.Focus();
                }
                    else
                    {
                        MessageBox.Show("Le pokemon n'a aucune attaque", "Vérification des attaques", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                else
                {
                    MessageBox.Show("Le pokemon n'a aucune attaque", "Vérification des attaques", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
        }


        private void btn_attaque_une_Click(object sender, EventArgs e)
        {
            if (btn_choix_objet.Visible = true && cb_choix_objets.Visible == true)
            {
                btn_choix_objet.Visible = false;
                cb_choix_objets.Visible = false;
            }

            if (btn_attaque1.Enabled == true && btn_soigner.Enabled == true && btn_attraper.Enabled == true)
            {
                btn_attaque1.Enabled = false;
                btn_soigner.Enabled = false;
                btn_attraper.Enabled = false;
                btn_changement_pokemon.Enabled = false;
            }

            attaqueCombat(pokemonJoueurSelectionner.getAttaque1());
            changementMenuAttaqueCombat();

          //  MessageBox.Show(pokemon.getAttaqueChangementStatutPokemonAdverseReussi(pokemonJoueurSelectionner.getAttaque1()).ToString());
          //  MessageBox.Show(pokemon.getStatutPokemon());
        }

        private void btn_attaque_deux_Click(object sender, EventArgs e)
        {
            if (btn_choix_objet.Visible = true && cb_choix_objets.Visible == true)
            {
                btn_choix_objet.Visible = false;
                cb_choix_objets.Visible = false;
            }

            if (btn_attaque1.Enabled == true && btn_soigner.Enabled == true && btn_attraper.Enabled == true)
            {
                btn_attaque1.Enabled = false;
                btn_soigner.Enabled = false;
                btn_attraper.Enabled = false;
                btn_changement_pokemon.Enabled = false;
            }

            attaqueCombat(pokemonJoueurSelectionner.getAttaque2());
            changementMenuAttaqueCombat();
        }

        private void btn_attaque_trois_Click(object sender, EventArgs e)
        {
            if (btn_choix_objet.Visible = true && cb_choix_objets.Visible == true)
            {
                btn_choix_objet.Visible = false;
                cb_choix_objets.Visible = false;
            }

            if (btn_attaque1.Enabled == true && btn_soigner.Enabled == true && btn_attraper.Enabled == true)
            {
                btn_attaque1.Enabled = false;
                btn_soigner.Enabled = false;
                btn_attraper.Enabled = false;
                btn_changement_pokemon.Enabled = false;
            }

            attaqueCombat(pokemonJoueurSelectionner.getAttaque3());
            changementMenuAttaqueCombat();
        }

        private void btn_attaque_quatre_Click(object sender, EventArgs e)
        {
            if (btn_choix_objet.Visible = true && cb_choix_objets.Visible == true)
            {
                btn_choix_objet.Visible = false;
                cb_choix_objets.Visible = false;
            }

            if (btn_attaque1.Enabled == true && btn_soigner.Enabled == true && btn_attraper.Enabled == true)
            {
                btn_attaque1.Enabled = false;
                btn_soigner.Enabled = false;
                btn_attraper.Enabled = false;
                btn_changement_pokemon.Enabled = false;
            }

            attaqueCombat(pokemonJoueurSelectionner.getAttaque4());
            changementMenuAttaqueCombat();
        }

        private void pictureBoxBarreViePokemonAdversaire_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_3(object sender, EventArgs e)
        {
            // MessageBox.Show("Changer de pokemon ?", "Changer de pokemon", MessageBoxButtons.YesNo);

            if (panel_choix_attaque_selection.Visible == true)
            {
                panel_choix_attaque_selection.Visible = false;
            }

            btn_attaque1.Enabled = false;
            btn_attraper.Enabled = false;
            btn_soigner.Enabled = false;
            panel_choix_pokemon_selection.Visible = true;
            btn_changement_pokemon.Enabled = false; 
        }

        private void button1_Click_4(object sender, EventArgs e)
        {
            var checkedButton = panel_choix_pokemon_selection.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked);

            if (checkedButton != null)
            {

                if (checkedButton == radioBtn_pokemon[0])
                {
                    if (Joueur.getPokemonEquipe()[0].getPvRestant() <= 0)
                    {
                        MessageBox.Show("Le pokemon est K.O.");
                    }

                    else if (pokemonJoueurSelectionner == Joueur.getPokemonEquipe()[0])
                    {
                        MessageBox.Show("Le pokemon est déjà sur le terrain");
                    }

                    else
                    {
                        pokemonJoueurSelectionner = Joueur.getPokemonEquipe()[0];

                        textBox1.Text += pokemonJoueurSelectionner.getNom() + " est entré sur le terrain " + Environment.NewLine;

                        changementPokemon();

                        ClassLibrary2.Attaque attaqueLancerAdversaire = pokemon.attaqueAdversaire(pokemon, pokemonJoueurSelectionner);
                        attaqueCombatAdversaire(attaqueLancerAdversaire);

                    }
                }

                else if (checkedButton == radioBtn_pokemon[1])
                {
                    if (Joueur.getPokemonEquipe()[1].getPvRestant() <= 0)
                    {
                        MessageBox.Show("Le pokemon est K.O.");
                    }

                    else if (pokemonJoueurSelectionner == Joueur.getPokemonEquipe()[1])
                    {
                        MessageBox.Show("Le pokemon est déjà sur le terrain");
                    }

                    else
                    {
                        pokemonJoueurSelectionner = Joueur.getPokemonEquipe()[1];

                        textBox1.Text += pokemonJoueurSelectionner.getNom() + " est entré sur le terrain " + Environment.NewLine;
                    
                        changementPokemon();

                        ClassLibrary2.Attaque attaqueLancerAdversaire = pokemon.attaqueAdversaire(pokemon, pokemonJoueurSelectionner);
                        attaqueCombatAdversaire(attaqueLancerAdversaire);
                    }
                }

                else if (checkedButton == radioBtn_pokemon[2])
                {
                   

                    if (Joueur.getPokemonEquipe()[2].getPvRestant() <= 0)
                    {
                        MessageBox.Show("Le pokemon est K.O.");
                    }

                    else if (pokemonJoueurSelectionner == Joueur.getPokemonEquipe()[2])
                    {
                        MessageBox.Show("Le pokemon est déjà sur le terrain");
                    }

                    else
                    {
                        pokemonJoueurSelectionner = Joueur.getPokemonEquipe()[2];

                        textBox1.Text += pokemonJoueurSelectionner.getNom() + " est entré sur le terrain " + Environment.NewLine;
                      
                        changementPokemon();

                        ClassLibrary2.Attaque attaqueLancerAdversaire = pokemon.attaqueAdversaire(pokemon, pokemonJoueurSelectionner);
                        attaqueCombatAdversaire(attaqueLancerAdversaire);
                    }
                }

                else if (checkedButton == radioBtn_pokemon[3])
                {
                    if (Joueur.getPokemonEquipe()[3].getPvRestant() <= 0)
                    {
                        MessageBox.Show("Le pokemon est K.O.");
                    }
                    else if (pokemonJoueurSelectionner == Joueur.getPokemonEquipe()[3])
                    {
                        MessageBox.Show("Le pokemon est déjà sur le terrain");
                    }

                    else
                    {
                        pokemonJoueurSelectionner = Joueur.getPokemonEquipe()[3];

                        textBox1.Text += pokemonJoueurSelectionner.getNom() + " est entré sur le terrain " + Environment.NewLine;

                        changementPokemon();

                        ClassLibrary2.Attaque attaqueLancerAdversaire = pokemon.attaqueAdversaire(pokemon, pokemonJoueurSelectionner);
                        attaqueCombatAdversaire(attaqueLancerAdversaire);
                    }
                }

                else if (checkedButton == radioBtn_pokemon[4])
                {
                    
                    if (Joueur.getPokemonEquipe()[4].getPvRestant() <= 0)
                    {
                        MessageBox.Show("Le pokemon est K.O.");
                    }
                    else if (pokemonJoueurSelectionner == Joueur.getPokemonEquipe()[4])
                    {
                        MessageBox.Show("Le pokemon est déjà sur le terrain");
                    }
                    else
                    {
                        pokemonJoueurSelectionner = Joueur.getPokemonEquipe()[4];

                        textBox1.Text += pokemonJoueurSelectionner.getNom() + " est entré sur le terrain " + Environment.NewLine;

                        changementPokemon();

                        ClassLibrary2.Attaque attaqueLancerAdversaire = pokemon.attaqueAdversaire(pokemon, pokemonJoueurSelectionner);
                        attaqueCombatAdversaire(attaqueLancerAdversaire);
                    }
                }

                else if (checkedButton == radioBtn_pokemon[5])
                { 
                    if (Joueur.getPokemonEquipe()[5].getPvRestant() <= 0)
                    {
                        MessageBox.Show("Le pokemon est K.O.");
                    }
                    else if (pokemonJoueurSelectionner == Joueur.getPokemonEquipe()[5])
                    {
                        MessageBox.Show("Le pokemon est déjà sur le terrain");
                    }
                    else
                    {
                        pokemonJoueurSelectionner = Joueur.getPokemonEquipe()[5];

                        textBox1.Text += pokemonJoueurSelectionner.getNom() + " est entré sur le terrain " + Environment.NewLine;
         
                        changementPokemon();

                        ClassLibrary2.Attaque attaqueLancerAdversaire = pokemon.attaqueAdversaire(pokemon, pokemonJoueurSelectionner);
                        attaqueCombatAdversaire(attaqueLancerAdversaire);
                    }
                }


               // rafraichirBarreViePokemonJoueur();

            }
            else
            {
                MessageBox.Show("Selectionnez un pokémon", "Changement de pokemon", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmSaisiesBoutons_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.A || e.KeyCode == Keys.Enter) && showStatistiquesAugmenter == true)
            {
                // groupBoxNiveauSuperieurStatistiques.Visible = false;
                showStatistiquesAugmenter = false;
                showStatistiquesNiveauSuivant = true;

                label_pv_changement_niveau.Text = "PV :                          " + pokemonJoueurSelectionner.getPv();
                label_attaque_changement_niveau.Text = "Attaque :                  " + pokemonJoueurSelectionner.getStatistiquesAttaque();
                label_defense_changement_niveau.Text = "Défense :                 " + pokemonJoueurSelectionner.getStatistiquesDefense();
                label_vitesse_changement_niveau.Text = "Vitesse :                   " + pokemonJoueurSelectionner.getStatistiquesVitesse();
                label_attaque_speciale_changement_niveau.Text = "Attaque Spéciale :   " + pokemonJoueurSelectionner.getStatistiquesAttaqueSpeciale();
                label_defense_speciale_changement_niveau.Text = "Défense Spéciale :  " + pokemonJoueurSelectionner.getStatistiquesDefenseSpeciale();
            }
            
            else if ((e.KeyCode == Keys.A || e.KeyCode == Keys.Enter) && showStatistiquesAugmenter == false && showStatistiquesNiveauSuivant == true)
            {
                showStatistiquesNiveauSuivant = false;
                groupBoxNiveauSuperieurStatistiques.Visible = false;
                combat_btn.Enabled = true;
                combat_btn.Focus();
            }
           
        }

        private void textBoxSaisie_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonAfficher.PerformClick();
            }
        }

        private void textBoxAge_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonAfficher.PerformClick();
            }
        }

        private void cb_choix_pokemon_depart_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
               
            }
        }

        private void btn_attaque_une_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                btn_attaque_trois.Focus();
            }
            else if(e.KeyCode == Keys.Right)
            {
                btn_attaque_deux.Focus();
            }
            else if(e.KeyCode == Keys.Escape)
            {
                btn_retour_choix_attaque.PerformClick();
            }
        }

        private void btn_choix_pokeball_Click(object sender, EventArgs e)
        {
            /*
            if (Joueur.getPokemonEquipe().Count < 6)
            { */
                /*
                pictureBoxPokemonCombatAdversaire.Controls.Add(pictureBox1);
                pictureBox1.Location = new Point(0, 0);
                pictureBox1.BackColor = Color.Transparent; */

                btn_choix_pokeball.Visible = false;
                cb_choix_pokeball.Visible = false; 

                if(pokemonJoueurSelectionner.getStatutPokemon() == "Sommeil")
                {
                    nombreTourSommeil++;
                }

                pictureBoxPokeball = new PictureBox();
                pictureBoxPokeball.Size = new Size(40, 40); 
                this.Controls.Add(pictureBoxPokeball);

                pictureBoxPokeball.Location = new System.Drawing.Point(900, 415);

                this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

                try
                {
                    Bitmap pngPokeball = new Bitmap(AppDomain.CurrentDomain.BaseDirectory + "\\Images\\" + "Pokeball\\" + cb_choix_pokeball.SelectedItem + "_1" + ".png");
                    pictureBoxPokeball.Image = pngPokeball;
                }
                catch
                {
                    MessageBox.Show("L'image de la ball n'a pas pu être chargée. Veuillez vérifier que celle-ci est bien présente dans le répertoire.", "Vérification de l'image de la ball", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            // pictureBoxPokeball.Image.RotateFlip(RotateFlipType.Rotate180FlipY);
                pictureBoxPokeball.SizeMode = PictureBoxSizeMode.CenterImage;
                pictureBoxPokeball.BringToFront();

                // MessageBox.Show(pokemon.getTauxCaptureModifier(db.selectionObjet(cb_choix_pokeball.SelectedItem.ToString())).ToString());

               // MessageBox.Show(pokemon.probabiliteMouvementsBall(pokemon.getTauxCaptureModifier(db.selectionObjet(cb_choix_pokeball.SelectedItem.ToString()))).ToString());
                // MessageBox.Show(pokemon.nombreMouvementsBall(pokemon.probabiliteMouvementsBall(pokemon.getTauxCaptureModifier(db.selectionObjet(cb_choix_pokeball.SelectedItem.ToString())))).ToString());

                ClassLibrary2.Objet ball = new ClassLibrary2.Objet();
                nombreMouvementsBall = pokemon.nombreMouvementsBall(pokemon.probabiliteMouvementsBall(pokemon.getTauxCaptureModifier(ball.setChercherObjet(cb_choix_pokeball.SelectedItem.ToString(), jeu))));

              //  MessageBox.Show(nombreMouvementsBall.ToString());

                textBox1.Text += Environment.NewLine + Joueur.getNom() + " utilise " + cb_choix_pokeball.SelectedItem.ToString() + Environment.NewLine;

                rafraichirAnimationCapture(); // Bug parfois pokemon attaque après que le pokemon se soit libéré
            /*
            }
            
            else
            {
                MessageBox.Show("Vous n'avez plus de place pour attraper un pokemon");
            }
            */
        }

        private void btn_attaque_une_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if(e.KeyCode == Keys.Down || e.KeyCode == Keys.Right)
            {
                e.IsInputKey = true;
            }
        }

        private void btn_attaque_deux_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                btn_attaque_quatre.Focus();
            }
            else if (e.KeyCode == Keys.Left)
            {
                btn_attaque_une.Focus();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                btn_retour_choix_attaque.PerformClick();
            }
        }

        private void frmSaisiesBoutons_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.IsInputKey = true;
            }
        }

        private void timerAnimationCapture_Tick(object sender, EventArgs e)
        {
            // double positionX = 800 + Math.Cos(compteurAnimationCapture); animation capture
            if (compteurAnimationCapturePartie1 <= 8)
            {
                compteurAnimationCapturePartie1++;
            }

            double positionX = 900 + ((compteurAnimationCapturePartie1 - 1) * 16);
            double positionY = 415 - (Math.Log(compteurAnimationCapturePartie1) * 50);

            if (positionX < 1039 && positionY > 312)
            {

                pictureBoxPokeball.Location = new System.Drawing.Point((int)positionX, (int)positionY);
            }
            else if(compteurAnimationCapturePartie1 >= 8 && compteurAnimationCapturePartie2 < 5)
            {
                // pictureBoxPokeball.Parent = pictureBoxPokemonCombatAdversaire;
                // pictureBoxPokeball.Location = new Point(0, 0);
                // pictureBoxPokeball.BackColor = Color.Transparent;
                try
                {
                    Bitmap pngPokeball = new Bitmap(AppDomain.CurrentDomain.BaseDirectory + "\\Images\\" + "Pokeball\\" + cb_choix_pokeball.SelectedItem + "_2" + ".png");
                    pictureBoxPokeball.Image = pngPokeball;
                }
                catch
                {
                    // MessageBox.Show("L'image de la ball n'a pas pu être chargée. Veuillez vérifier que celle-ci est bien présente dans le répertoire.", "Vérification de l'image de la ball", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                compteurAnimationCapturePartie2++;
            }
            else if(compteurAnimationCapturePartie1 >= 8 && compteurAnimationCapturePartie2 >= 5 && compteurAnimationCapturePartie3 < 9)
            {
                if (compteurAnimationCapturePartie2 == 5)
                {
                    pictureBoxPokemonCombatAdversaire.Visible = false;
                    try
                    {
                        Bitmap pngPokeball = new Bitmap(AppDomain.CurrentDomain.BaseDirectory + "\\Images\\" + "Pokeball\\" + cb_choix_pokeball.SelectedItem + "_1" + ".png");
                        pictureBoxPokeball.Image = pngPokeball;
                    }
                    catch
                    {
                       // MessageBox.Show("L'image du type de la ball n'a pas pu être chargée. Veuillez vérifier que celle-ci est bien présente dans le répertoire.", "Vérification de l'image de la ball", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                pictureBoxPokeball.Location = new System.Drawing.Point((int)positionX, (int)positionY + ((int)compteurAnimationCapturePartie3 * 2));

                compteurAnimationCapturePartie3++;
            }
            else if(compteurAnimationCapturePartie3 >= 9 && compteurAnimationCapturePartie5 < 9)
            {
                // nombreMouvementsBall = 2;
                if (nombreMouvementsBall == 0)
                {
                   // pictureBoxPokeball.Location = new System.Drawing.Point(1032, 321);
               
                    compteurAnimationCapturePartie5 = 15;
                }

                else if (nombreMouvementsBall > 0)
                {
                    pictureBoxPokeball.Location = new System.Drawing.Point(900 + (((int)compteurAnimationCapturePartie1 - 1) * 16) + (int)Math.Cos(compteurAnimationCapturePartie4) * 4, (int)positionY + (((int)compteurAnimationCapturePartie3 - 1) * 2));
                   // MessageBox.Show(pictureBoxPokeball.Location.ToString());
                    if (compteurAnimationCapturePartie4 % 2 == 0)
                    {
                        compteurAnimationCapturePartie4++;
                    }
                    else
                    {
                        compteurAnimationCapturePartie4--;
                    }
                   
                    if (compteurAnimationCapturePartie5 == 2 && nombreMouvementsBall == 1)
                    {
                        compteurAnimationCapturePartie5 = 15;
                    }
                    
                    else if (compteurAnimationCapturePartie5 == 4 && nombreMouvementsBall == 2)
                    {
                        compteurAnimationCapturePartie5 = 15;
                    }
                    else if (compteurAnimationCapturePartie5 == 6 && nombreMouvementsBall == 3)
                    {
                        compteurAnimationCapturePartie5 = 15;
                    } 

                    if (compteurAnimationCapturePartie5 < 9)
                    {
                        compteurAnimationCapturePartie5++;
                    }
                }
            }
            else if(compteurAnimationCapturePartie5 == 15 && compteurAnimationCapturePartie6 < 11)
            {
                compteurAnimationCapturePartie6++;
            }

            else if(compteurAnimationCapturePartie6 == 11 && compteurAnimationCapturePartie7 < 5)
            {
                if (compteurAnimationCapturePartie7 == 0)
                {
                    try
                    {
                        Bitmap pngPokeball = new Bitmap(AppDomain.CurrentDomain.BaseDirectory + "\\Images\\" + "Pokeball\\" + cb_choix_pokeball.SelectedItem + "_2" + ".png");
                        pictureBoxPokeball.Image = pngPokeball;
                    }
                    catch
                    {
                        // MessageBox.Show("L'image du type de la ball n'a pas pu être chargée. Veuillez vérifier que celle-ci est bien présente dans le répertoire.", "Vérification de l'image de la ball", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
               
                compteurAnimationCapturePartie7++;
            }
            else if(compteurAnimationCapturePartie7 == 5 && compteurAnimationCapturePartie8 < 7)
            {
                if (compteurAnimationCapturePartie8 == 0) {
                     pictureBoxPokemonCombatAdversaire.Visible = true;
                     pictureBoxPokeball.Parent = pictureBoxPokemonCombatAdversaire;

                     if (nombreMouvementsBall > 0)
                     {
                        pictureBoxPokeball.Location = new Point(2, 21);
                     }
                    else
                    {
                        pictureBoxPokeball.Location = new Point(-2, 21);
                    }
                }
                else if(compteurAnimationCapturePartie8 == 5)
                {
                    pictureBoxPokeball.Visible = false;
                }

                Bitmap bmp = (Bitmap)pictureBoxPokemonCombatAdversaire.Image;
                Color cTransparent = Color.FromArgb(0, 0, 0, 0);
                Color cWhite = Color.FromArgb(255, 184, 24, 0);
                Color cBlack = Color.FromArgb(255, 0, 0, 0);

                for (int y = 0; y < bmp.Height; y++)
                {
                    for (int x = 0; x < bmp.Width; x++)
                    {
                        Color c = bmp.GetPixel(x, y);
                        if (c != cTransparent)
                        {
                            if(compteurAnimationCapturePartie8 < 6)
                            {
                                int transparenceAnimation = (40 * (int)compteurAnimationCapturePartie8) + 1;
                                bmp.SetPixel(x, y, Color.FromArgb(transparenceAnimation, c.R, c.G, c.B));
                            }
                            else
                            {
                                bmp.SetPixel(x, y, Color.FromArgb(255, c.R, c.G, c.B));
                            }
                        } 
                    }
                }

                pictureBoxPokemonCombatAdversaire.Image = (Bitmap)bmp;

                compteurAnimationCapturePartie8++;

            }

            else
            {
                if (nombreMouvementsBall == 4)
                {
                    Bitmap bmp = (Bitmap)pictureBoxPokeball.Image;
                    Color cTransparent = Color.FromArgb(0, 0, 0, 0);
                    Color cBlack = Color.FromArgb(255, 0, 56, 0);
                    Color cWhite = Color.FromArgb(255, 184, 24, 0);
                    Color cGray = Color.FromArgb(255, 160, 160, 160);

                    for (int y = 0; y < bmp.Height; y++)
                    {
                        for (int x = 0; x < bmp.Width; x++)
                        {
                            Color c = bmp.GetPixel(x, y);
                            if (c != cTransparent)
                            {
                                bmp.SetPixel(x, y, Color.FromArgb(255, c.R / 2, c.G / 2, c.B / 2));
                            }
                        }
                    }
                    pictureBoxPokeball.Image = (Bitmap)bmp;

                    timerAnimationCapture.Stop();
                    label_pv_pokemon_combat_adversaire.Text = "Attrapé";

                    string pokemonEnvoi = Joueur.attraperPokemon(pokemon);
                    // pokemon.setIdPokemon(pokemon);

                    textBox1.Text += "Et hop ! " + pokemon.getNom() + " est attrapé !" + Environment.NewLine;

                    combat_btn.Enabled = true;
                    btn_pc.Enabled = true;
                    btn_attaque1.Enabled = false;
                    btn_attraper.Enabled = false;
                    btn_soigner.Enabled = false;
                    btn_changement_pokemon.Enabled = false;
                    panel_choix_attaque_selection.Visible = false;
                    panel_choix_pokemon_selection.Visible = false;

                    Graphics gBarreAdversaire = Graphics.FromImage(DrawAreaPokemonAdversaire);
                    gBarreAdversaire.Clear(SystemColors.Control);
                    pictureBoxBarreViePokemonAdversaire.Image = DrawAreaPokemonAdversaire;
                    gBarreAdversaire.Dispose();

                    if (pokemonEnvoi == "Equipe")
                    {
                        label_pokemon[Joueur.getPokemonEquipe().Count - 1].Text = Joueur.getPokemonEquipe()[Joueur.getPokemonEquipe().Count - 1].getNom();
                        label_pv_pokemon[Joueur.getPokemonEquipe().Count - 1].Text = Joueur.getPokemonEquipe()[Joueur.getPokemonEquipe().Count - 1].getPvRestant().ToString() + " / " + Joueur.getPokemonEquipe()[Joueur.getPokemonEquipe().Count - 1].getPv().ToString() + " PV";

                        label_pokemon[Joueur.getPokemonEquipe().Count - 1].Visible = true;
                        label_pv_pokemon[Joueur.getPokemonEquipe().Count - 1].Visible = true;
                        radioBtn_pokemon[Joueur.getPokemonEquipe().Count - 1].Visible = true;

                        // pokemon.setPvRestant(0);
                        // rafraichirBarreViePokemonAdversaire1();

                        int idPokedexImage = Joueur.getPokemonEquipe()[Joueur.getPokemonEquipe().Count - 1].getNoIdPokedex();
                        try
                        {
                            Bitmap png = new Bitmap(AppDomain.CurrentDomain.BaseDirectory + "\\Images\\" + idPokedexImage + ".png");
                            pictureBoxPokemon[Joueur.getPokemonEquipe().Count - 1].Image = png;
                            pictureBoxPokemon[Joueur.getPokemonEquipe().Count - 1].Image.RotateFlip(RotateFlipType.Rotate180FlipY);
                        }
                        catch
                        {
                            MessageBox.Show("L'image du pokémon n'a pas pu être chargée. Veuillez vérifier que celle-ci est bien présente dans le répertoire.", "Vérification de l'image du pokémon", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    else
                    {
                        textBox1.Text += pokemon.getNom() + " est envoyé dans le PC !" + Environment.NewLine;
                    }

                    compteurAnimationCapturePartie1 = 0;
                    compteurAnimationCapturePartie2 = 0;
                    compteurAnimationCapturePartie3 = 0;
                    compteurAnimationCapturePartie4 = 0;
                    compteurAnimationCapturePartie5 = 0;
                    nombreMouvementsBall = 0;
                    nombreTourStatutAdversaire = 0;
                    nombreTourSommeilAdversaire = 0;
                    nombreTourStatutAEffectuerAdversaire = 0;
                }
                else
                {
                    //  pictureBoxPokemonCombatAdversaire.Visible = true;

                    timerAnimationCapture.Stop();

                    rafraichirBarreViePokemonJoueur();

                    if (nombreMouvementsBall == 0)
                    {
                        textBox1.Text += "Oh, non ! Le Pokémon s'est libéré" + Environment.NewLine;
                    }
                    else if(nombreMouvementsBall == 1)
                    {
                        textBox1.Text += "Raaah ça y était presque !" + Environment.NewLine;
                    }
                    else if (nombreMouvementsBall == 2)
                    {
                        textBox1.Text += "Aaaaaah ! Presque !" + Environment.NewLine;
                    }
                    else if (nombreMouvementsBall == 3)
                    {
                        textBox1.Text += "Mince ! ça y était presque !" + Environment.NewLine;
                    }

                    compteurAnimationCapturePartie1 = 0;
                    compteurAnimationCapturePartie2 = 0;
                    compteurAnimationCapturePartie3 = 0;
                    compteurAnimationCapturePartie4 = 0;
                    compteurAnimationCapturePartie5 = 0;
                    compteurAnimationCapturePartie6 = 0;
                    compteurAnimationCapturePartie7 = 0;
                    compteurAnimationCapturePartie8 = 0;
                }
            }
        }

        private void btn_attaque_deux_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Left)
            {
                e.IsInputKey = true;
            }
        }

        private void btn_attaque_trois_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down || e.KeyCode == Keys.Right)
            {
                e.IsInputKey = true;
            }
        }

        private void btn_attaque_trois_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                btn_attaque_une.Focus();
            }
            else if (e.KeyCode == Keys.Right)
            {
                btn_attaque_quatre.Focus();
            }
            else if (e.KeyCode == Keys.Down)
            {
                btn_retour_choix_attaque.Focus();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                btn_retour_choix_attaque.PerformClick();
            }
        }

        private void btn_attaque_quatre_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down || e.KeyCode == Keys.Left)
            {
                e.IsInputKey = true;
            }
        }

        private void btn_attaque_quatre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                btn_attaque_deux.Focus();
            }
            else if (e.KeyCode == Keys.Left)
            {
                btn_attaque_trois.Focus();
            }
            else if (e.KeyCode == Keys.Down)
            {
                btn_retour_choix_attaque.Focus();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                btn_retour_choix_attaque.PerformClick();
            }
        }

        private void btn_retour_choix_attaque_Click(object sender, EventArgs e)
        {
            panel_choix_attaque_selection.Visible = false;

            changementMenuAttaqueCombat();

            try
            {
                Bitmap pngMenuCombat = new Bitmap(AppDomain.CurrentDomain.BaseDirectory + "\\Images\\Combat\\menu_combat.png");
                pictureBoxMenuCombat.Image = pngMenuCombat;
            }
            catch
            {
                MessageBox.Show("L'image du menu du combat n'a pas pu être chargée. Veuillez vérifier que celle-ci est bien présente dans le répertoire.", "Vérification de l'image du menu de combat", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            btn_attaque1.Visible = true;
            btn_soigner.Visible = true;
            btn_changement_pokemon.Visible = true;

            btn_attaque1.Focus();
        }

        private void btn_retour_choix_attaque_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                btn_retour_choix_attaque.PerformClick();
            }
        }

        private void groupBoxPokemon_Enter(object sender, EventArgs e)
        {

        }

        private void timerBarreExperiencePokemonJoueur_Tick(object sender, EventArgs e)
        {
            Graphics gBarreExperience;
            gBarreExperience = Graphics.FromImage(DrawAreaExperiencePokemonJoueur);
            System.Drawing.SolidBrush fillBlue = new System.Drawing.SolidBrush(Color.Blue);
            Pen black = new Pen(Color.Black);
            pictureBoxBarreExperiencePokemonJoueur.Image = DrawAreaExperiencePokemonJoueur;

            int pourcentageBarreExperience = (100 * (pokemonJoueurSelectionner.getExperience() - pokemonJoueurSelectionner.getExperiencePokemonReturn())) / (pokemonJoueurSelectionner.getExperiencePokemonProchainNiveau() - pokemonJoueurSelectionner.getExperiencePokemonReturn());

            if (compteurExperience <= pourcentageBarreExperience)
            {

                gBarreExperience.Clear(SystemColors.Control);
                gBarreExperience.DrawRectangle(black, 0, 0, 100, 15);
                // 100 * (pokemonJoueurSelectionner.getExperience() - pokemonJoueurSelectionner.getExperiencePokemonReturn())) / (pokemonJoueurSelectionner.getExperiencePokemonProchainNiveau() - pokemonJoueurSelectionner.getExperiencePokemonReturn())
                gBarreExperience.FillRectangle(fillBlue, 0, 0, ((100 * (pokemonJoueurSelectionner.getExperience() - pokemonJoueurSelectionner.getExperiencePokemonReturn())) / (pokemonJoueurSelectionner.getExperiencePokemonProchainNiveau() - pokemonJoueurSelectionner.getExperiencePokemonReturn())) - (pourcentageBarreExperience - compteurExperience) , 15);
                pictureBoxBarreViePokemonJoueur.Image = DrawAreaPokemonJoueur;

                compteurExperience += (pokemonJoueurSelectionner.getExperiencePokemonProchainNiveau() - pokemonJoueurSelectionner.getExperiencePokemonReturn()) / (pokemonJoueurSelectionner.getExperiencePokemonProchainNiveau() - pokemonJoueurSelectionner.getExperiencePokemonReturn());

                if (compteurExperience >= 100)
                {
                    compteurExperience = 0;

                    int nbViePokemonAvant = pokemonJoueurSelectionner.getPv();
                    int statistiquesAttaquePokemonAvant = pokemonJoueurSelectionner.getStatistiquesAttaque();
                    int statistiquesDefensePokemonAvant = pokemonJoueurSelectionner.getStatistiquesDefense();
                    int statistiquesVitessePokemonAvant = pokemonJoueurSelectionner.getStatistiquesVitesse();
                    int statistiquesAttaqueSpecialePokemonAvant = pokemonJoueurSelectionner.getStatistiquesAttaqueSpeciale();
                    int statistiquesDefenseSpecialePokemonAvant = pokemonJoueurSelectionner.getStatistiquesDefenseSpeciale();

                    pokemonJoueurSelectionner.setNiveau(pokemonJoueurSelectionner.getNiveau() + 1);

                    int nbviePokemonApres = pokemonJoueurSelectionner.getPv();
                    int statistiquesAttaquePokemonApres = pokemonJoueurSelectionner.getStatistiquesAttaque();
                    int statistiquesDefensePokemonApres = pokemonJoueurSelectionner.getStatistiquesDefense();
                    int statistiquesVitessePokemonApres = pokemonJoueurSelectionner.getStatistiquesVitesse();
                    int statistiquesAttaqueSpecialePokemonApres = pokemonJoueurSelectionner.getStatistiquesAttaqueSpeciale();
                    int statistiquesDefenseSpecialePokemonApres = pokemonJoueurSelectionner.getStatistiquesDefenseSpeciale();

                    int nbPvGagner = nbviePokemonApres - nbViePokemonAvant;
                    int statistiquesAttaqueGagner = statistiquesAttaquePokemonApres - statistiquesAttaquePokemonAvant;
                    int statistiquesDefenseGagner = statistiquesDefensePokemonApres - statistiquesDefensePokemonAvant;
                    int statistiquesVitesseGagner = statistiquesVitessePokemonApres - statistiquesVitessePokemonAvant;
                    int statistiquesAttaqueSpecialeGagner = statistiquesAttaqueSpecialePokemonApres - statistiquesAttaqueSpecialePokemonAvant;
                    int statistiquesDefenseSpecialeGagner = statistiquesDefenseSpecialePokemonApres - statistiquesDefenseSpecialePokemonAvant;

                    pokemonJoueurSelectionner.setPvRestant(pokemonJoueurSelectionner.getPvRestant() + nbPvGagner);
                    label_niveau_pokemon_combat_joueur.Text = "N. " + pokemonJoueurSelectionner.getNiveau().ToString();

                    label_pv_changement_niveau.Text =      "PV :                         + " + nbPvGagner;
                    label_attaque_changement_niveau.Text = "Attaque :                 + " + statistiquesAttaqueGagner;
                    label_defense_changement_niveau.Text = "Défense :                + " + statistiquesDefenseGagner;
                    label_vitesse_changement_niveau.Text = "Vitesse :                  + " + statistiquesVitesseGagner;
                    label_attaque_speciale_changement_niveau.Text = "Attaque Spéciale :  + " + statistiquesAttaqueSpecialeGagner;
                    label_defense_speciale_changement_niveau.Text = "Défense Spéciale : + " + statistiquesDefenseSpecialeGagner;

                    for (int i = 0; i <= Joueur.getPokemonEquipe().Count - 1; i++)
                    {
                        if (pokemonJoueurSelectionner == Joueur.getPokemonEquipe()[i])
                        {
                            label_pv_pokemon[i].Text = pokemonJoueurSelectionner.getPvRestant().ToString() + " / " + pokemonJoueurSelectionner.getPv().ToString() + " PV";
                        }
                    }
                    label_pv_pokemon_combat_joueur.Text = pokemonJoueurSelectionner.getPvRestant().ToString() + " / " + pokemonJoueurSelectionner.getPv().ToString() + " PV";

                    textBox1.Text += pokemonJoueurSelectionner.getNom() + " passe au niveau " + pokemonJoueurSelectionner.getNiveau() + Environment.NewLine;
                    rafraichirBarreViePokemonJoueur1();

                    groupBoxNiveauSuperieurStatistiques.Visible = true;
                    showStatistiquesAugmenter = true;
                }
            }
            else
            {
                timerBarreExperiencePokemonJoueur.Stop();

                if (groupBoxNiveauSuperieurStatistiques.Visible == false)
                {
                    combat_btn.Enabled = true;

                    combat_btn.Focus();
                }
            }

            gBarreExperience.Dispose();

          
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btn_retour_liste_pokemon_Click(object sender, EventArgs e)
        {
            btn_attaque1.Enabled = true;
            btn_attraper.Enabled = true;
            btn_soigner.Enabled = true;
            btn_changement_pokemon.Enabled = true;

            btn_changement_pokemon.Focus();

            panel_choix_pokemon_selection.Visible = false; 
        }

        private void btn_retour_objets_Click(object sender, EventArgs e)
        {
            btn_attaque1.Enabled = true;
            btn_attraper.Enabled = true;
            btn_soigner.Enabled = true;
            btn_changement_pokemon.Enabled = true;

            panel_choix_objets_selection.Visible = false;

            if (cb_choix_objets.SelectedItem != null)
            {
                cb_choix_objets.Items.Remove(cb_choix_objets.SelectedItem);
                
            }
            cb_choix_objets.Items.Clear();
        }

        private void btn_statistiques_Click(object sender, EventArgs e)
        {
            ClassLibrary2.Pokemon pokemonJoueurStatistiquesSelectionner = new ClassLibrary2.Pokemon();
            var checkedButton = panel_choix_pokemon_selection.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked);

            if (checkedButton != null)
            {

                if (checkedButton == radioBtn_pokemon[0])
                {
                    pokemonJoueurStatistiquesSelectionner = Joueur.getPokemonEquipe()[0];
                }

                else if (checkedButton == radioBtn_pokemon[1])
                {
                    pokemonJoueurStatistiquesSelectionner = Joueur.getPokemonEquipe()[1];
                }

                else if (checkedButton == radioBtn_pokemon[2])
                {
                    pokemonJoueurStatistiquesSelectionner = Joueur.getPokemonEquipe()[2];
                }

                else if (checkedButton == radioBtn_pokemon[3])
                {
                    pokemonJoueurStatistiquesSelectionner = Joueur.getPokemonEquipe()[3];
                }

                else if (checkedButton == radioBtn_pokemon[4])
                {
                    pokemonJoueurStatistiquesSelectionner = Joueur.getPokemonEquipe()[4];
                }

                else if (checkedButton == radioBtn_pokemon[5])
                {
                    pokemonJoueurStatistiquesSelectionner = Joueur.getPokemonEquipe()[5];
                }

            this.Enabled = false;

            Form2 fenetreStatistiquesPokemon = new Form2(this);

            fenetreStatistiquesPokemon.pokemonSelectionner(pokemonJoueurStatistiquesSelectionner);
            fenetreStatistiquesPokemon.Show();

            }
            else
            {
                MessageBox.Show("Selectionnez un pokémon", "Ouverture des statistiques d'un pokemon", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            System.Drawing.SolidBrush fillGreen = new System.Drawing.SolidBrush(Color.Green);
            System.Drawing.SolidBrush fillRed = new System.Drawing.SolidBrush(Color.Red);
            System.Drawing.SolidBrush fillYellow = new System.Drawing.SolidBrush(Color.FromArgb(248, 222, 125));

            Pen black = new Pen(Color.Black);

            if (compteur >= pokemonJoueurSelectionner.getPvRestant() && compteur >= 0 && compteur <= pokemonJoueurSelectionner.getPv() && gagnePvPokemonJoueur == false || compteur <= pokemonJoueurSelectionner.getPvRestant() && compteur <= pokemonJoueurSelectionner.getPv() && gagnePvPokemonJoueur == true)
            {
                Graphics g = Graphics.FromImage(DrawAreaPokemonJoueur);

                if (compteur >= pokemonJoueurSelectionner.getPv() / 2)
                {
                    g.Clear(SystemColors.Control);
                    g.DrawRectangle(black, 0, 0, 100, 15);
                    g.FillRectangle(fillGreen, 0, 0, ((100 * pokemonJoueurSelectionner.getPv() - (100 * pokemonJoueurSelectionner.getPv() - compteur * 100)) / pokemonJoueurSelectionner.getPv()), 15);
                    rafraichirLabelViePokemonEquipe();
                    label_pv_pokemon_combat_joueur.Text = compteur.ToString() + " / " + pokemonJoueurSelectionner.getPv().ToString() + " PV";
                    pictureBoxBarreViePokemonJoueur.Image = DrawAreaPokemonJoueur;
                }
                else if (compteur < pokemonJoueurSelectionner.getPv() / 2 && compteur >= pokemonJoueurSelectionner.getPv() / 5)
                {
                    g.Clear(SystemColors.Control);
                    g.DrawRectangle(black, 0, 0, 100, 15);
                    g.FillRectangle(fillYellow, 0, 0, (100 * pokemonJoueurSelectionner.getPv() - (100 * pokemonJoueurSelectionner.getPv() - compteur * 100)) / pokemonJoueurSelectionner.getPv(), 15);
                    rafraichirLabelViePokemonEquipe();  
                    label_pv_pokemon_combat_joueur.Text = compteur.ToString() + " / " + pokemonJoueurSelectionner.getPv().ToString() + " PV";
                    pictureBoxBarreViePokemonJoueur.Image = DrawAreaPokemonJoueur;
                }
                else if (compteur < pokemonJoueurSelectionner.getPv() / 5 && compteur > 0)
                {
                    g.Clear(SystemColors.Control);
                    g.DrawRectangle(black, 0, 0, 100, 15);
                    g.FillRectangle(fillRed, 0, 0, (100 * pokemonJoueurSelectionner.getPv() - (100 * pokemonJoueurSelectionner.getPv() - compteur * 100)) / pokemonJoueurSelectionner.getPv(), 15);
                    rafraichirLabelViePokemonEquipe();
                    label_pv_pokemon_combat_joueur.Text = compteur.ToString() + " / " + pokemonJoueurSelectionner.getPv().ToString() + " PV";
                    pictureBoxBarreViePokemonJoueur.Image = DrawAreaPokemonJoueur;

                }

                else
                {
                    g.Clear(SystemColors.Control);
                    g.DrawRectangle(black, 0, 0, 100, 15);

                    if (pokemonJoueurSelectionner.getPv() - (pokemonJoueurSelectionner.getPv() - compteur) > 0)
                    {
                        g.FillRectangle(fillRed, 0, 0, (100 * pokemonJoueurSelectionner.getPv() - (100 * pokemonJoueurSelectionner.getPv() - compteur * 100)) / pokemonJoueurSelectionner.getPv(), 15);
                        rafraichirLabelViePokemonEquipe();
                        label_pv_pokemon_combat_joueur.Text = compteur.ToString() + " / " + pokemonJoueurSelectionner.getPv().ToString() + " PV";
                    }
                    else
                    {
                        rafraichirLabelViePokemonEquipe();

                        textBox1.Text += pokemonJoueurSelectionner.getNom() + " est K.O." + Environment.NewLine;
                        // label_pv_pokemon[i].Text = "K.O.";

                        label_pv_pokemon_combat_joueur.Text = "K.O.";
                    }
                    pictureBoxBarreViePokemonJoueur.Image = DrawAreaPokemonJoueur;
                }

                
                if (gagnePvPokemonJoueur == false)
                {
                    compteur--;
                }

                if(gagnePvPokemonJoueur == true)
                {
                    compteur++;
                }

                g.Dispose();


            }
            else
            {
                timerBarrePokemonJoueur.Stop();

                if (statutPokemonPerdPvJoueur != 2)
                {
                    if (pokemon.getPvRestant() > 0 && (pokemon.getStatutPokemon() != "Paralysie" && pokemon.getStatutPokemon() != "Gelé" && pokemon.getStatutPokemon() != "Sommeil") || (pokemon.getStatutPokemon() == "Paralysie" && reussiteAttaqueParalyseAdversaire == true) || (pokemon.getStatutPokemon() == "Gelé" && reussiteAttaqueGelAdversaire == true))
                    {
                        textBox1.Text += pokemon.getNom() + " adverse a fait " + nbDegats + " dégâts " + Environment.NewLine;
                    }

                }
                else
                {
                    if (pokemonJoueurSelectionner.getStatutPokemon() == "Brulure")
                    {
                        textBox1.Text += pokemonJoueurSelectionner.getNom() + " brule" + Environment.NewLine;
                        nbDegats = pokemonJoueurSelectionner.getPv() / 16;
                        textBox1.Text += pokemonJoueurSelectionner.getNom() + " perd " + nbDegats + " pv" + Environment.NewLine;
                    }
                    else if(pokemonJoueurSelectionner.getStatutPokemon() == "Empoisonnement normal")
                    {
                        textBox1.Text += pokemonJoueurSelectionner.getNom() + " souffre du poison" + Environment.NewLine;
                        nbDegats = pokemonJoueurSelectionner.getPv() / 8;
                        textBox1.Text += pokemonJoueurSelectionner.getNom() + " perd " + nbDegats + " pv" + Environment.NewLine;
                    }
                    else if (pokemonJoueurSelectionner.getStatutPokemon() == "Empoisonnement grave")
                    {
                        textBox1.Text += pokemonJoueurSelectionner.getNom() + " souffre du poison" + Environment.NewLine;
                        nbDegats = (pokemonJoueurSelectionner.getPv() / 16) * (nombreTourStatut - 1);
                        textBox1.Text += pokemonJoueurSelectionner.getNom() + " perd " + nbDegats + " pv" + Environment.NewLine;
                    }
                }

                if (gagnePvPokemonJoueur == true)
                {
                    compteur = pokemonJoueurSelectionner.getPvRestant();
                    gagnePvPokemonJoueur = false;
                    
                    rafraichirBarreViePokemonJoueur();
                }

                else if (pokemonJoueurAttaquePremier == false && nombreMouvementsBall < 0 && pokemonJoueurSelectionner.getPvRestant() > 0 && changement_pokemon == false && statutPokemonPerdPvJoueur == 0)
                {   
                    rafraichirBarreViePokemonAdversaire();
                }
               
                if(pokemonJoueurAttaquePremier == false && pokemon.getPvRestant() <= 0)
                {

                }
              //  else if ((pokemonJoueurAttaquePremier == true && pokemon.getPvRestant() > 0 && pokemonJoueurSelectionner.getPvRestant() > 0 && pokemon.getStatutPokemon() == "Normal") || (pokemonJoueurAttaquePremier == false && nombreMouvementsBall >= 0 && nombreMouvementsBall < 4 && pokemonJoueurSelectionner.getPvRestant() > 0 && pokemon.getStatutPokemon() == "Normal"))
                else if ((pokemonJoueurAttaquePremier == true && pokemon.getPvRestant() > 0 && statutPokemonPerdPvAdversaire == 0 && pokemonJoueurSelectionner.getPvRestant() > 0 && (pokemon.getStatutPokemon() == "Normal" || pokemon.getStatutPokemon() == "Paralysie" || pokemon.getStatutPokemon() == "Gelé" || pokemon.getStatutPokemon() == "Sommeil")) || (pokemonJoueurAttaquePremier == false && nombreMouvementsBall >= 0 && nombreMouvementsBall < 4 && pokemonJoueurSelectionner.getPvRestant() > 0 && (pokemon.getStatutPokemon() == "Normal" || pokemon.getStatutPokemon() == "Paralysie" || pokemon.getStatutPokemon() == "Gelé" || pokemon.getStatutPokemon() == "Sommeil")))
                {
                    try
                    {
                        Bitmap pngMenuCombat = new Bitmap(AppDomain.CurrentDomain.BaseDirectory + "\\Images\\Combat\\menu_combat.png");
                        pictureBoxMenuCombat.Image = pngMenuCombat;
                    }
                    catch
                    {
                        MessageBox.Show("L'image du menu de combat n'a pas pu être chargée. Veuillez vérifier que celle-ci est bien présente dans le répertoire.", "Vérification du menu de combat", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    btn_attaque1.Enabled = true;
                    btn_soigner.Enabled = true;
                    btn_attraper.Enabled = true;
                    btn_changement_pokemon.Enabled = true;

                    btn_attaque1.Visible = true;
                    btn_soigner.Visible = true;
                    btn_changement_pokemon.Visible = true;

                    btn_attaque1.Focus();
                     
                  //  MessageBox.Show("marche");

                }

                else if (pokemon.getPvRestant() > 0 && pokemonJoueurSelectionner.getPvRestant() <= 0)
                {
                    timerAnimationKo.Start();

                    bool equipePokemonEncoreEnVie = false;

                    for (int i = 0; i < Joueur.getPokemonEquipe().Count; i++)
                    {
                        if (Joueur.getPokemonEquipe()[i].getPvRestant() > 0)
                        {
                            equipePokemonEncoreEnVie = true;
                        }
                    }

                    if (equipePokemonEncoreEnVie == false)
                    {
                        MessageBox.Show("Votre équipe à perdu");
                    }
                    else
                    {
                        btn_attaque1.Enabled = false;
                        btn_soigner.Enabled = false;
                        btn_attraper.Enabled = false;
                        btn_changement_pokemon.Enabled = true;

                        btn_changement_pokemon.Focus();

                        changementPokemonPokemonKo = true;
                    }
                }
                if ((pokemon.getStatutPokemon() == "Brulure" || pokemon.getStatutPokemon() == "Empoisonnement normal" || pokemon.getStatutPokemon() == "Empoisonnement grave") && statutPokemonPerdPvAdversaire == 0 && statutPokemonPerdPvJoueur == 0 && pokemonJoueurAttaquePremier == true && pokemon.getPvRestant() > 0)
                {
                    statutPokemonPerdPvAdversaire = 1;
                    compteurAdversaire = pokemon.getPvRestant();

                    if (pokemon.getStatutPokemon() == "Brulure")
                    {
                        pokemon.setPvRestant(pokemon.getPvRestant() - (pokemon.getPv() / 16));
                    }
                    else if(pokemon.getStatutPokemon() == "Empoisonnement normal")
                    {
                        pokemon.setPvRestant(pokemon.getPvRestant() - (pokemon.getPv() / 8));
                    }
                    else if (pokemon.getStatutPokemon() == "Empoisonnement grave")
                    {
                        pokemon.setPvRestant(pokemon.getPvRestant() - ((pokemon.getPv() / 16) * nombreTourStatutAdversaire));
                        if (nombreTourStatutAdversaire < 16)
                        {
                            nombreTourStatutAdversaire++;
                        }
                    }
                    rafraichirBarreViePokemonAdversaire();
                }
                else if((pokemon.getStatutPokemon() == "Normal" || pokemon.getStatutPokemon() == "Paralysie" || pokemon.getStatutPokemon() == "Gelé" || pokemon.getStatutPokemon() == "Sommeil") && (pokemonJoueurSelectionner.getStatutPokemon() == "Brulure" || pokemonJoueurSelectionner.getStatutPokemon() == "Empoisonnement normal" || pokemonJoueurSelectionner.getStatutPokemon() == "Empoisonnement grave") && statutPokemonPerdPvAdversaire == 0 && statutPokemonPerdPvJoueur == 0 && pokemonJoueurAttaquePremier == true && pokemon.getPvRestant() > 0)
                {
                    compteur = pokemonJoueurSelectionner.getPvRestant();
                    if (pokemonJoueurSelectionner.getStatutPokemon() == "Brulure")
                    {
                        pokemonJoueurSelectionner.setPvRestant(pokemonJoueurSelectionner.getPvRestant() - (pokemonJoueurSelectionner.getPv() / 16));
                    }
                    else if (pokemonJoueurSelectionner.getStatutPokemon() == "Empoisonnement normal")
                    {
                        pokemonJoueurSelectionner.setPvRestant(pokemonJoueurSelectionner.getPvRestant() - (pokemonJoueurSelectionner.getPv() / 8));
                    }
                    else if (pokemonJoueurSelectionner.getStatutPokemon() == "Empoisonnement grave")
                    {
                        pokemonJoueurSelectionner.setPvRestant(pokemonJoueurSelectionner.getPvRestant() - ((pokemonJoueurSelectionner.getPv() / 16) * nombreTourStatut));
                        if (nombreTourStatut < 16)
                        {
                            nombreTourStatut++;
                        }
                    }
                    statutPokemonPerdPvJoueur = 1;
                    rafraichirBarreViePokemonJoueur();
                }

                else if (statutPokemonPerdPvJoueur == 2 && (pokemonJoueurSelectionner.getStatutPokemon() == "Brulure" || pokemonJoueurSelectionner.getStatutPokemon() == "Empoisonnement normal" || pokemonJoueurSelectionner.getStatutPokemon() == "Empoisonnement grave"))
                {
                    statutPokemonPerdPvJoueur = 0;

                    if (pokemonJoueurSelectionner.getPvRestant() > 0 && pokemon.getPvRestant() > 0)
                    {
                        try
                        {
                            Bitmap pngMenuCombat = new Bitmap(AppDomain.CurrentDomain.BaseDirectory + "\\Images\\Combat\\menu_combat.png");
                            pictureBoxMenuCombat.Image = pngMenuCombat;
                        }
                        catch
                        {
                            MessageBox.Show("L'image du menu de combat n'a pas pu être chargée. Veuillez vérifier que celle-ci est bien présente dans le répertoire.", "Vérification de l'image du menu de combat", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        btn_attaque1.Enabled = true;
                        btn_soigner.Enabled = true;
                        btn_attraper.Enabled = true;
                        btn_changement_pokemon.Enabled = true;

                        btn_attaque1.Visible = true;
                        btn_soigner.Visible = true;
                        btn_changement_pokemon.Visible = true;

                        btn_attaque1.Focus();
                    }
                }

                if (nombreMouvementsBall >= 0)
                {
                    nombreMouvementsBall = -1;
                }

            }

        }

        private void timerBarrePokemonAdversaire_Tick(object sender, EventArgs e)
        {
            System.Drawing.SolidBrush fillGreen = new System.Drawing.SolidBrush(Color.Green);
            System.Drawing.SolidBrush fillRed = new System.Drawing.SolidBrush(Color.Red);
            System.Drawing.SolidBrush fillYellow = new System.Drawing.SolidBrush(Color.FromArgb(248, 222, 125));

            Pen black = new Pen(Color.Black);

            if (compteurAdversaire >= pokemon.getPvRestant() && compteurAdversaire >= 0 && compteurAdversaire <= pokemon.getPv())
            {
                Graphics gBarreAdversaire = Graphics.FromImage(DrawAreaPokemonAdversaire);

                if (compteurAdversaire >= pokemon.getPv() / 2)
                {
                    gBarreAdversaire.Clear(SystemColors.Control);
                    gBarreAdversaire.DrawRectangle(black, 0, 0, 100, 15);
                    gBarreAdversaire.FillRectangle(fillGreen, 0, 0, ((100 * pokemon.getPv() - (100 * pokemon.getPv() - compteurAdversaire * 100)) / pokemon.getPv()) + 1, 15);
                    label_pv_pokemon_combat_adversaire.Text = compteurAdversaire.ToString() + " / " + pokemon.getPv().ToString() + " PV";
                    pictureBoxBarreViePokemonAdversaire.Image = DrawAreaPokemonAdversaire;
                }
                else if (compteurAdversaire < pokemon.getPv() / 2 && compteurAdversaire >= pokemon.getPv() / 5)
                {
                    gBarreAdversaire.Clear(SystemColors.Control);
                    gBarreAdversaire.DrawRectangle(black, 0, 0, 100, 15);
                    gBarreAdversaire.FillRectangle(fillYellow, 0, 0, (100 * pokemon.getPv() - (100 * pokemon.getPv() - compteurAdversaire * 100)) / pokemon.getPv(), 15);
                    label_pv_pokemon_combat_adversaire.Text = compteurAdversaire.ToString() + " / " + pokemon.getPv().ToString() + " PV";
                    pictureBoxBarreViePokemonAdversaire.Image = DrawAreaPokemonAdversaire;
                }
                else if (compteurAdversaire < pokemon.getPv() / 5 && compteurAdversaire > 0)
                {
                    gBarreAdversaire.Clear(SystemColors.Control);
                    gBarreAdversaire.DrawRectangle(black, 0, 0, 100, 15);
                    gBarreAdversaire.FillRectangle(fillRed, 0, 0, (100 * pokemon.getPv() - (100 * pokemon.getPv() - compteurAdversaire * 100)) / pokemon.getPv(), 15);
                    label_pv_pokemon_combat_adversaire.Text = compteurAdversaire.ToString() + " / " + pokemon.getPv().ToString() + " PV";
                    pictureBoxBarreViePokemonAdversaire.Image = DrawAreaPokemonAdversaire;

                }

                else
                {
                    gBarreAdversaire.Clear(SystemColors.Control);
                    gBarreAdversaire.DrawRectangle(black, 0, 0, 100, 15);

                    if (pokemon.getPv() - (pokemon.getPv() - compteurAdversaire) > 0)
                    {
                        gBarreAdversaire.FillRectangle(fillRed, 0, 0, (100 * pokemon.getPv() - (100 * pokemon.getPv() - compteurAdversaire * 100)) / pokemon.getPv(), 15);
                        label_pv_pokemon_combat_adversaire.Text = compteurAdversaire.ToString() + " / " + pokemon.getPv().ToString() + " PV";
                    }
              
                    pictureBoxBarreViePokemonAdversaire.Image = DrawAreaPokemonAdversaire;
                }

                compteurAdversaire--;

                gBarreAdversaire.Dispose();
            }

            else
            {
                timerBarrePokemonAdversaire.Stop();
                if (statutPokemonPerdPvAdversaire != 2)
                {
                    if ((pokemonJoueurSelectionner.getStatutPokemon() != "Paralysie" && pokemonJoueurSelectionner.getStatutPokemon() != "Gelé" && pokemonJoueurSelectionner.getStatutPokemon() != "Sommeil") || (pokemonJoueurSelectionner.getStatutPokemon() == "Paralysie" && reussiteAttaqueParalyse == true) || (pokemonJoueurSelectionner.getStatutPokemon() == "Gelé" && reussiteAttaqueGel == true))
                    {
                        textBox1.Text += pokemonJoueurSelectionner.getNom() + " a fait " + nbDegats + " dégâts " + Environment.NewLine;
                    }
                }
                else
                {
                    if (pokemon.getStatutPokemon() == "Brulure")
                    {
                        textBox1.Text += pokemon.getNom() + " adverse brule" + Environment.NewLine;
                        nbDegats = pokemon.getPv() / 16;
                        textBox1.Text += pokemon.getNom() + " adverse perd " + nbDegats + " pv" + Environment.NewLine;
                    }
                    else if (pokemon.getStatutPokemon() == "Empoisonnement normal")
                    {
                        textBox1.Text += pokemon.getNom() + " adverse souffre du poison" + Environment.NewLine;
                        nbDegats = pokemon.getPv() / 8;
                        textBox1.Text += pokemon.getNom() + " adverse perd " + nbDegats + " pv" + Environment.NewLine;
                    }
                    else if (pokemon.getStatutPokemon() == "Empoisonnement grave")
                    {
                        textBox1.Text += pokemon.getNom() + " adverse souffre du poison" + Environment.NewLine;
                        nbDegats = (pokemon.getPv()  / 16) * (nombreTourStatutAdversaire - 1);
                        textBox1.Text += pokemon.getNom() + " adverse perd " + nbDegats + " pv" + Environment.NewLine;
                    }

                }

                if (pokemon.getPvRestant() <= 0)
                {
                    label_pv_pokemon_combat_adversaire.Text = "K.O.";
                    textBox1.Text += pokemon.getNom() + " sauvage est K.O." + Environment.NewLine;

                    timerAnimationAdversaireKo.Start();

                    nombreTourStatutAdversaire = 0;
                    nombreTourStatutAEffectuerAdversaire = 0;
                    nombreTourSommeilAdversaire = 0;

                    btn_attaque1.Visible = false;
                    pictureBoxMenuCombat.Visible = false;
                    

                    if (pokemon.getGainEvPv() > 0)
                    {
                        pokemonJoueurSelectionner.setEvPv(pokemonJoueurSelectionner.getEvPv() + pokemon.getGainEvPv());
                    }
                    if (pokemon.getGainEvAttaque() > 0)
                    { 
                        pokemonJoueurSelectionner.setEvAttaque(pokemonJoueurSelectionner.getEvAttaque() + pokemon.getGainEvAttaque());
                    }
                    if (pokemon.getGainEvDefense() > 0)
                    {
                        pokemonJoueurSelectionner.setEvDefense(pokemonJoueurSelectionner.getEvDefense() + pokemon.getGainEvDefense());
                    }
                    if (pokemon.getGainEvVitesse() > 0)
                    {
                        pokemonJoueurSelectionner.setEvVitesse(pokemonJoueurSelectionner.getEvVitesse() + pokemon.getGainEvVitesse());
                    }
                    if (pokemon.getGainEvAttaqueSpeciale() > 0)
                    {
                        pokemonJoueurSelectionner.setEvAttaqueSpeciale(pokemonJoueurSelectionner.getEvAttaqueSpeciale() + pokemon.getGainEvAttaqueSpeciale());
                    }
                    if (pokemon.getGainEvDefenseSpeciale() > 0)
                    {
                        pokemonJoueurSelectionner.setEvDefenseSpeciale(pokemonJoueurSelectionner.getEvDefenseSpeciale() + pokemon.getGainEvDefenseSpeciale());
                    }

                    compteurExperience = (100 * (pokemonJoueurSelectionner.getExperience() - pokemonJoueurSelectionner.getExperiencePokemonReturn())) / (pokemonJoueurSelectionner.getExperiencePokemonProchainNiveau() - pokemonJoueurSelectionner.getExperiencePokemonReturn());
                    double experienceGagner = pokemonJoueurSelectionner.gainExperiencePokemonBattu(pokemon);

                    textBox1.Text += pokemonJoueurSelectionner.getNom() + " a obtenu " + experienceGagner + " points d'expérience" + Environment.NewLine;

                    statutPokemonPerdPvAdversaire = 0;

                    rafraichirBarreExperiencePokemonJoueur();
                    combat_btn.Focus();

                }
                if (pokemonJoueurAttaquePremier == true && statutPokemonPerdPvAdversaire == 0)
                {
                    rafraichirBarreViePokemonJoueur();
                }
                else if(pokemonJoueurAttaquePremier == false && pokemon.getPvRestant() > 0 && statutPokemonPerdPvAdversaire == 0 && (pokemon.getStatutPokemon() == "Normal" || pokemon.getStatutPokemon() == "Paralysie" || pokemon.getStatutPokemon() == "Gelé" || pokemon.getStatutPokemon() == "Sommeil") && (pokemonJoueurSelectionner.getStatutPokemon() == "Normal" || pokemonJoueurSelectionner.getStatutPokemon() == "Paralysie" || pokemonJoueurSelectionner.getStatutPokemon() == "Gelé" || pokemonJoueurSelectionner.getStatutPokemon() == "Sommeil"))
                {
                    try
                    {
                        Bitmap pngMenuCombat = new Bitmap(AppDomain.CurrentDomain.BaseDirectory + "\\Images\\Combat\\menu_combat.png");
                        pictureBoxMenuCombat.Image = pngMenuCombat;
                    }
                    catch
                    {
                        MessageBox.Show("L'image du menu de combat n'a pas pu être chargée. Veuillez vérifier que celle-ci est bien présente dans le répertoire.", "Vérification de l'image du menu de combat", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    btn_attaque1.Enabled = true;
                    btn_soigner.Enabled = true;
                    btn_attraper.Enabled = true;
                    btn_changement_pokemon.Enabled = true;

                    btn_attaque1.Visible = true;
                    btn_soigner.Visible = true;
                    btn_changement_pokemon.Visible = true;
           
                    btn_attaque1.Focus();

                }
                else if (pokemonJoueurAttaquePremier == false && statutPokemonPerdPvAdversaire == 0 && (pokemon.getStatutPokemon() == "Brulure" || pokemon.getStatutPokemon() == "Empoisonnement normal" || pokemon.getStatutPokemon() == "Empoisonnement grave") && pokemon.getPvRestant() > 0)
                {
                    statutPokemonPerdPvAdversaire = 1;
                    compteurAdversaire = pokemon.getPvRestant();

                    if (pokemon.getStatutPokemon() == "Brulure")
                    {
                        pokemon.setPvRestant(pokemon.getPvRestant() - (pokemon.getPv() / 16));
                    }
                    else if (pokemon.getStatutPokemon() == "Empoisonnement normal")
                    {
                        pokemon.setPvRestant(pokemon.getPvRestant() - (pokemon.getPv() / 8));
                    }
                    else if (pokemon.getStatutPokemon() == "Empoisonnement grave")
                    {
                        pokemon.setPvRestant(pokemon.getPvRestant() - ((pokemon.getPv() / 16) * nombreTourStatutAdversaire));
                        if (nombreTourStatutAdversaire < 16)
                        {
                            nombreTourStatutAdversaire++;
                        }
                    }

                    rafraichirBarreViePokemonAdversaire();    
                }
                else if (pokemonJoueurAttaquePremier == false && statutPokemonPerdPvAdversaire == 0 && (pokemon.getStatutPokemon() == "Normal" || pokemon.getStatutPokemon() == "Paralysie" || pokemon.getStatutPokemon() == "Gelé" || pokemon.getStatutPokemon() == "Sommeil") && (pokemonJoueurSelectionner.getStatutPokemon() == "Brulure" || pokemonJoueurSelectionner.getStatutPokemon() == "Empoisonnement normal" || pokemonJoueurSelectionner.getStatutPokemon() == "Empoisonnement grave") && pokemon.getPvRestant() > 0)
                {
                    compteur = pokemonJoueurSelectionner.getPvRestant();
                    if (pokemonJoueurSelectionner.getStatutPokemon() == "Brulure")
                    {
                        pokemonJoueurSelectionner.setPvRestant(pokemonJoueurSelectionner.getPvRestant() - (pokemonJoueurSelectionner.getPv() / 16));
                    }
                    else if(pokemonJoueurSelectionner.getStatutPokemon() == "Empoisonnement normal")
                    {
                        pokemonJoueurSelectionner.setPvRestant(pokemonJoueurSelectionner.getPvRestant() - (pokemonJoueurSelectionner.getPv() / 8));
                    }
                    else if (pokemonJoueurSelectionner.getStatutPokemon() == "Empoisonnement grave")
                    {
                        pokemonJoueurSelectionner.setPvRestant(pokemonJoueurSelectionner.getPvRestant() - ((pokemonJoueurSelectionner.getPv() / 16) * nombreTourStatut));
                        if (nombreTourStatut < 16)
                        {
                            nombreTourStatut++;
                        }
                    }
                    statutPokemonPerdPvJoueur = 1;
                    rafraichirBarreViePokemonJoueur();
                }
                else if(statutPokemonPerdPvAdversaire == 2)
                {
                    statutPokemonPerdPvAdversaire = 0;

                    if (pokemon.getPvRestant() > 0)
                    {
                        if (pokemonJoueurSelectionner.getStatutPokemon() == "Normal" || pokemonJoueurSelectionner.getStatutPokemon() == "Paralysie" || pokemonJoueurSelectionner.getStatutPokemon() == "Gelé" || pokemonJoueurSelectionner.getStatutPokemon() == "Sommeil")
                        {
                            try
                            {
                                Bitmap pngMenuCombat = new Bitmap(AppDomain.CurrentDomain.BaseDirectory + "\\Images\\Combat\\menu_combat.png");
                                pictureBoxMenuCombat.Image = pngMenuCombat;
                            }
                            catch
                            {
                                MessageBox.Show("L'image du menu de combat n'a pas pu être chargée. Veuillez vérifier que celle-ci est bien présente dans le répertoire.", "Vérification de l'image du menu de combat", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }

                            btn_attaque1.Enabled = true;
                            btn_soigner.Enabled = true;
                            btn_attraper.Enabled = true;
                            btn_changement_pokemon.Enabled = true;

                            btn_attaque1.Visible = true;
                            btn_soigner.Visible = true;
                            btn_changement_pokemon.Visible = true;

                            btn_attaque1.Focus();
                        }
                        else
                        {
                            compteur = pokemonJoueurSelectionner.getPvRestant();
                            if (pokemonJoueurSelectionner.getStatutPokemon() == "Brulure")
                            {
                                pokemonJoueurSelectionner.setPvRestant(pokemonJoueurSelectionner.getPvRestant() - (pokemonJoueurSelectionner.getPv() / 16));
                            }
                            else if (pokemonJoueurSelectionner.getStatutPokemon() == "Empoisonnement normal")
                            {
                                pokemonJoueurSelectionner.setPvRestant(pokemonJoueurSelectionner.getPvRestant() - (pokemonJoueurSelectionner.getPv() / 8));
                            }
                            else if (pokemonJoueurSelectionner.getStatutPokemon() == "Empoisonnement grave")
                            {
                                pokemonJoueurSelectionner.setPvRestant(pokemonJoueurSelectionner.getPvRestant() - ((pokemonJoueurSelectionner.getPv() / 16) * nombreTourStatut));
                                if (nombreTourStatut < 16)
                                {
                                    nombreTourStatut++;
                                }
                            }
                            statutPokemonPerdPvJoueur = 1;
                            rafraichirBarreViePokemonJoueur();
                        }
                    }
                
                }
                
                if (pokemonJoueurAttaquePremier == false && statutPokemonPerdPvJoueur == 1 && (pokemonJoueurSelectionner.getStatutPokemon() == "Brulure" || pokemonJoueurSelectionner.getStatutPokemon() == "Empoisonnement normal" || pokemonJoueurSelectionner.getStatutPokemon() == "Empoisonnement grave") && pokemonJoueurSelectionner.getPvRestant() > 0)
                {
                    compteur = pokemonJoueurSelectionner.getPvRestant();

                    if (pokemonJoueurSelectionner.getStatutPokemon() == "Brulure")
                    {
                        pokemonJoueurSelectionner.setPvRestant(pokemonJoueurSelectionner.getPvRestant() - (pokemonJoueurSelectionner.getPv() / 16));
                    }
                    else if (pokemonJoueurSelectionner.getStatutPokemon() == "Empoisonnement normal")
                    {
                        pokemonJoueurSelectionner.setPvRestant(pokemonJoueurSelectionner.getPvRestant() - (pokemonJoueurSelectionner.getPv() / 8));
                    }
                    else if (pokemonJoueurSelectionner.getStatutPokemon() == "Empoisonnement grave")
                    {
                        pokemonJoueurSelectionner.setPvRestant(pokemonJoueurSelectionner.getPvRestant() - ((pokemonJoueurSelectionner.getPv() / 16) * nombreTourStatut));
                        if (nombreTourStatut < 16)
                        {
                            nombreTourStatut++;
                        }
                    }

                    // statutPokemonPerdPvJoueur = 1;

                    rafraichirBarreViePokemonJoueur();
                }
            }
        }
    }
}
