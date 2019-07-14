using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form2 : Form
    {
        ClassLibrary2.Pokemon pokemon = new ClassLibrary2.Pokemon();
        frmSaisiesBoutons fenetre1;

        public void pokemonSelectionner(ClassLibrary2.Pokemon PokemonSelectionner)
        {
            pokemon = PokemonSelectionner;             
        }

        public Form2(frmSaisiesBoutons fenetre)
        {
            InitializeComponent();

            fenetre1 = fenetre;
        }


        private void Form2_Load(object sender, EventArgs e)
        {
            int idPokedexImage = pokemon.getNoIdPokedex();
            Bitmap png = new Bitmap(AppDomain.CurrentDomain.BaseDirectory + "\\Images\\" + idPokedexImage + ".png");
            pictureBoxPokemonStatistiques.Image = png;
            pictureBoxPokemonStatistiques.Image.RotateFlip(RotateFlipType.Rotate180FlipY);

            label_nom_pokemon.Text = pokemon.getNom();
            label_niveau_pokemon.Text = "N " + pokemon.getNiveau();

            if (pokemon.getSexe() == "Feminin")
            {
                label_sexe_pokemon.Text = "♀";
                label_sexe_pokemon.ForeColor = Color.Pink;
            }
            else if (pokemon.getSexe() == "Masculin")
            {
                label_sexe_pokemon.Text = "♂";
                label_sexe_pokemon.ForeColor = Color.Blue;
            }

            label_pv.Text = " / " + pokemon.getPv().ToString();
            label_pv_restant.Text = pokemon.getPvRestant().ToString();
            label_attaque.Text = "Attaque : " + pokemon.getStatistiquesAttaque().ToString();
            label_defense.Text = "Defense : " + pokemon.getStatistiquesDefense().ToString();
            label_vitesse.Text = "Vitesse : " + pokemon.getStatistiquesVitesse().ToString();
            label_attaque_speciale.Text = "Attaque Spéciale : " + pokemon.getStatistiquesAttaqueSpeciale().ToString();
            label_defense_speciale.Text = "Defense Spéciale : " + pokemon.getStatistiquesDefenseSpeciale().ToString();
            label_experience_pokemon.Text = "Expérience : " + pokemon.getExperience().ToString();

            label_ev_pv.Text = "EV PV : " + pokemon.getEvPv().ToString();
            label_ev_attaque.Text = "EV Attaque : " + pokemon.getEvAttaque().ToString();
            label_ev_defense.Text = "EV Defense : " + pokemon.getEvDefense().ToString();
            label_ev_vitesse.Text = "EV Vitesse : " + pokemon.getEvVitesse().ToString();
            label_ev_attaque_speciale.Text = "EV Attaque Spéciale : " + pokemon.getEvAttaqueSpeciale().ToString();
            label_ev_defense_speciale.Text = "EV Defense Spéciale : " + pokemon.getEvDefenseSpeciale().ToString();

            if (pokemon.getType() != null)
            {
                string typePokemon = pokemon.getType();
                Bitmap pngTypePokemon = new Bitmap(AppDomain.CurrentDomain.BaseDirectory + "\\Images\\Types\\" + typePokemon + ".png");
                pictureBoxTypePokemon.Image = pngTypePokemon;
                pictureBoxTypePokemon.Visible = true;
            }

            if (pokemon.getListeAttaque().Count > 0)
            {
                if (pokemon.getAttaque1().getNom() != "default")
                {
                    label_attaque_une.Text = pokemon.getAttaque1().getNom();
                    label_attaque_une.Visible = true;

                    string typeAttaque1 = pokemon.getAttaque1().getTypeAttaque();
                    if (typeAttaque1 != null)
                    {
                        Bitmap pngTypeAttaque1 = new Bitmap(AppDomain.CurrentDomain.BaseDirectory + "\\Images\\Types\\" + typeAttaque1 + ".png");
                        pictureBoxTypeAttaque1.Image = pngTypeAttaque1;
                        pictureBoxTypeAttaque1.Visible = true;
                    }
                }

                if (pokemon.getListeAttaque().Count > 1)
                {
                    if (pokemon.getAttaque2().getNom() != "default")
                    {
                        label_attaque_deux.Text = pokemon.getAttaque2().getNom();
                        label_attaque_deux.Visible = true;

                        string typeAttaque2 = pokemon.getAttaque2().getTypeAttaque();
                        if (typeAttaque2 != null)
                        {
                            Bitmap pngTypeAttaque2 = new Bitmap(AppDomain.CurrentDomain.BaseDirectory + "\\Images\\Types\\" + typeAttaque2 + ".png");
                            pictureBoxTypeAttaque2.Image = pngTypeAttaque2;
                            pictureBoxTypeAttaque2.Visible = true;
                        }
                    }

                    if (pokemon.getListeAttaque().Count > 2)
                    {
                        if (pokemon.getAttaque3().getNom() != "default")
                        {
                            label_attaque_trois.Text = pokemon.getAttaque3().getNom();
                            label_attaque_trois.Visible = true;

                            string typeAttaque3 = pokemon.getAttaque3().getTypeAttaque();
                            if (typeAttaque3 != null)
                            {
                                Bitmap pngTypeAttaque3 = new Bitmap(AppDomain.CurrentDomain.BaseDirectory + "\\Images\\Types\\" + typeAttaque3 + ".png");
                                pictureBoxTypeAttaque3.Image = pngTypeAttaque3;
                                pictureBoxTypeAttaque3.Visible = true;
                            }
                        }

                        if (pokemon.getListeAttaque().Count > 3)
                        {
                            if (pokemon.getAttaque4().getNom() != "default")
                            {
                                label_attaque_quatre.Text = pokemon.getAttaque4().getNom();
                                label_attaque_quatre.Visible = true;

                                string typeAttaque4 = pokemon.getAttaque4().getTypeAttaque();
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

            else
            {
                MessageBox.Show("Le pokemon n'a aucune attaque", "Vérification des attaques", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        

        private void btn_retour_changement_pokemon_Click(object sender, EventArgs e)
        {
            fenetre1.Enabled = true;
            this.Close();
          
          
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            fenetre1.Enabled = true;
        }
    }
}
