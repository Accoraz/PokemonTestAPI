namespace PokemonTestAPI
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnSearch = new Button();
            txtSpecies = new TextBox();
            lstResults = new ListBox();
            lblError = new Label();
            SuspendLayout();
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(343, 26);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(75, 23);
            btnSearch.TabIndex = 0;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // txtSpecies
            // 
            txtSpecies.Location = new Point(306, 71);
            txtSpecies.Name = "txtSpecies";
            txtSpecies.Size = new Size(145, 23);
            txtSpecies.TabIndex = 1;
            txtSpecies.TextChanged += txtSpecies_TextChanged;
            // 
            // lstResults
            // 
            lstResults.FormattingEnabled = true;
            lstResults.ItemHeight = 15;
            lstResults.Location = new Point(143, 124);
            lstResults.Name = "lstResults";
            lstResults.Size = new Size(506, 304);
            lstResults.TabIndex = 3;
            lstResults.SelectedIndexChanged += lstResults_SelectedIndexChanged;
            // 
            // lblError
            // 
            lblError.AutoSize = true;
            lblError.Location = new Point(139, 30);
            lblError.Name = "lblError";
            lblError.Size = new Size(32, 15);
            lblError.TabIndex = 4;
            lblError.Text = "Error";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblError);
            Controls.Add(lstResults);
            Controls.Add(txtSpecies);
            Controls.Add(btnSearch);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnSearch;
        private TextBox txtSpecies;
        private ListBox lstResults;
        private Label lblError;
    }
}
