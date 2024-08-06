#!/bin/bash

cd ./artifacts/Release/bin/GitExtensions/net8.0-windows &&
find . \
     -type f \
     ! -name 'GitExtensions.dll.config' \
     ! -name 'WindowPositions.xml' \
     \( \
         -name '*.xml' -or \
         -name '*.dll.config' -or \
         -name '*.pdb' \
     \) \
     -exec rm -f {} +
