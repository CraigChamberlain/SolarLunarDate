#!/bin/bash
#export COVERALLS_REPO_TOKEN=xxxxxxxxxxxxxxxxxxxxxxxxxxxxx

find . -path "*/TestResults/*" -type d -exec rm "{}" -r \;

find . -path "*.Tests" -exec dotnet test --collect:"XPlat Code Coverage" "{}" -- DataCollectionRunSettings.DataCollectors.DataCollector.Configuration.Format=opencover  \;


COVERAGEFILES=""
for x in $(find . -path */coverage.opencover.xml); do
    COVERAGEFILES+="opencover=$x;"
done
COVERAGEFILES="$(sed -e 's/;$//' <<< $COVERAGEFILES)"

./tools/csmacnz.Coveralls \
  --multiple \
  -i $COVERAGEFILES \
  --useRelativePaths \
  --commitId $(git log --format="%H" -n 1) \
  --commitBranch $(git rev-parse --abbrev-ref HEAD)