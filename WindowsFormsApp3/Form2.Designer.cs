namespace WindowsFormsApp3
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBoxPokemonStatistiques = new System.Windows.Forms.PictureBox();
            this.label_nom_pokemon = new System.Windows.Forms.Label();
            this.btn_retour_changement_pokemon = new System.Windows.Forms.Button();
            this.label_niveau_pokemon = new System.Windows.Forms.Label();
            this.pictureBoxTypePokemon = new System.Windows.Forms.PictureBox();
            this.label_sexe_pokemon = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageResume = new System.Windows.Forms.TabPage();
            this.tabPageStatistiques = new System.Windows.Forms.TabPage();
            this.label_iv_pv = new System.Windows.Forms.Label();
            this.panel_liste_attaque = new System.Windows.Forms.Panel();
            this.pictureBoxTypeAttaque4 = new System.Windows.Forms.PictureBox();
            this.label_attaque_trois = new System.Windows.Forms.Label();
            this.pictureBoxTypeAttaque3 = new System.Windows.Forms.PictureBox();
            this.label_attaque_deux = new System.Windows.Forms.Label();
            this.pictureBoxTypeAttaque2 = new System.Windows.Forms.PictureBox();
            this.label_attaque_quatre = new System.Windows.Forms.Label();
            this.pictureBoxTypeAttaque1 = new System.Windows.Forms.PictureBox();
            this.label_attaque_une = new System.Windows.Forms.Label();
            this.label_ev_defense_speciale = new System.Windows.Forms.Label();
            this.label_ev_attaque_speciale = new System.Windows.Forms.Label();
            this.label_ev_vitesse = new System.Windows.Forms.Label();
            this.label_pv_restant = new System.Windows.Forms.Label();
            this.label_ev_defense = new System.Windows.Forms.Label();
            this.label_attaque = new System.Windows.Forms.Label();
            this.label_ev_attaque = new System.Windows.Forms.Label();
            this.label_defense = new System.Windows.Forms.Label();
            this.label_ev_pv = new System.Windows.Forms.Label();
            this.label_vitesse = new System.Windows.Forms.Label();
            this.label_experience_pokemon = new System.Windows.Forms.Label();
            this.label_pv = new System.Windows.Forms.Label();
            this.label_attaque_speciale = new System.Windows.Forms.Label();
            this.label_defense_speciale = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPokemonStatistiques)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTypePokemon)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPageResume.SuspendLayout();
            this.tabPageStatistiques.SuspendLayout();
            this.panel_liste_attaque.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTypeAttaque4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTypeAttaque3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTypeAttaque2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTypeAttaque1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxPokemonStatistiques
            // 
            this.pictureBoxPokemonStatistiques.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxPokemonStatistiques.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBoxPokemonStatistiques.Location = new System.Drawing.Point(17, 57);
            this.pictureBoxPokemonStatistiques.Name = "pictureBoxPokemonStatistiques";
            this.pictureBoxPokemonStatistiques.Size = new System.Drawing.Size(89, 77);
            this.pictureBoxPokemonStatistiques.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBoxPokemonStatistiques.TabIndex = 29;
            this.pictureBoxPokemonStatistiques.TabStop = false;
            // 
            // label_nom_pokemon
            // 
            this.label_nom_pokemon.AutoSize = true;
            this.label_nom_pokemon.Location = new System.Drawing.Point(39, 15);
            this.label_nom_pokemon.Name = "label_nom_pokemon";
            this.label_nom_pokemon.Size = new System.Drawing.Size(72, 13);
            this.label_nom_pokemon.TabIndex = 30;
            this.label_nom_pokemon.Text = "nomPokemon";
            // 
            // btn_retour_changement_pokemon
            // 
            this.btn_retour_changement_pokemon.Location = new System.Drawing.Point(31, 193);
            this.btn_retour_changement_pokemon.Name = "btn_retour_changement_pokemon";
            this.btn_retour_changement_pokemon.Size = new System.Drawing.Size(75, 23);
            this.btn_retour_changement_pokemon.TabIndex = 50;
            this.btn_retour_changement_pokemon.Text = "Retour";
            this.btn_retour_changement_pokemon.UseVisualStyleBackColor = true;
            this.btn_retour_changement_pokemon.Click += new System.EventHandler(this.btn_retour_changement_pokemon_Click);
            // 
            // label_niveau_pokemon
            // 
            this.label_niveau_pokemon.AutoSize = true;
            this.label_niveau_pokemon.Location = new System.Drawing.Point(48, 41);
            this.label_niveau_pokemon.Name = "label_niveau_pokemon";
            this.label_niveau_pokemon.Size = new System.Drawing.Size(41, 13);
            this.label_niveau_pokemon.TabIndex = 51;
            this.label_niveau_pokemon.Text = "Niveau";
            // 
            // pictureBoxTypePokemon
            // 
            this.pictureBoxTypePokemon.Location = new System.Drawing.Point(21, 140);
            this.pictureBoxTypePokemon.Name = "pictureBoxTypePokemon";
            this.pictureBoxTypePokemon.Size = new System.Drawing.Size(89, 30);
            this.pictureBoxTypePokemon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBoxTypePokemon.TabIndex = 59;
            this.pictureBoxTypePokemon.TabStop = false;
            this.pictureBoxTypePokemon.Visible = false;
            // 
            // label_sexe_pokemon
            // 
            this.label_sexe_pokemon.AutoSize = true;
            this.label_sexe_pokemon.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label_sexe_pokemon.Location = new System.Drawing.Point(116, 10);
            this.label_sexe_pokemon.Name = "label_sexe_pokemon";
            this.label_sexe_pokemon.Size = new System.Drawing.Size(45, 20);
            this.label_sexe_pokemon.TabIndex = 68;
            this.label_sexe_pokemon.Text = "Sexe";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageResume);
            this.tabControl1.Controls.Add(this.tabPageStatistiques);
            this.tabControl1.Location = new System.Drawing.Point(31, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(678, 319);
            this.tabControl1.TabIndex = 69;
            // 
            // tabPageResume
            // 
            this.tabPageResume.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageResume.Controls.Add(this.label_nom_pokemon);
            this.tabPageResume.Controls.Add(this.label_sexe_pokemon);
            this.tabPageResume.Controls.Add(this.pictureBoxPokemonStatistiques);
            this.tabPageResume.Controls.Add(this.btn_retour_changement_pokemon);
            this.tabPageResume.Controls.Add(this.label_niveau_pokemon);
            this.tabPageResume.Controls.Add(this.pictureBoxTypePokemon);
            this.tabPageResume.Location = new System.Drawing.Point(4, 22);
            this.tabPageResume.Name = "tabPageResume";
            this.tabPageResume.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageResume.Size = new System.Drawing.Size(670, 293);
            this.tabPageResume.TabIndex = 0;
            this.tabPageResume.Text = "Resumé";
            // 
            // tabPageStatistiques
            // 
            this.tabPageStatistiques.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageStatistiques.Controls.Add(this.label_iv_pv);
            this.tabPageStatistiques.Controls.Add(this.panel_liste_attaque);
            this.tabPageStatistiques.Controls.Add(this.label_ev_defense_speciale);
            this.tabPageStatistiques.Controls.Add(this.label_ev_attaque_speciale);
            this.tabPageStatistiques.Controls.Add(this.label_ev_vitesse);
            this.tabPageStatistiques.Controls.Add(this.label_pv_restant);
            this.tabPageStatistiques.Controls.Add(this.label_ev_defense);
            this.tabPageStatistiques.Controls.Add(this.label_attaque);
            this.tabPageStatistiques.Controls.Add(this.label_ev_attaque);
            this.tabPageStatistiques.Controls.Add(this.label_defense);
            this.tabPageStatistiques.Controls.Add(this.label_ev_pv);
            this.tabPageStatistiques.Controls.Add(this.label_vitesse);
            this.tabPageStatistiques.Controls.Add(this.label_experience_pokemon);
            this.tabPageStatistiques.Controls.Add(this.label_pv);
            this.tabPageStatistiques.Controls.Add(this.label_attaque_speciale);
            this.tabPageStatistiques.Controls.Add(this.label_defense_speciale);
            this.tabPageStatistiques.Location = new System.Drawing.Point(4, 22);
            this.tabPageStatistiques.Name = "tabPageStatistiques";
            this.tabPageStatistiques.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageStatistiques.Size = new System.Drawing.Size(670, 293);
            this.tabPageStatistiques.TabIndex = 1;
            this.tabPageStatistiques.Text = "Statistiques";
            // 
            // label_iv_pv
            // 
            this.label_iv_pv.AutoSize = true;
            this.label_iv_pv.Location = new System.Drawing.Point(375, 132);
            this.label_iv_pv.Name = "label_iv_pv";
            this.label_iv_pv.Size = new System.Drawing.Size(34, 13);
            this.label_iv_pv.TabIndex = 83;
            this.label_iv_pv.Text = "IV PV";
            // 
            // panel_liste_attaque
            // 
            this.panel_liste_attaque.Controls.Add(this.pictureBoxTypeAttaque4);
            this.panel_liste_attaque.Controls.Add(this.label_attaque_trois);
            this.panel_liste_attaque.Controls.Add(this.pictureBoxTypeAttaque3);
            this.panel_liste_attaque.Controls.Add(this.label_attaque_deux);
            this.panel_liste_attaque.Controls.Add(this.pictureBoxTypeAttaque2);
            this.panel_liste_attaque.Controls.Add(this.label_attaque_quatre);
            this.panel_liste_attaque.Controls.Add(this.pictureBoxTypeAttaque1);
            this.panel_liste_attaque.Controls.Add(this.label_attaque_une);
            this.panel_liste_attaque.Location = new System.Drawing.Point(99, 105);
            this.panel_liste_attaque.Name = "panel_liste_attaque";
            this.panel_liste_attaque.Size = new System.Drawing.Size(200, 108);
            this.panel_liste_attaque.TabIndex = 68;
            // 
            // pictureBoxTypeAttaque4
            // 
            this.pictureBoxTypeAttaque4.Location = new System.Drawing.Point(129, 83);
            this.pictureBoxTypeAttaque4.Name = "pictureBoxTypeAttaque4";
            this.pictureBoxTypeAttaque4.Size = new System.Drawing.Size(57, 18);
            this.pictureBoxTypeAttaque4.TabIndex = 63;
            this.pictureBoxTypeAttaque4.TabStop = false;
            this.pictureBoxTypeAttaque4.Visible = false;
            // 
            // label_attaque_trois
            // 
            this.label_attaque_trois.AutoSize = true;
            this.label_attaque_trois.Location = new System.Drawing.Point(22, 63);
            this.label_attaque_trois.Name = "label_attaque_trois";
            this.label_attaque_trois.Size = new System.Drawing.Size(53, 13);
            this.label_attaque_trois.TabIndex = 5;
            this.label_attaque_trois.Text = "Attaque 3";
            this.label_attaque_trois.Visible = false;
            // 
            // pictureBoxTypeAttaque3
            // 
            this.pictureBoxTypeAttaque3.Location = new System.Drawing.Point(25, 83);
            this.pictureBoxTypeAttaque3.Name = "pictureBoxTypeAttaque3";
            this.pictureBoxTypeAttaque3.Size = new System.Drawing.Size(57, 18);
            this.pictureBoxTypeAttaque3.TabIndex = 62;
            this.pictureBoxTypeAttaque3.TabStop = false;
            this.pictureBoxTypeAttaque3.Visible = false;
            // 
            // label_attaque_deux
            // 
            this.label_attaque_deux.AutoSize = true;
            this.label_attaque_deux.Location = new System.Drawing.Point(126, 16);
            this.label_attaque_deux.Name = "label_attaque_deux";
            this.label_attaque_deux.Size = new System.Drawing.Size(53, 13);
            this.label_attaque_deux.TabIndex = 4;
            this.label_attaque_deux.Text = "Attaque 2";
            this.label_attaque_deux.Visible = false;
            // 
            // pictureBoxTypeAttaque2
            // 
            this.pictureBoxTypeAttaque2.Location = new System.Drawing.Point(130, 32);
            this.pictureBoxTypeAttaque2.Name = "pictureBoxTypeAttaque2";
            this.pictureBoxTypeAttaque2.Size = new System.Drawing.Size(57, 18);
            this.pictureBoxTypeAttaque2.TabIndex = 61;
            this.pictureBoxTypeAttaque2.TabStop = false;
            this.pictureBoxTypeAttaque2.Visible = false;
            // 
            // label_attaque_quatre
            // 
            this.label_attaque_quatre.AutoSize = true;
            this.label_attaque_quatre.Location = new System.Drawing.Point(126, 63);
            this.label_attaque_quatre.Name = "label_attaque_quatre";
            this.label_attaque_quatre.Size = new System.Drawing.Size(53, 13);
            this.label_attaque_quatre.TabIndex = 3;
            this.label_attaque_quatre.Text = "Attaque 4";
            this.label_attaque_quatre.Visible = false;
            // 
            // pictureBoxTypeAttaque1
            // 
            this.pictureBoxTypeAttaque1.Location = new System.Drawing.Point(24, 32);
            this.pictureBoxTypeAttaque1.Name = "pictureBoxTypeAttaque1";
            this.pictureBoxTypeAttaque1.Size = new System.Drawing.Size(57, 18);
            this.pictureBoxTypeAttaque1.TabIndex = 60;
            this.pictureBoxTypeAttaque1.TabStop = false;
            this.pictureBoxTypeAttaque1.Visible = false;
            // 
            // label_attaque_une
            // 
            this.label_attaque_une.AutoSize = true;
            this.label_attaque_une.Location = new System.Drawing.Point(22, 16);
            this.label_attaque_une.Name = "label_attaque_une";
            this.label_attaque_une.Size = new System.Drawing.Size(53, 13);
            this.label_attaque_une.TabIndex = 0;
            this.label_attaque_une.Text = "Attaque 1";
            this.label_attaque_une.Visible = false;
            // 
            // label_ev_defense_speciale
            // 
            this.label_ev_defense_speciale.AutoSize = true;
            this.label_ev_defense_speciale.Location = new System.Drawing.Point(463, 78);
            this.label_ev_defense_speciale.Name = "label_ev_defense_speciale";
            this.label_ev_defense_speciale.Size = new System.Drawing.Size(108, 13);
            this.label_ev_defense_speciale.TabIndex = 82;
            this.label_ev_defense_speciale.Text = "EV Defense Spéciale";
            // 
            // label_ev_attaque_speciale
            // 
            this.label_ev_attaque_speciale.AutoSize = true;
            this.label_ev_attaque_speciale.Location = new System.Drawing.Point(463, 52);
            this.label_ev_attaque_speciale.Name = "label_ev_attaque_speciale";
            this.label_ev_attaque_speciale.Size = new System.Drawing.Size(105, 13);
            this.label_ev_attaque_speciale.TabIndex = 81;
            this.label_ev_attaque_speciale.Text = "EV Attaque Spéciale";
            // 
            // label_ev_vitesse
            // 
            this.label_ev_vitesse.AutoSize = true;
            this.label_ev_vitesse.Location = new System.Drawing.Point(463, 26);
            this.label_ev_vitesse.Name = "label_ev_vitesse";
            this.label_ev_vitesse.Size = new System.Drawing.Size(58, 13);
            this.label_ev_vitesse.TabIndex = 80;
            this.label_ev_vitesse.Text = "EV Vitesse";
            // 
            // label_pv_restant
            // 
            this.label_pv_restant.AutoSize = true;
            this.label_pv_restant.Location = new System.Drawing.Point(121, 26);
            this.label_pv_restant.Name = "label_pv_restant";
            this.label_pv_restant.Size = new System.Drawing.Size(21, 13);
            this.label_pv_restant.TabIndex = 69;
            this.label_pv_restant.Text = "PV";
            // 
            // label_ev_defense
            // 
            this.label_ev_defense.AutoSize = true;
            this.label_ev_defense.Location = new System.Drawing.Point(375, 78);
            this.label_ev_defense.Name = "label_ev_defense";
            this.label_ev_defense.Size = new System.Drawing.Size(64, 13);
            this.label_ev_defense.TabIndex = 79;
            this.label_ev_defense.Text = "EV Defense";
            // 
            // label_attaque
            // 
            this.label_attaque.AutoSize = true;
            this.label_attaque.Location = new System.Drawing.Point(121, 52);
            this.label_attaque.Name = "label_attaque";
            this.label_attaque.Size = new System.Drawing.Size(44, 13);
            this.label_attaque.TabIndex = 70;
            this.label_attaque.Text = "Attaque";
            // 
            // label_ev_attaque
            // 
            this.label_ev_attaque.AutoSize = true;
            this.label_ev_attaque.Location = new System.Drawing.Point(375, 52);
            this.label_ev_attaque.Name = "label_ev_attaque";
            this.label_ev_attaque.Size = new System.Drawing.Size(61, 13);
            this.label_ev_attaque.TabIndex = 78;
            this.label_ev_attaque.Text = "EV Attaque";
            // 
            // label_defense
            // 
            this.label_defense.AutoSize = true;
            this.label_defense.Location = new System.Drawing.Point(121, 78);
            this.label_defense.Name = "label_defense";
            this.label_defense.Size = new System.Drawing.Size(47, 13);
            this.label_defense.TabIndex = 71;
            this.label_defense.Text = "Defense";
            // 
            // label_ev_pv
            // 
            this.label_ev_pv.AutoSize = true;
            this.label_ev_pv.Location = new System.Drawing.Point(375, 26);
            this.label_ev_pv.Name = "label_ev_pv";
            this.label_ev_pv.Size = new System.Drawing.Size(38, 13);
            this.label_ev_pv.TabIndex = 77;
            this.label_ev_pv.Text = "EV PV";
            // 
            // label_vitesse
            // 
            this.label_vitesse.AutoSize = true;
            this.label_vitesse.Location = new System.Drawing.Point(193, 26);
            this.label_vitesse.Name = "label_vitesse";
            this.label_vitesse.Size = new System.Drawing.Size(41, 13);
            this.label_vitesse.TabIndex = 72;
            this.label_vitesse.Text = "Vitesse";
            // 
            // label_experience_pokemon
            // 
            this.label_experience_pokemon.AutoSize = true;
            this.label_experience_pokemon.Location = new System.Drawing.Point(208, 225);
            this.label_experience_pokemon.Name = "label_experience_pokemon";
            this.label_experience_pokemon.Size = new System.Drawing.Size(60, 13);
            this.label_experience_pokemon.TabIndex = 76;
            this.label_experience_pokemon.Text = "Expérience";
            // 
            // label_pv
            // 
            this.label_pv.AutoSize = true;
            this.label_pv.Location = new System.Drawing.Point(145, 26);
            this.label_pv.Name = "label_pv";
            this.label_pv.Size = new System.Drawing.Size(21, 13);
            this.label_pv.TabIndex = 73;
            this.label_pv.Text = "PV";
            // 
            // label_attaque_speciale
            // 
            this.label_attaque_speciale.AutoSize = true;
            this.label_attaque_speciale.Location = new System.Drawing.Point(193, 52);
            this.label_attaque_speciale.Name = "label_attaque_speciale";
            this.label_attaque_speciale.Size = new System.Drawing.Size(88, 13);
            this.label_attaque_speciale.TabIndex = 74;
            this.label_attaque_speciale.Text = "Attaque Spéciale";
            // 
            // label_defense_speciale
            // 
            this.label_defense_speciale.AutoSize = true;
            this.label_defense_speciale.Location = new System.Drawing.Point(193, 78);
            this.label_defense_speciale.Name = "label_defense_speciale";
            this.label_defense_speciale.Size = new System.Drawing.Size(91, 13);
            this.label_defense_speciale.TabIndex = 75;
            this.label_defense_speciale.Text = "Defense Spéciale";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(814, 368);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form2";
            this.Text = "Form2";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form2_FormClosed);
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPokemonStatistiques)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTypePokemon)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPageResume.ResumeLayout(false);
            this.tabPageResume.PerformLayout();
            this.tabPageStatistiques.ResumeLayout(false);
            this.tabPageStatistiques.PerformLayout();
            this.panel_liste_attaque.ResumeLayout(false);
            this.panel_liste_attaque.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTypeAttaque4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTypeAttaque3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTypeAttaque2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTypeAttaque1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxPokemonStatistiques;
        private System.Windows.Forms.Label label_nom_pokemon;
        private System.Windows.Forms.Button btn_retour_changement_pokemon;
        private System.Windows.Forms.Label label_niveau_pokemon;
        private System.Windows.Forms.PictureBox pictureBoxTypePokemon;
        private System.Windows.Forms.Label label_sexe_pokemon;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageResume;
        private System.Windows.Forms.TabPage tabPageStatistiques;
        private System.Windows.Forms.Label label_iv_pv;
        private System.Windows.Forms.Panel panel_liste_attaque;
        private System.Windows.Forms.PictureBox pictureBoxTypeAttaque4;
        private System.Windows.Forms.Label label_attaque_trois;
        private System.Windows.Forms.PictureBox pictureBoxTypeAttaque3;
        private System.Windows.Forms.Label label_attaque_deux;
        private System.Windows.Forms.PictureBox pictureBoxTypeAttaque2;
        private System.Windows.Forms.Label label_attaque_quatre;
        private System.Windows.Forms.PictureBox pictureBoxTypeAttaque1;
        private System.Windows.Forms.Label label_attaque_une;
        private System.Windows.Forms.Label label_ev_defense_speciale;
        private System.Windows.Forms.Label label_ev_attaque_speciale;
        private System.Windows.Forms.Label label_ev_vitesse;
        private System.Windows.Forms.Label label_pv_restant;
        private System.Windows.Forms.Label label_ev_defense;
        private System.Windows.Forms.Label label_attaque;
        private System.Windows.Forms.Label label_ev_attaque;
        private System.Windows.Forms.Label label_defense;
        private System.Windows.Forms.Label label_ev_pv;
        private System.Windows.Forms.Label label_vitesse;
        private System.Windows.Forms.Label label_experience_pokemon;
        private System.Windows.Forms.Label label_pv;
        private System.Windows.Forms.Label label_attaque_speciale;
        private System.Windows.Forms.Label label_defense_speciale;
    }
}