using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using System.Windows.Forms;


namespace WindowsFormsApp3
{
    public partial class frmSaisiesBoutons : Form
    {
        ClassLibrary2.Personnage Joueur = new ClassLibrary2.Personnage();
        ClassLibrary2.Pokemon pokemon = new ClassLibrary2.Pokemon();
        ClassLibrary2.accesDonnees db = new ClassLibrary2.accesDonnees();

        ClassLibrary2.Pokemon pokemonJoueurStarter = new ClassLibrary2.Pokemon();
        ClassLibrary2.Pokemon pokemonJoueurSelectionner = new ClassLibrary2.Pokemon();

        ClassLibrary2.Pokemon pokemonJoueur_2 = new ClassLibrary2.Pokemon();
        ClassLibrary2.Attaque attaqueLancerPokemon = new ClassLibrary2.Attaque();
        ClassLibrary2.Attaque attaqueLancerAdversaire = new ClassLibrary2.Attaque();

        int compteur = 0, compteurAdversaire = 0, compteurExperience = 0, nbDegats = 0;
        double compteurAnimationCapturePartie1 = 0, compteurAnimationCapturePartie2 = 0, compteurAnimationCapturePartie3 = 0, compteurAnimationCapturePartie4 = 0, compteurAnimationCapturePartie5 = 0;
        int nbPvGagner, statistiquesAttaqueGagner, statistiquesDefenseGagner, statistiquesVitesseGagner, statistiquesAttaqueSpecialeGagner, statistiquesDefenseSpecialeGagner;
        bool gagnePvPokemonJoueur = false, pokemonJoueurAttaquePremier = true, reussiteAttaque = false, changement_pokemon = false, showStatistiquesAugmenter = false, showStatistiquesNiveauSuivant = false;
        double bonusCritique = 1;

        Bitmap DrawAreaPokemonJoueur, DrawAreaPokemonAdversaire, DrawAreaExperiencePokemonJoueur;

        PictureBox[] pictureBoxPokemon = new PictureBox[6];
        PictureBox pictureBoxPokeball = new PictureBox();
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
                                attaqueLancerAdversaire = pokemon.attaqueAdversaire(pokemon, pokemonJoueurSelectionner);

