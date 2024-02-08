FROM node:latest as build

WORKDIR /usr/local/app

COPY ./ /usr/local/app/

# INSTALL ANGULAR
RUN npm install -g @angular/cli

RUN npm cache clean --force
RUN npm install --peer-legacy-deps -f

# RUN npm run build

RUN ng build --configuration=production

# RUN mv dist /usr/local/app/

FROM nginx:latest
RUN chown -R nginx:nginx /usr/share/nginx/html
WORKDIR /usr/share/nginx/html
RUN rm -rf ./*
COPY --from=build /usr/local/app/dist/web_page/ /usr/share/nginx/html
COPY ./nginx/nginx.conf /etc/nginx/conf.d/default.conf

# Expose port 80
EXPOSE 80
ENTRYPOINT ["nginx", "-g", "daemon off;"]
