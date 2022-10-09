geth --datadir eth_private_net init Genesis.json
geth --networkid "15" --nodiscover --datadir eth_private_net --miner.gaslimit "20000000" --http --http.addr "localhost" --http.port "8545" --http.corsdomain "*" --http.api "eth, net, web3, personal" console 2>> eth_private_net\geth_err.log
pause
