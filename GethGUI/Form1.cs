using GethGUI.Model;
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

        private Genesis Genesis = new();


        private void GenesisButton_Click(object sender, EventArgs e)
        {
            var form = new GenesisForm(Genesis);
            if (form.ShowDialog() == DialogResult.OK)
            {
                GenesisFileNameTextBox.Text = Path.GetFileName(Genesis.FileName);
            }
        }

        private void GenesisFileNameTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void InitButton_Click(object sender, EventArgs e)
        {
            //geth --datadir /home/ubuntu/eth_private_net init /home/ubuntu/eth_private_net/myGenesis.json

            //$ geth --networkid "15" --nodiscover --datadir "/home/ubuntu/eth_private_net" console 2>> /home/ubuntu/eth_private_net/geth_err.log
        }
    }
}