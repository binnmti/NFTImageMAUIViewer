using GethGUI.Model;

namespace GethGUI
{
    public partial class GenesisForm : Form
    {
        private readonly Genesis _genesis = new();
        private readonly string PrivateGenesisContext = @"{
  ""config"": {
    ""chainId"": 15,
    ""homesteadBlock"": 0,
    ""eip150Block"": 0,
    ""eip155Block"": 0,
    ""eip158Block"": 0,
    ""byzantiumBlock"": 0,
    ""constantinopleBlock"": 0,
    ""petersburgBlock"": 0,
    ""istanbulBlock"": 0,
    ""berlinBlock"": 0
  },
  ""nonce"": ""0x0000000000000042"",
  ""timestamp"": ""0x0"",
  ""parentHash"": ""0x0000000000000000000000000000000000000000000000000000000000000000"",
  ""extraData"": "",
  ""gasLimit"": ""0x8000000"",
  ""difficulty"": ""0x4000"",
  ""mixhash"": ""0x0000000000000000000000000000000000000000000000000000000000000000"",
  ""coinbase"": ""0x3333333333333333333333333333333333333333"",
  ""alloc"": {}
}";


        public GenesisForm(Genesis genesis)
        {
            InitializeComponent();
            _genesis = genesis;
        }

        private void GenesisForm_Shown(object sender, EventArgs e)
        {
            GenesisFileNameTextBox.Text = _genesis.FileName;
            GenesisContextTextBox.Text = _genesis.Context;
        }

        private void PrivateButton_Click(object sender, EventArgs e)
        {
            GenesisContextTextBox.Text = PrivateGenesisContext;
        }

        private void SetEnabledOkButton()
        {
            bool enabled = true;

            var dir = Path.GetDirectoryName(GenesisFileNameTextBox.Text) ?? "";
            var file = Path.GetFileName(GenesisFileNameTextBox.Text) ?? "";

            if (GenesisFileNameTextBox.Text == "") enabled = false;
            if (Path.GetInvalidPathChars().Any(x => dir.Contains(x))) enabled = false;
            if (Path.GetInvalidFileNameChars().Any(x => file.Contains(x))) enabled = false;
            if (GenesisContextTextBox.Text == "") enabled = false;

            OkButton.Enabled = enabled;
        }

        private void GenesisFileNameTextBox_TextChanged(object sender, EventArgs e)
        {
            SetEnabledOkButton();
        }


        private void GenesisContextTextBox_TextChanged(object sender, EventArgs e)
        {
            SetEnabledOkButton();

        }

        private void GenesisForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult != DialogResult.OK) return;

            if (Path.GetExtension(GenesisFileNameTextBox.Text) != ".json")
            {
                MessageBox.Show("Only Json File");
                e.Cancel = true;
                return;
            }
            var dir = Path.GetDirectoryName(GenesisFileNameTextBox.Text) ?? "";
            try
            {
                Directory.CreateDirectory(dir);
                File.WriteAllText(GenesisFileNameTextBox.Text, GenesisContextTextBox.Text);
            }
            catch
            {
                MessageBox.Show("Can't Create File");
                e.Cancel = true;
                return;
            }
            _genesis.FileName = GenesisFileNameTextBox.Text;
            _genesis.Context = GenesisContextTextBox.Text;
            Close();
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
        }

        private void GenesisFileNameButton_Click(object sender, EventArgs e)
        {
            GenesisFileNameOpenFileDialog.ShowDialog();
        }

        private void GenesisFileNameOpenFileDialog_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            GenesisFileNameTextBox.Text = GenesisFileNameOpenFileDialog.FileName;
        }
    }
}
