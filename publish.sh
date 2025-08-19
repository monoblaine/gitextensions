#!/bin/bash

dotnet build ./src/native/build.proj -c Release --nologo -bl:./artifacts/log/native.binlog &&
dotnet publish -c Release --nologo -bl:./artifacts/log/build.binlog
