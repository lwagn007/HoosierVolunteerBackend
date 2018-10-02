# HoosierVolunteer

## Purpose
Hoosier Volunteers is a web application to connect local Indiana organizations with local Hoosier volunteers. As a group of developers we found there was a lack of notification and ability to find opportunities or post opportunities to volunteer.



## HTTP Requests

#### POST / GetToken
https://hoosiervolunteer.azurewebsites.net/token

```cs
grant_type: "password",
username: usersEmail,
password: usersPassword
```

#### POST / CreateEvent
https://hoosiervolunteer.azurewebsites.net/api/Event/Create
```cs
EventRange: {
	Start: "2018-09-20T18:25:43.511Z",
	End: "2018-09-23T18:25:43.511Z"
},
Type: "Distribution",
EventTitle: "Soup Kitchen",
Address: "123 Main St",
VolunteersNeeded: 12,
EventDescription: "Soup kitchen stuff"
```
