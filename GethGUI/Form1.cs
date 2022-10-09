using GethGUI.Model;
using Nethereum.Geth;
using System.Reflection;

namespace GethGUI
{
    public partial class Form1 : Form
    {
        private Web3Geth Web3Geth { get; } = new();
        private string ExeDirectoryName { get; } = "";
        private int ChainId { get; set; }

        public Form1()
        {
            InitializeComponent();

            ExeDirectoryName = Path.GetDirectoryName(Assembly.GetEntryAssembly()?.Location) ?? "";
        }

        private void CommandInputRunButton_Click(object sender, EventArgs e)
        {
        }

        private async void EthAccountsButton_Click(object sender, EventArgs e)
        {
            var request = await Web3Geth.Eth.Accounts.SendRequestAsync();
            CommandOutputTextBox.Text += string.Concat(request);
        }

        private async void PersonalNewAccountButton_Click(object sender, EventArgs e)
        {
            CommandOutputTextBox.Text += await Web3Geth.Personal.NewAccount.SendRequestAsync(PasswordTextBox.Text);
        }

        private Genesis Genesis = new();


        private void GenesisButton_Click(object sender, EventArgs e)
        {
            GethGroupBox.Enabled = false;
            var form = new GenesisForm(Genesis);
            if (form.ShowDialog() != DialogResult.OK) return;

            GenesisFileNameTextBox.Text = Path.GetFileName(Genesis.FileName);
            ChainId = GenesisUtility.GetChainId(Genesis.FileName);
            GethGroupBox.Enabled = true;
        }

        private void GenesisFileNameTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void InitButton_Click(object sender, EventArgs e)
        {
            CommandOutputTextBox.Text = GethExe.Run(ExeDirectoryName, $"--datadir {ExeDirectoryName} init {GenesisFileNameTextBox.Text}");
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            CommandOutputTextBox.Text = GethExe.Run(ExeDirectoryName, $"--networkid {ChainId} --nodiscover --datadir {ExeDirectoryName} console");
        }
    }
}