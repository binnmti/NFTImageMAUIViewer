using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EthBlockWebApi.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Block",
                columns: table => new
                {
                    BlockId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BlockHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SealFields = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ParentHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nonce = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sha3Uncles = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LogsBloom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TransactionsRoot = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StateRoot = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReceiptsRoot = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Miner = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Difficulty = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalDifficulty = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MixHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExtraData = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Size = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GasLimit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GasUsed = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Timestamp = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Uncles = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BaseFeePerGas = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Block", x => x.BlockId);
                });

            migrationBuilder.CreateTable(
                name: "Transaction",
                columns: table => new
                {
                    TransactionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransactionHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TransactionIndex = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BlockHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BlockNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    From = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    To = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gas = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GasPrice = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaxFeePerGas = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaxPriorityFeePerGas = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Input = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nonce = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    R = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    S = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    V = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transaction", x => x.TransactionId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Block");

            migrationBuilder.DropTable(
                name: "Transaction");
        }
    }
}
