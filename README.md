# Hello World EF

## How to deploy on Heroku
1. Create heroku account
2. Create application
3. Choose container registry as deployment method
4. Make sure application works locally


Login to heroku
```
heroku login
heroku container:login
```

Push container
```
heroku container:push -a george-ef web
```

Release the container
```
heroku container:release -a george-ef web
```

Heroku application link: https://george-ef.herokuapp.com/