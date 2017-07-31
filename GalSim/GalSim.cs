using System;
using System.Windows.Forms;

namespace GalSim
{
    public partial class GalSim : Form
    {
        private PictureBox mainBox;
        private ProgressBar pbExperience;
        private ProgressBar pbHitPoints;
        private PictureBox boxAvatar;

        public GalSim()
        {
            InitializeComponent();

            pbExperience.Value = 0;
            pbHitPoints.Value = 0;
        }
        private void GalSim_Load(object sender, EventArgs e)
        {

        }

        private void InitializeComponent()
        {
            this.mainBox = new System.Windows.Forms.PictureBox();
            this.pbExperience = new System.Windows.Forms.ProgressBar();
            this.pbHitPoints = new System.Windows.Forms.ProgressBar();
            this.boxAvatar = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.mainBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.boxAvatar)).BeginInit();
            this.SuspendLayout();
            // 
            // mainBox
            // 
            this.mainBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.mainBox.Location = new System.Drawing.Point(47, 49);
            this.mainBox.Name = "mainBox";
            this.mainBox.Size = new System.Drawing.Size(520, 340);
            this.mainBox.TabIndex = 0;
            this.mainBox.TabStop = false;
            // 
            // pbExperience
            // 
            this.pbExperience.Location = new System.Drawing.Point(47, 32);
            this.pbExperience.Name = "pbExperience";
            this.pbExperience.Size = new System.Drawing.Size(100, 10);
            this.pbExperience.TabIndex = 1;
            // 
            // pbHitPoints
            // 
            this.pbHitPoints.Location = new System.Drawing.Point(47, 16);
            this.pbHitPoints.Name = "pbHitPoints";
            this.pbHitPoints.Size = new System.Drawing.Size(100, 10);
            this.pbHitPoints.TabIndex = 2;
            // 
            // boxAvatar
            // 
            this.boxAvatar.BackgroundImage = global::GalSim.Properties.Resources.planet_8;
            this.boxAvatar.InitialImage = null;
            this.boxAvatar.Location = new System.Drawing.Point(10, 10);
            this.boxAvatar.Name = "boxAvatar";
            this.boxAvatar.Size = new System.Drawing.Size(32, 32);
            this.boxAvatar.TabIndex = 3;
            this.boxAvatar.TabStop = false;
            // 
            // GalSim
            // 
            this.BackColor = System.Drawing.SystemColors.WindowText;
            this.ClientSize = new System.Drawing.Size(624, 441);
            this.Controls.Add(this.boxAvatar);
            this.Controls.Add(this.pbHitPoints);
            this.Controls.Add(this.pbExperience);
            this.Controls.Add(this.mainBox);
            this.Name = "GalSim";
            this.Text = "Galactix";
            ((System.ComponentModel.ISupportInitialize)(this.mainBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.boxAvatar)).EndInit();
            this.ResumeLayout(false);

        }
    }
}
