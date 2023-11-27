#!/bin/bash
echo "running set up script"
/opt/mssql-tools/bin/sqlcmd -S digimon_db,1433 -U sa -P Jnavarrete2024* -d master -i digimon-db-init.sql