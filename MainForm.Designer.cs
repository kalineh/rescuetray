namespace rescuetray
{
    partial class MainForm
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
            this.RefreshButton = new System.Windows.Forms.Button();
            this.RescueDataListView = new System.Windows.Forms.ListView();
            this.MainSplit = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.MainSplit)).BeginInit();
            this.MainSplit.Panel1.SuspendLayout();
            this.MainSplit.Panel2.SuspendLayout();
            this.MainSplit.SuspendLayout();
            this.SuspendLayout();
            // 
            // RefreshButton
            // 
            this.RefreshButton.Location = new System.Drawing.Point(21, 11);
            this.RefreshButton.Name = "RefreshButton";
            this.RefreshButton.Size = new System.Drawing.Size(85, 25);
            this.RefreshButton.TabIndex = 0;
            this.RefreshButton.Text = "&Refresh";
            this.RefreshButton.UseVisualStyleBackColor = true;
            this.RefreshButton.Click += new System.EventHandler(this.OnRefreshButton);
            // 
            // RescueDataListView
            // 
            this.RescueDataListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RescueDataListView.FullRowSelect = true;
            this.RescueDataListView.GridLines = true;
            this.RescueDataListView.Location = new System.Drawing.Point(0, 0);
            this.RescueDataListView.Name = "RescueDataListView";
            this.RescueDataListView.Size = new System.Drawing.Size(501, 407);
            this.RescueDataListView.Sorting = System.Windows.Forms.SortOrder.Descending;
            this.RescueDataListView.TabIndex = 1;
            this.RescueDataListView.UseCompatibleStateImageBehavior = false;
            this.RescueDataListView.View = System.Windows.Forms.View.Details;
            this.RescueDataListView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.RescueDataListColumnClick);
            // 
            // MainSplit
            // 
            this.MainSplit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainSplit.Location = new System.Drawing.Point(0, 0);
            this.MainSplit.Name = "MainSplit";
            this.MainSplit.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // MainSplit.Panel1
            // 
            this.MainSplit.Panel1.Controls.Add(this.RescueDataListView);
            // 
            // MainSplit.Panel2
            // 
            this.MainSplit.Panel2.Controls.Add(this.RefreshButton);
            this.MainSplit.Size = new System.Drawing.Size(501, 459);
            this.MainSplit.SplitterDistance = 407;
            this.MainSplit.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(501, 459);
            this.Controls.Add(this.MainSplit);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.MainSplit.Panel1.ResumeLayout(false);
            this.MainSplit.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MainSplit)).EndInit();
            this.MainSplit.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button RefreshButton;
        private System.Windows.Forms.ListView RescueDataListView;
        private System.Windows.Forms.SplitContainer MainSplit;
    }
}

