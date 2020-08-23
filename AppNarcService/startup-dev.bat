docker build -t local/app-narc-service .
docker run -it -p 8090:443 --rm --name app-narc-service-1 local/app-narc-service