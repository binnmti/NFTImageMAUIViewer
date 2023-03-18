using Nethereum.Hex.HexTypes;

namespace BlazorApp1.Shared;

public record AddressItem(decimal EtherBalance, decimal EtherValue, List<TransactionItem> TransactionItems);

public record TransactionItem(string Hash, HexBigInteger Block, string From, string To, HexBigInteger Value, HexBigInteger Gas);