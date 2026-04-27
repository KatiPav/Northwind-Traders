# Northwind Traders

This is my submission for the technical task for Fourth.

## Assumptions made:
  You have a copy of the Northwind db on your SQL server.
  
  This project will be reviewed in development environment.
  
  In one place I was unsure if the task wants all unique products of an order returned or the total number of products in the order. I've made it with the assumption for unique products.

## What could be improved:
  - adding caching
  - more direct setup
  - more error catching especially on the front end
  - better structure in the front end

## How to run:
 I made 2 parts - front and back end. Open each project in your IDE (I used VSCode).
 ### How to run front-end : I used Vite to create React app. Running from the root folder
 - `npm install`
 - `npm run dev`
   should be enough to get it working. The default port is http://localhost:5173, but if this one doesn't work for you and another one is used you will have to set up the other port in the back-end in the appsettings.json file. 
   `  "Cors": {
    "AllowedOrigins": [
      "http://localhost:<your-port-here>"
    ]
  }`

! If there are any issues with the front end you can also skip it and use Swagger instead at http://localhost:<your-port>/swagger/index.html
I added the front end to make it feel more like a complete project but it has no important functionality.

### How to run back-end: 
Run
- `dotnet run`
  The default port it runs on is localhost:5041, and if that is not the case for you you will have to update the front-end in the .env file like so.
  `VITE_API_BASE_URL=http://localhost:<your-port-here>/api`
  You will also need to update the "DefaultConnection" string in the appsetting.json file with your local database that contains the Northwind db.
  `  "AllowedHosts": "*",
  "ConnectionStrings": {
    "DefaultConnection": "Server=<your-db-name-here>;Trusted_Connection=True;TrustServerCertificate=True"
  },`

### In the back-end folder there is another project - Fourth.Tests if you want to take a look.

  
