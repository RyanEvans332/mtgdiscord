# mtgdiscord
## Dev env
Development/testing in Windows and deploys to a Linux container. Install:
- WSL 2
- Docker Desktop
- Visual Studio 2022
- Powershell
- Azure Powershell cmdlets

Create a system environment variable named "mtgdiscordbot" with the bot token as value.

## Testing
Bot is setup to run as a single instance. Not sure what would happen if a local test instance was running alongside the prod Azure instance so just turn off the Azure instance during tests.
No special requirements to run/debug locally, run/debug works in VS22. 

## Publishing
Execute publish.ps1. It will build the Dockerfile which in turn gets the latest commit from master, builds it, then creates the image which has a dotnet entrypoint to the program. 
The image is pushed to Docker hub then Azure is instructed to update the prod container with the image.
'latest' Docker semantics are not set up and will not work. Tags are defined as the commit the image is based off of, and that's it. ryanevans332/mtgdiscord:latest does not exist. 
