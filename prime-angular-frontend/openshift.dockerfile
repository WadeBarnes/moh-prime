### Stage 1: Create build environment ###
FROM node:10.16
WORKDIR /app

# Copy package definition, install them, then copy everything into working directory and build it
COPY package.json package-lock.json ./
RUN echo "Populating environment..."
RUN (eval "echo \"$(cat /app/src/environments/environment.prod.template.ts )\"" ) > /app/src/environments/environment.prod.ts
RUN npm install
COPY . .
RUN npm run build


### Stage 2: Run Angular & Nginx ###
FROM nginx:stable

# Set environment variables
ENV REDIRECT_URL $REDIRECT_URL
ENV VANITY_URL $VANITY_URL
ENV OC_APP $OC_APP
ENV KEYCLOAK_URL $KEYCLOAK_URL
ENV KEYCLOAK_REALM $KEYCLOAK_REALM
ENV KEYCLOAK_CLIENT_ID $KEYCLOAK_CLIENT_ID
ENV JWT_WELL_KNOWN_CONFIG $JWT_WELL_KNOWN_CONFIG
ENV DOCUMENT_MANAGER_URL $DOCUMENT_MANAGER_URL

RUN apt-get update
RUN touch /etc/nginx/conf.d/default.conf
RUN chmod -R 777 /etc/nginx

COPY nginx.conf /etc/nginx/nginx.conf
COPY nginx.template.conf /etc/nginx/nginx.template.conf
COPY entrypoint.sh /

RUN rm -fr /usr/share/nginx/html
RUN chmod -R 777 /app/src

RUN chmod +x /entrypoint.sh
RUN chmod 777 /entrypoint.sh
RUN echo "Build completed."

COPY ./entrypoint.sh /
RUN chmod +x /entrypoint.sh

EXPOSE 80 8080 4200:8080

CMD /entrypoint.sh
