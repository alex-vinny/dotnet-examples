FROM                microsoft/dotnet
MAINTAINER          alexzamboli <alex.zamboli@gmail.com>
LABEL               name "netcore"

RUN                 mkdir /app
WORKDIR             /app

# install npm, bower and yo
RUN                 curl -sL https://deb.nodesource.com/setup_8.x -o nodesource_setup.sh
RUN                 chmod +x nodesource_setup.sh
RUN                 ./nodesource_setup.sh
RUN                 apt-get install nodejs
RUN                 bash -c "npm install -g bower --alow-root"
RUN                 bash -c "npm install -g yo --alow-root"
RUN                 bash -c "npm install -g generator-aspnet --alow-root"
RUN                 bash -c "sed -i -e '/rootCheck/d' \"/usr/lib/node_modules/yo/lib/cli.js\""

ENV                 ASPNETCORE_URLS http://*:5001
EXPOSE              5001

ENTRYPOINT          ["/bin/bash"]
