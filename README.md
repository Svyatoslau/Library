# Launch Instruction

1. Before starting. Git and Docker need to be installed in your machine.
  - Installing Git: https://git-scm.com/book/en/v2/Getting-Started-Installing-Git
  - Installing Docker: https://docs.docker.com/get-docker/
2. Open Terminal
3. Clone current git repository.
```
git clone https://github.com/Svyatoslau/Library.git
```
![image](https://user-images.githubusercontent.com/70974206/227704859-99066a83-9123-4385-8ad9-72ad603a2036.png)

4. Go to Library directory. That you instaled with git clone.
```
cd Library
```
![image](https://user-images.githubusercontent.com/70974206/227704918-b0dbe55c-3183-4c83-a013-2986bcca1cd4.png)

5. Run appliccation with docker-compose.
```
docker-compose up
```
![image](https://user-images.githubusercontent.com/70974206/227705099-705910f7-8387-4f17-88e1-a1456daf501b.png)
  - You can check containers in other terminal
```
docker ps -a
```
![image](https://user-images.githubusercontent.com/70974206/227705216-ff4586c9-3211-43f8-8455-e7ca9b8aae3c.png)

6. Open swagger web page in your browser.
  - http://localhost:5200/swagger/index.html
  - Example of page: ![image](https://user-images.githubusercontent.com/70974206/227704643-8a707812-53dc-4b00-9d4f-0748c9db3ee4.png)


# User Guide

1. Login to exist user or registr new.
  - Login. Swagger documentation: ![image](https://user-images.githubusercontent.com/70974206/227705494-8ae01ac9-0f01-4d7d-8021-806ed7dfc194.png)

  - Application have exists user:
```json
{
  "nickname": "user",
  "password": "1234"
}
```
  - You can registr new user: ![image](https://user-images.githubusercontent.com/70974206/227705640-d0f15e23-fd35-4c6f-8ee9-557cd952f107.png)

2. After login you need to be authenticated with JwtToken. For using book api
  - Example of generated token after successfull login:  http://localhost:5200/api/user/login : 
```
{
  "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoidXNlciIsImV4cCI6MTY3OTczNDQyMiwiaXNzIjoiTGV0dGVyU2VydmljZSIsImF1ZCI6InVzZXIifQ.kSdDswG6YKduGanIVdyfiA8HoTUfNkMen2kbkh7RB1Q"
}
```
  - Pass token to Authorize: ![image](https://user-images.githubusercontent.com/70974206/227705839-13b17b06-cdb2-4cf2-8b80-c42a10bb227b.png)

3. Book api
  - Example: ![image](https://user-images.githubusercontent.com/70974206/227706114-3d9943a5-aa4d-479f-908f-d803be35c5f8.png)
  - Realized all base request.
  - And realized specific request GetBookByIsbn. You can get book by ISBN. ![image](https://user-images.githubusercontent.com/70974206/227706183-0a6f4fd8-25a7-4fc3-a1df-a3ed57cce922.png)

