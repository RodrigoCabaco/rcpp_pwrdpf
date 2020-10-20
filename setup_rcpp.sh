wget -O - https://packages.microsoft.com/keys/microsoft.asc | gpg --dearmor > microsoft.asc.gpg
sudo mv microsoft.asc.gpg /etc/apt/trusted.gpg.d/
wget https://packages.microsoft.com/config/debian/9/prod.list
sudo mv prod.list /etc/apt/sources.list.d/microsoft-prod.list
sudo chown root:root /etc/apt/trusted.gpg.d/microsoft.asc.gpg
sudo chown root:root /etc/apt/sources.list.d/microsoft-prod.list

sudo apt-get update; \
  sudo apt-get install -y apt-transport-https && \
  sudo apt-get update && \
  sudo apt-get install -y dotnet-sdk-3.1


  sudo apt-get update; \
  sudo apt-get install -y apt-transport-https && \
  sudo apt-get update && \
  sudo apt-get install -y aspnetcore-runtime-3.1

sudo apt-get install -y dotnet-runtime-3.1

dotnet run

#rcpp            rcpp.dll  rcpp.pdb                     rcpp.runtimeconfig.json
#rcpp.deps.json  rcpp.exe  rcpp.runtimeconfig.dev.json  TextToAsciiArt.dll
cp bin/Debug/netcoreapp3.1/rcpp rcpp
cp bin/Debug/netcoreapp3.1/rcpp.deps.json rcpp.deps.json

cp bin/Debug/netcoreapp3.1/rcpp.dll rcpp.dll

cp bin/Debug/netcoreapp3.1/rcpp.pdb rcpp.pdb

cp bin/Debug/netcoreapp3.1/rcpp.runtimeconfig.dev.json rcpp.runtimeconfig.dev.json

cp bin/Debug/netcoreapp3.1/TextToAsciiArt.dll TextToAsciiArt.dll

cp bin/Debug/netcoreapp3.1/rcpp.runtimeconfig.json rcpp.runtimeconfig.json


clear
echo "Installation Finished run ./rcpp -h"
