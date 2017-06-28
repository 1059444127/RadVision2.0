namespace RadVision
{
    partial class frm_Main
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Main));
            this.label_Week = new System.Windows.Forms.Label();
            this.label_Date = new System.Windows.Forms.Label();
            this.pBx_SwitchNet = new System.Windows.Forms.PictureBox();
            this.panel_Control = new System.Windows.Forms.Panel();
            this.pBx_Down = new System.Windows.Forms.PictureBox();
            this.pBx_Up = new System.Windows.Forms.PictureBox();
            this.pBx_ModeStandUp = new System.Windows.Forms.PictureBox();
            this.pBx_ModeSitDown = new System.Windows.Forms.PictureBox();
            this.pBx_Tips = new System.Windows.Forms.PictureBox();
            this.label_Tips = new System.Windows.Forms.Label();
            this.panel_Time = new System.Windows.Forms.Panel();
            this.label_Minute = new System.Windows.Forms.Label();
            this.label = new System.Windows.Forms.Label();
            this.label_Hour = new System.Windows.Forms.Label();
            this.label_Distance = new System.Windows.Forms.Label();
            this.label_Dicom = new System.Windows.Forms.Label();
            this.DistancePort = new System.IO.Ports.SerialPort(this.components);
            this.pBx_ResetPoint = new System.Windows.Forms.PictureBox();
            this.panel_HealthyNotice = new System.Windows.Forms.Panel();
            this.pBx_ContinuTimer = new System.Windows.Forms.PictureBox();
            this.pBx_ExitTimer = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pBx_SwitchNet)).BeginInit();
            this.panel_Control.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pBx_Down)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBx_Up)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBx_ModeStandUp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBx_ModeSitDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBx_Tips)).BeginInit();
            this.panel_Time.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pBx_ResetPoint)).BeginInit();
            this.panel_HealthyNotice.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pBx_ContinuTimer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBx_ExitTimer)).BeginInit();
            this.SuspendLayout();
            // 
            // label_Week
            // 
            this.label_Week.AutoSize = true;
            this.label_Week.BackColor = System.Drawing.Color.Transparent;
            this.label_Week.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label_Week.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label_Week.ForeColor = System.Drawing.Color.White;
            this.label_Week.Location = new System.Drawing.Point(213, 60);
            this.label_Week.Name = "label_Week";
            this.label_Week.Size = new System.Drawing.Size(95, 31);
            this.label_Week.TabIndex = 2;
            this.label_Week.Text = "星期五";
            // 
            // label_Date
            // 
            this.label_Date.AutoSize = true;
            this.label_Date.BackColor = System.Drawing.Color.Transparent;
            this.label_Date.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label_Date.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label_Date.ForeColor = System.Drawing.Color.White;
            this.label_Date.Location = new System.Drawing.Point(331, 60);
            this.label_Date.Name = "label_Date";
            this.label_Date.Size = new System.Drawing.Size(135, 31);
            this.label_Date.TabIndex = 3;
            this.label_Date.Text = "2017/3/10";
            // 
            // pBx_SwitchNet
            // 
            this.pBx_SwitchNet.BackColor = System.Drawing.Color.Transparent;
            this.pBx_SwitchNet.Image = global::RadVision.Properties.Resources.outer_net;
            this.pBx_SwitchNet.Location = new System.Drawing.Point(754, 82);
            this.pBx_SwitchNet.Name = "pBx_SwitchNet";
            this.pBx_SwitchNet.Size = new System.Drawing.Size(174, 83);
            this.pBx_SwitchNet.TabIndex = 6;
            this.pBx_SwitchNet.TabStop = false;
            this.pBx_SwitchNet.Click += new System.EventHandler(this.pBx_SwitchNet_Click);
            // 
            // panel_Control
            // 
            this.panel_Control.BackColor = System.Drawing.Color.Transparent;
            this.panel_Control.BackgroundImage = global::RadVision.Properties.Resources.buttons_background;
            this.panel_Control.Controls.Add(this.pBx_Down);
            this.panel_Control.Controls.Add(this.pBx_Up);
            this.panel_Control.Location = new System.Drawing.Point(778, 209);
            this.panel_Control.Name = "panel_Control";
            this.panel_Control.Size = new System.Drawing.Size(128, 254);
            this.panel_Control.TabIndex = 7;
            // 
            // pBx_Down
            // 
            this.pBx_Down.Image = global::RadVision.Properties.Resources.down_1;
            this.pBx_Down.Location = new System.Drawing.Point(12, 137);
            this.pBx_Down.Margin = new System.Windows.Forms.Padding(0);
            this.pBx_Down.Name = "pBx_Down";
            this.pBx_Down.Size = new System.Drawing.Size(106, 105);
            this.pBx_Down.TabIndex = 9;
            this.pBx_Down.TabStop = false;
            this.pBx_Down.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pBx_Down_MouseDown);
            this.pBx_Down.MouseEnter += new System.EventHandler(this.pBx_Down_MouseEnter);
            this.pBx_Down.MouseLeave += new System.EventHandler(this.pBx_Down_MouseLeave);
            this.pBx_Down.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pBx_Down_MouseUp);
            // 
            // pBx_Up
            // 
            this.pBx_Up.Image = global::RadVision.Properties.Resources.up_1;
            this.pBx_Up.Location = new System.Drawing.Point(12, 15);
            this.pBx_Up.Margin = new System.Windows.Forms.Padding(0);
            this.pBx_Up.Name = "pBx_Up";
            this.pBx_Up.Size = new System.Drawing.Size(106, 105);
            this.pBx_Up.TabIndex = 8;
            this.pBx_Up.TabStop = false;
            this.pBx_Up.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pBx_Up_MouseDown);
            this.pBx_Up.MouseEnter += new System.EventHandler(this.pBx_Up_MouseEnter);
            this.pBx_Up.MouseLeave += new System.EventHandler(this.pBx_Up_MouseLeave);
            this.pBx_Up.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pBx_Up_MouseUp);
            // 
            // pBx_ModeStandUp
            // 
            this.pBx_ModeStandUp.BackColor = System.Drawing.Color.Transparent;
            this.pBx_ModeStandUp.Image = global::RadVision.Properties.Resources.stand_up_1;
            this.pBx_ModeStandUp.Location = new System.Drawing.Point(148, 224);
            this.pBx_ModeStandUp.Margin = new System.Windows.Forms.Padding(0);
            this.pBx_ModeStandUp.Name = "pBx_ModeStandUp";
            this.pBx_ModeStandUp.Size = new System.Drawing.Size(101, 102);
            this.pBx_ModeStandUp.TabIndex = 10;
            this.pBx_ModeStandUp.TabStop = false;
            this.pBx_ModeStandUp.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ModeStandUp_MouseDown);
            this.pBx_ModeStandUp.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ModeStandUp_MouseUp);
            // 
            // pBx_ModeSitDown
            // 
            this.pBx_ModeSitDown.BackColor = System.Drawing.Color.Transparent;
            this.pBx_ModeSitDown.Image = global::RadVision.Properties.Resources.sit_down_1;
            this.pBx_ModeSitDown.Location = new System.Drawing.Point(148, 349);
            this.pBx_ModeSitDown.Margin = new System.Windows.Forms.Padding(0);
            this.pBx_ModeSitDown.Name = "pBx_ModeSitDown";
            this.pBx_ModeSitDown.Size = new System.Drawing.Size(101, 102);
            this.pBx_ModeSitDown.TabIndex = 11;
            this.pBx_ModeSitDown.TabStop = false;
            this.pBx_ModeSitDown.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ModeSitDown_MouseDown);
            this.pBx_ModeSitDown.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ModeSitDown_MouseUp);
            // 
            // pBx_Tips
            // 
            this.pBx_Tips.BackColor = System.Drawing.Color.Transparent;
            this.pBx_Tips.Image = global::RadVision.Properties.Resources.notice;
            this.pBx_Tips.Location = new System.Drawing.Point(98, 140);
            this.pBx_Tips.Name = "pBx_Tips";
            this.pBx_Tips.Size = new System.Drawing.Size(39, 36);
            this.pBx_Tips.TabIndex = 12;
            this.pBx_Tips.TabStop = false;
            // 
            // label_Tips
            // 
            this.label_Tips.AutoSize = true;
            this.label_Tips.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_Tips.Location = new System.Drawing.Point(143, 143);
            this.label_Tips.Name = "label_Tips";
            this.label_Tips.Size = new System.Drawing.Size(432, 27);
            this.label_Tips.TabIndex = 13;
            this.label_Tips.Text = "温馨提示：关机时请依次关闭内网、外网主机！";
            // 
            // panel_Time
            // 
            this.panel_Time.BackColor = System.Drawing.Color.Transparent;
            this.panel_Time.Controls.Add(this.label_Minute);
            this.panel_Time.Controls.Add(this.label);
            this.panel_Time.Controls.Add(this.label_Hour);
            this.panel_Time.Controls.Add(this.label_Week);
            this.panel_Time.Controls.Add(this.label_Date);
            this.panel_Time.Location = new System.Drawing.Point(88, 10);
            this.panel_Time.Name = "panel_Time";
            this.panel_Time.Size = new System.Drawing.Size(508, 108);
            this.panel_Time.TabIndex = 19;
            // 
            // label_Minute
            // 
            this.label_Minute.AutoSize = true;
            this.label_Minute.BackColor = System.Drawing.Color.Transparent;
            this.label_Minute.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label_Minute.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label_Minute.ForeColor = System.Drawing.Color.White;
            this.label_Minute.Location = new System.Drawing.Point(121, 49);
            this.label_Minute.Name = "label_Minute";
            this.label_Minute.Size = new System.Drawing.Size(64, 46);
            this.label_Minute.TabIndex = 6;
            this.label_Minute.Text = "22";
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.BackColor = System.Drawing.Color.Transparent;
            this.label.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label.ForeColor = System.Drawing.Color.White;
            this.label.Location = new System.Drawing.Point(93, 49);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(31, 46);
            this.label.TabIndex = 5;
            this.label.Text = ":";
            // 
            // label_Hour
            // 
            this.label_Hour.AutoSize = true;
            this.label_Hour.BackColor = System.Drawing.Color.Transparent;
            this.label_Hour.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label_Hour.Font = new System.Drawing.Font("Microsoft Sans Serif", 39.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label_Hour.ForeColor = System.Drawing.Color.White;
            this.label_Hour.Location = new System.Drawing.Point(14, 37);
            this.label_Hour.Name = "label_Hour";
            this.label_Hour.Size = new System.Drawing.Size(85, 61);
            this.label_Hour.TabIndex = 4;
            this.label_Hour.Text = "22";
            // 
            // label_Distance
            // 
            this.label_Distance.AutoSize = true;
            this.label_Distance.BackColor = System.Drawing.Color.Transparent;
            this.label_Distance.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label_Distance.ForeColor = System.Drawing.Color.Aqua;
            this.label_Distance.Location = new System.Drawing.Point(467, 382);
            this.label_Distance.Name = "label_Distance";
            this.label_Distance.Size = new System.Drawing.Size(87, 31);
            this.label_Distance.TabIndex = 5;
            this.label_Distance.Text = "75 cm";
            // 
            // label_Dicom
            // 
            this.label_Dicom.AutoSize = true;
            this.label_Dicom.BackColor = System.Drawing.Color.Transparent;
            this.label_Dicom.Font = new System.Drawing.Font("Microsoft Sans Serif", 24.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label_Dicom.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label_Dicom.Location = new System.Drawing.Point(418, 303);
            this.label_Dicom.Name = "label_Dicom";
            this.label_Dicom.Size = new System.Drawing.Size(198, 38);
            this.label_Dicom.TabIndex = 15;
            this.label_Dicom.Text = "DICOM: 450";
            // 
            // pBx_ResetPoint
            // 
            this.pBx_ResetPoint.BackColor = System.Drawing.Color.Transparent;
            this.pBx_ResetPoint.Image = global::RadVision.Properties.Resources.ResetPoint1;
            this.pBx_ResetPoint.Location = new System.Drawing.Point(933, 20);
            this.pBx_ResetPoint.Margin = new System.Windows.Forms.Padding(0);
            this.pBx_ResetPoint.Name = "pBx_ResetPoint";
            this.pBx_ResetPoint.Size = new System.Drawing.Size(66, 66);
            this.pBx_ResetPoint.TabIndex = 20;
            this.pBx_ResetPoint.TabStop = false;
            this.pBx_ResetPoint.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pBx_ResetPoint_MouseDown);
            this.pBx_ResetPoint.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pBx_ResetPoint_MouseUp);
            // 
            // panel_HealthyNotice
            // 
            this.panel_HealthyNotice.BackColor = System.Drawing.Color.Transparent;
            this.panel_HealthyNotice.BackgroundImage = global::RadVision.Properties.Resources.healthnoticebackground;
            this.panel_HealthyNotice.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel_HealthyNotice.Controls.Add(this.pBx_ContinuTimer);
            this.panel_HealthyNotice.Controls.Add(this.pBx_ExitTimer);
            this.panel_HealthyNotice.Location = new System.Drawing.Point(621, 224);
            this.panel_HealthyNotice.Name = "panel_HealthyNotice";
            this.panel_HealthyNotice.Size = new System.Drawing.Size(403, 376);
            this.panel_HealthyNotice.TabIndex = 21;
            this.panel_HealthyNotice.Visible = false;
            // 
            // pBx_ContinuTimer
            // 
            this.pBx_ContinuTimer.Image = global::RadVision.Properties.Resources.continutimer1;
            this.pBx_ContinuTimer.Location = new System.Drawing.Point(265, 193);
            this.pBx_ContinuTimer.Name = "pBx_ContinuTimer";
            this.pBx_ContinuTimer.Size = new System.Drawing.Size(60, 28);
            this.pBx_ContinuTimer.TabIndex = 1;
            this.pBx_ContinuTimer.TabStop = false;
            this.pBx_ContinuTimer.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pBx_ContinuTimer_MouseDown);
            this.pBx_ContinuTimer.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pBx_ContinuTimer_MouseUp);
            // 
            // pBx_ExitTimer
            // 
            this.pBx_ExitTimer.Image = global::RadVision.Properties.Resources.exittimer1;
            this.pBx_ExitTimer.Location = new System.Drawing.Point(66, 193);
            this.pBx_ExitTimer.Name = "pBx_ExitTimer";
            this.pBx_ExitTimer.Size = new System.Drawing.Size(120, 28);
            this.pBx_ExitTimer.TabIndex = 0;
            this.pBx_ExitTimer.TabStop = false;
            this.pBx_ExitTimer.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pBx_ExitTimer_MouseDown);
            this.pBx_ExitTimer.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pBx_ExitTimer_MouseUp);
            // 
            // frm_Main
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackgroundImage = global::RadVision.Properties.Resources.background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1024, 600);
            this.Controls.Add(this.panel_HealthyNotice);
            this.Controls.Add(this.pBx_ResetPoint);
            this.Controls.Add(this.panel_Time);
            this.Controls.Add(this.label_Dicom);
            this.Controls.Add(this.label_Tips);
            this.Controls.Add(this.pBx_Tips);
            this.Controls.Add(this.pBx_ModeSitDown);
            this.Controls.Add(this.pBx_ModeStandUp);
            this.Controls.Add(this.panel_Control);
            this.Controls.Add(this.pBx_SwitchNet);
            this.Controls.Add(this.label_Distance);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frm_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "实和智能--RadVision";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frm_Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pBx_SwitchNet)).EndInit();
            this.panel_Control.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pBx_Down)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBx_Up)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBx_ModeStandUp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBx_ModeSitDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBx_Tips)).EndInit();
            this.panel_Time.ResumeLayout(false);
            this.panel_Time.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pBx_ResetPoint)).EndInit();
            this.panel_HealthyNotice.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pBx_ContinuTimer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBx_ExitTimer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label_Week;
        private System.Windows.Forms.Label label_Date;
        private System.Windows.Forms.PictureBox pBx_SwitchNet;
        private System.Windows.Forms.Panel panel_Control;
        private System.Windows.Forms.PictureBox pBx_Up;
        private System.Windows.Forms.PictureBox pBx_Down;
        private System.Windows.Forms.PictureBox pBx_ModeStandUp;
        private System.Windows.Forms.PictureBox pBx_ModeSitDown;
        private System.Windows.Forms.PictureBox pBx_Tips;
        private System.Windows.Forms.Label label_Tips;
        private System.Windows.Forms.Panel panel_Time;
        private System.Windows.Forms.Label label_Hour;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Label label_Minute;
        private System.Windows.Forms.Label label_Distance;
        private System.Windows.Forms.Label label_Dicom;
        private System.IO.Ports.SerialPort DistancePort;
        private System.Windows.Forms.PictureBox pBx_ResetPoint;
        private System.Windows.Forms.Panel panel_HealthyNotice;
        private System.Windows.Forms.PictureBox pBx_ExitTimer;
        private System.Windows.Forms.PictureBox pBx_ContinuTimer;
    }
}

