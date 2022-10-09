using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GethGUI
{
    internal static class GenesisUtility
    {

        public class GenesisJson
        {
            public Config config { get; set; }
            public string nonce { get; set; }
            public string timestamp { get; set; }
            public string parentHash { get; set; }
            public string extraData { get; set; }
            public string gasLimit { get; set; }
            public string difficulty { get; set; }
            public string mixhash { get; set; }
            public string coinbase { get; set; }
            public Alloc alloc { get; set; }
        }

        public class Config
        {
            public int chainId { get; set; }
            public int homesteadBlock { get; set; }
            public int eip150Block { get; set; }
            public int eip155Block { get; set; }
            public int eip158Block { get; set; }
            public int byzantiumBlock { get; set; }
            public int constantinopleBlock { get; set; }
            public int petersburgBlock { get; set; }
            public int istanbulBlock { get; set; }
            public int berlinBlock { get; set; }
        }

        public class Alloc
        {
        }


        internal static int GetChainId(string jsonFileName)
        {
            var json = File.ReadAllText(jsonFileName);
            var genesis = JsonSerializer.Deserialize<GenesisJson>(json);
            return genesis.config.chainId;
        }
    }
}
