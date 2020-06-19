# Architecture

## Techs

* Linux
* .NET Core 3.1
* ASP.NET Core MVC
* SQLite
* Kestrel
* HTML
* CSS
* JavaScript
* jQuery


## URL structure

```
/_site
  /live
  /version
/error
/login
/register
/{user}*
/{user}/account**
/{user}/events*
/{user}/my-events**
/{user}/invitations**
/{user}/calendar**
/{user}/contacts*
/{event}*

/api/v1/ *

* = must be logged in
** = must be logged in as {user}
```


## Server-side or client-side rendering?

* Server-side: ASP.NET Views
* Client-side: JavaScript calling APIs


|             | Pros                                                         | Cons                                                         |
| ----------- | ------------------------------------------------------------ | ------------------------------------------------------------ |
| Server-side | Routing easily handled by ASP.NET<br />Get HTML templating for free | I'm not familiar with Razor or ASP.NET Views                 |
| Client-side | More loosely coupled architecture (get the API for free)<br />Practice Web dev fundamentals | How will I do routing?<br />Won't work for users with JS disabled |

**Decision:** client-side

- Simpler architecture
- Lower learning curve
- I get practice with the fundamentals


## Data access

* ADO.NET: write and execute SQL directly, process the output manually into .NET types
* Entity Framework: ORM (define .NET types that get translated into SQL)

Both support SQLite.

**Decision:** ADO.NET

* I get practice with the fundamentals (writing SQL) and seeing how Entity Framework "really works"
* If I ever want to try ADO, now's the time
* Lower learning curve: this is similar to the Python libraries I've tried for SQLite and PostgreSQL

