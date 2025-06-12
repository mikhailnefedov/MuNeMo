#!/bin/bash

echo "Building MuNeMo"
dotnet publish MuNeMo/MuNeMo.csproj -c Release -o out
#dotnet publish -c Release -o out

multi-gitter run "dotnet /app/out/MuNeMo.dll" --config=config.yaml