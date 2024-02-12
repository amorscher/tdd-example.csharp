#!/bin/bash

dotnet test
coverlet ./bin/Debug/net7.0/tdd-example.csharp.test.dll --target "dotnet" --targetargs "test tdd-example.csharp.test.csproj --no-build" -f lcov -o ../lcov.info