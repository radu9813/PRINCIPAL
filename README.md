# Hello World
You can check how the application works if you go to http://app-helloworld-sechei.herokuapp.com/
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

