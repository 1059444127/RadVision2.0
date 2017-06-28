namespace RadVision
{
    partial class frm_Welcome
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Welcome));
            this.timer_Loading = new System.Windows.Forms.Timer(this.components);
            this.pBx_Loading = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pBx_Loading)).BeginInit();
            this.SuspendLayout();
            // 
            // timer_Loading
            // 
            this.timer_Loading.Interval = 6000;
            this.timer_Loading.Tick += new System.EventHandler(this.timer_Loading_Tick);
            // 
            // pBx_Loading
            // 
            this.pBx_Loading.BackColor = System.Drawing.Color.Transparent;
            this.pBx_Loading.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pBx_Loading.Image = global::RadVision.Properties.Resources.logo_loading;
            this.pBx_Loading.Location = new System.Drawing.Point(0, 0);
            this.pBx_Loading.Margin = new System.Windows.Forms.Padding(0);
            this.pBx_Loading.Name = "pBx_Loading";
            this.pBx_Loading.Size = new System.Drawing.Size(1024, 600);
            this.pBx_Loading.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pBx_Loading.TabIndex = 0;
            this.pBx_Loading.TabStop = false;
            // 
            // frm_Welcome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 600);
            this.Controls.Add(this.pBx_Loading);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frm_Welcome";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "欢迎使用！--上海实和智能";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frm_Welcome_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pBx_Loading)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer_Loading;
        private System.Windows.Forms.PictureBox pBx_Loading;
    }
}