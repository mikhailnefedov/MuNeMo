# Use the .NET SDK image to allow building the project at runtime.
FROM mcr.microsoft.com/dotnet/sdk:8.0

# multi-gitter requires sudo for installation
RUN apt-get update
RUN apt install sudo
RUN curl -s https://raw.githubusercontent.com/lindell/multi-gitter/master/install.sh | sh

WORKDIR /app

COPY entrypoint.sh /app/entrypoint.sh
RUN chmod +x /app/entrypoint.sh

CMD ["/app/entrypoint.sh"]

# ENTRYPOINT ["tail", "-f", "/dev/null"]


