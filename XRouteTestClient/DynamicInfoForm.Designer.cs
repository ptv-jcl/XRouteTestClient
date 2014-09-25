namespace XRouteTestClient
{
    partial class DynamicInfoForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DynamicInfoForm));
            this.DynamicInfo = new System.Windows.Forms.GroupBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tbxTimeBenefit = new System.Windows.Forms.TextBox();
            this.tbxDistanceDiff = new System.Windows.Forms.TextBox();
            this.tbxTimeLoss2 = new System.Windows.Forms.TextBox();
            this.tbxTimeLoss = new System.Windows.Forms.TextBox();
            this.labTimeBenefit = new System.Windows.Forms.Label();
            this.labDistanceDiff = new System.Windows.Forms.Label();
            this.labTimeLoss2 = new System.Windows.Forms.Label();
            this.labTimeLoss = new System.Windows.Forms.Label();
            this.DynamicInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // DynamicInfo
            // 
            this.DynamicInfo.Controls.Add(this.labTimeLoss);
            this.DynamicInfo.Controls.Add(this.labTimeLoss2);
            this.DynamicInfo.Controls.Add(this.labDistanceDiff);
            this.DynamicInfo.Controls.Add(this.labTimeBenefit);
            this.DynamicInfo.Controls.Add(this.tbxTimeLoss);
            this.DynamicInfo.Controls.Add(this.tbxTimeLoss2);
            this.DynamicInfo.Controls.Add(this.tbxDistanceDiff);
            this.DynamicInfo.Controls.Add(this.tbxTimeBenefit);
            this.DynamicInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DynamicInfo.Location = new System.Drawing.Point(0, 0);
            this.DynamicInfo.Name = "DynamicInfo";
            this.DynamicInfo.Size = new System.Drawing.Size(339, 79);
            this.DynamicInfo.TabIndex = 0;
            this.DynamicInfo.TabStop = false;
            this.DynamicInfo.Text = "DynamicInfo";
            this.toolTip1.SetToolTip(this.DynamicInfo, resources.GetString("DynamicInfo.ToolTip"));
            this.DynamicInfo.Enter += new System.EventHandler(this.DynamicInfo_Enter);
            // 
            // tbxTimeBenefit
            // 
            this.tbxTimeBenefit.Location = new System.Drawing.Point(75, 19);
            this.tbxTimeBenefit.Name = "tbxTimeBenefit";
            this.tbxTimeBenefit.Size = new System.Drawing.Size(86, 20);
            this.tbxTimeBenefit.TabIndex = 0;
            this.tbxTimeBenefit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbxDistanceDiff
            // 
            this.tbxDistanceDiff.Location = new System.Drawing.Point(241, 45);
            this.tbxDistanceDiff.Name = "tbxDistanceDiff";
            this.tbxDistanceDiff.Size = new System.Drawing.Size(86, 20);
            this.tbxDistanceDiff.TabIndex = 1;
            this.tbxDistanceDiff.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbxTimeLoss2
            // 
            this.tbxTimeLoss2.Location = new System.Drawing.Point(241, 19);
            this.tbxTimeLoss2.Name = "tbxTimeLoss2";
            this.tbxTimeLoss2.Size = new System.Drawing.Size(86, 20);
            this.tbxTimeLoss2.TabIndex = 2;
            this.tbxTimeLoss2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbxTimeLoss
            // 
            this.tbxTimeLoss.Location = new System.Drawing.Point(75, 45);
            this.tbxTimeLoss.Name = "tbxTimeLoss";
            this.tbxTimeLoss.Size = new System.Drawing.Size(86, 20);
            this.tbxTimeLoss.TabIndex = 3;
            this.tbxTimeLoss.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labTimeBenefit
            // 
            this.labTimeBenefit.AutoSize = true;
            this.labTimeBenefit.Location = new System.Drawing.Point(6, 22);
            this.labTimeBenefit.Name = "labTimeBenefit";
            this.labTimeBenefit.Size = new System.Drawing.Size(63, 13);
            this.labTimeBenefit.TabIndex = 4;
            this.labTimeBenefit.Text = "TimeBenefit";
            this.toolTip1.SetToolTip(this.labTimeBenefit, resources.GetString("labTimeBenefit.ToolTip"));
            // 
            // labDistanceDiff
            // 
            this.labDistanceDiff.AutoSize = true;
            this.labDistanceDiff.Location = new System.Drawing.Point(167, 48);
            this.labDistanceDiff.Name = "labDistanceDiff";
            this.labDistanceDiff.Size = new System.Drawing.Size(65, 13);
            this.labDistanceDiff.TabIndex = 5;
            this.labDistanceDiff.Text = "DistanceDiff";
            this.toolTip1.SetToolTip(this.labDistanceDiff, "The distance difference between the dynamic \r\nand the static route in meters.\r\n\r\n" +
                    "NOTE: This is an optional attribute and is set only \r\nif the REQUEST_VERSION is " +
                    "set to 1.4.5 or higher");
            // 
            // labTimeLoss2
            // 
            this.labTimeLoss2.AutoSize = true;
            this.labTimeLoss2.Location = new System.Drawing.Point(167, 22);
            this.labTimeLoss2.Name = "labTimeLoss2";
            this.labTimeLoss2.Size = new System.Drawing.Size(58, 13);
            this.labTimeLoss2.TabIndex = 6;
            this.labTimeLoss2.Text = "TimeLoss2";
            this.toolTip1.SetToolTip(this.labTimeLoss2, resources.GetString("labTimeLoss2.ToolTip"));
            // 
            // labTimeLoss
            // 
            this.labTimeLoss.AutoSize = true;
            this.labTimeLoss.Location = new System.Drawing.Point(6, 48);
            this.labTimeLoss.Name = "labTimeLoss";
            this.labTimeLoss.Size = new System.Drawing.Size(52, 13);
            this.labTimeLoss.TabIndex = 7;
            this.labTimeLoss.Text = "TimeLoss";
            this.toolTip1.SetToolTip(this.labTimeLoss, "The time loss you will have when taking the dynamic \r\nroute in contrast to the st" +
                    "atic route. \r\ntimeLoss = Td(Rd) - Ts(Rs)");
            // 
            // DynamicInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(339, 79);
            this.Controls.Add(this.DynamicInfo);
            this.Name = "DynamicInfoForm";
            this.Text = "DynamicInfoForm";
            this.Load += new System.EventHandler(this.DynamicInfoForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DynamicInfoForm_FormClosing);
            this.DynamicInfo.ResumeLayout(false);
            this.DynamicInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox DynamicInfo;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label labTimeLoss;
        private System.Windows.Forms.Label labTimeLoss2;
        private System.Windows.Forms.Label labDistanceDiff;
        private System.Windows.Forms.Label labTimeBenefit;
        private System.Windows.Forms.TextBox tbxTimeLoss;
        private System.Windows.Forms.TextBox tbxTimeLoss2;
        private System.Windows.Forms.TextBox tbxDistanceDiff;
        private System.Windows.Forms.TextBox tbxTimeBenefit;
    }
}