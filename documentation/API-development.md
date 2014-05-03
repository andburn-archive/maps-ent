API - Development
===================

Defining the interface between the two applications (Service provider, service user) required negotiation and consideration of the differing needs of each.

An API was designed to accept cross-origin GET requests in a number of formats which were defined in consultation with the primary service client. The needs of the client application at present can be broken into to categories, query-less and query-full requests, the later having many permutations of actual usage.

Request string format
------------------------

The request sting must always be directed to HOST/api to be accepted for cross origin requests. The two route formats defined for use in this project follow a common structure. One designed to recieve a general request with no query parameters, and one which accepts multiple variables used for querying entities and geo-data:

	http://HOST/api/events

	http://HOST/api/{altitude-zoom}/{latitude}/{longitude}?categories=1|2

By structuring the data in this way we present a stable, reliable interface to machine users accepting the data nessecary to make informed descisions and return the desired responses.

Accepted query parameters are:


### Categories

	categories=battles|cheese|etc 
A greedy search, results in any or all of the provided categories if provided

### Keywords 
	keywords=hello\|world 
A greedy search, results in any or all of the provided keyworks in event descriptions if provided
### startdate
	startdate=01-01-2001
The end date for a query based on time range
### Enddate 
	enddate=01-08-2011 
The end date for a query based on time range

A full request might look like this:

	http://HOST/api/9/-6/55?categories=battles|cheese|etc&keywords=hello\|world&startdate=01-01-2001&enddate=01-08-2011


Response format and structure 
---------------------------

The response format needed to be interpreted by a JavaScript application, as such the returning of data structured as a JSON object of results suited the client needs over xml which would require additional parsing.

Creating a JSON response, in a predefined format in the .Net MVC framework requires careful planning and data entity abstraction, because true entity names or database structure should not be exposed to the client. To this end an API ViewModel was created to act as the "view" or response abstraction

The format below shows an example of this geo JSON.

```JavaScript 
{ "type": "FeatureCollection",
    "features": [
      { "type": "Feature",
        "geometry": {"type": "Point", "coordinates": [102.0, 0.5]},
        "properties": {"prop0": "value0"}
        },
      { "type": "Feature",
        "geometry": {
          "type": "LineString",
          "coordinates": [
            [102.0, 0.0], [103.0, 1.0], [104.0, 0.0], [105.0, 1.0]
            ]
          },
        "properties": {
          "prop0": "value0",
          "prop1": 0.0
          }
        },
      { "type": "Feature",
         "geometry": {
           "type": "Polygon",
           "coordinates": [
             [ [100.0, 0.0], [101.0, 0.0], [101.0, 1.0],
               [100.0, 1.0], [100.0, 0.0] ]
             ]
         },
         "properties": {
           "prop0": "value0",
           "prop1": {"this": "that"}
           }
         }
       ]
     }
```

GeoJson format uses Longitude/Latitude ordering rather than the Latitude/Lonitude ordering ISO 6709 standard employed by most other systems including Google Maps. Despite this, it was decided to put systems implementation secondary to aherance to the GeoJson format in order to increase accessability of the API for other systems.

To compensate, the MapsAgo API includes a `location` propery with `latitude` and `longitude` properties 


```javascript
{
    "type": "FeatureCollection",
    "features": [
      {
          "type": "Feature",
          "geometry": {
              "type": "Point",
              "coordinates": [53.365, -6.21]
          },
          "properties": {
              "name": "Battle of Clontarf",
              "excerpt": "The Battle of Clontarf took place on 23 April 1014 between the forces of Brian Boru and the...",
              "startDate": "1014-04-23",
              "endDate": "1014-04-23",
              "category": "Battle",
              "resources": [
                {
                    "type": "image",
                    "name": "Www",
                    "url": "http://upload.wikimedia.org/wikipedia/commons/e/e9/Www.wesleyjohnston.com-users-ireland-maps-historical-map1014.gif"
                }, {
                    "type": "link",
                    "name": "Wikipedia Link",
                    "url": "http://en.wikipedia.org/wiki/index.html?curid=155550"
                }],
              "location": {
                  "alias": null,
                  "name": "Clontarf, Dublin",
                  "latitude": 53.365,
                  "longitude": -6.21
              },
              "description": "The Battle of Clontarf took place on 23 April 1014 between the forces of Brian Boru and the forces led by the King of Leinster, Máel Mórda mac Murchada: composed mainly of his own men, Viking mercenaries from Dublin and the Orkney Islands led by his cousin Sigtrygg."
          }
      },
    {
        "type": "Feature"
    }]
}
```

In this way each response has two properties, `type` with value `FeaturesCollection` and `features` as an array of points.

Each Point has three properties: "type", "geometry" (which stores coordinates) and "properties" (which contains all other metadata. Although this format is more complex than is strictly necesary to communicate effectively, it is hoped that the conformity to standards will increase the value and usefulness of the service to third-parties.