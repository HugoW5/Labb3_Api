## Endpoints Dokumentering

| Metod | Endpoint | Beskrivning |
|:-----|:---------|:------------|
| GET | `/api/Person` | Hämta alla personer |
| POST | `/api/Person` | Skapa en ny person |
| GET | `/api/Person/{personId}` | Hämta en person via ID |
| GET | `/api/Person/{personId}/Interests` | Hämta alla intressen kopplade till en person |
| GET | `/api/Person/{personId}/links` | Hämta alla länkar kopplade till en person |
| PUT | `/api/Person/{personId}/interests` | Lägg till ett nytt intresse till en person |
| GET | `/api/Interest` | Hämta alla intressen |
| POST | `/api/Interest` | Skapa ett nytt intresse |
| PUT | `/api/Link` | Lägg till en ny länk för intresse och person|



---

## Testresultat för API Endpoints

### 1. Hämta alla personer
> ### GET /api/Person
**Response:**
```json
[
  {
    "id": 1,
    "firstName": "Anna",
    "lastName": "Andersson",
    "email": "anna@example.com",
    "phoneNumber": "0701234567",
    "interests": [],
    "links": []
  },
  {
    "id": 2,
    "firstName": "Björn",
    "lastName": "Berg",
    "email": "bjorn@example.com",
    "phoneNumber": "0707654321",
    "interests": [],
    "links": []
  }
]
```
### 2. Skapa ny person
> ### POST /api/Person
**Request Body**
```json
{
  "firstName": "Karin",
  "lastName": "Karlsson",
  "email": "karin@example.com",
  "phoneNumber": "0701122334"
}
```
**Response**
```json
{
  "id": 7
  "firstName": "Karin",
  "lastName": "Karlsson",
  "email": "karin@example.com",
  "phoneNumber": "0701122334"
}
```
### 3. Hämta person via Id
> ### GET /api/Person/{id}
**Response**
```json
{
  "id": 2,
  "firstName": "Bob",
  "lastName": "Smith",
  "email": "bob@example.com",
  "phoneNumber": "987-654-3210",
  "interests": [
    {
      "id": 2,
      "title": "Programming",
      "description": "Writing code to solve problems."
    },
    {
      "id": 3,
      "title": "Biking",
      "description": "Biking around the city"
    }
  ],
  "links": [
    {
      "url": "https://bobcodes.io"
    },
    {
      "url": "https://biking.com"
    }
  ]
}
```
### 4. Hämta en persons länkar via Id
> ### GET /api/Person/{id}/links
**Response**
```json
[
  {
    "url": "https://bobcodes.io"
  },
  {
    "url": "https://biking.com"
  }
]
```
### 5. Hämta en persons intressen via Id
> ### GET /api/Person/{id}/interests
**Response**
```json
[
  {
    "id": 2,
    "title": "Programming",
    "description": "Writing code to solve problems."
  },
  {
    "id": 3,
    "title": "Biking",
    "description": "Biking around the city"
  }
]
```
### 6. Lägg till nytt intresse för en person
> ### POST /api/Person/{id}/interests
**Request Body**
```json
{
  "interestId": 4
}
```
**Response**
```json
{
  "id": 0,
  "firstName": "Alice",
  "lastName": "Johnson",
  "email": "alice@example.com",
  "phoneNumber": "123-456-7890",
  "interests": [
    {
      "id": 4,
      "title": "Movies",
      "description": "Watching Movies"
    }
  ],
  "links": []
}
```
### 7. Lägg till ny länk för ett intresse och en person
> ### POST /api/Link
**Request Body**
```json
{
  "url": "string",
  "interestId": 2,
  "personId": 1
}
```
**Response**
```json
{
  "url": "string"
}
```
### 8. Hämta alla intressen
> ### GET /api/Interest
**Response**
```json
[
  {
    "id": 1,
    "title": "Photography",
    "description": "Capturing moments through a lens."
  },
  {
    "id": 2,
    "title": "Programming",
    "description": "Writing code to solve problems."
  },
  {
    "id": 3,
    "title": "Biking",
    "description": "Biking around the city"
  }
]
```
### 9. Lägg till nytt intresse 
> ### POST /api/Link
**Request Body**
```json
{
  "title": "string",
  "description": "string"
}
```
**Response**
```json
{
  "id": 11,
  "title": "string",
  "description": "string",
  "links": [],
  "people": []
}
```
