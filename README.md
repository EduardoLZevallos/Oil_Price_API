# Oil_Price_API
Crude Oil and Conventional Gasoline Price
Source of data : https://www.eia.gov/dnav/pet/pet_pri_spt_s1_a.htm 

**API EndPoints: **
https://localhost:7063/api/CrudeOil/{id}
https://localhost:7063/api/CrudeOil
https://localhost:7063/api/OilPrice/{id}
https://localhost:7063/api/OilPrice/

**Sample Request: **
Lets say we want to add a record to the db for crude oil prices in the year 3000
{
    "Date" : 3000,
    "WTI" : 5.30,
    "BRENT" : 1000
}

**Sample Response:**
Response 1st ID in the crude oil db for https://localhost:7063/api/CrudeOil/1 
{
    "statusCode": 200,
    "statusDescription": "You found the ID",
    "conventionalGasolines": null,
    "crudeOils": [
        {
            "crudeOilID": 1,
            "date": 1986,
            "wti": 15.05,
            "brent": 0
        }
    ]
}

This API has 3 http methods PUT, DELETE, GET 
