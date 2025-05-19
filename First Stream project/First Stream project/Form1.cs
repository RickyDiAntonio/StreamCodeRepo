using System.Runtime.CompilerServices;

namespace First_Stream_project
{
    public partial class Form1 : Form
    {
        int playerHP = 100;
        int enemyHP = 100;
        Random rng = new Random();
        public Form1()
        {
            InitializeComponent();
            UpdateUI();


        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void bubtnHeal_Click(object sender, EventArgs e) {

            int healAmount = rng.Next(15, 26);
            playerHP = Math.Min(playerHP + healAmount, 100);
            Log($"You heal for {healAmount} HP!");

            int enemyDamage = rng.Next(5, 16);
            playerHP -= enemyDamage;
            Log($"The goblin hits you for {enemyDamage} damage!");

            UpdateUI();
        }

        private void btnAttack_Click(object sender, EventArgs e)
        {
            int playerDamage = rng.Next(10, 15);//between 10-15 damage
            int enemyDamage = rng.Next(5, 11);//between 5 and 11 damage
            enemyHP -= playerDamage;
            Log($"You attack the goblin for {playerDamage} damage!");

            if (enemyHP > 0)
            {
                playerHP -= enemyDamage;
                Log($"The goblin hits you for {enemyDamage} damage!");

            }

            UpdateUI();

        }
        private void checkBattleStatus()
        {
            if (playerHP<=0)
            {
                playerHP = 0;
                Log("How did the basic goblin beat you??");
                
            }
        }
        private void UpdateUI()
        {
            PlayerHP.Text = $"Player HP: {playerHP}";
            Enemy1HP.Text = $"Enemy HP: {enemyHP}";
        }
        private void Log(string message)
        {
            richTextBox1.AppendText(message +  Environment.NewLine);
        }


        private void DisableButtons()
        {
            btnAttack.Enabled = false;
            //button1.Enabled = false;
        }
    }
}
