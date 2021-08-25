# Hello World

## How to deploy to Heroku
Login to heroku
```
heroku login
heroku container:login
```



Push container
```
heroku container:push -a app-helloworld-sechei web
```



Release the container
```
heroku container:release -a app-helloworld-sechei web
```

