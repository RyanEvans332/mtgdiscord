#Set-ExecutionPolicy -ExecutionPolicy RemoteSigned -Scope CurrentUser

$tag = (git rev-parse --short HEAD)
cd mtgdiscord
docker build -t mtgdiscord -f Dockerfile .
docker tag mtgdiscord docker.io/ryanevans332/mtgdiscord:$tag
docker push docker.io/ryanevans332/mtgdiscord:$tag
cd ..