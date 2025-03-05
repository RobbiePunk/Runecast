namespace RuneCast
{
    partial class Form1
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
            this.castingWindowPB = new System.Windows.Forms.PictureBox();
            this.debugPB = new System.Windows.Forms.PictureBox();
            this.countBT = new System.Windows.Forms.Button();
            this.distanceBT = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.loadRuneBT = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.FindBT = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.castingWindowPB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.debugPB)).BeginInit();
            this.SuspendLayout();
            // 
            // castingWindowPB
            // 
            this.castingWindowPB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.castingWindowPB.Cursor = System.Windows.Forms.Cursors.Hand;
            this.castingWindowPB.Location = new System.Drawing.Point(24, 54);
            this.castingWindowPB.Name = "castingWindowPB";
            this.castingWindowPB.Size = new System.Drawing.Size(563, 558);
            this.castingWindowPB.TabIndex = 0;
            this.castingWindowPB.TabStop = false;
            this.castingWindowPB.MouseDown += new System.Windows.Forms.MouseEventHandler(this.StartCasting);
            this.castingWindowPB.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Casting);
            this.castingWindowPB.MouseUp += new System.Windows.Forms.MouseEventHandler(this.StopCasting);
            // 
            // debugPB
            // 
            this.debugPB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.debugPB.Cursor = System.Windows.Forms.Cursors.Hand;
            this.debugPB.Location = new System.Drawing.Point(690, 54);
            this.debugPB.Name = "debugPB";
            this.debugPB.Size = new System.Drawing.Size(563, 558);
            this.debugPB.TabIndex = 1;
            this.debugPB.TabStop = false;
            // 
            // countBT
            // 
            this.countBT.Location = new System.Drawing.Point(593, 12);
            this.countBT.Name = "countBT";
            this.countBT.Size = new System.Drawing.Size(88, 23);
            this.countBT.TabIndex = 2;
            this.countBT.Text = "Save";
            this.countBT.UseVisualStyleBackColor = true;
            this.countBT.Click += new System.EventHandler(this.SaveRune);
            // 
            // distanceBT
            // 
            this.distanceBT.Location = new System.Drawing.Point(593, 63);
            this.distanceBT.Name = "distanceBT";
            this.distanceBT.Size = new System.Drawing.Size(88, 23);
            this.distanceBT.TabIndex = 3;
            this.distanceBT.Text = "Normalize";
            this.distanceBT.UseVisualStyleBackColor = true;
            this.distanceBT.Click += new System.EventHandler(this.distanceBT_Click);
            // 
            // loadRuneBT
            // 
            this.loadRuneBT.Location = new System.Drawing.Point(593, 120);
            this.loadRuneBT.Name = "loadRuneBT";
            this.loadRuneBT.Size = new System.Drawing.Size(88, 23);
            this.loadRuneBT.TabIndex = 4;
            this.loadRuneBT.Text = "Load";
            this.loadRuneBT.UseVisualStyleBackColor = true;
            this.loadRuneBT.Click += new System.EventHandler(this.LoadRune);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // FindBT
            // 
            this.FindBT.Location = new System.Drawing.Point(593, 170);
            this.FindBT.Name = "FindBT";
            this.FindBT.Size = new System.Drawing.Size(88, 23);
            this.FindBT.TabIndex = 5;
            this.FindBT.Text = "Find";
            this.FindBT.UseVisualStyleBackColor = true;
            this.FindBT.Click += new System.EventHandler(this.FindBT_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1337, 649);
            this.Controls.Add(this.FindBT);
            this.Controls.Add(this.loadRuneBT);
            this.Controls.Add(this.distanceBT);
            this.Controls.Add(this.countBT);
            this.Controls.Add(this.debugPB);
            this.Controls.Add(this.castingWindowPB);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.castingWindowPB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.debugPB)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox castingWindowPB;
        private System.Windows.Forms.PictureBox debugPB;
        private System.Windows.Forms.Button countBT;
        private System.Windows.Forms.Button distanceBT;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button loadRuneBT;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button FindBT;
    }
}

