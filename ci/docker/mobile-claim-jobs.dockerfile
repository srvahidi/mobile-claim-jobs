FROM feeds.axadmin.net/docker/dotnet/core/aspnet:2.1

ENV ASPNETCORE_URLS=http://+:8080
WORKDIR /app
COPY mobile-claim-jobs-binaries/app/ ./

ENTRYPOINT ["dotnet", "MobileClaimJobs.dll"]