                                if (attaqueLancerAdversaire != null)
                                {
                                    reussiteAttaque = pokemon.getReussiteAttaque(pokemonJoueurSelectionner.getProbabiliteReussiteAttaque(pokemon, pokemonJoueurSelectionner, attaqueLancerAdversaire));
                                    bonusCritique = pokemonJoueurSelectionner.getCoupCritique(pokemon.getProbabiliteCoupCritique(pokemon));
                                    nbDegats = pokemon.attaqueWithNomAttaque(pokemon, pokemonJoueurSelectionner, attaqueLancerAdversaire, bonusCritique);

                                    if (reussiteAttaque == true)
                                    {
                                        textBox1.Text += Environment.NewLine + pokemon.getNom() + " adverse lance " + attaqueLancerAdversaire.getNom() + Environment.NewLine;

                                        if (bonusCritique == 1.5)
                                        {
                                            textBox1.Text += "Coup Critique" + Environment.NewLine;
                                            bonusCritique = 1;
                                        }

                                        if (pokemon.getEfficaciteAttaque(attaqueLancerAdversaire, pokemonJoueurSelectionner) != 1)
                                        {
                                            textBox1.Text += pokemon.getEfficaciteAttaqueTexte(pokemon.getEfficaciteAttaque(attaqueLancerAdversaire, pokemonJoueurSelectionner)) + Environment.NewLine;
                                        }
                                        // textBox1.Text += pokemon.getNom() + " adverse a fait " + nbDegats + " dégâts " + Environment.NewLine;
                                        // textBox1.Text += pokemon.getEfficaciteAttaqueTexte(pokemon.getEfficaciteAttaque(attaqueLancer, pokemonJoueurSelectionner)) + Environment.NewLine;
                                    }
                                    else
                                    {
                                        textBox1.Text += pokemon.getNom() + " rate son attaque" + Environment.NewLine;
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("Le pokemon n'a aucune attaque", "Vérification des attaques", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }


                        }

                        if (pokemonJoueurSelectionner.getPvRestant() > 0)
                        {
                           // label_pv_pokemon[i].Text = pokemonJoueurSelectionner.getPvRestant().ToString() + " / " + pokemonJoueurSelectionner.getPv().ToString() + " PV";

                        }
                        else
                        {
                            textBox1.Text += pokemonJoueurSelectionner.getNom() + " est K.O." + Environment.NewLine;
                           // label_pv_pokemon[i].Text = "K.O.";

                            btn_attaque1.Enabled = false;
                            btn_attraper.Enabled = false;
                            btn_soigner.Enabled = false;
                            btn_changement_pokemon.Enabled = true;

                            // label_pv_pokemon_combat_joueur.Text = "K.O.";
                        }
                    }
                }
                   
                 
            }
            else
            {
                pokemonJoueurAttaquePremier = true;
            }

            if(pokemonJoueurAttaquePremier == true)
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
            if (pokemonJoueurSelectionner.getPvRestant() > 0)
            {
                reussiteAttaque = pokemonJoueurSelectionner.getReussiteAttaque(pokemonJoueurSelectionner.getProbabiliteReussiteAttaque(pokemonJoueurSelectionner, pokemon, attaqueLancerPokemon));
                bonusCritique = pokemonJoueurSelectionner.getCoupCritique(pokemonJoueurSelectionner.getProbabiliteCoupCritique(pokemonJoueurSelectionner));
                nbDegats = pokemonJoueurSelectionner.attaqueWithNomAttaque(pokemonJoueurSelectionner, pokemon, attaqueLancerPokemon, bonusCritique);

                if (reussiteAttaque == true)
                {
                    textBox1.Text += Environment.NewLine + pokemonJoueurSelectionner.getNom() + " lance " + attaqueLancerPokemon.getNom() + Environment.NewLine;

                    if (bonusCritique == 1.5)
                    {
                        textBox1.Text += "Coup Critique" + Environment.NewLine;
                        bonusCritique = 1;
                    }

                    if (pokemonJoueurSelectionner.getEfficaciteAttaque(attaqueLancerPokemon, pokemon) != 1)
                    {
                        textBox1.Text += pokemonJoueurSelectionner.getEfficaciteAttaqueTexte(pokemonJoueurSelectionner.getEfficaciteAttaque(attaqueLancerPokemon, pokemon)) + Environment.NewLine;
                    }
                }

                else
                {
                    textBox1.Text += pokemonJoueurSelectionner.getNom() + " rate son attaque" + Environment.NewLine;
                }
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
            else if(changement_pokemon == true)
            {
                changement_pokemon = false;
                rafraichirBarreViePokemonJoueur();
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
            Bitmap png = new Bitmap(AppDomain.CurrentDomain.BaseDirectory + "\\Images\\" + idPokedexImage + ".png");
            pictureBoxPokemonCombatJoueur.Image = png;
            pictureBoxPokemonCombatJoueur.Image.RotateFlip(RotateFlipType.Rotate180FlipY);
            label_nom_pokemon_combat_joueur.Text = pokemonJoueurSelectionner.getNom();

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

            rafraichirBarreViePokemonJoueur1();

            label_niveau_pokemon_combat_joueur.Text = "N. " + pokemonJoueurSelectionner.getNiveau().ToString();
            rafraichirBarreExperiencePokemonJoueur1();
        }

        public frmSaisiesBoutons()
        {
            InitializeComponent();

            db.selection();

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
            if (cb_choix_pokemon_depart.Items.Count > 0)
            {
                cb_choix_pokemon_depart.Items.Clear();
            }

            for (int i = 0; i < db.selectionStarter().Count; i++)
            {
                cb_choix_pokemon_depart.Items.Add(db.selectionStarter()[i].ToString());
            }

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
               
                label_choix_pokemon_depart.Visible = true;
                cb_choix_pokemon_depart.Visible = true;
                bt_choixPokemon.Visible = true;

                cb_choix_pokemon_depart.Focus();

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
            btn_attaque1.Enabled = true;
            combat_btn.Enabled = false;
            btn_attraper.Enabled = true;
            btn_changement_pokemon.Enabled = true;

            if(pictureBoxPokeball != null)
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

            pokemon = pokemon.setPokemon();

            pokemon.setPvRestant(pokemon.getPv());
            pokemon.setAllAttacksWithId();

            int idPokedexImage = pokemonJoueurSelectionner.getNoIdPokedex();
            Bitmap png = new Bitmap(AppDomain.CurrentDomain.BaseDirectory + "\\Images\\" + idPokedexImage + ".png");
            pictureBoxPokemonCombatJoueur.Image = png;
            pictureBoxPokemonCombatJoueur.Image.RotateFlip(RotateFlipType.Rotate180FlipY);

            if (pictureBoxPokemonCombatAdversaire.Visible == false)
            {
                pictureBoxPokemonCombatAdversaire.Visible = true;
            }

            int idPokedexImageCombat = pokemon.getNoIdPokedex();
            Bitmap pngPokemonAdversaire = new Bitmap(AppDomain.CurrentDomain.BaseDirectory + "\\Images\\" + idPokedexImageCombat + ".png");
            pictureBoxPokemonCombatAdversaire.Image = pngPokemonAdversaire;

            textBox1.Text += Environment.NewLine; ;
            textBox1.Text += "Un " + pokemon.getNom() + " sauvage veut se battre" + Environment.NewLine;
            textBox1.Text += "Il a " + pokemon.getPv() + " PV" + Environment.NewLine;

            label_nom_pokemon_combat_joueur.Text = pokemonJoueurSelectionner.getNom();
            // label_pv_pokemon_combat_joueur.Text = Joueur.getPokemonEquipe()[0].getPvRestant().ToString() + " / " + Joueur.getPokemonEquipe()[0].getPv().ToString() + " PV";
            label_niveau_pokemon_combat_joueur.Text = "N. " + pokemonJoueurSelectionner.getNiveau().ToString();

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

            label_nom_pokemon_combat_adversaire.Visible = true;
            label_pv_pokemon_combat_adversaire.Visible = true;
            label_sexe_pokemon_combat_adversaire.Visible = true;
            label_niveau_pokemon_combat_adversaire.Visible = true;

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
            if (cb_choix_pokemon_depart.SelectedItem != null)
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
                cb_choix_pokemon_depart.Visible = false;
                bt_choixPokemon.Visible = false;

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

                Joueur.ajouterPokemonEquipe(db.selectionPokemonStatsStarter(cb_choix_pokemon_depart.SelectedItem.ToString()));
                Joueur.getPokemonEquipe()[0].setAllAttacksWithId();

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

                Bitmap png = new Bitmap(AppDomain.CurrentDomain.BaseDirectory + "\\Images\\" + idPokedexImage + ".png");

                pictureBoxPokemon[0].Image = png;
                pictureBoxPokemon[0].Image.RotateFlip(RotateFlipType.Rotate180FlipY);
            }
            else
            {
                MessageBox.Show("Choisissez un starter...", "Vérification du starter", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label1_Click_3(object sender, EventArgs e)
        {

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
                if (Joueur.getObjetsSac()[i].getQuantiteObjet() > 0)
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
                        if(pokemonJoueurSelectionner.getAttaque1().getPPRestant() <= 0)
                        {
                            btn_attaque_une.Enabled = false;
                        }
                        btn_attaque_une.Text = pokemonJoueurSelectionner.getAttaque1().getNom();
                        btn_attaque_une.Visible = true;
                        label_pp_attaque_une.Text = "PP " + pokemonJoueurSelectionner.getAttaque1().getPPRestant() + "/" + pokemonJoueurSelectionner.getAttaque1().getPP();
                        label_pp_attaque_une.Visible = true;
                        
                        btn_retour_choix_attaque.Visible = true;
                        btn_attaque_une.Focus();

                        string typeAttaque1 = pokemonJoueurSelectionner.getAttaque1().getTypeAttaque();
                        if(typeAttaque1 != null)
                        {
                            Bitmap pngTypeAttaque1 = new Bitmap(AppDomain.CurrentDomain.BaseDirectory + "\\Images\\Types\\" + typeAttaque1 + ".png");
                            pictureBoxTypeAttaque1.Image = pngTypeAttaque1;
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
                                btn_attaque_deux.Text = pokemonJoueurSelectionner.getAttaque2().getNom();
                                btn_attaque_deux.Visible = true;
                                label_pp_attaque_deux.Text = "PP " + pokemonJoueurSelectionner.getAttaque2().getPPRestant() + "/" + pokemonJoueurSelectionner.getAttaque2().getPP();
                                label_pp_attaque_deux.Visible = true;

                                string typeAttaque2 = pokemonJoueurSelectionner.getAttaque2().getTypeAttaque();
                                if (typeAttaque2 != null)
                                {
                                    Bitmap pngTypeAttaque2 = new Bitmap(AppDomain.CurrentDomain.BaseDirectory + "\\Images\\Types\\" + typeAttaque2 + ".png");
                                    pictureBoxTypeAttaque2.Image = pngTypeAttaque2;
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
                                        btn_attaque_trois.Text = pokemonJoueurSelectionner.getAttaque3().getNom();
                                        btn_attaque_trois.Visible = true;
                                        label_pp_attaque_trois.Text = "PP " + pokemonJoueurSelectionner.getAttaque3().getPPRestant() + "/" + pokemonJoueurSelectionner.getAttaque3().getPP();
                                        label_pp_attaque_trois.Visible = true;

                                        string typeAttaque3 = pokemonJoueurSelectionner.getAttaque3().getTypeAttaque();
                                        if (typeAttaque3 != null)
                                        {
                                            Bitmap pngTypeAttaque3 = new Bitmap(AppDomain.CurrentDomain.BaseDirectory + "\\Images\\Types\\" + typeAttaque3 + ".png");
                                            pictureBoxTypeAttaque3.Image = pngTypeAttaque3;
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
                                                btn_attaque_quatre.Text = pokemonJoueurSelectionner.getAttaque4().getNom();
                                                btn_attaque_quatre.Visible = true;
                                                label_pp_attaque_quatre.Text = "PP " + pokemonJoueurSelectionner.getAttaque4().getPPRestant() + "/" + pokemonJoueurSelectionner.getAttaque4().getPP();
                                                label_pp_attaque_quatre.Visible = true;

                                                string typeAttaque4 = pokemonJoueurSelectionner.getAttaque4().getTypeAttaque();
                                                if (typeAttaque4 != null)
                                                {
                                                    Bitmap pngTypeAttaque4 = new Bitmap(AppDomain.CurrentDomain.BaseDirectory + "\\Images\\Types\\" + typeAttaque4 + ".png");
                                                    pictureBoxTypeAttaque4.Image = pngTypeAttaque4;
                                                    pictureBoxTypeAttaque4.Visible = true;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
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
                bt_choixPokemon.PerformClick();
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
            if (Joueur.getPokemonEquipe().Count < 6)
            {
                /*
                pictureBoxPokemonCombatAdversaire.Controls.Add(pictureBox1);
                pictureBox1.Location = new Point(0, 0);
                pictureBox1.BackColor = Color.Transparent; */

                btn_choix_pokeball.Visible = false;
                cb_choix_pokeball.Visible = false; 

                pictureBoxPokeball = new PictureBox();
                pictureBoxPokeball.Size = new Size(40, 40);
                this.Controls.Add(pictureBoxPokeball);

                pictureBoxPokeball.Location = new System.Drawing.Point(900, 415);

                this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true); 
                Bitmap pngPokeball = new Bitmap(AppDomain.CurrentDomain.BaseDirectory + "\\Images\\" + "Pokeball\\" + cb_choix_pokeball.SelectedItem + "_1" + ".png"); 

                pictureBoxPokeball.Image = pngPokeball;

                // pictureBoxPokeball.Image.RotateFlip(RotateFlipType.Rotate180FlipY);
                pictureBoxPokeball.SizeMode = PictureBoxSizeMode.CenterImage;
                pictureBoxPokeball.BringToFront();

                rafraichirAnimationCapture();


            }
            else
            {
                MessageBox.Show("Vous n'avez plus de place pour attraper un pokemon");
            }
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

                Bitmap pngPokeball = new Bitmap(AppDomain.CurrentDomain.BaseDirectory + "\\Images\\" + "Pokeball\\" + cb_choix_pokeball.SelectedItem + "_2" + ".png");
                pictureBoxPokeball.Image = pngPokeball;   
                compteurAnimationCapturePartie2++;
            }
            else if(compteurAnimationCapturePartie1 >= 8 && compteurAnimationCapturePartie2 >= 5 && compteurAnimationCapturePartie3 < 9)
            {
                if (compteurAnimationCapturePartie2 == 5)
                {
                    pictureBoxPokemonCombatAdversaire.Visible = false;
                    Bitmap pngPokeball = new Bitmap(AppDomain.CurrentDomain.BaseDirectory + "\\Images\\" + "Pokeball\\" + cb_choix_pokeball.SelectedItem + "_1" + ".png");
                    pictureBoxPokeball.Image = pngPokeball;
                }


                pictureBoxPokeball.Location = new System.Drawing.Point((int)positionX, (int)positionY + ((int)compteurAnimationCapturePartie3 * 2));

                compteurAnimationCapturePartie3++;
            }
            else if(compteurAnimationCapturePartie3 >= 9 && compteurAnimationCapturePartie5 < 9)
            {
                pictureBoxPokeball.Location = new System.Drawing.Point(900 + (((int)compteurAnimationCapturePartie1 - 1) * 16) + (int)Math.Cos(compteurAnimationCapturePartie4) * 4, (int)positionY + (((int)compteurAnimationCapturePartie3 - 1) * 2));
                if (compteurAnimationCapturePartie4 % 2 == 0)
                {
                    compteurAnimationCapturePartie4++;
                }
                else
                {
                    compteurAnimationCapturePartie4--;
                }
                compteurAnimationCapturePartie5++;
            }
            else
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

                Joueur.attraperPokemon(pokemon);
                pokemon.setIdPokemon(pokemon);

                textBox1.Text += "Vous avez attrapé un " + pokemon.getNom() + " !" + Environment.NewLine;

                combat_btn.Enabled = true;
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

                label_pokemon[Joueur.getPokemonEquipe().Count - 1].Text = Joueur.getPokemonEquipe()[Joueur.getPokemonEquipe().Count - 1].getNom();
                label_pv_pokemon[Joueur.getPokemonEquipe().Count - 1].Text = Joueur.getPokemonEquipe()[Joueur.getPokemonEquipe().Count - 1].getPvRestant().ToString() + " / " + Joueur.getPokemonEquipe()[Joueur.getPokemonEquipe().Count - 1].getPv().ToString() + " PV";

                label_pokemon[Joueur.getPokemonEquipe().Count - 1].Visible = true;
                label_pv_pokemon[Joueur.getPokemonEquipe().Count - 1].Visible = true;
                radioBtn_pokemon[Joueur.getPokemonEquipe().Count - 1].Visible = true;

                // pokemon.setPvRestant(0);
                // rafraichirBarreViePokemonAdversaire1();

                int idPokedexImage = Joueur.getPokemonEquipe()[Joueur.getPokemonEquipe().Count - 1].getNoIdPokedex();
                Bitmap png = new Bitmap(AppDomain.CurrentDomain.BaseDirectory + "\\Images\\" + idPokedexImage + ".png");
                pictureBoxPokemon[Joueur.getPokemonEquipe().Count - 1].Image = png;
                pictureBoxPokemon[Joueur.getPokemonEquipe().Count - 1].Image.RotateFlip(RotateFlipType.Rotate180FlipY);

                compteurAnimationCapturePartie1 = 0;
                compteurAnimationCapturePartie2 = 0;
                compteurAnimationCapturePartie3 = 0;
                compteurAnimationCapturePartie4 = 0;
                compteurAnimationCapturePartie5 = 0;
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

                if (pokemon.getPvRestant() > 0)
                { 
                textBox1.Text += pokemon.getNom() + " adverse a fait " + nbDegats + " dégâts " + Environment.NewLine;
                }

                if (gagnePvPokemonJoueur == true)
                {
                    compteur = pokemonJoueurSelectionner.getPvRestant();
                    gagnePvPokemonJoueur = false;
                    
                    rafraichirBarreViePokemonJoueur();
                }

                else if (pokemonJoueurSelectionner.getPvRestant() > 0 && pokemon.getPvRestant() > 0 && gagnePvPokemonJoueur == false)
                {
                    /*
                    btn_attaque1.Enabled = true;
                    btn_soigner.Enabled = true;
                    btn_attraper.Enabled = true;
                    btn_changement_pokemon.Enabled = true; */
                }

                if (pokemonJoueurAttaquePremier == false)
                {
                    rafraichirBarreViePokemonAdversaire();
                    /*
                    btn_attaque1.Enabled = true;
                    btn_soigner.Enabled = true;
                    btn_attraper.Enabled = true;
                    btn_changement_pokemon.Enabled = true; */
                }
                else if(pokemonJoueurAttaquePremier == false && pokemon.getPvRestant() <= 0)
                {

                }
                else if(pokemonJoueurAttaquePremier == true && pokemon.getPvRestant() > 0)
                {   
                    btn_attaque1.Enabled = true;
                    btn_soigner.Enabled = true;
                    btn_attraper.Enabled = true;
                    btn_changement_pokemon.Enabled = true;

                    btn_attaque1.Focus();
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

                textBox1.Text += pokemonJoueurSelectionner.getNom() + " a fait " + nbDegats + " dégâts " + Environment.NewLine;

                if (pokemon.getPvRestant() <= 0)
                {
                    label_pv_pokemon_combat_adversaire.Text = "K.O.";
                    textBox1.Text += pokemon.getNom() + " sauvage est K.O." + Environment.NewLine;

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

                    rafraichirBarreExperiencePokemonJoueur();

                }

                if (pokemonJoueurAttaquePremier == true)
                {
                    rafraichirBarreViePokemonJoueur();

                   // pokemonJoueurAttaquePremier = false;
                }
                else if(pokemonJoueurAttaquePremier == false && pokemon.getPvRestant() > 0)
                {
                    btn_attaque1.Enabled = true;
                    btn_soigner.Enabled = true;
                    btn_attraper.Enabled = true;
                    btn_changement_pokemon.Enabled = true;

                    btn_attaque1.Focus();
                }

            }
        }
    }
}
