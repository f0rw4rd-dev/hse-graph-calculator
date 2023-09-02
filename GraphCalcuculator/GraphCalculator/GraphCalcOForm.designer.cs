namespace GraphCalcuculator
{
    partial class GraphCalcOForm
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
            this.TBox_Output = new System.Windows.Forms.TextBox();
            this.But_Save_Changes = new System.Windows.Forms.Button();
            this.Tab_Output = new System.Windows.Forms.TableLayoutPanel();
            this.Tab_Output.SuspendLayout();
            this.SuspendLayout();
            // 
            // TBox_Output
            // 
            this.TBox_Output.AcceptsReturn = true;
            this.TBox_Output.AcceptsTab = true;
            this.TBox_Output.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TBox_Output.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TBox_Output.Location = new System.Drawing.Point(3, 3);
            this.TBox_Output.MaxLength = 100000000;
            this.TBox_Output.Multiline = true;
            this.TBox_Output.Name = "TBox_Output";
            this.TBox_Output.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TBox_Output.Size = new System.Drawing.Size(698, 406);
            this.TBox_Output.TabIndex = 0;
            // 
            // But_Save_Changes
            // 
            this.But_Save_Changes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.But_Save_Changes.Location = new System.Drawing.Point(3, 415);
            this.But_Save_Changes.Name = "But_Save_Changes";
            this.But_Save_Changes.Size = new System.Drawing.Size(698, 23);
            this.But_Save_Changes.TabIndex = 1;
            this.But_Save_Changes.Text = "Сохранить изменения";
            this.But_Save_Changes.UseVisualStyleBackColor = true;
            this.But_Save_Changes.Click += new System.EventHandler(this.But_Save_Changes_Click);
            // 
            // Tab_Output
            // 
            this.Tab_Output.ColumnCount = 1;
            this.Tab_Output.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.Tab_Output.Controls.Add(this.TBox_Output, 0, 0);
            this.Tab_Output.Controls.Add(this.But_Save_Changes, 0, 1);
            this.Tab_Output.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Tab_Output.Location = new System.Drawing.Point(0, 0);
            this.Tab_Output.Name = "Tab_Output";
            this.Tab_Output.RowCount = 2;
            this.Tab_Output.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.Tab_Output.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.Tab_Output.Size = new System.Drawing.Size(704, 441);
            this.Tab_Output.TabIndex = 2;
            // 
            // GraphCalcOForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 441);
            this.Controls.Add(this.Tab_Output);
            this.Name = "GraphCalcOForm";
            this.Text = "Вывод данных";
            this.Tab_Output.ResumeLayout(false);
            this.Tab_Output.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox TBox_Output;
        private System.Windows.Forms.Button But_Save_Changes;
        private System.Windows.Forms.TableLayoutPanel Tab_Output;
    }
}