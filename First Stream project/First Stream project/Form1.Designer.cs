namespace First_Stream_project
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
            btnAttack = new Button();
            PlayerHP = new Label();
            richTextBox1 = new RichTextBox();
            btnHeal = new Button();
            Run = new Button();
            Enemy1HP = new Label();
            SuspendLayout();
            // 
            // btnAttack
            // 
            btnAttack.Location = new Point(12, 348);
            btnAttack.Name = "btnAttack";
            btnAttack.Size = new Size(135, 52);
            btnAttack.TabIndex = 0;
            btnAttack.Text = "Attack";
            btnAttack.UseVisualStyleBackColor = true;
            btnAttack.Click += btnAttack_Click;
            // 
            // PlayerHP
            // 
            PlayerHP.Location = new Point(12, 322);
            PlayerHP.Name = "PlayerHP";
            PlayerHP.Size = new Size(135, 23);
            PlayerHP.TabIndex = 1;
            PlayerHP.Text = "Player HP: 100";
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(508, 12);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.ReadOnly = true;
            richTextBox1.Size = new Size(280, 426);
            richTextBox1.TabIndex = 2;
            richTextBox1.Text = "";
            richTextBox1.TextChanged += richTextBox1_TextChanged;
            // 
            // btnHeal
            // 
            btnHeal.AccessibleRole = AccessibleRole.None;
            btnHeal.Location = new Point(261, 348);
            btnHeal.Name = "btnHeal";
            btnHeal.Size = new Size(131, 52);
            btnHeal.TabIndex = 3;
            btnHeal.Text = "Heal";
            btnHeal.UseVisualStyleBackColor = true;
            btnHeal.Click += bubtnHeal_Click;
            // 
            // Run
            // 
            Run.AccessibleRole = AccessibleRole.None;
            Run.Location = new Point(143, 416);
            Run.Name = "Run";
            Run.Size = new Size(131, 52);
            Run.TabIndex = 4;
            Run.Text = "run";
            Run.UseVisualStyleBackColor = true;
            // 
            // Enemy1HP
            // 
            Enemy1HP.Location = new Point(99, 175);
            Enemy1HP.Name = "Enemy1HP";
            Enemy1HP.Size = new Size(135, 23);
            Enemy1HP.TabIndex = 5;
            Enemy1HP.Text = "Enemy HP: 100";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(Enemy1HP);
            Controls.Add(Run);
            Controls.Add(btnHeal);
            Controls.Add(richTextBox1);
            Controls.Add(PlayerHP);
            Controls.Add(btnAttack);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private Button btnAttack;
        private Label PlayerHP;
        private RichTextBox richTextBox1;
        private Button btnHeal;
        private Button Run;
        private Label Enemy1HP;
    }
}
