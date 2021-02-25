#! /bin/bash

find ./src/HashCode \( -name "*.cs" -or -name "*.csproj" \) -not -path './**/obj/*' | zip -@ solution.zip