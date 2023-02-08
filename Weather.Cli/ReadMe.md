**\*\*\*\***\*\***\*\*\*\*** WELCOME TO WEATHER Command Line Interface APP \***\*\*\*\*\***\*\***\*\*\*\*\***

Introduction::

1. Weather.Cli is an app, which provide you all live infomation realted to weather for that particular city.

2. This APP require, City Name needs to be input from user end and then user will get displayed all weather realted infomation for that particular city.

Project/Application Introduction::

1. Application Name: Weather.Cli
2. Inside bin -> Debug folder, we have one csv file, which is having all indian cities weather information- city, latitude, longitude, country, iso2, admin_name, capital, population, population_proper.
3. Program.cs file containing complete business logic.

Flow of Application::

1. In this applicatiom we are using 2 APIs.
2. First API, giving us latitude and longitude information based on City Name provided by user- https://simplemaps.com/data/in-cities.
   For simplicity, we downloaded/extracted this data into csv and added in our project as a static csv file.
3. Second API, giving us whole weather infomation based on latitude and longitude retrieved, from the first API- https://api.open-meteo.com/v1/forecast?latitude=lat&longitude=lon&current_weather=true

Execution Of Application::

1. You have to open Weather.Cli folder
2. Go to bin folder
3. Go to Degug folder
4. Run Weather.Cli.exe

Weather.Cli -> bin -> Debug -> Weather.Cli.exe

Alternatively-
Open Weather.Cli.sln file, and run the application.

Open application running, it is asking user to input City and press enter.

If City exists, then data will be returned successfully.
Other wise, it will show Input City does not exist
