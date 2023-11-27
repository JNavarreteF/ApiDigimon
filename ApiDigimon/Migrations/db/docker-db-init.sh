#!/bin/bash
sleep $'30s' & /opt/mssql-tools/bin/sqlcmd -S localhost,1433 -U sa -P Jnavarrete2024* -d master -i digimon-db-init.sql