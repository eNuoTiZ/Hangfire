FROM microsoft/dotnet:2.0-sdk AS base

ARG PROXY="http://proxy.ubisoft.org:3128"

# Setup Ubisoft proxy
ENV http_proxy=${PROXY} https_proxy=${PROXY}

WORKDIR ./src

COPY *.csproj ./

RUN dotnet restore -nowarn:msb3202,nu1503

COPY . ./

RUN dotnet build -c Release -o /app

EXPOSE 80/tcp
ENV ASPNETCORE_URLS="http://*:80"

#FROM build AS publish
RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=base /app .
ENTRYPOINT ["dotnet", "TutoHangfire.dll"]