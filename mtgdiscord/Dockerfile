FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env
RUN git clone https://github.com/RyanEvans332/mtgdiscord.git && cd mtgdiscord/mtgdiscord
WORKDIR /mtgdiscord/mtgdiscord

# Copy everything
COPY . ./
# Restore as distinct layers
RUN dotnet restore
# Build and publish a release
RUN dotnet publish -c Release

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /mtgdiscord/mtgdiscord
COPY --from=build-env /mtgdiscord/mtgdiscord/bin/Release/net7.0/ .
ENTRYPOINT ["dotnet", "mtgdiscord.dll"]