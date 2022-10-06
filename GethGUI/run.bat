geth --datadir eth_private_net init Genesis.json
geth --networkid "15" --nodiscover --datadir eth_private_net --mine --unlock 0xa7653f153f9ead98dc3be08abfc5314f596f97c6 --http --http.addr "localhost" --http.port "8545" --http.corsdomain "*" console 2>> eth_private_net\geth_err.log
pause
