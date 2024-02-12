#!/bin/bash

dotnet-coverage collect -f cobertura -o "./TestResults/report.cobertura.xml" "dotnet test"
reportgenerator -reports:./TestResults/report.cobertura.xml -targetdir:"TestResults/coverage-report"