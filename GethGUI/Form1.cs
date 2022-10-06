using Nethereum.Geth;

namespace GethGUI
{
    public partial class Form1 : Form
    {
        private Web3Geth Geth { get; } = new();

        public Form1()
        {
            InitializeComponent();
        }

        private void CommandInputRunButton_Click(object sender, EventArgs e)
        {
        }

        private async void EthAccountsButton_Click(object sender, EventArgs e)
        {
            var request = await Geth.Eth.Accounts.SendRequestAsync();
            CommandOutputTextBox.Text += string.Concat(request);
        }

        private async void PersonalNewAccountButton_Click(object sender, EventArgs e)
        {
            CommandOutputTextBox.Text += await Geth.Personal.NewAccount.SendRequestAsync(PasswordTextBox.Text);
        }
    }
}