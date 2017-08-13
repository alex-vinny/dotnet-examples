docker run -it \
-p 5001:5001 \
-v /etc/group:/etc/group:ro \
-v /etc/passwd:/etc/passwd:ro \
-v $(pwd):/app:rw \
-u $( id -u $USER ):$( id -g $USER ) \
--name netcore \
--rm zamboli/dotnet
