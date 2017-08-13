FROM                microsoft/dotnet
MAINTAINER          alexzamboli <alex.zamboli@gmail.com>
LABEL               name "netcore"

ENV                 ASPNETCORE_URLS http://*:5001
EXPOSE              5001

RUN                 mkdir /app
WORKDIR             /app

ENTRYPOINT          ["/bin/bash"]
