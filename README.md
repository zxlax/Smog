# SmogInfo
App using ASP.NET Core 2.1 to collect and provide data about PM10 concentration in Warsaw

return all cities, their stations and PM10 level

api/cities

return city by their id

api/cities/{cityid}

return all stations in city by city id

api/cities/{cityid}/smogstation

return station in city by city id and station id

api/cities/{cityid}/smogstation/{stationid}

return PM10 level in station by city id and station id

api/cities/{cityid}/smogstation/{stationid}/level


First deploy with working controllers and data model:
https://hardy-ivy-207617.appspot.com
