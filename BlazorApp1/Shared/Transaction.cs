﻿namespace BlazorApp1.Shared;
public class Transaction
{
    public int TransactionId { get; set; }

    public string TransactionHash { get; set; } = "";

    public string TransactionIndex { get; set; } = "";

    public string Type { get; set; }

    public string BlockHash { get; set; } = "";

    public string BlockNumber { get; set; } = "";

    public string From { get; set; } = "";

    public string To { get; set; } = "";

    public string Gas { get; set; } = "";

    public string GasPrice { get; set; } = "";

    public string MaxFeePerGas { get; set; } = "";

    public string MaxPriorityFeePerGas { get; set; } = "";

    public string Value { get; set; } = "";

    public string Input { get; set; } = "";

    public string Nonce { get; set; } = "";

    public string R { get; set; } = "";

    public string S { get; set; } = "";

    public string V { get; set; } = "";

    //public List<AccessList> AccessList { get; set; }
}
