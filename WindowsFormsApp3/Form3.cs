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
    public partial class Form3 : Form
    {
        ClassLibrary2.Personnage Joueur = new ClassLibrary2.Personnage();
        frmSaisiesBoutons fenetre1;
        List<Button> btn_pokemon = new List<Button>();
        PictureBox pictureBoxBackgroundBoite = new PictureBox();
        PictureBox pictureBoxCurseurChoixPokemon = new PictureBox();

        public void personnageSelectionner(ClassLibrary2.Personnage personnageSelectionner)
        {
            Joueur = personnageSelectionner;
        } 

        public Form3(frmSaisiesBoutons fenetre)
        {
            InitializeComponent();

            fenetre1 = fenetre;
        }

        private void btn_pokemon_Click(object sender, EventArgs e)
        {
            int positionTrouver = 0;
            ClassLibrary2.Pokemon pokemonJoueurStatistiquesSelectionner = new ClassLibrary2.Pokemon();

            for (int i = 0; i < Joueur.getPokemonPc().Count; i++)
            {
                if (btn_pokemon[i].Focused == true)
                {
                    positionTrouver = i;
                }
            }

            pictureBoxCurseurChoixPokemon.Location = new System.Drawing.Point(btn_pokemon[positionTrouver].Location.X + 28, btn_pokemon[positionTrouver].Location.Y - 41);
            pokemonJoueurStatistiquesSelectionner = Joueur.getPokemonPc()[positionTrouver];


            this.Enabled = false;

            Form2 fenetreStatistiquesPokemon = new Form2(this);

            fenetreStatistiquesPokemon.pokemonSelectionner(pokemonJoueurStatistiquesSelectionner);
            fenetreStatistiquesPokemon.Show();
        }

        private void btn_pokemon_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.Right || e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                e.IsInputKey = true;
            }
        }

        private void btn_pokemon_KeyDown(object sender, KeyEventArgs e)
        {
            int positionTrouver = 0;

            for (int i = 0; i < Joueur.getPokemonPc().Count; i++)
            {
                if (btn_pokemon[i].Focused == true)
                {
                    positionTrouver = i;                
                }
            }

            if (e.KeyCode == Keys.Right)
            {
                if (positionTrouver + 1 < Joueur.getPokemonPc().Count)
                {
                    btn_pokemon[positionTrouver + 1].Focus();
                    if (pictureBoxCurseurChoixPokemon.Location.X + 120 < 620)
                    {
                        pictureBoxCurseurChoixPokemon.Location = new System.Drawing.Point(pictureBoxCurseurChoixPokemon.Location.X + 120, pictureBoxCurseurChoixPokemon.Location.Y);
                    }
                    else
                    {
                        pictureBoxCurseurChoixPokemon.Location = new System.Drawing.Point(68, pictureBoxCurseurChoixPokemon.Location.Y + 120);
                    }
                }
            }

            else if(e.KeyCode == Keys.Left)
            {
                if (positionTrouver - 1 >= 0)
                {
                    btn_pokemon[positionTrouver - 1].Focus();
                    if (pictureBoxCurseurChoixPokemon.Location.X - 120 > 0)
                    {
                        pictureBoxCurseurChoixPokemon.Location = new System.Drawing.Point(pictureBoxCurseurChoixPokemon.Location.X - 120, pictureBoxCurseurChoixPokemon.Location.Y);
                    }
                    else
                    {
                        pictureBoxCurseurChoixPokemon.Location = new System.Drawing.Point(548, pictureBoxCurseurChoixPokemon.Location.Y - 120);
                    }
                }
            }

            else if (e.KeyCode == Keys.Up)
            {
                if (positionTrouver - 5 >= 0)
                {
                    btn_pokemon[positionTrouver - 5].Focus();
                    if (pictureBoxCurseurChoixPokemon.Location.Y - 120 > 0)
                    {
                        pictureBoxCurseurChoixPokemon.Location = new System.Drawing.Point(pictureBoxCurseurChoixPokemon.Location.X, pictureBoxCurseurChoixPokemon.Location.Y - 120);
                    }
                }
            }

            else if (e.KeyCode == Keys.Down)
            {
                if (positionTrouver + 5 < Joueur.getPokemonPc().Count)
                {
                    btn_pokemon[positionTrouver + 5].Focus();
                    if (pictureBoxCurseurChoixPokemon.Location.Y - 120 < this.Height)
                    {
                        pictureBoxCurseurChoixPokemon.Location = new System.Drawing.Point(pictureBoxCurseurChoixPokemon.Location.X, pictureBoxCurseurChoixPokemon.Location.Y + 120);
                    }
                }
            }
        }


        private void Form3_Load(object sender, EventArgs e)
        {
            Bitmap pngBackground = new Bitmap(AppDomain.CurrentDomain.BaseDirectory + "\\Images\\Boite\\Background.png");
            pictureBoxBackgroundBoite.Size = new Size(960, 540);
            pictureBoxBackgroundBoite.Image = (Image)(new Bitmap(pngBackground, new Size(960, 540)));

            this.Controls.Add(pictureBoxBackgroundBoite);

            if (Joueur.getPokemonPc().Count > 0)
            {
                for (int i = 0; i < 6; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        if (((i * 5) + j) < Joueur.getPokemonPc().Count)
                        {
                            btn_pokemon.Add(new Button());
                            btn_pokemon[(i * 5) + j].Size = new Size(89, 77);
                            // btn_pokemon[(i * 5) + j].SizeMode = PictureBoxSizeMode.CenterImage;
                            btn_pokemon[(i * 5) + j].Location = new System.Drawing.Point(40 + (120 * j), 50 + (120 * i));
                            pictureBoxBackgroundBoite.Controls.Add(btn_pokemon[(i * 5) + j]);

                            int idPokedexImage = Joueur.getPokemonPc()[(i * 5) + j].getNoIdPokedex();
                            Bitmap png = new Bitmap(AppDomain.CurrentDomain.BaseDirectory + "\\Images\\Icones\\" + idPokedexImage + ".png");
                            btn_pokemon[(i * 5) + j].Image = (Image)(new Bitmap(png, new Size(80, 60)));

                            btn_pokemon[(i * 5) + j].FlatStyle = FlatStyle.Flat;
                            btn_pokemon[(i * 5) + j].FlatAppearance.BorderSize = 0;
                            btn_pokemon[(i * 5) + j].BackColor = Color.Transparent;

                            btn_pokemon[(i * 5) + j].Click += btn_pokemon_Click;
                            btn_pokemon[(i * 5) + j].PreviewKeyDown += btn_pokemon_PreviewKeyDown;
                            btn_pokemon[(i * 5) + j].KeyDown += btn_pokemon_KeyDown;
                        }
                    }
                }

                pictureBoxCurseurChoixPokemon.Size = new Size(41, 41);
                pictureBoxCurseurChoixPokemon.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBoxCurseurChoixPokemon.BackColor = Color.Transparent;

                Bitmap pngCurseurChoixPokemon = new Bitmap(AppDomain.CurrentDomain.BaseDirectory + "\\Images\\Curseur.png");
                pictureBoxCurseurChoixPokemon.Image = pngCurseurChoixPokemon;
                pictureBoxBackgroundBoite.Controls.Add(pictureBoxCurseurChoixPokemon);

                pictureBoxCurseurChoixPokemon.Visible = true;

                btn_pokemon[0].Focus();

                pictureBoxCurseurChoixPokemon.Location = new System.Drawing.Point(68, 9);               
            }
        }

        private void Form3_FormClosed(object sender, FormClosedEventArgs e)
        {
            fenetre1.Enabled = true;
        }
    }
}
