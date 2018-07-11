# SmogInfo

Actual version, collecting data from Warsaw:
http://cleanair.azurewebsites.net

Project in which im trying collect smog data from API's and present them in simple Angular app.

Next step is set up my own sensor and update database instead of taking data from APIs




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

